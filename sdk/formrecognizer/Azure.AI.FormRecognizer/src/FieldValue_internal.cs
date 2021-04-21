// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    [CodeGenModel("FieldValue")]
    internal partial class FieldValue_internal
    {
        /// <summary>Integer value.</summary>
        public long? ValueInteger { get; }

        /// <summary> Selection mark value. </summary>
        public SelectionMarkState? ValueSelectionMark { get; }

        internal FieldValue_internal(string value)
        {
            Type = FieldValueType.String;
            ValueString = value;
            Text = value;
        }

        /// <summary> Initializes a new instance of FieldValue_internal. </summary>
        /// <param name="type"> Type of field value. </param>
        /// <param name="valueString"> String value. </param>
        /// <param name="valueDate"> Date value. </param>
        /// <param name="valueTime"> Time value. </param>
        /// <param name="valuePhoneNumber"> Phone number value. </param>
        /// <param name="valueNumber"> Floating point value. </param>
        /// <param name="valueInteger"> Integer value. </param>
        /// <param name="valueArray"> Array of field values. </param>
        /// <param name="valueObject"> Dictionary of named field values. </param>
        /// <param name="valueSelectionMark"> Selection mark value. </param>
        /// <param name="valueGender"> Gender value: M, F, or X. </param>
        /// <param name="valueCountry"> 3-letter country code (ISO 3166-1 alpha-3). </param>
        /// <param name="text"> Text content of the extracted field. </param>
        /// <param name="boundingBox"> Bounding box of the field value, if appropriate. </param>
        /// <param name="confidence"> Confidence score. </param>
        /// <param name="elements"> When includeTextDetails is set to true, a list of references to the text elements constituting this field. </param>
        /// <param name="page"> The 1-based page number in the input document. </param>
        internal FieldValue_internal(FieldValueType type, string valueString, DateTimeOffset? valueDate, TimeSpan? valueTime, string valuePhoneNumber, float? valueNumber, long? valueInteger, IReadOnlyList<FieldValue_internal> valueArray, IReadOnlyDictionary<string, FieldValue_internal> valueObject, SelectionMarkState? valueSelectionMark, FieldValueGender? valueGender, string valueCountry, string text, IReadOnlyList<float> boundingBox, float? confidence, IReadOnlyList<string> elements, int? page)
        {
            Type = type;
            ValueString = valueString;
            ValueDate = valueDate;
            ValueTime = valueTime;
            ValuePhoneNumber = valuePhoneNumber;
            ValueNumber = valueNumber;
            ValueInteger = valueInteger;
            ValueArray = valueArray;
            ValueObject = valueObject;
            ValueSelectionMark = valueSelectionMark;
            ValueGender = valueGender;
            ValueCountry = valueCountry;
            BoundingBox = boundingBox;
            Confidence = confidence;
            Elements = elements;
            Page = page;

            if (Type == FieldValueType.SelectionMark)
            {
                ValueSelectionMark = SelectionMarkStateExtensions.ToSelectionMarkState(text);
                Text = ValueSelectionMark.ToString();
            }
            else
                Text = text;
        }
    }
}
