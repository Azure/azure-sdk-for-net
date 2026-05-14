// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    public class SecurityManagementTests
    {
        [Test]
        public void CanLoadSecurityAssembly()
        {
            Assert.That(typeof(SecurityCenterExtensions).Assembly.GetName().Name, Is.EqualTo("Azure.ResourceManager.SecurityCenter"));
        }
    }
}
