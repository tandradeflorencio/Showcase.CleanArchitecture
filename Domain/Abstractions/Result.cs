namespace Showcase.CleanArchitecture.Domain.Abstractions
{
    public class Result
    {
        private Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
            {
                throw new ArgumentException("Invalid state", nameof(error));
            }

            if (!isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid state", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public Error Error { get; set; }

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);
    }
}