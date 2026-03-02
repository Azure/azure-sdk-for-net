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
        // CUSTOMIZATION: The service returns "source" as a single string (e.g., "D(1,0.5712,...);D(2,...)")
        // which we parse into strongly-typed ContentSource[] via the public Sources property.
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
            string.IsNullOrEmpty(SourceValue) ? null : ContentSource.Parse(SourceValue);
#nullable disable

        /// <summary>
        /// Gets the value of the field, regardless of its type.
        /// Returns the appropriate typed value for each field type:
        /// - <see cref="ContentStringField"/>: returns <see cref="ContentStringField.Value"/>
        /// - <see cref="ContentNumberField"/>: returns <see cref="ContentNumberField.Value"/>
        /// - <see cref="ContentIntegerField"/>: returns <see cref="ContentIntegerField.Value"/>
        /// - <see cref="ContentDateTimeOffsetField"/>: returns <see cref="ContentDateTimeOffsetField.Value"/>
        /// - <see cref="ContentTimeField"/>: returns <see cref="ContentTimeField.Value"/>
        /// - <see cref="ContentBooleanField"/>: returns <see cref="ContentBooleanField.Value"/>
        /// - <see cref="ContentObjectField"/>: returns <see cref="ContentObjectField.Value"/>
        /// - <see cref="ContentArrayField"/>: returns <see cref="ContentArrayField.Value"/>
        /// - <see cref="ContentJsonField"/>: returns <see cref="ContentJsonField.Value"/>
        /// </summary>
        /// <example>
        /// <code>
        /// // Simple field access
        /// var customerName = result.Fields["CustomerName"].Value?.ToString();
        ///
        /// // Nested object access via indexer
        /// var totalAmount = (ContentObjectField)result.Fields["TotalAmount"];
        /// var amount = totalAmount["Amount"].Value;
        /// </code>
        /// </example>
        public object Value => this switch
        {
            ContentStringField sf => sf.Value,
            ContentNumberField nf => nf.Value,
            ContentIntegerField inf => inf.Value,
            ContentDateTimeOffsetField df => df.Value,
            ContentTimeField tf => tf.Value,
            ContentBooleanField bf => bf.Value,
            ContentObjectField of => of.Value,
            ContentArrayField af => af.Value,
            ContentJsonField jf => jf.Value,
            _ => null
        };
    }
}
