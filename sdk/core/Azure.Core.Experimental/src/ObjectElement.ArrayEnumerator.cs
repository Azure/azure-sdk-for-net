// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

// TODO: Remove when prototyping complete
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Dynamic
{
    public partial struct ObjectElement
    {
        /// <summary>
        /// An enumerable and enumerator for the contents of a mutable JSON array.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct ArrayEnumerator : IEnumerable<ObjectElement>, IEnumerator<ObjectElement>
        {
            private readonly ObjectElement _element;
            private readonly int _length;
            private int _index;

            internal ArrayEnumerator(ObjectElement element)
            {
                _element = element;
                _length = element.GetArrayLength();
                _index = -1;
            }

            /// <inheritdoc />
            public ObjectElement Current
            {
                get
                {
                    if (_index < 0)
                    {
                        return default;
                    }

                    return _element.GetIndexElement(_index);
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
            IEnumerator<ObjectElement> IEnumerable<ObjectElement>.GetEnumerator() => GetEnumerator();

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
