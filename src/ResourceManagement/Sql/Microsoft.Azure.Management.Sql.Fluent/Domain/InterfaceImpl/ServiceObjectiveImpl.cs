// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    internal partial class ServiceObjectiveImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.IServiceObjective Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Sql.Fluent.IServiceObjective;
        }

        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>
        /// Whether the service level objective is the default service
        /// objective.
        /// </return>
        bool Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.IsDefault
        {
            get
            {
                return this.IsDefault();
            }
        }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.SqlServerName
        {
            get
            {
                return this.SqlServerName() as string;
            }
        }

        /// <return>Whether the service level objective is enabled.</return>
        bool Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.Enabled
        {
            get
            {
                return this.Enabled();
            }
        }

        /// <return>Whether the service level objective is a system service objective.</return>
        bool Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.IsSystem
        {
            get
            {
                return this.IsSystem();
            }
        }

        /// <return>The description for the service level objective.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.Description
        {
            get
            {
                return this.Description() as string;
            }
        }

        /// <return>The name for the service objective.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.ServiceObjectiveName
        {
            get
            {
                return this.ServiceObjectiveName() as string;
            }
        }

        /// <return>The name of the resource group.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName() as string;
            }
        }

        /// <return>The resource ID string.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id() as string;
            }
        }
    }
}