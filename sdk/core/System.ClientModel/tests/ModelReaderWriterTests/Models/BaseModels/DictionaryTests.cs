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

        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private Dictionary_BaseModel_Builder? _Dictionary_BaseModel_Builder;

            public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? modelInfo)
            {
                modelInfo = type switch
                {
                    Type t when t == typeof(Dictionary<string, BaseModel>) => _Dictionary_BaseModel_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return modelInfo is not null;
            }

            private ModelBuilder? GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetModelBuilder(type, out ModelBuilder? modelInfo))
                    return modelInfo;
                return null;
            }

            private class Dictionary_BaseModel_Builder : ModelBuilder
            {
                private Func<object>? _createInstance;
                protected override Func<object> CreateInstance => _createInstance ??= () => new Dictionary<string, BaseModel>();

                private Action<object, object, string?>? _addItem;
                protected override Action<object, object, string?>? AddItem
                    => _addItem ??= (collection, item, key) => AssertCollection<Dictionary<string, BaseModel>>(collection).Add(AssertKey(key), AssertItem<BaseModel>(item));

                private Func<object>? _createElementInstance;
                protected override Func<object> CreateElementInstance
                    => _createElementInstance ??= () => s_libraryContext.Value.GetModelBuilder(typeof(BaseModel)).CreateObject();
            }
        }
    }
}
