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
    [CodeGenSuppress("GetTranslationsStatus", typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetTranslationsStatusAsync", typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetTranslationsStatus", typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetTranslationsStatusAsync", typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(RequestContext))]
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
            : this(new AzureKeyCredentialPolicy(credential, AuthorizationHeader), endpoint, options)
        {
        }

        /// <summary> Initializes a new instance of DocumentTranslation. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        internal DocumentTranslationClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            Pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary> Initializes a new instance of DocumentTranslation. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        internal virtual DocumentTranslationClient GetDocumentTranslationClient(string apiVersion = "2024-05-01")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new DocumentTranslationClient(ClientDiagnostics, Pipeline, _endpoint, apiVersion);
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

        /// <summary> Returns a list of batch requests submitted and the status for each request. </summary>
        /// <param name="maxCount"> top indicates the total number of records the user wants to be returned across all pages. </param>
        /// <param name="skip"> skip indicates the number of records to skip from the list of records held by the server based on the sorting method specified. By default, we sort by descending start time. </param>
        /// <param name="maxpagesize"> maxpagesize is the maximum items returned in a page. </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc','CreatedDateTimeUtc desc'). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<TranslationStatusResult> GetTranslationsStatusAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, IEnumerable<Guid> ids = null, IEnumerable<string> statuses = null, DateTimeOffset? createdDateTimeUtcStart = null, DateTimeOffset? createdDateTimeUtcEnd = null, IEnumerable<string> orderBy = null, CancellationToken cancellationToken = default)
        {
            return new DocumentTranslationClientGetTranslationsStatusAsyncCollectionResultOfT(
                this,
                maxCount,
                skip,
                maxpagesize,
                ids,
                statuses,
                createdDateTimeUtcStart,
                createdDateTimeUtcEnd,
                orderBy,
                cancellationToken.ToRequestContext(),
                $"{nameof(DocumentTranslationClient)}.{nameof(GetTranslationStatuses)}");
        }

        /// <summary> Returns a list of batch requests submitted and the status for each request. </summary>
        /// <param name="maxCount"> top indicates the total number of records the user wants to be returned across all pages. </param>
        /// <param name="skip"> skip indicates the number of records to skip from the list of records held by the server based on the sorting method specified. By default, we sort by descending start time. </param>
        /// <param name="maxpagesize"> maxpagesize is the maximum items returned in a page. </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc','CreatedDateTimeUtc desc'). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<TranslationStatusResult> GetTranslationsStatus(int? maxCount = null, int? skip = null, int? maxpagesize = null, IEnumerable<Guid> ids = null, IEnumerable<string> statuses = null, DateTimeOffset? createdDateTimeUtcStart = null, DateTimeOffset? createdDateTimeUtcEnd = null, IEnumerable<string> orderBy = null, CancellationToken cancellationToken = default)
        {
            return new DocumentTranslationClientGetTranslationsStatusCollectionResultOfT(
                this,
                maxCount,
                skip,
                maxpagesize,
                ids,
                statuses,
                createdDateTimeUtcStart,
                createdDateTimeUtcEnd,
                orderBy,
                cancellationToken.ToRequestContext(),
                $"{nameof(DocumentTranslationClient)}.{nameof(GetTranslationStatuses)}");
        }

        /// <summary>
        /// [Protocol Method] Returns a list of batch requests submitted and the status for each request.
        /// </summary>
        /// <param name="maxCount"> top indicates the total number of records the user wants to be returned across all pages. </param>
        /// <param name="skip"> skip indicates the number of records to skip from the list of records held by the server based on the sorting method specified. By default, we sort by descending start time. </param>
        /// <param name="maxpagesize"> maxpagesize is the maximum items returned in a page. </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc','CreatedDateTimeUtc desc'). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual AsyncPageable<BinaryData> GetTranslationsStatusAsync(int? maxCount, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            return new DocumentTranslationClientGetTranslationsStatusAsyncCollectionResult(
                this,
                maxCount,
                skip,
                maxpagesize,
                ids,
                statuses,
                createdDateTimeUtcStart,
                createdDateTimeUtcEnd,
                orderBy,
                context,
                $"{nameof(DocumentTranslationClient)}.{nameof(GetTranslationStatuses)}");
        }

        /// <summary>
        /// [Protocol Method] Returns a list of batch requests submitted and the status for each request.
        /// </summary>
        /// <param name="maxCount"> top indicates the total number of records the user wants to be returned across all pages. </param>
        /// <param name="skip"> skip indicates the number of records to skip from the list of records held by the server based on the sorting method specified. By default, we sort by descending start time. </param>
        /// <param name="maxpagesize"> maxpagesize is the maximum items returned in a page. </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc','CreatedDateTimeUtc desc'). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Pageable<BinaryData> GetTranslationsStatus(int? maxCount, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            return new DocumentTranslationClientGetTranslationsStatusCollectionResult(
                this,
                maxCount,
                skip,
                maxpagesize,
                ids,
                statuses,
                createdDateTimeUtcStart,
                createdDateTimeUtcEnd,
                orderBy,
                context,
                $"{nameof(DocumentTranslationClient)}.{nameof(GetTranslationStatuses)}");
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
