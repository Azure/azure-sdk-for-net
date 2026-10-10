// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    // CUSTOM:
    // - Suppress generated GetBlobFlatSegmentApacheArrow & GetBlobHierarchySegmentApacheArrow methods in favor of custom implementations that return Stream.
    // - Maintain optionality of delimiter parameter for backwards compatibility.
    internal partial class ContainerRestClient
    {
        /// <summary> Returns a list of the blobs in Apache Arrow format as raw data, to be deserialized by the client. </summary>
        /// <param name="prefix"> Filters the results to return only resources whose name begins with the specified prefix. </param>
        /// <param name="marker"> An opaque string value that identifies the portion of the result set to return with this operation. </param>
        /// <param name="maxresults"> Specifies the maximum number of resources to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. </param>
        /// <param name="include"> Specify to include additional, optional information. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href=\"https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations\"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="startFrom"> Specifies the relative path to list paths from. For non-recursive list, only one entity level is supported; for recursive list, multiple entity levels are supported. (Inclusive). </param>
        /// <param name="endBefore"> Filters the results to return only names that are ordered before this value. Currently only applies to Apache Arrow scenario. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<Stream> GetBlobFlatSegmentApacheArrow(string prefix = default, string marker = default, int? maxresults = default, IEnumerable<ListBlobsIncludeItem> include = default, int? timeout = default, string startFrom = default, string endBefore = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ContainerRestClient.GetBlobFlatSegmentApacheArrow");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateGetBlobFlatSegmentApacheArrowRequest(prefix, marker, maxresults, include, timeout, startFrom, endBefore, context);
                message.BufferResponse = false;
                Response response = Pipeline.ProcessMessage(message, context);
                Stream content = message.ExtractResponseContent();
                return Response.FromValue(content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a list of the blobs in Apache Arrow format as raw data, to be deserialized by the client. </summary>
        /// <param name="prefix"> Filters the results to return only resources whose name begins with the specified prefix. </param>
        /// <param name="marker"> An opaque string value that identifies the portion of the result set to return with this operation. </param>
        /// <param name="maxresults"> Specifies the maximum number of resources to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. </param>
        /// <param name="include"> Specify to include additional, optional information. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href=\"https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations\"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="startFrom"> Specifies the relative path to list paths from. For non-recursive list, only one entity level is supported; for recursive list, multiple entity levels are supported. (Inclusive). </param>
        /// <param name="endBefore"> Filters the results to return only names that are ordered before this value. Currently only applies to Apache Arrow scenario. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<Stream>> GetBlobFlatSegmentApacheArrowAsync(string prefix = default, string marker = default, int? maxresults = default, IEnumerable<ListBlobsIncludeItem> include = default, int? timeout = default, string startFrom = default, string endBefore = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ContainerRestClient.GetBlobFlatSegmentApacheArrow");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateGetBlobFlatSegmentApacheArrowRequest(prefix, marker, maxresults, include, timeout, startFrom, endBefore, context);
                message.BufferResponse = false;
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Stream content = message.ExtractResponseContent();
                return Response.FromValue(content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a list of the blobs in Apache Arrow format as raw data, to be deserialized by the client. A delimiter can be used to traverse a virtual hierarchy of blobs as though it were a file system. </summary>
        /// <param name="delimiter"> If specified, the operation returns a BlobPrefix element that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string. </param>
        /// <param name="prefix"> Filters the results to return only resources whose name begins with the specified prefix. </param>
        /// <param name="marker"> An opaque string value that identifies the portion of the result set to return with this operation. </param>
        /// <param name="maxresults"> Specifies the maximum number of resources to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. </param>
        /// <param name="include"> Specify to include additional, optional information. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href=\"https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations\"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="startFrom"> Specifies the relative path to list paths from. For non-recursive list, only one entity level is supported; for recursive list, multiple entity levels are supported. (Inclusive). </param>
        /// <param name="endBefore"> Filters the results to return only names that are ordered before this value. Currently only applies to Apache Arrow scenario. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<Stream> GetBlobHierarchySegmentApacheArrow(string delimiter = default, string prefix = default, string marker = default, int? maxresults = default, IEnumerable<ListBlobsIncludeItem> include = default, int? timeout = default, string startFrom = default, string endBefore = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ContainerRestClient.GetBlobHierarchySegmentApacheArrow");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateGetBlobHierarchySegmentApacheArrowRequest(delimiter, prefix, marker, maxresults, include, timeout, startFrom, endBefore, context);
                message.BufferResponse = false;
                Response response = Pipeline.ProcessMessage(message, context);
                Stream content = message.ExtractResponseContent();
                return Response.FromValue(content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a list of the blobs in Apache Arrow format as raw data, to be deserialized by the client. A delimiter can be used to traverse a virtual hierarchy of blobs as though it were a file system. </summary>
        /// <param name="delimiter"> If specified, the operation returns a BlobPrefix element that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string. </param>
        /// <param name="prefix"> Filters the results to return only resources whose name begins with the specified prefix. </param>
        /// <param name="marker"> An opaque string value that identifies the portion of the result set to return with this operation. </param>
        /// <param name="maxresults"> Specifies the maximum number of resources to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. </param>
        /// <param name="include"> Specify to include additional, optional information. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href=\"https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations\"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="startFrom"> Specifies the relative path to list paths from. For non-recursive list, only one entity level is supported; for recursive list, multiple entity levels are supported. (Inclusive). </param>
        /// <param name="endBefore"> Filters the results to return only names that are ordered before this value. Currently only applies to Apache Arrow scenario. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<Stream>> GetBlobHierarchySegmentApacheArrowAsync(string delimiter = default, string prefix = default, string marker = default, int? maxresults = default, IEnumerable<ListBlobsIncludeItem> include = default, int? timeout = default, string startFrom = default, string endBefore = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ContainerRestClient.GetBlobHierarchySegmentApacheArrow");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateGetBlobHierarchySegmentApacheArrowRequest(delimiter, prefix, marker, maxresults, include, timeout, startFrom, endBefore, context);
                message.BufferResponse = false;
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Stream content = message.ExtractResponseContent();
                return Response.FromValue(content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetBlobHierarchySegmentRequest(string delimiter, string prefix, string marker, int? maxresults, IEnumerable<ListBlobsIncludeItem> include, int? timeout, string startFrom, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendQuery("restype", "container", true);
            uri.AppendQuery("comp", "list", true);
            if (delimiter != null)
            {
                uri.AppendQuery("delimiter", delimiter, true);
            }
            if (prefix != null)
            {
                uri.AppendQuery("prefix", prefix, true);
            }
            if (marker != null)
            {
                uri.AppendQuery("marker", marker, true);
            }
            if (maxresults != null)
            {
                uri.AppendQuery("maxresults", TypeFormatters.ConvertToString(maxresults), true);
            }
            if (include != null && !(include is ChangeTrackingList<ListBlobsIncludeItem> changeTrackingList && changeTrackingList.IsUndefined))
            {
                uri.AppendQueryDelimited("include", include, ",", escape: true);
            }
            if (timeout != null)
            {
                uri.AppendQuery("timeout", TypeFormatters.ConvertToString(timeout), true);
            }
            if (startFrom != null)
            {
                uri.AppendQuery("startFrom", startFrom, true);
            }
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            if (_version != null)
            {
                request.Headers.SetValue("x-ms-version", _version);
            }
            request.Headers.SetValue("Accept", "application/xml");
            return message;
        }

        internal HttpMessage CreateGetBlobHierarchySegmentApacheArrowRequest(string delimiter, string prefix, string marker, int? maxresults, IEnumerable<ListBlobsIncludeItem> include, int? timeout, string startFrom, string endBefore, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendQuery("restype", "container", true);
            uri.AppendQuery("comp", "list", true);
            if (delimiter != null)
            {
                uri.AppendQuery("delimiter", delimiter, true);
            }
            if (prefix != null)
            {
                uri.AppendQuery("prefix", prefix, true);
            }
            if (marker != null)
            {
                uri.AppendQuery("marker", marker, true);
            }
            if (maxresults != null)
            {
                uri.AppendQuery("maxresults", TypeFormatters.ConvertToString(maxresults), true);
            }
            if (include != null && !(include is ChangeTrackingList<ListBlobsIncludeItem> changeTrackingList && changeTrackingList.IsUndefined))
            {
                uri.AppendQueryDelimited("include", include, ",", escape: true);
            }
            if (timeout != null)
            {
                uri.AppendQuery("timeout", TypeFormatters.ConvertToString(timeout), true);
            }
            if (startFrom != null)
            {
                uri.AppendQuery("startFrom", startFrom, true);
            }
            if (endBefore != null)
            {
                uri.AppendQuery("endBefore", endBefore, true);
            }
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            if (_version != null)
            {
                request.Headers.SetValue("x-ms-version", _version);
            }
            request.Headers.SetValue("Accept", "application/vnd.apache.arrow.stream,application/xml");
            return message;
        }
    }
}
