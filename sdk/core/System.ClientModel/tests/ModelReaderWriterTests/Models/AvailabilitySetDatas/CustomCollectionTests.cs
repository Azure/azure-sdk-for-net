// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
#if SOURCE_GENERATOR
using System.ClientModel.SourceGeneration.Tests;
#endif
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using static System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas.CustomCollectionTests;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public partial class CustomCollectionTests : MrwCollectionTests<CustomCollection<AvailabilitySetData>, AvailabilitySetData>
    {
        protected override string GetJsonCollectionType() => "List";

        protected override bool HasReflectionBuilderSupport => false;

        protected override string CollectionTypeName => "CustomCollection<AvailabilitySetData>";

        public class CustomCollection<T> : List<T> { }

#if SOURCE_GENERATOR
        protected override ModelReaderWriterContext Context => BasicContext.Default;
#else
        protected override ModelReaderWriterContext Context => new LocalContext();
#endif

        protected override CustomCollection<AvailabilitySetData> GetModelInstance()
        {
            return [ModelInstances.s_testAs_3375, ModelInstances.s_testAs_3376];
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => AvailabilitySetDataTests.CompareAvailabilitySetData(model, model2, format);
    }
}
