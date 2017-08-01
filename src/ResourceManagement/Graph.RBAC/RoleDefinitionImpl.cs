// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class RoleDefinitionImpl :
        Wrapper<Models.RoleDefinitionInner>,
        IRoleDefinition
    {
        private GraphRbacManager manager;
        private string objectId;
        private string userName;
        private string servicePrincipalName;
        private string roleDefinitionId;
        private string roleName;

        string IHasId.Id => Inner.Id;

        string IHasName.Name => Inner.Name;

        GraphRbacManager IHasManager<GraphRbacManager>.Manager => manager;

        public GraphRbacManager Manager()
        {
            return manager;
        }

        public ISet<Models.Permission> Permissions()
        {
            if (Inner.Properties == null)
            {
                return null;
            }
            return new HashSet<Models.Permission>(Inner.Properties.Permissions);
        }

        internal RoleDefinitionImpl(RoleDefinitionInner innerObject, GraphRbacManager manager)
            : base(innerObject)
        {
            this.manager = manager;
        }

        public string Name()
        {
            return Inner.Name;
        }

        public string RoleName()
        {
            if (Inner.Properties == null)
            {
                return null;
            }
            return Inner.Properties.RoleName;
        }

        public string Description()
        {
            if (Inner.Properties == null)
            {
                return null;
            }
            return Inner.Properties.Description;
        }

        public string Id()
        {
            return Inner.Id;
        }

        public string Type()
        {
            if (Inner.Properties == null)
            {
                return null;
            }
            return Inner.Properties.Type;
        }

        public ISet<string> AssignableScopes()
        {
            if (Inner.Properties == null)
            {
                return null;
            }
            return new HashSet<string>(Inner.Properties.AssignableScopes);
        }
    }
}