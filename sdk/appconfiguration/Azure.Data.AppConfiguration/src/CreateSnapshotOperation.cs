// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// A long-running operation for <see cref="ConfigurationClient.CreateSnapshot(WaitUntil, string, ConfigurationSettingsSnapshot, CancellationToken)"/>
    /// or <see cref="ConfigurationClient.CreateSnapshotAsync(WaitUntil, string, ConfigurationSettingsSnapshot, CancellationToken)"/>.
    /// </summary>
    public class CreateSnapshotOperation : Operation<ConfigurationSettingsSnapshot>, IOperation
    {
        private HttpPipeline _httpPipeline;
        private ConfigurationSettingsSnapshot _snapshot;
        private OperationInternal _operationInternal;
        private Operation<BinaryData> _operation;

        internal CreateSnapshotOperation(HttpPipeline httpPipeline, ClientDiagnostics diagnostics, Operation<BinaryData> operation, Response<ConfigurationSettingsSnapshot> response)
        {
            // TODO:
            // need to update and test once the Snapshot feature is out of dogfood
            _httpPipeline = httpPipeline;
            _snapshot = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
            _operation = operation;

            if (_snapshot.Status == SnapshotStatus.Ready)
            {
                _operationInternal = OperationInternal.Succeeded(operation.GetRawResponse());
            }
            else
            {
                _operationInternal = new(diagnostics, this, operation.GetRawResponse(), nameof(CreateSnapshotOperation));
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CreateSnapshotOperation"/> for mocking.
        /// </summary>
        protected CreateSnapshotOperation() { }

        /// <summary>
        /// Gets the <see cref="ConfigurationSettingsSnapshot"/>. This snapshot will have a status of
        /// <see cref="SnapshotStatus.Provisioning"/> until the operation has completed.
        /// </summary>
        public override ConfigurationSettingsSnapshot Value => _snapshot;

        /// <inheritdoc/>
        public override bool HasValue => true;

        /// <inheritdoc/>
        public override string Id => _operation.Id;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _operationInternal.RawResponse;
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            // TODO:
            // need to test and adjust once the Snapshot feature is out of dogfood
            if (!HasCompleted)
            {
                return _operationInternal.UpdateStatus(cancellationToken);
            }
            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            // TODO:
            // need to test and adjust once the Snapshot feature is out of dogfood
            if (!HasCompleted)
            {
                return await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
            }
            return GetRawResponse();
        }

        ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            // TODO:
            // need to implement and test once the Snapshot feature is out of dogfood
            throw new NotImplementedException();
        }
    }
}
