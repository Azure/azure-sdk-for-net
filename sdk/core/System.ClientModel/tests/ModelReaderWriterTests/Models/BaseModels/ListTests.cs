// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.BaseModels
{
    public class ListTests : MrwCollectionTests<List<BaseModel>, BaseModel>
    {
        protected override ModelReaderWriterContext Context => new LocalContext();

        protected override List<BaseModel> GetModelInstance()
        {
            return [ModelInstances.s_modelX, ModelInstances.s_modelY, ModelInstances.s_modelZ];
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
            private List_BaseModel_Info? _list_BaseModel_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(List<BaseModel>) => _list_BaseModel_Info ??= new(),
                    _ => s_libraryContext.Value.GetModelInfo(type)
                };
            }

            private class List_BaseModel_Info : ModelInfo
            {
                public override object CreateObject() => new List_BaseModel_Builder();

                private class List_BaseModel_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<BaseModel>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<BaseModel>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object CreateElement() => s_libraryContext.Value.GetModelInfo(typeof(BaseModel))!.CreateObject();
                }
            }
        }
    }
}
