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
        protected internal override ObjectValueKind GetValueKind(object element)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            switch (value.ValueKind)
            {
                case JsonValueKind.Array:
                    return ObjectValueKind.Array;
                case JsonValueKind.Object:
                    return ObjectValueKind.Object;
                case JsonValueKind.String:
                    return ObjectValueKind.String;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    return ObjectValueKind.Boolean;
                case JsonValueKind.Null:
                    return ObjectValueKind.Null;
                case JsonValueKind.Number:
                    if (value.GetJsonElement().TryGetInt64(out long l))
                    {
                        return ObjectValueKind.Integer;
                    }
                    if (value.GetJsonElement().TryGetDecimal(out decimal d))
                    {
                        return ObjectValueKind.FloatingPoint;
                    }
                    break;
            }

            throw new InvalidOperationException();
        }

        protected internal override T As<T>(object element)
        {
            MutableJsonElement value = (MutableJsonElement)element;

#if NET6_0_OR_GREATER
            return JsonSerializer.Deserialize<T>(value.GetJsonElement(), DefaultJsonSerializerOptions)!;
#else
            Utf8JsonReader reader = MutableJsonElement.GetReaderForElement(value.GetJsonElement());
            return JsonSerializer.Deserialize<T>(ref reader, DefaultJsonSerializerOptions);
#endif
        }

        protected internal override ObjectElement GetIndexElement(object element, int index)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            return new ObjectElement(this, value.GetIndexElement(index));
        }

        protected internal override int GetArrayLength(object element)
        {
            MutableJsonElement value = (MutableJsonElement)element;

            if (value.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException();
            }

            return value.GetJsonElement().GetArrayLength();
        }

        protected internal override bool TryGetProperty(object element, string name, out ObjectElement value)
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

        protected internal override IEnumerable<string> GetPropertyNames(object element)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            if (mje.ValueKind != JsonValueKind.Object)
            {
                throw new InvalidOperationException();
            }

            return mje.EnumerateObject().Select(p => p.Name);
        }

        protected internal override bool TryGetBoolean(object element, out bool value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            if (mje.ValueKind == JsonValueKind.True ||
                mje.ValueKind == JsonValueKind.False)
            {
                value = mje.GetBoolean();
                return true;
            }

            value = default;
            return false;
        }

        protected internal override bool TryGetDouble(object element, out double value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetDouble();
            return true;
        }

        protected internal override bool TryGetInt64(object element, out long value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            // TODO: implement try/get
            value = mje.GetInt64();
            return true;
        }

        protected internal override bool TryGetString(object element, out string? value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            if (mje.ValueKind == JsonValueKind.String)
            {
                value = mje.GetString();
                return true;
            }

            value = default;
            return false;
        }

        protected internal override ObjectElement SetProperty(object element, string name, object value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            return new ObjectElement(this, mje.SetProperty(name, value));
        }

        protected internal override bool TrySet(object element, object value)
        {
            MutableJsonElement mje = (MutableJsonElement)element;
            mje.Set(value);

            return true;
        }

        protected internal override void WriteTo(object element, Stream stream)
        {
            MutableJsonElement mje = (MutableJsonElement)element;

            Utf8JsonWriter writer = new(stream);
            mje.WriteTo(writer);
            writer.Flush();
        }
    }
}
