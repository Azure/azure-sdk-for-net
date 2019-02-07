// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Buffers;
using Azure.Core.Testing;
using NUnit.Framework;
using System;

namespace Azure.Core.Tests
{
    public class BuffersTests
    {
        TestPool<byte> pool = new TestPool<byte>();

        [Test]
        public void EmptyBuilder() {
            pool.ClearDiagnostics();
            var sequence = new Sequence<byte>(pool);
            var ros = sequence.AsReadOnly();
            Assert.AreEqual(0, ros.Length);
            sequence.Dispose();
            Assert.AreEqual(0, pool.TotalRented);
        }

        [Test]
        public void SingleSegmentBuilder()
        {
            pool.ClearDiagnostics();
            var sequence = new Sequence<byte>(pool);

            var array = sequence.GetMemory(100);
            Assert.GreaterOrEqual(array.Length, 100);

            sequence.Advance(50);
            var ros = sequence.AsReadOnly();

            Assert.True(ros.IsSingleSegment);
            Assert.AreEqual(50, ros.Length);

            sequence.Dispose();

            Assert.AreEqual(1, pool.TotalRented);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public void TwoSegmentBuilder()
        {
            pool.ClearDiagnostics();
            var sequence = new Sequence<byte>(pool);

            sequence.GetMemory(4096);
            sequence.Advance(4095);

            sequence.GetMemory(4096);
            sequence.Advance(4096);

            var ros = sequence.AsReadOnly();

            Assert.False(ros.IsSingleSegment);
            Assert.AreEqual(4096 * 2 - 1, ros.Length);

            sequence.Dispose();

            Assert.AreEqual(2, pool.TotalRented);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }

        [Test]
        public void ThreeSegmentBuilder()
        {
            pool.ClearDiagnostics();
            var builder = new Sequence<byte>(pool);

            builder.GetMemory(4096);
            builder.Advance(4095);

            builder.GetMemory(4096);
            builder.Advance(4096);

            builder.GetMemory(4096);
            builder.Advance(4095);

            var sequence = builder.AsReadOnly();

            Assert.False(sequence.IsSingleSegment);
            Assert.AreEqual(4096 * 3 - 2, sequence.Length);

            builder.Dispose();

            Assert.AreEqual(3, pool.TotalRented);
            Assert.AreEqual(0, pool.CurrentlyRented);
        }
    }
}
