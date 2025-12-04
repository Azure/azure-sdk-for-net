// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.ContentSafety
{
    /// <summary> ContentSafety model factory. </summary>
    [CodeGenModel("AIContentSafetyModelFactory")]
    public static partial class ContentSafetyModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ContentSafety.TextBlocklistItem"/>. </summary>
        /// <param name="blocklistItemId"> The service will generate a BlocklistItemId, which will be a UUID. </param>
        /// <param name="description"> BlocklistItem description. </param>
        /// <param name="text"> BlocklistItem content. </param>
        /// <returns> A new <see cref="ContentSafety.TextBlocklistItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TextBlocklistItem TextBlocklistItem(string blocklistItemId, string description, string text)
        {
            return TextBlocklistItem(blocklistItemId, description, text, isRegex: null);
        }
    }
}
