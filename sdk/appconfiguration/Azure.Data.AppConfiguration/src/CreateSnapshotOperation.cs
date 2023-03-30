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
    /// A long-running operation for <see cref="ConfigurationClient.CreateSnapshot(WaitUntil, string, ConfigurationSettingsSnapshot, CancellationToken)"/>
    /// or <see cref="ConfigurationClient.CreateSnapshotAsync(WaitUntil, string, ConfigurationSettingsSnapshot, CancellationToken)"/>.
    /// </summary>
    public class CreateSnapshotOperation : Operation<ConfigurationSettingsSnapshot>
    {
        private ConfigurationSettingsSnapshot _snapshot;
        private Operation<BinaryData> _operation;
        private readonly ClientDiagnostics _diagnostics;
        private Response _rawResponse;
        private readonly ConfigurationClient _client;
        private readonly string _snapshotName;
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Gets the <see cref="ConfigurationSettingsSnapshot"/>. This snapshot will have a status of
        /// <see cref="SnapshotStatus.Provisioning"/> until the operation has completed.
        /// </summary>
        public override ConfigurationSettingsSnapshot Value => OperationHelpers.GetValue(ref _snapshot);

        private bool _hasValue;

        /// <inheritdoc/>
        public override bool HasValue => _hasValue;

        /// <inheritdoc/>
        public override string Id => _operation.Id;

        private bool _hasCompleted;

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        internal CreateSnapshotOperation(string snapshot, ConfigurationClient client)
        {
            _client = client;
            _snapshotName = snapshot;
        }

        internal CreateSnapshotOperation(ConfigurationClient client, string snapshot, ClientDiagnostics diagnostics, Operation<BinaryData> operation)
            : this(snapshot, client)
        {
            _diagnostics = diagnostics;
            _rawResponse = operation.GetRawResponse();
            _operation = operation;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CreateSnapshotOperation"/> for mocking.
        /// </summary>
        protected CreateSnapshotOperation() { }

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _rawResponse;
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => UpdateStatusAsync(false).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => await UpdateStatusAsync(true).ConfigureAwait(false);

        /// <inheritdoc />
        public override ValueTask<Response<ConfigurationSettingsSnapshot>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ConfigurationSettingsSnapshot>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        private async ValueTask<Response> UpdateStatusAsync(bool async)
        {
            // TODO: test
            if (!_hasCompleted)
            {
                using DiagnosticScope? scope = _diagnostics?.CreateScope($"{nameof(CreateSnapshotOperation)}.{nameof(UpdateStatus)}");
                scope?.Start();

                try
                {
                    // Get the latest status
                    Response update = async
                        ? await _client.GetOperationDetailsAsync(_snapshotName).ConfigureAwait(false)
                        : _client.GetOperationDetails(_snapshotName);

                    JsonElement result = JsonDocument.Parse(update.ContentStream).RootElement;
                    var status = result.GetProperty("status");

                    // Check if the operation is no longer running
                    _hasCompleted = IsJobComplete(status.ToString());
                    if (_hasCompleted)
                    {
                        // Only want to set this if the operation has completed.

                        // Get the latest snapshot - TODO is there a way to pull this from the operation details
                        ConfigurationSettingsSnapshot updatedSnapshot = async
                            ? await _client.GetSnapshotAsync(_snapshotName).ConfigureAwait(false)
                            : _client.GetSnapshot(_snapshotName);

                        _snapshot = updatedSnapshot;

                        _hasValue = true;
                    }

                    // Update raw response
                    _rawResponse = update;
                }
                catch (Exception e)
                {
                    scope?.Failed(e);
                    throw;
                }
            }

            return GetRawResponse();
        }

        private static bool IsJobComplete(string status)
        {
            if (status == "Succeeded" || status == "Failed" || status == "Canceled")
            {
                return true;
            }
            return false;
        }
    }
}
