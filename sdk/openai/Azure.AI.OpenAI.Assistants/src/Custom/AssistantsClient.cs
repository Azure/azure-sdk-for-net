// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.OpenAI.Assistants;
public partial class AssistantsClient
{
    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * Constructors are replaced to provide overloads that configure client instances to use the platform.openai.com
     * OpenAI endpoint instead of an Azure OpenAI resource.
     *
     */

    private static readonly string s_openAIEndpoint = "https://api.openai.com/v1";

    private readonly string _apiVersion;
    private bool _isConfiguredForAzure;

    /// <summary>
    /// Creates a new instance of <see cref="AssistantsClient"/> for use with an Azure OpenAI resource.
    /// </summary>
    /// <param name="endpoint"> An Azure OpenAI resource URL, e.g. https://my-resource.openai.azure.com. </param>
    /// <param name="keyCredential"> The authentication information for the Azure OpenAI resource. </param>
    /// <param name="options"> Additional options for customizing the behavior of the client. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="endpoint"/> or <paramref name="keyCredential"/> is null.
    /// </exception>
    public AssistantsClient(Uri endpoint, AzureKeyCredential keyCredential, AssistantsClientOptions options)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(keyCredential, nameof(keyCredential));
        options ??= new AssistantsClientOptions();

        ClientDiagnostics = new ClientDiagnostics(options, true);
        _isConfiguredForAzure = true;
        _keyCredential = keyCredential;
        _pipeline = HttpPipelineBuilder.Build(
            options,
            Array.Empty<HttpPipelinePolicy>(),
            new HttpPipelinePolicy[]
            {
                new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader)
            },
            new ResponseClassifier());
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantsClient"/> for use with an Azure OpenAI resource.
    /// </summary>
    /// <param name="endpoint"> An Azure OpenAI resource URL, e.g. https://my-resource.openai.azure.com. </param>
    /// <param name="keyCredential"> The authentication information for the Azure OpenAI resource. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="endpoint"/> or <paramref name="keyCredential"/> is null.
    /// </exception>
    public AssistantsClient(Uri endpoint, AzureKeyCredential keyCredential)
        : this(endpoint, keyCredential, new AssistantsClientOptions())
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantsClient"/> for use with an Azure OpenAI resource.
    /// </summary>
    /// <param name="endpoint"> An Azure OpenAI resource URL, e.g. https://my-resource.openai.azure.com. </param>
    /// <param name="tokenCredential"> The authentication information for the Azure OpenAI resource. </param>
    /// <param name="options"> Additional options for customizing the behavior of the client. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.
    /// </exception>
    public AssistantsClient(Uri endpoint, TokenCredential tokenCredential, AssistantsClientOptions options)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));
        options ??= new AssistantsClientOptions();

        ClientDiagnostics = new ClientDiagnostics(options, true);
        _isConfiguredForAzure = true;
        _tokenCredential = tokenCredential;
        _pipeline = HttpPipelineBuilder.Build(
            options,
            Array.Empty<HttpPipelinePolicy>(),
            new HttpPipelinePolicy[] {
                    new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes)
            },
            new ResponseClassifier());
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantsClient"/> for use with an Azure OpenAI resource.
    /// </summary>
    /// <param name="endpoint"> An Azure OpenAI resource URL, e.g. https://my-resource.openai.azure.com. </param>
    /// <param name="tokenCredential"> The authentication information for the Azure OpenAI resource. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="endpoint"/> is null.
    /// </exception>
    public AssistantsClient(Uri endpoint, TokenCredential tokenCredential)
        : this(endpoint, tokenCredential, new AssistantsClientOptions())
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantsClient"/> for use with OpenAI's api.openai.com endpoint.
    /// </summary>
    /// <param name="openAIApiKey"> An OpenAI API key as obtained from platform.openai.com. </param>
    /// <param name="options"> Additional options for customizing the behavior of the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="openAIApiKey"/> is null. </exception>
    public AssistantsClient(string openAIApiKey, AssistantsClientOptions options)
    {
        Argument.AssertNotNull(openAIApiKey, nameof(openAIApiKey));
        options ??= new AssistantsClientOptions();

        ClientDiagnostics = new ClientDiagnostics(options, true);
        _isConfiguredForAzure = false;
        _tokenCredential = CreateDelegatedToken(openAIApiKey);
        _pipeline = HttpPipelineBuilder.Build(
            options,
            Array.Empty<HttpPipelinePolicy>(),
            new HttpPipelinePolicy[] {
                    new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes)
            },
            new ResponseClassifier());
        _endpoint = new Uri(s_openAIEndpoint);
        _apiVersion = options.Version;
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantsClient"/> for use with OpenAI's api.openai.com endpoint.
    /// </summary>
    /// <param name="openAIApiKey"> An OpenAI API key as obtained from platform.openai.com. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="openAIApiKey"/> is null. </exception>
    public AssistantsClient(string openAIApiKey)
        : this(openAIApiKey, new AssistantsClientOptions())
    {
    }

    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * Generated methods that return trivial response value types (e.g. "DeletionStatus" that has nothing but a
     * "Deleted" property) are shimmed to directly use the underlying data as their response value type.
     *
     */

    /// <summary> Deletes an assistant. </summary>
    /// <param name="assistantId"> The ID of the assistant to delete. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="assistantId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="assistantId"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual Response<bool> DeleteAssistant(string assistantId, CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.DeleteAssistant");
        scope.Start();
        Response<InternalAssistantDeletionStatus> baseResponse = InternalDeleteAssistant(assistantId, cancellationToken);
        bool simplifiedValue =
            baseResponse.GetRawResponse() != null
            && !baseResponse.GetRawResponse().IsError
            && baseResponse.Value != null
            && baseResponse.Value.Deleted;
        return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
    }

    /// <summary> Deletes an assistant. </summary>
    /// <param name="assistantId"> The ID of the assistant to delete. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="assistantId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="assistantId"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<Response<bool>> DeleteAssistantAsync(
        string assistantId,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.DeleteAssistant");
        scope.Start();
        Response<InternalAssistantDeletionStatus> baseResponse
            = await InternalDeleteAssistantAsync(assistantId, cancellationToken).ConfigureAwait(false);
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.DeleteThread");
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.DeleteThread");
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

    /// <summary> Associates a previously uploaded file with an assistant for use by supported tools. </summary>
    /// <param name="assistantId"> The ID of the assistant associated with the attached file to delete. </param>
    /// <param name="fileId"> The ID of the attached file to delete. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="assistantId"/> or <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="assistantId"/> or <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual Response<bool> UnlinkAssistantFile(
        string assistantId,
        string fileId,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.UnlinkAssistantFile");
        scope.Start();
        Response<InternalAssistantFileDeletionStatus> baseResponse
            = InternalUnlinkAssistantFile(assistantId, fileId, cancellationToken);
        bool simplifiedValue =
            baseResponse.GetRawResponse() != null
            && !baseResponse.GetRawResponse().IsError
            && baseResponse.Value != null
            && baseResponse.Value.Deleted;
        return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
    }

    /// <summary>
    ///     Removes an association between an uploaded file and an assistant, making it inaccessible to supported tools
    ///     for that assistant.
    /// </summary>
    /// <remarks>
    ///     This operation only removes the link between the file and assistant; it does not delete the file itself.
    ///     To delete the file, use <see cref="DeleteFile(string, CancellationToken)"/>, instead.
    /// </remarks>
    /// <param name="assistantId"> The ID of the assistant associated with the attached file to delete. </param>
    /// <param name="fileId"> The ID of the attached file to delete. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="assistantId"/> or <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="assistantId"/> or <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<Response<bool>> UnlinkAssistantFileAsync(
        string assistantId,
        string fileId,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.UnlinkAssistantFile");
        scope.Start();
        Response<InternalAssistantFileDeletionStatus> baseResponse
            = await InternalUnlinkAssistantFileAsync(assistantId, fileId, cancellationToken).ConfigureAwait(false);
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetFiles");
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetFiles");
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.DeleteFile");
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.DeleteFile");
        scope.Start();
        Response<InternalFileDeletionStatus> baseResponse = await InternalDeleteFileAsync(fileId, cancellationToken).ConfigureAwait(false);
        bool simplifiedValue =
            baseResponse.GetRawResponse() != null
            && !baseResponse.GetRawResponse().IsError
            && baseResponse.Value != null
            && baseResponse.Value.Deleted;
        return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
    }

    /// <inheritdoc cref="InternalGetAssistants(int?, ListSortOrder?, string, string, CancellationToken)"/>
    public virtual Response<PageableList<Assistant>> GetAssistants(
        int? limit = null,
        ListSortOrder? order = null,
        string after = null,
        string before = null,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetAssistants");
        scope.Start();
        Response<InternalOpenAIPageableListOfAssistant> baseResponse = InternalGetAssistants(limit, order, after, before, cancellationToken);
        return Response.FromValue(PageableList<Assistant>.Create(baseResponse.Value), baseResponse.GetRawResponse());
    }

    /// <inheritdoc cref="InternalGetAssistantsAsync(int?, ListSortOrder?, string, string, CancellationToken)"/>
    public virtual async Task<Response<PageableList<Assistant>>> GetAssistantsAsync(
        int? limit = null,
        ListSortOrder? order = null,
        string after = null,
        string before = null,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetAssistants");
        scope.Start();
        Response<InternalOpenAIPageableListOfAssistant> baseResponse
            = await InternalGetAssistantsAsync(limit, order, after, before, cancellationToken).ConfigureAwait(false);
        return Response.FromValue(PageableList<Assistant>.Create(baseResponse.Value), baseResponse.GetRawResponse());
    }

    /// <inheritdoc cref="InternalGetAssistantFiles(string, int?, ListSortOrder?, string, string, CancellationToken)"/>
    public virtual Response<PageableList<AssistantFile>> GetAssistantFiles(
        string assistantId,
        int? limit = null,
        ListSortOrder? order = null,
        string after = null,
        string before = null,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetAssistantFiles");
        scope.Start();
        Response<InternalOpenAIPageableListOfAssistantFile> baseResponse = InternalGetAssistantFiles(assistantId, limit, order, after, before, cancellationToken);
        return Response.FromValue(PageableList<AssistantFile>.Create(baseResponse.Value), baseResponse.GetRawResponse());
    }

    /// <inheritdoc cref="InternalGetAssistantFilesAsync(string, int?, ListSortOrder?, string, string, CancellationToken)"/>
    public virtual async Task<Response<PageableList<AssistantFile>>> GetAssistantFilesAsync(
        string assistantId,
        int? limit = null,
        ListSortOrder? order = null,
        string after = null,
        string before = null,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetAssistantFiles");
        scope.Start();
        Response<InternalOpenAIPageableListOfAssistantFile> baseResponse
            = await InternalGetAssistantFilesAsync(assistantId, limit, order, after, before, cancellationToken).ConfigureAwait(false);
        return Response.FromValue(PageableList<AssistantFile>.Create(baseResponse.Value), baseResponse.GetRawResponse());
    }

    /// <inheritdoc cref="InternalGetMessageFiles(string, string, int?, ListSortOrder?, string, string, CancellationToken)"/>
    public virtual Response<PageableList<MessageFile>> GetMessageFiles(
        string threadId,
        string messageId,
        int? limit = null,
        ListSortOrder? order = null,
        string after = null,
        string before = null,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetMessageFiles");
        scope.Start();
        Response<InternalOpenAIPageableListOfMessageFile> baseResponse = InternalGetMessageFiles(threadId, messageId, limit, order, after, before, cancellationToken);
        return Response.FromValue(PageableList<MessageFile>.Create(baseResponse.Value), baseResponse.GetRawResponse());
    }

    /// <inheritdoc cref="InternalGetMessageFilesAsync(string, string, int?, ListSortOrder?, string, string, CancellationToken)"/>
    public virtual async Task<Response<PageableList<MessageFile>>> GetMessageFilesAsync(
        string threadId,
        string messageId,
        int? limit = null,
        ListSortOrder? order = null,
        string after = null,
        string before = null,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetMessageFiles");
        scope.Start();
        Response<InternalOpenAIPageableListOfMessageFile> baseResponse
            = await InternalGetMessageFilesAsync(threadId, messageId, limit, order, after, before, cancellationToken).ConfigureAwait(false);
        return Response.FromValue(PageableList<MessageFile>.Create(baseResponse.Value), baseResponse.GetRawResponse());
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetRunSteps");
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetRunSteps");
        scope.Start();
        Response<InternalOpenAIPageableListOfRunStep> baseResponse
            = await InternalGetRunStepsAsync(threadId, runId, limit, order, after, before, cancellationToken).ConfigureAwait(false);
        return Response.FromValue(PageableList<RunStep>.Create(baseResponse.Value), baseResponse.GetRawResponse());
    }

    /// <inheritdoc cref="InternalGetMessages(string, int?, ListSortOrder?, string, string, CancellationToken)"/>
    public virtual Response<PageableList<ThreadMessage>> GetMessages(
        string threadId,
        int? limit = null,
        ListSortOrder? order = null,
        string after = null,
        string before = null,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetMessages");
        scope.Start();
        Response<InternalOpenAIPageableListOfThreadMessage> baseResponse = InternalGetMessages(threadId, limit, order, after, before, cancellationToken);
        return Response.FromValue(PageableList<ThreadMessage>.Create(baseResponse.Value), baseResponse.GetRawResponse());
    }

    /// <inheritdoc cref="InternalGetMessagesAsync(string, int?, ListSortOrder?, string, string, CancellationToken)"/>
    public virtual async Task<Response<PageableList<ThreadMessage>>> GetMessagesAsync(
        string threadId,
        int? limit = null,
        ListSortOrder? order = null,
        string after = null,
        string before = null,
        CancellationToken cancellationToken = default)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetMessages");
        scope.Start();
        Response<InternalOpenAIPageableListOfThreadMessage> baseResponse
            = await InternalGetMessagesAsync(threadId, limit, order, after, before, cancellationToken).ConfigureAwait(false);
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetRuns");
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
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AssistantsClient.GetRuns");
        scope.Start();
        Response<InternalOpenAIPageableListOfThreadRun> baseResponse
            = await InternalGetRunsAsync(threadId, limit, order, after, before, cancellationToken).ConfigureAwait(false);
        return Response.FromValue(PageableList<ThreadRun>.Create(baseResponse.Value), baseResponse.GetRawResponse());
    }

    /// <summary> Uploads a file for use by other operations. </summary>
    /// <param name="data"> The file data (not filename) to upload. </param>
    /// <param name="purpose"> The intended purpose of the file. </param>
    /// <param name="filename"> A filename to associate with the uploaded data. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
    public virtual async Task<Response<OpenAIFile>> UploadFileAsync(Stream data, OpenAIFilePurpose purpose, string filename = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(data, nameof(data));

        UploadFileRequest uploadFileRequest = new UploadFileRequest(data, purpose, filename, null);
        return await UploadFileAsync(uploadFileRequest, cancellationToken).ConfigureAwait(false);
    }

    /// <summary> Uploads a file for use by other operations. </summary>
    /// <param name="data"> The file data (not filename) to upload. </param>
    /// <param name="purpose"> The intended purpose of the file. </param>
    /// <param name="filename"> A filename to associate with the uploaded data. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
    public virtual Response<OpenAIFile> UploadFile(Stream data, OpenAIFilePurpose purpose, string filename = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(data, nameof(data));

        UploadFileRequest uploadFileRequest = new UploadFileRequest(data, purpose, filename, null);
        return UploadFile(uploadFileRequest, cancellationToken);
    }

    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * Request message methods are replaced to support Azure and non-Azure OpenAI use.
     *
     */

    internal HttpMessage CreateRequestMessage(
        string operationPath,
        RequestContent content,
        RequestContext context,
        RequestMethod method,
        params (string QueryParameterName, string QueryParameterValue)[] queryParameters)
    {
        HttpMessage message = _pipeline.CreateMessage(context, ResponseClassifier200);
        Request request = message.Request;
        request.Method = method;
        request.Headers.Add(HttpHeader.Common.JsonAccept);
        request.Headers.Add(HttpHeader.Common.JsonContentType);
        var uri = new RawRequestUriBuilder();
        uri.Reset(_endpoint);
        if (_isConfiguredForAzure)
        {
            uri.AppendPath("openai");
            uri.AppendPath(operationPath, escape: false);
            uri.AppendQuery("api-version", _apiVersion, true);
        }
        else
        {
            uri.AppendPath(operationPath, escape: false);
            request.Headers.Add("OpenAI-Beta", "assistants=v1");
        }
        foreach ((string key, string value) in queryParameters)
        {
            if (!string.IsNullOrEmpty(value))
            {
                uri.AppendQuery(key, value);
            }
        }
        request.Uri = uri;
        request.Content = content;
        return message;
    }

    internal HttpMessage CreateInternalGetAssistantsRequest(
        int? limit,
        string order,
        string after,
        string before,
        RequestContext context)
        => CreateRequestMessage(
            "/assistants",
            content: null,
            context,
            RequestMethod.Get,
            ("limit", $"{(limit.HasValue ? limit.Value : string.Empty)}"),
            ("order", order),
            ("after", after),
            ("before", before));

    internal HttpMessage CreateCreateAssistantRequest(RequestContent content, RequestContext context)
        => CreateRequestMessage("/assistants", content, context, RequestMethod.Post);

    internal HttpMessage CreateGetAssistantRequest(string assistantId, RequestContext context)
        => CreateRequestMessage($"/assistants/{assistantId}", content: null, context, RequestMethod.Get);

    internal HttpMessage CreateUpdateAssistantRequest(string assistantId, RequestContent content, RequestContext context)
        => CreateRequestMessage($"/assistants/{assistantId}", content, context, RequestMethod.Post);

    internal HttpMessage CreateInternalDeleteAssistantRequest(string assistantId, RequestContext context)
        => CreateRequestMessage($"/assistants/{assistantId}", content: null, context, RequestMethod.Delete);

    internal HttpMessage CreateLinkAssistantFileRequest(string assistantId, RequestContent content, RequestContext context)
        => CreateRequestMessage($"/assistants/{assistantId}/files", content, context, RequestMethod.Post);

    internal HttpMessage CreateInternalGetAssistantFilesRequest(string assistantId, int? limit, string order, string after, string before, RequestContext context)
    {
        return CreateRequestMessage(
            $"/assistants/{assistantId}/files",
            content: null,
            context,
            RequestMethod.Get,
            ("limit", $"{(limit.HasValue ? limit.Value : string.Empty)}"),
            ("order", order),
            ("after", after),
            ("before", before));
    }

    internal HttpMessage CreateGetAssistantFileRequest(string assistantId, string fileId, RequestContext context)
        => CreateRequestMessage($"/assistants/{assistantId}/files/{fileId}", content: null, context, RequestMethod.Get);

    internal HttpMessage CreateInternalUnlinkAssistantFileRequest(string assistantId, string fileId, RequestContext context)
        => CreateRequestMessage($"/assistants/{assistantId}/files/{fileId}", content: null, context, RequestMethod.Delete);

    internal HttpMessage CreateCreateThreadRequest(RequestContent content, RequestContext context)
        => CreateRequestMessage($"/threads", content, context, RequestMethod.Post);

    internal HttpMessage CreateGetThreadRequest(string threadId, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}", content: null, context, RequestMethod.Get);
    internal HttpMessage CreateUpdateThreadRequest(string threadId, RequestContent content, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}", content, context, RequestMethod.Post);
    internal HttpMessage CreateInternalDeleteThreadRequest(string threadId, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}", content: null, context, RequestMethod.Delete);

    internal HttpMessage CreateCreateMessageRequest(string threadId, RequestContent content, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}/messages", content, context, RequestMethod.Post);

    internal HttpMessage CreateInternalGetMessagesRequest(string threadId, int? limit, string order, string after, string before, RequestContext context)
        => CreateRequestMessage(
            $"/threads/{threadId}/messages",
            content: null,
            context,
            RequestMethod.Get,
            ("limit", $"{(limit.HasValue ? limit.Value : string.Empty)}"),
            ("order", order),
            ("after", after),
            ("before", before));

    internal HttpMessage CreateGetMessageRequest(string threadId, string messageId, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}/messages/{messageId}", content: null, context, RequestMethod.Get);

    internal HttpMessage CreateUpdateMessageRequest(string threadId, string messageId, RequestContent content, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}/messages/{messageId}", content, context, RequestMethod.Post);
    internal HttpMessage CreateInternalGetMessageFilesRequest(string threadId, string messageId, int? limit, string order, string after, string before, RequestContext context)
        => CreateRequestMessage(
            $"/threads/{threadId}/messages/{messageId}/files",
            content: null,
            context,
            RequestMethod.Get,
            ("limit", $"{(limit.HasValue ? limit.Value : string.Empty)}"),
            ("order", order),
            ("after", after),
            ("before", before));

    internal HttpMessage CreateGetMessageFileRequest(string threadId, string messageId, string fileId, RequestContext context)
        => CreateRequestMessage(
            $"/threads/{threadId}/messages/{messageId}/files/{fileId}",
            content: null,
            context,
            RequestMethod.Get);

    internal HttpMessage CreateCreateRunRequest(string threadId, RequestContent content, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}/runs", content, context, RequestMethod.Post);

    internal HttpMessage CreateInternalGetRunsRequest(string threadId, int? limit, string order, string after, string before, RequestContext context)
        => CreateRequestMessage(
            $"/threads/{threadId}/runs",
            content: null,
            context,
            RequestMethod.Get,
            ("limit", $"{(limit.HasValue ? limit.Value : string.Empty)}"),
            ("order", order),
            ("after", after),
            ("before", before));

    internal HttpMessage CreateGetRunRequest(string threadId, string runId, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}/runs/{runId}", content: null, context, RequestMethod.Get);

    internal HttpMessage CreateUpdateRunRequest(string threadId, string runId, RequestContent content, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}/runs/{runId}", content, context, RequestMethod.Post);
    internal HttpMessage CreateSubmitToolOutputsToRunRequest(string threadId, string runId, RequestContent content, RequestContext context)
        => CreateRequestMessage(
            $"/threads/{threadId}/runs/{runId}/submit_tool_outputs",
            content,
            context,
            RequestMethod.Post);

    internal HttpMessage CreateCancelRunRequest(string threadId, string runId, RequestContext context)
        => CreateRequestMessage($"/threads/{threadId}/runs/{runId}/cancel", content: null, context, RequestMethod.Post);

    internal HttpMessage CreateCreateThreadAndRunRequest(RequestContent content, RequestContext context)
        => CreateRequestMessage($"/threads/runs", content, context, RequestMethod.Post);

    internal HttpMessage CreateGetRunStepRequest(string threadId, string runId, string stepId, RequestContext context)
        => CreateRequestMessage(
            $"/threads/{threadId}/runs/{runId}/steps/{stepId}",
            content: null,
            context,
            RequestMethod.Get);

    internal HttpMessage CreateInternalGetRunStepsRequest(string threadId, string runId, int? limit, string order, string after, string before, RequestContext context)
        => CreateRequestMessage(
            $"/threads/{threadId}/runs/{runId}/steps",
            content: null,
            context,
            RequestMethod.Get,
            ("limit", $"{(limit.HasValue ? limit.Value : string.Empty)}"),
            ("order", order),
            ("after", after),
            ("before", before));

    internal HttpMessage CreateInternalListFilesRequest(string purpose, RequestContext context)
        => CreateRequestMessage("/files", content: null, context, RequestMethod.Get, ("purpose", purpose));

    internal HttpMessage CreateUploadFileRequest(RequestContent content, string contentType,RequestContext context)
    {
        HttpMessage message = CreateRequestMessage("/files", content, context, RequestMethod.Post);
        message.Request.Headers.SetValue(HttpHeader.Names.ContentType, contentType);
        return message;
    }

    internal HttpMessage CreateInternalDeleteFileRequest(string fileId, RequestContext context)
        => CreateRequestMessage($"/files/{fileId}", content: null, context, RequestMethod.Delete);

    internal HttpMessage CreateGetFileRequest(string fileId, RequestContext context)
        => CreateRequestMessage($"/files/{fileId}", content: null, context, RequestMethod.Get);

    internal HttpMessage CreateGetFileContentRequest(string fileId, RequestContext context)
        => CreateRequestMessage($"/files/{fileId}/content", content: null, context, RequestMethod.Get);

    private static TokenCredential CreateDelegatedToken(string token)
    {
        var accessToken = new AccessToken(token, DateTimeOffset.Now.AddDays(180));
        return DelegatedTokenCredential.Create((_, _) => accessToken);
    }
}
