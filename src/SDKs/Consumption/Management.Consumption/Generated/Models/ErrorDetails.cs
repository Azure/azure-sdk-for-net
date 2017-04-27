// MICROSOFT_MIT┬á

namespace Microsoft.Azure.Management.Consumption.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Consumption;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The details of the error.
    /// </summary>
    public partial class ErrorDetails
    {
        /// <summary>
        /// Initializes a new instance of the ErrorDetails class.
        /// </summary>
        public ErrorDetails()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ErrorDetails class.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message indicating why the operation
        /// failed.</param>
        /// <param name="target">The target of the particular error.</param>
        public ErrorDetails(string code = default(string), string message = default(string), string target = default(string))
        {
            Code = code;
            Message = message;
            Target = target;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets error code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; private set; }

        /// <summary>
        /// Gets error message indicating why the operation failed.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; private set; }

        /// <summary>
        /// Gets the target of the particular error.
        /// </summary>
        [JsonProperty(PropertyName = "target")]
        public string Target { get; private set; }

    }
}
