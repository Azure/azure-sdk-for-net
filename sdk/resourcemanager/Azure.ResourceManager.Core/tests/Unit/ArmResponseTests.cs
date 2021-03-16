// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class ArmResponseTests
    {
        [TestCase]
        public void TestArmResponseParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new ArmResponse(null); });

        }
    }
}
