// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

#nullable enable

namespace Azure.Core.Json
{
    /// <summary>
    /// A mutable representation of a JSON element.
    /// </summary>
    internal readonly partial struct MutableJsonElement
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
                target.EnsureObject();

                _target = target;
                _enumerator = target.GetJsonElement().EnumerateObject();
            }

            /// <inheritdoc />
            public (string Name, MutableJsonElement Value) Current => (_enumerator.Current.Name, _target.GetProperty(_enumerator.Current.Name));

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

            /// <summary>
            ///   Returns an enumerator that iterates the properties of an object.
            /// </summary>
            /// <returns>
            ///   An <see cref="IEnumerator"/> that can be used to iterate
            ///   through the properties of the object.
            /// </returns>
            /// <remarks>
            ///   The enumerator will enumerate the properties in the order they are
            ///   declared, and when an object has multiple definitions of a single
            ///   property they will all individually be returned (each in the order
            ///   they appear in the content).
            /// </remarks>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <summary>
            ///   Returns an enumerator that iterates the properties of an object.
            /// </summary>
            /// <returns>
            ///   An <see cref="IEnumerator{T}"/> over a <see cref="Tuple{String, MutableJsonElement}"/>
            ///   that can be used to iterate through the properties of the object.
            /// </returns>
            /// <remarks>
            ///   The enumerator will enumerate the properties in the order they are
            ///   declared, and when an object has multiple definitions of a single
            ///   property they will all individually be returned (each in the order
            ///   they appear in the content).
            /// </remarks>
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
