/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{

    using Microsoft.Rest;
    using Microsoft.Azure.Management.Graph.RBAC.Models;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Management.Graph.RBAC;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Rest.Azure;

    /// <summary>
    /// The implementation of ServicePrincipals and its parent interfaces.
    /// </summary>
    public partial class ServicePrincipalsImpl  :
        CreatableWrappers<IServicePrincipal, ServicePrincipalImpl, ServicePrincipalInner>,
        IServicePrincipals
    {
        private IServicePrincipalsOperations innerCollection;
        private GraphRbacManager manager;
        internal ServicePrincipalsImpl (IServicePrincipalsOperations client, GraphRbacManager graphRbacManager)
        {
            this.innerCollection = client;
            this.manager = graphRbacManager;
        }

        public PagedList<IServicePrincipal> List ()
        {
            var pagedList = new PagedList<ServicePrincipalInner>(this.innerCollection.List());
            return WrapList(pagedList);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public ServicePrincipalImpl Define (string appId)
        {
            return WrapModel(appId);
        }

        protected override ServicePrincipalImpl WrapModel (string appId)
        {
            return new ServicePrincipalImpl(new ServicePrincipalInner
            {
                AppId = appId
            }, innerCollection);
        }

        protected override IServicePrincipal WrapModel (ServicePrincipalInner servicePrincipalInner)
        {
            return new ServicePrincipalImpl(servicePrincipalInner, this.innerCollection);
        }

        public ServicePrincipalImpl GetByObjectId (string objectId)
        {
            return new ServicePrincipalImpl(innerCollection.Get(objectId), innerCollection);
        }

        public IServicePrincipal GetByAppId (string appId)
        {
            throw new NotImplementedException();
        }

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

        public async Task<IServicePrincipal> GetByServicePrincipalNameAsync (string spn, CancellationToken cancellationToken = default(CancellationToken))
        {
            IPage<ServicePrincipalInner> spList = await innerCollection.ListAsync(new Rest.Azure.OData.ODataQuery<ServicePrincipalInner>(string.Format("servicePrincipalNames/any(c:c eq '{0}')", spn)), cancellationToken);
            if (spList == null || spList.Count() == 0)
            {
                return null;
            }
            else
            {
                return new ServicePrincipalImpl(spList.FirstOrDefault(), innerCollection);
            }
        }
    }
}