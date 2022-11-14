// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            SourceLocale = new ChangeTrackingList<string>();
            TargetLocale = new ChangeTrackingList<string>();
            Gender = new ChangeTrackingList<GenderType>();
            VoiceName = new ChangeTrackingList<string>();
        }

        /// <summary> Text for the cognitive service to be played. </summary>
        public string Text { get; }
        /// <summary> Source language locale to be played. </summary>
        public IList<string> SourceLocale { get; }
        /// <summary> Target language locale to be played. </summary>
        public IList<string> TargetLocale { get; }
        /// <summary> Voice gender type. </summary>
        public IList<GenderType> Gender { get; }
        /// <summary> Voice names to be played. </summary>
        public IList<string> VoiceName { get; }
    }
}
