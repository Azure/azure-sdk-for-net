// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class VariantCreation
    {
        [Test]
        public void CreateIsAllocationFree()
        {
            var watch = MemoryWatch.Create();

            Variant.Create((bool)default);
            watch.Validate();
            Variant.Create((byte)default);
            watch.Validate();
            Variant.Create((sbyte)default);
            watch.Validate();
            Variant.Create((char)default);
            watch.Validate();
            Variant.Create((double)default);
            watch.Validate();
            Variant.Create((short)default);
            watch.Validate();
            Variant.Create((int)default);
            watch.Validate();
            Variant.Create((long)default);
            watch.Validate();
            Variant.Create((ushort)default);
            watch.Validate();
            Variant.Create((uint)default);
            watch.Validate();
            Variant.Create((ulong)default);
            watch.Validate();
            Variant.Create((float)default);
            watch.Validate();
            Variant.Create((double)default);
            watch.Validate();

            Variant.Create((bool?)default);
            watch.Validate();
            Variant.Create((byte?)default);
            watch.Validate();
            Variant.Create((sbyte?)default);
            watch.Validate();
            Variant.Create((char?)default);
            watch.Validate();
            Variant.Create((double?)default);
            watch.Validate();
            Variant.Create((short?)default);
            watch.Validate();
            Variant.Create((int?)default);
            watch.Validate();
            Variant.Create((long?)default);
            watch.Validate();
            Variant.Create((ushort?)default);
            watch.Validate();
            Variant.Create((uint?)default);
            watch.Validate();
            Variant.Create((ulong?)default);
            watch.Validate();
            Variant.Create((float?)default);
            watch.Validate();
            Variant.Create((double?)default);
            watch.Validate();
        }
    }
}
