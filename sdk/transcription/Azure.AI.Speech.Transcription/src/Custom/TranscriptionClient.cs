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
            // Always use multipart/form-data as per API spec.
            // The audio part is optional when audioUrl is provided in the definition.
            MultiPartFormDataBinaryContent multipart = new MultiPartFormDataBinaryContent();

            BinaryData optionsJson = ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAISpeechTranscriptionContext.Default);
            multipart.Add(optionsJson.ToString(), DefinitionPartName, contentType: MultipartDefinitionPartContentType);

            if (options.AudioStream != null)
            {
                multipart.Add(options.AudioStream, AudioPartName, filename: DefaultAudioFileName);
            }

            return (multipart, multipart.ContentType);
        }
    }
}
