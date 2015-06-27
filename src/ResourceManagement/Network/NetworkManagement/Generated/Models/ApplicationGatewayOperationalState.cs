namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ApplicationGatewayOperationalState
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApplicationGatewayOperationalState
    {
        [EnumMember(Value = "Stopped")]
        Stopped,
        [EnumMember(Value = "Starting")]
        Starting,
        [EnumMember(Value = "Running")]
        Running,
        [EnumMember(Value = "Stopping")]
        Stopping
    }
}
