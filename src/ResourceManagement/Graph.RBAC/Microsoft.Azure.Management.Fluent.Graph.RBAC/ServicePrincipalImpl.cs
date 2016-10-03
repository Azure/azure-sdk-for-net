// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{

    using Microsoft.Azure.Management.Graph.RBAC;
    using Microsoft.Azure.Management.Graph.RBAC.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC.ServicePrincipal.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC.ServicePrincipal.Update;
    using System.Threading;
    using System.Linq;
    using System;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    public partial class ServicePrincipalImpl :
        CreatableUpdatable<IServicePrincipal, ServicePrincipalInner, ServicePrincipalImpl, IServicePrincipal, IUpdate>,
        IServicePrincipal,
        IDefinition,
        IUpdate
    {
        private IServicePrincipalsOperations client;
        private ServicePrincipalCreateParametersInner createParameters;

        internal ServicePrincipalImpl(ServicePrincipalInner innerModel,
            IServicePrincipalsOperations client)
            : base(innerModel.AppId, innerModel)
        {
            this.client = client;
            this.createParameters = new ServicePrincipalCreateParametersInner()
            {
                AppId = AppId()
            };
        }

        public string ObjectId()
        {
            return Inner.ObjectId;
        }
        public string ObjectType()
        {
                return Inner.ObjectType;
        }
        public string DisplayName()
        {
                return Inner.DisplayName;
        }
        public string AppId()
        {
                return Inner.AppId;
        }
        public IList<string> ServicePrincipalNames()
        {
                return Inner.ServicePrincipalNames;
        }
        public ServicePrincipalImpl WithAccountEnabled(bool enabled)
        {
            createParameters.AccountEnabled = enabled;
            return this;
        }

        public override IServicePrincipal Refresh()
        {
            var inner = client.List(new Rest.Azure.OData.ODataQuery<ServicePrincipalInner>(string.Format("servicePrincipalNames/any(c:c eq '{0}')", AppId())));
            SetInner(inner.ToList()[0]);
            return this;
        }

        public override async Task<IServicePrincipal> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}