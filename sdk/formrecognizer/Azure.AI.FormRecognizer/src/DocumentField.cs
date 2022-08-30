// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentField")]
    [CodeGenSuppress(nameof(DocumentField), typeof(DocumentFieldType), typeof(string), typeof(DateTimeOffset?), typeof(TimeSpan?), typeof(string), typeof(double?), typeof(long?), typeof(V3SelectionMarkState?), typeof(DocumentSignatureType?), typeof(string), typeof(IReadOnlyList<DocumentField>), typeof(IReadOnlyDictionary<string, DocumentField>), typeof(CurrencyValue?), typeof(AddressValue), typeof(string), typeof(IReadOnlyList<BoundingRegion>), typeof(IReadOnlyList<DocumentSpan>), typeof(float?))]
    [CodeGenSuppress("Type")]
    [CodeGenSuppress("ValueString")]
    [CodeGenSuppress("ValueDate")]
    [CodeGenSuppress("ValueTime")]
    [CodeGenSuppress("ValuePhoneNumber")]
    [CodeGenSuppress("ValueInteger")]
    [CodeGenSuppress("ValueSelectionMark")]
    [CodeGenSuppress("ValueSignature")]
    [CodeGenSuppress("ValueCountryRegion")]
    [CodeGenSuppress("ValueArray")]
    [CodeGenSuppress("ValueObject")]
    [CodeGenSuppress("ValueCurrency")]
    [CodeGenSuppress("ValueAddress")]
    public partial class DocumentField
    {
        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="valueType"> Data type of the field value. </param>
        internal DocumentField(DocumentFieldType valueType)
        {
            Value = new DocumentFieldValue(valueType);
            BoundingRegions = new ChangeTrackingList<BoundingRegion>();
            Spans = new ChangeTrackingList<DocumentSpan>();
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="valueType"> Data type of the field value. </param>
        /// <param name="valueString"> String value. </param>
        /// <param name="valueDate"> Date value in YYYY-MM-DD format (ISO 8601). </param>
        /// <param name="valueTime"> Time value in hh:mm:ss format (ISO 8601). </param>
        /// <param name="valuePhoneNumber"> Phone number value in E.164 format (ex. +19876543210). </param>
        /// <param name="valueNumber"> Floating point value. </param>
        /// <param name="valueInteger"> Integer value. </param>
        /// <param name="valueSelectionMarkPrivate"> Selection mark value. </param>
        /// <param name="valueSignature"> Presence of signature. </param>
        /// <param name="valueCountryRegion"> 3-letter country code value (ISO 3166-1 alpha-3). </param>
        /// <param name="valueArray"> Array of field values. </param>
        /// <param name="valueObject"> Dictionary of named field values. </param>
        /// <param name="valueCurrency"> Currency value. </param>
        /// <param name="valueAddress"> Address value. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        internal DocumentField(DocumentFieldType valueType, string valueString, DateTimeOffset? valueDate, TimeSpan? valueTime, string valuePhoneNumber, double? valueNumber, long? valueInteger, V3SelectionMarkState? valueSelectionMarkPrivate, DocumentSignatureType? valueSignature, string valueCountryRegion, IReadOnlyList<DocumentField> valueArray, IReadOnlyDictionary<string, DocumentField> valueObject, CurrencyValue? valueCurrency, AddressValue valueAddress, string content, IReadOnlyList<BoundingRegion> boundingRegions, IReadOnlyList<DocumentSpan> spans, float? confidence)
        {
            Value = new DocumentFieldValue(valueType, valueString, valueDate, valueTime, valuePhoneNumber, valueNumber, valueInteger, valueSelectionMarkPrivate, valueSignature, valueCountryRegion, valueArray, valueObject, valueCurrency, valueAddress);
            Content = content;
            BoundingRegions = boundingRegions;
            Spans = spans;
            Confidence = confidence;
        }

        /// <summary>
        /// Initializes a new instance of DocumentField. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentField(DocumentFieldValue value, string content, IReadOnlyList<BoundingRegion> boundingRegions, IReadOnlyList<DocumentSpan> spans, float? confidence)
        {
            Value = value;
            Content = content;
            BoundingRegions = boundingRegions;
            Spans = spans;
            Confidence = confidence;
        }

        /// <summary>
        /// The value of this <see cref="DocumentField"/>.
        /// </summary>
        public DocumentFieldValue Value { get; }

        // Even though we don't need it, keep property to force CodeGen to serialize it as a double instead of float.
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double? ValueNumber { get; }
    }
}
