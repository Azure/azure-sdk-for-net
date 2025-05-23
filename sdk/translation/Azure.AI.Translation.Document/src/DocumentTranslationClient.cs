// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
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
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));
            options ??= new DocumentTranslationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
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
            _pipeline = pipeline;
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

        /// <summary> Returns a list of batch requests submitted and the status for each request. </summary>
        /// <param name="maxCount">
        /// $top indicates the total number of records the user wants to be returned across
        /// all pages.
        ///
        /// Clients MAY use $top and $skip query parameters to
        /// specify a number of results to return and an offset into the collection.
        /// When
        /// both $top and $skip are given by a client, the server SHOULD first apply $skip
        /// and then $top on the collection.
        ///
        /// Note: If the server can't honor
        /// $top and/or $skip, the server MUST return an error to the client informing
        /// about it instead of just ignoring the query options.
        /// </param>
        /// <param name="skip">
        /// $skip indicates the number of records to skip from the list of records held by
        /// the server based on the sorting method specified.  By default, we sort by
        /// descending start time.
        ///
        /// Clients MAY use $top and $skip query
        /// parameters to specify a number of results to return and an offset into the
        /// collection.
        /// When both $top and $skip are given by a client, the server SHOULD
        /// first apply $skip and then $top on the collection.
        ///
        /// Note: If the
        /// server can't honor $top and/or $skip, the server MUST return an error to the
        /// client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="maxpagesize">
        /// $maxpagesize is the maximum items returned in a page.  If more items are
        /// requested via $top (or $top is not specified and there are more items to be
        /// returned), @nextLink will contain the link to the next page.
        ///
        ///
        /// Clients MAY request server-driven paging with a specific page size by
        /// specifying a $maxpagesize preference. The server SHOULD honor this preference
        /// if the specified page size is smaller than the server's default page size.
        /// </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc','CreatedDateTimeUtc desc'). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// Returns a list of batch requests submitted and the status for each
        /// request.
        /// This list only contains batch requests submitted by the user (based on
        /// the resource).
        ///
        /// If the number of requests exceeds our paging limit,
        /// server-side paging is used. Paginated responses indicate a partial result and
        /// include a continuation token in the response.
        /// The absence of a continuation
        /// token means that no additional pages are available.
        ///
        /// $top, $skip
        /// and $maxpagesize query parameters can be used to specify a number of results to
        /// return and an offset for the collection.
        ///
        /// $top indicates the total
        /// number of records the user wants to be returned across all pages.
        /// $skip
        /// indicates the number of records to skip from the list of batches based on the
        /// sorting method specified.  By default, we sort by descending start
        /// time.
        /// $maxpagesize is the maximum items returned in a page.  If more items are
        /// requested via $top (or $top is not specified and there are more items to be
        /// returned), @nextLink will contain the link to the next page.
        ///
        ///
        /// $orderBy query parameter can be used to sort the returned list (ex
        /// "$orderBy=createdDateTimeUtc asc" or "$orderBy=createdDateTimeUtc
        /// desc").
        /// The default sorting is descending by createdDateTimeUtc.
        /// Some query
        /// parameters can be used to filter the returned list (ex:
        /// "status=Succeeded,Cancelled") will only return succeeded and cancelled
        /// operations.
        /// createdDateTimeUtcStart and createdDateTimeUtcEnd can be used
        /// combined or separately to specify a range of datetime to filter the returned
        /// list by.
        /// The supported filtering query parameters are (status, ids,
        /// createdDateTimeUtcStart, createdDateTimeUtcEnd).
        ///
        /// The server honors
        /// the values specified by the client. However, clients must be prepared to handle
        /// responses that contain a different page size or contain a continuation token.
        ///
        ///
        /// When both $top and $skip are included, the server should first apply
        /// $skip and then $top on the collection.
        /// Note: If the server can't honor $top
        /// and/or $skip, the server must return an error to the client informing about it
        /// instead of just ignoring the query options.
        /// This reduces the risk of the client
        /// making assumptions about the data returned.
        /// </remarks>
        public virtual AsyncPageable<TranslationStatusResult> GetTranslationsStatusAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, IEnumerable<Guid> ids = null, IEnumerable<string> statuses = null, DateTimeOffset? createdDateTimeUtcStart = null, DateTimeOffset? createdDateTimeUtcEnd = null, IEnumerable<string> orderBy = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTranslationsStatusRequest(maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTranslationsStatusNextPageRequest(nextLink, maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => TranslationStatusResult.DeserializeTranslationStatusResult(e), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetTranslationsStatuses", "value", "nextLink", context);
        }

        /// <summary> Returns a list of batch requests submitted and the status for each request. </summary>
        /// <param name="maxCount">
        /// $top indicates the total number of records the user wants to be returned across
        /// all pages.
        ///
        /// Clients MAY use $top and $skip query parameters to
        /// specify a number of results to return and an offset into the collection.
        /// When
        /// both $top and $skip are given by a client, the server SHOULD first apply $skip
        /// and then $top on the collection.
        ///
        /// Note: If the server can't honor
        /// $top and/or $skip, the server MUST return an error to the client informing
        /// about it instead of just ignoring the query options.
        /// </param>
        /// <param name="skip">
        /// $skip indicates the number of records to skip from the list of records held by
        /// the server based on the sorting method specified.  By default, we sort by
        /// descending start time.
        ///
        /// Clients MAY use $top and $skip query
        /// parameters to specify a number of results to return and an offset into the
        /// collection.
        /// When both $top and $skip are given by a client, the server SHOULD
        /// first apply $skip and then $top on the collection.
        ///
        /// Note: If the
        /// server can't honor $top and/or $skip, the server MUST return an error to the
        /// client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="maxpagesize">
        /// $maxpagesize is the maximum items returned in a page.  If more items are
        /// requested via $top (or $top is not specified and there are more items to be
        /// returned), @nextLink will contain the link to the next page.
        ///
        ///
        /// Clients MAY request server-driven paging with a specific page size by
        /// specifying a $maxpagesize preference. The server SHOULD honor this preference
        /// if the specified page size is smaller than the server's default page size.
        /// </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc','CreatedDateTimeUtc desc'). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// Returns a list of batch requests submitted and the status for each
        /// request.
        /// This list only contains batch requests submitted by the user (based on
        /// the resource).
        ///
        /// If the number of requests exceeds our paging limit,
        /// server-side paging is used. Paginated responses indicate a partial result and
        /// include a continuation token in the response.
        /// The absence of a continuation
        /// token means that no additional pages are available.
        ///
        /// $top, $skip
        /// and $maxpagesize query parameters can be used to specify a number of results to
        /// return and an offset for the collection.
        ///
        /// $top indicates the total
        /// number of records the user wants to be returned across all pages.
        /// $skip
        /// indicates the number of records to skip from the list of batches based on the
        /// sorting method specified.  By default, we sort by descending start
        /// time.
        /// $maxpagesize is the maximum items returned in a page.  If more items are
        /// requested via $top (or $top is not specified and there are more items to be
        /// returned), @nextLink will contain the link to the next page.
        ///
        ///
        /// $orderBy query parameter can be used to sort the returned list (ex
        /// "$orderBy=createdDateTimeUtc asc" or "$orderBy=createdDateTimeUtc
        /// desc").
        /// The default sorting is descending by createdDateTimeUtc.
        /// Some query
        /// parameters can be used to filter the returned list (ex:
        /// "status=Succeeded,Cancelled") will only return succeeded and cancelled
        /// operations.
        /// createdDateTimeUtcStart and createdDateTimeUtcEnd can be used
        /// combined or separately to specify a range of datetime to filter the returned
        /// list by.
        /// The supported filtering query parameters are (status, ids,
        /// createdDateTimeUtcStart, createdDateTimeUtcEnd).
        ///
        /// The server honors
        /// the values specified by the client. However, clients must be prepared to handle
        /// responses that contain a different page size or contain a continuation token.
        ///
        ///
        /// When both $top and $skip are included, the server should first apply
        /// $skip and then $top on the collection.
        /// Note: If the server can't honor $top
        /// and/or $skip, the server must return an error to the client informing about it
        /// instead of just ignoring the query options.
        /// This reduces the risk of the client
        /// making assumptions about the data returned.
        /// </remarks>
        public virtual Pageable<TranslationStatusResult> GetTranslationsStatus(int? maxCount = null, int? skip = null, int? maxpagesize = null, IEnumerable<Guid> ids = null, IEnumerable<string> statuses = null, DateTimeOffset? createdDateTimeUtcStart = null, DateTimeOffset? createdDateTimeUtcEnd = null, IEnumerable<string> orderBy = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTranslationsStatusRequest(maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTranslationsStatusNextPageRequest(nextLink, maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => TranslationStatusResult.DeserializeTranslationStatusResult(e), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetTranslationStatuses", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Returns a list of batch requests submitted and the status for each request
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTranslationsStatusAsync(int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount">
        /// $top indicates the total number of records the user wants to be returned across
        /// all pages.
        ///
        /// Clients MAY use $top and $skip query parameters to
        /// specify a number of results to return and an offset into the collection.
        /// When
        /// both $top and $skip are given by a client, the server SHOULD first apply $skip
        /// and then $top on the collection.
        ///
        /// Note: If the server can't honor
        /// $top and/or $skip, the server MUST return an error to the client informing
        /// about it instead of just ignoring the query options.
        /// </param>
        /// <param name="skip">
        /// $skip indicates the number of records to skip from the list of records held by
        /// the server based on the sorting method specified.  By default, we sort by
        /// descending start time.
        ///
        /// Clients MAY use $top and $skip query
        /// parameters to specify a number of results to return and an offset into the
        /// collection.
        /// When both $top and $skip are given by a client, the server SHOULD
        /// first apply $skip and then $top on the collection.
        ///
        /// Note: If the
        /// server can't honor $top and/or $skip, the server MUST return an error to the
        /// client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="maxpagesize">
        /// $maxpagesize is the maximum items returned in a page.  If more items are
        /// requested via $top (or $top is not specified and there are more items to be
        /// returned), @nextLink will contain the link to the next page.
        ///
        ///
        /// Clients MAY request server-driven paging with a specific page size by
        /// specifying a $maxpagesize preference. The server SHOULD honor this preference
        /// if the specified page size is smaller than the server's default page size.
        /// </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc','CreatedDateTimeUtc desc'). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual AsyncPageable<BinaryData> GetTranslationsStatusAsync(int? maxCount, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTranslationsStatusRequest(maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTranslationsStatusNextPageRequest(nextLink, maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetTranslationStatuses", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Returns a list of batch requests submitted and the status for each request
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTranslationsStatus(int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount">
        /// $top indicates the total number of records the user wants to be returned across
        /// all pages.
        ///
        /// Clients MAY use $top and $skip query parameters to
        /// specify a number of results to return and an offset into the collection.
        /// When
        /// both $top and $skip are given by a client, the server SHOULD first apply $skip
        /// and then $top on the collection.
        ///
        /// Note: If the server can't honor
        /// $top and/or $skip, the server MUST return an error to the client informing
        /// about it instead of just ignoring the query options.
        /// </param>
        /// <param name="skip">
        /// $skip indicates the number of records to skip from the list of records held by
        /// the server based on the sorting method specified.  By default, we sort by
        /// descending start time.
        ///
        /// Clients MAY use $top and $skip query
        /// parameters to specify a number of results to return and an offset into the
        /// collection.
        /// When both $top and $skip are given by a client, the server SHOULD
        /// first apply $skip and then $top on the collection.
        ///
        /// Note: If the
        /// server can't honor $top and/or $skip, the server MUST return an error to the
        /// client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="maxpagesize">
        /// $maxpagesize is the maximum items returned in a page.  If more items are
        /// requested via $top (or $top is not specified and there are more items to be
        /// returned), @nextLink will contain the link to the next page.
        ///
        ///
        /// Clients MAY request server-driven paging with a specific page size by
        /// specifying a $maxpagesize preference. The server SHOULD honor this preference
        /// if the specified page size is smaller than the server's default page size.
        /// </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc','CreatedDateTimeUtc desc'). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual Pageable<BinaryData> GetTranslationsStatus(int? maxCount, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTranslationsStatusRequest(maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTranslationsStatusNextPageRequest(nextLink, maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetTranslationStatuses", "value", "nextLink", context);
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
