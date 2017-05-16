// %~6

namespace Microsoft.Azure.Management.Relay.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Relay;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for UnavailableReason.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnavailableReason
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "InvalidName")]
        InvalidName,
        [EnumMember(Value = "SubscriptionIsDisabled")]
        SubscriptionIsDisabled,
        [EnumMember(Value = "NameInUse")]
        NameInUse,
        [EnumMember(Value = "NameInLockdown")]
        NameInLockdown,
        [EnumMember(Value = "TooManyNamespaceInCurrentSubscription")]
        TooManyNamespaceInCurrentSubscription
    }
}
