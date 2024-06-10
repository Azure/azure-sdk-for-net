﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using OpenAI.Assistants;
using System.ClientModel.Primitives;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Azure.AI.OpenAI.Assistants;

[Experimental("OPENAI001")]
internal partial class AzureAssistantClient : AssistantClient
{
    public override async Task<ClientResult> CreateAssistantAsync(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateAssistantRequest(content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CreateAssistant(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateAssistantRequest(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetAssistantsAsync(int? limit, string order, string after, string before, RequestOptions options)
    {
        using PipelineMessage message = CreateGetAssistantsRequest(limit, order, after, before, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetAssistants(int? limit, string order, string after, string before, RequestOptions options)
    {
        using PipelineMessage message = CreateGetAssistantsRequest(limit, order, after, before, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetAssistantAsync(string assistantId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));

        using PipelineMessage message = CreateGetAssistantRequest(assistantId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetAssistant(string assistantId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));

        using PipelineMessage message = CreateGetAssistantRequest(assistantId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> ModifyAssistantAsync(string assistantId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateModifyAssistantRequest(assistantId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult ModifyAssistant(string assistantId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateModifyAssistantRequest(assistantId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> DeleteAssistantAsync(string assistantId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));

        using PipelineMessage message = CreateDeleteAssistantRequest(assistantId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult DeleteAssistant(string assistantId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(assistantId, nameof(assistantId));

        using PipelineMessage message = CreateDeleteAssistantRequest(assistantId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.CreateMessageAsync"/>
    public override async Task<ClientResult> CreateMessageAsync(string threadId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateCreateMessageRequest(threadId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.CreateMessage"/>
    public override ClientResult CreateMessage(string threadId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateCreateMessageRequest(threadId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.GetMessagesAsync"/>
    public override async Task<ClientResult> GetMessagesAsync(string threadId, int? limit, string order, string after, string before, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetMessagesRequest(threadId, limit, order, after, before, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.GetMessages"/>
    public override ClientResult GetMessages(string threadId, int? limit, string order, string after, string before, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetMessagesRequest(threadId, limit, order, after, before, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.GetMessageAsync"/>
    public override async Task<ClientResult> GetMessageAsync(string threadId, string messageId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetMessageRequest(threadId, messageId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.GetMessage"/>
    public override ClientResult GetMessage(string threadId, string messageId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetMessageRequest(threadId, messageId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.ModifyMessageAsync"/>
    public override async Task<ClientResult> ModifyMessageAsync(string threadId, string messageId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));

        using PipelineMessage message = CreateModifyMessageRequest(threadId, messageId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.ModifyMessage"/>
    public override ClientResult ModifyMessage(string threadId, string messageId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));

        using PipelineMessage message = CreateModifyMessageRequest(threadId, messageId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.DeleteMessageAsync"/>
    public override async Task<ClientResult> DeleteMessageAsync(string threadId, string messageId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));

        using PipelineMessage message = CreateDeleteMessageRequest(threadId, messageId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantMessageClient.DeleteMessage"/>
    public override ClientResult DeleteMessage(string threadId, string messageId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(messageId, nameof(messageId));

        using PipelineMessage message = CreateDeleteMessageRequest(threadId, messageId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.CreateThreadAndRunAsync"/>
    public override async Task<ClientResult> CreateThreadAndRunAsync(BinaryContent content, RequestOptions options = null)
    {
        PipelineMessage message = null;
        try
        {
            message = CreateCreateThreadAndRunRequest(content, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }
        finally
        {
            if (options?.BufferResponse != false)
            {
                message.Dispose();
            }
        }
    }

    /// <inheritdoc cref="InternalAssistantRunClient.CreateThreadAndRun"/>
    public override ClientResult CreateThreadAndRun(BinaryContent content, RequestOptions options = null)
    {
        PipelineMessage message = null;
        try
        {
            message = CreateCreateThreadAndRunRequest(content, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }
        finally
        {
            if (options?.BufferResponse != false)
            {
                message.Dispose();
            }
        }
    }

    /// <inheritdoc cref="InternalAssistantRunClient.CreateRunAsync"/>
    public override async Task<ClientResult> CreateRunAsync(string threadId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        PipelineMessage message = null;
        try
        {
            message = CreateCreateRunRequest(threadId, content, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }
        finally
        {
            if (options?.BufferResponse != false)
            {
                message.Dispose();
            }
        }
    }

    /// <inheritdoc cref="InternalAssistantRunClient.CreateRun"/>
    public override ClientResult CreateRun(string threadId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        PipelineMessage message = null;
        try
        {
            message = CreateCreateRunRequest(threadId, content, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }
        finally
        {
            if (options?.BufferResponse != false)
            {
                message.Dispose();
            }
        }
    }

    /// <inheritdoc cref="InternalAssistantRunClient.GetRunsAsync"/>
    public override async Task<ClientResult> GetRunsAsync(string threadId, int? limit, string order, string after, string before, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetRunsRequest(threadId, limit, order, after, before, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.GetRuns"/>
    public override ClientResult GetRuns(string threadId, int? limit, string order, string after, string before, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetRunsRequest(threadId, limit, order, after, before, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.GetRunAsync"/>
    public override async Task<ClientResult> GetRunAsync(string threadId, string runId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        using PipelineMessage message = CreateGetRunRequest(threadId, runId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.GetRun"/>
    public override ClientResult GetRun(string threadId, string runId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        using PipelineMessage message = CreateGetRunRequest(threadId, runId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.ModifyRunAsync"/>
    public override async Task<ClientResult> ModifyRunAsync(string threadId, string runId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        using PipelineMessage message = CreateModifyRunRequest(threadId, runId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.ModifyRun"/>
    public override ClientResult ModifyRun(string threadId, string runId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        using PipelineMessage message = CreateModifyRunRequest(threadId, runId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.CancelRunAsync"/>
    public override async Task<ClientResult> CancelRunAsync(string threadId, string runId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        using PipelineMessage message = CreateCancelRunRequest(threadId, runId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.CancelRun"/>
    public override ClientResult CancelRun(string threadId, string runId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        using PipelineMessage message = CreateCancelRunRequest(threadId, runId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.SubmitToolOutputsToRunAsync"/>
    public override async Task<ClientResult> SubmitToolOutputsToRunAsync(string threadId, string runId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        PipelineMessage message = null;
        try
        {
            message = CreateSubmitToolOutputsToRunRequest(threadId, runId, content, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }
        finally
        {
            if (options?.BufferResponse != false)
            {
                message.Dispose();
            }
        }
    }

    /// <inheritdoc cref="InternalAssistantRunClient.SubmitToolOutputsToRun"/>
    public override ClientResult SubmitToolOutputsToRun(string threadId, string runId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        PipelineMessage message = null;
        try
        {
            message = CreateSubmitToolOutputsToRunRequest(threadId, runId, content, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }
        finally
        {
            if (options?.BufferResponse != false)
            {
                message.Dispose();
            }
        }
    }

    /// <inheritdoc cref="InternalAssistantRunClient.GetRunStepsAsync"/>
    public override async Task<ClientResult> GetRunStepsAsync(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        using PipelineMessage message = CreateGetRunStepsRequest(threadId, runId, limit, order, after, before, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.GetRunSteps"/>
    public override ClientResult GetRunSteps(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        using PipelineMessage message = CreateGetRunStepsRequest(threadId, runId, limit, order, after, before, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.GetRunStepAsync"/>
    public override async Task<ClientResult> GetRunStepAsync(string threadId, string runId, string stepId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));
        Argument.AssertNotNullOrEmpty(stepId, nameof(stepId));

        using PipelineMessage message = CreateGetRunStepRequest(threadId, runId, stepId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantRunClient.GetRunStep"/>
    public override ClientResult GetRunStep(string threadId, string runId, string stepId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));
        Argument.AssertNotNullOrEmpty(stepId, nameof(stepId));

        using PipelineMessage message = CreateGetRunStepRequest(threadId, runId, stepId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantThreadClient.CreateThreadAsync"/>
    public override async Task<ClientResult> CreateThreadAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateCreateThreadRequest(content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantThreadClient.CreateThread"/>
    public override ClientResult CreateThread(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateCreateThreadRequest(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantThreadClient.GetThreadAsync"/>
    public override async Task<ClientResult> GetThreadAsync(string threadId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetThreadRequest(threadId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantThreadClient.GetThread"/>
    public override ClientResult GetThread(string threadId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetThreadRequest(threadId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantThreadClient.ModifyThreadAsync"/>
    public override async Task<ClientResult> ModifyThreadAsync(string threadId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateModifyThreadRequest(threadId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantThreadClient.ModifyThread"/>
    public override ClientResult ModifyThread(string threadId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateModifyThreadRequest(threadId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="InternalAssistantThreadClient.DeleteThreadAsync"/>
    public override async Task<ClientResult> DeleteThreadAsync(string threadId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateDeleteThreadRequest(threadId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <inheritdoc cref="InternalAssistantThreadClient.DeleteThread"/>
    public override ClientResult DeleteThread(string threadId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateDeleteThreadRequest(threadId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    private new PipelineMessage CreateCreateAssistantRequest(BinaryContent content, RequestOptions options = null)
        => NewJsonPostBuilder(content, options).WithPath("assistants").Build();

    private new PipelineMessage CreateGetAssistantsRequest(int? limit, string order, string after, string before, RequestOptions options)
        => NewGetListBuilder(limit, order, after, before, options).WithPath("assistants").Build();

    private new PipelineMessage CreateGetAssistantRequest(string assistantId, RequestOptions options)
        => NewJsonGetBuilder(options).WithPath("assistants", assistantId).Build();

    private new PipelineMessage CreateModifyAssistantRequest(string assistantId, BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("assistants", assistantId).Build();

    private new PipelineMessage CreateDeleteAssistantRequest(string assistantId, RequestOptions options)
        => NewJsonDeleteBuilder(options).WithPath("assistants", assistantId).Build();

    private PipelineMessage CreateCreateThreadRequest(BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("threads").Build();

    private PipelineMessage CreateGetThreadsRequest(int? limit, string order, string after, string before, RequestOptions options)
        => NewGetListBuilder(limit, order, after, before, options).WithPath("threads").Build();

    private PipelineMessage CreateGetThreadRequest(string threadId, RequestOptions options)
        => NewJsonGetBuilder(options).WithPath("threads", threadId).Build();

    private PipelineMessage CreateModifyThreadRequest(string threadId, BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("threads", threadId).Build();

    private PipelineMessage CreateDeleteThreadRequest(string threadId, RequestOptions options)
        => NewJsonDeleteBuilder(options).WithPath("threads", threadId).Build();

    private PipelineMessage CreateCreateMessageRequest(string threadId, BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("threads", threadId, "messages").Build();

    private PipelineMessage CreateGetMessagesRequest(string threadId, int? limit, string order, string after, string before, RequestOptions options)
        => NewGetListBuilder(limit, order, after, before, options).WithPath("threads", threadId, "messages").Build();

    private PipelineMessage CreateGetMessageRequest(string threadId, string messageId, RequestOptions options)
        => NewJsonGetBuilder(options).WithPath("threads", threadId, "messages", messageId).Build();

    private PipelineMessage CreateModifyMessageRequest(string threadId, string messageId, BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("threads", threadId, "messages", messageId).Build();

    private PipelineMessage CreateDeleteMessageRequest(string threadId, string messageId, RequestOptions options)
        => NewJsonDeleteBuilder(options).WithPath("threads", threadId, "messages", messageId).Build();

    private PipelineMessage CreateCreateThreadAndRunRequest(BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("threads", "runs").Build();

    private PipelineMessage CreateCreateRunRequest(string threadId, BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("threads", threadId, "runs").Build();

    private PipelineMessage CreateGetRunsRequest(string threadId, int? limit, string order, string after, string before, RequestOptions options)
        => NewGetListBuilder(limit, order, after, before, options).WithPath("threads", threadId, "runs").Build();

    private PipelineMessage CreateGetRunRequest(string threadId, string runId, RequestOptions options)
        => NewJsonGetBuilder(options).WithPath("threads", threadId, "runs", runId).Build();

    private PipelineMessage CreateModifyRunRequest(string threadId, string runId, BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("threads", threadId, "runs", runId).Build();

    private PipelineMessage CreateCancelRunRequest(string threadId, string runId, RequestOptions options)
        => NewBuilder(options).WithMethod("POST").WithPath("threads", threadId, "runs", runId, "cancel").WithAccept("application/json").Build();

    private PipelineMessage CreateSubmitToolOutputsToRunRequest(string threadId, string runId, BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("threads", threadId, "runs", runId, "submit_tool_outputs").Build();

    private PipelineMessage CreateGetRunStepsRequest(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options)
        => NewGetListBuilder(limit, order, after, before, options).WithPath("threads", threadId, "runs", runId, "steps").Build();

    private PipelineMessage CreateGetRunStepRequest(string threadId, string runId, string stepId, RequestOptions options)
        => NewJsonGetBuilder(options).WithPath("threads", threadId, "runs", runId, "steps", stepId).Build();

    private AzureOpenAIPipelineMessageBuilder NewBuilder(RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithHeader(s_OpenAIBetaFeatureHeader, s_OpenAIBetaAssistantsV2HeaderValue)
            .WithOptions(options);
    private AzureOpenAIPipelineMessageBuilder NewJsonPostBuilder(BinaryContent content, RequestOptions options)
        => NewBuilder(options)
        .WithMethod("POST")
        .WithContent(content, "application/json")
        .WithAccept("application/json");

    private AzureOpenAIPipelineMessageBuilder NewJsonGetBuilder(RequestOptions options)
        => NewBuilder(options)
        .WithMethod("GET")
        .WithAccept("application/json");

    private AzureOpenAIPipelineMessageBuilder NewJsonDeleteBuilder(RequestOptions options)
        => NewBuilder(options)
        .WithMethod("DELETE")
        .WithAccept("application/json");

    private AzureOpenAIPipelineMessageBuilder NewGetListBuilder(int? limit, string order, string after, string before, RequestOptions options)
        => NewJsonGetBuilder(options)
        .WithOptionalQueryParameter("limit", limit)
        .WithOptionalQueryParameter("order", order)
        .WithOptionalQueryParameter("after", after)
        .WithOptionalQueryParameter("before", before);

    private static readonly string s_OpenAIBetaFeatureHeader = "OpenAI-Beta";
    private static readonly string s_OpenAIBetaAssistantsV2HeaderValue = "assistants=v2";
}
