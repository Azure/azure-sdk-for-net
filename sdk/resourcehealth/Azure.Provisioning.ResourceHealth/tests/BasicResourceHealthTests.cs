// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ResourceHealth.Tests;

public class BasicResourceHealthTests
{
    internal static Trycep CreateResourceHealthEventTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ResourceHealthEventBasic
                Infrastructure infra = new() { TargetScope = DeploymentScope.Subscription };

                ResourceHealthEvent healthEvent = ResourceHealthEvent.FromExisting(nameof(healthEvent), ResourceHealthEvent.ResourceVersions.V2025_05_01);
                healthEvent.Name = "eventTrackingId";
                infra.Add(healthEvent);

                infra.Add(new ProvisioningOutput("eventId", typeof(string)) { Value = healthEvent.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.resourcehealth/2025-05-01/events")]
    public async Task ReferenceResourceHealthEvent()
    {
        await using Trycep test = CreateResourceHealthEventTest();
        test.Compare(
            """
            targetScope = 'subscription'

            resource healthEvent 'Microsoft.ResourceHealth/events@2025-05-01' existing = {
              name: 'eventTrackingId'
            }

            output eventId string = healthEvent.id
            """);
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.resourcehealth/2025-05-01/events/impactedresources")]
    public async Task ReferenceResourceHealthEventImpactedResource()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new() { TargetScope = DeploymentScope.Subscription };

                ResourceHealthEvent healthEvent = ResourceHealthEvent.FromExisting(nameof(healthEvent), ResourceHealthEvent.ResourceVersions.V2025_05_01);
                healthEvent.Name = "eventTrackingId";
                infra.Add(healthEvent);

                ResourceHealthEventImpactedResource impactedResource = ResourceHealthEventImpactedResource.FromExisting(nameof(impactedResource), ResourceHealthEventImpactedResource.ResourceVersions.V2025_05_01);
                impactedResource.Name = "impactedResourceName";
                impactedResource.Parent = healthEvent;
                infra.Add(impactedResource);

                return infra;
            });

        test.Compare(
            """
            targetScope = 'subscription'

            resource healthEvent 'Microsoft.ResourceHealth/events@2025-05-01' existing = {
              name: 'eventTrackingId'
            }

            resource impactedResource 'Microsoft.ResourceHealth/events/impactedResources@2025-05-01' existing = {
              name: 'impactedResourceName'
              parent: healthEvent
            }
            """);
    }
}
