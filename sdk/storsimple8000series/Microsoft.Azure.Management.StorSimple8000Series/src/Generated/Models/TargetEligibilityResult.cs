
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The eligibility result of device, as a failover target device.
    /// </summary>
    public partial class TargetEligibilityResult
    {
        /// <summary>
        /// Initializes a new instance of the TargetEligibilityResult class.
        /// </summary>
        public TargetEligibilityResult() { }

        /// <summary>
        /// Initializes a new instance of the TargetEligibilityResult class.
        /// </summary>
        /// <param name="eligibilityStatus">The eligibility status of device,
        /// as a failover target device. Possible values include:
        /// 'NotEligible', 'Eligible'</param>
        /// <param name="messages">The list of error messages, if a device does
        /// not qualify as a failover target device.</param>
        public TargetEligibilityResult(TargetEligibilityStatus? eligibilityStatus = default(TargetEligibilityStatus?), IList<TargetEligibilityErrorMessage> messages = default(IList<TargetEligibilityErrorMessage>))
        {
            EligibilityStatus = eligibilityStatus;
            Messages = messages;
        }

        /// <summary>
        /// Gets or sets the eligibility status of device, as a failover target
        /// device. Possible values include: 'NotEligible', 'Eligible'
        /// </summary>
        [JsonProperty(PropertyName = "eligibilityStatus")]
        public TargetEligibilityStatus? EligibilityStatus { get; set; }

        /// <summary>
        /// Gets or sets the list of error messages, if a device does not
        /// qualify as a failover target device.
        /// </summary>
        [JsonProperty(PropertyName = "messages")]
        public IList<TargetEligibilityErrorMessage> Messages { get; set; }

    }
}

