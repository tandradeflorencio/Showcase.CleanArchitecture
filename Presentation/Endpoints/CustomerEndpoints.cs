using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Showcase.CleanArchitecture.Application.Customers.Commands.CreateCustomer;
using Showcase.CleanArchitecture.Application.Customers.Queries.GetCustomerById;

namespace Showcase.CleanArchitecture.Presentation.Endpoints
{
    public static class CustomerEndpoints
    {
        public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/customers",
            [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            async ([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken, ISender sender) =>
            {
                var command = request.Adapt<CreateCustomerCommand>();

                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess ?
                    Results.Created() :
                    Results.BadRequest();
            })
            .WithTags("Customers")
            .WithOpenApi();

            app.MapGet("api/customers/{customerId:guid}",
            [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            async (Guid customerId, CancellationToken cancellationToken, ISender sender) =>
            {
                var query = new GetCustomerByIdQuery(customerId);

                var customer = await sender.Send(query, cancellationToken);

                return Results.Ok(customer);
            })
            .WithTags("Customers")
            .WithOpenApi();
        }
    }
}