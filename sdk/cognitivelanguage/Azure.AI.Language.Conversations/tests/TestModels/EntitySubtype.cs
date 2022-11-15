// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The concrete entity Subtype model of extra information. </summary>
    public partial class EntitySubtype : BaseExtraInformation
    {
        /// <summary> Initializes a new instance of EntitySubtype. </summary>
        internal EntitySubtype()
        {
            ExtraInformationKind = ExtraInformationKind.EntitySubtype;
        }

        /// <summary> Initializes a new instance of EntitySubtype. </summary>
        /// <param name="extraInformationKind"> The extra information object kind. </param>
        /// <param name="value"> The Subtype of an extracted entity type. </param>
        internal EntitySubtype(ExtraInformationKind extraInformationKind, string value) : base(extraInformationKind)
        {
            Value = value;
            ExtraInformationKind = extraInformationKind;
        }

        /// <summary> The Subtype of an extracted entity type. </summary>
        public string Value { get; }
    }
}
