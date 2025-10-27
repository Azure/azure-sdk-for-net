// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Speech.Transcription
{
    // Data plane generated client.
    /// <summary> The Transcription service client. </summary>
    public partial class TranscriptionClient
    {
        /// <summary> Transcribes the provided audio stream. </summary>
        /// <param name="options"> The transcription options containing audio and configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<TranscriptionResult>> TranscribeAsync(TranscriptionOptions options, CancellationToken cancellationToken = default)
        {
            TranscribeRequestContent body = new TranscribeRequestContent(options, options.AudioStream, null);
            return await TranscribeAsync(body, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Transcribes the provided audio stream. </summary>
        /// <param name="options"> The transcription options containing audio and configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        internal virtual Response<TranscriptionResult> Transcribe(TranscriptionOptions options, CancellationToken cancellationToken = default)
        {
            TranscribeRequestContent body = new TranscribeRequestContent(options, options.AudioStream, null);
            return Transcribe(body, cancellationToken);
        }
    }
}
