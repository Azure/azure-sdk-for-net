
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for OperationStatus.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum OperationStatus
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Updating")]
        Updating,
        [EnumMember(Value = "Deleting")]
        Deleting,
        [EnumMember(Value = "Restoring")]
        Restoring
    }
}

