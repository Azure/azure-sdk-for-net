// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.ResourceManager.Security.Tests
{
    public class SecurityManagementTests
    {
        [Test]
        public void CanLoadSecurityAssembly()
        {
            Assert.That(typeof(SecurityExtensions).Assembly.GetName().Name, Is.EqualTo("Azure.ResourceManager.Security"));
        }
    }
}
