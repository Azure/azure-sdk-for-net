// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The presence of a signature.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1720:Identifier contains type name")]
    [CodeGenModel("DocumentSignatureType")]
    public enum DocumentSignatureType
    {
        /// <summary>
        /// Signed.
        /// </summary>
        Signed,

        /// <summary>
        /// Unsigned.
        /// </summary>
        Unsigned
    }
}
