// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

// TODO: Remove when prototyping complete
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// A mutable representation of an object element.
    /// </summary>
    public readonly partial struct ObjectElement
    {
        /// <summary>
        ///   An enumerable and enumerator for the properties of an object.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct ObjectEnumerator : IEnumerable<(string Name, ObjectElement Value)>, IEnumerator<(string Name, ObjectElement Value)>
        {
            private readonly ObjectElement _target;
            private IEnumerable<(string Name, ObjectElement Value)> _enumerator;

            internal ObjectEnumerator(ObjectElement target)
            {
                _target = target;
                _enumerator = target.EnumerateObject();
            }

            /// <inheritdoc />
            public (string Name, ObjectElement Value) Current => (_enumerator.GetEnumerator().Current.Name, _target.GetProperty(_enumerator.GetEnumerator().Current.Name));

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
                enumerator._enumerator = _enumerator;
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
            ///   An <see cref="IEnumerator{T}"/> over a <see cref="Tuple{String, ObjectElement}"/>
            ///   that can be used to iterate through the properties of the object.
            /// </returns>
            /// <remarks>
            ///   The enumerator will enumerate the properties in the order they are
            ///   declared, and when an object has multiple definitions of a single
            ///   property they will all individually be returned (each in the order
            ///   they appear in the content).
            /// </remarks>
            IEnumerator<(string Name, ObjectElement Value)> IEnumerable<(string Name, ObjectElement Value)>.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            public void Dispose() => _enumerator.GetEnumerator().Dispose();

            /// <inheritdoc />
            public void Reset() => _enumerator.GetEnumerator().Reset();

            /// <inheritdoc />
            object IEnumerator.Current => _enumerator.GetEnumerator().Current;

            /// <inheritdoc />
            public bool MoveNext() => _enumerator.GetEnumerator().MoveNext();
        }
    }
}
