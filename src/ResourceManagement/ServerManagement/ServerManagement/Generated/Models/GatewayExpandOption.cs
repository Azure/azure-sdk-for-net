
namespace Microsoft.Azure.Management.ServerManagement.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for GatewayExpandOption.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GatewayExpandOption
    {
        [EnumMember(Value = "status")]
        Status
    }
}
