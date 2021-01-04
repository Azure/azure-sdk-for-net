// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Administration.Models
{
    /// <summary>
    /// Represents a long-running operation for releasing a phone number.
    /// </summary>
    public class ReleasePhoneNumberOperation : Operation<PhoneNumberRelease>
    {
        private readonly PhoneNumberAdministrationClient _client;
        private readonly CancellationToken _cancellationToken;
        private bool _hasCompleted;
        private PhoneNumberRelease? _value;
        private Response _rawResponse;
        private readonly ReleaseStatus[] _terminateStatuses = new[] {
                ReleaseStatus.Complete,
                ReleaseStatus.Failed,
                ReleaseStatus.Expired
        };

        /// <summary>
        /// Initializes a new <see cref="ReleasePhoneNumberOperation"/> instance.
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="id">The phone number release operation ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public ReleasePhoneNumberOperation(
            PhoneNumberAdministrationClient client,
            string id,
            CancellationToken cancellationToken = default)
        {
            Id = id;
            _value = null;
            _rawResponse = null!;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Initializes a new <see cref="ReleasePhoneNumberOperation"/> instance.
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="id">The phone number release operation ID.</param>
        /// <param name="initialResponse">The original server response on start operation request.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal ReleasePhoneNumberOperation(
            PhoneNumberAdministrationClient client,
            string id,
            Response initialResponse,
            CancellationToken cancellationToken = default)
        {
            Id = id;
            _value = null;
            _rawResponse = initialResponse;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <inheritdocs />
        public override string Id { get; }

        /// <inheritdocs />
        public override PhoneNumberRelease Value
        {
            get
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                if (!HasCompleted)
                {
                    throw new InvalidOperationException("The operation has not completed yet.");
                }
                if (_value?.Status != ReleaseStatus.Complete)
                {
                    throw new RequestFailedException(GetErrorMessage(_value));
                }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

                return OperationHelpers.GetValue(ref _value);
            }
        }

        /// <inheritdocs />
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdocs />
        public override bool HasValue => _value?.Status == ReleaseStatus.Complete;

        /// <inheritdocs />
        public override Response GetRawResponse() => _rawResponse;

        /// <summary>
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
            => UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            => await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check for the latest status of the operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="async" />
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope($"{nameof(ReleasePhoneNumberOperation)}.{nameof(UpdateStatus)}");
            scope.Start();

            try
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                if (cancellationToken == default)
                {
                    cancellationToken = _cancellationToken;
                }

                Response<PhoneNumberRelease> update = async
                    ? await _client.GetReleaseByIdAsync(releaseId: Id, cancellationToken: cancellationToken).ConfigureAwait(false)
                    : _client.GetReleaseById(releaseId: Id, cancellationToken: cancellationToken);

                if (!HasCompleted)
                    _rawResponse = update.GetRawResponse();

                if (IsOperationCompleted(update))
                {
                    _value = update.Value;
                    _hasCompleted = true;
                }

                return GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private bool IsOperationCompleted(Response<PhoneNumberRelease> update)
        {
            return update.Value?.Status != null && _terminateStatuses.Contains(update.Value.Status.Value);
        }

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberRelease>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            => this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberRelease>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        private static string GetErrorMessage(PhoneNumberRelease? release)
        {
            var status = release?.Status;

            if (status == ReleaseStatus.Failed)
                return "Phone number release failed.";
            if (status == ReleaseStatus.Expired)
                return "Phone number release operation is expired.";

            throw new InvalidOperationException($"Unsupported status: {status}");
        }
    }
}
