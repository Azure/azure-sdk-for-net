
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The details of the error for which the alert was raised
    /// </summary>
    public partial class AlertErrorDetails
    {
        /// <summary>
        /// Initializes a new instance of the AlertErrorDetails class.
        /// </summary>
        public AlertErrorDetails() { }

        /// <summary>
        /// Initializes a new instance of the AlertErrorDetails class.
        /// </summary>
        /// <param name="errorCode">The error code</param>
        /// <param name="errorMessage">The error message</param>
        /// <param name="occurences">The number of occurences</param>
        public AlertErrorDetails(string errorCode = default(string), string errorMessage = default(string), int? occurences = default(int?))
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Occurences = occurences;
        }

        /// <summary>
        /// Gets or sets the error code
        /// </summary>
        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the number of occurences
        /// </summary>
        [JsonProperty(PropertyName = "occurences")]
        public int? Occurences { get; set; }

    }
}

