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
    /// Tracks the status of a long-running operation for recognizing layout elements from forms.
    /// </summary>
    public class RecognizeContentOperation : Operation<IReadOnlyList<FormPage>>
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly ServiceClient _serviceClient;

        /// <summary>The last HTTP response received from the server. <c>null</c> until the first response is received.</summary>
        private Response _response;

        /// <summary>The result of the long-running operation. <c>null</c> until result is received on status update.</summary>
        private IReadOnlyList<FormPage> _value;

        /// <summary><c>true</c> if the long-running operation has completed. Otherwise, <c>false</c>.</summary>
        private bool _hasCompleted;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override IReadOnlyList<FormPage> Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeContentOperation"/> class.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public RecognizeContentOperation(string operationId, FormRecognizerClient client)
        {
            // TODO: Add argument validation here.

            Id = operationId;
            _serviceClient = client.ServiceClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeContentOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Form Recognizer Azure Cognitive Service through its REST API.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        internal RecognizeContentOperation(ServiceClient serviceClient, string operationLocation)
        {
            _serviceClient = serviceClient;

            // TODO: Add validation here
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = operationLocation.Split('/').Last();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeContentOperation"/> class.
        /// </summary>
        protected RecognizeContentOperation()
        {
        }

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<FormPage>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<FormPage>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="async">When <c>true</c>, the method will be executed asynchronously; otherwise, it will execute synchronously.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The HTTP response from the service.</returns>
        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_hasCompleted)
            {
                Response<AnalyzeOperationResult_internal> update = async
                    ? await _serviceClient.GetAnalyzeLayoutResultAsync(new Guid(Id), cancellationToken).ConfigureAwait(false)
                    : _serviceClient.GetAnalyzeLayoutResult(new Guid(Id), cancellationToken);

                if (update.Value.Status == OperationStatus.Succeeded || update.Value.Status == OperationStatus.Failed)
                {
                    _hasCompleted = true;

                    _value = ConvertValue(update.Value.AnalyzeResult.PageResults, update.Value.AnalyzeResult.ReadResults);
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();
        }

        private static IReadOnlyList<FormPage> ConvertValue(IReadOnlyList<PageResult_internal> pageResults, IReadOnlyList<ReadResult_internal> readResults)
        {
            Debug.Assert(pageResults.Count == readResults.Count);

            List<FormPage> pages = new List<FormPage>();
            List<ReadResult_internal> rawPages = readResults.ToList();

            for (var pageIndex = 0; pageIndex < pageResults.Count; pageIndex++)
            {
                pages.Add(new FormPage(pageResults[pageIndex], rawPages, pageIndex));
            }

            return pages;
        }
    }
}
