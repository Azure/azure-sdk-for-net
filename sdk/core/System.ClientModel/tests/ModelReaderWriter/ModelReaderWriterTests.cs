// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class ModelReaderWriterTests
    {
        private static readonly ModelReaderWriterOptions s_wireOptions = new("W");

        private static readonly List<object> s_emptyCollections =
        [
            new List<SubType>(),
            new SubType[] { },
            new Collection<SubType> { },
            new ObservableCollection<SubType> { },
            new HashSet<SubType> { },
            new Queue<SubType> { },
            new Stack<SubType> { },
            new LinkedList<SubType> { },
            new SortedSet<SubType> { },
            new ArrayList { },
        ];

        [Test]
        public void ArgumentExceptions()
        {
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(null!));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(null!, typeof(BaseWithNoUnknown)));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(new BinaryData([]), null!));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write<BaseWithNoUnknown>(null!));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write(null!));

            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(null!, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(null!, typeof(BaseWithNoUnknown), s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(new BinaryData([]), null!, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write<BaseWithNoUnknown>(null!, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write(null!, s_wireOptions));
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "InvalidOperationBinaryData")]
        public void ValidateInvalidOperationBinaryData(BinaryData data)
        {
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<ModelX>(data));
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(data, typeof(ModelX)));
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "JsonExceptionBinaryData")]
        public void ValidateJsonExceptionBinaryData(BinaryData data)
        {
            bool gotException = false;
            try
            {
                ModelX? x = ModelReaderWriter.Read<ModelX>(data);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType().IsSubclassOf(typeof(JsonException)), $"Expected a subclass of {nameof(JsonException)} but got {ex.GetType().Name}");
                gotException = true;
            }

            Assert.IsTrue(gotException, "Did not receive exception");

            gotException = false;
            try
            {
                object? x = ModelReaderWriter.Read(data, typeof(ModelX));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType().IsSubclassOf(typeof(JsonException)), $"Expected a subclass of {nameof(JsonException)} but got {ex.GetType().Name}");
                gotException = true;
            }

            Assert.IsTrue(gotException, "Did not receive exception");
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "NullBinaryData")]
        public void ValidateNullBinaryData(BinaryData data)
        {
            Assert.Throws<JsonException>(() => ModelReaderWriter.Read<ModelX>(data));
            Assert.Throws<JsonException>(() => ModelReaderWriter.Read(data, typeof(ModelX)));
        }

        [TestCaseSource(typeof(ReaderWriterTestSource), "EmptyObjectBinaryData")]
        public void ValidateEmptyObjectBinaryData(BinaryData data)
        {
            Assert.Throws<JsonException>(() => ModelReaderWriter.Read<ModelX>(data));
            Assert.Throws<JsonException>(() => ModelReaderWriter.Read(data, typeof(ModelX)));
        }

        [Test]
        public void ValidateErrorIfUnknownDoesntExist()
        {
            BaseWithNoUnknown baseInstance = new SubType();
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(new BinaryData([])));
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(new BinaryData([]), typeof(BaseWithNoUnknown)));
        }

        [Test]
        public void ValidateErrorIfNoDefaultCtor()
        {
            Assert.Throws<MissingMethodException>(() => ModelReaderWriter.Read<ModelWithNoDefaultCtor>(new BinaryData([])));
        }

        [Test]
        public void ValidateErrorIfNotImplementInterface()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(new BinaryData([]), typeof(DoesNotImplementInterface)));
            Assert.IsTrue(ex?.Message.Contains("does not implement"));
            ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(new DoesNotImplementInterface()));
            Assert.IsTrue(ex?.Message.Contains("does not implement"));
        }

        [Test]
        public void EmptyEnumerableOfNoInterface()
        {
            List<DoesNotImplementInterface> list = [];
            BinaryData data = ModelReaderWriter.Write(list);
            Assert.AreEqual("[]", data.ToString());
        }

        [Test]
        public void EmptyEnumerableOfNonJson()
        {
            List<SubType> list = [];
            BinaryData data = ModelReaderWriter.Write(list, new ModelReaderWriterOptions("X"));
            Assert.AreEqual("[]", data.ToString());
        }

        [Test]
        public void EnumerableOfNoInterface()
        {
            List<DoesNotImplementInterface> list =
            [
                new DoesNotImplementInterface(),
            ];
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list));
        }

        [Test]
        public void EnumerableOfNonJson()
        {
            List<SubType> list =
            [
                new SubType(),
            ];
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("X")));
        }

        [TestCaseSource(nameof(s_emptyCollections))]
        public void WriteEmptyCollection(object collection)
        {
            BinaryData data = ModelReaderWriter.Write(collection);
            Assert.IsNotNull(data);
            Assert.AreEqual("[]", data.ToString());
        }

        [Test]
        public void WriteDictionaryOfInterface()
        {
            Dictionary<string, SubType> dict = new()
            {
                { "key", new SubType() },
            };
            BinaryData data = ModelReaderWriter.Write(dict);
            Assert.IsNotNull(data);
            Assert.AreEqual("{\"key\":{}}", data.ToString());
        }

        [Test]
        public void NullOptionsWritesJson()
        {
            BinaryData data = ModelReaderWriter.Write(new SubType(), null);
            Assert.IsNotNull(data);
            Assert.AreEqual("{}", data.ToString());
        }

        [Test]
        public void ReadListOfNonPersistableFails()
        {
            var json = "[{\"x\":1},{\"y\":2}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<DoesNotImplementInterface>>(BinaryData.FromString(json)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.EndsWith(" must implement IJsonModel<>."));
        }

        [Test]
        public void ReadListOfDictionariesAsListOfLists()
        {
            var json = "[{\"x\":{}},{\"y\":{}}]";
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<List<SubType>>>(BinaryData.FromString(json)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Equals("Unexpected StartObject found."));
        }

        [Test]
        public void ReadListOfListsAsListOfDictionaries()
        {
            var json = "[[{}],[{}]]";
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<Dictionary<string, SubType>>>(BinaryData.FromString(json)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Equals("Unexpected StartArray found."));
        }

        [Test]
        public void ReadUnexpectedToken()
        {
            var json = "[null{}]";
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<SubType>>(BinaryData.FromString(json)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Equals("Unexpected token Null."));
        }

        [Test]
        public void ReadDictionaryWithNoPropertyNames()
        {
            bool foundException = false;
            var json = "{{},{}}";
            try
            {
                var result = ModelReaderWriter.Read<Dictionary<string, SubType>>(BinaryData.FromString(json));
            }
            catch (Exception ex)
            {
                foundException = true;
                Assert.IsTrue(ex.GetType().Name.Equals("JsonReaderException"));
                Assert.IsTrue(ex.Message.StartsWith("'{' is an invalid start of a property name."));
            }
            Assert.IsTrue(foundException, "Expected an exception but none was thrown");
        }

        private class DoesNotImplementInterface { }

        private class SubType : BaseWithNoUnknown, IJsonModel<SubType>
        {
            string IPersistableModel<SubType>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            SubType IJsonModel<SubType>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                return new SubType();
            }

            SubType IPersistableModel<SubType>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                return new SubType();
            }

            void IJsonModel<SubType>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
                return;
            }

            BinaryData IPersistableModel<SubType>.Write(ModelReaderWriterOptions options)
            {
                return new BinaryData(Array.Empty<byte>());
            }
        }

        private abstract class BaseWithNoUnknown : IJsonModel<BaseWithNoUnknown>
        {
            string IPersistableModel<BaseWithNoUnknown>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            BaseWithNoUnknown IJsonModel<BaseWithNoUnknown>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                return new SubType();
            }

            BaseWithNoUnknown IPersistableModel<BaseWithNoUnknown>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                return new SubType();
            }

            void IJsonModel<BaseWithNoUnknown>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
                return;
            }

            BinaryData IPersistableModel<BaseWithNoUnknown>.Write(ModelReaderWriterOptions options)
            {
                return new BinaryData(Array.Empty<byte>());
            }
        }

        private class ModelWithNoDefaultCtor : IJsonModel<ModelWithNoDefaultCtor>
        {
            public ModelWithNoDefaultCtor(int x) { }

            string IPersistableModel<ModelWithNoDefaultCtor>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            ModelWithNoDefaultCtor IJsonModel<ModelWithNoDefaultCtor>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                return new ModelWithNoDefaultCtor(1);
            }

            ModelWithNoDefaultCtor IPersistableModel<ModelWithNoDefaultCtor>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                return new ModelWithNoDefaultCtor(1);
            }

            void IJsonModel<ModelWithNoDefaultCtor>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                return;
            }

            BinaryData IPersistableModel<ModelWithNoDefaultCtor>.Write(ModelReaderWriterOptions options)
            {
                return new BinaryData(Array.Empty<byte>());
            }
        }
    }
}
