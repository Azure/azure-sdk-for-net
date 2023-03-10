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
        /// An enumerable and enumerator for the properties of a mutable JSON object.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct ObjectEnumerator : IEnumerable<DynamicJsonProperty>, IEnumerator<DynamicJsonProperty>
        {
            private MutableJsonElement.ObjectEnumerator _enumerator;

            internal ObjectEnumerator(MutableJsonElement.ObjectEnumerator enumerator)
            {
                _enumerator = enumerator;
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
            public ObjectEnumerator GetEnumerator() => new(_enumerator.GetEnumerator());

            /// <inheritdoc />
            public DynamicJsonProperty Current => new(_enumerator.Current.Name, new(_enumerator.Current.Value));

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            IEnumerator<DynamicJsonProperty> IEnumerable<DynamicJsonProperty>.GetEnumerator() => GetEnumerator();

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
