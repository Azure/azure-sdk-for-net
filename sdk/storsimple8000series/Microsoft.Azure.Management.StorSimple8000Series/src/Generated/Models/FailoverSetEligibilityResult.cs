
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The eligibility result of failover set, for failover.
    /// </summary>
    public partial class FailoverSetEligibilityResult
    {
        /// <summary>
        /// Initializes a new instance of the FailoverSetEligibilityResult
        /// class.
        /// </summary>
        public FailoverSetEligibilityResult() { }

        /// <summary>
        /// Initializes a new instance of the FailoverSetEligibilityResult
        /// class.
        /// </summary>
        /// <param name="isEligibleForFailover">Represents if this failover set
        /// is eligible for failover or not.</param>
        /// <param name="errorMessage">The error message, if the failover set
        /// is not eligible for failover.</param>
        public FailoverSetEligibilityResult(bool? isEligibleForFailover = default(bool?), string errorMessage = default(string))
        {
            IsEligibleForFailover = isEligibleForFailover;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Gets or sets represents if this failover set is eligible for
        /// failover or not.
        /// </summary>
        [JsonProperty(PropertyName = "isEligibleForFailover")]
        public bool? IsEligibleForFailover { get; set; }

        /// <summary>
        /// Gets or sets the error message, if the failover set is not eligible
        /// for failover.
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }

    }
}

