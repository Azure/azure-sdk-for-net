// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RecognizeContentOperation : Operation<IReadOnlyList<FormPage>>
    {
        private Response _response;
        private IReadOnlyList<FormPage> _value;
        private bool _hasCompleted;

        // TODO: use this.
        private CancellationToken _cancellationToken;

        private readonly ServiceClient _serviceClient;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override IReadOnlyList<FormPage> Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<FormPage>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<FormPage>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        internal RecognizeContentOperation(ServiceClient operations, string operationLocation)
        {
            _serviceClient = operations;

            // TODO: Add validation here
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = operationLocation.Split('/').Last();
        }

        /// <summary>
        /// Initializes a new <see cref="RecognizeContentOperation"/> instance.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="cancellationToken"></param>
        public RecognizeContentOperation(string operationId, FormRecognizerClient client, CancellationToken cancellationToken = default)
        {
            Id = operationId;
            _serviceClient = client.ServiceClient;
            _cancellationToken = cancellationToken;
        }


        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_hasCompleted)
            {
                Response<AnalyzeOperationResult_internal> update = async
                    ? await _serviceClient.GetAnalyzeLayoutResultAsync(new Guid(Id), cancellationToken).ConfigureAwait(false)
                    : _serviceClient.GetAnalyzeLayoutResult(new Guid(Id), cancellationToken);

                // TODO: Handle correctly according to returned status code
                // https://github.com/Azure/azure-sdk-for-net/issues/10386
                if (update.Value.Status == OperationStatus.Succeeded || update.Value.Status == OperationStatus.Failed)
                {
                    _hasCompleted = true;

                    // TODO:
                    //_value = ConvertValue(update.Value.AnalyzeResult.PageResults, update.Value.AnalyzeResult.ReadResults);
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();
        }

        private static IReadOnlyList<FormPage> ConvertValue(ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            Debug.Assert(pageResults.Count == readResults.Count);

            List<FormPage> pages = new List<FormPage>();
            List<ReadResult_internal> rawPages = readResults.ToList();

            foreach (var page in pageResults)
            {
                // TODO:
                //pages.Add(new FormPage(page, rawPages[page.Page - 1]));
            }

            return pages;
        }
    }
}
