namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for PassNames
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PassNames
    {
        [EnumMember(Value = "oobeSystem")]
        OobeSystem
    }
}
