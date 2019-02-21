// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Collections.Generic;

namespace Azure.Core.Testing
{
    public class TestPool<T> : ArrayPool<T>
    {
        ArrayPool<T> _pool = Shared;
        public List<string> Log { get; } = new List<string>();
        public int CurrentlyRented;
        public int TotalRented;

        public override T[] Rent(int minimumLength)
        {
            TotalRented++;
            CurrentlyRented++;
            Log.Add($"Rent {minimumLength}");
            return _pool.Rent(minimumLength);
        }

        public override void Return(T[] array, bool clearArray = false)
        {
            CurrentlyRented--;
            Log.Add($"Return {array.Length}");
            _pool.Return(array, clearArray);
        }

        public void ClearDiagnostics()
        {
            TotalRented = 0;
            CurrentlyRented = 0;
            Log.Clear();
        }

        public override string ToString()
            => $"CurrentlyRented={CurrentlyRented}, TotalRented={TotalRented}";
    }
}
