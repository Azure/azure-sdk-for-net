// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentField")]
    public partial class DocumentField
    {
        /// <summary>
        /// Initializes a new instance of DocumentField. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentField(SelectionMarkState? value, string content, IReadOnlyList<BoundingRegion> boundingRegions, IReadOnlyList<DocumentSpan> spans, float? confidence)
        {
            ValueType = DocumentFieldType.SelectionMark;
            ValueSelectionMark = value;
            ValueArray = new List<DocumentField>();
            ValueObject = new Dictionary<string, DocumentField>();
            Content = content;
            BoundingRegions = boundingRegions;
            Spans = spans;
            Confidence = confidence;
        }

        /// <summary>
        /// The data type of the field value.
        /// </summary>
        [CodeGenMember("Type")]
        public DocumentFieldType ValueType { get; }

        private string ValueString { get; }

        private DateTimeOffset? ValueDate { get; }

        private TimeSpan? ValueTime { get; }

        private string ValuePhoneNumber { get; }

        private double? ValueNumber { get; }

        private int? ValueInteger { get; }

        private SelectionMarkState? ValueSelectionMark { get; set; }

        private AddressValue ValueAddress { get; }

        [CodeGenMember("ValueSelectionMark")]
        private V3SelectionMarkState? ValueSelectionMarkPrivate
        {
            get => throw new InvalidOperationException();
            set
            {
                if (value == null)
                {
                    ValueSelectionMark = null;
                }
                else if (value == V3SelectionMarkState.Selected)
                {
                    ValueSelectionMark = SelectionMarkState.Selected;
                }
                else if (value == V3SelectionMarkState.Unselected)
                {
                    ValueSelectionMark = SelectionMarkState.Unselected;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Unknown {nameof(SelectionMarkState)} value: {value}");
                }
            }
        }

        private DocumentSignatureType? ValueSignature { get; }

        private string ValueCountryRegion { get; }

        private CurrencyValue? ValueCurrency { get; }

        private IReadOnlyList<DocumentField> ValueArray { get; }

        private IReadOnlyDictionary<string, DocumentField> ValueObject { get; }

        /// <summary>
        /// Gets the value of the field as a <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.String"/>.</exception>
        public string AsString()
        {
            if (ValueType != DocumentFieldType.String)
            {
                throw new InvalidOperationException($"Cannot get field as String.  Field value's type is {ValueType}.");
            }

            return ValueString;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="long"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="long"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.Int64"/> or when the value is <c>null</c>.</exception>
        public long AsInt64()
        {
            if (ValueType != DocumentFieldType.Int64)
            {
                throw new InvalidOperationException($"Cannot get field as Integer.  Field value's type is {ValueType}.");
            }

            if (!ValueInteger.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.Int64)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            return ValueInteger.Value;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="double"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="double"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.Double"/>.</exception>
        public double AsDouble()
        {
            if (ValueType != DocumentFieldType.Double)
            {
                throw new InvalidOperationException($"Cannot get field as Double.  Field value's type is {ValueType}.");
            }

            if (!ValueNumber.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.Double)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            return ValueNumber.Value;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="DateTime"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="DateTime"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.Date"/> or when the value is <c>null</c>.</exception>
        public DateTime AsDate()
        {
            if (ValueType != DocumentFieldType.Date)
            {
                throw new InvalidOperationException($"Cannot get field as Date.  Field value's type is {ValueType}.");
            }

            if (!ValueDate.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.Date)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            return ValueDate.Value.UtcDateTime;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="TimeSpan"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.Time"/> or when the value is <c>null</c>.</exception>
        public TimeSpan AsTime()
        {
            if (ValueType != DocumentFieldType.Time)
            {
                throw new InvalidOperationException($"Cannot get field as Time.  Field value's type is {ValueType}.");
            }

            if (!ValueTime.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.Time)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            return ValueTime.Value;
        }

        /// <summary>
        /// Gets the value of the field as a phone number <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to a phone number <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.PhoneNumber"/>.</exception>
        public string AsPhoneNumber()
        {
            if (ValueType != DocumentFieldType.PhoneNumber)
            {
                throw new InvalidOperationException($"Cannot get field as PhoneNumber.  Field value's type is {ValueType}.");
            }

            return ValuePhoneNumber;
        }

        /// <summary>
        /// Gets the value of the field as an <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        /// <returns>The value of the field converted to an <see cref="IReadOnlyList{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.List"/>.</exception>
        public IReadOnlyList<DocumentField> AsList()
        {
            if (ValueType != DocumentFieldType.List)
            {
                throw new InvalidOperationException($"Cannot get field as List.  Field value's type is {ValueType}.");
            }

            return ValueArray;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="Dictionary{TKey, TValue}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.Dictionary"/>.</exception>
        public IReadOnlyDictionary<string, DocumentField> AsDictionary()
        {
            if (ValueType != DocumentFieldType.Dictionary)
            {
                throw new InvalidOperationException($"Cannot get field as Dictionary.  Field value's type is {ValueType}.");
            }

            return ValueObject;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="SelectionMarkState"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="SelectionMarkState"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.SelectionMark"/>.</exception>
        public SelectionMarkState AsSelectionMarkState()
        {
            if (ValueType != DocumentFieldType.SelectionMark)
            {
                throw new InvalidOperationException($"Cannot get field as SelectionMark.  Field value's type is {ValueType}.");
            }

            if (!ValueSelectionMark.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.SelectionMark)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            return ValueSelectionMark.Value;
        }

        /// <summary>
        /// Gets the value of the field as an ISO 3166-1 alpha-3 country code <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to an ISO 3166-1 alpha-3 country code <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.CountryRegion"/>.</exception>
        public string AsCountryRegion()
        {
            if (ValueType != DocumentFieldType.CountryRegion)
            {
                throw new InvalidOperationException($"Cannot get field as country code.  Field value's type is {ValueType}.");
            }

            return ValueCountryRegion;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="DocumentSignatureType"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="DocumentSignatureType"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.Signature"/>.</exception>
        public DocumentSignatureType AsSignatureType()
        {
            if (ValueType != DocumentFieldType.Signature)
            {
                throw new InvalidOperationException($"Cannot get field as signature.  Field value's type is {ValueType}.");
            }

            if (!ValueSignature.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.Signature)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            return ValueSignature.Value;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="CurrencyValue"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="CurrencyValue"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.Currency"/>.</exception>
        public CurrencyValue AsCurrency()
        {
            if (ValueType != DocumentFieldType.Currency)
            {
                throw new InvalidOperationException($"Cannot get field as currency.  Field value's type is {ValueType}.");
            }

            if (!ValueCurrency.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.Currency)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            return ValueCurrency.Value;
        }

        /// <summary>
        /// Gets the value of the field as an <see cref="AddressValue"/>.
        /// </summary>
        /// <returns>The value of the field converted to an <see cref="AddressValue"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="ValueType"/> is not <see cref="DocumentFieldType.Address"/>.</exception>
        public AddressValue AsAddress()
        {
            if (ValueType != DocumentFieldType.Address)
            {
                throw new InvalidOperationException($"Cannot get field as address.  Field value's type is {ValueType}.");
            }

            return ValueAddress;
        }
    }
}
