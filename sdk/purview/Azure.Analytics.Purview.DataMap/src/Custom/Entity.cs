// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.DataMap;

public partial class Entity
{
    // CUSTOM CODE NOTE:
    //   This file is the central hub of .NET client customization for Purview DataMap.


    /// <summary> Upload the file for creating Business Metadata in BULK. </summary>
    /// <param name="file"> InputStream of file. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
    /// <include file="Docs/Entity.xml" path="doc/members/member[@name='ImportBusinessMetadataAsync(BinaryData,CancellationToken)']/*" />
    public virtual async Task<Response<BulkImportResult>> ImportBusinessMetadataAsync(BinaryData file, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(file, nameof(file));

        RequestContext context = FromCancellationToken(cancellationToken);
        ImportBusinessMetadataRequest importBusinessMetadataRequest = new ImportBusinessMetadataRequest(file);
        Response response = await ImportBusinessMetadataAsync(importBusinessMetadataRequest.ToRequestContent(), context).ConfigureAwait(false);
        return Response.FromValue(BulkImportResult.FromResponse(response), response);
    }

    /// <summary> Upload the file for creating Business Metadata in BULK. </summary>
    /// <param name="file"> InputStream of file. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
    /// <include file="Docs/Entity.xml" path="doc/members/member[@name='ImportBusinessMetadata(BinaryData,CancellationToken)']/*" />
    public virtual Response<BulkImportResult> ImportBusinessMetadata(BinaryData file, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(file, nameof(file));

        RequestContext context = FromCancellationToken(cancellationToken);
        ImportBusinessMetadataRequest importBusinessMetadataRequest = new ImportBusinessMetadataRequest(file);
        Response response = ImportBusinessMetadata(importBusinessMetadataRequest.ToRequestContent(), context);
        return Response.FromValue(BulkImportResult.FromResponse(response), response);
    }

    /// <summary>
    /// [Protocol Method] Upload the file for creating Business Metadata in BULK
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="ImportBusinessMetadataAsync(BinaryData,CancellationToken)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    /// <include file="Docs/Entity.xml" path="doc/members/member[@name='ImportBusinessMetadataAsync(RequestContent,RequestContext)']/*" />


    /// <summary>
    /// [Protocol Method] Upload the file for creating Business Metadata in BULK
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="ImportBusinessMetadata(BinaryData,CancellationToken)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    /// <include file="Docs/Entity.xml" path="doc/members/member[@name='ImportBusinessMetadata(RequestContent,RequestContext)']/*" />
    public virtual Response ImportBusinessMetadata(RequestContent content, RequestContext context = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using var scope = ClientDiagnostics.CreateScope("Entity.ImportBusinessMetadata");
        scope.Start();
        try
        {
            using HttpMessage message = CreateImportBusinessMetadataRequest(content, context);
            return _pipeline.ProcessMessage(message, context);
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    internal HttpMessage CreateImportBusinessMetadataRequest(RequestContent content, RequestContext context)
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
        request.Headers.Add("content-type", "multipart/form-data");
        request.Content = content;
        (content as MultipartFormDataContent).ApplyToRequest(request);
        return message;
    }
}
