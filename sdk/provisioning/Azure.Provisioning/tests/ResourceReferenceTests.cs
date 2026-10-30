// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Roles;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

public class ResourceReferenceTests
{
    [Test]
    public void NullScopeIsUnset()
    {
        ManagementLock resource = new("resource") { Scope = null };

        Assert.That(resource.Scope, Is.Null);
        Assert.That(resource.ProvisionableProperties[nameof(ManagementLock.Scope)].Kind, Is.EqualTo(BicepValueKind.Unset));
    }

    [Test]
    public void ClearingRequiredParentLeavesItUnset()
    {
        FederatedIdentityCredential resource = new("credential")
        {
            Name = "credential",
            Parent = new UserAssignedIdentity("identity")
        };
        resource.Parent = null;

        Assert.That(resource.Parent, Is.Null);
        IBicepValue parent = resource.ProvisionableProperties[nameof(FederatedIdentityCredential.Parent)];
        Assert.That(parent.Kind, Is.EqualTo(BicepValueKind.Unset));
        Assert.That(parent.IsRequired, Is.True);

        Infrastructure infrastructure = new();
        infrastructure.Add(resource);
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => infrastructure.Build())!;
        Assert.That(exception.Message, Does.Contain("missing required property Parent"));
    }

    [Test]
    public void ParentCanBeReassignedAfterClearing()
    {
        FederatedIdentityCredential resource = new("credential")
        {
            Parent = new UserAssignedIdentity("previous")
        };
        resource.Parent = null;
        UserAssignedIdentity identity = new("identity");
        resource.Parent = identity;

        Assert.That(resource.Parent, Is.SameAs(identity));
        IBicepValue parent = resource.ProvisionableProperties[nameof(FederatedIdentityCredential.Parent)];
        Assert.That(parent.Kind, Is.EqualTo(BicepValueKind.Expression));
        Assert.That(parent.Compile().ToString(), Is.EqualTo("identity"));
    }

    [Test]
    public void OrdinaryPropertyStillEmitsExplicitNull()
    {
        ManagementLock resource = new("resource");
        resource.Notes = (string)null!;

        IBicepValue notes = resource.ProvisionableProperties[nameof(ManagementLock.Notes)];
        Assert.That(notes.Kind, Is.Not.EqualTo(BicepValueKind.Unset));
        Assert.That(notes.Compile().ToString(), Is.EqualTo("null"));
    }
}
