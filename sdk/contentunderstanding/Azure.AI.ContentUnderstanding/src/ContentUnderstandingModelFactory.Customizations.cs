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
    [CodeGenSuppress("StringField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(string))]
    [CodeGenSuppress("NumberField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(double?))]
    [CodeGenSuppress("IntegerField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(long?))]
    [CodeGenSuppress("BooleanField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(bool?))]
    [CodeGenSuppress("TimeField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(TimeSpan?))]
    [CodeGenSuppress("DateTimeOffsetField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(DateTimeOffset?))]
    [CodeGenSuppress("JsonField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(BinaryData))]
    [CodeGenSuppress("ArrayField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(IEnumerable<ContentField>))]
    [CodeGenSuppress("ObjectField", typeof(IEnumerable<ContentSpan>), typeof(float?), typeof(string), typeof(IDictionary<string, ContentField>))]
    public static partial class ContentUnderstandingModelFactory
    {
        /// <summary> Creates a new <see cref="ContentUnderstanding.StringField"/> for mocking. </summary>
        public static StringField StringField(string? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new StringField(ContentFieldType.String, spans.ToList(), confidence, source!, null!, value!);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.NumberField"/> for mocking. </summary>
        public static NumberField NumberField(double? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new NumberField(ContentFieldType.Number, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.IntegerField"/> for mocking. </summary>
        public static IntegerField IntegerField(long? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new IntegerField(ContentFieldType.Integer, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.BooleanField"/> for mocking. </summary>
        public static BooleanField BooleanField(bool? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new BooleanField(ContentFieldType.Boolean, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.TimeField"/> for mocking. </summary>
        public static TimeField TimeField(TimeSpan? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new TimeField(ContentFieldType.Time, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.DateTimeOffsetField"/> for mocking. </summary>
        public static DateTimeOffsetField DateTimeOffsetField(DateTimeOffset? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new DateTimeOffsetField(ContentFieldType.Date, spans.ToList(), confidence, source!, null!, value);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.JsonField"/> for mocking. </summary>
        public static JsonField JsonField(BinaryData? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new JsonField(ContentFieldType.Json, spans.ToList(), confidence, source!, null!, value!);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ArrayField"/> for mocking. </summary>
        public static ArrayField ArrayField(IList<ContentField>? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ArrayField(ContentFieldType.Array, spans.ToList(), confidence, source!, null!, value?.ToList()!);
        }

        /// <summary> Creates a new <see cref="ContentUnderstanding.ObjectField"/> for mocking. </summary>
        public static ObjectField ObjectField(IDictionary<string, ContentField>? value = default, IEnumerable<ContentSpan>? spans = default, float? confidence = default, string? source = default)
        {
            spans ??= new ChangeTrackingList<ContentSpan>();
            return new ObjectField(ContentFieldType.Object, spans.ToList(), confidence, source!, null!, value!);
        }
    }
}
