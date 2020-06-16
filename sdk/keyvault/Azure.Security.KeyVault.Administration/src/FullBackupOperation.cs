// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Security.KeyVault.Administration;
using Azure.Security.KeyVault.Administration.Models;

/// <summary>
/// A long-running operation for <see cref="KeyVaultBackupClient.StartFullBackup(Uri, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartFullBackupAsync(Uri, string, CancellationToken)"/>.
/// </summary>
public class FullBackupOperation : Operation<FullBackupDetails>
{
    /// <summary>
    /// The number of seconds recommended by the service to delay before checking on completion status.
    /// </summary>
    private readonly int? _retryAfterSeconds;
    private readonly KeyVaultBackupClient _client;
    private Response _response;
    private FullBackupDetails _value;

    /// <summary>
    /// Creates an instance of a FullBackupOperation from a previously started operation. <see cref="UpdateStatus(CancellationToken)"/>, <see cref="UpdateStatusAsync(CancellationToken)"/>,
    ///  <see cref="WaitForCompletionAsync(CancellationToken)"/>, or <see cref="WaitForCompletionAsync(TimeSpan, CancellationToken)"/> must be called
    /// to re-populate the details of this operation.
    /// </summary>
    /// <param name="jobId">The <see cref="Id" /> from a previous <see cref="FullBackupOperation" />.</param>
    /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
    public FullBackupOperation(string jobId, KeyVaultBackupClient client)
    {
        Argument.AssertNotNull(jobId, nameof(jobId));
        Argument.AssertNotNull(client, nameof(client));

        _client = client;
        _value = new FullBackupDetails(string.Empty, string.Empty, null, null, null, jobId, string.Empty);
    }

    /// <summary>
    /// Initializes a new instance of a FullBackupOperation.
    /// </summary>
    /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
    /// <param name="response">The <see cref="ResponseWithHeaders{T, THeaders}" /> returned from <see cref="KeyVaultBackupClient.StartFullBackup(Uri, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartFullBackupAsync(Uri, string, CancellationToken)"/>.</param>
    internal FullBackupOperation(KeyVaultBackupClient client, ResponseWithHeaders<FullBackupDetails, ServiceFullBackupHeaders> response)
    {
        _client = client;
        _response = response;
        _retryAfterSeconds = response.Headers.RetryAfter;
        _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
    }

    /// <summary>
    /// Initializes a new instance of a FullBackupOperation for mocking purposes.
    /// </summary>
    /// <param name="value">The <see cref="FullBackupDetails" /> that will be returned from <see cref="Value" />.</param>
    /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="GetRawResponse" />.</param>
    /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
    internal FullBackupOperation(FullBackupDetails value, Response response, KeyVaultBackupClient client)
    {
        Argument.AssertNotNull(value, nameof(value));
        Argument.AssertNotNull(response, nameof(response));
        Argument.AssertNotNull(client, nameof(client));

        _response = response;
        _value = value;
        _client = client;
    }

    /// <inheritdoc/>
    public override string Id => _value.JobId;

    /// <summary>
    /// Gets the <see cref="FullBackupDetails"/> of the backup operation.
    /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use a key in this pending state.
    /// </summary>
    public override FullBackupDetails Value => _value;

    /// <inheritdoc/>
    public override bool HasCompleted => _value.EndTime.HasValue;

    /// <inheritdoc/>
    public override bool HasValue => true;

    /// <inheritdoc/>
    public override Response GetRawResponse() => _response;

    /// <inheritdoc/>
    public override Response UpdateStatus(CancellationToken cancellationToken = default)
    {
        if (!HasCompleted)
        {
            Response<FullBackupDetails> response = _client.GetFullBackupDetails(Id, cancellationToken);
            _value = response.Value;
            _response = response.GetRawResponse();
        }

        return GetRawResponse();
    }

    /// <inheritdoc/>
    public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
    {
        if (!HasCompleted)
        {
            Response<FullBackupDetails> response = await _client.GetFullBackupDetailsAsync(Id, cancellationToken).ConfigureAwait(false);
            _value = response.Value;
            _response = response.GetRawResponse();
        }

        return GetRawResponse();
    }

    /// <inheritdoc/>
    public override ValueTask<Response<FullBackupDetails>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
        _retryAfterSeconds.HasValue ? this.DefaultWaitForCompletionAsync(TimeSpan.FromSeconds(_retryAfterSeconds.Value), cancellationToken) :
            this.DefaultWaitForCompletionAsync(cancellationToken);

    /// <inheritdoc/>
    public override ValueTask<Response<FullBackupDetails>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);
}
