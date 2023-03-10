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
        protected internal abstract bool TryGetPropertyNames(object element, out IEnumerable<string> enumerator);
        protected internal abstract bool TryGetProperty(object element, string name, out ObjectElement value);

        // Arrays
        protected internal abstract bool TryGetArrayLength(object element, out int length);
        protected internal abstract ObjectElement GetIndexElement(object element, int index);

        // Primitives
        protected internal abstract bool TryGetBoolean(object element, out bool value);
        protected internal abstract bool TryGetDouble(object element, out double value);
        protected internal abstract bool TryGetInt64(object element, out long value);
        protected internal abstract bool TryGetString(object element, out string? value);
        protected internal abstract bool HasValue(object element);

        // Setters
        protected internal abstract ObjectElement SetProperty(object element, string name, object value);
        protected internal abstract void Set(object element, object value);

        // Serialization
        protected internal abstract void WriteTo(object element, Stream stream);

        // Conversion
        protected internal abstract T As<T>(object element);

        protected internal abstract string? ToString(object element);

        public abstract void Dispose();
    }
}
