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
        var diagnosticId = typeName switch
        {
            "PreviewOnlyResource" => "CUSTOMRESOURCE001",
            "PreviewOnlyResourceProperties" => "CUSTOMMODEL001",
            _ => experimental ? "AZPROVISION001" : null
        };
        Assert.That(GetExperimentalDiagnosticId(type!), Is.EqualTo(diagnosticId));
    }

    [TestCase("InitialStableProperty", false)]
    [TestCase("PreviewOnlyProperty", true)]
    [TestCase("PreviewRetainedProperty", true)]
    [TestCase("InitialStableEnum", false)]
    [TestCase("PreviewOnlyEnum", true)]
    [TestCase("PreviewRetainedEnum", true)]
    public void ExperimentalPropertiesReflectSelectedApiVersion(string propertyName, bool experimental)
    {
        var property = typeof(VersionedResource).GetProperty(propertyName);

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
        var propertyNames = typeof(VersionedResource)
            .GetProperties()
            .Select(property => property.Name);

        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.Preview.PreviewOnlyResource"), Is.Not.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.Preview.PreviewRetainedResource"), Is.Not.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.Preview.LatestStableResource"), Is.Null);
        Assert.That(assembly.GetType("Azure.Provisioning.ProvisioningTypeSpec.Preview.LatestStableEnum"), Is.Null);
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResource.InitialStableProperty)));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResource.PreviewOnlyProperty)));
        Assert.That(propertyNames, Does.Contain(nameof(VersionedResource.PreviewRetainedProperty)));
        Assert.That(propertyNames, Does.Not.Contain("LatestStableProperty"));
    }

    [TestCase("FlattenedPreviewValue")]
    [TestCase("SharedValue")]
    [TestCase("NestedPreviewValue")]
    [TestCase("PreviewSafeWrapperSharedValue")]
    public void FlattenedPathsPreservePreviewRestrictions(string propertyName)
    {
        var property = typeof(VersionedResource).GetProperty(propertyName);

        Assert.That(property, Is.Not.Null);
        Assert.That(GetExperimentalDiagnosticId(property!), Is.EqualTo("AZPROVISION001"));
    }

    [Test]
    public void SharedStableLeafRemainsUnmarked()
    {
        var leaf = typeof(VersionedResource).Assembly.GetType(
            "Azure.Provisioning.ProvisioningTypeSpec.Preview.SharedFlattenedLeaf");
        Assert.That(leaf, Is.Not.Null);
        Assert.That(GetExperimentalDiagnosticId(leaf!), Is.Null);
        Assert.That(GetExperimentalDiagnosticId(leaf!.GetProperty("SharedValue")!), Is.Null);
        var stableProperty = typeof(VersionedResource).GetProperty("StableSharedValue");
        Assert.That(stableProperty, Is.Not.Null);
        Assert.That(GetExperimentalDiagnosticId(stableProperty!), Is.Null);
    }

    private static object? GetExperimentalDiagnosticId(MemberInfo member)
        => member.CustomAttributes.SingleOrDefault(attribute =>
            attribute.AttributeType.FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute")
            ?.ConstructorArguments[0].Value;
}
