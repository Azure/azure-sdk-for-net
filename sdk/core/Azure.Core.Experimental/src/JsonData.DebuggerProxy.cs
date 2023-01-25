// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Dynamic
{
    public partial class JsonData
    {
        //internal class JsonDataDebuggerProxy
        //{
        //    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //    private readonly JsonData _jsonData;

        //    public JsonDataDebuggerProxy(JsonData jsonData)
        //    {
        //        _jsonData = jsonData;
        //    }

        //    [DebuggerDisplay("{Value.DebuggerDisplay,nq}", Name = "{Name,nq}")]
        //    internal class PropertyMember
        //    {
        //        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //        public string? Name { get; set; }
        //        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        //        public JsonData? Value { get; set; }
        //    }

        //    [DebuggerDisplay("{Value,nq}")]
        //    internal class SingleMember
        //    {
        //        public object? Value { get; set; }
        //    }

        //    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        //    public object Members
        //    {
        //        get
        //        {
        //            if (_jsonData.Kind != JsonValueKind.Array &&
        //                _jsonData.Kind != JsonValueKind.Object)
        //                return new SingleMember() { Value = _jsonData.ToJsonString() };

        //            return BuildMembers().ToArray();
        //        }
        //    }

        //    private IEnumerable<object> BuildMembers()
        //    {
        //        if (_jsonData.Kind == JsonValueKind.Object)
        //        {
        //            foreach (var property in _jsonData.Properties)
        //            {
        //                yield return new PropertyMember() { Name = property, Value = _jsonData.GetPropertyValue(property) };
        //            }
        //        }
        //        else if (_jsonData.Kind == JsonValueKind.Array)
        //        {
        //            foreach (var property in _jsonData.Items)
        //            {
        //                yield return property;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// The default serialization behavior for <see cref="JsonData"/> is not the behavior we want, we want to use
        /// the underlying JSON value that <see cref="JsonData"/> wraps, instead of using the default behavior for
        /// POCOs.
        /// </summary>
        private class JsonConverter : JsonConverter<JsonData>
        {
            public override JsonData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return new JsonData(document);
            }

            public override void Write(Utf8JsonWriter writer, JsonData value, JsonSerializerOptions options)
            {
                value.WriteTo(writer);
            }
        }
    }
}
