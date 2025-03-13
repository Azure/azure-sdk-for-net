// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;

namespace OpenTelemetry.Resources.Azure;

internal static class AzureVmMetaDataRequestor
{
    private const string AzureVmMetadataEndpointURL = "http://169.254.169.254/metadata/instance/compute?api-version=2021-12-13&format=json";

    public static Func<AzureVmMetadataResponse?> GetAzureVmMetaDataResponse { get; internal set; } = GetAzureVmMetaDataResponseDefault!;

    public static AzureVmMetadataResponse? GetAzureVmMetaDataResponseDefault()
    {
        using var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(2) };

        httpClient.DefaultRequestHeaders.Add("Metadata", "True");
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
        var res = httpClient.GetStringAsync(new Uri(AzureVmMetadataEndpointURL)).ConfigureAwait(false).GetAwaiter().GetResult();
#pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

        if (res != null)
        {
#if NET
            return JsonSerializer.Deserialize(res, SourceGenerationContext.Default.AzureVmMetadataResponse);
#else
            return JsonSerializer.Deserialize<AzureVmMetadataResponse>(res);
#endif
        }

        return null;
    }
}
