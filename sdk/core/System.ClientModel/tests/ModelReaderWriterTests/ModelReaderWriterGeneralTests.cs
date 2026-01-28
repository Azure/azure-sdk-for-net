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
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(BinaryData.Empty, null!, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(BinaryData.Empty, s_wireOptions, null!));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, typeof(BaseWithNoUnknown), null!, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, typeof(BaseWithNoUnknown), s_wireOptions, null!));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, null!, ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, typeof(BaseWithNoUnknown), null!, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write<PersistableModel>(new PersistableModel(), null!, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write((object)new PersistableModel(), null!, s_readerWriterContext));

            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read<BaseWithNoUnknown>(null!, s_wireOptions, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(null!, typeof(BaseWithNoUnknown), s_wireOptions, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Read(BinaryData.Empty, null!, s_wireOptions, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write<BaseWithNoUnknown>(null!, s_wireOptions, s_readerWriterContext));
            Assert.Throws<ArgumentNullException>(() => ModelReaderWriter.Write(null!, s_wireOptions, s_readerWriterContext));
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
                Assert.That(ex.GetType().IsSubclassOf(typeof(JsonException)), Is.True, $"Expected a subclass of {nameof(JsonException)} but got {ex.GetType().Name}");
                gotException = true;
            }

            Assert.That(gotException, Is.True, "Did not receive exception");

            gotException = false;
            try
            {
                object? x = ModelReaderWriter.Read(data, typeof(ModelX));
            }
            catch (Exception ex)
            {
                Assert.That(ex.GetType().IsSubclassOf(typeof(JsonException)), Is.True, $"Expected a subclass of {nameof(JsonException)} but got {ex.GetType().Name}");
                gotException = true;
            }

            Assert.That(gotException, Is.True, "Did not receive exception");
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
            Assert.That(ex?.Message.Contains("does not implement"), Is.True);
            ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(new DoesNotImplementInterface()));
            Assert.That(ex!.Message, Is.EqualTo("DoesNotImplementInterface must implement IEnumerable or IPersistableModel"));
        }

        [Test]
        public void EmptyEnumerableOfNoInterface()
        {
            List<DoesNotImplementInterface> list = [];
            BinaryData data = ModelReaderWriter.Write(list, ModelReaderWriterOptions.Json, s_readerWriterContext);
            Assert.That(data.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Write_EmptyEnumerableOfNonJson()
        {
            List<SubType> list = [];
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("X"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Format 'X' is not supported.  Only 'J' or 'W' format can be written as collections"));
        }

        [Test]
        public void Read_EmptyEnumerableOfNonJson()
        {
            var json = "[]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(List<SubType>), new ModelReaderWriterOptions("X"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Format 'X' is not supported.  Only 'J' or 'W' format can be read as collections"));
        }

        [Test]
        public void ReadDictionaryWhenList()
        {
            var data = BinaryData.FromString(File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataList.json")).TrimEnd());
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<Dictionary<string, AvailabilitySetData>>(data, ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Expected start of dictionary."));
        }

        [Test]
        public void ReadUnsupportedCollectionGeneric()
        {
            //make sure SortedDictionary is not in s_readerWriterContext
            var data = BinaryData.FromString(File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataList.json")).TrimEnd());
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<SortedDictionary<string, AvailabilitySetData>>(data, ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("No ModelReaderWriterTypeBuilder found for SortedDictionary<String, AvailabilitySetData>.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info."));
        }

        [Test]
        public void ReadListWhenDictionary()
        {
            var data = BinaryData.FromString(File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd());
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<AvailabilitySetData>>(data, ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Expected start of array."));
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
            BinaryData data = ModelReaderWriter.Write(collection, ModelReaderWriterOptions.Json, s_readerWriterContext);
            Assert.That(data, Is.Not.Null);
            Assert.That(data.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void WriteDictionaryOfInterface()
        {
            Dictionary<string, SubType> dict = new()
            {
                { "key", new SubType() },
            };
            BinaryData data = ModelReaderWriter.Write(dict, ModelReaderWriterOptions.Json, s_readerWriterContext);
            Assert.That(data, Is.Not.Null);
            Assert.That(data.ToString(), Is.EqualTo("{\"key\":{}}"));
        }

        [Test]
        public void NullOptionsWritesJson()
        {
            BinaryData data = ModelReaderWriter.Write(new SubType(), null);
            Assert.That(data, Is.Not.Null);
            Assert.That(data.ToString(), Is.EqualTo("{}"));
        }

        [Test]
        public void ReadListOfDictionariesAsListOfLists()
        {
            var json = "[{\"x\":{}},{\"y\":{}}]";
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<List<SubType>>>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Unexpected JsonTokenType.StartObject found."));
        }

        [Test]
        public void ReadListOfListsAsListOfDictionaries()
        {
            var json = "[[{}],[{}]]";
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<Dictionary<string, SubType>>>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Unexpected JsonTokenType.StartArray found."));
        }

        [Test]
        public void ReadUnexpectedToken()
        {
            var json = "[true,{}]";
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<SubType>>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Unexpected token True."));
        }

        [Test]
        public void ReadDictionaryWithNoPropertyNames()
        {
            bool foundException = false;
            var json = "{{},{}}";
            try
            {
                var result = ModelReaderWriter.Read<Dictionary<string, SubType>>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, s_readerWriterContext);
            }
            catch (Exception ex)
            {
                foundException = true;
                Assert.That(ex.GetType().Name, Is.EqualTo("JsonReaderException"), $"Expected JsonReaderException but got {ex.GetType().Name} with message: {ex.Message}");
                Assert.That(ex.Message.StartsWith("'{' is an invalid start of a property name."), Is.True);
            }
            Assert.That(foundException, Is.True, "Expected an exception but none was thrown");
        }

        [Test]
        public void WriteListNonJWire()
        {
            var list = new List<NonJWire>() { new NonJWire() };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("W"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("NonJWire has a wire format of 'X'.  It must be 'J' to be written as a collection"));
        }

        [Test]
        public void WriteListOfListNonJWire()
        {
            var list = new List<List<NonJWire>>() { new List<NonJWire>() { new NonJWire() } };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("W"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("NonJWire has a wire format of 'X'.  It must be 'J' to be written as a collection"));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void WriteListPersistableModel(string format)
        {
            var list = new List<PersistableModel>() { new PersistableModel() };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions(format), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            var expectedMessage = format == "J"
                ? "PersistableModel does not implement IJsonModel or IEnumerable<IJsonModel>"
                : "PersistableModel has a wire format of 'X'.  It must be 'J' to be written as a collection";
            Assert.That(ex!.Message, Is.EqualTo(expectedMessage));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void WriteListOfListPersistableModel(string format)
        {
            var list = new List<List<PersistableModel>>() { new List<PersistableModel>() { new PersistableModel() } };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions(format), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            var expectedMessage = format == "J"
                ? "PersistableModel does not implement IJsonModel or IEnumerable<IJsonModel>"
                : "PersistableModel has a wire format of 'X'.  It must be 'J' to be written as a collection";
            Assert.That(ex!.Message, Is.EqualTo(expectedMessage));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ReadListOfPersistableModel(string format)
        {
            var json = "[{},{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<PersistableModel>>(BinaryData.FromString(json), new ModelReaderWriterOptions(format), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            var expectedMessage = format == "J"
                ? "Item type 'PersistableModel' must implement IJsonModel"
                : "PersistableModel has a wire format of 'X' it must be 'J' to be read as a collection";
            Assert.That(ex!.Message, Is.EqualTo(expectedMessage));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ReadListOfListOfPersistableModel(string format)
        {
            var json = "[[{},{}]]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<List<PersistableModel>>>(BinaryData.FromString(json), new ModelReaderWriterOptions(format), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            var expectedMessage = format == "J"
                ? "Item type 'PersistableModel' must implement IJsonModel"
                : "PersistableModel has a wire format of 'X' it must be 'J' to be read as a collection";
            Assert.That(ex!.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void ReadListNonJWire()
        {
            var json = "[{},{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<NonJWire>>(BinaryData.FromString(json), new ModelReaderWriterOptions("W"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("NonJWire has a wire format of 'X' it must be 'J' to be read as a collection"));
        }

        [Test]
        public void ReadListOfListNonJWire()
        {
            var json = "[[{},{}]]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<List<NonJWire>>>(BinaryData.FromString(json), new ModelReaderWriterOptions("W"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("NonJWire has a wire format of 'X' it must be 'J' to be read as a collection"));
        }

        [Test]
        public void ReadNoActivator()
        {
            var json = "{}";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<NoActivator>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("No ModelReaderWriterTypeBuilder found for NoActivator.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info."));
        }

        [Test]
        public void ReadListOfNoActivator()
        {
            var json = "[{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<NoActivator>>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("No ModelReaderWriterTypeBuilder found for List<NoActivator>.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info."));
        }

        [Test]
        public void ReadListOfListOfNoActivator()
        {
            var json = "[[{}]]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<List<List<NoActivator>>>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("No ModelReaderWriterTypeBuilder found for List<List<NoActivator>>.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info."));
        }

        [Test]
        public void Read_NullReturn_Generic()
        {
            var json = "{}";
            var result = ModelReaderWriter.Read<ReadReturnsNull>(BinaryData.FromString(json));
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Read_NullReturn_NonGeneric()
        {
            var json = "{}";
            var result = ModelReaderWriter.Read(BinaryData.FromString(json), typeof(ReadReturnsNull));
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Read_NullReturn_Generic_WithContext()
        {
            var json = "{}";
            var result = ModelReaderWriter.Read<ReadReturnsNull>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, s_readerWriterContext);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Read_NullReturn_NonGeneric_WithContext()
        {
            var json = "{}";
            var result = ModelReaderWriter.Read(BinaryData.FromString(json), typeof(ReadReturnsNull), ModelReaderWriterOptions.Json, s_readerWriterContext);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ReadBadAbstractType()
        {
            var json = "{}";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(Stream)));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message.Contains("must be decorated with PersistableModelProxyAttribute"), Is.True);
        }

        [Test]
        public void ReadBadValueType()
        {
            var json = "{}";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(int)));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message.Contains("does not implement IPersistableModel"), Is.True);
        }

        [Test]
        public void ReadNoPublicCtorType()
        {
            var json = "{}";
#if NET5_0_OR_GREATER
            var ex = Assert.Throws<MissingMethodException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(FileStream)));
            Assert.That(ex, Is.Not.Null);
#else
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(FileStream)));
            Assert.That(ex, Is.Not.Null);
#endif
        }

        [Test]
        public void WriteListOfNonPersistable()
        {
            var list = new List<DoesNotImplementInterface>() { new DoesNotImplementInterface() };
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("W"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Unable to write List<DoesNotImplementInterface>.  Only collections of 'IPersistableModel' can be written."));
        }

        [Test]
        public void WriteEmptyDictionary()
        {
            var dict = new Dictionary<string, SubType>();
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(dict, new ModelReaderWriterOptions("W"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Can't use format 'W' format on an empty collection.  Please specify a concrete format"));
        }

        [Test]
        public void WriteEmptyList()
        {
            var list = new List<SubType>();
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("W"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("Can't use format 'W' format on an empty collection.  Please specify a concrete format"));
        }

        [Test]
        public void WriteMixedPersistableList()
        {
            List<object> list =
            [
                new ModelWithNoDefaultCtor(1),
                new SubType()
            ];
            Assert.DoesNotThrow(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("J"), s_readerWriterContext));
        }

        [Test]
        public void WriteMixedListWithNonJsonItem()
        {
            List<object> list =
            [
                new ModelWithNoDefaultCtor(1),
                new PersistableModel()
            ];
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("J"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("PersistableModel does not implement IJsonModel or IEnumerable<IJsonModel>"));
        }

        [Test]
        public void WriteMixedPersistableEnumerableList()
        {
            List<object> list =
            [
                new ModelWithNoDefaultCtor(1),
                new List<SubType>([new SubType(), new SubType()]),
            ];
            Assert.DoesNotThrow(() => ModelReaderWriter.Write(list, new ModelReaderWriterOptions("J"), s_readerWriterContext));
        }

        [Test]
        public void WriteMixedPersistableDictionary()
        {
            Dictionary<string, object> dict = new()
            {
                { "key1", new ModelWithNoDefaultCtor(1) },
                { "key2", new SubType() }
            };
            Assert.DoesNotThrow(() => ModelReaderWriter.Write(dict, new ModelReaderWriterOptions("J"), s_readerWriterContext));
        }

        [Test]
        public void WriteMixedPersistableEnumerableDictionary()
        {
            Dictionary<string, object> dict = new()
            {
                { "key1", new ModelWithNoDefaultCtor(1) },
                { "key2", new List<SubType>([new SubType(), new SubType()]) }
            };
            Assert.DoesNotThrow(() => ModelReaderWriter.Write(dict, new ModelReaderWriterOptions("J"), s_readerWriterContext));
        }

        [Test]
        public void ReadMixedPersistableList()
        {
            var json = "[{},{}]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(List<object>), new ModelReaderWriterOptions("J"), s_readerWriterContext));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message, Is.EqualTo("No ModelReaderWriterTypeBuilder found for List<Object>.  See 'https://aka.ms/no-modelreaderwritertypebuilder-found' for more info."));
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
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            BinaryData IPersistableModel<ModelWithNoDefaultCtor>.Write(ModelReaderWriterOptions options)
            {
                return BinaryData.Empty;
            }
        }

#nullable disable
        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> _libraryContext = new(() => new());
            private static readonly Lazy<Models.AvailabilitySetDatas.ListTests.LocalContext> _availabilitySetData_ListTests_LocalContext = new(() => new());

            private Dictionary_String_SubType_Builder _dictionary_String_SubType_Builder;
            private List_List_SubType_Builder _list_List_SubType_Builder;
            private List_SubType_Builder _list_SubType_Builder;
            private List_Dictionary_String_SubType_Builder _list_Dictionary_String_SubType_Builder;
            private SubType_Builder _subType_Builder;
            private DoesNotImplementInterface_Builder _doesNotImplementInterface_Builder;
            private NonJWire_Builder _nonJWire_Builder;
            private PersistableModel_Builder _persistableModel_Builder;
            private List_PersistableModel_Builder _list_PersistableModel_Builder;
            private List_List_PersistableModel_Builder _list_List_PersistableModel_Builder;
            private List_NonJWire_Builder _list_NonJWire_Builder;
            private List_List_NonJWire_Builder _list_List_NonJWire_Builder;
            private ReadReturnsNull_Builder _readReturnsNull_Builder;
            private Dictionary_String_AvailabilitySetData_Builder _dictionary_String_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(Dictionary<string, SubType>) => _dictionary_String_SubType_Builder ??= new(),
                    Type t when t == typeof(List<List<SubType>>) => _list_List_SubType_Builder ??= new(),
                    Type t when t == typeof(List<SubType>) => _list_SubType_Builder ??= new(),
                    Type t when t == typeof(List<Dictionary<string, SubType>>) => _list_Dictionary_String_SubType_Builder ??= new(),
                    Type t when t == typeof(SubType) => _subType_Builder ??= new(),
                    Type t when t == typeof(DoesNotImplementInterface) => _doesNotImplementInterface_Builder ??= new(),
                    Type t when t == typeof(NonJWire) => _nonJWire_Builder ??= new(),
                    Type t when t == typeof(PersistableModel) => _persistableModel_Builder ??= new(),
                    Type t when t == typeof(List<PersistableModel>) => _list_PersistableModel_Builder ??= new(),
                    Type t when t == typeof(List<List<PersistableModel>>) => _list_List_PersistableModel_Builder ??= new(),
                    Type t when t == typeof(List<NonJWire>) => _list_NonJWire_Builder ??= new(),
                    Type t when t == typeof(List<List<NonJWire>>) => _list_List_NonJWire_Builder ??= new(),
                    Type t when t == typeof(ReadReturnsNull) => _readReturnsNull_Builder ??= new(),
                    Type t when t == typeof(Dictionary<string, AvailabilitySetData>) => _dictionary_String_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                {
                    return builder;
                }
                if (_availabilitySetData_ListTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                {
                    return builder;
                }
                return null;
            }

            private class Dictionary_String_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(Dictionary<string, AvailabilitySetData>);

                protected override Type ItemType => typeof(AvailabilitySetData);

                protected override object CreateInstance() => new Dictionary<string, AvailabilitySetData>();

                protected override void AddItemWithKey(object collection, string key, object item)
                    => ((Dictionary<string, AvailabilitySetData>)collection).Add(key, (AvailabilitySetData)item);
            }

            private class ReadReturnsNull_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(ReadReturnsNull);

                protected override object CreateInstance() => new ReadReturnsNull();
            }

            private class List_List_NonJWire_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<List<NonJWire>>);

                protected override Type ItemType => typeof(List<NonJWire>);

                protected override object CreateInstance() => new List<List<NonJWire>>();

                protected override void AddItem(object collection, object item)
                    => ((List<List<NonJWire>>)collection).Add((List<NonJWire>)item);
            }

            private class List_NonJWire_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<NonJWire>);

                protected override Type ItemType => typeof(NonJWire);

                protected override object CreateInstance() => new List<NonJWire>();

                protected override void AddItem(object collection, object item)
                    => ((List<NonJWire>)collection).Add((NonJWire)item);
            }

            private class List_List_PersistableModel_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<List<PersistableModel>>);

                protected override Type ItemType => typeof(List<PersistableModel>);

                protected override object CreateInstance() => new List<List<PersistableModel>>();

                protected override void AddItem(object collection, object item)
                    => ((List<List<PersistableModel>>)collection).Add((List<PersistableModel>)item!);
            }

            private class List_PersistableModel_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<PersistableModel>);

                protected override Type ItemType => typeof(PersistableModel);

                protected override object CreateInstance() => new List<PersistableModel>();

                protected override void AddItem(object collection, object item)
                    => ((List<PersistableModel>)collection).Add((PersistableModel)item);
            }

            private class PersistableModel_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(PersistableModel);

                protected override object CreateInstance() => new PersistableModel();
            }

            private class NonJWire_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(NonJWire);

                protected override object CreateInstance() => new NonJWire();
            }

            private class DoesNotImplementInterface_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(DoesNotImplementInterface);

                protected override object CreateInstance() => new DoesNotImplementInterface();
            }

            private class SubType_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(SubType);

                protected override object CreateInstance() => new SubType();
            }

            private class List_Dictionary_String_SubType_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<Dictionary<string, SubType>>);

                protected override Type ItemType => typeof(Dictionary<string, SubType>);

                protected override object CreateInstance() => new List<Dictionary<string, SubType>>();

                protected override void AddItem(object collection, object item)
                    => ((List<Dictionary<string, SubType>>)collection).Add((Dictionary<string, SubType>)item);
            }

            private class List_SubType_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<SubType>);

                protected override Type ItemType => typeof(SubType);

                protected override object CreateInstance() => new List<SubType>();

                protected override void AddItem(object collection, object item)
                    => ((List<SubType>)collection).Add((SubType)item);
            }

            private class List_List_SubType_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<List<SubType>>);

                protected override Type ItemType => typeof(List<SubType>);

                protected override object CreateInstance() => new List<List<SubType>>();

                protected override void AddItem(object collection, object item)
                    => ((List<List<SubType>>)collection).Add((List<SubType>)item);
            }

            private class Dictionary_String_SubType_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(Dictionary<string, SubType>);

                protected override Type ItemType => typeof(SubType);

                protected override object CreateInstance() => new Dictionary<string, SubType>();

                protected override void AddItemWithKey(object collection, string key, object item)
                    => ((Dictionary<string, SubType>)collection).Add(key, (SubType)item);
            }
        }
#nullable enable
    }
}
