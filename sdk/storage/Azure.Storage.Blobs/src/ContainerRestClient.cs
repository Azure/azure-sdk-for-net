// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    // CUSTOM:
    // - Maintain optionality of delimiter parameter for backwards compatibility.
    internal partial class ContainerRestClient
    {
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
    }
}
