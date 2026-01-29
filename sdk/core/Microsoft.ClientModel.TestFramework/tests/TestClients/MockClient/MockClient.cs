// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class MockClient
{
    private readonly ClientPipeline _pipeline;

    public MockClient() : this(new MockClientOptions())
    {
    }

    public MockClient(MockClientOptions options)
    {
        options ??= new();
        _pipeline = ClientPipeline.Create(options);
    }

    public MockClient(Uri uri, MockClientOptions options) : this(options)
    {
        // parameters are ignored because they are illustrative for samples
    }

    public MockClient(Uri endpoint, AuthenticationTokenProvider credential, MockClientOptions options = null) : this(options)
    {
        // parameters are ignored because they are illustrative for samples
    }

    public virtual ClientResult GetResource(string id, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(id, nameof(id));

        using PipelineMessage message = CreateGetResourceRequest(id);
        _pipeline.Send(message);

        PipelineResponse response = message.Response!;
        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw new ClientResultException(response);
        }
        return ClientResult.FromResponse(response);
    }

    public virtual async Task<ClientResult> GetResourceAsync(string id, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(id, nameof(id));

        using PipelineMessage message = CreateGetResourceRequest(id);
        await _pipeline.SendAsync(message);

        PipelineResponse response = message.Response!;
        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
        }
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateGetResourceRequest(string id)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
        PipelineRequest request = message.Request;
        request.Method = "GET";

        UriBuilder uriBuilder = new("https://mock");

        StringBuilder path = new();
        path.Append("/resources/");
        path.Append(id);
        uriBuilder.Path += path.ToString();

        StringBuilder query = new();
        query.Append("api-version=");
        query.Append(Uri.EscapeDataString("2025-11-07"));
        uriBuilder.Query = query.ToString();

        request.Uri = uriBuilder.Uri;

        request.Headers.Add("Accept", "application/json");

        return message;
    }
}
