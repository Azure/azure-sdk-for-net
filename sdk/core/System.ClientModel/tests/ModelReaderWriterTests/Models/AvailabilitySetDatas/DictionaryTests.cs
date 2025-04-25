// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
#if SOURCE_GENERATOR
using System.ClientModel.SourceGeneration.Tests;
#endif
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public partial class DictionaryTests : MrwCollectionTests<Dictionary<string, AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string CollectionTypeName => "Dictionary<String, AvailabilitySetData>";

#if SOURCE_GENERATOR
        protected override ModelReaderWriterContext Context => BasicContext.Default;
#else
        protected override ModelReaderWriterContext Context => new LocalContext();
#endif

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);

        protected override Dictionary<string, AvailabilitySetData> GetModelInstance()
            => new Dictionary<string, AvailabilitySetData>()
            {
                { ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375 },
                { ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376 }
            };
    }
}
