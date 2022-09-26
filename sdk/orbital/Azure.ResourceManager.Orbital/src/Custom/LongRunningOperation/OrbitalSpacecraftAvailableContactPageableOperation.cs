// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Orbital.Models;

namespace Azure.ResourceManager.Orbital
{
    internal sealed class OrbitalSpacecraftAvailableContactPageableOperation : PageableOperation<OrbitalSpacecraftAvailableContact>, IOperation<AsyncPageable<OrbitalSpacecraftAvailableContact>>
    {
        private readonly IOperationSource<AvailableContactsListResult> _operationSource;
        private readonly IOperation _operation;
        private readonly OperationInternal _operationInternal;
        private readonly RequestMethod _requestMethod;
        private readonly SpacecraftsRestOperations _spacecraftsRestClient;
        private Page<OrbitalSpacecraftAvailableContact> _firstPage;

        public override bool HasValue => _operationInternal.HasCompleted && GetOperationStateFromFinalResponse(_requestMethod, _operationInternal.RawResponse).HasSucceeded;

        [EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string Id => throw new NotImplementedException();

        public override bool HasCompleted => _operationInternal.HasCompleted;

        public OrbitalSpacecraftAvailableContactPageableOperation(IOperationSource<AvailableContactsListResult> operationSource, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, SpacecraftsRestOperations spacecraftsRestClient)
        {
            _operationSource = operationSource;
            _operation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);
            _requestMethod = request.Method;
            _spacecraftsRestClient = spacecraftsRestClient;
            _operationInternal = new OperationInternal(clientDiagnostics, _operation, response, "OperationToOrbitalSpacecraftAvailableContactPageableOperation", fallbackStrategy: new ExponentialDelayStrategy());
        }

        async ValueTask<OperationState<AsyncPageable<OrbitalSpacecraftAvailableContact>>> IOperation<AsyncPageable<OrbitalSpacecraftAvailableContact>>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var state = await _operation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
            Response rawResponse = state.RawResponse;
            if (state.HasSucceeded)
            {
                var result = async
                    ? await _operationSource.CreateResultAsync(state.RawResponse, cancellationToken).ConfigureAwait(false)
                    : _operationSource.CreateResult(state.RawResponse, cancellationToken);
                _firstPage = Page.FromValues(result.Value, result.NextLink, rawResponse);

                return OperationState<AsyncPageable<OrbitalSpacecraftAvailableContact>>.Success(rawResponse, CreateOperationValueAsync(CancellationToken.None));
            }

            if (state.HasCompleted)
            {
                return OperationState<AsyncPageable<OrbitalSpacecraftAvailableContact>>.Failure(state.RawResponse, state.OperationFailedException);
            }

            return OperationState<AsyncPageable<OrbitalSpacecraftAvailableContact>>.Pending(state.RawResponse);
        }

        private AsyncPageable<OrbitalSpacecraftAvailableContact> CreateOperationValueAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<OrbitalSpacecraftAvailableContact>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await _spacecraftsRestClient.ListAvailableContactsNextPageAsync(nextLink, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }

            return PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(_firstPage), NextPageFunc);
        }

        /// <summary>
        /// Gets the final result of the long-running operation asynchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public override AsyncPageable<OrbitalSpacecraftAvailableContact> GetValuesAsync(CancellationToken cancellationToken = default)
        {
            if (!_operationInternal.HasCompleted)
                throw new InvalidOperationException("The operation has not completed yet.");

            return CreateOperationValueAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the final result of the long-running operation in synchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public override Pageable<OrbitalSpacecraftAvailableContact> GetValues(CancellationToken cancellationToken = default)
        {
            if (!_operationInternal.HasCompleted)
                throw new InvalidOperationException("The operation has not completed yet.");

            Page<OrbitalSpacecraftAvailableContact> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = _spacecraftsRestClient.ListAvailableContactsNextPage(nextLink, cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }

            return PageableHelpers.CreateEnumerable(_ => _firstPage, NextPageFunc);
        }

        public override Response GetRawResponse()
        {
            return _operationInternal.RawResponse;
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return _operationInternal.UpdateStatusAsync(cancellationToken);
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _operationInternal.UpdateStatus(cancellationToken);
        }

        private static OperationState GetOperationStateFromFinalResponse(RequestMethod requestMethod, Response response)
        {
            switch (response.Status)
            {
                case 200:
                case 201 when requestMethod == RequestMethod.Put:
                case 204 when requestMethod != RequestMethod.Put && requestMethod != RequestMethod.Patch:
                    return OperationState.Success(response);
                default:
                    return OperationState.Failure(response);
            }
        }
    }
}
