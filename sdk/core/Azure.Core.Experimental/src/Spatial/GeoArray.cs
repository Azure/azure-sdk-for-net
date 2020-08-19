// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.GeoJson
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct GeoArray<T>
    {
        private readonly T[] _array;

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        public GeoArray(T[] array)
        {
            _array = array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        public T this[int index] => default!;

        /// <summary>
        ///
        /// </summary>
        public int Count => 0;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Enumerator GetEnumerator()
        {
            return new Enumerator();
        }



        /// <summary>
        ///
        /// </summary>
#pragma warning disable CA1034
        public struct Enumerator
        {
            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public bool MoveNext() => false;
            /// <summary>
            ///
            /// </summary>
            public T Current { get; }
        }
    }
}