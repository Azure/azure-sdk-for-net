// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class RoleDefinitionImpl  :
        WrapperImpl<Models.RoleDefinitionInner>,
        IRoleDefinition
    {
        private GraphRbacManager manager;
        private string objectId;
        private string userName;
        private string servicePrincipalName;
        private string roleDefinitionId;
        private string roleName;
                public GraphRbacManager Manager()
        {
            //$ return manager;

            return null;
        }

                public ISet<Models.PermissionInner> Permissions()
        {
            //$ if (inner().Properties() == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableSet(Sets.NewHashSet(inner().Properties().Permissions()));

            return null;
        }

                internal  RoleDefinitionImpl(RoleDefinitionInner innerObject, GraphRbacManager manager)
        {
            //$ super(innerObject);
            //$ this.manager = manager;
            //$ }

        }

                public string Name()
        {
            //$ return inner().Name();

            return null;
        }

                public string RoleName()
        {
            //$ if (inner().Properties() == null) {
            //$ return null;
            //$ }
            //$ return inner().Properties().RoleName();

            return null;
        }

                public string Description()
        {
            //$ if (inner().Properties() == null) {
            //$ return null;
            //$ }
            //$ return inner().Properties().Description();

            return null;
        }

                public string Id()
        {
            //$ return inner().Id();

            return null;
        }

                public string Type()
        {
            //$ if (inner().Properties() == null) {
            //$ return null;
            //$ }
            //$ return inner().Properties().Type();

            return null;
        }

                public ISet<string> AssignableScopes()
        {
            //$ if (inner().Properties() == null) {
            //$ return null;
            //$ }
            //$ return Collections.UnmodifiableSet(Sets.NewHashSet(inner().Properties().AssignableScopes()));

            return null;
        }
    }
}