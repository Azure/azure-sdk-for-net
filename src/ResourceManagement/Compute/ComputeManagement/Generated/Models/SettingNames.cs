namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for SettingNames.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SettingNames
    {
        [EnumMember(Value = "AutoLogon")]
        AutoLogon,
        [EnumMember(Value = "FirstLogonCommands")]
        FirstLogonCommands
    }
}
