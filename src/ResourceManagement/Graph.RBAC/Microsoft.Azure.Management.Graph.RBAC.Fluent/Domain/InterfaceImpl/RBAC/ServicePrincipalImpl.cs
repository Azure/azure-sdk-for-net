// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models ;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update;
    public partial class ServicePrincipalImpl 
    {
        /// <summary>
        /// Specifies whether the service principal account is enabled upon creation.
        /// </summary>
        /// <param name="enabled">enabled if set to true, the service principal account is enabled.</param>
        /// <returns>the next stage in service principal definition</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithAccountEnabled.WithAccountEnabled(bool enabled) { 
            return this.WithAccountEnabled( enabled) as Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Definition.IWithCreate;
        }

        /// <returns>object type.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.ObjectType
        {
            get
            { 
            return this.ObjectType() as string;
            }
        }
        /// <returns>object Id.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.ObjectId
        {
            get
            { 
            return this.ObjectId() as string;
            }
        }
        /// <returns>service principal display name.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.DisplayName
        {
            get
            { 
            return this.DisplayName() as string;
            }
        }
        /// <returns>app id.</returns>
        string Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.AppId
        {
            get
            { 
            return this.AppId() as string;
            }
        }
        /// <returns>the list of names.</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal.ServicePrincipalNames
        {
            get
            { 
            return this.ServicePrincipalNames() as System.Collections.Generic.IList<string>;
            }
        }
    }
}