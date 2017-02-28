// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Models;
    using System.Collections.Generic;
    using ServicePrincipal.Definition;
    using Resource.Fluent.Core.ResourceActions;
    using System.Threading.Tasks;
    using ServicePrincipal.Update;
    using System.Threading;
    using System.Linq;
    using System;

    /// <summary>
    /// Implementation for ServicePrincipal and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmdyYXBocmJhYy5pbXBsZW1lbnRhdGlvbi5TZXJ2aWNlUHJpbmNpcGFsSW1wbA==
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

        ///GENMHASH:17540EB75C744FB87D329C55BE359E09:CC8D1D4F5D89E231669C5963BF9F8E9C
        public string ObjectId()
        {
            return Inner.ObjectId;
        }

        ///GENMHASH:29024ACA1EA67366DE27F7A1B972E458:75852A31ACA71709FD61BA0195203BFF
        public string ObjectType()
        {
                return Inner.ObjectType;
        }

        ///GENMHASH:19FB5490B29F08AC39628CD5F893E975:54FC41D8034FD612C7047E2055BC6E48
        public string DisplayName()
        {
                return Inner.DisplayName;
        }

        ///GENMHASH:CF00964037C1AADDCC0C25C134168C6E:DBDA3E40337A88C78112F81653959508
        public string AppId()
        {
                return Inner.AppId;
        }

        ///GENMHASH:3190BDAA4917D0479F1E9EBBDAC6590C:9C7DB50BD87DDC349B690C1F34C49A26
        public IList<string> ServicePrincipalNames()
        {
                return Inner.ServicePrincipalNames;
        }

        ///GENMHASH:8B8E171AB3970DFD7516F84B8C19861C:4549C714DB7AE421B3ED125CD30CFEF9
        public ServicePrincipalImpl WithAccountEnabled(bool enabled)
        {
            createParameters.AccountEnabled = enabled;
            return this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:6FBD633E7AC3512A3078AD9811DEC068
        public override IServicePrincipal Refresh()
        {
            var inner = client.List(new Rest.Azure.OData.ODataQuery<ServicePrincipalInner>(string.Format("servicePrincipalNames/any(c:c eq '{0}')", AppId())));
            SetInner(inner.ToList()[0]);
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:E9A4DA014B21051979442ACE026C7D1F
        public override async Task<IServicePrincipal> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
