// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormField
    {
#pragma warning disable CA1801
        internal FormField(KeyValuePair_internal field, ReadResult_internal readResult)
        {
#pragma warning restore CA1801
            //Confidence = field.Confidence;

            //Name = field.Key.Text;
            //NameBoundingBox = new BoundingBox(field.Key.BoundingBox);

            //if (field.Key.Elements != null)
            //{
            //    NameTextElements = ConvertTextReferences(readResult, field.Key.Elements);
            //}

            //Value = field.Value.Text;
            //ValueBoundingBox = new BoundingBox(field.Value.BoundingBox);

            //if (field.Value.Elements != null)
            //{
            //    ValueTextElements = ConvertTextReferences(readResult, field.Value.Elements);
            //}
        }

        /// <summary>
        /// Canonical name; uniquely identifies a field within the form.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Text from the form that labels the form field.
        /// </summary>
        public FieldText FieldLabel { get; internal set; }

        /// <summary>
        /// </summary>
        public FieldText ValueText { get; internal set; }

        /// <summary>
        /// </summary>
        public FieldValue Value { get; internal set; }

        /// <summary>
        /// </summary>
        public float? Confidence { get; }
    }
}
