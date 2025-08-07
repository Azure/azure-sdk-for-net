// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.BaseModels
{
    public class DictionaryTests : MrwCollectionTests<Dictionary<string, BaseModel>, BaseModel>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override string CollectionTypeName => "Dictionary<String, BaseModel>";

        protected override Dictionary<string, BaseModel> GetModelInstance()
        {
            return new()
            {
                { ModelInstances.s_modelX.Name!, ModelInstances.s_modelX },
                { ModelInstances.s_modelY.Name!, ModelInstances.s_modelY },
                { ModelInstances.s_modelZ.Name!, ModelInstances.s_modelZ }
            };
        }

        protected override void CompareModels(BaseModel model, BaseModel model2, string format)
        {
            Assert.AreEqual(model.GetType(), model2.GetType());
            if (model is ModelX modelX)
            {
                ModelInstances.CompareModelX(modelX, (ModelX)model2, format);
            }
            else if (model is ModelY modelY)
            {
                ModelInstances.CompareModelY(modelY, (ModelY)model2, format);
            }
            else
            {
                ModelInstances.CompareModelZ(model, model2, format);
            }
        }

#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private Dictionary_BaseModel_Builder _Dictionary_BaseModel_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(Dictionary<string, BaseModel>) => _Dictionary_BaseModel_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                return null;
            }

            private class Dictionary_BaseModel_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(Dictionary<string, BaseModel>);

                protected override Type ItemType => typeof(BaseModel);

                protected override object CreateInstance() => new Dictionary<string, BaseModel>();

                protected override void AddItemWithKey(object collection, string key, object item)
                    => ((Dictionary<string, BaseModel>)collection).Add(key, (BaseModel)item);
            }
        }
#nullable enable
    }
}
