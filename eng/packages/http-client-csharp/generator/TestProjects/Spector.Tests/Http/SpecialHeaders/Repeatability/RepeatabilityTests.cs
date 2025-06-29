// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using SpecialHeaders.Repeatability;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace TestProjects.Spector.Tests.Http.SpecialHeaders.Repeatability
{
    public class RepeatabilityTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ImmediateSuccess() => Test(async (host) =>
        {
            var response = await new RepeatabilityClient(host, null).ImmediateSuccessAsync();

            Assert.AreEqual(204, response.Status);
            Assert.IsTrue(response.Headers.TryGetValue("repeatability-result", out var headerValue));
            Assert.AreEqual("accepted", headerValue);
        });

        [Test]
        public void RepeatabilityHeadersNotInMethodSignature()
        {
            var methods = typeof(RepeatabilityClient).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.Name.StartsWith("ImmediateSuccess"));

            Assert.IsNotEmpty(methods);
            foreach (var m in methods)
            {
                Assert.False(m.GetParameters().Any(p => p.Name == "repeatabilityRequestId" || p.Name == "repeatabilityFirstSent"));
            }
        }
    }
}
