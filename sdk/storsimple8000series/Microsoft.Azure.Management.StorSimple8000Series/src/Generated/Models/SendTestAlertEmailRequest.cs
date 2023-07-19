
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
    /// The request for sending test alert email
    /// </summary>
    public partial class SendTestAlertEmailRequest
    {
        /// <summary>
        /// Initializes a new instance of the SendTestAlertEmailRequest class.
        /// </summary>
        public SendTestAlertEmailRequest() { }

        /// <summary>
        /// Initializes a new instance of the SendTestAlertEmailRequest class.
        /// </summary>
        /// <param name="emailList">The list of email IDs to send the test
        /// alert email</param>
        public SendTestAlertEmailRequest(IList<string> emailList)
        {
            EmailList = emailList;
        }

        /// <summary>
        /// Gets or sets the list of email IDs to send the test alert email
        /// </summary>
        [JsonProperty(PropertyName = "emailList")]
        public IList<string> EmailList { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (EmailList == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "EmailList");
            }
        }
    }
}

