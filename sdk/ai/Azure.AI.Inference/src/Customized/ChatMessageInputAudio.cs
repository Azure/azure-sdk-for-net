// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;

namespace Azure.AI.Inference
{
    public partial class ChatMessageInputAudio
    {
        public static ChatMessageInputAudio Load(string path, AudioContentFormat format)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string base64 = Convert.ToBase64String(bytes);
            return new ChatMessageInputAudio(base64, format);
        }
    }
}
