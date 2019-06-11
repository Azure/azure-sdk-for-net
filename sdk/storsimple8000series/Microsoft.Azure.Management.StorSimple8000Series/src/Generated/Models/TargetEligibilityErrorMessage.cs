
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The error/warning message due to which the device is ineligible as a
    /// failover target device.
    /// </summary>
    public partial class TargetEligibilityErrorMessage
    {
        /// <summary>
        /// Initializes a new instance of the TargetEligibilityErrorMessage
        /// class.
        /// </summary>
        public TargetEligibilityErrorMessage() { }

        /// <summary>
        /// Initializes a new instance of the TargetEligibilityErrorMessage
        /// class.
        /// </summary>
        /// <param name="message">The localized error message stating the
        /// reason why the device is not eligible as a target device.</param>
        /// <param name="resolution">The localized resolution message for the
        /// error.</param>
        /// <param name="resultCode">The result code for the error, due to
        /// which the device does not qualify as a failover target device.
        /// Possible values include: 'TargetAndSourceCannotBeSameError',
        /// 'TargetIsNotOnlineError', 'TargetSourceIncompatibleVersionError',
        /// 'LocalToTieredVolumesConversionWarning',
        /// 'TargetInsufficientCapacityError',
        /// 'TargetInsufficientLocalVolumeMemoryError',
        /// 'TargetInsufficientTieredVolumeMemoryError'</param>
        public TargetEligibilityErrorMessage(string message = default(string), string resolution = default(string), TargetEligibilityResultCode? resultCode = default(TargetEligibilityResultCode?))
        {
            Message = message;
            Resolution = resolution;
            ResultCode = resultCode;
        }

        /// <summary>
        /// Gets or sets the localized error message stating the reason why the
        /// device is not eligible as a target device.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the localized resolution message for the error.
        /// </summary>
        [JsonProperty(PropertyName = "resolution")]
        public string Resolution { get; set; }

        /// <summary>
        /// Gets or sets the result code for the error, due to which the device
        /// does not qualify as a failover target device. Possible values
        /// include: 'TargetAndSourceCannotBeSameError',
        /// 'TargetIsNotOnlineError', 'TargetSourceIncompatibleVersionError',
        /// 'LocalToTieredVolumesConversionWarning',
        /// 'TargetInsufficientCapacityError',
        /// 'TargetInsufficientLocalVolumeMemoryError',
        /// 'TargetInsufficientTieredVolumeMemoryError'
        /// </summary>
        [JsonProperty(PropertyName = "resultCode")]
        public TargetEligibilityResultCode? ResultCode { get; set; }

    }
}

