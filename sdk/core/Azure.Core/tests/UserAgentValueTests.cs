// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class UserAgentValueTests
    {
        private const string appId = "MyApplicationId";

        [Test]
        public void CtorInitializesValue([Values(null, appId)] string applicationId)
        {
            var target = new UserAgentValue(typeof(UserAgentValueTests), applicationId);

            var assembly = Assembly.GetAssembly(GetType());
            AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            string version = versionAttribute.InformationalVersion;
            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }
            if (applicationId == null)
            {
                Assert.AreEqual(
                    target.ToString(),
                    $"azsdk-net-Core.Tests/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})");
            }
            else
            {
                Assert.AreEqual(
                    target.ToString(),
                    $"{applicationId} azsdk-net-Core.Tests/{version} ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})");
            }
        }

        [Test]
        public void CtorPopulatesProperties([Values(null, appId)] string applicationId)
        {
            var target = new UserAgentValue(typeof(UserAgentValueTests), applicationId);

            Assert.AreEqual(typeof(UserAgentValueTests), target.PackageType);
            Assert.AreEqual(applicationId, target.ApplicationId);
        }
    }
}
