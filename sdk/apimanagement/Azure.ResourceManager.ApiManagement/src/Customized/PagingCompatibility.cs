// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiGatewayCollection
    {
        /// <summary> Gets all the API gateways in the collection. </summary>
        public virtual AsyncPageable<ApiGatewayResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(default, default, cancellationToken);

        /// <summary> Gets all the API gateways in the collection. </summary>
        public virtual Pageable<ApiGatewayResource> GetAll(CancellationToken cancellationToken)
            => GetAll(default, default, cancellationToken);
    }

    public partial class ApiManagementServiceCollection
    {
        /// <summary> Gets all the API Management services in the collection. </summary>
        public virtual AsyncPageable<ApiManagementServiceResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(default, default, cancellationToken);

        /// <summary> Gets all the API Management services in the collection. </summary>
        public virtual Pageable<ApiManagementServiceResource> GetAll(CancellationToken cancellationToken)
            => GetAll(default, default, cancellationToken);
    }

    public partial class ApiGatewayConfigConnectionCollection
    {
        /// <summary> Gets all the API gateway config connections in the collection. </summary>
        public virtual AsyncPageable<ApiGatewayConfigConnectionResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(default, default, cancellationToken);

        /// <summary> Gets all the API gateway config connections in the collection. </summary>
        public virtual Pageable<ApiGatewayConfigConnectionResource> GetAll(CancellationToken cancellationToken)
            => GetAll(default, default, cancellationToken);
    }

    public partial class ApiManagementWorkspaceLinksCollection
    {
        /// <summary> Gets all the API Management workspace links in the collection. </summary>
        public virtual AsyncPageable<ApiManagementWorkspaceLinksResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(default, default, cancellationToken);

        /// <summary> Gets all the API Management workspace links in the collection. </summary>
        public virtual Pageable<ApiManagementWorkspaceLinksResource> GetAll(CancellationToken cancellationToken)
            => GetAll(default, default, cancellationToken);
    }

    public static partial class ApiManagementExtensions
    {
        /// <summary> Gets all the API gateways in the subscription. </summary>
        [ForwardsClientCalls]
        public static AsyncPageable<ApiGatewayResource> GetApiGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiGatewaysAsync(cancellationToken);
        }

        /// <summary> Gets all the API gateways in the subscription. </summary>
        [ForwardsClientCalls]
        public static Pageable<ApiGatewayResource> GetApiGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiGateways(cancellationToken);
        }

        /// <summary> Gets all the API Management services in the subscription. </summary>
        [ForwardsClientCalls]
        public static AsyncPageable<ApiManagementServiceResource> GetApiManagementServicesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiManagementServicesAsync(cancellationToken);
        }

        /// <summary> Gets all the API Management services in the subscription. </summary>
        [ForwardsClientCalls]
        public static Pageable<ApiManagementServiceResource> GetApiManagementServices(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiManagementServices(cancellationToken);
        }
    }
}

namespace Azure.ResourceManager.ApiManagement.Mocking
{
    public partial class MockableApiManagementSubscriptionResource
    {
        /// <summary> Gets all the API gateways in the subscription. </summary>
        public virtual AsyncPageable<ApiGatewayResource> GetApiGatewaysAsync(CancellationToken cancellationToken)
            => GetApiGatewaysAsync(default, default, cancellationToken);

        /// <summary> Gets all the API gateways in the subscription. </summary>
        public virtual Pageable<ApiGatewayResource> GetApiGateways(CancellationToken cancellationToken)
            => GetApiGateways(default, default, cancellationToken);

        /// <summary> Gets all the API Management services in the subscription. </summary>
        public virtual AsyncPageable<ApiManagementServiceResource> GetApiManagementServicesAsync(CancellationToken cancellationToken)
            => GetApiManagementServicesAsync(default, default, cancellationToken);

        /// <summary> Gets all the API Management services in the subscription. </summary>
        public virtual Pageable<ApiManagementServiceResource> GetApiManagementServices(CancellationToken cancellationToken)
            => GetApiManagementServices(default, default, cancellationToken);
    }
}
