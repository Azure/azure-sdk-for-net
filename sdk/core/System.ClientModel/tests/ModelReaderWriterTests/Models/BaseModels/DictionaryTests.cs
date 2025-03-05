// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.Collections.Generic;
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
            private Dictionary_BaseModel_Info? _Dictionary_BaseModel_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Dictionary<string, BaseModel>) => _Dictionary_BaseModel_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type)
                };
            }

            private class Dictionary_BaseModel_Info : ModelInfo
            {
                public override object CreateObject() => new Dictionary_BaseModel_Builder();

                private class Dictionary_BaseModel_Builder : CollectionBuilder
                {
                    private readonly Lazy<Dictionary<string, BaseModel>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertKey(key), AssertItem<BaseModel>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(BaseModel))!.CreateObject();
                }
            }
        }
    }
}
