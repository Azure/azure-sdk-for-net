// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Network
{
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using System.Linq;

    public partial class NetworkManagementClient : ServiceClient<NetworkManagementClient>, INetworkManagementClient, IAzureClient
    {
        partial void CustomInitialize()
        {
            // first remove the converters added by generated code for the FirewallPolicyRule and RuleCondition
            DeserializationSettings.Converters.Remove(DeserializationSettings.Converters.FirstOrDefault(c => c.GetType() == typeof(PolymorphicDeserializeJsonConverter<FirewallPolicyRule>)));
            DeserializationSettings.Converters.Remove(DeserializationSettings.Converters.FirstOrDefault(c => c.GetType() == typeof(PolymorphicDeserializeJsonConverter<FirewallPolicyRuleCollection>)));
            SerializationSettings.Converters.Remove(SerializationSettings.Converters.FirstOrDefault(c => c.GetType() == typeof(PolymorphicSerializeJsonConverter<FirewallPolicyRule>)));
            SerializationSettings.Converters.Remove(SerializationSettings.Converters.FirstOrDefault(c => c.GetType() == typeof(PolymorphicSerializeJsonConverter<FirewallPolicyRuleCollection>)));

            // now add the correct converters
            DeserializationSettings.Converters.Add(new PolymorphicJsonCustomConverter<FirewallPolicyRuleCollection, FirewallPolicyRule>("ruleCollectionType", "ruleType"));
            SerializationSettings.Converters.Add(new PolymorphicJsonCustomConverter<FirewallPolicyRuleCollection, FirewallPolicyRule>("ruleCollectionType", "ruleType"));
        }
    }
}