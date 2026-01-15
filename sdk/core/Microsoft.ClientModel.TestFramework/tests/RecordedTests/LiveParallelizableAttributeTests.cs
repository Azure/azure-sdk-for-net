// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class LiveParallelizableAttributeTests
{
    [Test]
    public void LiveMode_PreservesRequestedParallelScope()
    {
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Live"))
        {
            var attribute = new LiveParallelizableAttribute(ParallelScope.Children);

            // In Live mode, the requested scope should be preserved
            Assert.That(attribute.Properties.Get(PropertyNames.ParallelScope), Is.EqualTo(ParallelScope.Children));
        }
    }

    [Test]
    public void RecordMode_ForcesParallelScopeToNone()
    {
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Record"))
        {
            var attribute = new LiveParallelizableAttribute(ParallelScope.Children);

            // In Record mode, scope should be forced to None regardless of requested scope
            Assert.That(attribute.Properties.Get(PropertyNames.ParallelScope), Is.EqualTo(ParallelScope.None));
        }
    }

    [Test]
    public void PlaybackMode_ForcesParallelScopeToNone()
    {
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Playback"))
        {
            var attribute = new LiveParallelizableAttribute(ParallelScope.Self);

            // In Playback mode, scope should be forced to None regardless of requested scope
            Assert.That(attribute.Properties.Get(PropertyNames.ParallelScope), Is.EqualTo(ParallelScope.None));
        }
    }

    [Test]
    public void LiveMode_WithDifferentScopes_PreservesEachScope()
    {
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Live"))
        {
            var selfAttr = new LiveParallelizableAttribute(ParallelScope.Self);
            var childrenAttr = new LiveParallelizableAttribute(ParallelScope.Children);
            var fixturesAttr = new LiveParallelizableAttribute(ParallelScope.Fixtures);
            var allAttr = new LiveParallelizableAttribute(ParallelScope.All);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(selfAttr.Properties.Get(PropertyNames.ParallelScope), Is.EqualTo(ParallelScope.Self));
                Assert.That(childrenAttr.Properties.Get(PropertyNames.ParallelScope), Is.EqualTo(ParallelScope.Children));
                Assert.That(fixturesAttr.Properties.Get(PropertyNames.ParallelScope), Is.EqualTo(ParallelScope.Fixtures));
                Assert.That(allAttr.Properties.Get(PropertyNames.ParallelScope), Is.EqualTo(ParallelScope.All));
            }
        }
    }

    [Test]
    public void NonLiveModes_AlwaysForceToNoneRegardlessOfRequestedScope()
    {
        var testCases = new[]
        {
            ("Record", ParallelScope.Self),
            ("Record", ParallelScope.Children),
            ("Record", ParallelScope.Fixtures),
            ("Record", ParallelScope.All),
            ("Playback", ParallelScope.Self),
            ("Playback", ParallelScope.Children),
            ("Playback", ParallelScope.Fixtures),
            ("Playback", ParallelScope.All)
        };

        foreach (var (mode, requestedScope) in testCases)
        {
            using (new TestEnvVar("CLIENTMODEL_TEST_MODE", mode))
            {
                var attribute = new LiveParallelizableAttribute(requestedScope);

                Assert.That(attribute.Properties.Get(PropertyNames.ParallelScope), Is.EqualTo(ParallelScope.None),
                    $"Mode: {mode}, RequestedScope: {requestedScope} should result in ParallelScope.None");
            }
        }
    }

    [Test]
    public void DefaultMode_ForcesParallelScopeToNone()
    {
        // When no environment variable is set, TestEnvironment.GlobalTestMode defaults to Playback
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", null))
        {
            var attribute = new LiveParallelizableAttribute(ParallelScope.All);

            // Default mode (Playback) should force scope to None
            Assert.That(attribute.Properties.Get(PropertyNames.ParallelScope), Is.EqualTo(ParallelScope.None));
        }
    }

    // Helper classes for testing attribute application
    public class TestClassWithLiveParallelizable
    {
        [LiveParallelizable(ParallelScope.Self)]
        public void ParallelizableMethod()
        {
            // Test method with LiveParallelizable attribute
        }
    }

    [LiveParallelizable(ParallelScope.Children)]
    public class LiveParallelizableTestClass
    {
        public void TestMethod()
        {
            // Method in class with LiveParallelizable attribute
        }
    }
}
