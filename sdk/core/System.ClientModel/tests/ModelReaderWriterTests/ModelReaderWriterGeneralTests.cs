// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class ModelReaderWriterGeneralTests
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
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write<BaseWithNoUnknown>(null!, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write(null!, s_readerWriterContext));

            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(null!, s_readerWriterContext, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(null!, typeof(BaseWithNoUnknown), s_readerWriterContext, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, null!, s_readerWriterContext, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write<BaseWithNoUnknown>(null!, s_readerWriterContext, s_wireOptions));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write(null!, s_readerWriterContext, s_wireOptions));
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
            Assert.AreEqual("DoesNotImplementInterface does not implement IPersistableModel", ex!.Message);
        }

        [Test]
        public void EmptyEnumerableOfNoInterface()
        {
            List<DoesNotImplementInterface> list = [];
            BinaryData data = ModelReaderWriter.Write(list, s_readerWriterContext);
            Assert.AreEqual("[]", data.ToString());
        }

        [Test]
        public void Write_EmptyEnumerableOfNonJson()
        {
            List<SubType> list = [];
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, s_readerWriterContext, new ModelReaderWriterOptions("X")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Format 'X' is not supported only 'J' or 'W' format can be written as collections", ex!.Message);
        }

        [Test]
        public void Read_EmptyEnumerableOfNonJson()
        {
            var json = "[]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(List<SubType>), s_readerWriterContext, new ModelReaderWriterOptions("X")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Format 'X' is not supported only 'J' or 'W' format can be read as collections", ex!.Message);
        }

        [Test]
        public void ReadDictionaryWhenList()
        {
            var data = BinaryData.FromString(File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataList.json")).TrimEnd());
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<Dictionary<string, AvailabilitySetData>>(data, s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Expected start of dictionary.", ex!.Message);
        }

        [Test]
        public void ReadUnsupportedCollectionGeneric()
        {
            //make sure SortedDictionary is not in s_readerWriterContext
            var data = BinaryData.FromString(File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataList.json")).TrimEnd());
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<SortedDictionary<string, AvailabilitySetData>>(data, s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No model info found for SortedDictionary`2.", ex!.Message);
        }

        [Test]
        public void ReadListWhenDictionary()
        {
            var data = BinaryData.FromString(File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd());
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<AvailabilitySetData>>(data, s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Equals("Expected start of array."));
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
            BinaryData data = ModelReaderWriter.Write(collection, s_readerWriterContext);
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
            BinaryData data = ModelReaderWriter.Write(dict, s_readerWriterContext);
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
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, s_readerWriterContext, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("NonJWire has a wire format of 'X' it must be 'J' to be written as a collection", ex!.Message);
        }

        [Test]
        public void WriteListOfListNonJWire()
        {
            var list = new List<List<NonJWire>>() { new List<NonJWire>() { new NonJWire() } };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, s_readerWriterContext, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("NonJWire has a wire format of 'X' it must be 'J' to be written as a collection", ex!.Message);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void WriteListPersistableModel(string format)
        {
            var list = new List<PersistableModel>() { new PersistableModel() };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, s_readerWriterContext, new ModelReaderWriterOptions(format)));
            Assert.IsNotNull(ex);
            var expectedMessage = format == "J"
                ? "PersistableModel does not implement IJsonModel or IEnumerable<IJsonModel>"
                : "PersistableModel has a wire format of 'X' it must be 'J' to be written as a collection";
            Assert.AreEqual(expectedMessage, ex!.Message);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void WriteListOfListPersistableModel(string format)
        {
            var list = new List<List<PersistableModel>>() { new List<PersistableModel>() { new PersistableModel() } };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, s_readerWriterContext, new ModelReaderWriterOptions(format)));
            Assert.IsNotNull(ex);
            var expectedMessage = format == "J"
                ? "PersistableModel does not implement IJsonModel or IEnumerable<IJsonModel>"
                : "PersistableModel has a wire format of 'X' it must be 'J' to be written as a collection";
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
                ? "Element type PersistableModel must implement IJsonModel or CollectionBuilder"
                : "PersistableModel has a wire format of 'X' it must be 'J' to be read as a collection";
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
                ? "Element type PersistableModel must implement IJsonModel or CollectionBuilder"
                : "PersistableModel has a wire format of 'X' it must be 'J' to be read as a collection";
            Assert.AreEqual(expectedMessage, ex!.Message);
        }

        [Test]
        public void ReadListNonJWire()
        {
            var json = "[{},{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<NonJWire>>(BinaryData.FromString(json), s_readerWriterContext, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("NonJWire has a wire format of 'X' it must be 'J' to be read as a collection", ex!.Message);
        }

        [Test]
        public void ReadListOfListNonJWire()
        {
            var json = "[[{},{}]]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<List<NonJWire>>>(BinaryData.FromString(json), s_readerWriterContext, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("NonJWire has a wire format of 'X' it must be 'J' to be read as a collection", ex!.Message);
        }

        [Test]
        public void ReadNoActivator()
        {
            var json = "{}";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<NoActivator>(BinaryData.FromString(json), s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No model info found for NoActivator.", ex!.Message);
        }

        [Test]
        public void ReadListOfNoActivator()
        {
            var json = "[{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<NoActivator>>(BinaryData.FromString(json), s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No model info found for List`1.", ex!.Message);
        }

        [Test]
        public void ReadListOfListOfNoActivator()
        {
            var json = "[[{}]]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<List<NoActivator>>>(BinaryData.FromString(json), s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No model info found for List`1.", ex!.Message);
        }

        [Test]
        public void Read_NullReturn_Generic()
        {
            var json = "{}";
            var result = ModelReaderWriter.Read<ReadReturnsNull>(BinaryData.FromString(json));
            Assert.IsNull(result);
        }

        [Test]
        public void Read_NullReturn_NonGeneric()
        {
            var json = "{}";
            var result = ModelReaderWriter.Read(BinaryData.FromString(json), typeof(ReadReturnsNull));
            Assert.IsNull(result);
        }

        [Test]
        public void Read_NullReturn_Generic_WithContext()
        {
            var json = "{}";
            var result = ModelReaderWriter.Read<ReadReturnsNull>(BinaryData.FromString(json), s_readerWriterContext);
            Assert.IsNull(result);
        }

        [Test]
        public void Read_NullReturn_NonGeneric_WithContext()
        {
            var json = "{}";
            var result = ModelReaderWriter.Read(BinaryData.FromString(json), typeof(ReadReturnsNull), s_readerWriterContext);
            Assert.IsNull(result);
        }

        [Test]
        public void ReadBadAbstractType()
        {
            var json = "{}";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(Stream)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Contains("must be decorated with PersistableModelProxyAttribute"));
        }

        [Test]
        public void ReadBadValueType()
        {
            var json = "{}";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(int)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Contains("does not implement IPersistableModel"));
        }

        [Test]
        public void ReadNoPublicCtorType()
        {
            var json = "{}";
#if NET5_0_OR_GREATER
            var ex = Assert.Throws<MissingMethodException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(FileStream)));
            Assert.IsNotNull(ex);
