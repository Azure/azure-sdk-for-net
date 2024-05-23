// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.OpenAI.Assistants;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * These convenience helpers bring additive capabilities to address client methods more ergonomically:
 *   - Use response value instances of types like AssistantThread and ThreadRun instead of raw IDs from those instances
 *     a la thread.Id and run.Id.
 *   - Allow direct file-path-based file upload (with inferred filename parameter placement) in lieu of requiring
 *     manual I/O prior to getting a byte array
 */

public partial class AssistantsClient
{
    /// <summary>
    /// Creates a new, empty thread using a default <see cref="AssistantThreadCreationOptions"/> instance.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    public virtual Response<AssistantThread> CreateThread(CancellationToken cancellationToken = default)
        => CreateThread(new AssistantThreadCreationOptions(), cancellationToken);

    /// <summary>
    /// Creates a new, empty thread using a default <see cref="AssistantThreadCreationOptions"/> instance.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    public virtual Task<Response<AssistantThread>> CreateThreadAsync(
        CancellationToken cancellationToken = default)
        => CreateThreadAsync(new AssistantThreadCreationOptions(), cancellationToken);

    /// <summary>
    /// Creates a new run of the specified thread using a specified assistant.
    /// </summary>
    /// <remarks>
    /// This method will create the run with default configuration.
    /// To customize the run, use <see cref="AssistantsClient.CreateRun(string, CreateRunOptions, CancellationToken)"/>.
    /// </remarks>
    /// <param name="thread"> The thread that should be run. </param>
    /// <param name="assistant"> The assistant that should run the thread. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> A new <see cref="ThreadRun"/> instance. </returns>
    public virtual Response<ThreadRun> CreateRun(AssistantThread thread, Assistant assistant, CancellationToken cancellationToken = default)
        => CreateRun(thread.Id, new CreateRunOptions(assistant.Id), cancellationToken);

    /// <summary>
    /// Creates a new run of the specified thread using a specified assistant.
    /// </summary>
    /// <remarks>
    /// This method will create the run with default configuration.
    /// To customize the run, use <see cref="AssistantsClient.CreateRun(string, CreateRunOptions, CancellationToken)"/>.
    /// </remarks>
    /// <param name="thread"> The thread that should be run. </param>
    /// <param name="assistant"> The assistant that should run the thread. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> A new <see cref="ThreadRun"/> instance. </returns>
    public virtual Task<Response<ThreadRun>> CreateRunAsync(
        AssistantThread thread,
        Assistant assistant,
        CancellationToken cancellationToken = default)
        => CreateRunAsync(thread.Id, new CreateRunOptions(assistant.Id), cancellationToken);

    /// <summary> Returns a list of run steps associated an assistant thread run. </summary>
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

    /// <summary> Returns a list of run steps associated an assistant thread run. </summary>
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
    /// <param name="toolOutputs"> The list of tool call outputs to provide as part of an output submission to an assistant thread run. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
    public virtual Response<ThreadRun> SubmitToolOutputsToRun(ThreadRun run, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(run, nameof(run));
        return SubmitToolOutputsToRun(run.ThreadId, run.Id, toolOutputs, cancellationToken);
    }

    /// <summary> Submits outputs from tool calls as requested by a run with a status of 'requires_action' with required_action.type of 'submit_tool_outputs'. </summary>
    /// <param name="run"> The <see cref="ThreadRun"/> that the tool outputs should be submitted to. </param>
    /// <param name="toolOutputs"> The list of tool call outputs to provide as part of an output submission to an assistant thread run. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="run"/>  is null. </exception>
    public virtual Task<Response<ThreadRun>> SubmitToolOutputsToRunAsync(ThreadRun run, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(run, nameof(run));
        return SubmitToolOutputsToRunAsync(run.ThreadId, run.Id, toolOutputs, cancellationToken);
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
}
