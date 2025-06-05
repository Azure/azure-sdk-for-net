// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    internal class CreateEntryOperation : Operation<GetOperationResult>, IOperation
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
        public override GetOperationResult Value => Response.FromValue(GetOperationResult.FromResponse(_operationInternal.RawResponse), _operationInternal.RawResponse);

        // Part of IOperation which is used in _operationInternal
        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response response = async
                ? await _client.GetEntryStatusAsync(
                        Id,
                        new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow })
                    .ConfigureAwait(false)
                : _client.GetEntryStatus(Id, new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow });

            if (response.Status != (int)HttpStatusCode.OK)
            {
                RequestFailedException ex = new(response);
                return OperationState.Failure(response, new RequestFailedException($"Operation status check failed. OperationId '{Id}'", ex));
            }
            Response<GetOperationResult> result = Response.FromValue(GetOperationResult.FromResponse(response), response);

            if (result.Value.Status == OperationStatus.Failed)
            {
                return OperationState.Failure(response, new RequestFailedException(result.Value.Error));
            } else if (result.Value.Status == OperationStatus.Succeeded)
            {
                return OperationState.Success(response);
            } else
            {
                return OperationState.Pending(response);
            }
        }
    }
}
