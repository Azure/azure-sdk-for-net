// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core.Resources;
using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class ResourceTypeFilterTests
    {
        [TestCase]
        public void TestResourceTypeFilterParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new ArmVoidOperation((Operation<Response>)null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmVoidOperation((Response)null); });
        }
    }
}
