// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class ServiceObjectiveImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the name for the service objective.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.ServiceObjectiveName
        {
            get
            {
                return this.ServiceObjectiveName();
            }
        }

        /// <summary>
        /// Gets whether the service level objective is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.Enabled
        {
            get
            {
                return this.Enabled();
            }
        }

        /// <summary>
        /// Gets whether the service level objective is a system service objective.
        /// </summary>
        bool Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.IsSystem
        {
            get
            {
                return this.IsSystem();
            }
        }

        /// <summary>
        /// Gets the description for the service level objective.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.Description
        {
            get
            {
                return this.Description();
            }
        }

        /// <summary>
        /// Gets whether the service level objective is the default service
        /// objective.
        /// </summary>
        bool Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.IsDefault
        {
            get
            {
                return this.IsDefault();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceObjective.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }
    }
}