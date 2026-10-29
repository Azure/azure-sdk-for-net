// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Roles;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Relationships.Tests;

public class BasicRelationshipsTests
{
    internal static Trycep CreateDependencyRelationshipTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:RelationshipsBasic
                Infrastructure infra = new();

                UserAssignedIdentity source = new(nameof(source), "2023-01-31")
                {
                    Name = "source-identity",
                };
                infra.Add(source);

                UserAssignedIdentity target = new(nameof(target), "2023-01-31")
                {
                    Name = "target-identity",
                };
                infra.Add(target);

                DependencyOfRelationship relationship =
                    new(nameof(relationship), DependencyOfRelationship.ResourceVersions.V2026_08_01)
                    {
                        Name = "dependency",
                        Scope = source,
                        Properties = new DependencyOfRelationshipProperties
                        {
                            TargetId = target.Id,
                        },
                    };
                infra.Add(relationship);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateDependencyRelationship()
    {
        await using Trycep test = CreateDependencyRelationshipTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource source 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
              name: 'source-identity'
              location: location
            }

            resource target 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
              name: 'target-identity'
              location: location
            }

            resource relationship 'Microsoft.Relationships/dependencyOf@2026-08-01' = {
              name: 'dependency'
              scope: source
              properties: {
                targetId: target.id
              }
            }
            """);
    }

    [Test]
    public async Task CreateServiceGroupMemberRelationship()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                UserAssignedIdentity member = new(nameof(member), "2023-01-31")
                {
                    Name = "member-identity",
                };
                infra.Add(member);

                ServiceGroupMemberRelationship relationship =
                    new(nameof(relationship), ServiceGroupMemberRelationship.ResourceVersions.V2026_08_01)
                    {
                        Name = "membership",
                        Scope = member,
                        Properties = new ServiceGroupMemberRelationshipProperties
                        {
                            SourceId = new ResourceIdentifier("/providers/Microsoft.Management/serviceGroups/example-group"),
                        },
                    };
                infra.Add(relationship);
                return infra;
            });
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource member 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
              name: 'member-identity'
              location: location
            }

            resource relationship 'Microsoft.Relationships/serviceGroupMember@2026-08-01' = {
              name: 'membership'
              scope: member
              properties: {
                sourceId: '/providers/Microsoft.Management/serviceGroups/example-group'
              }
            }
            """);
    }
}
