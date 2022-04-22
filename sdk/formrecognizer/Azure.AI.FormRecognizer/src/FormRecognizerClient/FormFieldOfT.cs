// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a field recognized in the input form, where the field's value is of a known type.
    /// </summary>
    /// <typeparam name="T">The type of the value in the field this instance represents.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public class FormField<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormField{T}"/> class which
        /// represents a field recognized in the input form, where the field's value is of a known type.
        /// </summary>
        /// <param name="field">The weakly-typed field this instance is associated with.</param>
        /// <param name="value">The strongly-typed value of this <see cref="FormField{T}"/>.</param>
        public FormField(FormField field, T value)
        {
            Confidence = field.Confidence;
            LabelData = field.LabelData;
            Name = field.Name;
            ValueData = field.ValueData;
            Value = value;
        }

        /// <summary>
        /// Canonical name; uniquely identifies a field within the form.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Contains the text, bounding box and content of the label of the field in the form.
        /// </summary>
        public FieldData LabelData { get; }

        /// <summary>
        /// Contains the text, bounding box and content of the value of the field in the form.
        /// </summary>
        public FieldData ValueData { get; }

        /// <summary>
        /// The strongly-typed value of this <see cref="FormField{T}"/>.
        /// </summary>
        public T Value { get; }

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
