// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;

namespace Azure.AI.Inference
{
    /// <summary> A structured chat content item containing audio content. </summary>
    public partial class ChatMessageAudioContentItem : ChatMessageContentItem
    {
        private ChatMessageAudioDataContentItem _dataContentItem;
        private ChatMessageAudioUrlContentItem _urlContentItem;

        /// <summary> Initializes a new instance of <see cref="ChatMessageAudioContentItem"/> that references audio at a remote location. </summary>
        /// <param name="audioUri"> The location of the audio to include in the chat message content. </param>
        public ChatMessageAudioContentItem(Uri audioUri)
        {
            _urlContentItem = new ChatMessageAudioUrlContentItem(new ChatMessageInputAudioUrl(audioUri.AbsoluteUri));
        }

        /// <summary> Initializes a new instance of <see cref="ChatMessageAudioContentItem"/> from in-memory audio data. </summary>
        /// <param name="bytes"> The audio data to include in the chat message content. </param>
        /// <param name="audioFormat"> The format of the audio data. </param>
        public ChatMessageAudioContentItem(BinaryData bytes, AudioContentFormat audioFormat)
        {
            string base64AudioData = Convert.ToBase64String(bytes.ToArray());
            _dataContentItem = new ChatMessageAudioDataContentItem(new ChatMessageInputAudio(base64AudioData, audioFormat));
        }

        /// <summary> Initializes a new instance of <see cref="ChatMessageAudioContentItem"/> by reading audio data from a stream. </summary>
        /// <param name="stream"> The stream to read the audio data from. </param>
        /// <param name="audioFormat"> The format of the audio data. </param>
        public ChatMessageAudioContentItem(Stream stream, AudioContentFormat audioFormat)
            : this(BinaryData.FromStream(stream), audioFormat)
        { }

        /// <summary> Initializes a new instance of <see cref="ChatMessageAudioContentItem"/> by reading audio data from a local file. </summary>
        /// <param name="audioFilePath"> The path of the audio file to read. </param>
        /// <param name="audioFormat"> The format of the audio data. </param>
        public ChatMessageAudioContentItem(string audioFilePath, AudioContentFormat audioFormat)
            : this(File.OpenRead(audioFilePath), audioFormat)
        { }

        /// <summary> Initializes a new instance of <see cref="ChatMessageAudioDataContentItem"/> for deserialization. </summary>
        internal ChatMessageAudioContentItem()
        {
        }
    }
}
