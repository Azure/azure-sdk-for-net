// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using Azure.Core;
using System.ClientModel;

namespace Azure.AI.OpenAI.Realtime;

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureRealtimeClient : RealtimeClient
{
    private readonly Uri _baseEndpoint;
    private readonly string _apiVersion;
    private readonly IDictionary<string, string> _defaultHeaders;
    private readonly IDictionary<string, string> _defaultQueryParameters;
    private readonly ApiKeyCredential _credential;
    private readonly TokenCredential _tokenCredential;
    private readonly List<string> _tokenAuthorizationScopes;
    private readonly string _userAgent;

    public AzureRealtimeClient(Uri endpoint, ApiKeyCredential credential, AzureOpenAIClientOptions options = null)
        : base(credential, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        options ??= new();
        _baseEndpoint = GetEndpoint(endpoint);
        _apiVersion = options.GetRawServiceApiValueForClient(this);
        _defaultHeaders = options.DefaultHeaders;
        _defaultQueryParameters = options.DefaultQueryParameters;
        _credential = credential;
        Core.TelemetryDetails telemetryDetails = new(typeof(AzureOpenAIClient).Assembly, options.UserAgentApplicationId);
        _userAgent = telemetryDetails.ToString();
    }

    public AzureRealtimeClient(Uri endpoint, TokenCredential credential, AzureOpenAIClientOptions options = null)
        : base(credential: new("placeholder") , new OpenAIClientOptions() { Endpoint = endpoint })
    {
        options ??= new();
        _baseEndpoint = GetEndpoint(endpoint);
        _apiVersion = options.GetRawServiceApiValueForClient(this);
        _defaultHeaders = options.DefaultHeaders;
        _defaultQueryParameters = options.DefaultQueryParameters;
        _tokenCredential = credential;
        _tokenAuthorizationScopes = [options?.Audience?.ToString() ?? AzureOpenAIAudience.AzurePublicCloud.ToString()];
        Core.TelemetryDetails telemetryDetails = new(typeof(AzureOpenAIClient).Assembly, options?.UserAgentApplicationId);
        _userAgent = telemetryDetails.ToString();
    }

    private static Uri GetEndpoint(Uri endpoint)
    {
        UriBuilder baseBuilder = new(endpoint);
        baseBuilder.Scheme = baseBuilder.Scheme switch
        {
            "http" => "ws",
            "https" => "wss",
            _ => baseBuilder.Scheme,
        };

        ClientUriBuilder uriBuilder = new();
        uriBuilder.Reset(baseBuilder.Uri);

        if (!baseBuilder.Path.EndsWith($"/openai/realtime"))
        {
            string path = baseBuilder.Path.Length > 0 && baseBuilder.Path[baseBuilder.Path.Length - 1] == '/'
                ? "openai/realtime"
                : "/openai/realtime";
            uriBuilder.AppendPath(path, escape: false);
        }

        return uriBuilder.ToUri();
    }
}

#endif
