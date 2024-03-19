// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    [CodeGenSuppress("GetTranslationsStatusAsync", typeof(int), typeof(int), typeof(int), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetTranslationsStatus", typeof(int), typeof(int), typeof(int), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetTranslationsStatusAsync", typeof(int), typeof(int), typeof(int), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetTranslationsStatus", typeof(int), typeof(int), typeof(int), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(IEnumerable<string>), typeof(RequestContext))]

    [CodeGenSuppress("CreateStartTranslationRequest", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetTranslationsStatusRequest", typeof(int), typeof(int), typeof(int), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetDocumentStatusRequest", typeof(Guid), typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetTranslationStatusRequest", typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("CreateCancelTranslationRequest", typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetDocumentsStatusRequest", typeof(int), typeof(int), typeof(int), typeof(IEnumerable<Guid>), typeof(IEnumerable<string>), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetSupportedDocumentFormatsRequest", typeof(RequestContext))]
    [CodeGenSuppress("CreateGetSupportedGlossaryFormatsRequest", typeof(RequestContext))]
    [CodeGenSuppress("CreateGetSupportedStorageSourcesRequest", typeof(RequestContext))]
    public partial class DocumentTranslation
    {
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
        /// <param name="orderBy">
        /// the sorting query for the collection (ex: 'CreatedDateTimeUtc asc',
        /// 'CreatedDateTimeUtc desc')
        /// </param>
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
        /// <include file="./Generated/Docs/DocumentTranslation.xml" path="./Generated/doc/members/member[@name='GetTranslationsStatusAsync(int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},CancellationToken)']/*" />
        public virtual AsyncPageable<TranslationStatusResult> GetTranslationsStatusAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, IEnumerable<Guid> ids = null, IEnumerable<string> statuses = null, DateTimeOffset? createdDateTimeUtcStart = null, DateTimeOffset? createdDateTimeUtcEnd = null, IEnumerable<string> orderBy = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTranslationsStatusRequest(maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTranslationsStatusNextPageRequest(nextLink, maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => TranslationStatusResult.DeserializeTranslationStatusResult(e), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetTranslationStatuses", "value", "nextLink", context);
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
        /// <param name="orderBy">
        /// the sorting query for the collection (ex: 'CreatedDateTimeUtc asc',
        /// 'CreatedDateTimeUtc desc')
        /// </param>
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
        /// <include file="./Generated/Docs/DocumentTranslation.xml" path="./Generated/doc/members/member[@name='GetTranslationsStatus(int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},CancellationToken)']/*" />
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
        /// <param name="orderBy">
        /// the sorting query for the collection (ex: 'CreatedDateTimeUtc asc',
        /// 'CreatedDateTimeUtc desc')
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="./Generated/Docs/DocumentTranslation.xml" path="./Generated/doc/members/member[@name='GetTranslationsStatusAsync(int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},RequestContext)']/*" />
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
        /// <param name="orderBy">
        /// the sorting query for the collection (ex: 'CreatedDateTimeUtc asc',
        /// 'CreatedDateTimeUtc desc')
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="./Generated/Docs/DocumentTranslation.xml" path="./Generated/doc/members/member[@name='GetTranslationsStatus(int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetTranslationsStatus(int? maxCount, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTranslationsStatusRequest(maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTranslationsStatusNextPageRequest(nextLink, maxCount, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetTranslationStatuses", "value", "nextLink", context);
        }

        internal HttpMessage CreateStartTranslationRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/translator/text/batch/v1.0", false);
            uri.AppendPath("/batches", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetTranslationsStatusRequest(int? maxCount, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/translator/text/batch/v1.0", false);
            uri.AppendPath("/batches", false);
            // uri.AppendQuery("api-version", _apiVersion, true);
            if (maxCount != null)
            {
                uri.AppendQuery("$top", maxCount.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("$skip", skip.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("$maxpagesize", maxpagesize.Value, true);
            }
            if (ids != null && !(ids is ChangeTrackingList<Guid> changeTrackingList && changeTrackingList.IsUndefined))
            {
                uri.AppendQueryDelimited("ids", ids, ",", true);
            }
            if (statuses != null && !(statuses is ChangeTrackingList<string> changeTrackingList0 && changeTrackingList0.IsUndefined))
            {
                uri.AppendQueryDelimited("statuses", statuses, ",", true);
            }
            if (createdDateTimeUtcStart != null)
            {
                uri.AppendQuery("createdDateTimeUtcStart", createdDateTimeUtcStart.Value, "O", true);
            }
            if (createdDateTimeUtcEnd != null)
            {
                uri.AppendQuery("createdDateTimeUtcEnd", createdDateTimeUtcEnd.Value, "O", true);
            }
            if (orderBy != null && !(orderBy is ChangeTrackingList<string> changeTrackingList1 && changeTrackingList1.IsUndefined))
            {
                uri.AppendQueryDelimited("$orderBy", orderBy, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDocumentStatusRequest(Guid id, Guid documentId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/translator/text/batch/v1.0", false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/documents/", false);
            uri.AppendPath(documentId, true);
            // uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetTranslationStatusRequest(Guid id, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/translator/text/batch/v1.0", false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(id, true);
            // uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCancelTranslationRequest(Guid id, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/translator/text/batch/v1.0", false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(id, true);
            // uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDocumentsStatusRequest(Guid id, int? maxCount, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/translator/text/batch/v1.0", false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/documents", false);
            // uri.AppendQuery("api-version", _apiVersion, true);
            if (maxCount != null)
            {
                uri.AppendQuery("$top", maxCount.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("$skip", skip.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("$maxpagesize", maxpagesize.Value, true);
            }
            if (ids != null && !(ids is ChangeTrackingList<Guid> changeTrackingList && changeTrackingList.IsUndefined))
            {
                uri.AppendQueryDelimited("ids", ids, ",", true);
            }
            if (statuses != null && !(statuses is ChangeTrackingList<string> changeTrackingList0 && changeTrackingList0.IsUndefined))
            {
                uri.AppendQueryDelimited("statuses", statuses, ",", true);
            }
            if (createdDateTimeUtcStart != null)
            {
                uri.AppendQuery("createdDateTimeUtcStart", createdDateTimeUtcStart.Value, "O", true);
            }
            if (createdDateTimeUtcEnd != null)
            {
                uri.AppendQuery("createdDateTimeUtcEnd", createdDateTimeUtcEnd.Value, "O", true);
            }
            if (orderBy != null && !(orderBy is ChangeTrackingList<string> changeTrackingList1 && changeTrackingList1.IsUndefined))
            {
                uri.AppendQueryDelimited("$orderBy", orderBy, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSupportedDocumentFormatsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/translator/text/batch/v1.0", false);
            uri.AppendPath("/documents/formats", false);
            // uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSupportedGlossaryFormatsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/translator/text/batch/v1.0", false);
            uri.AppendPath("/glossaries/formats", false);
            // uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSupportedStorageSourcesRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/translator/text/batch/v1.0", false);
            uri.AppendPath("/storagesources", false);
            // uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier202;
        private static ResponseClassifier ResponseClassifier202 => _responseClassifier202 ??= new StatusCodeClassifier(stackalloc ushort[] { 202 });
    }
}
