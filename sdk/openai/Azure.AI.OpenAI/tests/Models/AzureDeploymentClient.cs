// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.AI.OpenAI.Tests.Utils.Config;
using Azure.Core;

namespace Azure.AI.OpenAI.Tests.Models;

internal class AzureDeploymentClient : IDisposable
{
    private const string DEFAULT_API_VERSION = "2023-10-01-preview";
    private const string DEFAULT_SKU_NAME = "standard";
    private const int DEFAULT_CAPACITY = 1;

    private HttpClient _client;
    private AccessToken? _cachedAuthToken;
    private readonly string _subscriptionId;
    private readonly string _resourceGroup;
    private readonly string _resourceName;
    private readonly string _endpointUrl;
    private readonly string _apiVersion;

    protected AzureDeploymentClient()
    {
        // for mocking
        _client = new();
        _subscriptionId = _resourceGroup = _resourceName = _endpointUrl = string.Empty;
        _apiVersion = DEFAULT_API_VERSION;
    }

    public AzureDeploymentClient(IConfiguration config, string? apiVersion = null)
    {
        if (config == null)
        {
            throw new ArgumentNullException(nameof(config));
        }

        _client = new();

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
        _client.Dispose();
    }

    private async ValueTask<AzureDeployedModel> CreateDeploymentAsync(bool isAsync, string deploymentName, string modelName, string? skuName, int capacity, CancellationToken token)
    {
        using HttpRequestMessage request = new()
        {
            Method = HttpMethod.Put,
            Content = ToStringContent(new
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
            })
        };

        using HttpResponseMessage response = await SendRequestAsync(isAsync, deploymentName, request, token)
            .ConfigureAwait(false);

        return await FromJsonContentAsync<AzureDeployedModel>(isAsync, response, token)
            .ConfigureAwait(false);
    }

    private async ValueTask<AzureDeployedModel> GetDeploymentAsync(bool isAsync, string deploymentName, CancellationToken token)
    {
        using HttpRequestMessage request = new()
        {
            Method = HttpMethod.Get,
        };

        using var response = await SendRequestAsync(isAsync, deploymentName, request, token)
            .ConfigureAwait(false);

        return await FromJsonContentAsync<AzureDeployedModel>(isAsync, response, token)
           .ConfigureAwait(false);
    }

    private async ValueTask<bool> DeleteDeploymentAsync(bool isAsync, string modelId, CancellationToken token)
    {
        using HttpRequestMessage request = new()
        {
            Method = HttpMethod.Delete
        };

        using HttpResponseMessage response = await SendRequestAsync(isAsync, modelId, request, token).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        return true;
    }

    private StringContent ToStringContent<T>(T value)
    {
        string jsonContent = JsonSerializer.Serialize(value, JsonHelpers.AzureJsonOptions);
        return new StringContent(jsonContent, Encoding.UTF8, "application/json");
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

    private async ValueTask<T> FromJsonContentAsync<T>(bool isAsync, HttpResponseMessage response, CancellationToken token)
    {
        if (!response.IsSuccessStatusCode)
        {
            if (response.Content?.Headers?.ContentType?.MediaType == "application/json")
            {
                using var errorStream = await GetJsonStreamAsync(isAsync, response, token).ConfigureAwait(false);
                ErrorInfo? error = JsonHelpers.Deserialize<ErrorInfo>(errorStream, JsonHelpers.AzureJsonOptions);
                if (error?.Error != null)
                {
                    throw new ApplicationException($"[{(int)response.StatusCode} - {error.Error.Code}] {error.Error.Message}");
                }
            }

            response.EnsureSuccessStatusCode();
        }

        using var stream = await GetJsonStreamAsync(isAsync, response, token).ConfigureAwait(false);
        return JsonHelpers.Deserialize<T>(stream, JsonHelpers.AzureJsonOptions)
            ?? throw new InvalidDataException("Service returend a null JSON response body");
    }

    private static async ValueTask<Stream> GetJsonStreamAsync(bool isAsync, HttpResponseMessage response, CancellationToken token)
    {
        if (response.Content == null)
        {
            throw new InvalidDataException("Service did not return a response body");
        }
        else if (response.Content.Headers.ContentType?.MediaType != "application/json")
        {
            throw new InvalidDataException("Service did not return a JSON response body. Got: " + (response.Content.Headers.ContentType?.MediaType ?? "<<null>>"));
        }

        return
#if NET
            isAsync
                ? await response.Content.ReadAsStreamAsync(token).ConfigureAwait(false)
                : response.Content.ReadAsStream(token);
#else
            // NOTE: .Net Framework's HttpClient does not have a synchronous ReadAsStream method
            await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif
    }

    private async ValueTask<HttpResponseMessage> SendRequestAsync(bool isAsync, string pathPart, HttpRequestMessage request, CancellationToken token)
    {
        string requestId = Guid.NewGuid().ToString();
        string bearerToken = await GetOrRenewAuthTokenAsync(isAsync, requestId, token).ConfigureAwait(false);

        string fullEndpoint = _endpointUrl + pathPart + "?api-version=" + _apiVersion;

        request.RequestUri = new Uri(fullEndpoint);
        request.Headers.TryAddWithoutValidation("x-ms-client-request-id", requestId);
        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + bearerToken);

        HttpResponseMessage response;
#if NET
        // NOTE: .Net Framework's HttpClient does not have a synchronous Send method
        if (isAsync)
        {
#endif
            response = await _client.SendAsync(request, token).ConfigureAwait(false);
#if NET
        }
        else
        {
            response = _client.Send(request, token);
        }
#endif

        return response;
    }

    private async ValueTask<string> GetOrRenewAuthTokenAsync(bool isAsync, string requestId, CancellationToken token)
    {
        // TODO FIXME: Use more streamlined way to get bearer auth token
        if (_cachedAuthToken?.ExpiresOn > DateTimeOffset.Now.AddSeconds(-5))
        {
            return _cachedAuthToken.Value.Token;
        }

        var cred = new Azure.Identity.DefaultAzureCredential();
        var context = new Core.TokenRequestContext(
            [
                "https://management.azure.com/.default"
            ],
            requestId);

        AccessToken authToken;
        if (isAsync)
        {
            authToken = await cred.GetTokenAsync(context, token).ConfigureAwait(false);
        }
        else
        {
            authToken = cred.GetToken(context, token);
        }

        string bearerToken = authToken.Token;
        _cachedAuthToken = authToken;
        return bearerToken;
    }
}
