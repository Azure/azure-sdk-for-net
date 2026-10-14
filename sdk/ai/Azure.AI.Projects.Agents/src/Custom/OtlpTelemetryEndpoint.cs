// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects.Agents;

public partial class OtlpTelemetryEndpoint
{
    [CodeGenMember("Endpoint")]
    internal string InternalEndpoint { get; set; }

    /// <summary> The OTLP collector endpoint URL. </summary>
    public Uri Endpoint { get => string.IsNullOrEmpty(InternalEndpoint) ? null : new Uri(InternalEndpoint); set => InternalEndpoint = value is null ? null : value.AbsoluteUri; }
}
