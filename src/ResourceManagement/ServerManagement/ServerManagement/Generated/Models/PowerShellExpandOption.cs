
namespace Microsoft.Azure.Management.ServerManagement.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for PowerShellExpandOption.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PowerShellExpandOption
    {
        [EnumMember(Value = "output")]
        Output
    }
}
