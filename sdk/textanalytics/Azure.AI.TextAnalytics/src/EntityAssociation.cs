// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Describes whether the healthcare entity it's on the subject of the document, or
    /// if this entity describes someone else in the document. For example, in "The subject's mother has
    /// a fever", the "fever" entity is not associated with the subject themselves, but with the subject's
    /// mother.
    /// </summary>
    [CodeGenModel("Association")]
    public enum EntityAssociation
    {
        /// <summary> subject. </summary>
        Subject,
        /// <summary> other. </summary>
        Other
    }
}
