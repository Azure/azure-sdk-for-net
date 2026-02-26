// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TODO: This custom code class should be removed after https://github.com/Azure/azure-sdk-for-net/issues/56502 is resolved.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Sphere.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sphere
{
    [CodeGenSuppress("GetDeploymentsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeployments", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeviceGroupsAsync", typeof(ListSphereDeviceGroupsContent), typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeviceGroups", typeof(ListSphereDeviceGroupsContent), typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeviceInsightsAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeviceInsights", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDevicesAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetDevices", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    public partial class SphereCatalogResource
    {
        /// <summary> Lists deployments for catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereDeploymentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SphereDeploymentResource> GetDeploymentsAsync(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SphereDeploymentData, SphereDeploymentResource>(new CatalogsGetDeploymentsAsyncCollectionResultOfT(
                _catalogsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereDeploymentResource(Client, data));
        }

        /// <summary> Lists deployments for catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereDeploymentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SphereDeploymentResource> GetDeployments(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SphereDeploymentData, SphereDeploymentResource>(new CatalogsGetDeploymentsCollectionResultOfT(
                _catalogsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereDeploymentResource(Client, data));
        }

        /// <summary> List the device groups for the catalog. </summary>
        /// <param name="content"> List device groups for catalog. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <returns> A collection of <see cref="SphereDeviceGroupResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SphereDeviceGroupResource> GetDeviceGroupsAsync(ListSphereDeviceGroupsContent content, string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SphereDeviceGroupData, SphereDeviceGroupResource>(new CatalogsGetDeviceGroupsAsyncCollectionResultOfT(
                _catalogsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                ListSphereDeviceGroupsContent.ToRequestContent(content),
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereDeviceGroupResource(Client, data));
        }

        /// <summary> List the device groups for the catalog. </summary>
        /// <param name="content"> List device groups for catalog. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <returns> A collection of <see cref="SphereDeviceGroupResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SphereDeviceGroupResource> GetDeviceGroups(ListSphereDeviceGroupsContent content, string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SphereDeviceGroupData, SphereDeviceGroupResource>(new CatalogsGetDeviceGroupsCollectionResultOfT(
                _catalogsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                ListSphereDeviceGroupsContent.ToRequestContent(content),
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereDeviceGroupResource(Client, data));
        }

        /// <summary> Lists device insights for catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereDeviceInsight"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SphereDeviceInsight> GetDeviceInsightsAsync(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new CatalogsGetDeviceInsightsAsyncCollectionResultOfT(
                _catalogsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context);
        }

        /// <summary> Lists device insights for catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereDeviceInsight"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SphereDeviceInsight> GetDeviceInsights(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new CatalogsGetDeviceInsightsCollectionResultOfT(
                _catalogsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context);
        }

        /// <summary> Lists devices for catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereDeviceResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SphereDeviceResource> GetDevicesAsync(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SphereDeviceData, SphereDeviceResource>(new CatalogsGetDevicesAsyncCollectionResultOfT(
                _catalogsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereDeviceResource(Client, data));
        }

        /// <summary> Lists devices for catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereDeviceResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SphereDeviceResource> GetDevices(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SphereDeviceData, SphereDeviceResource>(new CatalogsGetDevicesCollectionResultOfT(
                _catalogsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereDeviceResource(Client, data));
        }
    }
}
