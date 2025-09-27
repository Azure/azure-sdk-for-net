// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading;
using Azure.AI.OpenAI.Utility;

namespace Azure.AI.OpenAI.Assistants;

[Experimental("OPENAI001")]
internal partial class AzureAssistantClient : AssistantClient
{
    public override AsyncCollectionResult<Assistant> GetAssistantsAsync(AssistantCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        return new AzureAsyncCollectionResult<Assistant, AssistantCollectionPageToken>(
            Pipeline,
            continuation => CreateGetAssistantsRequest(options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, continuation?.Before ?? options?.BeforeId, cancellationToken.ToRequestOptions()),
            page => AssistantCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
            page => ModelReaderWriter.Read<InternalListAssistantsResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
    }

    public override CollectionResult<Assistant> GetAssistants(AssistantCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        return new AzureCollectionResult<Assistant, AssistantCollectionPageToken>(
            Pipeline,
            continuation => CreateGetAssistantsRequest(options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, continuation?.Before ?? options?.BeforeId, cancellationToken.ToRequestOptions()),
            page => AssistantCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
            page => ModelReaderWriter.Read<InternalListAssistantsResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
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

    /// <inheritdoc />
    public override AsyncCollectionResult<ThreadMessage> GetMessagesAsync(string threadId, MessageCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        return new AzureAsyncCollectionResult<ThreadMessage, AssistantCollectionPageToken>(
            Pipeline,
            continuation => CreateGetMessagesRequest(threadId, options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, continuation?.Before ?? options?.BeforeId, cancellationToken.ToRequestOptions()),
            page => AssistantCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
            page => ModelReaderWriter.Read<InternalListMessagesResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
    }

    public override CollectionResult<ThreadMessage> GetMessages(string threadId, MessageCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        return new AzureCollectionResult<ThreadMessage, AssistantCollectionPageToken>(
           Pipeline,
           continuation => CreateGetMessagesRequest(threadId, options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, continuation?.Before ?? options?.BeforeId, cancellationToken.ToRequestOptions()),
           page => AssistantCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
           page => ModelReaderWriter.Read<InternalListMessagesResponse>(page.GetRawResponse().Content).Data,
           cancellationToken);
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

    public override AsyncCollectionResult<ThreadRun> GetRunsAsync(string threadId, RunCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        return new AzureAsyncCollectionResult<ThreadRun, AssistantCollectionPageToken>(
            Pipeline,
            continuation => CreateGetRunsRequest(threadId, options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, continuation?.Before ?? options?.BeforeId, cancellationToken.ToRequestOptions()),
            page => AssistantCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
            page => ModelReaderWriter.Read<InternalListRunsResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
    }

    public override CollectionResult<ThreadRun> GetRuns(string threadId, RunCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        return new AzureCollectionResult<ThreadRun, AssistantCollectionPageToken>(
            Pipeline,
            continuation => CreateGetRunsRequest(threadId, options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, continuation?.Before ?? options?.BeforeId, cancellationToken.ToRequestOptions()),
            page => AssistantCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
            page => ModelReaderWriter.Read<InternalListRunsResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
    }

    public override async Task<ClientResult> GetRunAsync(string threadId, string runId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        using PipelineMessage message = CreateGetRunRequest(threadId, runId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

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

    public override AsyncCollectionResult<RunStep> GetRunStepsAsync(string threadId, string runId, RunStepCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        return new AzureAsyncCollectionResult<RunStep, AssistantCollectionPageToken>(
            Pipeline,
            continuation => CreateGetRunStepsRequest(threadId, runId, options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, continuation?.Before ?? options?.BeforeId, cancellationToken.ToRequestOptions()),
            page => AssistantCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
            page => ModelReaderWriter.Read<InternalListRunStepsResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
    }

    public override CollectionResult<RunStep> GetRunSteps(string threadId, string runId, RunStepCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        return new AzureCollectionResult<RunStep, AssistantCollectionPageToken>(
            Pipeline,
            continuation => CreateGetRunStepsRequest(threadId, runId, options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, continuation?.Before ?? options?.BeforeId, cancellationToken.ToRequestOptions()),
            page => AssistantCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
            page => ModelReaderWriter.Read<InternalListRunStepsResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
    }

    public override async Task<ClientResult> GetRunStepAsync(string threadId, string runId, string stepId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));
        Argument.AssertNotNullOrEmpty(stepId, nameof(stepId));

        using PipelineMessage message = CreateGetRunStepRequest(threadId, runId, stepId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

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

    internal override PipelineMessage CreateCreateAssistantRequest(BinaryContent content, RequestOptions options = null)
        => NewJsonPostBuilder(content, options).WithPath("assistants").Build();

    internal override PipelineMessage CreateGetAssistantsRequest(int? limit, string order, string after, string before, RequestOptions options)
        => NewGetListBuilder(limit, order, after, before, options).WithPath("assistants").Build();

    internal override PipelineMessage CreateGetAssistantRequest(string assistantId, RequestOptions options)
        => NewJsonGetBuilder(options).WithPath("assistants", assistantId).Build();

    internal override PipelineMessage CreateModifyAssistantRequest(string assistantId, BinaryContent content, RequestOptions options)
        => NewJsonPostBuilder(content, options).WithPath("assistants", assistantId).Build();

    internal override PipelineMessage CreateDeleteAssistantRequest(string assistantId, RequestOptions options)
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
            .WithAssistantsHeader()
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
        .WithCommonListParameters(limit, order, after, before);

    private class AssistantCollectionPageToken : ContinuationToken
    {
        protected AssistantCollectionPageToken(int? limit, string order, string after, string before)
        {
            Limit = limit;
            Order = order;
            After = after;
            Before = before;
        }

        public int? Limit { get; }

        public string Order { get; }

        public string After { get; }

        public string Before { get; }

        public override BinaryData ToBytes()
        {
            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);

            writer.WriteStartObject();

            if (Limit.HasValue)
            {
                writer.WriteNumber("limit", Limit.Value);
            }

            if (Order is not null)
            {
                writer.WriteString("order", Order);
            }

            if (After is not null)
            {
                writer.WriteString("after", After);
            }

            if (Before is not null)
            {
                writer.WriteString("before", Before);
            }

            writer.WriteEndObject();

            writer.Flush();
            stream.Position = 0;

            return BinaryData.FromStream(stream);
        }

        public static AssistantCollectionPageToken FromToken(ContinuationToken token)
        {
            if (token is AssistantCollectionPageToken pageToken)
            {
                return pageToken;
            }

            BinaryData data = token.ToBytes();

            if (data.ToMemory().Length == 0)
            {
                throw new ArgumentException("Failed to create AssistantsPageToken from provided pageToken.", nameof(pageToken));
            }

            Utf8JsonReader reader = new(data);

            int? limit = null;
            string order = null;
            string after = null;
            string before = null;

            reader.Read();

            Debug.Assert(reader.TokenType == JsonTokenType.StartObject);

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }

                Debug.Assert(reader.TokenType == JsonTokenType.PropertyName);

                string propertyName = reader.GetString()!;

                switch (propertyName)
                {
                    case "limit":
                        reader.Read();
                        Debug.Assert(reader.TokenType == JsonTokenType.Number);
                        limit = reader.GetInt32();
                        break;
                    case "order":
                        reader.Read();
                        Debug.Assert(reader.TokenType == JsonTokenType.String);
                        order = reader.GetString();
                        break;
                    case "after":
                        reader.Read();
                        Debug.Assert(reader.TokenType == JsonTokenType.String);
                        after = reader.GetString();
                        break;
                    case "before":
                        reader.Read();
                        Debug.Assert(reader.TokenType == JsonTokenType.String);
                        before = reader.GetString();
                        break;
                    default:
                        throw new JsonException($"Unrecognized property '{propertyName}'.");
                }
            }

            return new(limit, order, after, before);
        }

        public static AssistantCollectionPageToken FromOptions(int? limit, string order, string after, string before)
            => new AssistantCollectionPageToken(limit, order, after, before);

        public static AssistantCollectionPageToken FromResponse(ClientResult result, int? limit, string order, string before)
        {
            PipelineResponse response = result.GetRawResponse();
            using JsonDocument doc = JsonDocument.Parse(response.Content);
            string lastId = doc.RootElement.GetProperty("last_id"u8).GetString()!;
            bool hasMore = doc.RootElement.GetProperty("has_more"u8).GetBoolean();

            if (!hasMore || lastId is null)
            {
                return null;
            }

            return new(limit, order, lastId, before);
        }
    }
}

#endif
