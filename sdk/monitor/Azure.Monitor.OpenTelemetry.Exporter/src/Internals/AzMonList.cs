// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <remarks>
    /// An instance holds either recognized attributes (in the slot array) or unrecognized tags
    /// (in the list buffer), not both. Each buffer is rented only if that kind is stored.
    /// </remarks>
    internal readonly struct AzMonList
    {
        private const int DefaultCapacity = 8;

        private readonly KeyValuePair<string, object?>[]? data;

        private readonly object?[]? slots;

        private readonly int listCount;

        private AzMonList(KeyValuePair<string, object?>[]? data, int listCount, int length, object?[]? slots)
        {
            this.data = data;
            this.listCount = listCount;
            this.Length = length;
            this.slots = slots;
        }

        /// <summary>
        /// Total tags held, across both the slot array and the list buffer.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Tags held in the list buffer. A recognized attribute occupies a slot rather than a
        /// list entry, so this trails <see cref="Length"/> for an instance holding both kinds.
        /// </summary>
        public int ListCount => this.listCount;

        public ref KeyValuePair<string, object?> this[int index]
        {
            get => ref this.data![index];
        }

        /// <summary>
        /// Reads a recognized attribute in constant time. Returns <see langword="null"/> when the
        /// attribute is absent.
        /// </summary>
        public object? this[SemanticSlot slot]
        {
            get => this.slots?[(int)slot];
        }

        public static AzMonList Initialize()
        {
            return new AzMonList(ArrayPool<KeyValuePair<string, object?>>.Shared.Rent(DefaultCapacity), 0, 0, null);
        }

        /// <summary>
        /// Initializes a list that will only hold recognized attributes, so no list buffer is rented.
        /// </summary>
        public static AzMonList InitializeForMappedTags()
        {
            return new AzMonList(null, 0, 0, RentSlots());
        }

        private static object?[] RentSlots()
        {
            var slots = ArrayPool<object?>.Shared.Rent((int)SemanticSlot.Count);

            // The shared pool is process-wide, so a rented buffer cannot be assumed clean.
            Array.Clear(slots, 0, (int)SemanticSlot.Count);

            return slots;
        }

        /// <summary>
        /// Adds a tag, resolving its slot so it can later be read by <see cref="SemanticSlot"/>.
        /// </summary>
        public static void Add(ref AzMonList list, KeyValuePair<string, object?> keyValuePair)
        {
            if (SemanticSlotMap.TryGetSlot(keyValuePair.Key, out var slot))
            {
                AddMapped(ref list, slot, keyValuePair);
            }
            else
            {
                AddUnmapped(ref list, keyValuePair);
            }
        }

        /// <summary>
        /// Adds a tag whose slot the caller has already resolved.
        /// </summary>
        public static void AddMapped(ref AzMonList list, SemanticSlot slot, KeyValuePair<string, object?> keyValuePair)
        {
            var slots = list.slots ?? RentSlots();
            var length = list.Length;

            // First write wins, matching the first-match behaviour of GetTagValue.
            if (slots[(int)slot] == null)
            {
                slots[(int)slot] = keyValuePair.Value;
                length++;
            }

            list = new AzMonList(list.data, list.listCount, length, slots);
        }

        /// <summary>
        /// Adds a tag that is not a recognized attribute.
        /// </summary>
        public static void AddUnmapped(ref AzMonList list, KeyValuePair<string, object?> keyValuePair)
        {
            var data = list.data ?? ArrayPool<KeyValuePair<string, object?>>.Shared.Rent(DefaultCapacity);
            var listCount = list.listCount;

            if (listCount >= data.Length)
            {
                var previousData = data;

                data = ArrayPool<KeyValuePair<string, object?>>.Shared.Rent(previousData.Length * 2);

                previousData.AsSpan(0, listCount).CopyTo(data);

                // Entries hold references to caller-owned tag keys and values, so the used
                // region is cleared before the buffer goes back to the shared pool.
                Array.Clear(previousData, 0, listCount);
                ArrayPool<KeyValuePair<string, object?>>.Shared.Return(previousData);
            }

            data[listCount] = keyValuePair;
            list = new AzMonList(data, listCount + 1, list.Length + 1, list.slots);
        }

        public static object? GetTagValue(ref AzMonList list, string tagName)
        {
            if (list.slots != null && SemanticSlotMap.TryGetSlot(tagName, out var slot))
            {
                return list.slots[(int)slot];
            }

            var data = list.data;
            if (data == null)
            {
                return null;
            }

            int length = list.listCount;

            for (int i = 0; i < length; i++)
            {
                if (string.Equals(data[i].Key, tagName, StringComparison.Ordinal))
                {
                    return data[i].Value;
                }
            }

            return null;
        }

        public void Return()
        {
            var data = this.data;
            if (data != null)
            {
                // Every return path clears its own used region, so unused slots are already clean.
                Array.Clear(data, 0, this.listCount);
                ArrayPool<KeyValuePair<string, object?>>.Shared.Return(data);
            }

            var slots = this.slots;
            if (slots != null)
            {
                Array.Clear(slots, 0, (int)SemanticSlot.Count);
                ArrayPool<object?>.Shared.Return(slots);
            }
        }
    }
}
