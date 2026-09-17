// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Tests;

public class VersioningTests
{
    [Test]
    public void StableProjectionContainsExpectedApis()
    {
        var assembly = typeof(VersionedResource).Assembly;
        var propertyNames = typeof(VersionedResourceProperties)
            .GetProperties()
            .Select(property => property.Name);

        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.PreviewOnlyResource"), Is.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.PreviewRetainedResource"), Is.Not.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.LatestStableResource"), Is.Not.Null);
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResourceProperties.InitialStableProperty)));
        Assert.That(propertyNames, Does.Not.Contain("PreviewOnlyProperty"));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResourceProperties.PreviewRetainedProperty)));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResourceProperties.LatestStableProperty)));
    }
}
