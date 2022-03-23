// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure
{
    public class Creation
    {
        [Test]
        public void CreateIsAllocationFree()
        {
            var watch = MemoryWatch.Create();

            Value.Create((bool)default);
            watch.Validate();
            Value.Create((byte)default);
            watch.Validate();
            Value.Create((sbyte)default);
            watch.Validate();
            Value.Create((char)default);
            watch.Validate();
            Value.Create((double)default);
            watch.Validate();
            Value.Create((short)default);
            watch.Validate();
            Value.Create((int)default);
            watch.Validate();
            Value.Create((long)default);
            watch.Validate();
            Value.Create((ushort)default);
            watch.Validate();
            Value.Create((uint)default);
            watch.Validate();
            Value.Create((ulong)default);
            watch.Validate();
            Value.Create((float)default);
            watch.Validate();
            Value.Create((double)default);
            watch.Validate();

            Value.Create((bool?)default);
            watch.Validate();
            Value.Create((byte?)default);
            watch.Validate();
            Value.Create((sbyte?)default);
            watch.Validate();
            Value.Create((char?)default);
            watch.Validate();
            Value.Create((double?)default);
            watch.Validate();
            Value.Create((short?)default);
            watch.Validate();
            Value.Create((int?)default);
            watch.Validate();
            Value.Create((long?)default);
            watch.Validate();
            Value.Create((ushort?)default);
            watch.Validate();
            Value.Create((uint?)default);
            watch.Validate();
            Value.Create((ulong?)default);
            watch.Validate();
            Value.Create((float?)default);
            watch.Validate();
            Value.Create((double?)default);
            watch.Validate();
        }
    }
}
