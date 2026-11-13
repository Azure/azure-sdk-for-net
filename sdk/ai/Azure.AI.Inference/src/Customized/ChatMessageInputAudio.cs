// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;

namespace Azure.AI.Inference
{
    public partial class ChatMessageInputAudio
    {
        /// <summary> Creates a new <see cref="ChatMessageInputAudio"/> from the contents of a local audio file. </summary>
        /// <param name="path"> The path of the audio file to read. </param>
        /// <param name="format"> The format of the audio data. </param>
        /// <returns> A new <see cref="ChatMessageInputAudio"/> containing the base64-encoded contents of the file. </returns>
        public static ChatMessageInputAudio Load(string path, AudioContentFormat format)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string base64 = Convert.ToBase64String(bytes);
            return new ChatMessageInputAudio(base64, format);
        }
    }
}
