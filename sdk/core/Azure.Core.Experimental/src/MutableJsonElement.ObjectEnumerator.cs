// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace Azure.Core.Json
{
    /// <summary>
    /// A mutable representation of a JSON element.
    /// </summary>
    public readonly partial struct MutableJsonElement
    {
        /// <summary>
        ///   An enumerable and enumerator for the properties of a JSON object.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct ObjectEnumerator : IEnumerable<(string Name, MutableJsonElement Value)>, IEnumerator<(string Name, MutableJsonElement Value)>
        {
            private readonly MutableJsonElement _target;
            private JsonElement.ObjectEnumerator _enumerator;

            internal ObjectEnumerator(MutableJsonElement target)
            {
                Debug.Assert(target.ValueKind == JsonValueKind.Object);

                _target = target;
                _enumerator = target.GetJsonElement().EnumerateObject();
            }

            /// <inheritdoc />
            public (string Name, MutableJsonElement Value) Current
            {
                get => (
                    _enumerator.Current.Name,
                    new MutableJsonElement(_target._root, _enumerator.Current.Value, _target._path, _target._highWaterMark)
                );
            }

            /// <summary>
            ///   Returns an enumerator that iterates the properties of an object.
            /// </summary>
            /// <returns>
            ///   An <see cref="ObjectEnumerator"/> value that can be used to iterate
            ///   through the object.
            /// </returns>
            /// <remarks>
            ///   The enumerator will enumerate the properties in the order they are
            ///   declared, and when an object has multiple definitions of a single
            ///   property they will all individually be returned (each in the order
            ///   they appear in the content).
            /// </remarks>
            public ObjectEnumerator GetEnumerator()
            {
                ObjectEnumerator enumerator = this;
                enumerator._enumerator = _enumerator.GetEnumerator();
                return enumerator;
            }

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            IEnumerator<(string Name, MutableJsonElement Value)> IEnumerable<(string Name, MutableJsonElement Value)>.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            public void Dispose() => _enumerator.Dispose();

            /// <inheritdoc />
            public void Reset() => _enumerator.Reset();

            /// <inheritdoc />
            object IEnumerator.Current => _enumerator.Current;

            /// <inheritdoc />
            public bool MoveNext() => _enumerator.MoveNext();
        }
    }
}
