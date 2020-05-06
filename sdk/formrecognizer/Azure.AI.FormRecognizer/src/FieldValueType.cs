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
    [CodeGenModel("FieldValueType")]
    public enum FieldValueType
    {
        /// <summary>
        /// Used for <see cref="string"/> type.
        /// </summary>
        [CodeGenMember("String")]
        StringType,

        /// <summary>
        /// Used for <see cref="DateTime"/> type.
        /// </summary>
        [CodeGenMember("Date")]
        DateType,

        /// <summary>
        /// Used for <see cref="TimeSpan"/> type.
        /// </summary>
        [CodeGenMember("Time")]
        TimeType,

        /// <summary>
        /// Used for <see cref="string"/> type with a phone number format.
        /// </summary>
        [CodeGenMember("PhoneNumber")]
        PhoneNumberType,

        /// <summary>
        /// Used for <see cref="float"/> type.
        /// </summary>
        [CodeGenMember("Number")]
        FloatType,

        /// <summary>
        /// Used for <see cref="int"/> type.
        /// </summary>
        [CodeGenMember("Integer")]
        IntegerType,

        /// <summary>
        /// Used for <see cref="List{T}"/> type.
        /// </summary>
        [CodeGenMember("Array")]
        ListType,

        /// <summary>
        /// Used for <see cref="Dictionary{TKey, TValue}"/> type.
        /// </summary>
        [CodeGenMember("Object")]
        DictionaryType
    }
}
