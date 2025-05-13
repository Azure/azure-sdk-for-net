// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;

#if SOURCE_GENERATOR
using System.ClientModel.SourceGeneration.Tests;
#endif
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public partial class ProxiedListOfListTests : MrwCollectionTests<List<List<AvailabilitySetData>>, AvailabilitySetData>
    {
        protected override string CollectionTypeName => "List<List<AvailabilitySetData>>";

        protected override IPersistableModel<AvailabilitySetData>? Proxy => new AvailabilitySetDataProxy();

#if SOURCE_GENERATOR
        protected override ModelReaderWriterContext Context => BasicContext.Default;
#else
        protected override ModelReaderWriterContext Context => new LocalContext();
#endif

        protected override List<List<AvailabilitySetData>> GetModelInstance()
        {
            return [[ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376], [ModelInstances.s_testAs_3377, ModelInstances.s_testAs_3378]];
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
        {
            AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format, nameAlwaysExists: true);
            var sard = GetSard(model);
            var sard2 = GetSard(model2);
            Assert.IsNull(sard); //the original won't have it since its added in by the proxy
            Assert.IsNotNull(sard2); //new one should have it
            Assert.AreEqual(1, sard2.Count);
            Assert.AreEqual($"\"{model2.Name}_extra\"", sard2["extra"].ToString());
        }

        private IDictionary<string, BinaryData> GetSard(AvailabilitySetData model)
        {
            var result = model.GetType().GetField("_serializedAdditionalRawData", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(model) as IDictionary<string, BinaryData>;
            return result!;
        }
    }
}
