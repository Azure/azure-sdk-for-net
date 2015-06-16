namespace Microsoft.Azure.Management.Storage.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for KeyName
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KeyName
    {
        [EnumMember(Value = "key1")]
        Key1,
        [EnumMember(Value = "key2")]
        Key2
    }
}
