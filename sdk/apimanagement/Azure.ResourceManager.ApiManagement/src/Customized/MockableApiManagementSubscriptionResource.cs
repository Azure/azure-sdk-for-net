// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.ApiManagement.Mocking
{
    public partial class MockableApiManagementSubscriptionResource
    {
        // Old SDK had these with just CancellationToken; new generator adds top/skipToken params.
        // Not spec-fixable: C# convenience overloads.

        /// <summary> Gets all the API gateways in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ApiGatewayResource> GetApiGatewaysAsync(CancellationToken compatibilityCancellationToken)
            => GetApiGatewaysAsync(default, default, compatibilityCancellationToken);

        /// <summary> Gets all the API gateways in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ApiGatewayResource> GetApiGateways(CancellationToken compatibilityCancellationToken)
            => GetApiGateways(default, default, compatibilityCancellationToken);

        /// <summary> Gets all the API Management services in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ApiManagementServiceResource> GetApiManagementServicesAsync(CancellationToken compatibilityCancellationToken)
            => GetApiManagementServicesAsync(default, default, compatibilityCancellationToken);

        /// <summary> Gets all the API Management services in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ApiManagementServiceResource> GetApiManagementServices(CancellationToken compatibilityCancellationToken)
            => GetApiManagementServices(default, default, compatibilityCancellationToken);
    }
}
