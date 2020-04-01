// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{

    [CodeGenSchema("FormFieldsReport")]
    public partial class CustomFormModelField
    {
        /// <summary>
        /// </summary>
        [CodeGenSchemaMember("FieldName")]
        public string Label { get; internal set; }

        /// <summary> Estimated extraction accuracy for this field. </summary>
        [CodeGenSchemaMember("Accuracy")]
        public float? Accuracy { get; }
    }
}
