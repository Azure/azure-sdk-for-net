// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class BadContextTests
    {
        private static readonly BadContext s_badContext = new BadContext();

        [Test]
        public void Write_NonPersistableAndNonEnumerable()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(new DoesNotImplementInterface(), s_badContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("DoesNotImplementInterface must implement IEnumerable or IPersistableModel", ex!.Message);
        }

        [Test]
        public void Read_NonPersistableAndNonEnumerable()
        {
            var json = "{}";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(DoesNotImplementInterface), s_badContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("DoesNotImplementInterface must implement CollectionBuilder or IPersistableModel", ex!.Message);
        }

        [Test]
        public void Read_NonPersistableElement()
        {
            var json = "[]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(List<PersistableModel_NonPersistableElement>), s_badContext, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("'DoesNotImplementInterface' must implement IPersistableModel", ex!.Message);
        }

        [Test]
        public void Read_NullElement()
        {
            var json = "[]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(List<PersistableModel_NullElement>), s_badContext, new ModelReaderWriterOptions("W")));
            Assert.IsNotNull(ex);
            Assert.AreEqual("'' must implement IPersistableModel", ex!.Message);
        }

        private class BadContext : ModelReaderWriterContext
        {
            private DoesNotImplementInterface_Info? _doesNotImplementInterface_Info;
            private List_PersistableModel_NonPersistableElement_Info? _list_PersistableModel_NonPersistableElement_Info;
            private PersistableModel_NonPersistableElement_Info? _persistableModel_NonPersistableElement_Info;
            private List_PersistableModel_NullElement_Info? _list_PersistableModel_NullElement_Info;
            private PersistableModel_NullElement_Info? _persistableModel_NullElement_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(DoesNotImplementInterface) => _doesNotImplementInterface_Info ??= new(),
                    Type t when t == typeof(List<PersistableModel_NonPersistableElement>) => _list_PersistableModel_NonPersistableElement_Info ??= new(),
                    Type t when t == typeof(PersistableModel_NonPersistableElement) => _persistableModel_NonPersistableElement_Info ??= new(),
                    Type t when t == typeof(List<PersistableModel_NullElement>) => _list_PersistableModel_NullElement_Info ??= new(),
                    Type t when t == typeof(PersistableModel_NullElement) => _persistableModel_NullElement_Info ??= new(),
                    _ => null
                };
            }

            private class PersistableModel_NullElement_Info : ModelInfo
            {
                public override object CreateObject() => new PersistableModel_NullElement();
            }

            private class List_PersistableModel_NullElement_Info : ModelInfo
            {
                public override object CreateObject() => new List_PersistableModel_NullElement_Builder();

                private class List_PersistableModel_NullElement_Builder : CollectionBuilder
                {
                    protected internal override void AddItem(object item, string? key = null)
                    {
                        throw new NotImplementedException();
                    }

                    protected internal override object GetBuilder() => new List<PersistableModel_NullElement>();

                    protected internal override object? CreateElement() => null;
                }
            }

            private class PersistableModel_NonPersistableElement_Info : ModelInfo
            {
                public override object CreateObject() => new PersistableModel_NonPersistableElement();
            }

            private class List_PersistableModel_NonPersistableElement_Info : ModelInfo
            {
                public override object CreateObject() => new List_PersistableModel_NonPersistableElement_Builder();

                private class List_PersistableModel_NonPersistableElement_Builder : CollectionBuilder
                {
                    protected internal override void AddItem(object item, string? key = null)
                    {
                        throw new NotImplementedException();
                    }

                    protected internal override object GetBuilder() => new List<PersistableModel_NonPersistableElement>();

                    protected internal override object? CreateElement() => new DoesNotImplementInterface();
                }
            }

            private class DoesNotImplementInterface_Info : ModelInfo
            {
                public override object CreateObject() => new DoesNotImplementInterface();

                public override IEnumerable? GetEnumerable(object obj) => null;
            }
        }

        private class DoesNotImplementInterface();

        private class PersistableModel_NonPersistableElement : IJsonModel<PersistableModel_NonPersistableElement>
        {
            public PersistableModel_NonPersistableElement Create(BinaryData data, ModelReaderWriterOptions options) => new();

            public PersistableModel_NonPersistableElement Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new();

            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;

            public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
            }
        }

        private class PersistableModel_NullElement : IJsonModel<PersistableModel_NullElement>
        {
            public PersistableModel_NullElement Create(BinaryData data, ModelReaderWriterOptions options) => new();

            public PersistableModel_NullElement Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new();

            public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

            public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;

            public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
            }
        }
    }
}
