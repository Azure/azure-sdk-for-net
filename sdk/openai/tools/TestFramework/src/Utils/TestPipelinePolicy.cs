// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// A pipeline policy that raises events before a request sent, and after response has been received.
/// </summary>
public class TestPipelinePolicy() : PipelinePolicy()
{
    /// <summary>
    /// Creates a new instance. This will instantiate the <see cref="BeforeRequest"/> and <see cref="AfterResponse"/>
    /// events based on <paramref name="requestAction"/> and <paramref name="responseAction"/> respectively.
    /// </summary>
    /// <param name="requestAction">(Optional) Action to perform before sending a request.</param>
    /// <param name="responseAction">(Optional) Action to perform after a response is received.</param>
    public TestPipelinePolicy(Action<PipelineRequest>? requestAction, Action<PipelineResponse>? responseAction) : this()
    {
        if (requestAction != null) BeforeRequest += (s, e) => requestAction(e);
        
        if (responseAction != null) AfterResponse += (s, e) => responseAction(e);
    }

    /// <summary>
    /// Event raised before a request is sent.
    /// </summary>
    public event EventHandler<PipelineRequest>? BeforeRequest;

    /// <summary>
    /// Event raised after a response has been received.
    /// </summary>
    public event EventHandler<PipelineResponse>? AfterResponse;

    /// <inheritdoc />
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        BeforeRequest?.Invoke(this, message.Request);
        ProcessNext(message, pipeline, currentIndex);
        if (message.Response != null)
        {
            AfterResponse?.Invoke(this, message.Response);
        }
    }

    /// <inheritdoc />
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        BeforeRequest?.Invoke(this, message.Request);
        await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        if (message.Response != null)
        {
            AfterResponse?.Invoke(this, message.Response);
        }
    }
}
