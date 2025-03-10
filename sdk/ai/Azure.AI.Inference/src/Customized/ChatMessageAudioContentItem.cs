// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;

namespace Azure.AI.Inference
{
    public partial class ChatMessageAudioContentItem : ChatMessageContentItem
    {
        private ChatMessageAudioDataContentItem _dataContentItem;
        private ChatMessageAudioUrlContentItem _urlContentItem;

        public ChatMessageAudioContentItem(Uri audioUri)
        {
            _urlContentItem = new ChatMessageAudioUrlContentItem(new ChatMessageInputAudioUrl(audioUri.AbsoluteUri));
        }

        public ChatMessageAudioContentItem(BinaryData bytes, AudioContentFormat audioFormat)
        {
            string base64AudioData = Convert.ToBase64String(bytes.ToArray());
            _dataContentItem = new ChatMessageAudioDataContentItem(new ChatMessageInputAudio(base64AudioData, audioFormat));
        }

        public ChatMessageAudioContentItem(Stream stream, AudioContentFormat audioFormat)
            : this(BinaryData.FromStream(stream), audioFormat)
        { }

        public ChatMessageAudioContentItem(string audioFilePath, AudioContentFormat audioFormat)
            : this(File.OpenRead(audioFilePath), audioFormat)
        { }

        /// <summary> Initializes a new instance of <see cref="ChatMessageAudioDataContentItem"/> for deserialization. </summary>
        internal ChatMessageAudioContentItem()
        {
        }
    }
}
