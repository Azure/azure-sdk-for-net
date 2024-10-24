// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Projects
{
    /// <summary> The Agents sub-client. </summary>
    [CodeGenClient("Agents")]
    public partial class AgentClient
    {
        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="connectionString">The Azure AI Studio project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> </exception>
        public AgentClient(string connectionString, TokenCredential credential) : this(connectionString, credential, new AIProjectClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of AzureAIClient.
        /// </summary>
        /// <param name="connectionString">The Azure AI Studio project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> is an empty string. </exception>
        public AgentClient(string connectionString, TokenCredential credential, AIProjectClientOptions options)
             : this(new Uri(ClientHelper.ParseConnectionString(connectionString, "endpoint")),
                  ClientHelper.ParseConnectionString(connectionString, "subscriptionId"),
                  ClientHelper.ParseConnectionString(connectionString, "resourceGroupName"),
                  ClientHelper.ParseConnectionString(connectionString, "projectName"),
                  credential,
                  options)
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Studio project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Studio project name. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="projectName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public AgentClient(Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, TokenCredential credential) : this(endpoint, subscriptionId, resourceGroupName, projectName, credential, new AIProjectClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Studio project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Studio project name. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="projectName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public AgentClient(Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, TokenCredential credential, AIProjectClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AIProjectClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _projectName = projectName;
            _apiVersion = options.Version;
        }

        /*
        * CUSTOM CODE DESCRIPTION:
        *
        * These convenience helpers bring additive capabilities to address client methods more ergonomically:
        *  - Use response value instances of types like AgentThread and ThreadRun instead of raw IDs from those instances
        *     a la thread.Id and run.Id.
        *  - Allow direct file-path-based file upload (with inferred filename parameter placement) in lieu of requiring
        *     manual I/O prior to getting a byte array
        */

        /// <summary>
        /// Creates a new run of the specified thread using a specified agent.
        /// </summary>
        /// <remarks>
        /// This method will create the run with default configuration.
        /// </remarks>
        /// <param name="thread"> The thread that should be run. </param>
        /// <param name="agent"> The agent that should run the thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A new <see cref="ThreadRun"/> instance. </returns>
        public virtual Response<ThreadRun> CreateRun(AgentThread thread, Agent agent, CancellationToken cancellationToken = default)
            => CreateRun(thread.Id, agent.Id, null, null, null, null, null, null, null, null, null, null, null, null, null, null, cancellationToken);

        /// <summary>
        /// Creates a new run of the specified thread using a specified agent.
        /// </summary>
        /// <remarks>
        /// This method will create the run with default configuration.
        /// </remarks>
        /// <param name="thread"> The thread that should be run. </param>
        /// <param name="agent"> The agent that should run the thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A new <see cref="ThreadRun"/> instance. </returns>
        public virtual Task<Response<ThreadRun>> CreateRunAsync(AgentThread thread, Agent agent, CancellationToken cancellationToken = default)
             => CreateRunAsync(thread.Id, agent.Id, null, null, null, null, null, null, null, null, null, null, null, null, null, null, cancellationToken);

        /// <summary>
        /// Begins a new streaming <see cref="ThreadRun"/> that evaluates a <see cref="AgentThread"/> using a specified
        /// <see cref="Agent"/>.
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="assistantId"> The ID of the agent that should run the thread. </param>
        /// <param name="overrideModelName"> The overridden model name that the agent should use to run the thread. </param>
        /// <param name="overrideInstructions"> The overridden system instructions that the agent should use to run the thread. </param>
        /// <param name="additionalInstructions">
        /// Additional instructions to append at the end of the instructions for the run. This is useful for modifying the behavior
        /// on a per-run basis without overriding other instructions.
        /// </param>
        /// <param name="additionalMessages"> Adds additional messages to the thread before creating the run. </param>
        /// <param name="overrideTools"> The overridden list of enabled tools that the agent should use to run the thread. </param>
        /// <param name="temperature">
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </param>
        /// <param name="topP">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model
        /// considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens
        /// comprising the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or temperature but not both.
        /// </param>
        /// <param name="maxPromptTokens">
        /// The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only
        /// the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified,
        /// the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="maxCompletionTokens">
        /// The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort
        /// to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of
        /// completion tokens specified, the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="truncationStrategy"> The strategy to use for dropping messages as the context windows moves forward. </param>
        /// <param name="toolChoice"> Controls whether or not and which tool is called by the model. </param>
        /// <param name="responseFormat"> Specifies the format that the model must output. </param>
        /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="assistantId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual AsyncCollectionResult<StreamingUpdate> CreateRunStreamingAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, IEnumerable<ThreadMessage> additionalMessages = null, IEnumerable<ToolDefinition> overrideTools = null, float? temperature = null, float? topP = null, int? maxPromptTokens = null, int? maxCompletionTokens = null, TruncationObject truncationStrategy = null, BinaryData toolChoice = null, BinaryData responseFormat = null, IReadOnlyDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(assistantId, nameof(assistantId));

            CreateRunRequest createRunRequest = new CreateRunRequest(
                assistantId,
                overrideModelName,
                overrideInstructions,
                additionalInstructions,
                additionalMessages?.ToList() as IReadOnlyList<ThreadMessage> ?? new ChangeTrackingList<ThreadMessage>(),
                overrideTools?.ToList() as IReadOnlyList<ToolDefinition> ?? new ChangeTrackingList<ToolDefinition>(),
                stream: true,
                temperature,
                topP,
                maxPromptTokens,
                maxCompletionTokens,
                truncationStrategy,
                toolChoice,
                responseFormat,
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                null);
            RequestContext context = FromCancellationToken(cancellationToken);

            async Task<Response> sendRequestAsync() =>
                await CreateRunAsync(threadId, createRunRequest.ToRequestContent(), context).ConfigureAwait(false);

            return new AsyncStreamingUpdateCollection(sendRequestAsync, cancellationToken);
        }

        /// <summary>
        /// Begins a new streaming <see cref="ThreadRun"/> that evaluates a <see cref="AgentThread"/> using a specified
        /// <see cref="Agent"/>.
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="assistantId"> The ID of the agent that should run the thread. </param>
        /// <param name="overrideModelName"> The overridden model name that the agent should use to run the thread. </param>
        /// <param name="overrideInstructions"> The overridden system instructions that the agent should use to run the thread. </param>
        /// <param name="additionalInstructions">
        /// Additional instructions to append at the end of the instructions for the run. This is useful for modifying the behavior
        /// on a per-run basis without overriding other instructions.
        /// </param>
        /// <param name="additionalMessages"> Adds additional messages to the thread before creating the run. </param>
        /// <param name="overrideTools"> The overridden list of enabled tools that the agent should use to run the thread. </param>
        /// <param name="temperature">
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </param>
        /// <param name="topP">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model
        /// considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens
        /// comprising the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or temperature but not both.
        /// </param>
        /// <param name="maxPromptTokens">
        /// The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only
        /// the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified,
        /// the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="maxCompletionTokens">
        /// The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort
        /// to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of
        /// completion tokens specified, the run will end with status `incomplete`. See `incomplete_details` for more info.
        /// </param>
        /// <param name="truncationStrategy"> The strategy to use for dropping messages as the context windows moves forward. </param>
        /// <param name="toolChoice"> Controls whether or not and which tool is called by the model. </param>
        /// <param name="responseFormat"> Specifies the format that the model must output. </param>
        /// <param name="metadata"> A set of up to 16 key/value pairs that can be attached to an object, used for storing additional information about that object in a structured format. Keys may be up to 64 characters in length and values may be up to 512 characters in length. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="assistantId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual CollectionResult<StreamingUpdate> CreateRunStreaming(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, IEnumerable<ThreadMessage> additionalMessages = null, IEnumerable<ToolDefinition> overrideTools = null, float? temperature = null, float? topP = null, int? maxPromptTokens = null, int? maxCompletionTokens = null, TruncationObject truncationStrategy = null, BinaryData toolChoice = null, BinaryData responseFormat = null, IReadOnlyDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
#pragma warning restore AZC0015 // Unexpected client method return type.
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(assistantId, nameof(assistantId));

            CreateRunRequest createRunRequest = new CreateRunRequest(
                assistantId,
                overrideModelName,
                overrideInstructions,
                additionalInstructions,
                additionalMessages?.ToList() as IReadOnlyList<ThreadMessage> ?? new ChangeTrackingList<ThreadMessage>(),
                overrideTools?.ToList() as IReadOnlyList<ToolDefinition> ?? new ChangeTrackingList<ToolDefinition>(),
                stream: true,
                temperature,
                topP,
                maxPromptTokens,
                maxCompletionTokens,
                truncationStrategy,
                toolChoice,
                responseFormat,
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                null);
            RequestContext context = FromCancellationToken(cancellationToken);

            Response sendRequest() => CreateRun(threadId, createRunRequest.ToRequestContent(), context);
            return new StreamingUpdateCollection(sendRequest, cancellationToken);
        }

        /// <summary> Returns a list of run steps associated an agent thread run. </summary>
        /// <param name="run"> The <see cref="ThreadRun"/> instance from which run steps should be listed. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
        public virtual Response<PageableList<RunStep>> GetRunSteps(
            ThreadRun run,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(run, nameof(run));
            return GetRunSteps(run.ThreadId, run.Id, limit, order, after, before, cancellationToken);
        }

        /// <summary> Returns a list of run steps associated an agent thread run. </summary>
        /// <param name="run"> The <see cref="ThreadRun"/> instance from which run steps should be listed. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
        public virtual Task<Response<PageableList<RunStep>>> GetRunStepsAsync(
            ThreadRun run,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(run, nameof(run));
            return GetRunStepsAsync(run.ThreadId, run.Id, limit, order, after, before, cancellationToken);
        }

        /// <summary> Submits outputs from tool calls as requested by a run with a status of 'requires_action' with required_action.type of 'submit_tool_outputs'. </summary>
        /// <param name="run"> The <see cref="ThreadRun"/> that the tool outputs should be submitted to. </param>
        /// <param name="toolOutputs"> The list of tool call outputs to provide as part of an output submission to an agent thread run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
        public virtual Response<ThreadRun> SubmitToolOutputsToRun(ThreadRun run, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(run, nameof(run));
            return SubmitToolOutputsToRun(run.ThreadId, run.Id, toolOutputs, null, cancellationToken);
        }

        /// <summary> Submits outputs from tool calls as requested by a run with a status of 'requires_action' with required_action.type of 'submit_tool_outputs'. </summary>
        /// <param name="run"> The <see cref="ThreadRun"/> that the tool outputs should be submitted to. </param>
        /// <param name="toolOutputs"> The list of tool call outputs to provide as part of an output submission to an agent thread run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
        public virtual Task<Response<ThreadRun>> SubmitToolOutputsToRunAsync(ThreadRun run, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(run, nameof(run));
            return SubmitToolOutputsToRunAsync(run.ThreadId, run.Id, toolOutputs, null, cancellationToken);
        }

        /// <summary>
        /// Uploads a file from a local file path accessible to <see cref="System.IO.File"/>.
        /// </summary>
        /// <param name="filePath"> The local file path. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<OpenAIFile> UploadFile(
            string filePath,
            OpenAIFilePurpose purpose,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

            using FileStream stream = File.OpenRead(filePath);
            return UploadFile(stream, purpose, filePath, cancellationToken);
        }

        /// <summary>
        /// Uploads a file from a local file path accessible to <see cref="System.IO.File"/>.
        /// </summary>
        /// <param name="filePath"> The local file path. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<OpenAIFile>> UploadFileAsync(
            string filePath,
            OpenAIFilePurpose purpose,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

            using FileStream stream = File.OpenRead(filePath);
            return await UploadFileAsync(stream, purpose, filePath, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="data"> The file data, in bytes. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. Use `assistants` for Agents and Message files, `vision` for Agents image file inputs, `batch` for Batch API, and `fine-tune` for Fine-tuning. </param>
        /// <param name="filename"> The name of the file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<OpenAIFile>> UploadFileAsync(Stream data, OpenAIFilePurpose purpose, string filename, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));

            UploadFileRequest uploadFileRequest = new UploadFileRequest(data, purpose, filename, null);
            using MultipartFormDataRequestContent content = uploadFileRequest.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UploadFileAsync(content, content.ContentType, context).ConfigureAwait(false);
            return Response.FromValue(OpenAIFile.FromResponse(response), response);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="data"> The file data, in bytes. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. Use `assistants` for Agents and Message files, `vision` for Agents image file inputs, `batch` for Batch API, and `fine-tune` for Fine-tuning. </param>
        /// <param name="filename"> The name of the file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<OpenAIFile> UploadFile(Stream data, OpenAIFilePurpose purpose, string filename, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));

            UploadFileRequest uploadFileRequest = new UploadFileRequest(data, purpose, filename, null);
            using MultipartFormDataRequestContent content = uploadFileRequest.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UploadFile(content, content.ContentType, context);
            return Response.FromValue(OpenAIFile.FromResponse(response), response);
        }

        /*
         * CUSTOM CODE DESCRIPTION:
         *
         * Generated methods that return trivial response value types (e.g. "DeletionStatus" that has nothing but a
         * "Deleted" property) are shimmed to directly use the underlying data as their response value type.
         *
         */

        /// <summary> Deletes an agent. </summary>
        /// <param name="agentId"> The ID of the agent to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> DeleteAgent(string agentId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.DeleteAgent");
            scope.Start();
            Response<InternalAgentDeletionStatus> baseResponse = InternalDeleteAgent(agentId, cancellationToken);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Deletes an agent. </summary>
        /// <param name="agentId"> The ID of the agent to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> DeleteAgentAsync(
            string agentId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.DeleteAgent");
            scope.Start();
            Response<InternalAgentDeletionStatus> baseResponse
                = await InternalDeleteAgentAsync(agentId, cancellationToken).ConfigureAwait(false);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Deletes a thread. </summary>
        /// <param name="threadId"> The ID of the thread to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> DeleteThread(
            string threadId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.DeleteThread");
            scope.Start();
            Response<ThreadDeletionStatus> baseResponse
                = InternalDeleteThread(threadId, cancellationToken);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Deletes a thread. </summary>
        /// <param name="threadId"> The ID of the thread to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> DeleteThreadAsync(
            string threadId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.DeleteThread");
            scope.Start();
            Response<ThreadDeletionStatus> baseResponse
                = await InternalDeleteThreadAsync(threadId, cancellationToken).ConfigureAwait(false);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <param name="purpose"> Limits files in the response to those with the specified purpose. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<OpenAIFile>> GetFiles(OpenAIFilePurpose? purpose = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetFiles");
            scope.Start();
            Response<InternalFileListResponse> baseResponse = InternalListFiles(purpose, cancellationToken);
            return Response.FromValue(baseResponse.Value?.Data, baseResponse.GetRawResponse());
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <param name="purpose"> Limits files in the response to those with the specified purpose. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<OpenAIFile>>> GetFilesAsync(
            OpenAIFilePurpose? purpose = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetFiles");
            scope.Start();
            Response<InternalFileListResponse> baseResponse = await InternalListFilesAsync(purpose, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(baseResponse.Value?.Data, baseResponse.GetRawResponse());
        }

        /// <summary> Delete a previously uploaded file. </summary>
        /// <param name="fileId"> The ID of the file to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> DeleteFile(string fileId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.DeleteFile");
            scope.Start();
            Response<InternalFileDeletionStatus> baseResponse = InternalDeleteFile(fileId, cancellationToken);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Delete a previously uploaded file. </summary>
        /// <param name="fileId"> The ID of the file to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> DeleteFileAsync(string fileId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.DeleteFile");
            scope.Start();
            Response<InternalFileDeletionStatus> baseResponse = await InternalDeleteFileAsync(fileId, cancellationToken).ConfigureAwait(false);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetAgents(int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual Response<PageableList<Agent>> GetAgents(
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetAgents");
            scope.Start();
            Response<InternalOpenAIPageableListOfAgent> baseResponse = InternalGetAgents(limit, order, after, before, cancellationToken);
            return Response.FromValue(PageableList<Agent>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetAgentsAsync(int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual async Task<Response<PageableList<Agent>>> GetAgentsAsync(
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetAgents");
            scope.Start();
            Response<InternalOpenAIPageableListOfAgent> baseResponse
                = await InternalGetAgentsAsync(limit, order, after, before, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(PageableList<Agent>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetRunSteps(string, string, int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual Response<PageableList<RunStep>> GetRunSteps(
            string threadId,
            string runId,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetRunSteps");
            scope.Start();
            Response<InternalOpenAIPageableListOfRunStep> baseResponse = InternalGetRunSteps(threadId, runId, limit, order, after, before, cancellationToken);
            return Response.FromValue(PageableList<RunStep>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetRunStepsAsync(string, string, int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual async Task<Response<PageableList<RunStep>>> GetRunStepsAsync(
            string threadId,
            string runId,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetRunSteps");
            scope.Start();
            Response<InternalOpenAIPageableListOfRunStep> baseResponse
                = await InternalGetRunStepsAsync(threadId, runId, limit, order, after, before, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(PageableList<RunStep>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetMessages(string, string, int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual Response<PageableList<ThreadMessage>> GetMessages(
            string threadId,
            string runId = null,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetMessages");
            scope.Start();
            Response<InternalOpenAIPageableListOfThreadMessage> baseResponse = InternalGetMessages(threadId, runId, limit, order, after, before, cancellationToken);
            return Response.FromValue(PageableList<ThreadMessage>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetMessagesAsync(string, string, int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual async Task<Response<PageableList<ThreadMessage>>> GetMessagesAsync(
            string threadId,
            string runId = null,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetMessages");
            scope.Start();
            Response<InternalOpenAIPageableListOfThreadMessage> baseResponse
                = await InternalGetMessagesAsync(threadId, runId, limit, order, after, before, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(PageableList<ThreadMessage>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetRuns(string, int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual Response<PageableList<ThreadRun>> GetRuns(
            string threadId,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetRuns");
            scope.Start();
            Response<InternalOpenAIPageableListOfThreadRun> baseResponse = InternalGetRuns(threadId, limit, order, after, before, cancellationToken);
            return Response.FromValue(PageableList<ThreadRun>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetRunsAsync(string, int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual async Task<Response<PageableList<ThreadRun>>> GetRunsAsync(
            string threadId,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetRuns");
            scope.Start();
            Response<InternalOpenAIPageableListOfThreadRun> baseResponse
                = await InternalGetRunsAsync(threadId, limit, order, after, before, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(PageableList<ThreadRun>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }
    }
}
