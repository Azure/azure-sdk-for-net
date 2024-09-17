// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation.FHL
{
    /// <summary>
    /// Streaming Audio.
    /// </summary>
    public class ServerAudioData
    {
        /// <summary>
        /// Audio data constructor
        /// </summary>
        /// <param name="data">audio data bytes</param>
        public ServerAudioData(byte[] data)
        {
            Data = data;
        }

        /// <summary>
        /// Base64 Encoded audio buffer data, the byte[] array type was just added as a convenience since Newtonsoft.Json
        /// serializes it into a base64 encoded string. Over the wire, this should be of type string
        /// IsRequired = true
        /// </summary>
        public byte[] Data { get; }
    }
}
