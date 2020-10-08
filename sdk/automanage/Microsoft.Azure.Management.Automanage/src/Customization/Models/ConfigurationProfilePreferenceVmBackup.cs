namespace Microsoft.Azure.Management.Automanage.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Linq;

    /// <summary>
    /// Automanage configuration profile VM Backup preferences.
    /// </summary>
    public partial class ConfigurationProfilePreferenceVmBackup
    {
        /// <summary>
        /// Gets or sets retention policy with the details on backup copy
        /// retention ranges.
        /// </summary>
        [JsonProperty(PropertyName = "retentionPolicy")]
        public JObject RetentionPolicy { get; set; }
        /// <summary>
        /// Gets or sets backup schedule specified as part of backup policy.
        /// </summary>
        [JsonProperty(PropertyName = "schedulePolicy")]
        public JObject SchedulePolicy { get; set; }
    }
}