// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using System;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Sql.Mocking;

namespace Azure.ResourceManager.Sql
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetSqlServerJobStepResource", typeof(Azure.ResourceManager.ArmClient), typeof(Azure.Core.ResourceIdentifier))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetLongTermRetentionBackupResource", typeof(Azure.ResourceManager.ArmClient), typeof(Azure.Core.ResourceIdentifier))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetLongTermRetentionManagedInstanceBackupResource", typeof(Azure.ResourceManager.ArmClient), typeof(Azure.Core.ResourceIdentifier))]
    public static partial class SqlExtensions
    {
        /// <summary> Gets an object representing a <see cref="SqlServerJobStepResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SqlServerJobStepResource"/> object. </returns>
        public static SqlServerJobStepResource GetSqlServerJobStepResource(this ArmClient client, ResourceIdentifier id)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            return GetMockableSqlArmClient(client).GetSqlServerJobStepResource(id);
        }

        /// <summary> Gets an object representing a <see cref="LongTermRetentionBackupResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="LongTermRetentionBackupResource"/> object. </returns>
        public static LongTermRetentionBackupResource GetLongTermRetentionBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            return GetMockableSqlArmClient(client).GetLongTermRetentionBackupResource(id);
        }

        /// <summary> Gets an object representing a <see cref="LongTermRetentionManagedInstanceBackupResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="LongTermRetentionManagedInstanceBackupResource"/> object. </returns>
        public static LongTermRetentionManagedInstanceBackupResource GetLongTermRetentionManagedInstanceBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            return GetMockableSqlArmClient(client).GetLongTermRetentionManagedInstanceBackupResource(id);
        }
    }
}
