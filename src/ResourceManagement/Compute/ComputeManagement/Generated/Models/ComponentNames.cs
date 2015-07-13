namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ComponentNames
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ComponentNames
    {
        [EnumMember(Value = "Microsoft-Windows-Shell-Setup")]
        MicrosoftWindowsShellSetup
    }
}
