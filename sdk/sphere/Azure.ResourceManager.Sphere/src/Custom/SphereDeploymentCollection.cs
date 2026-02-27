// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TODO: This custom code class should be removed after https://github.com/Azure/azure-sdk-for-net/issues/56502 is resolved.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sphere
{
    [CodeGenSuppress("GetAllAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    public partial class SphereDeploymentCollection
    {
        /// <summary> List Deployment resources by DeviceGroup. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereDeploymentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SphereDeploymentResource> GetAllAsync(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SphereDeploymentData, SphereDeploymentResource>(new DeploymentsGetByDeviceGroupAsyncCollectionResultOfT(
                _deploymentsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Parent.Parent.Name,
                Id.Parent.Name,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereDeploymentResource(Client, data));
        }

        /// <summary> List Deployment resources by DeviceGroup. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereDeploymentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SphereDeploymentResource> GetAll(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SphereDeploymentData, SphereDeploymentResource>(new DeploymentsGetByDeviceGroupCollectionResultOfT(
                _deploymentsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Parent.Parent.Name,
                Id.Parent.Name,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereDeploymentResource(Client, data));
        }
    }
}
