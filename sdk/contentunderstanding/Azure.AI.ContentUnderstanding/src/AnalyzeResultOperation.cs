// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Wrapper for <see cref="Operation{AnalyzeResult}"/> that exposes the <see cref="OperationId"/> property.
    /// </summary>
    public class AnalyzeResultOperation : Operation<AnalyzeResult>
    {
        // Operation-Location header pattern:
        // https://<endpoint>/analyzerResults/{operationId}?api-version=<version>
        private static readonly Regex s_operationLocationRegex = new(@"[^/]+/([^?/]+)(?:\?|$)", RegexOptions.Compiled);

        private readonly Operation<AnalyzeResult> _innerOperation;
        private readonly string? _operationId;

        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzeResultOperation"/> for mocking.
        /// </summary>
        protected AnalyzeResultOperation()
        {
            _innerOperation = null!;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzeResultOperation"/>.
        /// </summary>
        /// <param name="innerOperation">The inner operation to wrap.</param>
        public AnalyzeResultOperation(Operation<AnalyzeResult> innerOperation)
        {
            _innerOperation = innerOperation ?? throw new ArgumentNullException(nameof(innerOperation));
            _operationId = ExtractOperationId(innerOperation);
        }

        /// <summary>
        /// Gets the operation ID from the Operation-Location header of the operation response.
        /// Returns null if the operation ID is not available.
        /// </summary>
        public string? OperationId => _operationId;

        /// <inheritdoc/>
        public override string Id => _operationId ?? throw new InvalidOperationException("The operation ID was not present in the service response.");

        /// <inheritdoc/>
        public override AnalyzeResult Value => _innerOperation.Value;

        /// <inheritdoc/>
        public override bool HasValue => _innerOperation.HasValue;

        /// <inheritdoc/>
        public override bool HasCompleted => _innerOperation.HasCompleted;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _innerOperation.GetRawResponse();

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
            => _innerOperation.UpdateStatus(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            => _innerOperation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc/>
        public override Response<AnalyzeResult> WaitForCompletion(CancellationToken cancellationToken = default)
            => _innerOperation.WaitForCompletion(cancellationToken);

        /// <inheritdoc/>
        public override Response<AnalyzeResult> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
            => _innerOperation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<AnalyzeResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            => _innerOperation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<AnalyzeResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
            => _innerOperation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        private static string? ExtractOperationId(Operation<AnalyzeResult> operation)
        {
            var rawResponse = operation.GetRawResponse();
            if (rawResponse.Headers.TryGetValue("Operation-Location", out var operationLocation))
            {
                // Extract operation ID from the URL: .../analyzerResults/{operationId}
                var match = s_operationLocationRegex.Match(operationLocation);
                if (match.Success && match.Groups.Count > 1)
                {
                    return match.Groups[1].Value.TrimEnd('/');
                }
            }

            return null;
        }
    }
}
