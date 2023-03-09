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
        /// An enumerable and enumerator for the properties of a mutable JSON object.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct ObjectEnumerator : IEnumerable<DynamicDataProperty>, IEnumerator<DynamicDataProperty>
        {
            private readonly ObjectElement _element;
            private readonly DynamicDataOptions _options;
            private readonly IEnumerator<string> _names;

            internal ObjectEnumerator(ObjectElement element, DynamicDataOptions options)
            {
                _element = element;
                _options = options;
                _names = _element.GetPropertyNames().GetEnumerator();
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
            public ObjectEnumerator GetEnumerator() => new(_element, _options);

            /// <inheritdoc />
            public DynamicDataProperty Current => new(_names.Current, new(_element.GetProperty(_names.Current)));

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            IEnumerator<DynamicDataProperty> IEnumerable<DynamicDataProperty>.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            public void Reset() => _names.Reset();

            /// <inheritdoc />
            object IEnumerator.Current => Current;

            /// <inheritdoc />
            public bool MoveNext() => _names.MoveNext();

            /// <inheritdoc />
            public void Dispose() => _names.Dispose();
        }
    }
}
