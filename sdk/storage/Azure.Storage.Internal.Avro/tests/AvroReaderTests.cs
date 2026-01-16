// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Internal.Avro.Tests
{
    public class AvroReaderTests
    {
        [Test]
        public async Task Tests()
        {
            List<TestCase> testCases = new List<TestCase>
            {
                new TestCase("test_null_0.avro", 57, o => Assert.That(o,Is.Null)), // null
                new TestCase("test_null_1.avro", 60, o => Assert.That((bool)o, Is.EqualTo(true))), // bool
                new TestCase("test_null_2.avro", 59, o => Assert.That((string)o, Is.EqualTo("adsfasdf09809dsf-=adsf"))), // string
                new TestCase("test_null_3.avro", 58, o => Assert.That((byte[])o, Is.EqualTo(Encoding.UTF8.GetBytes("12345abcd")))), // byte[]
                new TestCase("test_null_4.avro", 56, o => Assert.That((int)o, Is.EqualTo(1234))), // int
                new TestCase("test_null_5.avro", 57, o => Assert.That((long)o, Is.EqualTo(1234L))), // long
                new TestCase("test_null_6.avro", 58, o => Assert.That((float)o, Is.EqualTo(1234.0))), // float
                new TestCase("test_null_7.avro", 59, o => Assert.That((double)o, Is.EqualTo(1234.0))), // fouble
                // Not supported today.
                //new TestCase("test_null_8.avro", o => Assert.AreEqual(Encoding.UTF8.GetBytes("B"), (byte[])o)), // fixed
                new TestCase("test_null_9.avro", 106, o => Assert.That((string)o, Is.EqualTo("B"))), // enum
                // Not supported today.
                // new TestCase("test_null_10.avro", o => Assert.AreEqual(new List<long>() { 1, 2, 3 }, (List<long>)o)), // array
                new TestCase("test_null_11.avro", 84, o => Assert.That(
                    (Dictionary<string, object>)o, Is.EqualTo(new Dictionary<string, int>() { { "a", 1 }, { "b", 3 }, { "c", 2 } }))), // dictionary
                new TestCase("test_null_12.avro", 77, o => Assert.That(o,Is.Null)), // union
                new TestCase("test_null_13.avro", 129, o => // record
                {
                    Dictionary<string, object> expected = new Dictionary<string, object>() { { "$schema", "Test" }, { "f", 5 } };
                    Dictionary<string, object> actual = (Dictionary<string, object>)o;
                    Assert.That(actual.Count, Is.EqualTo(expected.Count));
                    foreach (KeyValuePair<string, object> keyValuePair in actual)
                    {
                        Assert.That(keyValuePair.Value, Is.EqualTo(expected[keyValuePair.Key]));
                    }
                })
            };

            // seekable streams
            foreach (TestCase testCase in testCases)
            {
                // Arrange
                using FileStream stream = File.OpenRead(
                    $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{testCase.Path}");
                AvroReader avroReader = new AvroReader(stream);

                // Act
                object o = await avroReader.Next(async: true).ConfigureAwait(false);
                testCase.Predicate(o);
                Assert.That(avroReader.BlockOffset, Is.EqualTo(testCase.BlockOffset));
            }

            // non-seekable streams
            foreach (TestCase testCase in testCases)
            {
                // Arrange
                string filePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{testCase.Path}";
                using FileStream stream = File.OpenRead(filePath);
                using NonSeekableMemoryStream nonSeekableMemoryStream = new NonSeekableMemoryStream();
                await stream.CopyToAsync(nonSeekableMemoryStream);
                nonSeekableMemoryStream.Reset();
                AvroReader avroReader = new AvroReader(nonSeekableMemoryStream);

                // Act
                object o = await avroReader.Next(async: true).ConfigureAwait(false);
                testCase.Predicate(o);
                Assert.That(avroReader.BlockOffset, Is.EqualTo(testCase.BlockOffset));
            }
        }

        private class TestCase
        {
            public readonly string Path;
            public readonly Action<object> Predicate;
            public readonly long BlockOffset;

            public TestCase(string path, long blockOffset, Action<object> predicate)
            {
                Path = path;
                Predicate = predicate;
                BlockOffset = blockOffset;
            }
        }
    }
}
