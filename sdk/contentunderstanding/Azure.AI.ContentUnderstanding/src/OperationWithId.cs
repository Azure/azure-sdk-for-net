// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Internal wrapper for <see cref="Operation{BinaryData}"/> that extracts and exposes the operation ID
    /// from the Operation-Location header.
    /// </summary>
    /// <remarks>
    /// The operation ID is needed for GetResultFile and DeleteResult APIs. By wrapping the protocol
    /// operation at this level, the Id property is preserved through
    /// <see cref="Azure.Core.ProtocolOperationHelpers.Convert"/> which delegates Id to the inner operation.
    /// </remarks>
    internal class OperationWithId : Operation<BinaryData>
    {
        // CUSTOM CODE NOTE: This class extends Operation<BinaryData> so that it can be returned by the protocol methods
        // for Analyze and AnalyzeBinary. This allows the operation ID to be extracted from the Operation-Location header
        // and exposed via the Id property, which is needed for GetResultFile and DeleteResult APIs.
        private const string OperationIdNotFoundErrorMessage = "The operation ID was not present in the service response.";
        private readonly Operation<BinaryData> _internalOperation;
        private readonly string? _operationId;

        internal OperationWithId(Operation<BinaryData> internalOperation)
        {
            _internalOperation = internalOperation;
            // SDK-EXT: Extract Operation-Location header from the response to be exposed by the public Operation<T>.Id property.
            _operationId = GetOperationId();
        }

        /// <inheritdoc/>
        public override BinaryData Value => _internalOperation.Value;

        /// <inheritdoc/>
        public override bool HasValue => _internalOperation.HasValue;

        /// <summary>
        /// Gets the operation ID from the Operation-Location header of the operation response.
        /// This operation ID can be used with GetResultFile and DeleteResult methods.
        /// </summary>
        // SDK-EXT: Return the Operation-Location ID extracted from Analyze* protocol method calls.
        public override string Id => _operationId ?? throw new InvalidOperationException(OperationIdNotFoundErrorMessage);

        /// <inheritdoc/>
        public override bool HasCompleted => _internalOperation.HasCompleted;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _internalOperation.GetRawResponse();
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _internalOperation.UpdateStatus(cancellationToken);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return await _internalOperation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
        }

        private string? GetOperationId()
        {
            var response = GetRawResponse();

            // The "Operation-Location" header contains the URL with the operation ID as the last path segment.
            // Extract the operation ID by parsing the URI and getting the last segment.
            if (response != null && response.Headers.TryGetValue("Operation-Location", out string? operationLocation))
            {
                if (Uri.TryCreate(operationLocation, UriKind.Absolute, out var uri))
                {
                    var segments = uri.Segments;
                    if (segments.Length > 0)
                    {
                        return segments[segments.Length - 1].TrimEnd('/');
                    }
                }
            }

            return null;
        }
    }
}
