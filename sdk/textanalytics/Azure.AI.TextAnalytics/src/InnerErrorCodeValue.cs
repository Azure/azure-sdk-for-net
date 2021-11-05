// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("InnerErrorCodeValue")]
    internal enum InnerErrorCodeValue
    {
        /// <summary> invalidParameterValue. </summary>
        InvalidParameterValue,
        /// <summary> invalidRequestBodyFormat. </summary>
        InvalidRequestBodyFormat,
        /// <summary> emptyRequest. </summary>
        EmptyRequest,
        /// <summary> missingInputRecords. </summary>
        MissingInputRecords,
        /// <summary> invalidDocument. </summary>
        InvalidDocument,
        /// <summary> modelVersionIncorrect. </summary>
        ModelVersionIncorrect,
        /// <summary> invalidDocumentBatch. </summary>
        InvalidDocumentBatch,
        /// <summary> unsupportedLanguageCode. </summary>
        UnsupportedLanguageCode,
        /// <summary> invalidCountryHint. </summary>
        InvalidCountryHint
    }
}
