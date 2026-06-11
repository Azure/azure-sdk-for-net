// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid
{
    internal sealed class NetworkSecurityPerimeterConfigurationCompatOperation<TResource> : ArmOperation<TResource>
    {
        private readonly ArmOperation<NetworkSecurityPerimeterConfigurationData> _operation;
        private readonly Func<NetworkSecurityPerimeterConfigurationData, TResource> _resourceFactory;

        public NetworkSecurityPerimeterConfigurationCompatOperation(ArmOperation<NetworkSecurityPerimeterConfigurationData> operation, Func<NetworkSecurityPerimeterConfigurationData, TResource> resourceFactory)
        {
            _operation = operation;
            _resourceFactory = resourceFactory;
        }

        public override string Id => _operation.Id;

        public override TResource Value => _resourceFactory(_operation.Value);

        public override bool HasCompleted => _operation.HasCompleted;

        public override bool HasValue => _operation.HasValue;

        public override RehydrationToken? GetRehydrationToken() => _operation.GetRehydrationToken();

        public override Response GetRawResponse() => _operation.GetRawResponse();

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        public override Response<TResource> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            Response<NetworkSecurityPerimeterConfigurationData> response = _operation.WaitForCompletion(cancellationToken);
            return Response.FromValue(_resourceFactory(response.Value), response.GetRawResponse());
        }

        public override Response<TResource> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            Response<NetworkSecurityPerimeterConfigurationData> response = _operation.WaitForCompletion(pollingInterval, cancellationToken);
            return Response.FromValue(_resourceFactory(response.Value), response.GetRawResponse());
        }

        public override ValueTask<Response<TResource>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            return WaitForCompletionAsyncCore(_operation.WaitForCompletionAsync(cancellationToken));
        }

        public override ValueTask<Response<TResource>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            return WaitForCompletionAsyncCore(_operation.WaitForCompletionAsync(pollingInterval, cancellationToken));
        }

        private async ValueTask<Response<TResource>> WaitForCompletionAsyncCore(ValueTask<Response<NetworkSecurityPerimeterConfigurationData>> pendingResponse)
        {
            Response<NetworkSecurityPerimeterConfigurationData> response = await pendingResponse.ConfigureAwait(false);
            return Response.FromValue(_resourceFactory(response.Value), response.GetRawResponse());
        }
    }
}
