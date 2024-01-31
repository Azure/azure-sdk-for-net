// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// A long-running operation for <see cref="ConfigurationClient.CreateSnapshot(WaitUntil, string, ConfigurationSnapshot, CancellationToken)"/>
    /// or <see cref="ConfigurationClient.CreateSnapshotAsync(WaitUntil, string, ConfigurationSnapshot, CancellationToken)"/>.
    /// </summary>
    public class CreateSnapshotOperation : Operation<ConfigurationSnapshot>
    {
        private readonly ClientDiagnostics _diagnostics;
        private Operation<BinaryData> _operation;
        private readonly string _id;
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Gets the <see cref="ConfigurationSnapshot"/>. This snapshot will have a status of
        /// <see cref="ConfigurationSnapshotStatus.Provisioning"/> until the operation has completed.
        /// </summary>
        public override ConfigurationSnapshot Value => ConfigurationSnapshot.FromResponse(_operation.GetRawResponse());

        /// <inheritdoc/>
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc/>
        public override string Id => _id;

        /// <inheritdoc/>
        public override bool HasCompleted => _operation.HasCompleted;

        internal CreateSnapshotOperation(string snapshotName)
        {
            _id = snapshotName;
        }

        internal CreateSnapshotOperation(string snapshotName, ClientDiagnostics diagnostics, Operation<BinaryData> operation)
            : this(snapshotName)
        {
            _diagnostics = diagnostics;
            _operation = operation;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CreateSnapshotOperation"/> for mocking.
        /// </summary>
        protected CreateSnapshotOperation() { }

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _operation.GetRawResponse();
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override ValueTask<Response<ConfigurationSnapshot>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ConfigurationSnapshot>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_operation.HasCompleted)
            {
                using DiagnosticScope? scope = _diagnostics?.CreateScope($"{nameof(CreateSnapshotOperation)}.{nameof(UpdateStatus)}");
                scope?.Start();

                try
                {
                    Response update;
                    if (async)
                    {
                        update = await _operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        update = _operation.UpdateStatus(cancellationToken);
                    }
                }
                catch (Exception e)
                {
                    scope?.Failed(e);
                    throw;
                }
            }

            return GetRawResponse();
        }
    }
}
