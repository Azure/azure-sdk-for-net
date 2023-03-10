// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;

// TODO: Remove when prototyping complete
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Dynamic
{
    public readonly partial struct ObjectElement
    {
        private readonly ObjectDocument _document;
        private readonly object _element;

        public readonly ObjectValueKind ValueKind { get; }

        public ObjectElement(ObjectDocument document, object element)
        {
            _document = document;
            _element = element;

            ValueKind = _document.GetValueKind(_element);
        }

        public T As<T>()
        {
            return _document.As<T>(_element);
        }

        public bool TryGetProperty(string name, out ObjectElement value)
        {
            return _document.TryGetProperty(_element, name, out value);
        }

        public ObjectElement GetIndexElement(int index)
        {
            return _document.GetIndexElement(_element, index);
        }

        public int GetArrayLength()
        {
            return _document.GetArrayLength(_element);
        }

        public IEnumerable<string> GetPropertyNames()
        {
            return _document.GetPropertyNames(_element);
        }

        public ObjectElement GetProperty(string name)
        {
            if (_document.TryGetProperty(_element, name, out ObjectElement value))
            {
                return value;
            }

            throw new InvalidOperationException();
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

        public string? GetString()
        {
            if (_document.TryGetString(_element, out string? value))
            {
                return value;
            }

            throw new InvalidOperationException();
        }

        public bool TrySet(object value)
        {
            return _document.TrySet(_element, value);
        }

        // TODO: add setters for primitives

        public ObjectElement SetProperty(string name, object value)
        {
            return _document.SetProperty(_element, name, value);
        }

        public void WriteTo(Stream stream)
        {
            _document.WriteTo(_element, stream);
        }

        public void DisposeRoot()
        {
            _document.Dispose();
        }

        public override string ToString()
        {
            return _element?.ToString() ?? "null";
        }
    }
}
