// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// The position at which to insert a <see cref="PipelinePolicy"/> into the
/// default <see cref="ClientPipeline"/> policy collection.
/// </summary>
public enum PipelinePosition
{
    /// <summary>
    /// Insert the <see cref="PipelinePolicy"/> before the pipeline's
    /// <see cref="ClientPipelineOptions.RetryPolicy"/>. Policies added to a
    /// pipeline in this position will run once per invocation of
    /// <see cref="ClientPipeline.Send(PipelineMessage)"/>.
    /// </summary>
    PerCall,

    /// <summary>
    /// Insert the <see cref="PipelinePolicy"/> after the pipeline's
    /// <see cref="ClientPipelineOptions.RetryPolicy"/>. Policies added to a
    /// pipeline in this position will run each time the pipeline tries to send
    /// the <see cref="PipelineMessage.Request"/>.
    /// </summary>
    PerTry,

    /// <summary>
    /// Insert the <see cref="PipelinePolicy"/> just before the pipeline's
    /// <see cref="ClientPipelineOptions.Transport"/>. Policies added to a
    /// pipeline in this position will run after all other polices in the
    /// <see cref="ClientPipeline"/> have viewed the
    /// <see cref="PipelineMessage.Request"/> and before they view the
    /// <see cref="PipelineMessage.Response"/>.  Adding policies at this
    /// position should be done with care since changes made to the
    /// <see cref="PipelineMessage.Request"/> by a before-transport policy
    /// will not be visible to any logging policies that come before it in the
    /// pipeline.
    /// </summary>
    BeforeTransport
}
