// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.AppService;

/// <summary>
/// Scale and concurrency settings for the function app.
/// </summary>
public partial class FunctionAppScaleAndConcurrency : ProvisionableConstruct
{
    /// <summary>
    /// The maximum number of instances for the function app.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<float> MaximumInstanceCount
    {
        get { Initialize(); return _maximumInstanceCount!; }
        set { Initialize(); _maximumInstanceCount!.Assign(value); }
    }
    private BicepValue<float>? _maximumInstanceCount;

    /// <summary>
    /// Set the amount of memory allocated to each instance of the function app
    /// in MB. CPU and network bandwidth are allocated proportionally.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<float> InstanceMemoryMB
    {
        get { Initialize(); return _instanceMemoryMB!; }
        set { Initialize(); _instanceMemoryMB!.Assign(value); }
    }
    private BicepValue<float>? _instanceMemoryMB;

    /// <summary>
    /// The maximum number of concurrent HTTP trigger invocations per instance.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<float> HttpPerInstanceConcurrency
    {
        get { Initialize(); return _httpPerInstanceConcurrency!; }
        set { Initialize(); _httpPerInstanceConcurrency!.Assign(value); }
    }
    private BicepValue<float>? _httpPerInstanceConcurrency;
}
