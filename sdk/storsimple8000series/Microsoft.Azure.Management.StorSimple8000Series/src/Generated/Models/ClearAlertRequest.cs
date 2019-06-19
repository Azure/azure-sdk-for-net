
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
    /// The request for clearing the alert
    /// </summary>
    public partial class ClearAlertRequest
    {
        /// <summary>
        /// Initializes a new instance of the ClearAlertRequest class.
        /// </summary>
        public ClearAlertRequest() { }

        /// <summary>
        /// Initializes a new instance of the ClearAlertRequest class.
        /// </summary>
        /// <param name="alerts">The list of alert IDs to be cleared</param>
        /// <param name="resolutionMessage">The resolution message while
        /// clearing the alert</param>
        public ClearAlertRequest(IList<string> alerts, string resolutionMessage = default(string))
        {
            ResolutionMessage = resolutionMessage;
            Alerts = alerts;
        }

        /// <summary>
        /// Gets or sets the resolution message while clearing the alert
        /// </summary>
        [JsonProperty(PropertyName = "resolutionMessage")]
        public string ResolutionMessage { get; set; }

        /// <summary>
        /// Gets or sets the list of alert IDs to be cleared
        /// </summary>
        [JsonProperty(PropertyName = "alerts")]
        public IList<string> Alerts { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Alerts == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Alerts");
            }
        }
    }
}

