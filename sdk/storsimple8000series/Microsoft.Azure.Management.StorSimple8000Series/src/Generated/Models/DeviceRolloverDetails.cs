
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The additional device details for the service data encryption key
    /// rollover.
    /// </summary>
    public partial class DeviceRolloverDetails
    {
        /// <summary>
        /// Initializes a new instance of the DeviceRolloverDetails class.
        /// </summary>
        public DeviceRolloverDetails() { }

        /// <summary>
        /// Initializes a new instance of the DeviceRolloverDetails class.
        /// </summary>
        /// <param name="authorizationEligibility">The eligibility status of
        /// device for service data encryption key rollover. Possible values
        /// include: 'InEligible', 'Eligible'</param>
        /// <param name="authorizationStatus">The authorization status of the
        /// device for service data encryption key rollover. Possible values
        /// include: 'Disabled', 'Enabled'</param>
        /// <param name="inEligibilityReason">The reason for inEligibility of
        /// device, in case it's not eligible for service data encryption key
        /// rollover. Possible values include: 'DeviceNotOnline',
        /// 'NotSupportedAppliance', 'RolloverPending'</param>
        public DeviceRolloverDetails(AuthorizationEligibility? authorizationEligibility = default(AuthorizationEligibility?), AuthorizationStatus? authorizationStatus = default(AuthorizationStatus?), InEligibilityCategory? inEligibilityReason = default(InEligibilityCategory?))
        {
            AuthorizationEligibility = authorizationEligibility;
            AuthorizationStatus = authorizationStatus;
            InEligibilityReason = inEligibilityReason;
        }

        /// <summary>
        /// Gets or sets the eligibility status of device for service data
        /// encryption key rollover. Possible values include: 'InEligible',
        /// 'Eligible'
        /// </summary>
        [JsonProperty(PropertyName = "authorizationEligibility")]
        public AuthorizationEligibility? AuthorizationEligibility { get; set; }

        /// <summary>
        /// Gets or sets the authorization status of the device for service
        /// data encryption key rollover. Possible values include: 'Disabled',
        /// 'Enabled'
        /// </summary>
        [JsonProperty(PropertyName = "authorizationStatus")]
        public AuthorizationStatus? AuthorizationStatus { get; set; }

        /// <summary>
        /// Gets or sets the reason for inEligibility of device, in case it's
        /// not eligible for service data encryption key rollover. Possible
        /// values include: 'DeviceNotOnline', 'NotSupportedAppliance',
        /// 'RolloverPending'
        /// </summary>
        [JsonProperty(PropertyName = "inEligibilityReason")]
        public InEligibilityCategory? InEligibilityReason { get; set; }

    }
}

