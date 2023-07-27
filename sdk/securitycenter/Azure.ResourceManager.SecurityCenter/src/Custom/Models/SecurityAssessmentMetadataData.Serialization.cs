// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityAssessmentMetadataData : IUtf8JsonSerializable
    {
        /// <summary> Avoid Deserialization failure issue when policyDefinitionId == "" </summary>
        internal static SecurityAssessmentMetadataData DeserializeSecurityAssessmentMetadataData(JsonElement element)
        {
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<string> displayName = default;
            Optional<ResourceIdentifier> policyDefinitionId = default;
            Optional<string> description = default;
            Optional<string> remediationDescription = default;
            Optional<IList<SecurityAssessmentResourceCategory>> categories = default;
            Optional<SecurityAssessmentSeverity> severity = default;
            Optional<SecurityAssessmentUserImpact> userImpact = default;
            Optional<ImplementationEffort> implementationEffort = default;
            Optional<IList<SecurityThreat>> threats = default;
            Optional<bool> preview = default;
            Optional<SecurityAssessmentType> assessmentType = default;
            Optional<SecurityAssessmentMetadataPartner> partnerData = default;
            Optional<SecurityAssessmentPublishDates> publishDates = default;
            Optional<string> plannedDeprecationDate = default;
            Optional<IList<SecurityAssessmentTactic>> tactics = default;
            Optional<IList<SecurityAssessmentTechnique>> techniques = default;
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
                        if (property0.NameEquals("displayName"))
                        {
                            displayName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("policyDefinitionId"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            if (string.IsNullOrEmpty(property0.Value.GetString()))
                            {
                                continue;
                            }
                            policyDefinitionId = new ResourceIdentifier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("description"))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("remediationDescription"))
                        {
                            remediationDescription = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("categories"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<SecurityAssessmentResourceCategory> array = new List<SecurityAssessmentResourceCategory>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new SecurityAssessmentResourceCategory(item.GetString()));
                            }
                            categories = array;
                            continue;
                        }
                        if (property0.NameEquals("severity"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            severity = new SecurityAssessmentSeverity(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("userImpact"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            userImpact = new SecurityAssessmentUserImpact(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("implementationEffort"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            implementationEffort = new ImplementationEffort(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("threats"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<SecurityThreat> array = new List<SecurityThreat>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new SecurityThreat(item.GetString()));
                            }
                            threats = array;
                            continue;
                        }
                        if (property0.NameEquals("preview"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            preview = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("assessmentType"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            assessmentType = new SecurityAssessmentType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("partnerData"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            partnerData = SecurityAssessmentMetadataPartner.DeserializeSecurityAssessmentMetadataPartner(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("publishDates"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            publishDates = SecurityAssessmentPublishDates.DeserializeSecurityAssessmentPublishDates(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("plannedDeprecationDate"))
                        {
                            plannedDeprecationDate = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("tactics"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<SecurityAssessmentTactic> array = new List<SecurityAssessmentTactic>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new SecurityAssessmentTactic(item.GetString()));
                            }
                            tactics = array;
                            continue;
                        }
                        if (property0.NameEquals("techniques"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<SecurityAssessmentTechnique> array = new List<SecurityAssessmentTechnique>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new SecurityAssessmentTechnique(item.GetString()));
                            }
                            techniques = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new SecurityAssessmentMetadataData(id, name, type, systemData.Value, displayName.Value, policyDefinitionId.Value, description.Value, remediationDescription.Value, Optional.ToList(categories), Optional.ToNullable(severity), Optional.ToNullable(userImpact), Optional.ToNullable(implementationEffort), Optional.ToList(threats), Optional.ToNullable(preview), Optional.ToNullable(assessmentType), partnerData.Value, publishDates.Value, plannedDeprecationDate.Value, Optional.ToList(tactics), Optional.ToList(techniques));
        }
    }
}
