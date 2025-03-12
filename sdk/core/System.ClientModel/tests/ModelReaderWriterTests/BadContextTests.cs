// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(new DoesNotImplementInterface(), ModelReaderWriterOptions.Json, s_badContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("DoesNotImplementInterface must implement IEnumerable or IPersistableModel", ex!.Message);
        }

        [Test]
        public void Read_NonPersistableAndNonEnumerable()
        {
            var json = "{}";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(DoesNotImplementInterface), ModelReaderWriterOptions.Json, s_badContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("DoesNotImplementInterface must implement IPersistableModel", ex!.Message);
        }

        [Test]
        public void Read_NonPersistableElement()
        {
            var json = "[]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(List<PersistableModel_NonPersistableElement>), new ModelReaderWriterOptions("W"), s_badContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("'DoesNotImplementInterface' must implement IPersistableModel", ex!.Message);
        }

        [Test]
        public void Read_NullElement()
        {
            var json = "[]";
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(json), typeof(List<PersistableModel_NullElement>), new ModelReaderWriterOptions("W"), s_badContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("'' must implement IPersistableModel", ex!.Message);
        }

        private class BadContext : ModelReaderWriterContext
        {
            private DoesNotImplementInterface_Builder? _doesNotImplementInterface_Builder;
            private List_PersistableModel_NonPersistableElement_Builder? _list_PersistableModel_NonPersistableElement_Builder;
            private PersistableModel_NonPersistableElement_Builder? _persistableModel_NonPersistableElement_Builder;
            private List_PersistableModel_NullElement_Builder? _list_PersistableModel_NullElement_Builder;
            private PersistableModel_NullElement_Builder? _persistableModel_NullElement_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(DoesNotImplementInterface) => _doesNotImplementInterface_Builder ??= new(),
                    Type t when t == typeof(List<PersistableModel_NonPersistableElement>) => _list_PersistableModel_NonPersistableElement_Builder ??= new(),
                    Type t when t == typeof(PersistableModel_NonPersistableElement) => _persistableModel_NonPersistableElement_Builder ??= new(),
                    Type t when t == typeof(List<PersistableModel_NullElement>) => _list_PersistableModel_NullElement_Builder ??= new(),
                    Type t when t == typeof(PersistableModel_NullElement) => _persistableModel_NullElement_Builder ??= new(),
                    _ => null
                };
                return builder is not null;
            }

            private class PersistableModel_NullElement_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new PersistableModel_NullElement();
            }

            private class List_PersistableModel_NullElement_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new List<PersistableModel_NullElement>();

                protected override Action<object, object, string?>? AddItem => (_, _, _) => throw new NotImplementedException();

                protected override Func<object>? CreateElementInstance => () => null!;
            }

            private class PersistableModel_NonPersistableElement_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new PersistableModel_NonPersistableElement();
            }

            private class List_PersistableModel_NonPersistableElement_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new List<PersistableModel_NonPersistableElement>();

                protected override Action<object, object, string?>? AddItem => (_, _, _) => throw new NotImplementedException();

                private Func<object>? _createElementInstance;
                protected override Func<object>? CreateElementInstance => _createElementInstance ??= () => new DoesNotImplementInterface();
            }

            private class DoesNotImplementInterface_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new DoesNotImplementInterface();
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
