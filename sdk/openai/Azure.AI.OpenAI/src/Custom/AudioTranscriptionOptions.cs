// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary>
    /// Transcription request.
    /// Requesting format 'json' will result on only the 'text' field being set.
    /// For more output data use 'verbose_json.
    /// </summary>
    [CodeGenType("AudioTranscriptionOptionsVerboseJson")]
    public partial class AudioTranscriptionOptions
    {
        /// <summary>
        /// The audio file object to transcribe.
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
        public BinaryData File { get; set; }

        /// <summary> Initializes a new instance of AudioTranscriptionOptions. </summary>
        public AudioTranscriptionOptions()
        { }

        internal string InternalNonAzureModelName { get; set; }
    }
}
