// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.DataMigration.Mocking;
using Azure.ResourceManager.DataMigration.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DataMigration
{
    // Backward-compat justification: the GA extension methods exposed legacy names and AzureLocation/Guid-based overloads.
    public static partial class DataMigrationExtensions
    {
        /// <summary>
        /// Gets a collection of DatabaseMigrationSqlDBResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataMigrationResourceGroupResource.GetDatabaseMigrationSqlDBs()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of DatabaseMigrationSqlDBResources and their operations over a DatabaseMigrationSqlDBResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetDatabaseMigrationSqlDBs(this ArmClient client, ResourceIdentifier scope)")]
        public static DatabaseMigrationSqlDBCollection GetDatabaseMigrationSqlDBs(this ResourceGroupResource resourceGroupResource)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlDBs();

        /// <summary>
        /// Retrieve the Database Migration resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DatabaseMigrationsSqlDb_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DatabaseMigrationSqlDBResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataMigrationResourceGroupResource.GetDatabaseMigrationSqlDB(string,string,Guid?,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="sqlDBInstanceName"> The <see cref="string"/> to use. </param>
        /// <param name="targetDBName"> The name of the target database. </param>
        /// <param name="migrationOperationId"> Optional migration operation ID. If this is provided, then details of migration operation for that ID are retrieved. If not provided (default), then details related to most recent or current operation are retrieved. </param>
        /// <param name="expand"> Complete migration details be included in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/>, <paramref name="sqlDBInstanceName"/> or <paramref name="targetDBName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sqlDBInstanceName"/> or <paramref name="targetDBName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetDatabaseMigrationSqlDB(this ArmClient client, ResourceIdentifier scope, string targetDbName, Guid? migrationOperationId = default, string expand = default, CancellationToken cancellationToken = default)")]
        [ForwardsClientCalls]
        public static Response<DatabaseMigrationSqlDBResource> GetDatabaseMigrationSqlDB(this ResourceGroupResource resourceGroupResource, string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlDB(sqlDBInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        /// <summary>
        /// Retrieve the Database Migration resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DatabaseMigrationsSqlDb_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DatabaseMigrationSqlDBResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataMigrationResourceGroupResource.GetDatabaseMigrationSqlDBAsync(string,string,Guid?,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="sqlDBInstanceName"> The <see cref="string"/> to use. </param>
        /// <param name="targetDBName"> The name of the target database. </param>
        /// <param name="migrationOperationId"> Optional migration operation ID. If this is provided, then details of migration operation for that ID are retrieved. If not provided (default), then details related to most recent or current operation are retrieved. </param>
        /// <param name="expand"> Complete migration details be included in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/>, <paramref name="sqlDBInstanceName"/> or <paramref name="targetDBName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sqlDBInstanceName"/> or <paramref name="targetDBName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetDatabaseMigrationSqlDBAsync(this ArmClient client, ResourceIdentifier scope, string targetDbName, Guid? migrationOperationId = default, string expand = default, CancellationToken cancellationToken = default)")]
        [ForwardsClientCalls]
        public static Task<Response<DatabaseMigrationSqlDBResource>> GetDatabaseMigrationSqlDBAsync(this ResourceGroupResource resourceGroupResource, string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlDBAsync(sqlDBInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        /// <summary>
        /// Gets a collection of DatabaseMigrationSqlMIResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataMigrationResourceGroupResource.GetDatabaseMigrationSqlMIs()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of DatabaseMigrationSqlMIResources and their operations over a DatabaseMigrationSqlMIResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetDatabaseMigrationSqlMIs(this ArmClient client, ResourceIdentifier scope)")]
        public static DatabaseMigrationSqlMICollection GetDatabaseMigrationSqlMIs(this ResourceGroupResource resourceGroupResource)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlMIs();

        /// <summary>
        /// Retrieve the specified database migration for a given SQL Managed Instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DatabaseMigrationsSqlMi_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DatabaseMigrationSqlMIResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataMigrationResourceGroupResource.GetDatabaseMigrationSqlMI(string,string,Guid?,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="managedInstanceName"> The <see cref="string"/> to use. </param>
        /// <param name="targetDBName"> The name of the target database. </param>
        /// <param name="migrationOperationId"> Optional migration operation ID. If this is provided, then details of migration operation for that ID are retrieved. If not provided (default), then details related to most recent or current operation are retrieved. </param>
        /// <param name="expand"> Complete migration details be included in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/>, <paramref name="managedInstanceName"/> or <paramref name="targetDBName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="managedInstanceName"/> or <paramref name="targetDBName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetDatabaseMigrationSqlMI(this ArmClient client, ResourceIdentifier scope, string targetDbName, Guid? migrationOperationId = default, string expand = default, CancellationToken cancellationToken = default)")]
        [ForwardsClientCalls]
        public static Response<DatabaseMigrationSqlMIResource> GetDatabaseMigrationSqlMI(this ResourceGroupResource resourceGroupResource, string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlMI(managedInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        /// <summary>
        /// Retrieve the specified database migration for a given SQL Managed Instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DatabaseMigrationsSqlMi_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DatabaseMigrationSqlMIResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataMigrationResourceGroupResource.GetDatabaseMigrationSqlMIAsync(string,string,Guid?,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="managedInstanceName"> The <see cref="string"/> to use. </param>
        /// <param name="targetDBName"> The name of the target database. </param>
        /// <param name="migrationOperationId"> Optional migration operation ID. If this is provided, then details of migration operation for that ID are retrieved. If not provided (default), then details related to most recent or current operation are retrieved. </param>
        /// <param name="expand"> Complete migration details be included in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/>, <paramref name="managedInstanceName"/> or <paramref name="targetDBName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="managedInstanceName"/> or <paramref name="targetDBName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetDatabaseMigrationSqlMIAsync(this ArmClient client, ResourceIdentifier scope, string targetDbName, Guid? migrationOperationId = default, string expand = default, CancellationToken cancellationToken = default)")]
        [ForwardsClientCalls]
        public static Task<Response<DatabaseMigrationSqlMIResource>> GetDatabaseMigrationSqlMIAsync(this ResourceGroupResource resourceGroupResource, string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlMIAsync(managedInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        /// <summary>
        /// Gets a collection of DatabaseMigrationSqlVmResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataMigrationResourceGroupResource.GetDatabaseMigrationSqlVms()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of DatabaseMigrationSqlVmResources and their operations over a DatabaseMigrationSqlVmResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetDatabaseMigrationSqlVms(this ArmClient client, ResourceIdentifier scope)")]
        public static DatabaseMigrationSqlVmCollection GetDatabaseMigrationSqlVms(this ResourceGroupResource resourceGroupResource)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlVms();

        /// <summary>
        /// Retrieve the specified database migration for a given SQL VM.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DatabaseMigrationsSqlVm_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DatabaseMigrationSqlVmResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataMigrationResourceGroupResource.GetDatabaseMigrationSqlVm(string,string,Guid?,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="sqlVirtualMachineName"> The <see cref="string"/> to use. </param>
        /// <param name="targetDBName"> The name of the target database. </param>
        /// <param name="migrationOperationId"> Optional migration operation ID. If this is provided, then details of migration operation for that ID are retrieved. If not provided (default), then details related to most recent or current operation are retrieved. </param>
        /// <param name="expand"> Complete migration details be included in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/>, <paramref name="sqlVirtualMachineName"/> or <paramref name="targetDBName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sqlVirtualMachineName"/> or <paramref name="targetDBName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetDatabaseMigrationSqlVm(this ArmClient client, ResourceIdentifier scope, string targetDbName, Guid? migrationOperationId = default, string expand = default, CancellationToken cancellationToken = default)")]
        [ForwardsClientCalls]
        public static Response<DatabaseMigrationSqlVmResource> GetDatabaseMigrationSqlVm(this ResourceGroupResource resourceGroupResource, string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlVm(sqlVirtualMachineName, targetDBName, migrationOperationId, expand, cancellationToken);

        /// <summary>
        /// Retrieve the specified database migration for a given SQL VM.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DatabaseMigrationsSqlVm_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DatabaseMigrationSqlVmResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableDataMigrationResourceGroupResource.GetDatabaseMigrationSqlVmAsync(string,string,Guid?,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="sqlVirtualMachineName"> The <see cref="string"/> to use. </param>
        /// <param name="targetDBName"> The name of the target database. </param>
        /// <param name="migrationOperationId"> Optional migration operation ID. If this is provided, then details of migration operation for that ID are retrieved. If not provided (default), then details related to most recent or current operation are retrieved. </param>
        /// <param name="expand"> Complete migration details be included in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/>, <paramref name="sqlVirtualMachineName"/> or <paramref name="targetDBName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sqlVirtualMachineName"/> or <paramref name="targetDBName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use GetDatabaseMigrationSqlVmAsync(this ArmClient client, ResourceIdentifier scope, string targetDbName, Guid? migrationOperationId = default, string expand = default, CancellationToken cancellationToken = default)")]
        [ForwardsClientCalls]
        public static Task<Response<DatabaseMigrationSqlVmResource>> GetDatabaseMigrationSqlVmAsync(this ResourceGroupResource resourceGroupResource, string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlVmAsync(sqlVirtualMachineName, targetDBName, migrationOperationId, expand, cancellationToken);
    }
}
