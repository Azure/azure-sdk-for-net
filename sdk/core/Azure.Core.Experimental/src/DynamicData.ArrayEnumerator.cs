// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
{
    public partial class DynamicData
    {
        /// <summary>
        /// An enumerable and enumerator for the contents of a mutable JSON array.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct ArrayEnumerator : IEnumerable<DynamicData>, IEnumerator<DynamicData>
        {
            private ObjectElement _element;
            private readonly int _length;
            private int _index;
            private DynamicDataOptions _options;

            internal ArrayEnumerator(ObjectElement element, DynamicDataOptions options)
            {
                _element = element;
                _length = element.GetArrayLength();
                _index = -1;
                _options = options;
            }

            /// <inheritdoc />
            public DynamicData Current
            {
                get
                {
                    if (_index < 0)
                    {
                        return new DynamicData(default);
                    }

                    return new DynamicData(_element.GetIndexElement(_index), _options);
                }
            }

            /// <summary>
            ///   Returns an enumerator that iterates through a collection.
            /// </summary>
            /// <returns>
            ///   An <see cref="ArrayEnumerator"/> value that can be used to iterate
            ///   through the array.
            /// </returns>
            public ArrayEnumerator GetEnumerator()
            {
                ArrayEnumerator enumerator = this;
                enumerator._index = -1;
                return enumerator;
            }

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            IEnumerator<DynamicData> IEnumerable<DynamicData>.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            public void Reset()
            {
                _index = -1;
            }

            /// <inheritdoc />
            object IEnumerator.Current => Current;

            /// <inheritdoc />
            public bool MoveNext()
            {
                _index++;

                return _index < _length;
            }

            /// <inheritdoc />
            public void Dispose()
            {
                _index = _length;
            }
        }
    }
}
