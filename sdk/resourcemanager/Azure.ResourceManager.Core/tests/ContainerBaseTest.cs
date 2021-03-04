// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ContainerBaseTest
    {
        [TestCase]
        public void TryGetTest(bool expected, string resourceName) 
        {
            //ArmResponse<TOperations> output;
            //Assert.AreEqual(expected, TryGet(resourceName, out output));
            Assert.Ignore();
        }

        [TestCase]
        public void TryGetAsyncTest(bool expected, string resourceName)
        {
            //ArmResponse<TOperations> output = null;
            //Assert.AreEqual(output, await TryGetAsync(resourceName, output));
            Assert.Ignore();
        }
    }
}
