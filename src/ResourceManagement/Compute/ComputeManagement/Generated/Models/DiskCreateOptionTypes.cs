namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for DiskCreateOptionTypes
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DiskCreateOptionTypes
    {
        [EnumMember(Value = "fromImage")]
        FromImage,
        [EnumMember(Value = "empty")]
        Empty,
        [EnumMember(Value = "attach")]
        Attach
    }
}
