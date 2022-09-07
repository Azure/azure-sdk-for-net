// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.Models;
using System.Text.Json;

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class PortalSettingsContractData : IUtf8JsonSerializable
    {
        internal static PortalSettingsContractData DeserializePortalSettingsContractData(JsonElement element)
        {
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<Uri> uri = default;
            Optional<string> validationKey = default;
            Optional<SubscriptionDelegationSettingProperties> subscriptions = default;
            Optional<RegistrationDelegationSettingProperties> userRegistration = default;
            Optional<bool> enabled = default;
            Optional<TermsOfServiceProperties> termsOfService = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("url"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null || string.IsNullOrEmpty(property0.Value.GetString()))
                            {
                                uri = null;
                                continue;
                            }
                            uri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("validationKey"))
                        {
                            validationKey = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("subscriptions"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                subscriptions = null;
                                continue;
                            }
                            subscriptions = SubscriptionDelegationSettingProperties.DeserializeSubscriptionDelegationSettingProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("userRegistration"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                userRegistration = null;
                                continue;
                            }
                            userRegistration = RegistrationDelegationSettingProperties.DeserializeRegistrationDelegationSettingProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("enabled"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            enabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("termsOfService"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                termsOfService = null;
                                continue;
                            }
                            termsOfService = TermsOfServiceProperties.DeserializeTermsOfServiceProperties(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new PortalSettingsContractData(id, name, type, systemData.Value, uri.Value, validationKey.Value, subscriptions.Value, userRegistration.Value, Optional.ToNullable(enabled), termsOfService.Value);
        }
    }
}
