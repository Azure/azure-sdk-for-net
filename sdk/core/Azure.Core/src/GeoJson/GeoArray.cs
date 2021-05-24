// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a geometry coordinates array
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public readonly struct GeoArray<T>: IEnumerable<T>
    {
        private readonly object _container;

        internal GeoArray(object container)
        {
            _container = container;
        }

        /// <summary>
        /// Returns a value at the provided index.
        /// </summary>
        /// <param name="index">The index to retrieve the value from.</param>
        public T this[int index]
        {
            get
            {
                return _container switch
                {
                    T[] array => array[index],
                    GeoPointCollection pointCollection => (T) (object) pointCollection.Points[index].Coordinates,
                    GeoLineStringCollection lineCollection => (T) (object) lineCollection.Lines[index].Coordinates,
                    GeoPolygon polygon => (T) (object) polygon.Rings[index].Coordinates,
                    GeoPolygonCollection polygonCollection => (T) (object) polygonCollection.Polygons[index].Coordinates,
                    _ => default!
                };
            }
        }

        /// <summary>
        /// Returns the size of the array.
        /// </summary>
        public int Count
        {
            get
            {
                return _container switch
                {
                    T[] array => array.Length,
                    GeoPointCollection pointCollection => pointCollection.Points.Count,
                    GeoLineStringCollection lineCollection => lineCollection.Lines.Count,
                    GeoPolygon polygon => polygon.Rings.Count,
                    GeoPolygonCollection polygonCollection => polygonCollection.Polygons.Count,
                    _ => 0
                };
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Enumerates the elements of a <see cref="GeoArray{T}"/>
        /// </summary>
#pragma warning disable CA1034
        public struct Enumerator: IEnumerator<T>
        {
            private readonly GeoArray<T> _array;
            private int _index;

            internal Enumerator(GeoArray<T> array) : this()
            {
                _array = array;
                _index = -1;
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                _index++;
                return _index < _array.Count;
            }

            /// <inheritdoc />
            public void Reset()
            {
                _index = -1;
            }

            object IEnumerator.Current => Current!;

            /// <inheritdoc />
            public T Current => _array[_index];

            /// <inheritdoc />
            public void Dispose()
            {
            }
        }
    }
}