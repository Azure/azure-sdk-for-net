// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Custom
{
    [CodeGenSchema("FormFieldsReport")]
    public partial class FieldPredictionAccuracy
    {
        [CodeGenSchemaMember("FieldName")]

        public string Label { get; internal set; }
    }
}
