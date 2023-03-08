// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using Azure.Core.Dynamic;

// TODO: Remove when prototyping complete
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Json
{
    public partial class MutableJsonDocument : ObjectDocument
    {
        public override T As<T>(object element)
        {
            MutableJsonElement value = (MutableJsonElement)element;

#if NET6_0_OR_GREATER
            return JsonSerializer.Deserialize<T>(value.GetJsonElement(), DefaultJsonSerializerOptions)!;
#else
            Utf8JsonReader reader = MutableJsonElement.GetReaderForElement(value.GetJsonElement());
            return JsonSerializer.Deserialize<T>(ref reader, DefaultJsonSerializerOptions);
#endif
        }

        public override IEnumerable EnumerateArray(object element)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable EnumerateObject(object element)
        {
            throw new NotImplementedException();
        }

        public override ObjectElement GetIndexElement(object element, int index)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetProperty(object element, string name, out ObjectElement value)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetBoolean(object element, out bool value)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetDouble(object element, out double value)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetInt64(object element, out long value)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetString(object element, out string value)
        {
            throw new NotImplementedException();
        }

        public override void SetProperty(object element, string name, object value)
        {
            throw new NotImplementedException();
        }

        public override void Set(object element, object value)
        {
            throw new NotImplementedException();
        }

        public override void WriteTo(object element, Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
