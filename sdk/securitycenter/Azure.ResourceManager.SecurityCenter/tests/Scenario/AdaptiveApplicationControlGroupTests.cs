// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class AdaptiveApplicationControlGroupTests : SecurityCenterManagementTestBase
    {
        public AdaptiveApplicationControlGroupTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("The SDK doesn't support create a AdaptiveApplicationControlGroupResource")]
        public void Update()
        {
        }
    }
}
