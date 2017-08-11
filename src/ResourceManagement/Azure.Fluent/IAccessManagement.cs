// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Fluent
{
    /// <summary>
    /// Exposes methods related to managing access permissions in Azure.
    /// </summary>
    public interface IAccessManagement : IBeta
    {
        /// <summary>
        /// Entry point to Azure Active Directory user management. 
        /// </summary>
        IActiveDirectoryUsers ActiveDirectoryUsers
        {
            get;
        }

        /// <summary>
        /// Entry point to Azure Active Directory group management.
        /// </summary>
        IActiveDirectoryGroups ActiveDirectoryGroups
        {
            get;
        }

        /// <summary>
        /// Entry point to Azure Active Directory service principal management.
        /// </summary>
        IServicePrincipals ServicePrincipals
        {
            get;
        }

        /// <summary>
        /// Entry point to Azure Active Directory application management.
        /// </summary>
        IActiveDirectoryApplications ActiveDirectoryApplications
        {
            get;
        }

        /// <summary>
        /// Entry point to Azure Active Directory role definition management.
        /// </summary>
        IRoleDefinitions RoleDefinitions
        {
            get;
        }

        /// <summary>
        /// Entry point to Azure Active Directory role assignemnt management.
        /// </summary>
        IRoleAssignments RoleAssignments
        {
            get;
        }
    }
}
