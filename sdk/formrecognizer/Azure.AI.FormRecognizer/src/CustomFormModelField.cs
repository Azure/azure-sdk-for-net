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
        internal CustomFormModelField(string name, string label, float? accuracy)
            : this(name, accuracy)
        {
            Label = label;
        }
        /// <summary>
        /// </summary>
        [CodeGenMember("FieldName")]
        public string Name { get; }

        /// <summary> Estimated extraction accuracy for this field. </summary>
        [CodeGenMember("Accuracy")]
        public float? Accuracy { get; }

        /// <summary>
        /// </summary>
        public string Label { get; }
    }
}
