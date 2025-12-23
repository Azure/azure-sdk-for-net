// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PostgreSql.Models;

namespace Azure.ResourceManager.PostgreSql
{
    public partial class PostgreSqlServerData : IUtf8JsonSerializable, IJsonModel<PostgreSqlServerData>
    {
        internal static PostgreSqlServerData DeserializePostgreSqlServerData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ManagedServiceIdentity identity = default;
            PostgreSqlSku sku = default;
            IDictionary<string, string> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            string administratorLogin = default;
            PostgreSqlServerVersion? version = default;
            PostgreSqlSslEnforcementEnum? sslEnforcement = default;
            PostgreSqlMinimalTlsVersionEnum? minimalTlsVersion = default;
            string byokEnforcement = default;
            PostgreSqlInfrastructureEncryption? infrastructureEncryption = default;
            PostgreSqlServerState? userVisibleState = default;
            string fullyQualifiedDomainName = default;
            DateTimeOffset? earliestRestoreDate = default;
            PostgreSqlStorageProfile storageProfile = default;
            string replicationRole = default;
            ResourceIdentifier masterServerId = default;
            int? replicaCapacity = default;
            PostgreSqlPublicNetworkAccessEnum? publicNetworkAccess = default;
            IReadOnlyList<PostgreSqlServerPrivateEndpointConnection> privateEndpointConnections = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identity = ModelReaderWriter.Read<ManagedServiceIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerPostgreSqlContext.Default);
                    continue;
                }
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sku = PostgreSqlSku.DeserializePostgreSqlSku(property.Value);
                    continue;
                }
                if (property.NameEquals("tags"u8))
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
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
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
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerPostgreSqlContext.Default);
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
                        if (property0.NameEquals("administratorLogin"u8))
                        {
                            administratorLogin = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("version"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            version = new PostgreSqlServerVersion(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("sslEnforcement"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            sslEnforcement = property0.Value.GetString().ToPostgreSqlSslEnforcementEnum();
                            continue;
                        }
                        if (property0.NameEquals("minimalTlsVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            minimalTlsVersion = new PostgreSqlMinimalTlsVersionEnum(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("byokEnforcement"u8))
                        {
                            byokEnforcement = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("infrastructureEncryption"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            infrastructureEncryption = new PostgreSqlInfrastructureEncryption(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("userVisibleState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            userVisibleState = new PostgreSqlServerState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("fullyQualifiedDomainName"u8))
                        {
                            fullyQualifiedDomainName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("earliestRestoreDate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            earliestRestoreDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("storageProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            storageProfile = PostgreSqlStorageProfile.DeserializePostgreSqlStorageProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("replicationRole"u8))
                        {
                            replicationRole = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("masterServerId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            // Customized code start
                            if (string.IsNullOrEmpty(property0.Value.GetString()))
                                continue;
                            // Customized code end
                            masterServerId = new ResourceIdentifier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("replicaCapacity"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            replicaCapacity = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("publicNetworkAccess"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            publicNetworkAccess = new PostgreSqlPublicNetworkAccessEnum(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("privateEndpointConnections"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<PostgreSqlServerPrivateEndpointConnection> array = new List<PostgreSqlServerPrivateEndpointConnection>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PostgreSqlServerPrivateEndpointConnection.DeserializePostgreSqlServerPrivateEndpointConnection(item));
                            }
                            privateEndpointConnections = array;
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new PostgreSqlServerData(
                id,
                name,
                type,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                identity,
                sku,
                administratorLogin,
                version,
                sslEnforcement,
                minimalTlsVersion,
                byokEnforcement,
                infrastructureEncryption,
                userVisibleState,
                fullyQualifiedDomainName,
                earliestRestoreDate,
                storageProfile,
                replicationRole,
                masterServerId,
                replicaCapacity,
                publicNetworkAccess,
                privateEndpointConnections ?? new ChangeTrackingList<PostgreSqlServerPrivateEndpointConnection>(),
                serializedAdditionalRawData);
        }
    }
}
