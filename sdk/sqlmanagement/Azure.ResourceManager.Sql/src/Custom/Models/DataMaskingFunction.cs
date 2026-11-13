// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    // Spec breaking change, preserve the original fixed enum for binary back-compat.
    /// <summary> The masking function that is used for the data masking rule. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum DataMaskingFunction
    {
        /// <summary> Default. </summary>
        Default,
        /// <summary> CCN. </summary>
        Ccn,
        /// <summary> Email. </summary>
        Email,
        /// <summary> Number. </summary>
        Number,
        /// <summary> SSN. </summary>
        Ssn,
        /// <summary> Text. </summary>
        Text,
    }
}
