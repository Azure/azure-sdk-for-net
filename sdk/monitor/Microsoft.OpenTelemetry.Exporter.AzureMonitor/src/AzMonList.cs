// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal readonly struct AzMonList : IEnumerable
    {
        private static int allocationSize = 64;

        private readonly KeyValuePair<string, object>[] data;

        private AzMonList(KeyValuePair<string, object>[] data, int length)
        {
            this.data = data;
            this.Length = length;
        }

        public int Length { get; }

        public ref KeyValuePair<string, object> this[int index]
        {
            get => ref this.data[index];
        }

        public static AzMonList Initialize()
        {
            return new AzMonList(ArrayPool<KeyValuePair<string, object>>.Shared.Rent(allocationSize), 0);
        }

        public static void Add(ref AzMonList list, KeyValuePair<string, object> keyValuePair)
        {
            var data = list.data;

            if (data == null)
            {
                throw new InvalidOperationException("AzMonList instance is not initialized.");
            }

            if (list.Length >= data.Length)
            {
                allocationSize = data.Length * 2;
                var previousData = data;

                data = ArrayPool<KeyValuePair<string, object>>.Shared.Rent(allocationSize);

                var span = previousData.AsSpan();
                span.CopyTo(data);
                ArrayPool<KeyValuePair<string, object>>.Shared.Return(previousData);
            }

            data[list.Length] = keyValuePair;
            list = new AzMonList(data, list.Length + 1);
        }

        public static void Clear(ref AzMonList list)
        {
            list = new AzMonList(list.data, 0);
        }

        public static object GetTagValue(ref AzMonList list, string tagName)
        {
            int length = list.Length;

            for (int i = 0; i < length; i++)
            {
                if (list[i].Key == tagName)
                {
                    return list[i].Value;
                }
            }

            return null;
        }

        internal static object[] GetTagValues(ref AzMonList list, params string[] tagNames)
        {
            int lengthTagNames = tagNames.Length;
            int lengthList = list.Length;
            object[] values = new object[(int)lengthTagNames];

            for (int i = 0; i < lengthList; i++)
            {
                var index = Array.IndexOf(tagNames, list[i].Key);
                if (index >= 0)
                {
                    values[index] = list[i].Value;
                    lengthTagNames--;

                    if (lengthTagNames == 0)
                    {
                        break;
                    }
                }
            }

            return values;
        }

        public void Return()
        {
            var data = this.data;
            if (data != null)
            {
                ArrayPool<KeyValuePair<string, object>>.Shared.Return(data);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(in this);
        }

        public struct Enumerator : IEnumerator
        {
            private readonly KeyValuePair<string, object>[] data;
            private readonly int length;
            private int index;
            private KeyValuePair<string, object> current;

            public Enumerator(in AzMonList list)
            {
                this.data = list.data;
                this.length = list.Length;
                this.index = 0;
                this.current = default;
            }

            public object Current { get => this.current; }

            public bool MoveNext()
            {
                if (this.index < this.length)
                {
                    this.current = this.data[this.index++];
                    return true;
                }

                this.index = this.length + 1;
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
