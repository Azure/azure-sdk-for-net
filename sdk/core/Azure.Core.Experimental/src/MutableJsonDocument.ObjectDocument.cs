// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
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

        public override ObjectElement GetIndexElement(object element, int index)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            return new ObjectElement(this, value.GetIndexElement(index));
        }

        public override int GetArrayLength(object element)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            return value.GetJsonElement().GetArrayLength();
        }

        public override bool HasValue(object element)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            return value.ValueKind != JsonValueKind.Null;
        }

        public override bool TryGetProperty(object element, string name, out ObjectElement value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            if (mje.TryGetProperty(name, out MutableJsonElement propertyValue))
            {
                value = new ObjectElement(this, propertyValue);
                return true;
            }

            value = default;
            return false;
        }

        public override bool TryGetArrayEnumerator(object element, out ObjectElement.ArrayEnumerator enumerable)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            if (value.ValueKind != JsonValueKind.Array)
            {
                enumerable = default;
                return false;
            }

            enumerable = new ObjectElement.ArrayEnumerator(new ObjectElement(this, element));
            return true;
        }

        public override bool TryGetObjectEnumerator(object element, out ObjectElement.ObjectEnumerator enumerable)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            if (value.ValueKind != JsonValueKind.Object)
            {
                enumerable = default;
                return false;
            }

            enumerable = new ObjectElement.ObjectEnumerator(new ObjectElement(this, element));
            return true;
        }

        public override IEnumerable<(string Name, object Value)> EnumerateObject(object element)
        {
            MutableJsonElement value = (MutableJsonElement)element;
            return value.EnumerateObject();
        }

        public override bool TryGetBoolean(object element, out bool value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetBoolean();
            return true;
        }

        public override bool TryGetDouble(object element, out double value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetDouble();
            return true;
        }

        public override bool TryGetInt64(object element, out long value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetInt64();
            return true;
        }

        public override bool TryGetString(object element, out string? value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetString();
            return true;
        }

        public override ObjectElement SetProperty(object element, string name, object value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            return new ObjectElement(this, mje.SetProperty(name, value));
        }

        public override void Set(object element, object value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            mje.Set(value);
        }

        public override void WriteTo(object element, Stream stream)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            Utf8JsonWriter writer = new(stream);
            mje.WriteTo(writer);
            writer.Flush();
        }

        public override string? ToString(object element)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            return mje.ToString();
        }
    }
}
