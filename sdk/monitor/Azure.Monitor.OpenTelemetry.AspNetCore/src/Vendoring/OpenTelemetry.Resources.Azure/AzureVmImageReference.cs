// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json.Serialization;

namespace OpenTelemetry.Resources.Azure;

internal sealed class AzureVmImageReference
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("offer")]
    public string? Offer { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }
}
