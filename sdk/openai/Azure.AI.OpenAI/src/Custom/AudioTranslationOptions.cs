// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI
{
    /// <summary> The configuration information for an audio translation request. </summary>
    public partial class AudioTranslationOptions
    {
        /// <summary>
        /// The audio data to transcribe. This must be the binary content of a file in one of the supported media formats:
        /// flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, webm.
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData AudioData { get; set; }

        internal string InternalNonAzureModelName { get; set; }

        /// <summary>
        /// Initializes a new instance of AudioTranslationOptions.
        /// </summary>
        public AudioTranslationOptions()
        { }
    }
}
