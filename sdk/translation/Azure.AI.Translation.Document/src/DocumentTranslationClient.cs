// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator.Customizations;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Translation.Document
{
    [CodeGenSuppress("DocumentTranslationClient", typeof(Uri), typeof(AzureKeyCredential), typeof(DocumentTranslationClientOptions))]
    [CodeGenSuppress("StartTranslation", typeof(WaitUntil), typeof(TranslationBatch), typeof(CancellationToken))]
    [CodeGenSuppress("StartTranslationAsync", typeof(WaitUntil), typeof(TranslationBatch), typeof(CancellationToken))]
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

        /// <summary> Initializes a new instance of DocumentTranslationClient. </summary>
        /// <param name="endpoint"> Supported document Translation endpoint, protocol and hostname, for example: https://{TranslatorResourceName}.cognitiveservices.azure.com/translator. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public DocumentTranslationClient(Uri endpoint, AzureKeyCredential credential, DocumentTranslationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));
            options ??= new DocumentTranslationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
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
            Pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary> Initializes a new instance of DocumentTranslation. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        internal virtual DocumentTranslationClient GetDocumentTranslationClient(string apiVersion = "2024-05-01")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new DocumentTranslationClient(ClientDiagnostics, Pipeline, _keyCredential, _tokenCredential, _endpoint, apiVersion);
        }

        /// <summary>
        /// Use this API to submit a bulk (batch) translation request to the Document Translation service.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> Translation job submission batch request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Operation<TranslationStatusResult> StartTranslation(WaitUntil waitUntil, TranslationBatch body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = cancellationToken.ToRequestContext();
            Operation<BinaryData> operation = StartTranslation(waitUntil, (RequestContent)body, context);
            return ProtocolOperationHelpers.Convert(operation, r => TranslationStatusResult.DeserializeTranslationStatusResult(JsonDocument.Parse(r.Content).RootElement, ModelSerializationExtensions.WireOptions), ClientDiagnostics, "DocumentTranslationClient.StartTranslation");
        }

        /// <summary>
        /// Use this API to submit a bulk (batch) translation request to the Document Translation service.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="body"> Translation job submission batch request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Operation<TranslationStatusResult>> StartTranslationAsync(WaitUntil waitUntil, TranslationBatch body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = cancellationToken.ToRequestContext();
            Operation<BinaryData> operation = await StartTranslationAsync(waitUntil, (RequestContent)body, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(operation, r => TranslationStatusResult.DeserializeTranslationStatusResult(JsonDocument.Parse(r.Content).RootElement, ModelSerializationExtensions.WireOptions), ClientDiagnostics, "DocumentTranslationClient.StartTranslation");
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
            var request = new TranslationBatch(inputs);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            var startTranslationDetails = new TranslationBatch(inputs);
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
            var request = new TranslationBatch(inputs);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            var startTranslationDetails = new TranslationBatch(inputs);
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
            var startTranslationDetails = new TranslationBatch(new List<DocumentTranslationInput> { input });
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
            var startTranslationDetails = new TranslationBatch(new List<DocumentTranslationInput> { input });
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
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
                    translationIds: idList,
                    statuses: statusList,
                    createdDateTimeUtcStart: options?.CreatedAfter,
                    createdDateTimeUtcEnd: options?.CreatedBefore,
                    orderby: orderByList,
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
            translationIds: idList,
            statuses: statusList,
            createdDateTimeUtcStart: options?.CreatedAfter,
            createdDateTimeUtcEnd: options?.CreatedBefore,
            orderby: orderByList,
            cancellationToken: cancellationToken);
        }

        #region supported formats functions nobody wants to see these

        /// <summary>
        /// Get the list of the glossary formats supported by the Document Translation service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SupportedFileFormats> GetSupportedGlossaryFormats(CancellationToken cancellationToken = default)
        {
            return GetSupportedFormats(FileFormatType.Glossary, cancellationToken);
        }

        /// <summary>
        /// Get the list of the glossary formats supported by the Document Translation service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SupportedFileFormats>> GetSupportedGlossaryFormatsAsync(CancellationToken cancellationToken = default)
        {
            return await GetSupportedFormatsAsync(FileFormatType.Glossary, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the list of the document formats supported by the Document Translation service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SupportedFileFormats> GetSupportedDocumentFormats(CancellationToken cancellationToken = default)
        {
            return GetSupportedFormats(FileFormatType.Document, cancellationToken);
        }

        /// <summary>
        /// Get the list of the document formats supported by the Document Translation service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SupportedFileFormats>> GetSupportedDocumentFormatsAsync(CancellationToken cancellationToken = default)
        {
            return await GetSupportedFormatsAsync(FileFormatType.Document, cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
