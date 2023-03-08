// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Json;

// TODO: Remove when prototyping complete
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Abstraction layer over a document element used by DynamicData.
    /// </summary>
    public abstract class ObjectDocument
    {
        public abstract ObjectElement GetIndexElement(object element, int index);

        // Enumerables
        public abstract IEnumerable EnumerateArray(object element);
        public abstract IEnumerable EnumerateObject(object element);

        // Properties
        public abstract bool TryGetProperty(object element, string name, out ObjectElement value);

        // Primitives
        public abstract bool TryGetBoolean(object element, out bool value);
        public abstract bool TryGetDouble(object element, out double value);
        public abstract bool TryGetInt64(object element, out long value);
        public abstract bool TryGetString(object element, out string value);

        // Setters
        public abstract void SetProperty(object element, string name, object value);
        public abstract void Set(object element, object value);
    }

    public struct ObjectElement
    {
        private ObjectDocument _document;
        private object _element;

        public ObjectElement(ObjectDocument document, object element)
        {
            _document = document;
            _element = element;
        }

        public bool TryGetProperty(string name, out ObjectElement value)
        {
            return _document.TryGetProperty(_element, name, out value);
        }

        public ObjectElement GetIndexElement(int index)
        {
            return _document.GetIndexElement(_element, index);
        }

        public IEnumerable EnumerateArray()
        {
            return _document.EnumerateArray(_element);
        }

        public IEnumerable EnumerateObject()
        {
            return _document.EnumerateObject(_element);
        }

        public bool GetBoolean()
        {
            if (_document.TryGetBoolean(_element, out bool value))
            {
                return value;
            }

            throw new InvalidOperationException();
        }

        public int GetInt32()
        {
            if (_document.TryGetInt64(_element, out long value))
            {
                // TODO: check range
                return (int)value;
            }

            throw new InvalidOperationException();
        }

        public long GetInt64()
        {
            if (_document.TryGetInt64(_element, out long value))
            {
                return value;
            }

            throw new InvalidOperationException();
        }

        public float GetSingle()
        {
            if (_document.TryGetDouble(_element, out double value))
            {
                // TODO: check range
                return (float)value;
            }

            throw new InvalidOperationException();
        }

        public double GetDouble()
        {
            if (_document.TryGetDouble(_element, out double value))
            {
                return value;
            }

            throw new InvalidOperationException();
        }

        public void SetProperty(string name, object value)
        {
            _document.SetProperty(_element, name, value);
        }
    }
}
