namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ApplicationGatewaySkuName
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApplicationGatewaySkuName
    {
        [EnumMember(Value = "Standard_Small")]
        StandardSmall,
        [EnumMember(Value = "Standard_Medium")]
        StandardMedium,
        [EnumMember(Value = "Standard_Large")]
        StandardLarge
    }
}
