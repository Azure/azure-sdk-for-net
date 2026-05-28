// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Generator.Model;

namespace Azure.Provisioning.Generator.Specifications;

public class StorageSpecification() :
    Specification("Storage", typeof(StorageExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<FileShareResource>("Expand");
        RemoveProperty<ImmutabilityPolicyResource>("IfMatch");
        RemoveProperty<ObjectReplicationPolicyResource>("ObjectReplicationPolicyId");
        RemoveProperty<StoragePrivateEndpointConnectionData>("ResourceType");
        RemoveProperty<StorageTableAccessPolicy>("ExpiresOn");

        // Patch models
        CustomizeModel<TableResource>(m => m.Name = "StorageTable");
        CustomizeProperty<StorageAccountKey>("Value", p => p.IsSecure = true);
        CustomizeProperty<LocalUserKeys>("SharedKey", p => p.IsSecure = true);
        CustomizeProperty<StorageSshPublicKey>("Key", p => p.IsSecure = true);
        CustomizeProperty<StorageTaskAssignmentProperties>("ProvisioningState", p => p.HideLevel = PropertyHideLevel.HideProperty);

        // Naming requirements
        AddNameRequirements<StorageAccountResource>(min: 3, max: 24, lower: true, digits: true);
        CustomizeProperty<BlobServiceResource>("Name", p => { p.GenerateDefaultValue = true; p.HideAccessors = true; p.IsReadOnly = false; }); // must be `default`
        AddNameRequirements<BlobContainerResource>(min: 3, max: 63, lower: true, digits: true, hyphen: true);
        CustomizeProperty<FileServiceResource>("Name", p => { p.GenerateDefaultValue = true; p.HideAccessors = true; p.IsReadOnly = false; }); // must be `default`
        AddNameRequirements<FileShareResource>(min: 3, max: 63, lower: true, digits: true, hyphen: true);
        CustomizeProperty<StorageAccountManagementPolicyResource>("Name", p => { p.GenerateDefaultValue = true; p.HideAccessors = true; p.IsReadOnly = false; }); // must be `default`
        AddNameRequirements<StorageQueueResource>(min: 3, max: 63, lower: true, digits: true, hyphen: true);
        AddNameRequirements<TableResource>(min: 3, max: 63, lower: true, upper: true, digits: true);
        CustomizeProperty<QueueServiceResource>("Name", p => { p.GenerateDefaultValue = true; p.HideAccessors = true; p.IsReadOnly = false; }); // must be `default`
        CustomizeProperty<TableServiceResource>("Name", p => { p.GenerateDefaultValue = true; p.HideAccessors = true; p.IsReadOnly = false; }); // must be `default`

        // Roles
        Roles.Add(new Role("StorageAccountBackupContributor", "e5e2a7ff-d759-4cd2-bb51-3152d37e2eb1", "Lets you perform backup and restore operations using Azure Backup on the storage account."));
        Roles.Add(new Role("StorageAccountContributor", "17d1049b-9a84-46fb-8f53-869881c3d3ab", "Permits management of storage accounts. Provides access to the account key, which can be used to access data via Shared Key authorization."));
        Roles.Add(new Role("StorageAccountKeyOperatorServiceRole", "81a9662b-bebf-436f-a333-f67b29880f12", "Permits listing and regenerating storage account access keys."));
        Roles.Add(new Role("StorageBlobDataContributor", "ba92f5b4-2d11-453d-a403-e96b0029c9fe", "Read, write, and delete Azure Storage containers and blobs. To learn which actions are required for a given data operation, see Permissions for calling data operations."));
        Roles.Add(new Role("StorageBlobDataOwner", "b7e6dc6d-f1e8-4753-8033-0f276bb0955b", "Provides full access to Azure Storage blob containers and data, including assigning POSIX access control. To learn which actions are required for a given data operation, see Permissions for calling data operations."));
        Roles.Add(new Role("StorageBlobDataReader", "2a2b9908-6ea1-4ae2-8e65-a410df84e7d1", "Read and list Azure Storage containers and blobs. To learn which actions are required for a given data operation, see Permissions for calling data operations."));
        Roles.Add(new Role("StorageBlobDelegator", "db58b8e5-c6ad-4a2a-8342-4190687cbf4a", "Get a user delegation key, which can then be used to create a shared access signature for a container or blob that is signed with Azure AD credentials. For more information, see Create a user delegation SAS."));
        Roles.Add(new Role("StorageFileDataPrivilegedContributor", "69566ab7-960f-475b-8e7c-b3118f30c6bd", "Allows for read, write, delete, and modify ACLs on files/directories in Azure file shares by overriding existing ACLs/NTFS permissions. This role has no built-in equivalent on Windows file servers."));
        Roles.Add(new Role("StorageFileDataPrivilegedReader", "b8eda974-7b85-4f76-af95-65846b26df6d", "Allows for read access on files/directories in Azure file shares by overriding existing ACLs/NTFS permissions. This role has no built-in equivalent on Windows file servers."));
        Roles.Add(new Role("StorageFileDataSmbShareContributor", "0c867c2a-1d8c-454a-a3db-ab2ea1bdc8bb", "Allows for read, write, and delete access on files/directories in Azure file shares. This role has no built-in equivalent on Windows file servers."));
        Roles.Add(new Role("StorageFileDataSmbShareElevatedContributor", "a7264617-510b-434b-a828-9731dc254ea7", "Allows for read, write, delete, and modify ACLs on files/directories in Azure file shares. This role is equivalent to a file share ACL of change on Windows file servers."));
        Roles.Add(new Role("StorageFileDataSmbShareReader", "aba4ae5f-2193-4029-9191-0cb91df5e314", "Allows for read access on files/directories in Azure file shares. This role is equivalent to a file share ACL of read on Windows file servers."));
        Roles.Add(new Role("StorageQueueDataContributor", "974c5e8b-45b9-4653-ba55-5f855dd0fb88", "Read, write, and delete Azure Storage queues and queue messages. To learn which actions are required for a given data operation, see Permissions for calling data operations."));
        Roles.Add(new Role("StorageQueueDataMessageProcessor", "8a0f0c08-91a1-4084-bc3d-661d67233fed", "Peek, retrieve, and delete a message from an Azure Storage queue. To learn which actions are required for a given data operation, see Permissions for calling data operations."));
        Roles.Add(new Role("StorageQueueDataMessageSender", "c6a89b2d-59bc-44d0-9896-0f6e12d7b80a", "Add messages to an Azure Storage queue. To learn which actions are required for a given data operation, see Permissions for calling data operations."));
        Roles.Add(new Role("StorageQueueDataReader", "19e7f393-937e-4f77-808e-94535e297925", "Read and list Azure Storage queues and queue messages. To learn which actions are required for a given data operation, see Permissions for calling data operations."));
        Roles.Add(new Role("StorageTableDataContributor", "0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3", "Allows for read, write and delete access to Azure Storage tables and entities"));
        Roles.Add(new Role("StorageTableDataReader", "76199698-9eea-4c19-bc75-cec21354c6b6", "Allows for read access to Azure Storage tables and entities"));
        Roles.Add(new Role("ClassicStorageAccountContributor", "86e8f5dc-a6e9-4c67-9d15-de283e8eac25", "Lets you manage classic storage accounts, but not access to them."));
        Roles.Add(new Role("ClassicStorageAccountKeyOperatorServiceRole", "985d6b00-f706-48f5-a6fe-d0ca12fb668d", "Classic Storage Account Key Operators are allowed to list and regenerate keys on Classic Storage Accounts"));

        // Assign Roles
        CustomizeResource<StorageAccountResource>(r => r.GenerateRoleAssignment = true);
    }
}
