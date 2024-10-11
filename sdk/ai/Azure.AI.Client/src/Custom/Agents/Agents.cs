// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Client.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Client
{
    public partial class Agents
    {
        /*
        * CUSTOM CODE DESCRIPTION:
        *
        * These convenience helpers bring additive capabilities to address client methods more ergonomically:
        *  - Use response value instances of types like AgentThread and ThreadRun instead of raw IDs from those instances
        *     a la thread.Id and run.Id.
        *   - Allow direct file-path-based file upload (with inferred filename parameter placement) in lieu of requiring
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
        /// <param name="localFilePath"> The local file path. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<OpenAIFile> UploadFile(
            string localFilePath,
            OpenAIFilePurpose purpose,
            CancellationToken cancellationToken = default)
        {
            FileInfo localFileInfo = new(localFilePath);
            using FileStream localFileStream = localFileInfo.OpenRead();
            return UploadFile(localFileStream, purpose, localFileInfo.Name, cancellationToken);
        }

        /// <summary>
        /// Uploads a file from a local file path accessible to <see cref="System.IO.File"/>.
        /// </summary>
        /// <param name="localFilePath"> The local file path. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<OpenAIFile>> UploadFileAsync(
            string localFilePath,
            OpenAIFilePurpose purpose,
            CancellationToken cancellationToken = default)
        {
            FileInfo localFileInfo = new(localFilePath);
            using FileStream localFileStream = localFileInfo.OpenRead();
            return await UploadFileAsync(localFileStream, purpose, localFileInfo.Name, cancellationToken).ConfigureAwait(false);
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
