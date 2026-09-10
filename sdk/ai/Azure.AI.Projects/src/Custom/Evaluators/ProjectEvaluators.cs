// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Evaluation;

[Experimental("AAIP001")]
[CodeGenType("Evaluators")]
public partial class ProjectEvaluators
{
    /// <summary> Initiates a new pending upload or retrieves an existing one for the specified evaluator version. </summary>
    /// <param name="name"></param>
    /// <param name="version"> The specific version id of the EvaluatorVersion to operate on. </param>
    /// <param name="pendingUploadRequest"> The pending upload request parameters. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="pendingUploadRequest"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<PendingUploadResult> StartPendingUpload(string name, string version, PendingUploadConfiguration pendingUploadRequest, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNullOrEmpty(version, nameof(version));
        Argument.AssertNotNull(pendingUploadRequest, nameof(pendingUploadRequest));

        ClientResult result = StartPendingUpload(name, version, pendingUploadRequest, default, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((PendingUploadResult)result, result.GetRawResponse());
    }

    /// <summary> Initiates a new pending upload or retrieves an existing one for the specified evaluator version. </summary>
    /// <param name="name"></param>
    /// <param name="version"> The specific version id of the EvaluatorVersion to operate on. </param>
    /// <param name="pendingUploadRequest"> The pending upload request parameters. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="pendingUploadRequest"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<PendingUploadResult>> StartPendingUploadAsync(string name, string version, PendingUploadConfiguration pendingUploadRequest, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNullOrEmpty(version, nameof(version));
        Argument.AssertNotNull(pendingUploadRequest, nameof(pendingUploadRequest));

        ClientResult result = await StartPendingUploadAsync(name, version, pendingUploadRequest, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((PendingUploadResult)result, result.GetRawResponse());
    }

    /// <summary> Retrieves SAS credentials for accessing the storage account associated with the specified evaluator version. </summary>
    /// <param name="name"></param>
    /// <param name="version"> The specific version id of the EvaluatorVersion to operate on. </param>
    /// <param name="credentialRequest"> The credential request parameters. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="credentialRequest"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<DatasetCredential> GetCredential(string name, string version, EvaluationCredentialContent credentialRequest, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNullOrEmpty(version, nameof(version));
        Argument.AssertNotNull(credentialRequest, nameof(credentialRequest));

        ClientResult result = GetCredential(name, version, credentialRequest, default, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((DatasetCredential)result, result.GetRawResponse());
    }

    /// <summary> Retrieves SAS credentials for accessing the storage account associated with the specified evaluator version. </summary>
    /// <param name="name"></param>
    /// <param name="version"> The specific version id of the EvaluatorVersion to operate on. </param>
    /// <param name="credentialRequest"> The credential request parameters. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="credentialRequest"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<DatasetCredential>> GetCredentialAsync(string name, string version, EvaluationCredentialContent credentialRequest, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNullOrEmpty(version, nameof(version));
        Argument.AssertNotNull(credentialRequest, nameof(credentialRequest));

        ClientResult result = await GetCredentialAsync(name, version, credentialRequest, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((DatasetCredential)result, result.GetRawResponse());
    }
}
