// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class JsonObjectSerializerTest
    {
        private static readonly JsonObjectSerializer JsonObjectSerializer = new JsonObjectSerializer(new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        [Test]
        public void CanSerializeAnObject()
        {
            using var memoryStream = new MemoryStream();
            var o = new Model {A = "1", B = 2};

            JsonObjectSerializer.Serialize(memoryStream, o, o.GetType(), default);

            Assert.AreEqual("{\"a\":\"1\",\"b\":2}", Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public async Task CanSerializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream();
            var o = new Model {A = "1", B = 2};

            await JsonObjectSerializer.SerializeAsync(memoryStream, o, o.GetType(), default);

            var aB = "{\"a\":\"1\",\"b\":2}";
            Assert.AreEqual(aB, Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public void CanDeserializeAnObject()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"a\":\"1\",\"b\":2}"));

            var model = (Model)JsonObjectSerializer.Deserialize(memoryStream, typeof(Model), default);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.B);
        }

        [Test]
        public async Task CanDeserializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"a\":\"1\",\"b\":2}"));

            var model = (Model)await JsonObjectSerializer.DeserializeAsync(memoryStream, typeof(Model), default).ConfigureAwait(false);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.B);
        }

        public class Model
        {
            public string A { get; set; }
            public int B { get; set; }
        }
    }
}