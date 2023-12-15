// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.ModelSerializationTests.Models;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerialization
{
    public class ModelSerializerTests
    {
        [Test]
        public void ArgumentExceptions()
        {
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Deserialize<BaseWithNoUnknown>(null));
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Deserialize(null, typeof(BaseWithNoUnknown)));
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Deserialize(new BinaryData(new byte[] { }), null));
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Serialize<BaseWithNoUnknown>(null));
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Serialize(null));

            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Deserialize<BaseWithNoUnknown>(null, ModelSerializerFormat.Wire));
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Deserialize(null, typeof(BaseWithNoUnknown), ModelSerializerFormat.Wire));
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Deserialize(new BinaryData(new byte[] { }), null, ModelSerializerFormat.Wire));
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Serialize<BaseWithNoUnknown>(null, ModelSerializerFormat.Wire));
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.Serialize(null, ModelSerializerFormat.Wire));

            Assert.Throws<ArgumentNullException>(() => ModelSerializer.SerializeCore(null, new ModelSerializerOptions()));
            Assert.Throws<ArgumentNullException>(() => ModelSerializer.SerializeCore(new ModelX(), null));
        }

        [TestCaseSource(typeof(SerializationTestSource), "InvalidOperationBinaryData")]
        public void ValidateInvalidOperationBinaryData(BinaryData data)
        {
            Assert.Throws<InvalidOperationException>(() => ModelSerializer.Deserialize<ModelX>(data));
            Assert.Throws<InvalidOperationException>(() => ModelSerializer.Deserialize(data, typeof(ModelX)));
        }

        [TestCaseSource(typeof(SerializationTestSource), "JsonExceptionBinaryData")]
        public void ValidateJsonExceptionBinaryData(BinaryData data)
        {
            bool gotException = false;
            try
            {
                ModelX x = ModelSerializer.Deserialize<ModelX>(data);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType().IsSubclassOf(typeof(JsonException)), $"Expected a subclass of {nameof(JsonException)} but got {ex.GetType().Name}");
                gotException = true;
            }

            Assert.IsTrue(gotException, "Did not recieve exception");

            gotException = false;
            try
            {
                object x = ModelSerializer.Deserialize(data, typeof(ModelX));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType().IsSubclassOf(typeof(JsonException)), $"Expected a subclass of {nameof(JsonException)} but got {ex.GetType().Name}");
                gotException = true;
            }

            Assert.IsTrue(gotException, "Did not recieve exception");
        }

        [TestCaseSource(typeof(SerializationTestSource), "NullBinaryData")]
        public void ValidateNullBinaryData(BinaryData data)
        {
            Assert.IsNull(ModelSerializer.Deserialize<ModelX>(data));
            Assert.IsNull(ModelSerializer.Deserialize(data, typeof(ModelX)));
        }

        [TestCaseSource(typeof(SerializationTestSource), "EmptyObjectBinaryData")]
        public void ValidateEmptyObjectBinaryData(BinaryData data)
        {
            ModelX x = ModelSerializer.Deserialize<ModelX>(data);
            Assert.IsNotNull(x);
            Assert.IsNull(x.Kind);

            object obj = ModelSerializer.Deserialize(data, typeof(ModelX));
            Assert.IsNotNull(obj);
            Assert.IsNull(((ModelX)obj).Kind);
        }

        [Test]
        public void ValidateErrorIfUnknownDoesntExist()
        {
            BaseWithNoUnknown baseInstance = new SubType();
            Assert.Throws<InvalidOperationException>(() => ModelSerializer.Deserialize<BaseWithNoUnknown>(new BinaryData(Array.Empty<byte>())));
            Assert.Throws<InvalidOperationException>(() => ModelSerializer.Deserialize(new BinaryData(Array.Empty<byte>()), typeof(BaseWithNoUnknown)));
        }

        [Test]
        public void ValidateErrorIfNoDefaultCtor()
        {
            Assert.Throws<MissingMethodException>(() => ModelSerializer.Deserialize<ModelWithNoDefaultCtor>(new BinaryData(Array.Empty<byte>())));
        }

        [Test]
        public void ValidateErrorIfNotImplementInterface()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelSerializer.Deserialize(new BinaryData(Array.Empty<byte>()), typeof(DoesntImplementInterface)));
            Assert.IsTrue(ex.Message.Contains("does not implement"));
            ex = Assert.Throws<InvalidOperationException>(() => ModelSerializer.Serialize(new DoesntImplementInterface()));
            Assert.IsTrue(ex.Message.Contains("does not implement"));
        }

        public class DoesntImplementInterface { }

        private class SubType : BaseWithNoUnknown, IModelJsonSerializable<SubType>
        {
            SubType IModelJsonSerializable<SubType>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
            {
                return new SubType();
            }

            SubType IModelSerializable<SubType>.Deserialize(BinaryData data, ModelSerializerOptions options)
            {
                return new SubType();
            }

            void IModelJsonSerializable<SubType>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
            {
                return;
            }

            BinaryData IModelSerializable<SubType>.Serialize(ModelSerializerOptions options)
            {
                return new BinaryData(Array.Empty<byte>());
            }
        }

        private abstract class BaseWithNoUnknown : IModelJsonSerializable<BaseWithNoUnknown>
        {
            BaseWithNoUnknown IModelJsonSerializable<BaseWithNoUnknown>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
            {
                return new SubType();
            }

            BaseWithNoUnknown IModelSerializable<BaseWithNoUnknown>.Deserialize(BinaryData data, ModelSerializerOptions options)
            {
                return new SubType();
            }

            void IModelJsonSerializable<BaseWithNoUnknown>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
            {
                return;
            }

            BinaryData IModelSerializable<BaseWithNoUnknown>.Serialize(ModelSerializerOptions options)
            {
                return new BinaryData(Array.Empty<byte>());
            }
        }

        public class ModelWithNoDefaultCtor : IModelJsonSerializable<ModelWithNoDefaultCtor>
        {
            public ModelWithNoDefaultCtor(int x) { }

            ModelWithNoDefaultCtor IModelJsonSerializable<ModelWithNoDefaultCtor>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
            {
                return new ModelWithNoDefaultCtor(1);
            }

            ModelWithNoDefaultCtor IModelSerializable<ModelWithNoDefaultCtor>.Deserialize(BinaryData data, ModelSerializerOptions options)
            {
                return new ModelWithNoDefaultCtor(1);
            }

            void IModelJsonSerializable<ModelWithNoDefaultCtor>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
            {
                return;
            }

            BinaryData IModelSerializable<ModelWithNoDefaultCtor>.Serialize(ModelSerializerOptions options)
            {
                return new BinaryData(Array.Empty<byte>());
            }
        }
    }
}
