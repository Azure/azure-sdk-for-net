namespace Microsoft.Azure.Management.Resources.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for DeploymentMode.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeploymentMode
    {
        [EnumMember(Value = "Incremental")]
        Incremental
    }
}
