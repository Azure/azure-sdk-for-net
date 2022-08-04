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

            Value.Create((bool)default).As<bool>();
            Value.Create((byte)default).As<byte>();
            Value.Create((sbyte)default).As<sbyte>();
            Value.Create((char)default).As<char>();
            Value.Create((double)default).As<double>();
            Value.Create((short)default).As<short>();
            Value.Create((int)default).As<int>();
            Value.Create((long)default).As<long>();
            Value.Create((ushort)default).As<ushort>();
            Value.Create((uint)default).As<uint>();
            Value.Create((ulong)default).As<ulong>();
            Value.Create((float)default).As<float>();
            Value.Create((double)default).As<double>();
            Value.Create((DateTime)default).As<DateTime>();
            Value.Create((DateTimeOffset)default).As<DateTimeOffset>();
            Value.Create(new byte[1]).As<byte[]>();
            Value.Create(new char[1]).As<char[]>();
            Value.Create(new ArraySegment<byte>(new byte[1])).As<ArraySegment<byte>>();
            Value.Create(new ArraySegment<char>(new char[1])).As<ArraySegment<char>>();

            Value.Create((bool?)default).As<bool?>();
            Value.Create((byte?)default).As<byte?>();
            Value.Create((sbyte?)default).As<sbyte?>();
            Value.Create((char?)default).As<char?>();
            Value.Create((double?)default).As<double?>();
            Value.Create((short?)default).As<short?>();
            Value.Create((int?)default).As<int?>();
            Value.Create((long?)default).As<long?>();
            Value.Create((ushort?)default).As<ushort?>();
            Value.Create((uint?)default).As<uint?>();
            Value.Create((ulong?)default).As<ulong?>();
            Value.Create((float?)default).As<float?>();
            Value.Create((double?)default).As<double?>();
            Value.Create((DateTime?)default).As<DateTime?>();
            Value.Create((DateTimeOffset?)default).As<DateTimeOffset?>();

            Value value = default;
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
