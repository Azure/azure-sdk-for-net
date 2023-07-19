
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The job error details. Contains list of job error items.
    /// </summary>
    public partial class JobErrorDetails
    {
        /// <summary>
        /// Initializes a new instance of the JobErrorDetails class.
        /// </summary>
        public JobErrorDetails() { }

        /// <summary>
        /// Initializes a new instance of the JobErrorDetails class.
        /// </summary>
        /// <param name="code">The error code intended for programmatic
        /// access.</param>
        /// <param name="message">The error message intended to describe the
        /// error in detail.</param>
        /// <param name="errorDetails">The error details.</param>
        public JobErrorDetails(string code, string message, IList<JobErrorItem> errorDetails = default(IList<JobErrorItem>))
        {
            ErrorDetails = errorDetails;
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Gets or sets the error details.
        /// </summary>
        [JsonProperty(PropertyName = "errorDetails")]
        public IList<JobErrorItem> ErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets the error code intended for programmatic access.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the error message intended to describe the error in
        /// detail.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Code == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Code");
            }
            if (Message == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Message");
            }
            if (ErrorDetails != null)
            {
                foreach (var element in ErrorDetails)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}

