// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// The type of the value of a <see cref="FormField"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1720:Identifier contains type name")]
    public enum FieldValueType
    {
        /// <summary>
        /// Used for <see cref="string"/> type.
        /// </summary>
        String,

        /// <summary>
        /// Used for <see cref="DateTime"/> type.
        /// </summary>
        Date,

        /// <summary>
        /// Used for <see cref="TimeSpan"/> type.
        /// </summary>
        Time,

        /// <summary>
        /// Used for <see cref="string"/> type with a phone number format.
        /// </summary>
        PhoneNumber,

        /// <summary>
        /// Used for <see cref="float"/> type.
        /// </summary>
        [CodeGenMember("Number")]
        Float,

        /// <summary>
        /// Used for <see cref="long"/> type.
        /// </summary>
        [CodeGenMember("Integer")]
        Int64,

        /// <summary>
        /// Used for <see cref="List{T}"/> type.
        /// </summary>
        [CodeGenMember("Array")]
        List,

        /// <summary>
        /// Used for <see cref="Dictionary{TKey, TValue}"/> type.
        /// </summary>
        [CodeGenMember("Object")]
        Dictionary,

        /// <summary>
        /// Used for <see cref="SelectionMarkState"/> type.
        /// </summary>
        SelectionMark
    }
}