#else
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(FileStream)));
            Assert.IsNotNull(ex);
#endif
        }

        private class ReadReturnsNull : IPersistableModel<ReadReturnsNull>
        {
            public ReadReturnsNull Create(BinaryData data, ModelReaderWriterOptions options)
            {
                return null!;
            }

            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
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
            private static readonly Lazy<TestClientModelReaderWriterContext> _LibraryContext = new(() => new());
            private static readonly Lazy<Models.AvailabilitySetDatas.ListTests.LocalContext> _availabilitySetData_ListTests_LocalContext = new(() => new());

            private Dictionary_String_SubType_Info? _dictionary_String_SubType_Info;
            private List_List_SubType_Info? _list_List_SubType_Info;
            private List_SubType_Info? _list_SubType_Info;
            private List_Dictionary_String_SubType_Info? _list_Dictionary_String_SubType_Info;
            private SubType_Info? _subType_Info;
            private DoesNotImplementInterface_Info? _doesNotImplementInterface_Info;
            private NonJWire_Info? _nonJWire_Info;
            private PersistableModel_Info? _persistableModel_Info;
            private List_PersistableModel_Info? _list_PersistableModel_Info;
            private List_List_PersistableModel_Info? _list_List_PersistableModel_Info;
            private List_NonJWire_Info? _list_NonJWire_Info;
            private List_List_NonJWire_Info? _list_List_NonJWire_Info;
            private ReadReturnsNull_Info? _readReturnsNull_Info;
            private Dictionary_String_AvailabilitySetData_Info? _dictionary_String_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Dictionary<string, SubType>) => _dictionary_String_SubType_Info ??= new(),
                    Type t when t == typeof(List<List<SubType>>) => _list_List_SubType_Info ??= new(),
                    Type t when t == typeof(List<SubType>) => _list_SubType_Info ??= new(),
                    Type t when t == typeof(List<Dictionary<string, SubType>>) => _list_Dictionary_String_SubType_Info ??= new(),
                    Type t when t == typeof(SubType) => _subType_Info ??= new(),
                    Type t when t == typeof(DoesNotImplementInterface) => _doesNotImplementInterface_Info ??= new(),
                    Type t when t == typeof(NonJWire) => _nonJWire_Info ??= new(),
                    Type t when t == typeof(PersistableModel) => _persistableModel_Info ??= new(),
                    Type t when t == typeof(List<PersistableModel>) => _list_PersistableModel_Info ??= new(),
                    Type t when t == typeof(List<List<PersistableModel>>) => _list_List_PersistableModel_Info ??= new(),
                    Type t when t == typeof(List<NonJWire>) => _list_NonJWire_Info ??= new(),
                    Type t when t == typeof(List<List<NonJWire>>) => _list_List_NonJWire_Info ??= new(),
                    Type t when t == typeof(ReadReturnsNull) => _readReturnsNull_Info ??= new(),
                    Type t when t == typeof(Dictionary<string, AvailabilitySetData>) => _dictionary_String_AvailabilitySetData_Info ??= new(),
                    _ => _LibraryContext.Value.GetModelInfo(type) ?? _availabilitySetData_ListTests_LocalContext.Value.GetModelInfo(type),
                };
            }

            private class Dictionary_String_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Dictionary_String_AvailabilitySetData_Builder();

                private class Dictionary_String_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Dictionary<string, AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertKey(key), AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => _LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))!.CreateObject();
                }
            }

            private class ReadReturnsNull_Info : ModelInfo
            {
                public override object CreateObject() => new ReadReturnsNull();
            }

            private class List_List_NonJWire_Info : ModelInfo
            {
                public override object CreateObject() => new List_List_NonJWire_Builder();

                private class List_List_NonJWire_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<List<NonJWire>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<NonJWire>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => new NonJWire();
                }
            }

            private class List_NonJWire_Info : ModelInfo
            {
                public override object CreateObject() => new List_NonJWire_Builder();

                private class List_NonJWire_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<NonJWire>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<NonJWire>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => new NonJWire();
                }
            }

            private class List_List_PersistableModel_Info : ModelInfo
            {
                public override object CreateObject() => new List_List_PersistableModel_Builder();

                private class List_List_PersistableModel_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<List<PersistableModel>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<PersistableModel>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => new PersistableModel();
                }
            }

            private class List_PersistableModel_Info : ModelInfo
            {
                public override object CreateObject() => new List_PersistableModel_Builder();

                private class List_PersistableModel_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<PersistableModel>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<PersistableModel>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => new PersistableModel();
                }
            }

            private class PersistableModel_Info : ModelInfo
            {
                public override object CreateObject() => new PersistableModel();
            }

            private class NonJWire_Info : ModelInfo
            {
                public override object CreateObject() => new NonJWire();
            }

            private class DoesNotImplementInterface_Info : ModelInfo
            {
                public override object CreateObject() => new DoesNotImplementInterface();
            }

            private class SubType_Info : ModelInfo
            {
                public override object CreateObject() => new SubType();
            }

            private class List_Dictionary_String_SubType_Info : ModelInfo
            {
                public override object CreateObject() => new List_Dictionary_String_SubType_Builder();

                private class List_Dictionary_String_SubType_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<Dictionary<string, SubType>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<Dictionary<string, SubType>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => new SubType();
                }
            }

            private class List_SubType_Info : ModelInfo
            {
                public override object CreateObject() => new List_SubType_Builder();

                private class List_SubType_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<SubType>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<SubType>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => new SubType();
                }
            }

            private class List_List_SubType_Info : ModelInfo
            {
                public override object CreateObject() => new List_List_SubType_Builder();

                private class List_List_SubType_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<List<SubType>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<SubType>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => new SubType();
                }
            }

            private class Dictionary_String_SubType_Info : ModelInfo
            {
                public override object CreateObject() => new Dictionary_String_SubType_Builder();

                private class Dictionary_String_SubType_Builder : CollectionBuilder
                {
                    private readonly Lazy<Dictionary<string, SubType>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertKey(key), AssertItem<SubType>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => new SubType();
                }
            }
        }
    }
}
