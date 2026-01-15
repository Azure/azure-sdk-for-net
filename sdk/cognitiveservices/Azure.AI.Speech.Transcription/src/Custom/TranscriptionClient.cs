// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Speech.Transcription
{
    /// <summary> The Transcription service client. </summary>
    public partial class TranscriptionClient
    {
        private const string JsonContentType = "application/json";
        private const string MultipartDefinitionPartContentType = "application/json";
        private const string DefinitionPartName = "definition";
        private const string AudioPartName = "audio";
        private const string DefaultAudioFileName = "audio";

        /// <summary> Transcribes the provided audio stream. </summary>
        /// <param name="options"> The transcription options containing audio and configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<ClientResult<TranscriptionResult>> TranscribeAsync(TranscriptionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            (BinaryContent content, string contentType) = CreateRequestContent(options);
            ClientResult result = await TranscribeAsync(content, contentType, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
            return ClientResult.FromValue((TranscriptionResult)result, result.GetRawResponse());
        }

        /// <summary> Transcribes the provided audio stream. </summary>
        /// <param name="options"> The transcription options containing audio and configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual ClientResult<TranscriptionResult> Transcribe(TranscriptionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            (BinaryContent content, string contentType) = CreateRequestContent(options);
            ClientResult result = Transcribe(content, contentType, cancellationToken.ToRequestOptions());
            return ClientResult.FromValue((TranscriptionResult)result, result.GetRawResponse());
        }

        private static (BinaryContent Content, string ContentType) CreateRequestContent(TranscriptionOptions options)
        {
            if (options.AudioStream != null)
            {
                // Closest equivalent to the old emitter's behavior:
                // send the options and raw audio stream as multipart/form-data.
                MultiPartFormDataBinaryContent multipart = new MultiPartFormDataBinaryContent();

                BinaryData optionsJson = ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAISpeechTranscriptionContext.Default);
                multipart.Add(optionsJson.ToString(), DefinitionPartName, contentType: MultipartDefinitionPartContentType);
                multipart.Add(options.AudioStream, AudioPartName, filename: DefaultAudioFileName);

                return (multipart, multipart.ContentType);
            }

            // AudioUri-only (or options-only) scenario: send JSON body.
            TranscriptionContent body = new TranscriptionContent(options);
            return (body, JsonContentType);
        }
    }
}
