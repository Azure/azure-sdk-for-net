// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The UnknownBaseExtraInformation. </summary>
    internal partial class UnknownBaseExtraInformation : BaseExtraInformation
    {
        /// <summary> Initializes a new instance of UnknownBaseExtraInformation. </summary>
        /// <param name="extraInformationKind"> The extra information object kind. </param>
        internal UnknownBaseExtraInformation(ExtraInformationKind extraInformationKind) : base(extraInformationKind)
        {
            ExtraInformationKind = extraInformationKind;
        }
    }
}
