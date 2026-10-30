// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Tests;

public class VersioningTests
{
    [TestCase("PreviewRetainedResource")]
    [TestCase("PreviewRetainedResourceProperties")]
    [TestCase("LatestStableResource")]
    [TestCase("LatestStableResourceProperties")]
    [TestCase("VersionedResource")]
    [TestCase("VersionedResourceProperties")]
    [TestCase("InitialStableEnum")]
    [TestCase("PreviewRetainedEnum")]
    [TestCase("LatestStableEnum")]
    public void StableProjectionTypesAreNotExperimental(string typeName)
    {
        var type = typeof(VersionedResource).Assembly.GetType(
            $"Azure.Provisioning.ProvisioningTypeSpec.{typeName}");

        Assert.That(type, Is.Not.Null);
        AssertNotExperimental(type!);
    }

    [TestCase("InitialStableProperty")]
    [TestCase("PreviewRetainedProperty")]
    [TestCase("LatestStableProperty")]
    [TestCase("InitialStableEnum")]
    [TestCase("PreviewRetainedEnum")]
    [TestCase("LatestStableEnum")]
    public void StableProjectionPropertiesAreNotExperimental(string propertyName)
    {
        var property = typeof(VersionedResource).GetProperty(propertyName);

        Assert.That(property, Is.Not.Null);
        AssertNotExperimental(property!);
    }

    [Test]
    public void StableResourceVersionsAreNotExperimental()
    {
        var fields = typeof(VersionedResource.ResourceVersions).GetFields();

        Assert.That(fields, Is.Not.Empty);
        foreach (var field in fields)
        {
            AssertNotExperimental(field);
        }
    }

    [Test]
    public void StableProjectionContainsExpectedApis()
    {
        var assembly = typeof(VersionedResource).Assembly;
        var propertyNames = typeof(VersionedResource)
            .GetProperties()
            .Select(property => property.Name);

        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.PreviewOnlyResource"), Is.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.PreviewRetainedResource"), Is.Not.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.LatestStableResource"), Is.Not.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.PreviewOnlyEnum"), Is.Null);
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResource.InitialStableProperty)));
        Assert.That(propertyNames, Does.Not.Contain("PreviewOnlyProperty"));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResource.PreviewRetainedProperty)));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResource.LatestStableProperty)));
    }

    [TestCase("FlattenedPreviewValue")]
    [TestCase("SharedValue")]
    [TestCase("NestedPreviewValue")]
    [TestCase("PreviewSafeWrapperSharedValue")]
    [TestCase("StableSharedValue")]
    public void RetainedFlattenedPathsAreNotExperimental(string propertyName)
    {
        var property = typeof(VersionedResource).GetProperty(propertyName);

        Assert.That(property, Is.Not.Null);
        AssertNotExperimental(property!);
    }

    private static void AssertNotExperimental(MemberInfo member)
        => Assert.That(member.CustomAttributes.Any(attribute =>
            attribute.AttributeType.FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute"), Is.False);
}
