﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core.Resources;
using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Core.Tests
{
    public class ArmVoidOperationTests
    {
        [TestCase]
        public void TestArmVoidOperationParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new ResourceTypeFilter(null); });
        }
    }
}
