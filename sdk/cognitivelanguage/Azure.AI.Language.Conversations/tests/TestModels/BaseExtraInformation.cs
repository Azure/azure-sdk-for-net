// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// The abstract base object for entity extra information.
    /// Please note <see cref="BaseExtraInformation"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="EntitySubtype"/>, <see cref="ListKey"/> and <see cref="RegexKey"/>.
    /// </summary>
    public partial class BaseExtraInformation
    {
        /// <summary> Initializes a new instance of BaseExtraInformation. </summary>
        internal BaseExtraInformation()
        {
        }

        /// <summary> Initializes a new instance of BaseExtraInformation. </summary>
        /// <param name="extraInformationKind"> The extra information object kind. </param>
        internal BaseExtraInformation(ExtraInformationKind extraInformationKind)
        {
            ExtraInformationKind = extraInformationKind;
        }

        /// <summary> The extra information object kind. </summary>
        internal ExtraInformationKind ExtraInformationKind { get; set; }
    }
}
