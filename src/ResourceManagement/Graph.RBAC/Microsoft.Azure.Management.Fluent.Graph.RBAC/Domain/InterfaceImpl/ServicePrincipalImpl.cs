/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{

    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Models;
    using System.Threading;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC.ServicePrincipal.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC.ServicePrincipal.Update;
    public partial class ServicePrincipalImpl 
    {
        /// <summary>
        /// Specifies whether the service principal account is enabled upon creation.
        /// </summary>
        /// <param name="enabled">enabled if set to true, the service principal account is enabled.</param>
        /// <returns>the next stage in service principal definition</returns>
        Microsoft.Azure.Management.Fluent.Graph.RBAC.ServicePrincipal.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Graph.RBAC.ServicePrincipal.Definition.IWithAccountEnabled.WithAccountEnabled (bool enabled) {
            return this.WithAccountEnabled( enabled) as Microsoft.Azure.Management.Fluent.Graph.RBAC.ServicePrincipal.Definition.IWithCreate;
        }

        /// <returns>object type.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IServicePrincipal.ObjectType
        {
            get
            {
                return this.ObjectType as string;
            }
        }
        /// <returns>object Id.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IServicePrincipal.ObjectId
        {
            get
            {
                return this.ObjectId as string;
            }
        }
        /// <returns>service principal display name.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IServicePrincipal.DisplayName
        {
            get
            {
                return this.DisplayName as string;
            }
        }
        /// <returns>app id.</returns>
        string Microsoft.Azure.Management.Fluent.Graph.RBAC.IServicePrincipal.AppId
        {
            get
            {
                return this.AppId as string;
            }
        }
        /// <returns>the list of names.</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Fluent.Graph.RBAC.IServicePrincipal.ServicePrincipalNames
        {
            get
            {
                return this.ServicePrincipalNames as System.Collections.Generic.IList<string>;
            }
        }
    }
}