
namespace Microsoft.Azure.Management.CognitiveServices.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for Kind.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Kind
    {
        [EnumMember(Value = "ComputerVision")]
        ComputerVision,
        [EnumMember(Value = "Emotion")]
        Emotion,
        [EnumMember(Value = "Face")]
        Face,
        [EnumMember(Value = "LUIS")]
        LUIS,
        [EnumMember(Value = "Recommendations")]
        Recommendations,
        [EnumMember(Value = "Speech")]
        Speech,
        [EnumMember(Value = "TextAnalytics")]
        TextAnalytics,
        [EnumMember(Value = "WebLM")]
        WebLM
    }
}
