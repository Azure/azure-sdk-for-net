// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerKeyType", "SystemAssigned", 0)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerKeyType", "SystemManaged", 1)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerKeyType", "AzureKeyVault", 2)]

[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerReplicationRole", "Secondary", 0)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerReplicationRole", "WalReplica", 1)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerReplicationRole", "SyncReplica", 2)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerReplicationRole", "GeoSyncReplica", 3)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerReplicationRole", "None", 4)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerReplicationRole", "Primary", 5)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerReplicationRole", "AsyncReplica", 6)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerReplicationRole", "GeoAsyncReplica", 7)]

[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerIdentityType", "SystemAssigned", 0)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerIdentityType", "None", 1)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerIdentityType", "UserAssigned", 2)]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerIdentityType", "SystemAssignedUserAssigned", 3, WireName = "SystemAssigned,UserAssigned")]

[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerVersion", "Ver15", 0, WireName = "15")]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerVersion", "Ver14", 1, WireName = "14")]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerVersion", "Ver13", 2, WireName = "13")]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerVersion", "Ver12", 3, WireName = "12")]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerVersion", "Ver11", 4, WireName = "11")]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerVersion", "Sixteen", 5, WireName = "16")]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerVersion", "Eighteen", 6, WireName = "18")]
[assembly: CodeGenEnumValue("PostgreSqlFlexibleServerVersion", "Seventeen", 7, WireName = "17")]
