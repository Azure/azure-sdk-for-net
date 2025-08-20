// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Agents.Persistent
{
    [CodeGenClient("Runs")]
    public partial class ThreadRuns
    {
        private readonly ThreadRunSteps _threadRunStepsClient;
        /// <summary> Initializes a new instance of ThreadRuns. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Project endpoint in the form of: https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="threadRunStepsClient">The thread run steps client to be used.</param>
        internal ThreadRuns(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, string apiVersion, ThreadRunSteps threadRunStepsClient): this (
                clientDiagnostics: clientDiagnostics,
                pipeline: pipeline,
                tokenCredential: tokenCredential,
                endpoint: endpoint,
                apiVersion: apiVersion
            )
        {
            _threadRunStepsClient = threadRunStepsClient;
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
        public virtual Response<ThreadRun> CreateRun(PersistentAgentThread thread, PersistentAgent agent, CancellationToken cancellationToken = default)
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
        public virtual Task<Response<ThreadRun>> CreateRunAsync(PersistentAgentThread thread, PersistentAgent agent, CancellationToken cancellationToken = default)
             => CreateRunAsync(thread.Id, agent.Id, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, cancellationToken);

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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.SubmitToolOutputsInternal");
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.SubmitToolOutputsInternalAsync");
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

        /// <summary> Gets a list of runs for a specified thread. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual AsyncPageable<ThreadRun> GetRunsAsync(string threadId, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetRunsRequest(threadId, limit, order?.ToString(), continuationToken, before, context);
            return new ContinuationTokenPageableAsync<ThreadRun>(
                createPageRequest: PageRequest,
                valueFactory: e => ThreadRun.DeserializeThreadRun(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context
            );
        }

        /// <summary> Gets a list of runs for a specified thread. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Pageable<ThreadRun> GetRuns(string threadId, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetRunsRequest(threadId, limit, order?.ToString(), continuationToken, before, context);
            return new ContinuationTokenPageable<ThreadRun>(
                createPageRequest: PageRequest,
                valueFactory: e => ThreadRun.DeserializeThreadRun(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context
            );
        }

        /// <summary>
        /// [Protocol Method] Gets a list of runs for a specified thread.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetRunsAsync(string,int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual AsyncPageable<BinaryData> GetRunsAsync(string threadId, int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetRunsRequest(threadId, limit, order, after, before, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ThreadRunsClient.GetRuns", "data", null, context);
        }

        /// <summary>
        /// [Protocol Method] Gets a list of runs for a specified thread.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetRuns(string,int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual Pageable<BinaryData> GetRuns(string threadId, int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetRunsRequest(threadId, limit, order, after, before, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ThreadRunsClient.GetRuns", "data", null, context);
        }

        ////////////////////////////////////////////////////////////////////////////
        // Thread run step client methods.
        ////////////////////////////////////////////////////////////////////////////
        /// <summary> Returns a list of run steps associated an agent thread run. </summary>
        /// <param name = "run" > The <see cref="ThreadRun"/> instance from which run steps should be listed. </param>
        /// <param name = "limit" > A limit on the number of objects to be returned.Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name = "order" > Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name = "after" > A cursor for use in pagination.after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after = obj_foo in order to fetch the next page of the list. </param>
        /// <param name = "before" > A cursor for use in pagination.before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before = obj_foo in order to fetch the previous page of the list. </param>
        /// <param name = "cancellationToken" > The cancellation token to use. </param>
        /// <exception cref ="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
        public virtual Pageable<RunStep> GetRunSteps(
            ThreadRun run,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            return _threadRunStepsClient.GetRunSteps(
                run: run,
                limit: limit,
                order: order,
                after: after,
                before: before,
                cancellationToken: cancellationToken
            );
        }

        /// <summary> Returns a list of run steps associated an agent thread run. </summary>
        /// <param name="run"> The <see cref="ThreadRun"/> instance from which run steps should be listed. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
        public virtual AsyncPageable<RunStep> GetRunStepsAsync(
            ThreadRun run,
            int? limit = null,
            ListSortOrder? order = null,
            string after = null,
            string before = null,
            CancellationToken cancellationToken = default)
        {
            return _threadRunStepsClient.GetRunStepsAsync(
                run: run,
                limit: limit,
                order: order,
                after: after,
                before: before,
                cancellationToken: cancellationToken
            );
        }

        /// <summary> Gets a list of run steps from a thread run. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="include">
        /// A list of additional fields to include in the response.
        /// Currently the only supported value is `step_details.tool_calls[*].file_search.results[*].content` to fetch the file search result content.
        /// </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="runId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> or <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual AsyncPageable<RunStep> GetRunStepsAsync(string threadId, string runId, IEnumerable<RunAdditionalFieldList> include = null, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            return _threadRunStepsClient.GetRunStepsAsync(
                threadId: threadId,
                runId: runId,
                include: include,
                limit: limit,
                order: order,
                after: after,
                before: before,
                cancellationToken: cancellationToken
            );
        }

        /// <summary> Gets a list of run steps from a thread run. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="include">
        /// A list of additional fields to include in the response.
        /// Currently the only supported value is `step_details.tool_calls[*].file_search.results[*].content` to fetch the file search result content.
        /// </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> or <paramref name="runId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> or <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Pageable<RunStep> GetRunSteps(string threadId, string runId, IEnumerable<RunAdditionalFieldList> include = null, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            return _threadRunStepsClient.GetRunSteps(
                threadId: threadId,
                runId: runId,
                include: include,
                limit: limit,
                order: order,
                after: after,
                before: before,
                cancellationToken: cancellationToken
            );
        }

        /// <summary> Retrieves a single run step from a thread run. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="stepId"> Identifier of the run step. </param>
        /// <param name="include">
        /// A list of additional fields to include in the response.
        /// Currently the only supported value is `step_details.tool_calls[*].file_search.results[*].content` to fetch the file search result content.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/>, <paramref name="runId"/> or <paramref name="stepId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/>, <paramref name="runId"/> or <paramref name="stepId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, IEnumerable<RunAdditionalFieldList> include = null, CancellationToken cancellationToken = default)
        {
            return await _threadRunStepsClient.GetRunStepAsync(
                threadId: threadId,
                runId: runId,
                stepId: stepId,
                include: include,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary> Retrieves a single run step from a thread run. </summary>
        /// <param name="threadId"> Identifier of the thread. </param>
        /// <param name="runId"> Identifier of the run. </param>
        /// <param name="stepId"> Identifier of the run step. </param>
        /// <param name="include">
        /// A list of additional fields to include in the response.
        /// Currently the only supported value is `step_details.tool_calls[*].file_search.results[*].content` to fetch the file search result content.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/>, <paramref name="runId"/> or <paramref name="stepId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/>, <paramref name="runId"/> or <paramref name="stepId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<RunStep> GetRunStep(string threadId, string runId, string stepId, IEnumerable<RunAdditionalFieldList> include = null, CancellationToken cancellationToken = default)
        {
            return _threadRunStepsClient.GetRunStep(
                threadId: threadId,
                runId: runId,
                stepId: stepId,
                include: include,
                cancellationToken: cancellationToken
            );
        }
    }
}
