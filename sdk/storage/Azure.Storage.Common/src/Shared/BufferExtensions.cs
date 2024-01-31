// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;

namespace Azure.Storage
{
    internal static class BufferExtensions
    {
        private class DisposableRentedArray<T> : IDisposable
        {
            private ArrayPool<T> _pool;
            private T[] _rentedArray;

            public DisposableRentedArray(ArrayPool<T> pool, T[] rentedArray)
            {
                _pool = pool;
                _rentedArray = rentedArray;
            }
            public void Dispose()
            {
                _pool.Return(_rentedArray);
            }
        }

        public static IDisposable RentDisposable<T>(this ArrayPool<T> pool, int minimumLength, out T[] array)
        {
            array = pool.Rent(minimumLength);
            return new DisposableRentedArray<T>(pool, array);
        }

        public static IDisposable RentAsMemoryDisposable<T>(this ArrayPool<T> pool, int minimumLength, out Memory<T> memory)
        {
            if (minimumLength == 0)
            {
                memory = Memory<T>.Empty;
                return null;
            }
            IDisposable result = pool.RentDisposable(minimumLength, out T[] array);
            memory = new Memory<T>(array, 0, minimumLength);
            return result;
        }

        public static IDisposable RentAsSpanDisposable<T>(this ArrayPool<T> pool, int minimumLength, out Span<T> span)
        {
            if (minimumLength == 0)
            {
                span = Span<T>.Empty;
                return null;
            }
            IDisposable result = pool.RentDisposable(minimumLength, out T[] array);
            span = new Span<T>(array, 0, minimumLength);
            return result;
        }

        /// <summary>
        /// Fluent API to clear the contents of an array to the default value at every index.
        /// </summary>
        /// <returns>
        /// The cleared array.
        /// </returns>
        public static T[] Clear<T>(this T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }
            return array;
        }
    }
}
