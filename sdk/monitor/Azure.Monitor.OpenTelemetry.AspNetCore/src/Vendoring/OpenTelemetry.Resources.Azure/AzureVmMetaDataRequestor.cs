// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;

namespace OpenTelemetry.Resources.Azure;

internal static class AzureVmMetaDataRequestor
{
    internal const int MaxResponseContentBufferSize = 4 * 1024 * 1024;

    private static readonly Uri AzureVmMetadataEndpointUri = new("http://169.254.169.254/metadata/instance/compute?api-version=2021-12-13&format=json");

    public static Func<AzureVmMetadataResponse?> GetAzureVmMetaDataResponse { get; internal set; } = GetAzureVmMetaDataResponseDefault;

    public static AzureVmMetadataResponse? GetAzureVmMetaDataResponseDefault()
    {
        var timeout = TimeSpan.FromSeconds(2);

        using var cts = new CancellationTokenSource(timeout);
        using var httpClient = new HttpClient()
        {
            MaxResponseContentBufferSize = MaxResponseContentBufferSize,
            Timeout = timeout,
        };

        return GetAzureVmMetaData(httpClient, cts.Token);
    }

    public static AzureVmMetadataResponse? GetAzureVmMetaData(
        HttpClient client,
        CancellationToken cancellationToken)
    {
        using var httpRequestMessage = new HttpRequestMessage();

        httpRequestMessage.RequestUri = AzureVmMetadataEndpointUri;
        httpRequestMessage.Method = HttpMethod.Get;
        httpRequestMessage.Headers.Add("Metadata", "True");

        // The whole response is buffered while the request is sent so that the timeout and the cancellation token also
        // cover reading the body. With ResponseHeadersRead they stop applying once the headers have been received, and
        // an endpoint that then stalls would block the caller (and so the construction of the provider) indefinitely.
#if NET
        using var response = client.Send(httpRequestMessage, HttpCompletionOption.ResponseContentRead, cancellationToken);
#else
#pragma warning disable CA2025 // Do not pass 'IDisposable' instances into unawaited tasks
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
        using var response = client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
#pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
#pragma warning restore CA2025 // Do not pass 'IDisposable' instances into unawaited tasks
#endif

        response.EnsureSuccessStatusCode();

        var result = HttpClientHelpers.GetResponseBodyAsString(response, cancellationToken);

        if (!string.IsNullOrEmpty(result))
        {
#if NET
            return JsonSerializer.Deserialize(result, SourceGenerationContext.Default.AzureVmMetadataResponse);
#else
            return JsonSerializer.Deserialize<AzureVmMetadataResponse>(result!);
#endif
        }

        return null;
    }
}
