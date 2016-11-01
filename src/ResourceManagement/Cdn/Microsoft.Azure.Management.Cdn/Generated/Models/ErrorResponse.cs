
namespace Microsoft.Azure.Management.Cdn.Models
{
    using System.Linq;

    /// <summary>
    /// Error reponse indicates CDN service is not able to process the
    /// incoming request. The reason is provided in the error message.
    /// </summary>
    public partial class ErrorResponse
    {
        /// <summary>
        /// Initializes a new instance of the ErrorResponse class.
        /// </summary>
        public ErrorResponse() { }

        /// <summary>
        /// Initializes a new instance of the ErrorResponse class.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message indicating why the operation
        /// failed.</param>
        public ErrorResponse(string code = default(string), string message = default(string))
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Gets or sets error code.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets error message indicating why the operation failed.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
