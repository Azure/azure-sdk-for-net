// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    [CodeGenSchema("FieldValueType")]
    public enum FieldValueType
    {
        /// <summary> string. </summary>
        [CodeGenSchemaMember("String")]
        StringType,
        /// <summary> date. </summary>
        [CodeGenSchemaMember("Date")]
        DateType,
        /// <summary> time. </summary>
        [CodeGenSchemaMember("Time")]
        TimeType,
        /// <summary> phoneNumber. </summary>
        [CodeGenSchemaMember("PhoneNumber")]
        PhoneNumberType,
        /// <summary> number. </summary>
        [CodeGenSchemaMember("Number")]
        FloatType,
        /// <summary> integer. </summary>
        [CodeGenSchemaMember("Integer")]
        IntegerType,
        /// <summary> array. </summary>
        [CodeGenSchemaMember("Array")]
        ListType,
        /// <summary> object. </summary>
        [CodeGenSchemaMember("Object")]
        DictionaryType
    }
}
