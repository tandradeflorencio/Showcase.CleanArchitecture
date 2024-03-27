﻿using Showcase.CleanArchitecture.Domain.Exceptions.Base;
using System.Text.Json;

namespace Showcase.CleanArchitecture.Presentation.Middlewares
{
    internal sealed class ExceptionHandlingMiddleware(Serilog.ILogger logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException or Application.Exceptions.ValidationException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            var errors = Array.Empty<ApiError>();

            if (exception is Application.Exceptions.ValidationException validationException)
            {
                errors = validationException.Errors
                    .SelectMany(kvp => kvp.Value,
                        (kvp, value) => new ApiError(kvp.Key, value))
                        .ToArray();
            }

            var response = new
            {
                status = httpContext.Response.StatusCode,
                message = exception.Message,
                errors
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private record ApiError(string PropertyName, string ErrorMessage);
    }
}