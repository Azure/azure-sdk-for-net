// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Core.GeoJson
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct GeoArray<T>: IEnumerable<T>
    {
        private readonly object _container;

        /// <summary>
        ///
        /// </summary>
        /// <param name="container"></param>
        internal GeoArray(object container)
        {
            _container = container;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        public T this[int index]
        {
            get
            {
                return _container switch
                {
                    T[] array => array[index],
                    GeoPointCollection pointCollection => (T) (object) pointCollection.Points[index].Coordinates,
                    GeoLineCollection lineCollection => (T) (object) lineCollection.Lines[index].Coordinates,
                    GeoPolygon polygon => (T) (object) polygon.Rings[index].Coordinates,
                    GeoPolygonCollection polygonCollection => (T) (object) polygonCollection.Polygons[index].Coordinates,
                    _ => default!
                };
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int Count
        {
            get
            {
                return _container switch
                {
                    T[] array => array.Length,
                    GeoPointCollection pointCollection => pointCollection.Points.Count,
                    GeoLineCollection lineCollection => lineCollection.Lines.Count,
                    GeoPolygon polygon => polygon.Rings.Count,
                    GeoPolygonCollection polygonCollection => polygonCollection.Polygons.Count,
                    _ => 0
                };
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        /// <summary>
        ///
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