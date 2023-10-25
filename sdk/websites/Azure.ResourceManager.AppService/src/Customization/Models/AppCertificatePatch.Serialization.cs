// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class AppCertificatePatch : IUtf8JsonSerializable
    {
        internal static AppCertificatePatch DeserializeAppCertificatePatch(JsonElement element)
        {
            Optional<string> kind = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> password = default;
            Optional<string> friendlyName = default;
            Optional<string> subjectName = default;
            Optional<IList<string>> hostNames = default;
            Optional<byte[]> pfxBlob = default;
            Optional<string> siteName = default;
            Optional<string> selfLink = default;
            Optional<string> issuer = default;
            Optional<DateTimeOffset> issueDate = default;
            Optional<DateTimeOffset> expirationDate = default;
            Optional<string> thumbprintString = default;
            Optional<bool> valid = default;
            Optional<byte[]> cerBlob = default;
            Optional<string> publicKeyHash = default;
            Optional<HostingEnvironmentProfile> hostingEnvironmentProfile = default;
            Optional<ResourceIdentifier> keyVaultId = default;
            Optional<string> keyVaultSecretName = default;
            Optional<KeyVaultSecretStatus> keyVaultSecretStatus = default;
            Optional<ResourceIdentifier> serverFarmId = default;
            Optional<string> canonicalName = default;
            Optional<string> domainValidationMethod = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("password"u8))
                        {
                            password = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("friendlyName"u8))
                        {
                            friendlyName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("subjectName"u8))
                        {
                            subjectName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("hostNames"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            hostNames = array;
                            continue;
                        }
                        if (property0.NameEquals("pfxBlob"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            pfxBlob = property0.Value.GetBytesFromBase64("D");
                            continue;
                        }
                        if (property0.NameEquals("siteName"u8))
                        {
                            siteName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("selfLink"u8))
                        {
                            selfLink = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("issuer"u8))
                        {
                            issuer = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("issueDate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            issueDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("expirationDate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            expirationDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("thumbprint"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            thumbprintString = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("valid"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            valid = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("cerBlob"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            cerBlob = property0.Value.GetBytesFromBase64("D");
                            continue;
                        }
                        if (property0.NameEquals("publicKeyHash"u8))
                        {
                            publicKeyHash = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("hostingEnvironmentProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            hostingEnvironmentProfile = HostingEnvironmentProfile.DeserializeHostingEnvironmentProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("keyVaultId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null || property0.Value.GetString().Length == 0)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            keyVaultId = new ResourceIdentifier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("keyVaultSecretName"u8))
                        {
                            keyVaultSecretName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("keyVaultSecretStatus"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            keyVaultSecretStatus = property0.Value.GetString().ToKeyVaultSecretStatus();
                            continue;
                        }
                        if (property0.NameEquals("serverFarmId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            serverFarmId = new ResourceIdentifier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("canonicalName"u8))
                        {
                            canonicalName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("domainValidationMethod"u8))
                        {
                            domainValidationMethod = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new AppCertificatePatch(id, name, type, systemData.Value, password.Value, friendlyName.Value, subjectName.Value, Optional.ToList(hostNames), pfxBlob.Value, siteName.Value, selfLink.Value, issuer.Value, Optional.ToNullable(issueDate), Optional.ToNullable(expirationDate), thumbprintString.Value, Optional.ToNullable(valid), cerBlob.Value, publicKeyHash.Value, hostingEnvironmentProfile.Value, keyVaultId.Value, keyVaultSecretName.Value, Optional.ToNullable(keyVaultSecretStatus), serverFarmId.Value, canonicalName.Value, domainValidationMethod.Value, kind.Value);
        }
    }
}
