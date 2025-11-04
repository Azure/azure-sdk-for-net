// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Translation.Text
{
    /// <summary> Element containing the text with translation. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    public class DictionaryExampleTextItem : InputTextItem
    {
        /// <summary> Initializes a new instance of <see cref="DictionaryExampleTextItem"/>. </summary>
        /// <param name="text"> Text to translate. </param>
        /// <param name="translation">
        /// A string specifying the translated text previously returned by the Dictionary lookup operation.
        /// This should be the value from the normalizedTarget field in the translations list of the Dictionary
        /// lookup response. The service will return examples for the specific source-target word-pair.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="translation"/> is null. </exception>
        public DictionaryExampleTextItem(string text, string translation) : base(text)
        {
            throw new NotSupportedException("This class is obsolete and will be removed in a future release.");
        }

        /// <summary>
        /// A string specifying the translated text previously returned by the Dictionary lookup operation.
        /// This should be the value from the normalizedTarget field in the translations list of the Dictionary
        /// lookup response. The service will return examples for the specific source-target word-pair.
        /// </summary>
        public string Translation { get; }
    }
}
