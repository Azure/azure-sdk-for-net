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
        private static readonly LocalContext s_readerWriterContext = new();

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
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, null!));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write<BaseWithNoUnknown>(null!));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write(null!));

            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(null!, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(null!, typeof(BaseWithNoUnknown), s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, null!, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write<BaseWithNoUnknown>(null!, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write(null!, s_wireOptions));

            //validate context overload for read
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(null!, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(null!, typeof(BaseWithNoUnknown), s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, null!, s_readerWriterContext));

            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(null!, s_readerWriterContext, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(null!, typeof(BaseWithNoUnknown), s_readerWriterContext, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, null!, s_readerWriterContext, s_wireOptions));
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
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(BinaryData.Empty));
            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.Empty, typeof(BaseWithNoUnknown)));
        }

        [Test]
        public void ValidateErrorIfNoDefaultCtor()
        {
            Assert.Throws<MissingMethodException>(() => ModelReaderWriter.Read<ModelWithNoDefaultCtor>(BinaryData.Empty));
        }

        [Test]
        public void ValidateErrorIfNotImplementInterface()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.Empty, typeof(DoesNotImplementInterface)));
            Assert.IsTrue(ex?.Message.Contains("does not implement"));
            ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(new DoesNotImplementInterface()));
            Assert.AreEqual("System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+DoesNotImplementInterface must implement IEnumerable or IPersistableModel", ex!.Message);
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
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("X")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Format 'X' is not supported only 'J' or 'W' format can be written as collections", ex!.Message);
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
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<DoesNotImplementInterface>>(BinaryData.FromString(json), s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.EndsWith("does not implement IPersistableModel"));
        }

        [Test]
        public void ReadListOfDictionariesAsListOfLists()
        {
            var json = "[{\"x\":{}},{\"y\":{}}]";
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<List<SubType>>>(BinaryData.FromString(json), s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Equals("Unexpected StartObject found."));
        }

        [Test]
        public void ReadListOfListsAsListOfDictionaries()
        {
            var json = "[[{}],[{}]]";
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<Dictionary<string, SubType>>>(BinaryData.FromString(json), s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Equals("Unexpected StartArray found."));
        }

        [Test]
        public void ReadUnexpectedToken()
        {
            var json = "[null{}]";
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<SubType>>(BinaryData.FromString(json), s_readerWriterContext));
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
                var result = ModelReaderWriter.Read<Dictionary<string, SubType>>(BinaryData.FromString(json), s_readerWriterContext);
            }
            catch (Exception ex)
            {
                foundException = true;
                Assert.IsTrue(ex.GetType().Name.Equals("JsonReaderException"), $"Expected JsonReaderException but got {ex.GetType().Name} with message: {ex.Message}");
                Assert.IsTrue(ex.Message.StartsWith("'{' is an invalid start of a property name."));
            }
            Assert.IsTrue(foundException, "Expected an exception but none was thrown");
        }

        [Test]
        public void ReadListNonGeneric()
        {
            var json = "[{},{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(List<SubType>)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.EndsWith("does not implement IPersistableModel"));
        }

        [Test]
        public void ReadListOfListNonGeneric()
        {
            var json = "[{},{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(List<List<SubType>>)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.EndsWith("does not implement IPersistableModel"));
        }

        [Test]
        public void WriteListNonJWire()
        {
            var list = new List<NonJWire>() { new NonJWire() };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+NonJWire has a wire format of 'X' it must be 'J' to be written as a collection", ex!.Message);
        }

        [Test]
        public void WriteListOfListNonJWire()
        {
            var list = new List<List<NonJWire>>() { new List<NonJWire>() { new NonJWire() } };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+NonJWire has a wire format of 'X' it must be 'J' to be written as a collection", ex!.Message);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void WriteListPersistableModel(string format)
        {
            var list = new List<PersistableModel>() { new PersistableModel() };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions(format)));
            Assert.IsNotNull(ex);
            var expectedMessage = format == "J"
                ? "System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+PersistableModel does not implement IJsonModel or IEnumerable<IJsonModel>"
                : "System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+PersistableModel has a wire format of 'X' it must be 'J' to be written as a collection";
            Assert.AreEqual(expectedMessage, ex!.Message);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void WriteListOfListPersistableModel(string format)
        {
            var list = new List<List<PersistableModel>>() { new List<PersistableModel>() { new PersistableModel() } };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions(format)));
            Assert.IsNotNull(ex);
            var expectedMessage = format == "J"
                ? "System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+PersistableModel does not implement IJsonModel or IEnumerable<IJsonModel>"
                : "System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+PersistableModel has a wire format of 'X' it must be 'J' to be written as a collection";
            Assert.AreEqual(expectedMessage, ex!.Message);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ReadListOfPersistableModel(string format)
        {
            var json = "[{},{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<PersistableModel>>(BinaryData.FromString(json), s_readerWriterContext, new ModelReaderWriterOptions(format)));
            Assert.IsNotNull(ex);
            var expectedMessage = format == "J"
                ? "Element type System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+PersistableModel must implement IJsonModel"
                : "System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+PersistableModel has a wire format of 'X' it must be 'J' to be read as a collection";
            Assert.AreEqual(expectedMessage, ex!.Message);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ReadListOfListOfPersistableModel(string format)
        {
            var json = "[[{},{}]]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<List<PersistableModel>>>(BinaryData.FromString(json), s_readerWriterContext, new ModelReaderWriterOptions(format)));
            Assert.IsNotNull(ex);
            var expectedMessage = format == "J"
                ? "Element type System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+PersistableModel must implement IJsonModel"
                : "System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+PersistableModel has a wire format of 'X' it must be 'J' to be read as a collection";
            Assert.AreEqual(expectedMessage, ex!.Message);
        }

        [Test]
        public void ReadListNonJWire()
        {
            var json = "[{},{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<NonJWire>>(BinaryData.FromString(json), s_readerWriterContext, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+NonJWire has a wire format of 'X' it must be 'J' to be read as a collection", ex!.Message);
        }

        [Test]
        public void ReadListOfListNonJWire()
        {
            var json = "[[{},{}]]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<List<NonJWire>>>(BinaryData.FromString(json), s_readerWriterContext, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("System.ClientModel.Tests.ModelReaderWriterTests.ModelReaderWriterTests+NonJWire has a wire format of 'X' it must be 'J' to be read as a collection", ex!.Message);
        }

        [Test]
        public void ReadNoActivator()
        {
            var json = "{}";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<NoActivator>(BinaryData.FromString(json), s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No activator found for NoActivator.", ex!.Message);
        }

        [Test]
        public void ReadListOfNoActivator()
        {
            var json = "[{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<NoActivator>>(BinaryData.FromString(json), s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No activator found for List`1.", ex!.Message);
        }

        [Test]
        public void ReadListOfListOfNoActivator()
        {
            var json = "[[{}]]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<List<NoActivator>>>(BinaryData.FromString(json), s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No activator found for List`1.", ex!.Message);
        }

        private class DoesNotImplementInterface { }

        private class NoActivator : IPersistableModel<NoActivator>
        {
            public NoActivator Create(BinaryData data, ModelReaderWriterOptions options)
            {
                return new NoActivator();
            }

            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "X";

            public BinaryData Write(ModelReaderWriterOptions options)
            {
                return BinaryData.Empty;
            }
        }

        private class PersistableModel : IPersistableModel<PersistableModel>
        {
            public PersistableModel Create(BinaryData data, ModelReaderWriterOptions options)
            {
                return new PersistableModel();
            }

            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "X";

            public BinaryData Write(ModelReaderWriterOptions options)
            {
                return BinaryData.Empty;
            }
        }

        private class NonJWire : IJsonModel<NonJWire>
        {
            public NonJWire Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                return new NonJWire();
            }

            public NonJWire Create(BinaryData data, ModelReaderWriterOptions options)
            {
                return new NonJWire();
            }

            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "X";

            public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
                return;
            }

            public BinaryData Write(ModelReaderWriterOptions options)
            {
                return BinaryData.Empty;
            }
        }

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
                return BinaryData.Empty;
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
                return BinaryData.Empty;
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
                return BinaryData.Empty;
            }
        }

        private class LocalContext : ModelReaderWriterContext
        {
            private Lazy<TestModelReaderWriterContext> _LibraryContext = new Lazy<TestModelReaderWriterContext>(() => new TestModelReaderWriterContext());

            public override Func<object>? GetActivator(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Dictionary<string, SubType>) => () => new Dictionary<string, SubType>(),
                    Type t when t == typeof(List<List<SubType>>) => () => new List<List<SubType>>(),
                    Type t when t == typeof(List<SubType>) => () => new List<SubType>(),
                    Type t when t == typeof(List<Dictionary<string, SubType>>) => () => new List<Dictionary<string, SubType>>(),
                    Type t when t == typeof(List<DoesNotImplementInterface>) => () => new List<DoesNotImplementInterface>(),
                    Type t when t == typeof(SubType) => () => new SubType(),
                    Type t when t == typeof(DoesNotImplementInterface) => () => new DoesNotImplementInterface(),
                    Type t when t == typeof(NonJWire) => () => new NonJWire(),
                    Type t when t == typeof(PersistableModel) => () => new PersistableModel(),
                    Type t when t == typeof(List<PersistableModel>) => () => new List<PersistableModel>(),
                    Type t when t == typeof(List<List<PersistableModel>>) => () => new List<List<PersistableModel>>(),
                    Type t when t == typeof(List<NonJWire>) => () => new List<NonJWire>(),
                    Type t when t == typeof(List<List<NonJWire>>) => () => new List<List<NonJWire>>(),
                    _ => _LibraryContext.Value.GetActivator(type)
                };
            }
        }
    }
}
