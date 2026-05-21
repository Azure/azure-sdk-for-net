// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.DataFactory
{
    // Internal LRO bridge used by the DataFactoryManagedIdentityCredential dual-view customization
    // (see DataFactoryManagedIdentityCredentialResource for full rationale). The MPG generator only
    // emits ArmOperation<DataFactoryServiceCredentialResource> for the spec-defined Credentials
    // CreateOrUpdate LRO. This wrapper re-types it as ArmOperation<DataFactoryManagedIdentityCredentialResource>
    // by lifting the inner operation's Value through DataFactoryManagedIdentityCredentialData so back-compat
    // consumers calling CreateOrUpdate/Update on the specialized resource keep getting the specialized type.
    internal sealed class DataFactoryManagedIdentityCredentialArmOperationWrapper : ArmOperation<DataFactoryManagedIdentityCredentialResource>
    {
        private readonly ArmClient _client;
        private readonly ArmOperation<DataFactoryServiceCredentialResource> _innerOperation;

        public DataFactoryManagedIdentityCredentialArmOperationWrapper(ArmClient client, ArmOperation<DataFactoryServiceCredentialResource> innerOperation)
        {
            _client = client;
            _innerOperation = innerOperation;
        }

        public override DataFactoryManagedIdentityCredentialResource Value =>
            new DataFactoryManagedIdentityCredentialResource(_client, new DataFactoryManagedIdentityCredentialData(_innerOperation.Value.Data));

        public override bool HasValue => _innerOperation.HasValue;
        public override string Id => _innerOperation.Id;
        public override bool HasCompleted => _innerOperation.HasCompleted;

        public override Response GetRawResponse() => _innerOperation.GetRawResponse();

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _innerOperation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _innerOperation.UpdateStatusAsync(cancellationToken);

        public override Response<DataFactoryManagedIdentityCredentialResource> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            var response = _innerOperation.WaitForCompletion(cancellationToken);
            return Response.FromValue(Value, response.GetRawResponse());
        }

        public override Response<DataFactoryManagedIdentityCredentialResource> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            var response = _innerOperation.WaitForCompletion(pollingInterval, cancellationToken);
            return Response.FromValue(Value, response.GetRawResponse());
        }

        public override async ValueTask<Response<DataFactoryManagedIdentityCredentialResource>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            var response = await _innerOperation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(Value, response.GetRawResponse());
        }

        public override async ValueTask<Response<DataFactoryManagedIdentityCredentialResource>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            var response = await _innerOperation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(Value, response.GetRawResponse());
        }
    }
}
