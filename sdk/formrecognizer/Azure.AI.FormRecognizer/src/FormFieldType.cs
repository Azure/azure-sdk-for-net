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
    public enum LabeledFieldType
    {
        /// <summary> string. </summary>
        [CodeGenSchemaMember("String")]
        StringValue,
        /// <summary> date. </summary>
        [CodeGenSchemaMember("Date")]
        DateValue,
        /// <summary> time. </summary>
        [CodeGenSchemaMember("Time")]
        TimeValue,
        /// <summary> phoneNumber. </summary>
        [CodeGenSchemaMember("PhoneNumber")]
        PhoneNumberValue,
        /// <summary> number. </summary>
        [CodeGenSchemaMember("Number")]
        FloatValue,
        /// <summary> integer. </summary>
        [CodeGenSchemaMember("Integer")]
        IntegerValue,
        /// <summary> array. </summary>
        [CodeGenSchemaMember("Array")]
        ArrayValue,
        /// <summary> object. </summary>
        [CodeGenSchemaMember("Object")]
        ObjectValue
    }
}
