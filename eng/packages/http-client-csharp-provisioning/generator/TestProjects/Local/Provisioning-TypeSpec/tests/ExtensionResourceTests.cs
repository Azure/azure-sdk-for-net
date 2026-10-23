// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Tests;

public class ExtensionResourceTests
{
    [Test]
    public void ReadOnlyExtensionPreservesScope()
    {
        Assert.That(typeof(ReadOnlyExtension).GetProperty("Scope")?.PropertyType,
            Is.EqualTo(typeof(ProvisionableResource)));
        Assert.That(typeof(ReadOnlyExtension).GetConstructors(), Is.Empty,
            "An existing-only resource must not become publicly deployable.");
        Assert.That(ReadOnlyExtension.FromExisting("existing").IsExistingResource, Is.True);
        Assert.That(ReadOnlyExtension.FromExisting("existing").ProvisionableProperties["Scope"].IsRequired, Is.True);
    }

    [Test]
    public void ExtensionChildPreservesStructuralParent()
    {
        Assert.That(typeof(ExtensionChild).GetProperty("Parent")?.PropertyType,
            Is.EqualTo(typeof(ExtensionAssignment)));
        Assert.That(typeof(ExtensionChild).GetProperty("Scope"), Is.Null,
            "A child inherits scope through its parent, not a second scope property.");
    }

    [Test]
    public void ExtensionOnlyScopeIsRequired()
    {
        ExtensionAssignment assignment = new("assignment");
        _ = assignment.Name;
        Assert.That(assignment.ProvisionableProperties["Scope"].IsRequired, Is.True);
        Infrastructure infra = new();
        infra.Add(assignment);
        var exception = Assert.Throws<InvalidOperationException>(() => infra.Build());
        Assert.That(exception!.Message, Does.Contain("Scope"));
    }

    [Test]
    public void MultiScopeRemainsOptional()
    {
        MultiScopeAssignment assignment = new("assignment");
        _ = assignment.Name;
        Assert.That(assignment.ProvisionableProperties["Scope"].IsRequired, Is.False);
    }

    [Test]
    public async Task ExternalResourceIdentities()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ExistingBillingProfile billing = new();
                ReadOnlyExtension grant = ReadOnlyExtension.FromExisting("grant");
                grant.Scope = billing;
                ExtensionAssignment lab = new("lab") { Name = "lab", Scope = billing };
                ExtensionChild student = new("student") { Name = "student", Parent = lab };
                ExtensionChild existing = ExtensionChild.FromExisting("existing");
                existing.Name = "existing";
                existing.Parent = lab;
                infra.Add(billing);
                infra.Add(grant);
                infra.Add(lab);
                infra.Add(student);
                infra.Add(existing);
                return infra;
            });

        test.Compare(
            """
            resource billing 'Microsoft.Billing/billingAccounts/billingProfiles@2024-04-01' existing = {
              name: 'account/profile'
            }

            resource grant 'ProvisioningTypeSpec/readOnlyExtensions@2024-05-01' existing = {
              name: 'default'
              scope: billing
            }

            resource lab 'ProvisioningTypeSpec/extensionAssignments@2024-05-01' = {
              name: 'lab'
              scope: billing
            }

            resource student 'ProvisioningTypeSpec/extensionAssignments/children@2024-05-01' = {
              name: 'student'
              parent: lab
            }

            resource existing 'ProvisioningTypeSpec/extensionAssignments/children@2024-05-01' existing = {
              name: 'existing'
              parent: lab
            }
            """);
    }

    [Test]
    public async Task MultiScopeResourceIdentities()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ExistingBillingProfile billing = new();
                MultiScopeAssignment root = new("root") { Name = "root" };
                MultiScopeAssignment scoped = new("scoped") { Name = "scoped", Scope = billing };
                infra.Add(billing);
                infra.Add(root);
                infra.Add(scoped);
                return infra;
            });

        test.Compare(
            """
            resource billing 'Microsoft.Billing/billingAccounts/billingProfiles@2024-04-01' existing = {
              name: 'account/profile'
            }

            resource root 'ProvisioningTypeSpec/multiScopeAssignments@2024-05-01' = {
              name: 'root'
            }

            resource scoped 'ProvisioningTypeSpec/multiScopeAssignments@2024-05-01' = {
              name: 'scoped'
              scope: billing
            }
            """);
    }

    private sealed class ExistingBillingProfile : ProvisionableResource
    {
        public ExistingBillingProfile()
            : base("billing", "Microsoft.Billing/billingAccounts/billingProfiles", "2024-04-01")
        {
            IsExistingResource = true;
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            DefineProperty<string>("Name", ["name"], isRequired: true, defaultValue: "account/profile");
        }
    }
}
