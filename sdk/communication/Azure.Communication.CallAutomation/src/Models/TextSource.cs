// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The TextSource. </summary>
    public class TextSource : PlaySource
    {
        /// <summary> Initializes a new instance of TextSource. </summary>
        /// <param name="text"> Text for the cognitive service to be played. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        public TextSource(string text)
        {
            Argument.AssertNotNull(text, nameof(text));

            Text = text;
        }

        /// <summary> Initializes a new instance of TextSource. </summary>
        /// <param name="text"> Text for the cognitive service to be played. </param>
        /// <param name="voiceName"> The voiceName of the audio. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        public TextSource(string text, string voiceName)
        {
            Argument.AssertNotNull(text, nameof(text));

            Text = text;
            VoiceName = voiceName;
        }

        /// <summary> Initializes a new instance of TextSource. </summary>
        /// <param name="text"> Text for the cognitive service to be played. </param>
        /// <param name="sourceLocale"> The culture info string of the voice. </param>
        /// <param name="voiceKind"> The Voice Kind of the voice. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        public TextSource(string text, string sourceLocale, VoiceKind voiceKind)
        {
            Argument.AssertNotNull(text, nameof(text));

            Text = text;
            SourceLocale = sourceLocale;
            VoiceKind = voiceKind;
        }

        /// <summary> Text for the cognitive service to be played. </summary>
        public string Text { get; }
        /// <summary> Source language locale to be played. </summary>
        public string SourceLocale { get; set; }
        /// <summary> Voice type. </summary>
        public VoiceKind? VoiceKind { get; set; }
        /// <summary> Voice name to be played. </summary>
        public string VoiceName { get; set; }
        /// <summary> Endpoint where the custom voice was deployed. </summary>
        public string CustomVoiceEndpointId { get; set; }
    }
}
