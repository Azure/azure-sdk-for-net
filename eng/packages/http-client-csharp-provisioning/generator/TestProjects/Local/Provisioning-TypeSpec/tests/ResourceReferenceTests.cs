// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Tests;

public class ResourceReferenceTests
{
    [TestCase(false)]
    [TestCase(true)]
    public void ClearingScopeOmitsReference(bool assignFirst)
    {
        ConfigurationStore store = new("store");
        ExtensionAssignment extension = new("extension") { Name = "assignment" };
        Assert.That(extension.Scope, Is.Null);
        IBicepValue reference = extension.ProvisionableProperties[nameof(ExtensionAssignment.Scope)];
        Assert.That(reference.IsRequired, Is.False);
        Assert.That(reference.IsOutput, Is.False);
        if (assignFirst)
        {
            extension.Scope = store;
            Assert.That(extension.Scope, Is.SameAs(store));
            Assert.That(reference.Compile().ToString(), Is.EqualTo("store"));
        }

        extension.Scope = null!;

        Assert.That(extension.Scope, Is.Null);
        Assert.That(reference.Kind, Is.EqualTo(BicepValueKind.Unset));
        Assert.That(reference.IsEmpty, Is.True);
        Infrastructure infrastructure = new();
        infrastructure.Add(extension);
        string bicep = infrastructure.Build().Compile()["main.bicep"];
        Assert.That(bicep, Does.Not.Contain("scope:"));

        ConfigurationStore replacement = new("replacement");
        extension.Scope = replacement;
        infrastructure.Add(replacement);
        Assert.That(extension.Scope, Is.SameAs(replacement));
        Assert.That(reference.Kind, Is.EqualTo(BicepValueKind.Expression));
        Assert.That(reference.Compile().ToString(), Is.EqualTo("replacement"));
        Assert.That(infrastructure.Build().Compile()["main.bicep"], Does.Contain("scope: replacement"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public void ClearingParentPreservesRequiredValidation(bool assignFirst)
    {
        ConfigurationStore store = new("store");
        KeyValue keyValue = new("keyValue") { Name = "key" };
        Assert.That(keyValue.Parent, Is.Null);
        IBicepValue reference = keyValue.ProvisionableProperties[nameof(KeyValue.Parent)];
        Assert.That(reference.IsRequired, Is.True);
        Assert.That(reference.IsOutput, Is.False);
        if (assignFirst)
        {
            keyValue.Parent = store;
            Assert.That(keyValue.Parent, Is.SameAs(store));
            Assert.That(reference.Compile().ToString(), Is.EqualTo("store"));
        }

        keyValue.Parent = null!;

        Assert.That(keyValue.Parent, Is.Null);
        Assert.That(reference.Kind, Is.EqualTo(BicepValueKind.Unset));
        Assert.That(reference.IsEmpty, Is.True);
        Assert.That(((IBicepValue)keyValue).Compile().ToString(), Does.Not.Contain("parent:"));
        Infrastructure infrastructure = new();
        infrastructure.Add(keyValue);
        Assert.That(() => infrastructure.Build(),
            Throws.TypeOf<InvalidOperationException>().With.Message.Contains("missing required property Parent"));

        ConfigurationStore replacement = new("replacement");
        keyValue.Parent = replacement;
        infrastructure.Add(replacement);
        Assert.That(keyValue.Parent, Is.SameAs(replacement));
        Assert.That(reference.Kind, Is.EqualTo(BicepValueKind.Expression));
        Assert.That(reference.Compile().ToString(), Is.EqualTo("replacement"));
        string bicep = infrastructure.Build().Compile()["main.bicep"];
        Assert.That(bicep, Does.Contain("parent: replacement"));
    }

    [Test]
    public void OrdinaryPropertyNullRemainsExplicitUntilCleared()
    {
        ExtensionAssignment extension = new("extension") { Name = "assignment" };
        extension.ExtensionAssignmentDisplayName = new BicepValue<string>((string)null!);

        Assert.That(extension.ExtensionAssignmentDisplayName.IsEmpty, Is.False);
        Assert.That(extension.ExtensionAssignmentDisplayName.Compile().ToString(), Is.EqualTo("null"));
        Assert.That(((IBicepValue)extension).Compile().ToString(), Does.Contain("displayName: null"));

        extension.ExtensionAssignmentDisplayName.ClearValue();

        Assert.That(extension.ExtensionAssignmentDisplayName.IsEmpty, Is.True);
        Assert.That(((IBicepValue)extension).Compile().ToString(), Does.Not.Contain("displayName:"));
    }
}
