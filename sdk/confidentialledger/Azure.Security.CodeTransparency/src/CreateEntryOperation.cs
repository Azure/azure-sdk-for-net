// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Formats.Cbor;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// Tracks the status of a call to <see cref="CodeTransparencyClient.CreateEntry"/>
    /// or <see cref="CodeTransparencyClient.CreateEntryAsync"/> until completion.
    /// </summary>
    internal class CreateEntryOperation : Operation<BinaryData>, IOperation
    {
        private readonly CodeTransparencyClient _client;
        private readonly OperationInternal _operationInternal;

        /// <summary>
        /// A constructor for mocking.
        /// </summary>
        protected CreateEntryOperation()
        { }

        /// <summary>
        /// Initializes a previously run operation with the given <paramref name="operationId"/> <see cref="CodeTransparencyClient.CreateEntry"/>.
        /// </summary>
        /// <param name="client"> The <see cref="CodeTransparencyClient"/>. </param>
        /// <param name="operationId"> The operation id from a previous call to create the entry. </param>
        public CreateEntryOperation(CodeTransparencyClient client, string operationId)
        {
            _client = client;
            Id = operationId;
            _operationInternal = new(this, _client.ClientDiagnostics, rawResponse: null, nameof(CreateEntryOperation));
        }

        /// <summary>
        /// The operationId of the created entry.
        /// </summary>
        public override string Id { get; }

        /// <inheritdoc />
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override bool HasValue => _operationInternal.HasCompleted && _operationInternal.RawResponse != null;

        /// <inheritdoc />
        public override BinaryData Value => _operationInternal.RawResponse.Content;

        // Part of IOperation which is used in _operationInternal
        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response response = async
                ? await _client.GetOperationAsync(
                        Id,
                        new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow })
                    .ConfigureAwait(false)
                : _client.GetOperation(Id, new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow });

            if (response.Status != (int)HttpStatusCode.OK &&
                response.Status != (int)HttpStatusCode.Created &&
                response.Status != (int)HttpStatusCode.Accepted)
            {
                RequestFailedException ex = new(response);
                return OperationState.Failure(response, new RequestFailedException($"Operation status check failed. OperationId '{Id}'", ex));
            }

            // The content of the response may be empty if we check the OperationStatus immediately after submitting an entry
            if (response.Content == null || response.Content.ToArray().Length == 0)
            {
                RequestFailedException ex = new(response);
                return OperationState.Pending(response);
            }

            string status = CborUtils.GetStringValueFromCborMapByKey(response.Content.ToArray(), "Status");

            if (!Enum.TryParse(status, true, out CodeTransparencyOperationStatus parsedStatus))
            {
                RequestFailedException ex = new(response);
                return OperationState.Failure(response, new RequestFailedException($"Operation status check failed. OperationId '{Id}'", ex));
            }
            else
            {
                switch (parsedStatus)
                {
                    case CodeTransparencyOperationStatus.Succeeded:
                        return OperationState.Success(response);
                    case CodeTransparencyOperationStatus.Failed:
                        return OperationState.Failure(response, new RequestFailedException($"Operation failed. OperationId '{Id}'"));
                    case CodeTransparencyOperationStatus.Running:
                        return OperationState.Pending(response);
                    default:
                        RequestFailedException ex = new(response);
                        return OperationState.Failure(response, new RequestFailedException($"Operation status check failed. Unknown Status: '{status}' OperationId '{Id}'", ex));
                }
             }
        }

        // This method is never invoked since we don't override Operation<T>.GetRehydrationToken.
        RehydrationToken IOperation.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");
    }
}
