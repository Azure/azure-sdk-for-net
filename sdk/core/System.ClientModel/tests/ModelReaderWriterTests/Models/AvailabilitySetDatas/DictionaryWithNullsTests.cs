// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class DictionaryWithNullsTests : DictionaryTests
    {
        protected override Dictionary<string, AvailabilitySetData> GetModelInstance()
            => new Dictionary<string, AvailabilitySetData>()
            {
                { ModelInstances.s_testAs_3375.Name!, ModelInstances.s_testAs_3375 },
                { "nullEntry", null! },
                { ModelInstances.s_testAs_3376.Name!, ModelInstances.s_testAs_3376 }
            };
    }
}
