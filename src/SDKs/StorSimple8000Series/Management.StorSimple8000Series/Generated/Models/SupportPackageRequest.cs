
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
    /// The support package request entity.
    /// </summary>
    public partial class SupportPackageRequest
    {
        /// <summary>
        /// Initializes a new instance of the SupportPackageRequest class.
        /// </summary>
        public SupportPackageRequest() { }

        /// <summary>
        /// Initializes a new instance of the SupportPackageRequest class.
        /// </summary>
        /// <param name="sdpPassKey">The SDP(Support Diagnostics Protocol) pass
        /// key.</param>
        /// <param name="packageType">The support package type. Possible values
        /// include: 'None', 'IncludeDefault', 'IncludeAll', 'Mini',
        /// 'Custom'</param>
        /// <param name="endTime">The maximum time stamp of the logs.</param>
        /// <param name="startTime">The minimum time stamp of the logs.</param>
        /// <param name="includeArchived">The bool which determines whether the
        /// archived logs are included or not.</param>
        /// <param name="scope">The support package scope (Cluster |
        /// Controller). Possible values include: 'Cluster',
        /// 'Controller'</param>
        /// <param name="customIncludeList">The list of log categories</param>
        public SupportPackageRequest(string sdpPassKey, SupportPackageType? packageType = default(SupportPackageType?), System.DateTime? endTime = default(System.DateTime?), System.DateTime? startTime = default(System.DateTime?), bool? includeArchived = default(bool?), ScopeType? scope = default(ScopeType?), IList<CustomSupportPackageType?> customIncludeList = default(IList<CustomSupportPackageType?>))
        {
            SdpPassKey = sdpPassKey;
            PackageType = packageType;
            EndTime = endTime;
            StartTime = startTime;
            IncludeArchived = includeArchived;
            Scope = scope;
            CustomIncludeList = customIncludeList;
        }

        /// <summary>
        /// Gets or sets the SDP(Support Diagnostics Protocol) pass key.
        /// </summary>
        [JsonProperty(PropertyName = "sdpPassKey")]
        public string SdpPassKey { get; set; }

        /// <summary>
        /// Gets or sets the support package type. Possible values include:
        /// 'None', 'IncludeDefault', 'IncludeAll', 'Mini', 'Custom'
        /// </summary>
        [JsonProperty(PropertyName = "packageType")]
        public SupportPackageType? PackageType { get; set; }

        /// <summary>
        /// Gets or sets the maximum time stamp of the logs.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public System.DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the minimum time stamp of the logs.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public System.DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the bool which determines whether the archived logs
        /// are included or not.
        /// </summary>
        [JsonProperty(PropertyName = "includeArchived")]
        public bool? IncludeArchived { get; set; }

        /// <summary>
        /// Gets or sets the support package scope (Cluster | Controller).
        /// Possible values include: 'Cluster', 'Controller'
        /// </summary>
        [JsonProperty(PropertyName = "scope")]
        public ScopeType? Scope { get; set; }

        /// <summary>
        /// Gets or sets the list of log categories
        /// </summary>
        [JsonProperty(PropertyName = "customIncludeList")]
        public IList<CustomSupportPackageType?> CustomIncludeList { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (SdpPassKey == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SdpPassKey");
            }
        }
    }
}

