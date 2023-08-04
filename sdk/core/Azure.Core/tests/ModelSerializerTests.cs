// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerialization
{
    public class ModelSerializerTests
    {
        [Test]
        public void ValidateErrorIfUnknownDoesntExist()
        {
            BaseWithNoUnknown baseInstance = new SubType();
            var ex = Assert.Throws<InvalidOperationException>(() => ModelSerializer.Deserialize<BaseWithNoUnknown>(new BinaryData(Array.Empty<byte>())));
            Assert.IsTrue(ex.Message.Contains("Unable to find type Unknown"));
            ex = Assert.Throws<InvalidOperationException>(() => ModelSerializer.Deserialize(new BinaryData(Array.Empty<byte>()), typeof(BaseWithNoUnknown)));
            Assert.IsTrue(ex.Message.Contains("Unable to find type Unknown"));
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
