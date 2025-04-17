// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Text.Json;

namespace Azure.AI.Projects
{
    /// <summary> The Agents sub-client. </summary>
    [CodeGenClient("Agents")]
    public partial class AgentsClient
    {
        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="connectionString">The Azure AI Foundry project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> </exception>
        public AgentsClient(string connectionString, TokenCredential credential) : this(connectionString, credential, new AIProjectClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of AzureAIClient.
        /// </summary>
        /// <param name="connectionString">The Azure AI Foundry project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> is an empty string. </exception>
        public AgentsClient(string connectionString, TokenCredential credential, AIProjectClientOptions options)
             : this(new Uri(ClientHelper.ParseConnectionString(connectionString, "endpoint")),
                  ClientHelper.ParseConnectionString(connectionString, "subscriptionId"),
                  ClientHelper.ParseConnectionString(connectionString, "resourceGroupName"),
                  ClientHelper.ParseConnectionString(connectionString, "projectName"),
                  credential,
                  options)
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Foundry project name. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="projectName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public AgentsClient(Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, TokenCredential credential) : this(endpoint, subscriptionId, resourceGroupName, projectName, credential, new AIProjectClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="endpoint"> The Azure AI Foundry project endpoint, in the form `https://&lt;azure-region&gt;.api.azureml.ms` or `https://&lt;private-link-guid&gt;.&lt;azure-region&gt;.api.azureml.ms`, where &lt;azure-region&gt; is the Azure region where the project is deployed (e.g. westus) and &lt;private-link-guid&gt; is the GUID of the Enterprise private link. </param>
        /// <param name="subscriptionId"> The Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the Azure Resource Group. </param>
        /// <param name="projectName"> The Azure AI Foundry project name. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="projectName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        public AgentsClient(Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, TokenCredential credential, AIProjectClientOptions options)
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
        /// Creates a new message on a specified thread, accepting a simple textual content string.
        /// This API overload matches the original user experience of providing a plain string.
        /// </summary>
        /// <param name="threadId">Identifier of the thread.</param>
        /// <param name="role">
        /// The role of the entity that is creating the message. Allowed values include:
        /// - <c>user</c>: Indicates the message is sent by an actual user.
        /// - <c>assistant</c>: Indicates the message is generated by the agent.
        /// </param>
        /// <param name="content">The plain text content of the message.</param>
        /// <param name="attachments">An optional list of files attached to the message.</param>
        /// <param name="metadata">Optional metadata as key/value pairs.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The newly created <see cref="ThreadMessage"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="threadId"/> or <paramref name="content"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="threadId"/> is empty.</exception>
        public virtual async Task<Response<ThreadMessage>> CreateMessageAsync(
            string threadId,
            MessageRole role,
            string content,
            IEnumerable<MessageAttachment> attachments = null,
            IReadOnlyDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(content, nameof(content));

            // Serialize the plain text into JSON so that the underlying generated code
            // sees a properly quoted/escaped string instead of raw text.
            BinaryData contentJson = BinaryData.FromObjectAsJson(content);

            return await CreateMessageAsync(
                threadId,
                role,
                contentJson,
                attachments,
                metadata,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous variant of <see cref="CreateMessageAsync(string, MessageRole, string, IEnumerable{MessageAttachment}, IReadOnlyDictionary{string, string}, CancellationToken)"/>.
        /// </summary>
        /// <param name="threadId">Identifier of the thread.</param>
        /// <param name="role">
        /// The role of the entity that is creating the message. Allowed values include:
        /// - <c>user</c>: Indicates the message is sent by an actual user.
        /// - <c>assistant</c>: Indicates the message is generated by the agent.
        /// </param>
        /// <param name="content">The plain text content of the message.</param>
        /// <param name="attachments">An optional list of files attached to the message.</param>
        /// <param name="metadata">Optional metadata as key/value pairs.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The newly created <see cref="ThreadMessage"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="threadId"/> or <paramref name="content"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="threadId"/> is empty.</exception>
        public virtual Response<ThreadMessage> CreateMessage(
            string threadId,
            MessageRole role,
            string content,
            IEnumerable<MessageAttachment> attachments = null,
            IReadOnlyDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(content, nameof(content));

            // Serialize the plain text into JSON so that the underlying generated code
            // sees a properly quoted/escaped string instead of raw text.
            BinaryData contentJson = BinaryData.FromObjectAsJson(content);

            // Reuse the existing generated method internally by converting the string to BinaryData.
            return CreateMessage(
                threadId,
                role,
                contentJson,
                attachments,
                metadata,
                cancellationToken
            );
        }

        /// <summary>
        /// Creates a new message on a specified thread using a collection of content blocks,
        /// such as text or image references.
        /// </summary>
        /// <param name="threadId">Identifier of the thread.</param>
        /// <param name="role">
        /// The role of the entity creating the message. For instance:
        /// - <c>MessageRole.User</c>: an actual user message
        /// - <c>MessageRole.Assistant</c>: an agent-generated response
        /// </param>
        /// <param name="contentBlocks">
        /// A collection of specialized content blocks (e.g. <see cref="MessageInputTextBlock"/>,
        /// <see cref="MessageInputImageUrlBlock"/>, <see cref="MessageInputImageFileBlock"/>, etc.).
        /// </param>
        /// <param name="attachments">An optional list of files attached to the message.</param>
        /// <param name="metadata">Optional metadata as key/value pairs.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="ThreadMessage"/> encapsulating the newly created message.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threadId"/> is null or empty, or if <paramref name="contentBlocks"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="threadId"/> is empty.</exception>
        public virtual async Task<Response<ThreadMessage>> CreateMessageAsync(
            string threadId,
            MessageRole role,
            IEnumerable<MessageInputContentBlock> contentBlocks,
            IEnumerable<MessageAttachment> attachments = null,
            IReadOnlyDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(contentBlocks, nameof(contentBlocks));

            // Convert blocks to a JSON array stored as BinaryData
            var jsonElements = new List<JsonElement>();
            foreach (MessageInputContentBlock block in contentBlocks)
            {
                // Write the content into a MemoryStream.
                using var memStream = new MemoryStream();

                // Write the RequestContent into the MemoryStream
                block.ToRequestContent().WriteTo(memStream, default);

                // Reset stream position to the beginning
                memStream.Position = 0;

                // Parse to a JsonDocument, then clone the root element so we can reuse it
                using var tempDoc = JsonDocument.Parse(memStream);
                jsonElements.Add(tempDoc.RootElement.Clone());
            }

            // Now serialize the array of JsonElements into a single BinaryData for the request:
            BinaryData serializedBlocks = BinaryData.FromObjectAsJson(jsonElements);

            return await CreateMessageAsync(
                threadId,
                role,
                serializedBlocks,
                attachments,
                metadata,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous variant of <see cref="CreateMessageAsync(string, MessageRole, IEnumerable{MessageInputContentBlock}, IEnumerable{MessageAttachment}, IReadOnlyDictionary{string, string}, CancellationToken)"/>.
        /// Creates a new message using multiple structured content blocks.
        /// </summary>
        /// <param name="threadId">Identifier of the thread.</param>
        /// <param name="role">
        /// The role of the entity creating the message. For instance:
        /// - <c>MessageRole.User</c>: an actual user message
        /// - <c>MessageRole.Assistant</c>: an agent-generated response.
        /// </param>
        /// <param name="contentBlocks">
        /// A collection of specialized content blocks (e.g. <see cref="MessageInputTextBlock"/>,
        /// <see cref="MessageInputImageUrlBlock"/>, <see cref="MessageInputImageFileBlock"/>, etc.).
        /// </param>
        /// <param name="attachments">An optional list of files attached to the message.</param>
        /// <param name="metadata">Optional metadata as key/value pairs.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="ThreadMessage"/> encapsulating the newly created message.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threadId"/> is null or empty, or if <paramref name="contentBlocks"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="threadId"/> is empty.</exception>
        public virtual Response<ThreadMessage> CreateMessage(
            string threadId,
            MessageRole role,
            IEnumerable<MessageInputContentBlock> contentBlocks,
            IEnumerable<MessageAttachment> attachments = null,
            IReadOnlyDictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNull(contentBlocks, nameof(contentBlocks));

            // Convert blocks to a JSON array stored as BinaryData
            var jsonElements = new List<JsonElement>();
            foreach (MessageInputContentBlock block in contentBlocks)
            {
                // Write the content into a MemoryStream.
                using var memStream = new MemoryStream();

                // Write the RequestContent into the MemoryStream
                block.ToRequestContent().WriteTo(memStream, default);

                // Reset stream position to the beginning
                memStream.Position = 0;

                // Parse to a JsonDocument, then clone the root element so we can reuse it
                using var tempDoc = JsonDocument.Parse(memStream);
                jsonElements.Add(tempDoc.RootElement.Clone());
            }

            // Now serialize the array of JsonElements into a single BinaryData for the request:
            BinaryData serializedBlocks = BinaryData.FromObjectAsJson(jsonElements);

            return CreateMessage(
                threadId,
                role,
                serializedBlocks,
                attachments,
                metadata,
                cancellationToken
            );
        }

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
            => CreateRun(thread.Id, agent.Id, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, cancellationToken);

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
             => CreateRunAsync(thread.Id, agent.Id, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, cancellationToken);

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

        /// <summary> Submits outputs from tools as requested by tool calls in a run. Runs that need submitted tool outputs will have a status of 'requires_action' with a required_action.type of 'submit_tool_outputs'. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="toolOutputs"> A list of tools for which the outputs are being submitted. </param>
        /// <param name="stream"> If true, returns a stream of events that happen during the Run as server-sent events, terminating when the run enters a terminal state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/>, <paramref name="runId"/> or <paramref name="toolOutputs"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> or <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        internal virtual Response SubmitToolOutputsToRun(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, bool? stream = null, CancellationToken cancellationToken = default)
        {
            // We hide this method because setting stream to true will result in streaming response,
            // which cannot be deserialized to ThreadRun.
            SubmitToolOutputsToRunRequest submitToolOutputsToRunRequest = new SubmitToolOutputsToRunRequest(toolOutputs.ToList(), stream, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            return SubmitToolOutputsInternal(threadId, runId, !stream.HasValue || stream.Value, submitToolOutputsToRunRequest.ToRequestContent(), context);
        }

        /// <summary> Submits outputs from tools as requested by tool calls in a run. Runs that need submitted tool outputs will have a status of 'requires_action' with a required_action.type of 'submit_tool_outputs'. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="toolOutputs"> A list of tools for which the outputs are being submitted. </param>
        /// <param name="stream"> If true, returns a stream of events that happen during the Run as server-sent events, terminating when the run enters a terminal state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response> SubmitToolOutputsToRunAsync(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, bool? stream = null, CancellationToken cancellationToken = default)
        {
            SubmitToolOutputsToRunRequest submitToolOutputsToRunRequest = new SubmitToolOutputsToRunRequest(toolOutputs.ToList(), stream, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            return await SubmitToolOutputsInternalAsync(threadId, runId, !stream.HasValue || stream.Value, submitToolOutputsToRunRequest.ToRequestContent(), context).ConfigureAwait(false);
        }

        /// <summary> Submits outputs from tools as requested by tool calls in a stream. Stream updates that need submitted tool outputs will have a status of 'RunStatus.RequiresAction'. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="content"> Serialized json contents. </param>
        /// <param name="context"> Options that can be used to control the request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/>, <paramref name="runId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> or <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response SubmitToolOutputsToRun(string threadId, string runId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNullOrEmpty(runId, nameof(runId));
            Argument.AssertNotNull(content, nameof(content));

            return SubmitToolOutputsInternal(threadId, runId, false, content, context);
        }

        /// <summary> Submits outputs from tools as requested by tool calls in a stream. Stream updates that need submitted tool outputs will have a status of 'RunStatus.RequiresAction'. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="content"> Serialized json contents. </param>
        /// <param name="context"> Options that can be used to control the request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/>, <paramref name="runId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> or <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response> SubmitToolOutputsToRunAsync(string threadId, string runId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));
            Argument.AssertNotNullOrEmpty(runId, nameof(runId));
            Argument.AssertNotNull(content, nameof(content));

            return await SubmitToolOutputsInternalAsync(threadId, runId, false, content, context).ConfigureAwait(false);
        }

        /// <summary> Submits outputs from tool calls as requested by a run with a status of 'requires_action' with required_action.type of 'submit_tool_outputs'. </summary>
        /// <param name="run"> The <see cref="ThreadRun"/> that the tool outputs should be submitted to. </param>
        /// <param name="toolOutputs"> The list of tool call outputs to provide as part of an output submission to an agent thread run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
        public virtual Response<ThreadRun> SubmitToolOutputsToRun(ThreadRun run, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(run, nameof(run));
            Response response = SubmitToolOutputsToRun(run.ThreadId, run.Id, toolOutputs, false, cancellationToken);
            return Response.FromValue(ThreadRun.FromResponse(response), response);
        }

        /// <summary> Submits outputs from tool calls as requested by a run with a status of 'requires_action' with required_action.type of 'submit_tool_outputs'. </summary>
        /// <param name="run"> The <see cref="ThreadRun"/> that the tool outputs should be submitted to. </param>
        /// <param name="toolOutputs"> The list of tool call outputs to provide as part of an output submission to an agent thread run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
        public virtual async Task<Response<ThreadRun>> SubmitToolOutputsToRunAsync(ThreadRun run, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(run, nameof(run));
            Response response = await SubmitToolOutputsToRunAsync(run.ThreadId, run.Id, toolOutputs, false, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ThreadRun.FromResponse(response), response);
        }

        /// <summary> Submits outputs from tools as requested by tool calls in a stream. Stream updates that need submitted tool outputs will have a status of 'RunStatus.RequiresAction'. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="stream">If true, the run should return stream</param>
        /// <param name="content"> Serialized json contents. </param>
        /// <param name="context"> Options that can be used to control the request. </param>
        internal virtual Response SubmitToolOutputsInternal(string threadId, string runId, bool stream, RequestContent content, RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("AgentsClient.SubmitToolOutputsInternal");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSubmitToolOutputsToRunRequest(threadId, runId, content, context);
                message.BufferResponse = !stream;
                return _pipeline.ProcessMessage(message, context, CancellationToken.None);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Submits outputs from tools as requested by tool calls in a stream. Stream updates that need submitted tool outputs will have a status of 'RunStatus.RequiresAction'. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="stream">If true, the run should return stream</param>
        /// <param name="content"> Serialized json contents. </param>
        /// <param name="context"> Options that can be used to control the request. </param>
        internal virtual async Task<Response> SubmitToolOutputsInternalAsync(string threadId, string runId, bool stream, RequestContent content, RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("AgentsClient.SubmitToolOutputsInternalAsync");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSubmitToolOutputsToRunRequest(threadId, runId, content, context);
                message.BufferResponse = !stream;
                return await _pipeline.ProcessMessageAsync(message, context, CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Uploads a file from a local file path accessible to <see cref="System.IO.File"/>.
        /// </summary>
        /// <param name="filePath"> The local file path. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AgentFile> UploadFile(
            string filePath,
            AgentFilePurpose purpose,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

            using FileStream stream = System.IO.File.OpenRead(filePath);
            return UploadFile(stream, purpose, filePath, cancellationToken);
        }

        /// <summary>
        /// Uploads a file from a local file path accessible to <see cref="System.IO.File"/>.
        /// </summary>
        /// <param name="filePath"> The local file path. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AgentFile>> UploadFileAsync(
            string filePath,
            AgentFilePurpose purpose,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

            using FileStream stream = System.IO.File.OpenRead(filePath);
            return await UploadFileAsync(stream, purpose, filePath, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="data"> The file data, in bytes. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. Use `assistants` for Agents and Message files, `vision` for Agents image file inputs, `batch` for Batch API, and `fine-tune` for Fine-tuning. </param>
        /// <param name="filename"> The name of the file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<AgentFile>> UploadFileAsync(Stream data, AgentFilePurpose purpose, string filename, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));
            File azureFile = new(BinaryData.FromStream(data));

            UploadFileRequest uploadFileRequest = new UploadFileRequest(azureFile, purpose, filename, null);
            using MultipartFormDataRequestContent content = uploadFileRequest.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UploadFileAsync(content, content.ContentType, context).ConfigureAwait(false);
            return Response.FromValue(AgentFile.FromResponse(response), response);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="data"> The file data, in bytes. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. Use `assistants` for Agents and Message files, `vision` for Agents image file inputs, `batch` for Batch API, and `fine-tune` for Fine-tuning. </param>
        /// <param name="filename"> The name of the file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<AgentFile> UploadFile(Stream data, AgentFilePurpose purpose, string filename, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));
            File azureFile = new(BinaryData.FromStream(data));

            UploadFileRequest uploadFileRequest = new UploadFileRequest(azureFile, purpose, filename, null);
            using MultipartFormDataRequestContent content = uploadFileRequest.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UploadFile(content, content.ContentType, context);
            return Response.FromValue(AgentFile.FromResponse(response), response);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="body"> Multipart body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        internal virtual async Task<Response<AgentFile>> UploadFileAsync(UploadFileRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using MultipartFormDataRequestContent content = body.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UploadFileAsync(content, content.ContentType, context).ConfigureAwait(false);
            return Response.FromValue(AgentFile.FromResponse(response), response);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="body"> Multipart body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        internal virtual Response<AgentFile> UploadFile(UploadFileRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using MultipartFormDataRequestContent content = body.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UploadFile(content, content.ContentType, context);
            return Response.FromValue(AgentFile.FromResponse(response), response);
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
        public virtual Response<IReadOnlyList<AgentFile>> GetFiles(AgentFilePurpose? purpose = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetFiles");
            scope.Start();
            Response<InternalFileListResponse> baseResponse = InternalListFiles(purpose, cancellationToken);
            return Response.FromValue(baseResponse.Value?.Data, baseResponse.GetRawResponse());
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <param name="purpose"> Limits files in the response to those with the specified purpose. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<AgentFile>>> GetFilesAsync(
            AgentFilePurpose? purpose = null,
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

        /// <inheritdoc cref="InternalGetRunSteps(string, string, IEnumerable&lt;RunAdditionalFieldList&gt;, int?, ListSortOrder?, string, string, CancellationToken)"/>
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
            Response<InternalOpenAIPageableListOfRunStep> baseResponse = InternalGetRunSteps(threadId, runId, null, limit, order, after, before, cancellationToken);
            return Response.FromValue(PageableList<RunStep>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetRunStepsAsync(string, string, IEnumerable&lt;RunAdditionalFieldList&gt;, int?, ListSortOrder?, string, string, CancellationToken)"/>
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
                = await InternalGetRunStepsAsync(threadId, runId, null, limit, order, after, before, cancellationToken).ConfigureAwait(false);
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

        /// <inheritdoc cref="InternalGetThreads(int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual Response<PageableList<AgentThread>> GetThreads(
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetThreads");
            scope.Start();
            Response<OpenAIPageableListOfAgentThread> baseResponse
                = InternalGetThreads(limit, order, after, before, cancellationToken);
            return Response.FromValue(PageableList<AgentThread>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }

        /// <inheritdoc cref="InternalGetThreadsAsync(int?, ListSortOrder?, string, string, CancellationToken)"/>
        public virtual async Task<Response<PageableList<AgentThread>>> GetThreadsAsync(
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("Agents.GetThreads");
            scope.Start();
            Response<OpenAIPageableListOfAgentThread> baseResponse
                = await InternalGetThreadsAsync(limit, order, after, before, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(PageableList<AgentThread>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        }
    }
}
