// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Preview.Tests;

public class VersioningTests
{
    [TestCase("PreviewOnlyResource", true)]
    [TestCase("PreviewOnlyResourceProperties", true)]
    [TestCase("PreviewRetainedResource", true)]
    [TestCase("PreviewRetainedResourceProperties", true)]
    [TestCase("VersionedResource", false)]
    [TestCase("VersionedResourceProperties", false)]
    [TestCase("InitialStableEnum", false)]
    [TestCase("PreviewOnlyEnum", true)]
    [TestCase("PreviewRetainedEnum", true)]
    public void ExperimentalTypesReflectSelectedApiVersion(string typeName, bool experimental)
    {
        var type = typeof(VersionedResource).Assembly.GetType(
            $"Azure.Provisioning.ProvisioningTypeSpec.Preview.{typeName}");

        Assert.That(type, Is.Not.Null);
        Assert.That(GetExperimentalDiagnosticId(type!), Is.EqualTo(experimental ? "AZPROVISION001" : null));
    }

    [TestCase("InitialStableProperty", false)]
    [TestCase("PreviewOnlyProperty", true)]
    [TestCase("PreviewRetainedProperty", true)]
    [TestCase("InitialStableEnum", false)]
    [TestCase("PreviewOnlyEnum", true)]
    [TestCase("PreviewRetainedEnum", true)]
    public void ExperimentalPropertiesReflectSelectedApiVersion(string propertyName, bool experimental)
    {
        var property = typeof(VersionedResourceProperties).GetProperty(propertyName);

        Assert.That(property, Is.Not.Null);
        Assert.That(GetExperimentalDiagnosticId(property!), Is.EqualTo(experimental ? "AZPROVISION001" : null));
    }

    [Test]
    public void PreviewResourceVersionRemainsExperimental()
    {
        var field = typeof(VersionedResource.ResourceVersions).GetField("V2024_03_01_PREVIEW");

        Assert.That(field, Is.Not.Null);
        Assert.That(GetExperimentalDiagnosticId(field!), Is.EqualTo("AZPROVISION001"));
    }

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
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.Preview.LatestStableEnum"), Is.Null);
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResourceProperties.InitialStableProperty)));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResourceProperties.PreviewOnlyProperty)));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResourceProperties.PreviewRetainedProperty)));
        Assert.That(propertyNames, Does.Not.Contain("LatestStableProperty"));
    }

    private static object? GetExperimentalDiagnosticId(MemberInfo member)
        => member.CustomAttributes.SingleOrDefault(attribute =>
            attribute.AttributeType.FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute")
            ?.ConstructorArguments[0].Value;
}
