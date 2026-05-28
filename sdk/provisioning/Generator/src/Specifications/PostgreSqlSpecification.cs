// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.PostgreSql;
using Azure.ResourceManager.PostgreSql.FlexibleServers;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Azure.ResourceManager.PostgreSql.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class PostgreSqlSpecification() :
    Specification("PostgreSql", typeof(PostgreSqlExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<PostgreSqlServerSecurityAlertPolicyResource>("SecurityAlertPolicyName");
        RemoveProperty<PostgreSqlFlexibleServerResource>("StorageSizeInGB");

        // Patch properties
        CustomizeProperty<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>("ObjectId", p => { p.IsReadOnly = true; p.IsRequired = false; });
        CustomizeProperty<PostgreSqlServerMetadata>("Sku", p => p.Name = "ServerSku");
        CustomizeSimpleModel<PostgreSqlServerPropertiesForDefaultCreate>(m => { m.DiscriminatorName = "createMode"; m.DiscriminatorValue = "Default"; });
        CustomizeSimpleModel<PostgreSqlServerPropertiesForGeoRestore>(m => { m.DiscriminatorName = "createMode"; m.DiscriminatorValue = "GeoRestore"; });
        CustomizeSimpleModel<PostgreSqlServerPropertiesForReplica>(m => { m.DiscriminatorName = "createMode"; m.DiscriminatorValue = "Replica"; });
        CustomizeSimpleModel<PostgreSqlServerPropertiesForRestore>(m => { m.DiscriminatorName = "createMode"; m.DiscriminatorValue = "PointInTimeRestore"; });

        // Naming requirements
        AddNameRequirements<PostgreSqlServerResource>(min: 3, max: 63, lower: true, digits: true, hyphen: true);
        AddNameRequirements<PostgreSqlDatabaseResource>(min: 1, max: 63, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<PostgreSqlFirewallRuleResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true, underscore: true);
        AddNameRequirements<PostgreSqlVirtualNetworkRuleResource>(min: 1, max: 128, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<PostgreSqlFlexibleServerResource>(min: 3, max: 63, lower: true, digits: true, hyphen: true);
    }
}
