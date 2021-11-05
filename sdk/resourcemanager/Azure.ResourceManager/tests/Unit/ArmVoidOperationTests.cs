// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ArmVoidOperationTests
    {
        [TestCase]
        public void TestArmVoidOperationParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new ResourceTypeFilter(null); });
        }
    }
}
