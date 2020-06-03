// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DynamicJsonMutableTests
    {
        [Test]
        public void ArrayItemsCanBeAssigned()
        {
            dynamic dynamicJson = DynamicJson.Parse("[0, 1, 2, 3]");
            dynamicJson[1] = 2;
            dynamicJson[2] = null;
            dynamicJson[3] = "string";
        }
    }
}