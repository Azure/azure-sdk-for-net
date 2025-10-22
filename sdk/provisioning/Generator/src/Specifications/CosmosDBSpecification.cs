// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.CosmosDB;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class CosmosDBSpecification() :
    Specification("CosmosDB", typeof(CosmosDBExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<CosmosDBSqlDatabaseResource>("ResourceDatabaseName");
        RemoveProperty<CosmosDBSqlRoleAssignmentResource>("RoleAssignmentId");
        RemoveProperty<CosmosDBSqlRoleDefinitionResource>("RoleDefinitionId");
        RemoveProperty<CosmosDBTableResource>("ResourceTableName");
        RemoveProperty<GremlinDatabaseResource>("ResourceDatabaseName");
        RemoveProperty<MongoDBDatabaseResource>("ResourceDatabaseName");
        RemoveProperty<MongoDBRoleDefinitionResource>("MongoRoleDefinitionId");
        RemoveProperty<MongoDBRoleDefinitionResource>("RoleDefinitionType");
        RemoveProperty<MongoDBUserDefinitionResource>("MongoUserDefinitionId");
        RemoveProperty<CosmosDBPrivateEndpointConnectionData>("ResourceType");

        // Patch models
        CustomizeSimpleModel<AzureBlobDataTransferDataSourceSink>(m => { m.DiscriminatorName = "component"; m.DiscriminatorValue = "AzureBlobStorage"; });
        CustomizeSimpleModel<CosmosCassandraDataTransferDataSourceSink>(m => { m.DiscriminatorName = "component"; m.DiscriminatorValue = "CosmosDBCassandra"; });
        CustomizeSimpleModel<CosmosMongoDataTransferDataSourceSink>(m => { m.DiscriminatorName = "component"; m.DiscriminatorValue = "CosmosDBMongo"; });
        CustomizeSimpleModel<CosmosSqlDataTransferDataSourceSink>(m => { m.DiscriminatorName = "component"; m.DiscriminatorValue = "CosmosDBSql"; });
        CustomizeProperty<CosmosDBAccountKeyList>("PrimaryMasterKey", p => p.IsSecure = true);
        CustomizeProperty<CosmosDBAccountKeyList>("SecondaryMasterKey", p => p.IsSecure = true);
        CustomizeProperty<CosmosDBAccountKeyList>("PrimaryReadonlyMasterKey", p => p.IsSecure = true);
        CustomizeProperty<CosmosDBAccountKeyList>("SecondaryReadonlyMasterKey", p => p.IsSecure = true);
        CustomizeProperty<CosmosDBServiceResource>("Properties", p => p.Name = "CreateOrUpdateProperties");
        CustomizeProperty<DataTransferJobProperties>("Error", p => p.Name = "ErrorResult");
        CustomizeProperty<DataTransferJobGetResultResource>("Error", p => p.Name = "ErrorResult");
        CustomizeEnum<CosmosDBAccountCreateMode>(e => e.Values.Add(new EnumValue(e, "PointInTimeRestore", "PointInTimeRestore") { Hidden = true }));

        // Naming requirements
        AddNameRequirements<CosmosDBAccountResource>(min: 3, max: 44, lower: true, digits: true, hyphen: true);

        // Roles
        Roles.Add(new Role("CosmosDBAccountReaderRole", "fbdf93bf-df7d-467e-a4d2-9458aa1360c8", "Can read Azure Cosmos DB account data. See DocumentDB Account Contributor for managing Azure Cosmos DB accounts."));
        Roles.Add(new Role("CosmosDBOperator", "230815da-be43-4aae-9cb4-875f7bd000aa", "Lets you manage Azure Cosmos DB accounts, but not access data in them. Prevents access to account keys and connection strings."));
        Roles.Add(new Role("CosmosBackupOperator", "db7b14f2-5adf-42da-9f96-f2ee17bab5cb", "Can submit restore request for a Cosmos DB database or a container for an account"));
        Roles.Add(new Role("CosmosRestoreOperator", "5432c526-bc82-444a-b7ba-57c5b0b5b34f", "Can perform restore action for Cosmos DB database account with continuous backup mode"));
        Roles.Add(new Role("DocumentDBAccountContributor", "5bd9cd88-fe45-4216-938b-f97437e15450", "Can manage Azure Cosmos DB accounts. Azure Cosmos DB is formerly known as DocumentDB."));

        // Assign Roles
        CustomizeResource<CosmosDBAccountResource>(r => r.GenerateRoleAssignment = true);
    }
}
