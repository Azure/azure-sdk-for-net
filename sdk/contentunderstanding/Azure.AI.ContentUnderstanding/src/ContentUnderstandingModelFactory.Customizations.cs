// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentUnderstanding
{
    // Customization: factory methods use "value" param name instead of "valueString", "valueNumber", etc.
    // Suppress generated factory methods that use wire-format param names.
    [CodeGenSuppress("ContentStringField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(string))]
    [CodeGenSuppress("ContentNumberField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(double?))]
    [CodeGenSuppress("ContentIntegerField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(long?))]
    [CodeGenSuppress("ContentBooleanField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(bool?))]
    [CodeGenSuppress("ContentTimeField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(TimeSpan?))]
    [CodeGenSuppress("ContentDateTimeOffsetField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(DateTimeOffset?))]
    [CodeGenSuppress("ContentJsonField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(BinaryData))]
    [CodeGenSuppress("ContentArrayField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(IEnumerable<ContentField>))]
    [CodeGenSuppress("ContentObjectField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(IDictionary<string, ContentField>))]
    public static partial class ContentUnderstandingModelFactory
    {
        /// <summary> Creates a new <see cref="ContentUnderstanding.ContentStringField"/> for mocking. </summary>
        public static ContentStringField ContentStringField(string? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ContentStringField(ContentFieldType.String, spans.ToList(), confidence, source!, null!, value!);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ContentNumberField"/> for mocking. </summary>
        public static ContentNumberField ContentNumberField(double? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ContentNumberField(ContentFieldType.Number, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ContentIntegerField"/> for mocking. </summary>
        public static ContentIntegerField ContentIntegerField(long? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ContentIntegerField(ContentFieldType.Integer, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ContentBooleanField"/> for mocking. </summary>
        public static ContentBooleanField ContentBooleanField(bool? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ContentBooleanField(ContentFieldType.Boolean, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ContentTimeField"/> for mocking. </summary>
        public static ContentTimeField ContentTimeField(TimeSpan? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ContentTimeField(ContentFieldType.Time, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ContentDateTimeOffsetField"/> for mocking. </summary>
        public static ContentDateTimeOffsetField ContentDateTimeOffsetField(DateTimeOffset? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ContentDateTimeOffsetField(ContentFieldType.Date, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ContentJsonField"/> for mocking. </summary>
        public static ContentJsonField ContentJsonField(BinaryData? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ContentJsonField(ContentFieldType.Json, spans.ToList(), confidence, source!, null!, value!);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ContentArrayField"/> for mocking. </summary>
        public static ContentArrayField ContentArrayField(IList<ContentField>? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ContentArrayField(ContentFieldType.Array, spans.ToList(), confidence, source!, null!, value?.ToList()!);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ContentObjectField"/> for mocking. </summary>
        public static ContentObjectField ContentObjectField(IDictionary<string, ContentField>? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ContentObjectField(ContentFieldType.Object, spans.ToList(), confidence, source!, null!, value!);
        }
    }
}
