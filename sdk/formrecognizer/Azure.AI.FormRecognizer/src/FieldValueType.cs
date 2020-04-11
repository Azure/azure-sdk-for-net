// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("FieldValueType")]
    public enum FieldValueType
    {
        /// <summary> string. </summary>
        [CodeGenMember("String")]
        StringType,
        /// <summary> date. </summary>
        [CodeGenMember("Date")]
        DateType,
        /// <summary> time. </summary>
        [CodeGenMember("Time")]
        TimeType,
        /// <summary> phoneNumber. </summary>
        [CodeGenMember("PhoneNumber")]
        PhoneNumberType,
        /// <summary> number. </summary>
        [CodeGenMember("Number")]
        FloatType,
        /// <summary> integer. </summary>
        [CodeGenMember("Integer")]
        IntegerType,
        /// <summary> array. </summary>
        [CodeGenMember("Array")]
        ListType,
        /// <summary> object. </summary>
        [CodeGenMember("Object")]
        DictionaryType
    }
}
