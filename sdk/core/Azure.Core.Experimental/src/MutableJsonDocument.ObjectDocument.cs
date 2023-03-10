// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Azure.Core.Dynamic;

// TODO: Remove when prototyping complete
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Json
{
    public partial class MutableJsonDocument : ObjectDocument
    {
        internal protected override T As<T>(object element)
        {
            MutableJsonElement value = (MutableJsonElement)element;

#if NET6_0_OR_GREATER
            return JsonSerializer.Deserialize<T>(value.GetJsonElement(), DefaultJsonSerializerOptions)!;
#else
            Utf8JsonReader reader = MutableJsonElement.GetReaderForElement(value.GetJsonElement());
            return JsonSerializer.Deserialize<T>(ref reader, DefaultJsonSerializerOptions);
#endif
        }

        internal protected override ObjectElement GetIndexElement(object element, int index)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            return new ObjectElement(this, value.GetIndexElement(index));
        }

        internal protected override bool TryGetArrayLength(object element, out int length)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            if (value.ValueKind != JsonValueKind.Array)
            {
                length = -1;
                return false;
            }

            length = value.GetJsonElement().GetArrayLength();
            return true;
        }

        internal protected override bool HasValue(object element)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            return value.ValueKind != JsonValueKind.Null;
        }

        internal protected override bool TryGetProperty(object element, string name, out ObjectElement value)
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

        internal protected override bool TryGetPropertyNames(object element, out IEnumerable<string> enumerable)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            if (mje.ValueKind != JsonValueKind.Object)
            {
                enumerable = Array.Empty<string>();
                return false;
            }

            enumerable = mje.EnumerateObject().Select(p => p.Name);
            return true;
        }

        internal protected override bool TryGetBoolean(object element, out bool value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetBoolean();
            return true;
        }

        internal protected override bool TryGetDouble(object element, out double value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetDouble();
            return true;
        }

        internal protected override bool TryGetInt64(object element, out long value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetInt64();
            return true;
        }

        internal protected override bool TryGetString(object element, out string? value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetString();
            return true;
        }

        internal protected override ObjectElement SetProperty(object element, string name, object value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            return new ObjectElement(this, mje.SetProperty(name, value));
        }

        internal protected override void Set(object element, object value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            mje.Set(value);
        }

        internal protected override void WriteTo(object element, Stream stream)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            Utf8JsonWriter writer = new(stream);
            mje.WriteTo(writer);
            writer.Flush();
        }

        internal protected override string? ToString(object element)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            return mje.ToString();
        }
    }
}
