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
    public abstract class ObjectDocument : IDisposable
    {
        // Getters

        // Objects
        internal protected abstract bool TryGetPropertyNames(object element, out IEnumerable<string> enumerator);
        internal protected abstract bool TryGetProperty(object element, string name, out ObjectElement value);

        // Arrays
        internal protected abstract bool TryGetArrayLength(object element, out int length);
        internal protected abstract ObjectElement GetIndexElement(object element, int index);

        // Primitives
        internal protected abstract bool TryGetBoolean(object element, out bool value);
        internal protected abstract bool TryGetDouble(object element, out double value);
        internal protected abstract bool TryGetInt64(object element, out long value);
        internal protected abstract bool TryGetString(object element, out string? value);
        internal protected abstract bool HasValue(object element);

        // Setters
        internal protected abstract ObjectElement SetProperty(object element, string name, object value);
        internal protected abstract void Set(object element, object value);

        // Serialization
        internal protected abstract void WriteTo(object element, Stream stream);

        // Conversion
        internal protected abstract T As<T>(object element);

        internal protected abstract string? ToString(object element);

        public abstract void Dispose();
    }
}
