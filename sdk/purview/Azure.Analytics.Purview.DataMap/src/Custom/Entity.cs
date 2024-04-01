// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Analytics.Purview.DataMap;

public partial class Entity
{
    // CUSTOM CODE NOTE:
    //   This file is the central hub of .NET client customization for Purview DataMap.

    internal HttpMessage CreateImportBusinessMetadataRequest(RequestContent content, string contentType, RequestContext context)
    {
        var message = _pipeline.CreateMessage(context, ResponseClassifier200);
        var request = message.Request;
        request.Method = RequestMethod.Post;
        var uri = new RawRequestUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendRaw("/datamap/api", false);
        uri.AppendPath("/atlas/v2/entity/businessmetadata/import", false);
        uri.AppendQuery("api-version", _apiVersion, true);
        request.Uri = uri;
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("content-type", contentType);
        request.Content = content;
        return message;
    }
}
