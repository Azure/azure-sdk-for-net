// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class ServicePrincipalImpl 
    {
        /// <summary>
        /// Specifies whether the service principal account is enabled upon creation.
        /// </summary>
        /// <param name="enabled">If set to true, the service principal account is enabled.</param>
        /// <return>The next stage in service principal definition.</return>
        ServicePrincipal.Definition.IWithCreate ServicePrincipal.Definition.IWithAccountEnabled.WithAccountEnabled(bool enabled)
        {
            return this.WithAccountEnabled(enabled) as ServicePrincipal.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets object Id.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.ObjectId
        {
            get
            {
                return this.ObjectId();
            }
        }

        /// <summary>
        /// Gets app id.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.AppId
        {
            get
            {
                return this.AppId();
            }
        }

        /// <summary>
        /// Gets service principal display name.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.DisplayName
        {
            get
            {
                return this.DisplayName();
            }
        }

        /// <summary>
        /// Gets object type.
        /// </summary>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.ObjectType
        {
            get
            {
                return this.ObjectType();
            }
        }

        /// <summary>
        /// Gets the list of names.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.ServicePrincipalNames
        {
            get
            {
                return this.ServicePrincipalNames() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }
    }
}