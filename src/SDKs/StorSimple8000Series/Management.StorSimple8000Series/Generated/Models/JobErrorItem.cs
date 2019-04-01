
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
    /// The job error items.
    /// </summary>
    public partial class JobErrorItem
    {
        /// <summary>
        /// Initializes a new instance of the JobErrorItem class.
        /// </summary>
        public JobErrorItem() { }

        /// <summary>
        /// Initializes a new instance of the JobErrorItem class.
        /// </summary>
        /// <param name="code">The error code intended for programmatic
        /// access.</param>
        /// <param name="message">The error message intended to describe the
        /// error in detail.</param>
        /// <param name="recommendations">The recommended actions.</param>
        public JobErrorItem(string code, string message, IList<string> recommendations = default(IList<string>))
        {
            Recommendations = recommendations;
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Gets or sets the recommended actions.
        /// </summary>
        [JsonProperty(PropertyName = "recommendations")]
        public IList<string> Recommendations { get; set; }

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
        }
    }
}

