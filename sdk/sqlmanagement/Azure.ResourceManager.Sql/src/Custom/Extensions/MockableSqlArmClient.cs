// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Sql.Mocking
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetSqlServerJobStepResource", typeof(ResourceIdentifier))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetLongTermRetentionBackupResource", typeof(ResourceIdentifier))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetLongTermRetentionManagedInstanceBackupResource", typeof(ResourceIdentifier))]
    public partial class MockableSqlArmClient
    {
        /// <summary> Gets an object representing a <see cref="SqlServerJobStepResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SqlServerJobStepResource"/> object. </returns>
        public virtual SqlServerJobStepResource GetSqlServerJobStepResource(ResourceIdentifier id)
        {
            SqlServerJobStepResource.ValidateResourceId(id);
            return new SqlServerJobStepResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="LongTermRetentionBackupResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="LongTermRetentionBackupResource"/> object. </returns>
        public virtual LongTermRetentionBackupResource GetLongTermRetentionBackupResource(ResourceIdentifier id)
        {
            LongTermRetentionBackupResource.ValidateResourceId(id);
            return new LongTermRetentionBackupResource(Client, id);
        }

        /// <summary> Gets an object representing a <see cref="LongTermRetentionManagedInstanceBackupResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="LongTermRetentionManagedInstanceBackupResource"/> object. </returns>
        public virtual LongTermRetentionManagedInstanceBackupResource GetLongTermRetentionManagedInstanceBackupResource(ResourceIdentifier id)
        {
            LongTermRetentionManagedInstanceBackupResource.ValidateResourceId(id);
            return new LongTermRetentionManagedInstanceBackupResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DistributedAvailabilityGroupResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DistributedAvailabilityGroupResource.CreateResourceIdentifier" /> to create a <see cref="DistributedAvailabilityGroupResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DistributedAvailabilityGroupResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DistributedAvailabilityGroupResource GetDistributedAvailabilityGroupResource(ResourceIdentifier id)
        {
            DistributedAvailabilityGroupResource.ValidateResourceId(id);
            return new DistributedAvailabilityGroupResource(Client, id);
        }
    }
}
