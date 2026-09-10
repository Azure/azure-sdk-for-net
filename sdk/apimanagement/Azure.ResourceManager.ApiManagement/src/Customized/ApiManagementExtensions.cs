// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ApiManagement
{
    // Old SDK had GetApiGateways/GetApiManagementServices(CancellationToken) on SubscriptionResource.
    // New generator adds top/skipToken params. These simplified overloads preserve the old signature.
    // Not spec-fixable: C# convenience overloads.

    public static partial class ApiManagementExtensions
    {
        /// <summary> Gets all the API gateways in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static AsyncPageable<ApiGatewayResource> GetApiGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiGatewaysAsync(cancellationToken);
        }

        /// <summary> Gets all the API gateways in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Pageable<ApiGatewayResource> GetApiGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiGateways(cancellationToken);
        }

        /// <summary> Gets all the API Management services in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static AsyncPageable<ApiManagementServiceResource> GetApiManagementServicesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiManagementServicesAsync(cancellationToken);
        }

        /// <summary> Gets all the API Management services in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Pageable<ApiManagementServiceResource> GetApiManagementServices(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiManagementServices(cancellationToken);
        }
    }
}
