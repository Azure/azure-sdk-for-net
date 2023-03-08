// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
{
    public partial class DynamicJson
    {
        /// <summary>
        /// An enumerable and enumerator for the contents of a mutable JSON array.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct ArrayEnumerator : IEnumerable<DynamicJson>, IEnumerator<DynamicJson>
        {
            private ObjectElement.ArrayEnumerator _enumerator;

            internal ArrayEnumerator(ObjectElement.ArrayEnumerator enumerator)
            {
                _enumerator = enumerator;
            }

            /// <summary> Returns an enumerator that iterates through a collection.</summary>
            /// <returns> An <see cref="ArrayEnumerator"/> value that can be used to iterate through the array.</returns>
            public ArrayEnumerator GetEnumerator() => new(_enumerator.GetEnumerator());

            /// <inheritdoc />
            public DynamicJson Current => new(_enumerator.Current);

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            IEnumerator<DynamicJson> IEnumerable<DynamicJson>.GetEnumerator() => GetEnumerator();

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
}
