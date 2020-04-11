// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FormField<T>
    {
        internal FormField(T value)
        {
            Value = value;
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
        public T Value { get; internal set; }

        /// <summary>
        /// </summary>
        public float? Confidence { get; }

        /// <summary>
        /// </summary>
        public int? PageNumber { get; internal set; }

        /// <summary>
        /// </summary>
        /// <param name="field"></param>
        public static implicit operator T(FormField<T> field) => field.Value;
    }
}
