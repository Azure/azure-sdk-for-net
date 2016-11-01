
namespace Microsoft.Azure.Management.Cdn.Models
{

    /// <summary>
    /// Defines values for GeoFilterActions.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum GeoFilterActions
    {
        [System.Runtime.Serialization.EnumMember(Value = "Block")]
        Block,
        [System.Runtime.Serialization.EnumMember(Value = "Allow")]
        Allow
    }
}
