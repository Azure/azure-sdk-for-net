// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PostgreSql.Models;

namespace Azure.ResourceManager.PostgreSql
{
    public partial class PostgreSqlServerData : IUtf8JsonSerializable
    {
        internal static PostgreSqlServerData DeserializePostgreSqlServerData(JsonElement element)
        {
            Optional<ManagedServiceIdentity> identity = default;
            Optional<PostgreSqlSku> sku = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> administratorLogin = default;
            Optional<PostgreSqlServerVersion> version = default;
            Optional<PostgreSqlSslEnforcementEnum> sslEnforcement = default;
            Optional<PostgreSqlMinimalTlsVersionEnum> minimalTlsVersion = default;
            Optional<string> byokEnforcement = default;
            Optional<PostgreSqlInfrastructureEncryption> infrastructureEncryption = default;
            Optional<PostgreSqlServerState> userVisibleState = default;
            Optional<string> fullyQualifiedDomainName = default;
            Optional<DateTimeOffset> earliestRestoreDate = default;
            Optional<PostgreSqlStorageProfile> storageProfile = default;
            Optional<string> replicationRole = default;
            Optional<ResourceIdentifier> masterServerId = default;
            Optional<int> replicaCapacity = default;
            Optional<PostgreSqlPublicNetworkAccessEnum> publicNetworkAccess = default;
            Optional<IReadOnlyList<PostgreSqlServerPrivateEndpointConnection>> privateEndpointConnections = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("identity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("sku"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sku = PostgreSqlSku.DeserializePostgreSqlSku(property.Value);
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
                if (property.NameEquals("location"))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
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
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
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
                        if (property0.NameEquals("administratorLogin"))
                        {
                            administratorLogin = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("version"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            version = new PostgreSqlServerVersion(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("sslEnforcement"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            sslEnforcement = property0.Value.GetString().ToPostgreSqlSslEnforcementEnum();
                            continue;
                        }
                        if (property0.NameEquals("minimalTlsVersion"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            minimalTlsVersion = new PostgreSqlMinimalTlsVersionEnum(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("byokEnforcement"))
                        {
                            byokEnforcement = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("infrastructureEncryption"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            infrastructureEncryption = new PostgreSqlInfrastructureEncryption(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("userVisibleState"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            userVisibleState = new PostgreSqlServerState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("fullyQualifiedDomainName"))
                        {
                            fullyQualifiedDomainName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("earliestRestoreDate"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            earliestRestoreDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("storageProfile"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            storageProfile = PostgreSqlStorageProfile.DeserializePostgreSqlStorageProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("replicationRole"))
                        {
                            replicationRole = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("masterServerId"))
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
                        if (property0.NameEquals("replicaCapacity"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            replicaCapacity = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("publicNetworkAccess"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            publicNetworkAccess = new PostgreSqlPublicNetworkAccessEnum(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("privateEndpointConnections"))
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
            }
            return new PostgreSqlServerData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, identity, sku.Value, administratorLogin.Value, Optional.ToNullable(version), Optional.ToNullable(sslEnforcement), Optional.ToNullable(minimalTlsVersion), byokEnforcement.Value, Optional.ToNullable(infrastructureEncryption), Optional.ToNullable(userVisibleState), fullyQualifiedDomainName.Value, Optional.ToNullable(earliestRestoreDate), storageProfile.Value, replicationRole.Value, masterServerId.Value, Optional.ToNullable(replicaCapacity), Optional.ToNullable(publicNetworkAccess), Optional.ToList(privateEndpointConnections));
        }
    }
}
