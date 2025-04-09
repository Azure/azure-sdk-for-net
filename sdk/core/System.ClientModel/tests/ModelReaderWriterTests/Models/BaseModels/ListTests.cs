// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
#if SOURCE_GENERATOR
using System.ClientModel.SourceGeneration.Tests;
#else
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
#endif
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.BaseModels
{
    public partial class ListTests : MrwCollectionTests<List<BaseModel>, BaseModel>
    {
#if SOURCE_GENERATOR
        protected override ModelReaderWriterContext Context => BasicContext.Default;
#else
        protected override ModelReaderWriterContext Context => new LocalContext();
#endif

        protected override string CollectionTypeName => "List<BaseModel>";

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
    }
}
