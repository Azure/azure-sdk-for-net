// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RedisEnterprise.Models
{
    [CodeGenSerialization(nameof(FirewallRules), SerializationValueHook = nameof(SerializeFirewallRules), DeserializationValueHook = nameof(DeserializeFirewallRules))]
    internal partial class ClusterProperties
    {
        // Generated readers coalesce null collections before construction. Keep explicit JSON
        // null distinct from omitted rules and the null passed by historical model factories.
        private static readonly IList<FirewallRule> ExplicitNullFirewallRules = new List<FirewallRule>();
        private IList<FirewallRule>? _firewallRules = new ChangeTrackingList<FirewallRule>();

        // Generated compatibility factories pass null for rules absent from the released API.
        // Normalize constructor null to an undefined collection; explicit assignments use
        // SetFirewallRules so they can clear rules without affecting omitted factory arguments.
        public IList<FirewallRule>? FirewallRules
        {
            get => _firewallRules;
            private set => _firewallRules = ReferenceEquals(value, ExplicitNullFirewallRules)
                ? null : value ?? new ChangeTrackingList<FirewallRule>();
        }

        internal void SetFirewallRules(IEnumerable<FirewallRule>? firewallRules)
            => _firewallRules = firewallRules?.ToList();

        private void SerializeFirewallRules(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (FirewallRules == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStartArray();
            foreach (FirewallRule rule in FirewallRules)
            {
                writer.WriteObjectValue(rule, options);
            }
            writer.WriteEndArray();
        }

        internal static void DeserializeFirewallRules(JsonProperty property, ref IList<FirewallRule> firewallRules)
        {
            firewallRules = property.Value.ValueKind == JsonValueKind.Null
                ? ExplicitNullFirewallRules
                : property.Value.EnumerateArray()
                    .Select(item => FirewallRule.DeserializeFirewallRule(item, ModelReaderWriterOptions.Json))
                    .ToList();
        }
    }
}
