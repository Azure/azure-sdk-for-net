// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;

namespace Azure.Storage.Tests.Shared
{
    public class MockArrayPool<T> : ArrayPool<T>
    {
        public int RentCount { get; private set; }

        public int ReturnCount { get; private set; }

        private readonly HashSet<T[]> _arraySet;

        public MockArrayPool()
        {
            _arraySet = new HashSet<T[]>();
        }

        public override T[] Rent(int minimumLength)
        {
            T[] array = new T[minimumLength];
            _arraySet.Add(array);
            RentCount++;
            return array;
        }

        public override void Return(T[] array, bool clearArray = false)
        {
            if (!_arraySet.Contains(array))
            {
                throw new ArgumentException($"{nameof(array)} was not rented from this ArrayPool");
            }
            ReturnCount++;
            _arraySet.Remove(array);
        }
    }
}
