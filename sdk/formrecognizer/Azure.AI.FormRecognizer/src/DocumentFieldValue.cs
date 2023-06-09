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
        private DocumentSelectionMarkState? _mockValueSelectionMark;

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="expectedFieldType"> Data type of the field value. </param>
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
        /// <param name="valueBoolean"> Boolean value. </param>
        internal DocumentFieldValue(DocumentFieldType expectedFieldType, string valueString = null, DateTimeOffset? valueDate = null, TimeSpan? valueTime = null, string valuePhoneNumber = null, double? valueNumber = null, long? valueInteger = null, V3SelectionMarkState? valueSelectionMark = null, DocumentSignatureType? valueSignature = null, string valueCountryRegion = null, IReadOnlyList<DocumentField> valueArray = null, IReadOnlyDictionary<string, DocumentField> valueObject = null, CurrencyValue? valueCurrency = null, AddressValue valueAddress = null, bool? valueBoolean = null)
        {
            ExpectedFieldType = expectedFieldType;
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
            ValueBoolean = valueBoolean;
        }

        /// <summary>
        /// Initializes a new instance of DocumentFieldValue. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentFieldValue(DocumentSelectionMarkState value)
        {
            ExpectedFieldType = DocumentFieldType.SelectionMark;
            _mockValueSelectionMark = value;
        }

        /// <summary>
        /// The data type of the field value.
        /// </summary>
        internal DocumentFieldType FieldType => (InternalValue == null) ? DocumentFieldType.Unknown : ExpectedFieldType;

        /// <summary>
        /// The expected data type of the field value according to the document model used for analysis.
        /// </summary>
        private DocumentFieldType ExpectedFieldType { get; }

        #region Field Values
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
        private bool? ValueBoolean { get; }

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
        #endregion FieldValues

        private object InternalValue => ExpectedFieldType switch
        {
            DocumentFieldType.Address => ValueAddress,
            DocumentFieldType.Boolean => ValueBoolean,
            DocumentFieldType.CountryRegion => ValueCountryRegion,
            DocumentFieldType.Currency => ValueCurrency,
            DocumentFieldType.Date => ValueDate,
            DocumentFieldType.Dictionary => ValueObject,
            DocumentFieldType.Double => ValueNumber,
            DocumentFieldType.Int64 => ValueInteger,
            DocumentFieldType.List => ValueArray,
            DocumentFieldType.PhoneNumber => ValuePhoneNumber,
            DocumentFieldType.SelectionMark => ValueSelectionMark,
            DocumentFieldType.Signature => ValueSignature,
            DocumentFieldType.String => ValueString,
            DocumentFieldType.Time => ValueTime,
            _ => null
        };

        #region Conversion Methods
        /// <summary>
        /// Gets the value of the field as a <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.String"/>.</exception>
        public string AsString() => AssertFieldTypeAndGetValue(DocumentFieldType.String, ValueString);

        /// <summary>
        /// Gets the value of the field as a <see cref="long"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="long"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Int64"/> or when the value is <c>null</c>.</exception>
        public long AsInt64() => AssertFieldTypeAndGetValue(DocumentFieldType.Int64, ValueInteger);

        /// <summary>
        /// Gets the value of the field as a <see cref="double"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="double"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Double"/>.</exception>
        public double AsDouble() => AssertFieldTypeAndGetValue(DocumentFieldType.Double, ValueNumber);

        /// <summary>
        /// Gets the value of the field as a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="DateTimeOffset"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Date"/> or when the value is <c>null</c>.</exception>
        public DateTimeOffset AsDate() => AssertFieldTypeAndGetValue(DocumentFieldType.Date, ValueDate);

        /// <summary>
        /// Gets the value of the field as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="TimeSpan"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Time"/> or when the value is <c>null</c>.</exception>
        public TimeSpan AsTime() => AssertFieldTypeAndGetValue(DocumentFieldType.Time, ValueTime);

        /// <summary>
        /// Gets the value of the field as a phone number <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to a phone number <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.PhoneNumber"/>.</exception>
        public string AsPhoneNumber() => AssertFieldTypeAndGetValue(DocumentFieldType.PhoneNumber, ValuePhoneNumber);

        /// <summary>
        /// Gets the value of the field as an <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        /// <returns>The value of the field converted to an <see cref="IReadOnlyList{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.List"/>.</exception>
        public IReadOnlyList<DocumentField> AsList() => AssertFieldTypeAndGetValue(DocumentFieldType.List, ValueArray);

        /// <summary>
        /// Gets the value of the field as a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="Dictionary{TKey, TValue}"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Dictionary"/>.</exception>
        public IReadOnlyDictionary<string, DocumentField> AsDictionary() => AssertFieldTypeAndGetValue(DocumentFieldType.Dictionary, ValueObject);

        /// <summary>
        /// Gets the value of the field as a <see cref="DocumentSelectionMarkState"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="DocumentSelectionMarkState"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.SelectionMark"/>.</exception>
        public DocumentSelectionMarkState AsSelectionMarkState()
        {
            if (_mockValueSelectionMark.HasValue)
            {
                return _mockValueSelectionMark.Value;
            }

            AssertFieldType(DocumentFieldType.SelectionMark, ValueSelectionMark);

            if (ValueSelectionMark == V3SelectionMarkState.Selected)
            {
                return DocumentSelectionMarkState.Selected;
            }

            if (ValueSelectionMark == V3SelectionMarkState.Unselected)
            {
                return DocumentSelectionMarkState.Unselected;
            }

            throw new ArgumentOutOfRangeException($"Unknown {nameof(DocumentSelectionMarkState)} value: {ValueSelectionMark}");
        }

        /// <summary>
        /// Gets the value of the field as an ISO 3166-1 alpha-3 country code <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the field converted to an ISO 3166-1 alpha-3 country code <see cref="string"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.CountryRegion"/>.</exception>
        public string AsCountryRegion() => AssertFieldTypeAndGetValue(DocumentFieldType.CountryRegion, ValueCountryRegion);

        /// <summary>
        /// Gets the value of the field as a <see cref="DocumentSignatureType"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="DocumentSignatureType"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Signature"/>.</exception>
        public DocumentSignatureType AsSignatureType() => AssertFieldTypeAndGetValue(DocumentFieldType.Signature, ValueSignature);

        /// <summary>
        /// Gets the value of the field as a <see cref="CurrencyValue"/>.
        /// </summary>
        /// <returns>The value of the field converted to <see cref="CurrencyValue"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Currency"/>.</exception>
        public CurrencyValue AsCurrency() => AssertFieldTypeAndGetValue(DocumentFieldType.Currency, ValueCurrency);

        /// <summary>
        /// Gets the value of the field as an <see cref="AddressValue"/>.
        /// </summary>
        /// <returns>The value of the field converted to an <see cref="AddressValue"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Address"/>.</exception>
        public AddressValue AsAddress() => AssertFieldTypeAndGetValue(DocumentFieldType.Address, ValueAddress);

        /// <summary>
        /// Gets the value of the field as a <see cref="bool"/>.
        /// </summary>
        /// <returns>The value of the field converted to a <see cref="bool"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="FieldType"/> is not <see cref="DocumentFieldType.Boolean"/>.</exception>
        public bool AsBoolean() => AssertFieldTypeAndGetValue(DocumentFieldType.Boolean, ValueBoolean);
        #endregion Conversion Methods

        /// <summary>
        /// Returns a string that represents the <see cref="DocumentField"/> object.
        /// </summary>
        /// <returns>A string that represents the <see cref="DocumentField"/> object.</returns>
        public override string ToString()
        {
            string conversionMethod = ExpectedFieldType switch
            {
                DocumentFieldType.Address => nameof(AsAddress),
                DocumentFieldType.Boolean => nameof(AsBoolean),
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
                ? $"{nameof(DocumentField)}: {nameof(FieldType)}={DocumentFieldType.Unknown}"
                : $"{nameof(DocumentField)}: {nameof(FieldType)}={ExpectedFieldType}, {conversionMethod}()=>Value";
        }

        private void AssertFieldType<T>(DocumentFieldType requestedFieldType, T value)
        {
            if (requestedFieldType != ExpectedFieldType)
            {
                throw new InvalidOperationException($"Cannot get field as {requestedFieldType}. Field value's type is {ExpectedFieldType}.");
            }

            if (value == null)
            {
                throw new InvalidOperationException($"The value was extracted from the document, but cannot be normalized to {requestedFieldType}. Consider accessing the `DocumentField.Content` property for a textual representation of the value.");
            }
        }

        private T AssertFieldTypeAndGetValue<T>(DocumentFieldType requestedFieldType, T value) where T : class
        {
            AssertFieldType(requestedFieldType, value);
            return value;
        }

        private T AssertFieldTypeAndGetValue<T>(DocumentFieldType requestedFieldType, T? value) where T : struct
        {
            AssertFieldType(requestedFieldType, value);
            return value.Value;
        }
    }
}
