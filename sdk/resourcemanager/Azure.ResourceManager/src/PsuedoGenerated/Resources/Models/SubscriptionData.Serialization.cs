// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    public partial class SubscriptionData
    {
        internal static SubscriptionData DeserializeSubscriptionData(JsonElement element)
        {
            Optional<ResourceIdentifier> id = default;
            Optional<string> subscriptionId = default;
            Optional<string> displayName = default;
            Optional<string> tenantId = default;
            Optional<SubscriptionState> state = default;
            Optional<SubscriptionPolicies> subscriptionPolicies = default;
            Optional<string> authorizationSource = default;
            Optional<IReadOnlyList<ManagedByTenant>> managedByTenants = default;
            Optional<IDictionary<string, string>> tags = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("subscriptionId"))
                {
                    subscriptionId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("displayName"))
                {
                    displayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tenantId"))
                {
                    tenantId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("state"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    state = property.Value.GetString().ToSubscriptionState();
                    continue;
                }
                if (property.NameEquals("subscriptionPolicies"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    subscriptionPolicies = SubscriptionPolicies.DeserializeSubscriptionPolicies(property.Value);
                    continue;
                }
                if (property.NameEquals("authorizationSource"))
                {
                    authorizationSource = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("managedByTenants"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ManagedByTenant> array = new List<ManagedByTenant>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ManagedByTenant.DeserializeManagedByTenant(item));
                    }
                    managedByTenants = array;
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
            }
            return new SubscriptionData(id.Value, displayName.Value, subscriptionId.Value, tenantId.Value, Optional.ToNullable(state), subscriptionPolicies.Value, authorizationSource.Value, Optional.ToList(managedByTenants), Optional.ToDictionary(tags));
        }
    }
}
