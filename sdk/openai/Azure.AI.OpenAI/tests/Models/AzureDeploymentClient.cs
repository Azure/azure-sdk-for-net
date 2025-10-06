// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.TestFramework.Utils;

namespace Azure.AI.OpenAI.Tests.Models;

internal class AzureDeploymentClient : IDisposable
{
    private const string DEFAULT_API_VERSION = "2023-10-01-preview";
    private const string DEFAULT_SKU_NAME = "standard";
    private const int DEFAULT_CAPACITY = 1;

    private CancellationTokenSource _cts;
    private ClientPipeline _pipeline;
    private Core.AccessToken? _cachedAuthToken;
    private readonly Core.TokenCredential _credential;
    private readonly string _subscriptionId;
    private readonly string _resourceGroup;
    private readonly string _resourceName;
    private readonly string _endpointUrl;
    private readonly string _apiVersion;

    internal AzureDeploymentClient()
    {
        // for mocking
        _cts = new();
        _pipeline = ClientPipeline.Create();
        _subscriptionId = _resourceGroup = _resourceName = _endpointUrl = string.Empty;
        _apiVersion = DEFAULT_API_VERSION;
        _credential = null!;
    }

    public AzureDeploymentClient(IConfiguration config, Core.TokenCredential credential, string? apiVersion = null, PipelineTransport? transport = null)
    {
        if (config == null)
        {
            throw new ArgumentNullException(nameof(config));
        }

        _cts = new();
        _pipeline = ClientPipeline.Create(new ClientPipelineOptions()
        {
            Transport = transport ?? new HttpClientPipelineTransport()
        });
        _credential = credential ?? throw new ArgumentNullException(nameof(credential));

        _subscriptionId = config.GetValueOrThrow<string>("subscription_id");
        _resourceGroup = config.GetValueOrThrow<string>("resource_group");
        _resourceName = config.Endpoint?.IdnHost.Split('.').FirstOrDefault()
            ?? throw new KeyNotFoundException("Could extract the resource name from the endpoint URL in the config");

        _endpointUrl = $"https://management.azure.com/subscriptions/{_subscriptionId}/resourceGroups/{_resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{_resourceName}/deployments/";

        _apiVersion = DEFAULT_API_VERSION;
        if (!string.IsNullOrWhiteSpace(apiVersion))
        {
            _apiVersion = Uri.EscapeDataString(apiVersion);
        }
    }

    public virtual AzureDeployedModel CreateDeployment(string deploymentName, string modelName, string? skuName = DEFAULT_SKU_NAME, int capacity = DEFAULT_CAPACITY, CancellationToken token = default)
        => CreateDeploymentAsync(false, deploymentName, modelName, skuName, capacity, token).GetAwaiter().GetResult();

    public virtual Task<AzureDeployedModel> CreateDeploymentAsync(string deploymentName, string modelName, string? skuName = DEFAULT_SKU_NAME, int capacity = DEFAULT_CAPACITY, CancellationToken token = default)
        => CreateDeploymentAsync(true, deploymentName, modelName, skuName, capacity, token).AsTask();

    public virtual AzureDeployedModel GetDeployment(string deploymentName, CancellationToken token = default)
        => GetDeploymentAsync(false, deploymentName, token).GetAwaiter().GetResult();

    public virtual Task<AzureDeployedModel> GetDeploymentAsync(string deploymentName, CancellationToken token = default)
        => GetDeploymentAsync(true, deploymentName, token).AsTask();

    public virtual bool DeleteDeployment(string deploymentName, CancellationToken token = default)
        => DeleteDeploymentAsync(false, deploymentName, token).GetAwaiter().GetResult();

