// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Custom
{

    [CodeGenModel("FormFieldsReport")]
    public partial class FieldPredictionAccuracy
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("FieldName")]
        public string Label { get; internal set; }
    }
}
