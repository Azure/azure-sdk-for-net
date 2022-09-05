// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// Represents the value of a field analyzed from the input document and provides
    /// methods for converting it to the appropriate type.
    /// </summary>
    public class DocumentFieldValue
    {
        private SelectionMarkState? _mockValueSelectionMark;

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="fieldType"> Data type of the field value. </param>
        /// <param name="valueString"> String value. </param>
        /// <param name="valueDate"> Date value in YYYY-MM-DD format (ISO 8601). </param>
        /// <param name="valueTime"> Time value in hh:mm:ss format (ISO 8601). </param>
        /// <param name="valuePhoneNumber"> Phone number value in E.164 format (ex. +19876543210). </param>
        /// <param name="valueNumber"> Floating point value. </param>
        /// <param name="valueInteger"> Integer value. </param>
        /// <param name="valueSelectionMark"> Selection mark value. </param>
        /// <param name="valueSignature"> Presence of signature. </param>
        /// <param name="valueCountryRegion"> 3-letter country code value (ISO 3166-1 alpha-3). </param>
        /// <param name="valueArray"> Array of field values. </param>
        /// <param name="valueObject"> Dictionary of named field values. </param>
        /// <param name="valueCurrency"> Currency value. </param>
        /// <param name="valueAddress"> Address value. </param>
        internal DocumentFieldValue(DocumentFieldType fieldType, string valueString = null, DateTimeOffset? valueDate = null, TimeSpan? valueTime = null, string valuePhoneNumber = null, double? valueNumber = null, long? valueInteger = null, V3SelectionMarkState? valueSelectionMark = null, DocumentSignatureType? valueSignature = null, string valueCountryRegion = null, IReadOnlyList<DocumentField> valueArray = null, IReadOnlyDictionary<string, DocumentField> valueObject = null, CurrencyValue? valueCurrency = null, AddressValue valueAddress = null)
        {
            FieldType = fieldType;
            ValueString = valueString;
            ValueDate = valueDate;
            ValueTime = valueTime;
            ValuePhoneNumber = valuePhoneNumber;
            ValueNumber = valueNumber;
            ValueInteger = valueInteger;
            ValueSelectionMark = valueSelectionMark;
            ValueSignature = valueSignature;
            ValueCountryRegion = valueCountryRegion;
            ValueArray = valueArray;
            ValueObject = valueObject;
            ValueCurrency = valueCurrency;
            ValueAddress = valueAddress;
        }

        /// <summary>
        /// Initializes a new instance of DocumentFieldValue. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentFieldValue(SelectionMarkState? value)
        {
            FieldType = DocumentFieldType.SelectionMark;
            _mockValueSelectionMark = value;
        }

        /// <summary>
        /// The data type of the field value.
        /// </summary>
        private DocumentFieldType FieldType { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string ValueString { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DateTimeOffset? ValueDate { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TimeSpan? ValueTime { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string ValuePhoneNumber { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double? ValueNumber { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private long? ValueInteger { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddressValue ValueAddress { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private V3SelectionMarkState? ValueSelectionMark { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DocumentSignatureType? ValueSignature { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string ValueCountryRegion { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CurrencyValue? ValueCurrency { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IReadOnlyList<DocumentField> ValueArray { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IReadOnlyDictionary<string, DocumentField> ValueObject { get; }

        /// <summary>
        /// Gets the value of the field as a <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.String"/>.</exception>
        public string AsString()
        {
            if (FieldType != DocumentFieldType.String)
            {
                throw new InvalidOperationException($"Cannot get field as String.  Field value's type is {FieldType}.");
            }

            return ValueString;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="long"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="long"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Int64"/> or when the value is <c>null</c>.</exception>
        public long AsInt64()
        {
            if (FieldType != DocumentFieldType.Int64)
            {
                throw new InvalidOperationException($"Cannot get field as Integer.  Field value's type is {FieldType}.");
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
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Double"/>.</exception>
        public double AsDouble()
        {
            if (FieldType != DocumentFieldType.Double)
            {
                throw new InvalidOperationException($"Cannot get field as Double.  Field value's type is {FieldType}.");
            }

            if (!ValueNumber.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.Double)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            return ValueNumber.Value;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="DateTimeOffset"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Date"/> or when the value is <c>null</c>.</exception>
        public DateTimeOffset AsDate()
        {
            if (FieldType != DocumentFieldType.Date)
            {
                throw new InvalidOperationException($"Cannot get field as Date.  Field value's type is {FieldType}.");
            }

            if (!ValueDate.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.Date)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            return ValueDate.Value;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="TimeSpan"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Time"/> or when the value is <c>null</c>.</exception>
        public TimeSpan AsTime()
        {
            if (FieldType != DocumentFieldType.Time)
            {
                throw new InvalidOperationException($"Cannot get field as Time.  Field value's type is {FieldType}.");
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
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.PhoneNumber"/>.</exception>
        public string AsPhoneNumber()
        {
            if (FieldType != DocumentFieldType.PhoneNumber)
            {
                throw new InvalidOperationException($"Cannot get field as PhoneNumber.  Field value's type is {FieldType}.");
            }

            return ValuePhoneNumber;
        }

        /// <summary>
        /// Gets the value of the field as an <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        /// <returns>The value of the field converted to an <see cref="IReadOnlyList{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.List"/>.</exception>
        public IReadOnlyList<DocumentField> AsList()
        {
            if (FieldType != DocumentFieldType.List)
            {
                throw new InvalidOperationException($"Cannot get field as List.  Field value's type is {FieldType}.");
            }

            return ValueArray;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="Dictionary{TKey, TValue}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Dictionary"/>.</exception>
        public IReadOnlyDictionary<string, DocumentField> AsDictionary()
        {
            if (FieldType != DocumentFieldType.Dictionary)
            {
                throw new InvalidOperationException($"Cannot get field as Dictionary.  Field value's type is {FieldType}.");
            }

            return ValueObject;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="SelectionMarkState"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="SelectionMarkState"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.SelectionMark"/>.</exception>
        public SelectionMarkState AsSelectionMarkState()
        {
            if (FieldType != DocumentFieldType.SelectionMark)
            {
                throw new InvalidOperationException($"Cannot get field as SelectionMark.  Field value's type is {FieldType}.");
            }

            if (_mockValueSelectionMark.HasValue)
            {
                return _mockValueSelectionMark.Value;
            }

            if (!ValueSelectionMark.HasValue)
            {
                throw new InvalidOperationException($"Value was extracted from the document, but cannot be normalized to {nameof(DocumentFieldType.SelectionMark)} type. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }

            if (ValueSelectionMark == V3SelectionMarkState.Selected)
            {
                return SelectionMarkState.Selected;
            }

            if (ValueSelectionMark == V3SelectionMarkState.Unselected)
            {
                return SelectionMarkState.Unselected;
            }

            throw new ArgumentOutOfRangeException($"Unknown {nameof(SelectionMarkState)} value: {ValueSelectionMark}");
        }

        /// <summary>
        /// Gets the value of the field as an ISO 3166-1 alpha-3 country code <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to an ISO 3166-1 alpha-3 country code <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.CountryRegion"/>.</exception>
        public string AsCountryRegion()
        {
            if (FieldType != DocumentFieldType.CountryRegion)
            {
                throw new InvalidOperationException($"Cannot get field as country code.  Field value's type is {FieldType}.");
            }

            return ValueCountryRegion;
        }

        /// <summary>
        /// Gets the value of the field as a <see cref="DocumentSignatureType"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="DocumentSignatureType"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Signature"/>.</exception>
        public DocumentSignatureType AsSignatureType()
        {
            if (FieldType != DocumentFieldType.Signature)
            {
                throw new InvalidOperationException($"Cannot get field as signature.  Field value's type is {FieldType}.");
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
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Currency"/>.</exception>
        public CurrencyValue AsCurrency()
        {
            if (FieldType != DocumentFieldType.Currency)
            {
                throw new InvalidOperationException($"Cannot get field as currency.  Field value's type is {FieldType}.");
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
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Address"/>.</exception>
        public AddressValue AsAddress()
        {
            if (FieldType != DocumentFieldType.Address)
            {
                throw new InvalidOperationException($"Cannot get field as address.  Field value's type is {FieldType}.");
            }

            return ValueAddress;
        }

        /// <summary>
        /// Returns a string that represents the <see cref="DocumentField"/> object.
        /// </summary>
        /// <returns>A string that represents the <see cref="DocumentField"/> object.</returns>
        public override string ToString()
        {
            string conversionMethod = FieldType switch
            {
                DocumentFieldType.Address => nameof(AsAddress),
                DocumentFieldType.CountryRegion => nameof(AsCountryRegion),
                DocumentFieldType.Currency => nameof(AsCurrency),
                DocumentFieldType.Date => nameof(AsDate),
                DocumentFieldType.Dictionary => nameof(AsDictionary),
                DocumentFieldType.Double => nameof(AsDouble),
                DocumentFieldType.Int64 => nameof(AsInt64),
                DocumentFieldType.List => nameof(AsList),
                DocumentFieldType.PhoneNumber => nameof(AsPhoneNumber),
                DocumentFieldType.SelectionMark => nameof(AsSelectionMarkState),
                DocumentFieldType.Signature => nameof(AsSignatureType),
                DocumentFieldType.String => nameof(AsString),
                DocumentFieldType.Time => nameof(AsTime),
                _ => null
            };

            return conversionMethod == null
                ? $"{nameof(DocumentField)}: {nameof(FieldType)}={FieldType}"
                : $"{nameof(DocumentField)}: {nameof(FieldType)}={FieldType}, {conversionMethod}()=>Value";
        }

        private object InternalValue => FieldType switch
        {
            DocumentFieldType.Address => AsAddress(),
            DocumentFieldType.CountryRegion => AsCountryRegion(),
            DocumentFieldType.Currency => AsCurrency(),
            DocumentFieldType.Date => AsDate(),
            DocumentFieldType.Dictionary => AsDictionary(),
            DocumentFieldType.Double => AsDouble(),
            DocumentFieldType.Int64 => AsInt64(),
            DocumentFieldType.List => AsList(),
            DocumentFieldType.PhoneNumber => AsPhoneNumber(),
            DocumentFieldType.SelectionMark => AsSelectionMarkState(),
            DocumentFieldType.Signature => AsSignatureType(),
            DocumentFieldType.String => AsString(),
            DocumentFieldType.Time => AsTime(),
            _ => null
        };
    }
}
