// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Evaluation;

[CodeGenType("Evaluators")]
public partial class ProjectEvaluators
{
    /// <summary> Initiates a new pending upload or retrieves an existing one for the specified evaluator version. </summary>
    /// <param name="name"></param>
    /// <param name="version"> The specific version id of the EvaluatorVersion to operate on. </param>
    /// <param name="configuration"> The pending upload request parameters. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="configuration"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<PendingUploadResult> StartPendingUpload(string name, string version, PendingUploadConfiguration configuration, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNullOrEmpty(version, nameof(version));
        Argument.AssertNotNull(configuration, nameof(configuration));

        ClientResult result = StartPendingUpload(name, version, configuration, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((PendingUploadResult)result, result.GetRawResponse());
    }

    /// <summary> Initiates a new pending upload or retrieves an existing one for the specified evaluator version. </summary>
    /// <param name="name"></param>
    /// <param name="version"> The specific version id of the EvaluatorVersion to operate on. </param>
    /// <param name="configuration"> The pending upload request parameters. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="configuration"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<PendingUploadResult>> StartPendingUploadAsync(string name, string version, PendingUploadConfiguration configuration, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNullOrEmpty(version, nameof(version));
        Argument.AssertNotNull(configuration, nameof(configuration));

        ClientResult result = await StartPendingUploadAsync(name, version, configuration, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((PendingUploadResult)result, result.GetRawResponse());
    }

    /// <summary> Retrieves SAS credentials for accessing the storage account associated with the specified evaluator version. </summary>
    /// <param name="name"></param>
    /// <param name="version"> The specific version id of the EvaluatorVersion to operate on. </param>
    /// <param name="credentialContent"> The credential request parameters. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="credentialContent"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<DatasetCredential> GetCredential(string name, string version, EvaluationCredentialContent credentialContent, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNullOrEmpty(version, nameof(version));
        Argument.AssertNotNull(credentialContent, nameof(credentialContent));

        ClientResult result = GetCredential(name, version, credentialContent, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((DatasetCredential)result, result.GetRawResponse());
    }

    /// <summary> Retrieves SAS credentials for accessing the storage account associated with the specified evaluator version. </summary>
    /// <param name="name"></param>
    /// <param name="version"> The specific version id of the EvaluatorVersion to operate on. </param>
    /// <param name="credentialContent"> The credential request parameters. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="credentialContent"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<DatasetCredential>> GetCredentialAsync(string name, string version, EvaluationCredentialContent credentialContent, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNullOrEmpty(version, nameof(version));
        Argument.AssertNotNull(credentialContent, nameof(credentialContent));

        ClientResult result = await GetCredentialAsync(name, version, credentialContent, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((DatasetCredential)result, result.GetRawResponse());
    }
}
