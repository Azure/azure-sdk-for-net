
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for EncryptionAlgorithm.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum EncryptionAlgorithm
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "AES256")]
        AES256,
        [EnumMember(Value = "RSAES_PKCS1_v_1_5")]
        RSAESPKCS1V15
    }
}

