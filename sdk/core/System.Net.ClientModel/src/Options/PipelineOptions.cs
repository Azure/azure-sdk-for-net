// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel.Core;

/// <summary>
/// Controls the creation of the pipeline.
/// Works with RequestOptions (TODO: RequestOptions), which controls the behavior of the pipeline.
/// </summary>
public class PipelineOptions
{
    // Note that all properties on PipelineOptions are nullable.
    // This gives us the ability to understand whether a caller passed them
    // as input or whether anything we add/set on PipelineOptions was set
    // internally.  If a property on PipelineOptions has a null value initially,
    // we will set a default value for it when options is frozen.

    public string? ServiceVersion { get; set; }

    public PipelinePolicy[]? PerTryPolicies { get; set; }

    public PipelinePolicy[]? PerCallPolicies { get; set; }

    public PipelinePolicy? RetryPolicy { get; set; }

    public PipelinePolicy? LoggingPolicy { get; set; }

    public PipelineTransport? Transport { get; set; }

    public TimeSpan? NetworkTimeout { get; set; }

    public virtual MessageClassifier? MessageClassifier { get; set; }
}
