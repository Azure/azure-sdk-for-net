// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a field recognized in the input form, where the field's value is of a known type.
    /// </summary>
    /// <typeparam name="T">The type of the value in the field this instance represents.</typeparam>
    /// <remarks>
    /// This class is used in place of a generic <see cref="FormField"/> when its value
    /// has a known type.
    /// </remarks>
    public class FormField<T>
    {
        internal FormField(T value)
        {
            Value = value;
        }

        internal FormField(FormField field, T value)
        {
            Confidence = field.Confidence;
            LabelText = field.LabelText;
            Name = field.Name;
            ValueText = field.ValueText;
            Value = value;
        }

        /// <summary>
        /// Canonical name; uniquely identifies a field within the form.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Contains the text, bounding box and content of the label of the field in the form.
        /// </summary>
        public FieldText LabelText { get; internal set; }

        /// <summary>
        /// Contains the text, bounding box and content of the value of the field in the form.
        /// </summary>
        public FieldText ValueText { get; internal set; }

        /// <summary>
        /// The strongly-typed value of this <see cref="FormField{T}"/>.
        /// </summary>
        public T Value { get; internal set; }

        /// <summary>
        /// Measures the degree of certainty of the recognition result. Value is between [0.0, 1.0].
        /// </summary>
        public float Confidence { get; }

        /// <summary>
        /// Implicitly converts a <see cref="FormField{T}"/> instance into a <typeparamref name="T"/>, using the
        /// value returned by <see cref="Value"/>.
        /// </summary>
        /// <param name="field">The instance to be converted into a <typeparamref name="T"/>.</param>
        /// <returns>The <typeparamref name="T"/> corresponding to the value of the specified <see cref="FormField"/> instance.</returns>
        public static implicit operator T(FormField<T> field) => field.Value;
    }
}
