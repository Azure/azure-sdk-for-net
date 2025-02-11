// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Billing.Models
{
    public partial class BillingRoleAssignmentProperties : IUtf8JsonSerializable, IJsonModel<BillingRoleAssignmentProperties>
    {
        internal static BillingRoleAssignmentProperties DeserializeBillingRoleAssignmentProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BillingProvisioningState? provisioningState = default;
            DateTimeOffset? createdOn = default;
            Guid? createdByPrincipalTenantId = default;
            string createdByPrincipalId = default;
            string createdByPrincipalPuid = default;
            string createdByUserEmailAddress = default;
            DateTimeOffset? modifiedOn = default;
            string modifiedByPrincipalPuid = default;
            string modifiedByUserEmailAddress = default;
            string modifiedByPrincipalId = default;
            Guid? modifiedByPrincipalTenantId = default;
            string principalPuid = default;
            string principalId = default;
            Guid? principalTenantId = default;
            ResourceIdentifier roleDefinitionId = default;
            string scope = default;
            string userAuthenticationType = default;
            string userEmailAddress = default;
            string principalTenantName = default;
            string principalDisplayName = default;
            BillingPrincipalType? principalType = default;
            ResourceIdentifier billingRequestId = default;
            ResourceIdentifier billingAccountId = default;
            string billingAccountDisplayName = default;
            ResourceIdentifier billingProfileId = default;
            string billingProfileDisplayName = default;
            ResourceIdentifier invoiceSectionId = default;
            string invoiceSectionDisplayName = default;
            ResourceIdentifier customerId = default;
            string customerDisplayName = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("provisioningState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisioningState = new BillingProvisioningState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("createdOn"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    createdOn = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("createdByPrincipalTenantId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || string.IsNullOrEmpty(property.Value.GetString()))
                    {
                        continue;
                    }
                    createdByPrincipalTenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("createdByPrincipalId"u8))
                {
                    createdByPrincipalId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("createdByPrincipalPuid"u8))
                {
                    createdByPrincipalPuid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("createdByUserEmailAddress"u8))
                {
                    createdByUserEmailAddress = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modifiedOn"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    modifiedOn = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("modifiedByPrincipalPuid"u8))
                {
                    modifiedByPrincipalPuid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modifiedByUserEmailAddress"u8))
                {
                    modifiedByUserEmailAddress = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modifiedByPrincipalId"u8))
                {
                    modifiedByPrincipalId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modifiedByPrincipalTenantId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    modifiedByPrincipalTenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("principalPuid"u8))
                {
                    principalPuid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("principalId"u8))
                {
                    principalId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("principalTenantId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    principalTenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("roleDefinitionId"u8))
                {
                    roleDefinitionId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("scope"u8))
                {
                    scope = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("userAuthenticationType"u8))
                {
                    userAuthenticationType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("userEmailAddress"u8))
                {
                    userEmailAddress = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("principalTenantName"u8))
                {
                    principalTenantName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("principalDisplayName"u8))
                {
                    principalDisplayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("principalType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    principalType = new BillingPrincipalType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("billingRequestId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    billingRequestId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("billingAccountId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    billingAccountId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("billingAccountDisplayName"u8))
                {
                    billingAccountDisplayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("billingProfileId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    billingProfileId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("billingProfileDisplayName"u8))
                {
                    billingProfileDisplayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("invoiceSectionId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    invoiceSectionId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("invoiceSectionDisplayName"u8))
                {
                    invoiceSectionDisplayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customerId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    customerId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("customerDisplayName"u8))
                {
                    customerDisplayName = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new BillingRoleAssignmentProperties(
                provisioningState,
                createdOn,
                createdByPrincipalTenantId,
                createdByPrincipalId,
                createdByPrincipalPuid,
                createdByUserEmailAddress,
                modifiedOn,
                modifiedByPrincipalPuid,
                modifiedByUserEmailAddress,
                modifiedByPrincipalId,
                modifiedByPrincipalTenantId,
                principalPuid,
                principalId,
                principalTenantId,
                roleDefinitionId,
                scope,
                userAuthenticationType,
                userEmailAddress,
                principalTenantName,
                principalDisplayName,
                principalType,
                billingRequestId,
                billingAccountId,
                billingAccountDisplayName,
                billingProfileId,
                billingProfileDisplayName,
                invoiceSectionId,
                invoiceSectionDisplayName,
                customerId,
                customerDisplayName,
                serializedAdditionalRawData);
        }
    }
}
