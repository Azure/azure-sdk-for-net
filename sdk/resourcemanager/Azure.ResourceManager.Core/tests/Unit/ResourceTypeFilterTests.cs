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
        [Ignore("Removed since PhVoidArmOperation no loger exists")]
        [TestCase]
        public void TestResourceTypeFilterParamCheck()
        {
            //Assert.Throws<ArgumentNullException>(() => { new PhVoidArmOperation((Operation<Response>)null); });
            //Assert.Throws<ArgumentNullException>(() => { new PhVoidArmOperation((Response)null); });
        }
    }
}
