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
        // Enumerables

        public abstract bool TryGetArrayEnumerator(object element, out IEnumerable enumerable);
        public abstract bool TryGetObjectEnumerator(object element, out IEnumerable<(string Name, ObjectElement Value)> enumerable);

        // Getters
        public abstract ObjectElement GetIndexElement(object element, int index);
        public abstract int GetArrayLength(object element);
        public abstract bool TryGetProperty(object element, string name, out ObjectElement value);

        // Primitives
        public abstract bool TryGetBoolean(object element, out bool value);
        public abstract bool TryGetDouble(object element, out double value);
        public abstract bool TryGetInt64(object element, out long value);
        public abstract bool TryGetString(object element, out string? value);
        public abstract bool HasValue(object element);

        // Setters
        public abstract ObjectElement SetProperty(object element, string name, object value);
        public abstract void Set(object element, object value);

        // Serialization
        public abstract void WriteTo(object element, Stream stream);

        // Conversion
        public abstract T As<T>(object element);

        public abstract void Dispose();

        public abstract string? ToString(object element);
    }
}
