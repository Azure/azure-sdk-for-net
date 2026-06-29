// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.ResourceManager.TestFramework
{
    public partial class InheritanceCheckTests
    {
        public InheritanceCheckTests()
        {
            SetExceptionList();
        }

        [SetUp]
        public void SetExceptionList()
        {
            ExceptionList = new string[]
            {
                "Azure.ResourceManager.SecurityCenter.Models.SecurityTopologyResource",
                "Azure.ResourceManager.SecurityCenter.Models.TopologySingleResource"
            };
        }
    }
}
