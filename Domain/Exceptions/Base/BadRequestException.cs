namespace Showcase.CleanArchitecture.Domain.Exceptions.Base
{
    public abstract class BadRequestException(string message) : Exception(message)
    {
    }
}