// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerialization
{
    /// <summary>
    /// Happy path tests are in the public test project in the ModelTests class using the JsonInterfaceStrategy.
    /// This class is used for testing the internal properties of ModelWriter.
    /// </summary>
    public class ModelWriterInterlockedTests
    {
        private const int _modelSize = 156000;
        private static readonly string _json = File.ReadAllText(TestData.GetLocation("ResourceProviderData.json"));
        private static readonly ResourceProviderData _resourceProviderData = ModelSerializer.Deserialize<ResourceProviderData>(BinaryData.FromString(_json));

        [Test]
        public async Task HappyPath()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
            Assert.IsTrue(writer.TryComputeLength(out var length));
            Assert.AreEqual(_modelSize, length);

            MemoryStream stream1 = new MemoryStream((int)length);
            writer.CopyTo(stream1, default);
            Assert.AreEqual(_modelSize, stream1.Length);

            MemoryStream stream2 = new MemoryStream((int)length);
            await writer.CopyToAsync(stream2, default);
            Assert.AreEqual(_modelSize, stream2.Length);

            CollectionAssert.AreEqual(stream1.ToArray(), stream2.ToArray());
        }

        //[Test]
        public async Task DisposeWhileConvertToBinaryData_5000Times()
        {
            for (var i = 0; i < 5000; i++)
            {
                await DisposeWhileConvertToBinaryData();
            }
        }

        [Test]
        public async Task DisposeWhileConvertToBinaryData()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
            FieldInfo sequenceField = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance);
            object sequenceBuilder = sequenceField.GetValue(writer);
            Assert.IsNull(sequenceBuilder);

            bool taskStarted = false;
            Task result = Task.Factory.StartNew(() =>
            {
                Parallel.For(0, 100000, i =>
                {
                    taskStarted = true;
                    BinaryData data = null;
                    try
                    {
                        data = writer.ToBinaryData();
                        Assert.AreEqual(_modelSize, data.ToMemory().Length);
                    }
                    catch (ObjectDisposedException)
                    {
                        Assert.IsNull(data);
                    }
                });
            });

            while (!taskStarted)
            {
                Thread.Sleep(1);
            }

            await DisposeAfterStart(writer, sequenceField, result);
        }

        //[Test]
        public async Task DisposeWhileCopyAsync_5000Times()
        {
            for (var i = 0; i < 5000; i++)
            {
                await DisposeWhileCopyAsync();
            }
        }

        [Test]
        public async Task DisposeWhileCopyAsync()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
            FieldInfo sequenceField = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance);
            object sequenceBuilder = sequenceField.GetValue(writer);
            Assert.IsNull(sequenceBuilder);

            bool taskStarted = false;
            Task result = Task.Factory.StartNew(() =>
            {
                Parallel.For(0, 100000, async i =>
                {
                    taskStarted = true;
                    using MemoryStream stream = new MemoryStream();
                    try
                    {
                        await writer.CopyToAsync(stream, default);
                        Assert.AreEqual(_modelSize, stream.Length);
                    }
                    catch (ObjectDisposedException)
                    {
                        Assert.AreEqual(0, stream.Length);
                    }
                });
            });

            while (!taskStarted)
            {
                Thread.Sleep(1);
            }

            await DisposeAfterStart(writer, sequenceField, result);
        }

        private static async Task DisposeAfterStart(ModelWriterInterlocked writer, FieldInfo sequenceField, Task result)
        {
            writer.Dispose();
            object sequenceBuilder = sequenceField.GetValue(writer);
            Assert.AreEqual(typeof(object), sequenceBuilder?.GetType());

            await result;

            sequenceBuilder = sequenceField.GetValue(writer);
            Assert.AreEqual(typeof(object), sequenceBuilder?.GetType());
        }

        //[Test]
        public async Task DisposeWhileCopy_5000Times()
        {
            for (var i = 0; i < 5000; i++)
            {
                await DisposeWhileCopy();
            }
        }

        [Test]
        public async Task DisposeWhileCopy()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
            FieldInfo sequenceField = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance);
            object sequenceBuilder = sequenceField.GetValue(writer);
            Assert.IsNull(sequenceBuilder);

            bool taskStarted = false;
            Task result = Task.Factory.StartNew(() =>
            {
                Parallel.For(0, 100000, i =>
                {
                    taskStarted = true;
                    using MemoryStream stream = new MemoryStream();
                    try
                    {
                        writer.CopyTo(stream, default);
                        Assert.AreEqual(_modelSize, stream.Length);
                    }
                    catch (ObjectDisposedException)
                    {
                        Assert.AreEqual(0, stream.Length);
                    }
                });
            });

            while (!taskStarted)
            {
                Thread.Sleep(1);
            }

            await DisposeAfterStart(writer, sequenceField, result);
        }

        //[Test]
        public async Task DisposeWhileGettingLength_5000Times()
        {
            for (var i = 0; i < 5000; i++)
            {
                await DisposeWhileGettingLength();
            }
        }

        [Test]
        public async Task DisposeWhileGettingLength()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
            FieldInfo sequenceField = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance);
            object sequenceBuilder = sequenceField.GetValue(writer);
            Assert.IsNull(sequenceBuilder);

            long length = 0;
            bool taskStarted = false;
            Task result = Task.Factory.StartNew(() =>
            {
                Parallel.For(0, 100000, i =>
                {
                    taskStarted = true;
                    try
                    {
                        Assert.IsTrue(writer.TryComputeLength(out var length));
                        Assert.AreEqual(_modelSize, length);
                    }
                    catch (ObjectDisposedException)
                    {
                        Assert.AreEqual(0, length);
                    }
                });
            });

            while (!taskStarted)
            {
                Thread.Sleep(1);
            }

            await DisposeAfterStart(writer, sequenceField, result);
        }

        [Test]
        public void UseAfterDispose()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
            writer.Dispose();

            Assert.Throws<ObjectDisposedException>(() => writer.TryComputeLength(out var length));
            Assert.Throws<ObjectDisposedException>(() => writer.CopyTo(new MemoryStream(), default));
            Assert.ThrowsAsync<ObjectDisposedException>(async () => await writer.CopyToAsync(new MemoryStream(), default));
            Assert.Throws<ObjectDisposedException>(() => writer.ToBinaryData());
            Assert.DoesNotThrow(() => writer.Dispose());
        }

        //[Test]
        public void DisposeWithLoad_5000Times()
        {
            for (var i = 0; i < 5000; i++)
            {
                DisposeWithLoad();
            }
        }

        [Test]
        public void DisposeWithLoad()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
            writer.TryComputeLength(out var length);
            Assert.AreEqual(_modelSize, length);

            object sequenceBuilder = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(writer);
            Assert.IsNotNull(sequenceBuilder);

            writer.Dispose();

            // sequenceBuilder should be null because the writer was disposed
            sequenceBuilder = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(writer);
            Assert.AreEqual(typeof(object), sequenceBuilder?.GetType());
        }

        //[Test]
        public void DisposeWithoutLoad_5000Times()
        {
            for (var i = 0; i < 5000; i++)
            {
                DisposeWithoutLoad();
            }
        }

        [Test]
        public void DisposeWithoutLoad()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);

            writer.Dispose();

            // sequenceBuilder should be null because the writer was disposed
            object sequenceBuilder = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(writer);
            Assert.AreEqual(typeof(object), sequenceBuilder?.GetType());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ExceptionsAreBubbledUp(string format)
        {
            ExplodingModel model = new ExplodingModel();
            ModelSerializerOptions options = new ModelSerializerOptions(format);
            MemoryStream stream = new MemoryStream();

            using var writer = new ModelWriterInterlocked(model, options);
            Assert.Throws<NotImplementedException>(() => writer.TryComputeLength(out var length));
            Assert.Throws<NotImplementedException>(() => writer.CopyTo(stream, default));
            Assert.ThrowsAsync<NotImplementedException>(async () => await writer.CopyToAsync(stream, default));
            Assert.Throws<NotImplementedException>(() => writer.ToBinaryData());
        }

        //[Test]
        public void ParallelComputeLength_5000Times()
        {
            for (var i = 0; i < 5000; i++)
            {
                ParallelComputeLength();
            }
        }

        [Test]
        public void ParallelComputeLength()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);

            Parallel.For(0, 1000000, i =>
            {
                Assert.IsTrue(writer.TryComputeLength(out var length));
                Assert.AreEqual(_modelSize, length);
            });
        }

        //[Test]
        public void ParallelCopy_5000Times()
        {
            for (var i = 0; i < 5000; i++)
            {
                ParallelCopy();
            }
        }

        [Test]
        public void ParallelCopy()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);

            Parallel.For(0, 10000, i =>
            {
                using MemoryStream stream = new MemoryStream(_modelSize);
                writer.CopyTo(stream, default);
                Assert.AreEqual(_modelSize, stream.Length);
            });
        }

        //[Test]
        public void ParallelCopyAsync_5000Times()
        {
            for (var i = 0; i < 5000; i++)
            {
                ParallelCopyAsync();
            }
        }

        [Test]
        public void ParallelCopyAsync()
        {
            var writer = new ModelWriterInterlocked(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);

            Parallel.For(0, 10000, async i =>
            {
                using MemoryStream stream = new MemoryStream(_modelSize);
                await writer.CopyToAsync(stream, default);
                Assert.AreEqual(_modelSize, stream.Length);
            });
        }

        [Test]
        public async Task ArrayPoolStarvation()
        {
            var input1 = new ArrayModel(50_000_000, 1);
            var input2 = new ArrayModel(50_000_000, 2);
            using var writer1 = new ModelWriterInterlocked(input1, ModelSerializerOptions.DefaultWireOptions, 512);
            using var writer2 = new ModelWriterInterlocked(input2, ModelSerializerOptions.DefaultWireOptions, 512);

            var task1 = Task.Run(writer1.ToBinaryData);
            var task2 = Task.Run(writer2.ToBinaryData);

            await Task.WhenAll(task1, task2);

            AssertArrayModel(ArrayModel.Deserialize(task1.Result), input1.Value, input1.Length);
            AssertArrayModel(ArrayModel.Deserialize(task2.Result), input2.Value, input2.Length);
        }

        [Test]
        public async Task ReuseOfSharedArrays()
        {
            var task1 = Task.Run(() => Enumerable.Repeat(0, 25000).Select(_ =>
            {
                using var writer = new ModelWriterInterlocked(new ArrayModel(5000, 1), ModelSerializerOptions.DefaultWireOptions, 512);
                return writer.ToBinaryData();
            }).ToArray());

            var task2 = Task.Run(() => Enumerable.Repeat(0, 25000).Select(_ =>
            {
                using var writer = new ModelWriterInterlocked(new ArrayModel(5000, 2), ModelSerializerOptions.DefaultWireOptions, 512);
                return writer.ToBinaryData();
            }).ToArray());

            await Task.WhenAll(task1, task2);

            foreach (var data in task1.Result)
            {
                AssertArrayModel(ArrayModel.Deserialize(data), 1, 5000);
            }

            foreach (var data in task2.Result)
            {
                AssertArrayModel(ArrayModel.Deserialize(data), 2, 5000);
            }
        }

        private void AssertArrayModel(ArrayModel model, int value, int length)
        {
            if (model.Value != value)
            {
                Assert.Fail($"Unexpected {nameof(ArrayModel)}.{nameof(ArrayModel.Value)}. Expected: {value}, actual: {model.Value}.");
            }

            if (model.Length != length)
            {
                Assert.Fail($"Unexpected {nameof(ArrayModel)}.{nameof(ArrayModel.Length)}. Expected: {length}, actual: {model.Length}.");
            }
        }

        private static void AssertReadNextToken(ref Utf8JsonReader reader)
        {
            if (!reader.Read())
            {
                Assert.Fail("Unexpected end of object");
            }
        }

        private static void AssertNextToken(ref Utf8JsonReader reader, JsonTokenType expected)
        {
            if (!reader.Read())
            {
                Assert.Fail("Unexpected end of object");
            }

            if (reader.TokenType != expected)
            {
                Assert.Fail($"Wrong JSON token type: expected `{expected}`, actual `{reader.TokenType}`");
            }
        }

        private class ArrayModel : IModelJsonSerializable<ArrayModel>
        {
            public int Length { get; }
            public int Value { get; }
            public ArrayModel(int length, int value)
            {
                Assert.Positive(value);
                Assert.Less(value, 10);

                Length = length;
                Value = value;
            }

            public BinaryData Serialize(ModelSerializerOptions options)
            {
                using var stream = new MemoryStream();
                using var writer = new Utf8JsonWriter(stream);
                Serialize(writer, ModelSerializerOptions.DefaultWireOptions);
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }

            public ArrayModel Deserialize(BinaryData data, ModelSerializerOptions options) => Deserialize(data);

            public static ArrayModel Deserialize(BinaryData data)
            {
                var reader = new Utf8JsonReader(data.ToMemory().Span);
                return Deserialize(ref reader);
            }

            public void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("property");
                writer.WriteStartArray();
                for (var i = 0; i < Length; i++)
                {
                    writer.WriteNumberValue(Value);
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
            }

            public ArrayModel Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options) => Deserialize(ref reader);

            private static ArrayModel Deserialize(ref Utf8JsonReader reader)
            {
                AssertNextToken(ref reader, JsonTokenType.StartObject);
                AssertNextToken(ref reader, JsonTokenType.PropertyName);
                AssertNextToken(ref reader, JsonTokenType.StartArray);
                AssertReadNextToken(ref reader);

                var value = reader.GetInt32();
                var length = 1;

                while (reader.TokenType != JsonTokenType.EndArray)
                {
                    AssertReadNextToken(ref reader);
                    if (reader.TokenType == JsonTokenType.Number)
                    {
                        if (value != reader.GetInt32())
                        {
                            Assert.Fail($"Unexpected item in array. Expected value: {value}, actual value: {reader.GetInt32()}.");
                        }
                        length++;
                    }
                }

                AssertNextToken(ref reader, JsonTokenType.EndObject);
                return new ArrayModel(length, value);
            }
        }

        private class ExplodingModel : IModelJsonSerializable<ExplodingModel>
        {
            ExplodingModel IModelJsonSerializable<ExplodingModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            ExplodingModel IModelSerializable<ExplodingModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            void IModelJsonSerializable<ExplodingModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            BinaryData IModelSerializable<ExplodingModel>.Serialize(ModelSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
