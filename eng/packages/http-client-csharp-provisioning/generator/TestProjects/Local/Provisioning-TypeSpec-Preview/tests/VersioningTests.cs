// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Preview.Tests;

public class VersioningTests
{
    [Test]
    public void PreviewProjectionContainsExpectedApis()
    {
        var assembly = typeof(VersionedResource).Assembly;
        var propertyNames = typeof(VersionedResourceProperties)
            .GetProperties()
            .Select(property => property.Name);

        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.Preview.PreviewOnlyResource"), Is.Not.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.Preview.PreviewRetainedResource"), Is.Not.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.Preview.LatestStableResource"), Is.Null);
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResourceProperties.InitialStableProperty)));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResourceProperties.PreviewOnlyProperty)));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResourceProperties.PreviewRetainedProperty)));
        Assert.That(propertyNames, Does.Not.Contain("LatestStableProperty"));
    }
}
