// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.ModelSerializationTests.Models;
using Azure.Core.Tests.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerialization
{
    /// <summary>
    /// Happy path tests are in the public test project in the ModelTests class using the JsonInterfaceStrategy.
    /// This class is used for testing the internal properties of ModelWriter.
    /// </summary>
    public class ModelWriterTests
    {
        private const int _modelSize = 156000;
        private static readonly string _json = File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData.json"));
        private static readonly ResourceProviderData _resourceProviderData = ModelSerializer.Deserialize<ResourceProviderData>(BinaryData.FromString(_json));

        [Test]
        public void ThrowsIfUnsupportedFormat()
        {
            ModelXml model = ModelSerializer.Deserialize<ModelXml>(BinaryData.FromString(File.ReadAllText(TestData.GetLocation("ModelXml.xml"))));
            ModelWriter writer = new ModelWriter(model, new ModelSerializerOptions("x"));
            Assert.Throws<FormatException>(() => writer.ToBinaryData());
        }

        [Test]
        public void ThrowsIfMismatch()
        {
            ModelXml model = ModelSerializer.Deserialize<ModelXml>(BinaryData.FromString(File.ReadAllText(TestData.GetLocation("ModelXml.xml"))));
            ModelWriter writer = new ModelWriter(model, ModelSerializerOptions.DefaultWireOptions);
            Assert.Throws<InvalidOperationException>(() => writer.ToBinaryData());
        }

        [Test]
        public async Task HappyPath()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
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

        [Test]
        public async Task DisposeWhileConvertToBinaryData()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
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

        [Test]
        public async Task DisposeWhileCopyAsync()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
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

        private static async Task DisposeAfterStart(ModelWriter writer, FieldInfo sequenceField, Task result)
        {
            writer.Dispose();
            object sequenceBuilder = sequenceField.GetValue(writer);
            Assert.IsNull(sequenceBuilder);

            await result;

            sequenceBuilder = sequenceField.GetValue(writer);
            Assert.IsNull(sequenceBuilder);
        }

        [Test]
        public async Task DisposeWhileCopy()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
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

        [Test]
        public async Task DisposeWhileGettingLength()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
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

        private static void Validate(ModelWriter writer, FieldInfo sequenceField, bool exceptionThrown, long length)
        {
            // sequenceBuilder should be null because the writer was disposed
            object sequenceBuilder = sequenceField.GetValue(writer);
            Assert.IsNull(sequenceBuilder);

            // The dispose should wait for the serialization to finish
            // because of thread timing the dispose might happen before the readCount is incremented
            // In this case the length of the stream will be 0 otherwise the length will be the size of the model
            // Both cases are expected and valid the idea being that the dispose should wait for the serialization to finish if it starts second
            // and if it starts first then the original thread should get an ObjectDisposedException
            Assert.AreEqual(exceptionThrown ? 0 : _modelSize, length);
        }

        [Test]
        public void UseAfterDispose()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
            writer.Dispose();

            Assert.Throws<ObjectDisposedException>(() => writer.TryComputeLength(out var length));
            Assert.Throws<ObjectDisposedException>(() => writer.CopyTo(new MemoryStream(), default));
            Assert.ThrowsAsync<ObjectDisposedException>(async () => await writer.CopyToAsync(new MemoryStream(), default));
            Assert.Throws<ObjectDisposedException>(() => writer.ToBinaryData());
            Assert.DoesNotThrow(() => writer.Dispose());
        }

        [Test]
        public void DisposeWithLoad()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);
            writer.TryComputeLength(out var length);
            Assert.AreEqual(_modelSize, length);

            object sequenceBuilder = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(writer);
            Assert.IsNotNull(sequenceBuilder);

            writer.Dispose();

            // sequenceBuilder should be null because the writer was disposed
            sequenceBuilder = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(writer);
            Assert.IsNull(sequenceBuilder);
        }

        [Test]
        public void DisposeWithoutLoad()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);

            writer.Dispose();

            // sequenceBuilder should be null because the writer was disposed
            object sequenceBuilder = writer.GetType().GetField("_sequenceBuilder", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(writer);
            Assert.IsNull(sequenceBuilder);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ExceptionsAreBubbledUp(string format)
        {
            ExplodingModel model = new ExplodingModel();
            ModelSerializerOptions options = new ModelSerializerOptions(format);
            MemoryStream stream = new MemoryStream();

            using ModelWriter writer = new ModelWriter(model, options);
            Assert.Throws<NotImplementedException>(() => writer.TryComputeLength(out var length));
            Assert.Throws<NotImplementedException>(() => writer.CopyTo(stream, default));
            Assert.ThrowsAsync<NotImplementedException>(async () => await writer.CopyToAsync(stream, default));
            Assert.Throws<NotImplementedException>(() => writer.ToBinaryData());
        }

        [Test]
        public void ParallelComputLength()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);

            Parallel.For(0, 1000000, i =>
            {
                Assert.IsTrue(writer.TryComputeLength(out var length));
                Assert.AreEqual(_modelSize, length);
            });
        }

        [Test]
        public void ParallelCopy()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);

            Parallel.For(0, 10000, i =>
            {
                using MemoryStream stream = new MemoryStream(_modelSize);
                writer.CopyTo(stream, default);
                Assert.AreEqual(_modelSize, stream.Length);
            });
        }

        [Test]
        public void ParallelCopyAsync()
        {
            ModelWriter writer = new ModelWriter(_resourceProviderData, ModelSerializerOptions.DefaultWireOptions);

            Parallel.For(0, 10000, async i =>
            {
                using MemoryStream stream = new MemoryStream(_modelSize);
                await writer.CopyToAsync(stream, default);
                Assert.AreEqual(_modelSize, stream.Length);
            });
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
