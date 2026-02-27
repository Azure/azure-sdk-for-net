// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.ResourceManager.TestFramework
{
    public partial class InheritanceCheckTests
    {
        [OneTimeSetUp]
        public void SetExceptionList()
        {
            // MoboBrokerResource is a model class that happens to end with "Resource"
            // but is not an ARM resource, so it should be excluded from inheritance checks.
            ExceptionList = new string[] { "MoboBrokerResource" };
        }
    }
}
