// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text;

namespace Microsoft.ClientModel.TestFramework.Tests.LibraryClient;

internal partial class LibraryClient
{
    private PipelineMessage CreateGetBookSummaryRequest(string title, string author, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier.Create([200]);

        // Set request values needed by the service.
        PipelineRequest request = message.Request;
        request.Method = "GET";

        UriBuilder uriBuilder = new(_endpoint.ToString());
        uriBuilder.Path += "book/summary";

        StringBuilder query = new();
        query.Append("author=");
        query.Append(Uri.EscapeDataString(author));
        query.Append("&title=");
        query.Append(Uri.EscapeDataString(title));
        uriBuilder.Query = query.ToString();

        request.Uri = uriBuilder.Uri;

        request.Headers.Add("Accept", "application/json");

        message.Apply(options);

        return message;
    }

    private PipelineMessage CreateAddBookRequest(BinaryContent content, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier.Create([200]);

        PipelineRequest request = message.Request;
        request.Method = "POST";

        UriBuilder uriBuilder = new(_endpoint.ToString())
        {
            Path = "book/add"
        };

        request.Uri = uriBuilder.Uri;
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("Content-Type", "application/json");
        request.Content = content;
        message.Apply(options);

        return message;
    }

    private PipelineMessage CreateUploadBookContentMessage(BinaryContent content, string contentType, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier.Create([200]);
        PipelineRequest request = message.Request;
        request.Method = "POST";

        UriBuilder uriBuilder = new(_endpoint.ToString())
        {
            Path = "book/files"
        };

        request.Uri = uriBuilder.Uri;
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("Content-Type", contentType);
        request.Content = content;
        message.Apply(options);
        return message;
    }

    internal PipelineMessage CreateGetBooksRequest(string author, int? limit, string after, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier.Create([200]);

        PipelineRequest request = message.Request;
        request.Method = "GET";

        UriBuilder uriBuilder = new(_endpoint.ToString());
        uriBuilder.Path += "books";

        StringBuilder query = new();
        bool hasQuery = false;

        if (!string.IsNullOrEmpty(author))
        {
            query.Append("author=");
            query.Append(Uri.EscapeDataString(author));
            hasQuery = true;
        }

        if (limit.HasValue)
        {
            if (hasQuery) query.Append("&");
            query.Append("limit=");
            query.Append(limit.Value);
            hasQuery = true;
        }

        if (!string.IsNullOrEmpty(after))
        {
            if (hasQuery) query.Append("&");
            query.Append("after=");
            query.Append(Uri.EscapeDataString(after));
            hasQuery = true;
        }

        if (hasQuery)
        {
            uriBuilder.Query = query.ToString();
        }

        request.Uri = uriBuilder.Uri;
        request.Headers.Add("Accept", "application/json");

        message.Apply(options);

        return message;
    }
}
