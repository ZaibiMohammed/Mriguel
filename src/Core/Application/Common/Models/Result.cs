namespace Mriguel.Application.Common.Models
{
    /// <summary>
    /// Represents the result of an operation
    /// </summary>
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        /// <summary>
        /// Indicates whether the operation succeeded
        /// </summary>
        public bool Succeeded { get; }

        /// <summary>
        /// Error messages if the operation failed
        /// </summary>
        public string[] Errors { get; }

        /// <summary>
        /// Creates a success result
        /// </summary>
        public static Result Success()
        {
            return new Result(true, Array.Empty<string>());
        }

        /// <summary>
        /// Creates a failure result with error messages
        /// </summary>
        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
    
    /// <summary>
    /// Represents the result of an operation with a return value
    /// </summary>
    public class Result<T> : Result
    {
        private readonly T _data;
        
        internal Result(T data, bool succeeded, IEnumerable<string> errors)
            : base(succeeded, errors)
        {
            _data = data;
        }
        
        /// <summary>
        /// Gets the value of the result
        /// </summary>
        public T Data => Succeeded
            ? _data
            : throw new InvalidOperationException("Cannot access data of a failed result.");
        
        /// <summary>
        /// Creates a success result with a value
        /// </summary>
        public static Result<T> Success(T data)
        {
            return new Result<T>(data, true, Array.Empty<string>());
        }
        
        /// <summary>
        /// Creates a failure result with error messages
        /// </summary>
        public new static Result<T> Failure(IEnumerable<string> errors)
        {
            return new Result<T>(default, false, errors);
        }
    }
}
