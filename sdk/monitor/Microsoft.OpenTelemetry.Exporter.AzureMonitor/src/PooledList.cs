// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal readonly struct PooledList<T> : IEnumerable<T>, ICollection
    {
        private static int lastAllocatedSize = 64;

        private readonly T[] buffer;

        private PooledList(T[] buffer, int count)
        {
            this.buffer = buffer;
            this.Count = count;
        }

        public int Count { get; }

        public bool IsEmpty => this.Count == 0;

        bool ICollection.IsSynchronized => false;

        object ICollection.SyncRoot => this;

        public ref T this[int index]
        {
            get => ref this.buffer[index];
        }

        public static PooledList<T> Create()
        {
            return new PooledList<T>(ArrayPool<T>.Shared.Rent(lastAllocatedSize), 0);
        }

        public static void Add(ref PooledList<T> list, T item)
        {
            var buffer = list.buffer;

            if (buffer == null)
            {
                throw new InvalidOperationException("Items cannot be added to an empty pool instance.");
            }

            if (list.Count >= buffer.Length)
            {
                lastAllocatedSize = buffer.Length * 2;
                var previousBuffer = buffer;

                buffer = ArrayPool<T>.Shared.Rent(lastAllocatedSize);

                var span = previousBuffer.AsSpan();
                span.CopyTo(buffer);
                ArrayPool<T>.Shared.Return(previousBuffer);
            }

            buffer[list.Count] = item;
            list = new PooledList<T>(buffer, list.Count + 1);
        }

        public static void Clear(ref PooledList<T> list)
        {
            list = new PooledList<T>(list.buffer, 0);
        }

        public void Return()
        {
            var buffer = this.buffer;
            if (buffer != null)
            {
                ArrayPool<T>.Shared.Return(buffer);
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            Array.Copy(this.buffer, 0, array, index, this.Count);
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(in this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(in this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(in this);
        }

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private readonly T[] buffer;
            private readonly int count;
            private int index;
            private T current;

            public Enumerator(in PooledList<T> list)
            {
                this.buffer = list.buffer;
                this.count = list.Count;
                this.index = 0;
                this.current = default;
            }

            public T Current { get => this.current; }

            object IEnumerator.Current { get => this.Current; }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (this.index < this.count)
                {
                    this.current = this.buffer[this.index++];
                    return true;
                }

                this.index = this.count + 1;
                this.current = default;
                return false;
            }

            void IEnumerator.Reset()
            {
                this.index = 0;
                this.current = default;
            }
        }
    }
}
