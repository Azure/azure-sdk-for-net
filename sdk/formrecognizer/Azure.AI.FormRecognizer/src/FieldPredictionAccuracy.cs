// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    [CodeGenModel("FormFieldsReport")]
    public partial class CustomFormModelField
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("FieldName")]
        public string Name { get; internal set; }

        /// <summary> Estimated extraction accuracy for this field. </summary>
        [CodeGenMember("Accuracy")]
        public float? Accuracy { get; }
    }
}
