// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Autorest.CSharp.Core;

using Azure.Core;
using System.Threading.Tasks;
using System.Threading;
using System;
using Azure.AI.Speech.BatchTranscription;

namespace Azure.AI.Speech.BatchTranscription;

/// <summary> The AsynchronousTranscription sub-client. </summary>
public partial class BatchTranscriptionClient
{
    private static readonly TimeSpan DefaultDelay = TimeSpan.FromSeconds(1);

    /// <summary> Submits a new transcription job. </summary>
    /// <param name="resource"> The resource instance. </param>
    /// <param name="waitUntil"> The waitUntil option. </param>
    /// /// <param name="pollingInterval"> The interval between status requests to the server. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="resource"/> is null. </exception>
    public virtual async Task<Response<TranscriptionJob>> TranscribeAsync(TranscriptionJob resource, WaitUntil waitUntil, TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(resource, nameof(resource));

        using RequestContent content = resource.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);
        Response response = await StartTranscriptionAsync(content, context).ConfigureAwait(false);
        return PollUntil(response, waitUntil, pollingInterval ?? DefaultDelay, cancellationToken);
    }

    /// <summary> Submits a new transcription job. </summary>
    /// <param name="resource"> The resource instance. </param>
    /// <param name="waitUntil"> The waitUntil option. </param>
    /// <param name="pollingInterval"> The interval between status requests to the server. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="resource"/> is null. </exception>
    public virtual Response<TranscriptionJob> Transcribe(TranscriptionJob resource, WaitUntil waitUntil, TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(resource, nameof(resource));

        using RequestContent content = resource.ToRequestContent();
        RequestContext context = FromCancellationToken(cancellationToken);
        Response response = StartTranscription(content, context);
        return PollUntil(response, waitUntil, pollingInterval ?? DefaultDelay, cancellationToken);
    }

    private Response<TranscriptionJob> PollUntil(Response response, WaitUntil waitUntil, TimeSpan delay, CancellationToken cancellationToken)
    {
        var waitUntilStatus = waitUntil == WaitUntil.Started ? TranscriptionStatus.Running : TranscriptionStatus.Succeeded;
        var transcriptionJobResponse = Response.FromValue(TranscriptionJob.FromResponse(response), response);
        while (transcriptionJobResponse.Value.Status != waitUntilStatus)
        {
            _ = Delay(false, delay, cancellationToken);
            transcriptionJobResponse = GetTranscription(transcriptionJobResponse.Value.Id, cancellationToken);
        }
        return transcriptionJobResponse;
    }

    private async Task<Response<TranscriptionJob>> PollUntilAsync(Response response, WaitUntil waitUntil, TimeSpan delay, CancellationToken cancellationToken)
    {
        var waitUntilStatus = waitUntil == WaitUntil.Started ? TranscriptionStatus.Running : TranscriptionStatus.Succeeded;
        var transcriptionJobResponse = Response.FromValue(TranscriptionJob.FromResponse(response), response);
        while (transcriptionJobResponse.Value.Status != waitUntilStatus)
        {
            await Delay(true, delay, cancellationToken).ConfigureAwait(false);
            transcriptionJobResponse = await GetTranscriptionAsync(transcriptionJobResponse.Value.Id, cancellationToken).ConfigureAwait(false);
        }
        return transcriptionJobResponse;
    }

    private static async ValueTask Delay(bool async, TimeSpan delay, CancellationToken cancellationToken)
    {
        if (async)
        {
            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
        }
        else if (cancellationToken.CanBeCanceled)
        {
            if (cancellationToken.WaitHandle.WaitOne(delay))
            {
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
        else
        {
            Thread.Sleep(delay);
        }
    }
}