    public virtual Task<bool> DeleteDeploymentAsync(string deploymentName, CancellationToken token = default)
        => DeleteDeploymentAsync(true, deploymentName, token).AsTask();

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }

    private async ValueTask<AzureDeployedModel> CreateDeploymentAsync(bool isAsync, string deploymentName, string modelName, string? skuName, int capacity, CancellationToken token)
    {
        BinaryContent content = ToJsonContent(new
        {
            sku = new
            {
                name = skuName,
                capacity = capacity.ToString(CultureInfo.InvariantCulture),
            },
            properties = new
            {
                model = new
                {
                    format = "OpenAI",
                    name = modelName,
                    version = "1"
                }
            }
        });

        PipelineResponse response = await SendRequestAsync(isAsync, HttpMethod.Put, deploymentName, content, token)
            .ConfigureAwait(false);
        return FromJsonContent<AzureDeployedModel>(response, token);
    }

    private async ValueTask<AzureDeployedModel> GetDeploymentAsync(bool isAsync, string deploymentName, CancellationToken token)
    {
        PipelineResponse response = await SendRequestAsync(isAsync, HttpMethod.Get, deploymentName, null, token)
            .ConfigureAwait(false);
        return FromJsonContent<AzureDeployedModel>(response, token);
    }

    private async ValueTask<bool> DeleteDeploymentAsync(bool isAsync, string deploymentName, CancellationToken token)
    {
        PipelineResponse response = await SendRequestAsync(isAsync, HttpMethod.Delete, deploymentName, null, token)
            .ConfigureAwait(false);
        ThrowOnFailed(response);
        return true;
    }

    private static BinaryContent ToJsonContent<T>(T value)
    {
        Utf8JsonBinaryContent content = new();
        JsonSerializer.Serialize(content.JsonWriter, value, typeof(T), JsonOptions.AzureJsonOptions);
        return content;
    }

    private class ErrorDetail
    {
        public string? Code { get; init; }
        public string? Message { get; init; }
    }

    private class ErrorInfo
    {
        public ErrorDetail? Error { get; init; }
    }

    private static void ThrowOnFailed(PipelineResponse response)
    {
        if (response.IsError)
        {
            if (response.Content != null
                && response.Headers.GetFirstOrDefault("Content-Type")?.StartsWith("application/json") == true)
            {
                using Stream errorStream = response.Content.ToStream();
                ErrorInfo? error = JsonSerializer.Deserialize<ErrorInfo>(errorStream, JsonOptions.AzureJsonOptions);
                if (error?.Error != null)
                {
                    throw new ClientResultException($"[{response.Status} - {error.Error.Code}] {error.Error.Message}", response);
                }
            }

            throw new ClientResultException(response);
        }
    }

    private static T FromJsonContent<T>(PipelineResponse response, CancellationToken token)
    {
        ThrowOnFailed(response);

        using Stream stream = response.Content.ToStream();
        return JsonSerializer.Deserialize<T>(stream, JsonOptions.AzureJsonOptions)
            ?? throw new InvalidDataException("Service returned a null JSON response body");
    }

    private async ValueTask<PipelineResponse> SendRequestAsync(bool isAsync, HttpMethod method, string pathPart, BinaryContent? body, CancellationToken token)
    {
        var linked = CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, token);

        PipelineMessage message = _pipeline.CreateMessage();
        message.Apply(new()
        {
            CancellationToken = linked.Token,
            ErrorOptions = ClientErrorBehaviors.NoThrow
        });

        string requestId = Guid.NewGuid().ToString();
        string bearerToken = await GetOrRenewAuthTokenAsync(isAsync, requestId, token).ConfigureAwait(false);

        string fullEndpoint = _endpointUrl + pathPart + "?api-version=" + _apiVersion;

        PipelineRequest request = message.Request;
        request.Method = method.Method;
        request.Uri = new Uri(fullEndpoint);
        request.Headers.Add("x-ms-client-request-id", requestId);
        request.Headers.Add("Authorization", "Bearer " + bearerToken);
        if (body != null)
        {
            request.Headers.Add("Content-Type", "application/json");
            request.Content = body;
        }

        if (isAsync)
        {
            await _pipeline.SendAsync(message).ConfigureAwait(false);
        }
        else
        {
            _pipeline.Send(message);
        }

        return message.Response ?? throw new InvalidOperationException("No response was set after sending");
    }

    private async ValueTask<string> GetOrRenewAuthTokenAsync(bool isAsync, string requestId, CancellationToken token)
    {
        // TODO FIXME: Use more streamlined way to get bearer auth token
        if (_cachedAuthToken?.ExpiresOn > DateTimeOffset.Now.AddSeconds(-5))
        {
            return _cachedAuthToken.Value.Token;
        }

        var context = new Core.TokenRequestContext(
            [
                "https://management.azure.com/.default"
            ],
            requestId);

        Core.AccessToken authToken;
        if (isAsync)
        {
            authToken = await _credential.GetTokenAsync(context, token).ConfigureAwait(false);
        }
        else
        {
            authToken = _credential.GetToken(context, token);
        }

        string bearerToken = authToken.Token;
        _cachedAuthToken = authToken;
        return bearerToken;
    }
}
