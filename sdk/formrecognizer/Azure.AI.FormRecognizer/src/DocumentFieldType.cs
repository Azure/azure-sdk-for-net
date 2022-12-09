// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The type of the value of a <see cref="DocumentField"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1720:Identifier contains type name")]
    [CodeGenModel("DocumentFieldType")]
    public enum DocumentFieldType
    {
        /// <summary>
        /// Used when the value of the field could not be parsed by the service. The expected
        /// field type can be checked at <see cref="DocumentField.ExpectedFieldType"/>. Consider
        /// using <see cref="DocumentField.Content"/> to get a textual representation of the field
        /// and parsing it manually in this case.
        /// </summary>
        Unknown,

        /// <summary>
        /// Used for <see cref="string"/> type.
        /// </summary>
        String,

        /// <summary>
        /// Used for <see cref="DateTime"/> type.
        /// </summary>
        Date,

        /// <summary>
        /// Used for <see cref="TimeSpan"/> type.
        /// </summary>
        Time,

        /// <summary>
        /// Used for <see cref="string"/> type with a phone number format.
        /// </summary>
        PhoneNumber,

        /// <summary>
        /// Used for <see cref="double"/> type.
        /// </summary>
        [CodeGenMember("Number")]
        Double,

        /// <summary>
        /// Used for <see cref="long"/> type.
        /// </summary>
        [CodeGenMember("Integer")]
        Int64,

        /// <summary>
        /// Used for <see cref="List{T}"/> type.
        /// </summary>
        [CodeGenMember("Array")]
        List,

        /// <summary>
        /// Used for <see cref="Dictionary{TKey, TValue}"/> type.
        /// </summary>
        [CodeGenMember("Object")]
        Dictionary,

        /// <summary>
        /// Used for <see cref="DocumentSelectionMarkState"/> type.
        /// </summary>
        SelectionMark,

        /// <summary>
        /// Used for <see cref="string"/> type with an ISO 3166-1 alpha-3 country code.
        /// </summary>
        CountryRegion,

        /// <summary>
        /// Used for <see cref="DocumentSignatureType"/> type.
        /// </summary>
        Signature,

        /// <summary>
        /// Used for <see cref="CurrencyValue"/> type.
        /// </summary>
        Currency,

        /// <summary>
        /// Used for <see cref="AddressValue"/> type.
        /// </summary>
        Address
    }
}
