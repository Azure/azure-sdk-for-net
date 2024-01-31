// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenSuppress(nameof(DocumentField), typeof(DocumentFieldType), typeof(string), typeof(DateTimeOffset?), typeof(TimeSpan?), typeof(string), typeof(double?), typeof(long?), typeof(V3SelectionMarkState?), typeof(DocumentSignatureType?), typeof(string), typeof(IReadOnlyList<DocumentField>), typeof(IReadOnlyDictionary<string, DocumentField>), typeof(CurrencyValue?), typeof(AddressValue), typeof(bool?), typeof(string), typeof(IReadOnlyList<BoundingRegion>), typeof(IReadOnlyList<DocumentSpan>), typeof(float?))]
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
    [CodeGenSuppress("ValueBoolean")]
    public partial class DocumentField
    {
        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="expectedFieldType"> Data type of the field value. </param>
        internal DocumentField(DocumentFieldType expectedFieldType)
        {
            ExpectedFieldType = expectedFieldType;
            Value = new DocumentFieldValue(expectedFieldType);
            BoundingRegions = new ChangeTrackingList<BoundingRegion>();
            Spans = new ChangeTrackingList<DocumentSpan>();
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="expectedFieldType"> Data type of the field value. </param>
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
        /// <param name="valueBoolean"> Boolean value. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        internal DocumentField(DocumentFieldType expectedFieldType, string valueString, DateTimeOffset? valueDate, TimeSpan? valueTime, string valuePhoneNumber, double? valueNumber, long? valueInteger, V3SelectionMarkState? valueSelectionMarkPrivate, DocumentSignatureType? valueSignature, string valueCountryRegion, IReadOnlyList<DocumentField> valueArray, IReadOnlyDictionary<string, DocumentField> valueObject, CurrencyValue? valueCurrency, AddressValue valueAddress, bool? valueBoolean, string content, IReadOnlyList<BoundingRegion> boundingRegions, IReadOnlyList<DocumentSpan> spans, float? confidence)
        {
            ExpectedFieldType = expectedFieldType;
            Value = new DocumentFieldValue(expectedFieldType, valueString, valueDate, valueTime, valuePhoneNumber, valueNumber, valueInteger, valueSelectionMarkPrivate, valueSignature, valueCountryRegion, valueArray, valueObject, valueCurrency, valueAddress, valueBoolean);
            Content = content;
            BoundingRegions = boundingRegions;
            Spans = spans;
            Confidence = confidence;
        }

        /// <summary>
        /// Initializes a new instance of DocumentField. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentField(DocumentFieldType expectedFieldType, DocumentFieldValue value, string content, IReadOnlyList<BoundingRegion> boundingRegions, IReadOnlyList<DocumentSpan> spans, float? confidence)
        {
            ExpectedFieldType = expectedFieldType;
            Value = value;
            Content = content;
            BoundingRegions = boundingRegions;
            Spans = spans;
            Confidence = confidence;
        }

        /// <summary>
        /// The data type of the field value. If <see cref="DocumentFieldType.Unknown"/>,
        /// it means the value of the field could not be parsed by the service. The expected
        /// field type can be checked at <see cref="ExpectedFieldType"/>. Consider using
        /// <see cref="Content"/> to get a textual representation of the field and parsing it
        /// manually in this case.
        /// </summary>
        public DocumentFieldType FieldType => Value.FieldType;

        /// <summary>
        /// The expected data type of the field value according to the document model used for analysis.
        /// </summary>
        [CodeGenMember("Type")]
        public DocumentFieldType ExpectedFieldType { get; }

        /// <summary>
        /// The value of this <see cref="DocumentField"/>.
        /// </summary>
        public DocumentFieldValue Value { get; }

        // Even though we don't need it, keep property to force CodeGen to serialize it as a double instead of float.
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double? ValueNumber { get; }
    }
}
