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

            Assert.Multiple(() =>
            {
                Assert.That(response.Status, Is.EqualTo(204));
                Assert.That(response.Headers.TryGetValue("repeatability-result", out var headerValue), Is.True);
                Assert.That(headerValue, Is.EqualTo("accepted"));
            });
        });

        [Test]
        public void RepeatabilityHeadersNotInMethodSignature()
        {
            var methods = typeof(RepeatabilityClient).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.Name.StartsWith("ImmediateSuccess"));

            Assert.That(methods, Is.Not.Empty);
            foreach (var m in methods)
            {
                Assert.That(m.GetParameters().Any(p => p.Name == "repeatabilityRequestId" || p.Name == "repeatabilityFirstSent"), Is.False);
            }
        }
    }
}
