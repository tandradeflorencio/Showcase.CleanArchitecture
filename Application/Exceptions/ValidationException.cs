using Showcase.CleanArchitecture.Domain.Exceptions.Base;

namespace Showcase.CleanArchitecture.Application.Exceptions
{
    public sealed class ValidationException(Dictionary<string, string[]> errors) : BadRequestException(DefaultValidationMessage)
    {
        private const string DefaultValidationMessage = "Validation errors occurred";
        public Dictionary<string, string[]> Errors { get; } = errors;
    }
}