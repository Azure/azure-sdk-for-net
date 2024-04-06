// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure
{
    public ref struct MemoryWatch
    {
        private static bool s_jit;
        private long _allocations;

        private static void JIT()
        {
            if (s_jit)
            {
                return;
            }

            // JITing allocates, so make sure we've got all of our <T> methods created.

            Variant.Create((bool)default).As<bool>();
            Variant.Create((byte)default).As<byte>();
            Variant.Create((sbyte)default).As<sbyte>();
            Variant.Create((char)default).As<char>();
            Variant.Create((double)default).As<double>();
            Variant.Create((short)default).As<short>();
            Variant.Create((int)default).As<int>();
            Variant.Create((long)default).As<long>();
            Variant.Create((ushort)default).As<ushort>();
            Variant.Create((uint)default).As<uint>();
            Variant.Create((ulong)default).As<ulong>();
            Variant.Create((float)default).As<float>();
            Variant.Create((double)default).As<double>();
            Variant.Create((DateTime)default).As<DateTime>();
            Variant.Create((DateTimeOffset)default).As<DateTimeOffset>();
            Variant.Create(new byte[1]).As<byte[]>();
            Variant.Create(new char[1]).As<char[]>();
            Variant.Create(new ArraySegment<byte>(new byte[1])).As<ArraySegment<byte>>();
            Variant.Create(new ArraySegment<char>(new char[1])).As<ArraySegment<char>>();

            Variant.Create((bool?)default).As<bool?>();
            Variant.Create((byte?)default).As<byte?>();
            Variant.Create((sbyte?)default).As<sbyte?>();
            Variant.Create((char?)default).As<char?>();
            Variant.Create((double?)default).As<double?>();
            Variant.Create((short?)default).As<short?>();
            Variant.Create((int?)default).As<int?>();
            Variant.Create((long?)default).As<long?>();
            Variant.Create((ushort?)default).As<ushort?>();
            Variant.Create((uint?)default).As<uint?>();
            Variant.Create((ulong?)default).As<ulong?>();
            Variant.Create((float?)default).As<float?>();
            Variant.Create((double?)default).As<double?>();
            Variant.Create((DateTime?)default).As<DateTime?>();
            Variant.Create((DateTimeOffset?)default).As<DateTimeOffset?>();

            Variant value = default;
            value.TryGetValue(out bool _);
            value.TryGetValue(out byte _);
            value.TryGetValue(out sbyte _);
            value.TryGetValue(out char _);
            value.TryGetValue(out double _);
            value.TryGetValue(out short _);
            value.TryGetValue(out int _);
            value.TryGetValue(out long _);
            value.TryGetValue(out ushort _);
            value.TryGetValue(out uint _);
            value.TryGetValue(out ulong _);
            value.TryGetValue(out float _);
            value.TryGetValue(out double _);
            value.TryGetValue(out DateTime _);
            value.TryGetValue(out DateTimeOffset _);

            s_jit = true;
        }

        private MemoryWatch(long allocations) => _allocations = allocations;

        public static MemoryWatch Create()
        {
            JIT();
            return new(GetAllocatedBytesPortable());
        }

        public void Dispose() => Validate();

        public void Validate()
        {
            var allocated = GetAllocatedBytesPortable();
            Assert.AreEqual(0, allocated - _allocations);

            // Assert.AreEqual allocates
            _allocations = GetAllocatedBytesPortable();
        }

        private static long GetAllocatedBytesPortable()
        {
#if NET6_0
            return GC.GetAllocatedBytesForCurrentThread();
#else
            return 0;
#endif
        }
    }
}
