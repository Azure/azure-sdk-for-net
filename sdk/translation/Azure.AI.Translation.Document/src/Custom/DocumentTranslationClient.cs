// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// The client to use for interacting with the Azure Document Translation Service.
    /// </summary>
    public partial class DocumentTranslationClient
    {
        internal readonly DocumentTranslationClient _serviceClient;
        internal readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected DocumentTranslationClient()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationClient"/>
        /// class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.  Endpoint can be found in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to
        /// authenticate requests to the service, such as DefaultAzureCredential.</param>
        public DocumentTranslationClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new DocumentTranslationClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DocumentTranslationClient"/> class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.</param>
        /// <param name="credential">The API key used to access
        /// the service. This will allow you to update the API key
        /// without creating a new client.</param>
        public DocumentTranslationClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new DocumentTranslationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of DocumentTranslation. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        internal DocumentTranslationClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary> Initializes a new instance of DocumentTranslation. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual DocumentTranslationClient GetDocumentTranslationClient(string apiVersion = "2024-05-01")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new DocumentTranslationClient(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, apiVersion);
        }

        /// <summary>
        /// Starts a translation operation which translates the document(s) in your source container
        /// to your <see cref="TranslationTarget"/>(s) in the given language.
        /// <para>For document length limits, maximum batch size, and supported document formats, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview"/>.</para>
        /// </summary>
        /// <param name="inputs">Sets the inputs for the translation operation
        /// including source and target containers for documents to be translated. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success status code. </exception>
        public virtual DocumentTranslationOperation StartTranslation(IEnumerable<DocumentTranslationInput> inputs, CancellationToken cancellationToken = default)
        {
            var request = new StartTranslationDetails(inputs);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            var startTranslationDetails = new StartTranslationDetails(inputs);
            scope.Start();

            try
            {
                var operation = GetDocumentTranslationClient().StartTranslation(WaitUntil.Started, startTranslationDetails, cancellationToken);
                operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string operationLocation);
                return new DocumentTranslationOperation(this, ClientDiagnostics, operationLocation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a translation operation which translates the document(s) in your source container
        /// to your <see cref="TranslationTarget"/>(s) in the given language.
        /// <para>For document length limits, maximum batch size, and supported document formats, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview"/>.</para>
        /// </summary>
        /// <param name="inputs">Sets the inputs for the translation operation
        /// including source and target containers for documents to be translated. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success status code. </exception>
        public virtual async Task<DocumentTranslationOperation> StartTranslationAsync(IEnumerable<DocumentTranslationInput> inputs, CancellationToken cancellationToken = default)
        {
            var request = new StartTranslationDetails(inputs);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            var startTranslationDetails = new StartTranslationDetails(inputs);
            scope.Start();

            try
            {
                var operation = await GetDocumentTranslationClient().StartTranslationAsync(WaitUntil.Started, startTranslationDetails, cancellationToken).ConfigureAwait(false);
                operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string operationLocation);
                return new DocumentTranslationOperation(this, ClientDiagnostics, operationLocation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a translation operation which translates the document(s) in your source container
        /// to your <see cref="TranslationTarget"/>(s) in the given language.
        /// <para>For document length limits, maximum batch size, and supported document formats, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview"/>.</para>
        /// </summary>
        /// <param name="input">Sets the input for the translation operation
        /// including source and target containers for documents to be translated. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success status code. </exception>
        public virtual DocumentTranslationOperation StartTranslation(DocumentTranslationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            var startTranslationDetails = new StartTranslationDetails(new List<DocumentTranslationInput> { input });
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            scope.Start();

            try
            {
                var operation = GetDocumentTranslationClient().StartTranslation(WaitUntil.Started, startTranslationDetails, cancellationToken);
                operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string operationLocation);
                return new DocumentTranslationOperation(this, ClientDiagnostics, operationLocation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a translation operation which translates the document(s) in your source container
        /// to your <see cref="TranslationTarget"/>(s) in the given language.
        /// <para>For document length limits, maximum batch size, and supported document formats, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview"/>.</para>
        /// </summary>
        /// <param name="input">Sets the input for the translation operation
        /// including source and target containers for documents to be translated. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success status code. </exception>
        public virtual async Task<DocumentTranslationOperation> StartTranslationAsync(DocumentTranslationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            var startTranslationDetails = new StartTranslationDetails(new List<DocumentTranslationInput> { input });
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            scope.Start();

            try
            {
                var operation = await GetDocumentTranslationClient().StartTranslationAsync(WaitUntil.Started,startTranslationDetails, cancellationToken).ConfigureAwait(false);
                operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string operationLocation);
                return new DocumentTranslationOperation(this, ClientDiagnostics, operationLocation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the status results for submitted translation operations.
        /// </summary>
        /// <param name="options">Options to use when filtering result.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<TranslationStatusResult> GetTranslationStatuses(GetTranslationStatusesOptions options = default, CancellationToken cancellationToken = default)
        {
            var statusList = options?.Statuses.Count > 0 ? options.Statuses.Select(status => status.ToString()) : null;
            var idList = options?.Ids.Count > 0 ? options.Ids.Select(id => ClientCommon.ValidateModelId(id, "Id Filter")) : null;
            var orderByList = options?.OrderBy.Count > 0 ? options.OrderBy.Select(order => order.ToGenerated()) : null;

            return GetDocumentTranslationClient().GetTranslationsStatus(
                        ids: idList,
                        statuses: statusList,
                        createdDateTimeUtcStart: options?.CreatedAfter,
                        createdDateTimeUtcEnd: options?.CreatedBefore,
                        orderBy: orderByList,
                        cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the status results for submitted translation operations.
        /// </summary>
        /// <param name="options">Options to use when filtering result.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncPageable<TranslationStatusResult> GetTranslationStatusesAsync(GetTranslationStatusesOptions options = default, CancellationToken cancellationToken = default)
        {
            var statusList = options?.Statuses.Count > 0 ? options.Statuses.Select(status => status.ToString()) : null;
            var idList = options?.Ids.Count > 0 ? options.Ids.Select(id => ClientCommon.ValidateModelId(id, "Id Filter")) : null;
            var orderByList = options?.OrderBy.Count > 0 ? options.OrderBy.Select(order => order.ToGenerated()) : null;

            return GetDocumentTranslationClient().GetTranslationsStatusAsync(
                ids: idList,
                statuses: statusList,
                createdDateTimeUtcStart: options?.CreatedAfter,
                createdDateTimeUtcEnd: options?.CreatedBefore,
                orderBy: orderByList,
                cancellationToken: cancellationToken);
        }
    }
}
