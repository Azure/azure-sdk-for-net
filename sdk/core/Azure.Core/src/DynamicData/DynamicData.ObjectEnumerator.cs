// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core.Json;

namespace Azure.Core.Serialization
{
    public partial class DynamicData
    {
        /// <summary>
        /// An enumerable and enumerator for the properties of a mutable JSON object.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        internal struct ObjectEnumerator : IEnumerable<DynamicDataProperty>, IEnumerator<DynamicDataProperty>
        {
            private MutableJsonElement.ObjectEnumerator _enumerator;
            private readonly DynamicDataOptions _options;

            internal ObjectEnumerator(MutableJsonElement.ObjectEnumerator enumerator, DynamicDataOptions options)
            {
                _enumerator = enumerator;
                _options = options;
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
            public ObjectEnumerator GetEnumerator() => new(_enumerator.GetEnumerator(), _options);

            /// <inheritdoc />
            public DynamicDataProperty Current => new(_enumerator.Current.Name, new(_enumerator.Current.Value, _options));

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            IEnumerator<DynamicDataProperty> IEnumerable<DynamicDataProperty>.GetEnumerator() => GetEnumerator();

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
