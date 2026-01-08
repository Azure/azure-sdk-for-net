// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public class ListWithNullsTests : ListTests
    {
        protected override List<AvailabilitySetData> GetModelInstance()
        {
            return [ModelInstances.s_testAs_3375, null!, ModelInstances.s_testAs_3376];
        }
    }
}
