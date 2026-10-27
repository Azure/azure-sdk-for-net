// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json.Serialization;

namespace OpenTelemetry.Resources.Azure;

internal sealed class AzureVmStorageProfile
{
    [JsonPropertyName("imageReference")]
    public AzureVmImageReference? ImageReference { get; set; }
}
