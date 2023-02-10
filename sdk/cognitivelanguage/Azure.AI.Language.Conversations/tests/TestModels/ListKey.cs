// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The list key extra data kind. </summary>
    public partial class ListKey : BaseExtraInformation
    {
        /// <summary> Initializes a new instance of ListKey. </summary>
        internal ListKey()
        {
            ExtraInformationKind = ExtraInformationKind.ListKey;
        }

        /// <summary> Initializes a new instance of ListKey. </summary>
        /// <param name="extraInformationKind"> The extra information object kind. </param>
        /// <param name="key"> The canonical form of the extracted entity. </param>
        internal ListKey(ExtraInformationKind extraInformationKind, string key) : base(extraInformationKind)
        {
            Key = key;
            ExtraInformationKind = extraInformationKind;
        }

        /// <summary> The canonical form of the extracted entity. </summary>
        public string Key { get; }
    }
}
