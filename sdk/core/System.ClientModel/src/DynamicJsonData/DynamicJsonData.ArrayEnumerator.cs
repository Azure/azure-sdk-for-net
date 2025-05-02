// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.ClientModel.Json;

namespace System.ClientModel.Serialization;

public partial class DynamicJsonData
{
    /// <summary>
    /// An enumerable and enumerator for the contents of a mutable JSON array.
    /// </summary>
    [DebuggerDisplay("{Current,nq}")]
    internal struct ArrayEnumerator : IEnumerable<DynamicJsonData>, IEnumerator<DynamicJsonData>
    {
        private MutableJsonElement.ArrayEnumerator _enumerator;
        private readonly DynamicJsonDataOptions _options;

        internal ArrayEnumerator(MutableJsonElement.ArrayEnumerator enumerator, DynamicJsonDataOptions options)
        {
            _enumerator = enumerator;
            _options = options;
        }

        /// <summary> Returns an enumerator that iterates through a collection.</summary>
        /// <returns> An <see cref="ArrayEnumerator"/> value that can be used to iterate through the array.</returns>
        public ArrayEnumerator GetEnumerator() => new(_enumerator.GetEnumerator(), _options);

        /// <inheritdoc />
        public DynamicJsonData Current => new(_enumerator.Current, _options);

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator<DynamicJsonData> IEnumerable<DynamicJsonData>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public void Reset() => _enumerator.Reset();

        /// <inheritdoc />
        object IEnumerator.Current => Current;

        /// <inheritdoc />
        public bool MoveNext() => _enumerator.MoveNext();

        /// <inheritdoc />
        public void Dispose() => _enumerator.Dispose();
    }
}
