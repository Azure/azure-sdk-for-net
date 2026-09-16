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
    // Preserve the previous public name because the generated "Triggers" prefix exposes the nested wire-model structure.
    /// <summary>
    /// The maximum number of concurrent HTTP trigger invocations per instance.
    /// </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("TriggersConcurrentHttpPerInstanceConcurrency")]
    public BicepValue<int> ConcurrentHttpPerInstanceConcurrency
    {
        get
        {
            return Triggers is null ? default! : Triggers.ConcurrentHttpPerInstanceConcurrency;
        }
        set
        {
            if (Triggers is null)
            {
                Triggers = new FunctionsScaleAndConcurrencyTriggers();
            }
            Triggers.ConcurrentHttpPerInstanceConcurrency = value;
        }
    }

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

    partial void DefineAdditionalProperties()
    {
        _maximumInstanceCount = DefineProperty<float>(nameof(MaximumInstanceCount), new string[] { "maximumInstanceCount" });
        _instanceMemoryMB = DefineProperty<float>(nameof(InstanceMemoryMB), new string[] { "instanceMemoryMB" });
        _httpPerInstanceConcurrency = DefineProperty<float>(nameof(HttpPerInstanceConcurrency), new string[] { "triggers", "http", "perInstanceConcurrency" });
    }
}
