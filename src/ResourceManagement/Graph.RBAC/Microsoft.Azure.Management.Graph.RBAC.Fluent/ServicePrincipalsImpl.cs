// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation of ServicePrincipals and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmdyYXBocmJhYy5pbXBsZW1lbnRhdGlvbi5TZXJ2aWNlUHJpbmNpcGFsc0ltcGw=
    internal partial class ServicePrincipalsImpl  :
        ReadableWrappers<IServicePrincipal, ServicePrincipalImpl, ServicePrincipalInner>,
        IServicePrincipals
    {
        private IServicePrincipalsOperations innerCollection;
        private IGraphRbacManager manager;

        public IGraphRbacManager Manager
        {
            get
            {
                return manager;
            }
        }

        public IServicePrincipalsOperations Inner
        {
            get
            {
                return innerCollection;
            }
        }

        ///GENMHASH:A268FD9043A10BBA863D754221CF201B:B5C5E95A3298DE50C35002A7B21387E7
        internal ServicePrincipalsImpl (IServicePrincipalsOperations client, IGraphRbacManager graphRbacManager)
        {
            this.innerCollection = client;
            this.manager = graphRbacManager;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        public IEnumerable<IServicePrincipal> List()
        {
            return WrapList(this.innerCollection.List());
        }

        ///GENMHASH:B6D698CC3012EA097E8D0E54375F2F9C:DECE5DD844886B2B30C5F0DDB9EAB09E
        protected override IServicePrincipal WrapModel (ServicePrincipalInner servicePrincipalInner)
        {
            return new ServicePrincipalImpl(servicePrincipalInner, this.innerCollection);
        }

        ///GENMHASH:0DE1C4F9167E6FED0CDC9D2B979CBBBF:858D059E37288A2B0A50BE70FD79972D
        public ServicePrincipalImpl GetByObjectId (string objectId)
        {
            return new ServicePrincipalImpl(innerCollection.Get(objectId), innerCollection);
        }

        ///GENMHASH:512256D5280EFD9A3AA9FDCF9496C049:9790D012FA64E47343F12DB13F0AA212
        public IServicePrincipal GetByAppId (string appId)
        {
            throw new NotImplementedException();
        }

        ///GENMHASH:BE4BCDD3BCE89FEFD9E95BD27432EDD1:427A94ECBA6D5EDB289FD55E027B6032
        public IServicePrincipal GetByServicePrincipalName (string spn)
        {
            IPage<ServicePrincipalInner> spList = innerCollection.List(new Rest.Azure.OData.ODataQuery<ServicePrincipalInner>(string.Format("servicePrincipalNames/any(c:c eq '{0}')", spn)));
            if (spList == null || spList.Count() == 0)
            {
                return null;
            }
            else
            {
                return new ServicePrincipalImpl(spList.FirstOrDefault(), innerCollection);
            }
        }

        ///GENMHASH:D5CC1AE1ACFF2AFCB45457F1FE786CA6:27DDEDD37FD80C9C08415FDFC32A607C
        public async Task<IServicePrincipal> GetByServicePrincipalNameAsync (string spn, CancellationToken cancellationToken = default(CancellationToken))
        {
            IPage<ServicePrincipalInner> spList = await innerCollection.ListAsync(
                new Rest.Azure.OData.ODataQuery<ServicePrincipalInner>(string.Format("servicePrincipalNames/any(c:c eq '{0}')", spn)), 
                cancellationToken);
            if (spList == null || spList.Count() == 0)
            {
                return null;
            }
            else
            {
                return new ServicePrincipalImpl(spList.FirstOrDefault(), innerCollection);
            }
        }

        public async Task<IPagedCollection<IServicePrincipal>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IServicePrincipal, ServicePrincipalInner>.LoadPage(
                async (cancellation) => await innerCollection.ListAsync(cancellationToken: cancellation),
                innerCollection.ListNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}
