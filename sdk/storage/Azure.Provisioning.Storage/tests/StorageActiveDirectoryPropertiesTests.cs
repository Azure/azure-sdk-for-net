// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Storage.Tests;

public class StorageActiveDirectoryPropertiesTests
{
    private static readonly Guid s_firstDomainGuid = Guid.Parse("11111111-1111-1111-1111-111111111111");
    private static readonly Guid s_secondDomainGuid = Guid.Parse("22222222-2222-2222-2222-222222222222");

    [Test]
    public void DomainGuidSharesBackingValue()
    {
        StorageActiveDirectoryProperties properties = new();

        Assert.That(properties.DomainGuid, Is.SameAs(properties.ActiveDirectoryDomainGuid));
        Assert.That(properties.ProvisionableProperties.Values.Count(value => value.Self!.BicepPath!.SequenceEqual(new[] { "domainGuid" })), Is.EqualTo(1));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void LastAssignmentWins(bool assignLegacyLast)
    {
        StorageActiveDirectoryProperties properties = new();

        if (assignLegacyLast)
        {
            properties.ActiveDirectoryDomainGuid = s_firstDomainGuid;
            properties.DomainGuid = s_secondDomainGuid;
        }
        else
        {
            properties.DomainGuid = s_firstDomainGuid;
            properties.ActiveDirectoryDomainGuid = s_secondDomainGuid;
        }

        Assert.That(properties.DomainGuid.Value, Is.EqualTo(s_secondDomainGuid));
        Assert.That(properties.ActiveDirectoryDomainGuid.Value, Is.EqualTo(s_secondDomainGuid));
        Assert.That(((IBicepValue)properties).Compile().ToString(), Is.EqualTo(
            """
            {
              domainGuid: '22222222-2222-2222-2222-222222222222'
            }
            """));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void AssignThroughEitherGetterUpdatesBothAliases(bool assignLegacy)
    {
        StorageActiveDirectoryProperties properties = new();
        BicepValue<Guid> legacyValue = properties.DomainGuid;
        BicepValue<Guid> currentValue = properties.ActiveDirectoryDomainGuid;

        (assignLegacy ? legacyValue : currentValue).Assign(s_firstDomainGuid);

        Assert.That(legacyValue.Value, Is.EqualTo(s_firstDomainGuid));
        Assert.That(currentValue.Value, Is.EqualTo(s_firstDomainGuid));
        Assert.That(((IBicepValue)properties).Compile().ToString(), Does.Contain($"domainGuid: '{s_firstDomainGuid}'"));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void ClearThroughEitherGetterClearsBothAliases(bool clearLegacy)
    {
        StorageActiveDirectoryProperties properties = new()
        {
            DomainGuid = s_firstDomainGuid
        };

        (clearLegacy ? properties.DomainGuid : properties.ActiveDirectoryDomainGuid).ClearValue();

        Assert.That(properties.DomainGuid.IsEmpty, Is.True);
        Assert.That(properties.ActiveDirectoryDomainGuid.IsEmpty, Is.True);
        Assert.That(((IBicepValue)properties).Compile().ToString(), Does.Not.Contain("domainGuid"));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void ParameterAssignmentsPreserveReferences(bool assignLegacy)
    {
        ProvisioningParameter parameter = new("domainGuid", typeof(string));
        StorageActiveDirectoryProperties properties = new();
        if (assignLegacy)
        {
            properties.DomainGuid = parameter;
        }
        else
        {
            properties.ActiveDirectoryDomainGuid = parameter;
        }

        StorageAccount account = new("storage")
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
            AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication
            {
                DirectoryServiceOptions = DirectoryServiceOption.AD,
                ActiveDirectoryProperties = properties
            }
        };
        Infrastructure infra = new();
        infra.Add(parameter);
        infra.Add(account);
        string bicep = infra.Build().Compile()["main.bicep"];

        Assert.That(((IBicepValue)properties.DomainGuid).Kind, Is.EqualTo(BicepValueKind.Expression));
        Assert.That(((IBicepValue)properties.ActiveDirectoryDomainGuid).Kind, Is.EqualTo(BicepValueKind.Expression));
        Assert.That(bicep, Does.Contain("param domainGuid string"));
        Assert.That(bicep, Does.Contain("domainGuid: domainGuid"));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void ExpressionAssignmentsReplacePreviousLiteral(bool assignLegacy)
    {
        StorageActiveDirectoryProperties properties = new()
        {
            DomainGuid = s_firstDomainGuid
        };
        IdentifierExpression expression = new("domainGuid");
        if (assignLegacy)
        {
            properties.DomainGuid = expression;
        }
        else
        {
            properties.ActiveDirectoryDomainGuid = expression;
        }

        Assert.That(((IBicepValue)properties.DomainGuid).Expression, Is.SameAs(expression));
        Assert.That(((IBicepValue)properties.ActiveDirectoryDomainGuid).Expression, Is.SameAs(expression));
        Assert.That(((IBicepValue)properties).Compile().ToString(), Does.Contain("domainGuid: domainGuid"));
        Assert.That(((IBicepValue)properties).Compile().ToString(), Does.Not.Contain(s_firstDomainGuid.ToString()));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void UnsetAssignmentsClearBothAliases(bool assignLegacy)
    {
        StorageActiveDirectoryProperties properties = new()
        {
            DomainGuid = s_firstDomainGuid,
            ActiveDirectoryDomainGuid = s_firstDomainGuid
        };
        BicepValue<Guid> unset = new(Guid.Empty);
        unset.ClearValue();
        if (assignLegacy)
        {
            properties.DomainGuid = unset;
        }
        else
        {
            properties.ActiveDirectoryDomainGuid = unset;
        }

        Assert.That(properties.DomainGuid.IsEmpty, Is.True);
        Assert.That(properties.ActiveDirectoryDomainGuid.IsEmpty, Is.True);
        Assert.That(((IBicepValue)properties).Compile().ToString(), Does.Not.Contain("domainGuid"));
    }
}
