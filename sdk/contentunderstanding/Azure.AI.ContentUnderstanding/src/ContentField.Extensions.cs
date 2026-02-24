// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Extension methods and convenience properties for <see cref="ContentField"/>.
    /// </summary>
    public partial class ContentField
    {
        // CUSTOMIZATION: Replaces the generated Source (string) with parsed ContentSource[] property.
        // Wire format (string) preserved via internal backing property for serialization.
        [CodeGenMember("Source")]
        internal string SourceValue { get; }

#nullable enable
        /// <summary>
        /// Gets the parsed sources that identify the position of the field value in the content.
        /// Returns <c>null</c> if no source information is available.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The source is encoded as a string (e.g., <c>"D(1,0.5712,...)"</c>) in the service response.
        /// This property parses it into strongly-typed <see cref="ContentSource"/> instances:
        /// <see cref="DocumentSource"/> for document regions or <see cref="AudioVisualSource"/> for audio/video regions.
        /// </para>
        /// <para>
        /// Multiple regions separated by <c>;</c> are returned as separate array elements.
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// ContentField field = result.Fields["CustomerName"];
        /// if (field.Sources != null)
        /// {
        ///     foreach (var source in field.Sources)
        ///     {
        ///         if (source is DocumentSource doc)
        ///             Console.WriteLine($"Page {doc.PageNumber}, polygon: {string.Join(", ", doc.Polygon)}");
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <exception cref="FormatException"> The source string has an unrecognized prefix or is malformed. </exception>
        public ContentSource[]? Sources =>
            string.IsNullOrEmpty(SourceValue) ? null : ContentSource.ParseAll(SourceValue);
#nullable disable

        /// <summary>
        /// Gets the value of the field, regardless of its type.
        /// Returns the appropriate typed value for each field type:
        /// - <see cref="StringField"/>: returns <see cref="StringField.Value"/>
        /// - <see cref="NumberField"/>: returns <see cref="NumberField.Value"/>
        /// - <see cref="IntegerField"/>: returns <see cref="IntegerField.Value"/>
        /// - <see cref="DateTimeOffsetField"/>: returns <see cref="DateTimeOffsetField.Value"/>
        /// - <see cref="TimeField"/>: returns <see cref="TimeField.Value"/>
        /// - <see cref="BooleanField"/>: returns <see cref="BooleanField.Value"/>
        /// - <see cref="ObjectField"/>: returns <see cref="ObjectField.Value"/>
        /// - <see cref="ArrayField"/>: returns <see cref="ArrayField.Value"/>
        /// - <see cref="JsonField"/>: returns <see cref="JsonField.Value"/>
        /// </summary>
        /// <example>
        /// <code>
        /// // Simple field access
        /// var customerName = documentContent.Fields["CustomerName"].Value?.ToString();
        ///
        /// // Nested object access
        /// // Note: Use Value (not this Value) to access nested fields because this Value returns object,
        /// // which cannot be indexed with []. ObjectField.Value is the IDictionary&lt;string, ContentField&gt;.
        /// var totalAmountObj = (ObjectField)documentContent.Fields["TotalAmount"];
        /// var amount = totalAmountObj.Value["Amount"].Value;
        /// </code>
        /// </example>
        public object Value => this switch
        {
            StringField sf => sf.Value,
            NumberField nf => nf.Value,
            IntegerField inf => inf.Value,
            DateTimeOffsetField df => df.Value,
            TimeField tf => tf.Value,
            BooleanField bf => bf.Value,
            ObjectField of => of.Value,
            ArrayField af => af.Value,
            JsonField jf => jf.Value,
            _ => null
        };
    }
}
