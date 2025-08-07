// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ApplicationInsights;

namespace Azure.Provisioning.Generator.Specifications;

public class ApplicationInsightsSpecification() :
    Specification("ApplicationInsights", typeof(ApplicationInsightsExtensions))
{
    protected override void Customize()
    {
        // Patch models
        CustomizeModel<ApplicationInsightsWorkbookResource>(m =>
        {
            if (m is not Resource r) { throw new InvalidOperationException($"Expected a resource {nameof(ApplicationInsightsWorkbookResource)}."); }

            // The convenience overload uses a string rather than a ResourceIdentifier so it generates a duplicate property we need to merge
            Property? sourceStr = r.Properties.FirstOrDefault(p => p.Name == "SourceId" && p.PropertyType?.Name == "String");
            Property? sourceId = r.Properties.FirstOrDefault(p => p.Name == "SourceId" && p.PropertyType?.Name == "ResourceIdentifier");
            if (sourceStr is null || sourceId is null) { throw new InvalidOperationException($"Expected to find both SourceId properties in {nameof(ApplicationInsightsWorkbookResource)}."); }

            // Keep the ResourceId, but use the string description
            sourceId.Description = sourceStr.Description;
            r.Properties.Remove(sourceStr);
        });
        CustomizeProperty<ApplicationInsightsComponentResource>("InstrumentationKey", p => p.IsSecure = true);

        // Naming requirements
        AddNameRequirements<ApplicationInsightsComponentResource>(min: 1, max: 260, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);

        // Roles
        Roles.Add(new Role("ApplicationInsightsComponentContributor", "ae349356-3a1b-4a5e-921d-050484c6347e", "Can manage Application Insights components"));
        Roles.Add(new Role("ApplicationInsightsSnapshotDebugger", "08954f03-6346-4c2e-81c0-ec3a5cfae23b", "Gives user permission to view and download debug snapshots collected with the Application Insights Snapshot Debugger. Note that these permissions are not included in the Owner or Contributor roles. When giving users the Application Insights Snapshot Debugger role, you must grant the role directly to the user. The role is not recognized when it is added to a custom role."));
        Roles.Add(new Role("MonitoringContributor", "749f88d5-cbae-40b8-bcfc-e573ddc772fa", "Can read all monitoring data and edit monitoring settings. See also Get started with roles, permissions, and security with Azure Monitor."));
        Roles.Add(new Role("MonitoringMetricsPublisher", "3913510d-42f4-4e42-8a64-420c390055eb", "Enables publishing metrics against Azure resources"));
        Roles.Add(new Role("MonitoringReader", "43d0d8ad-25c7-4714-9337-8ba259a9fe05", "Can read all monitoring data (metrics, logs, etc.). See also Get started with roles, permissions, and security with Azure Monitor."));
        Roles.Add(new Role("WorkbookContributor", "e8ddcd69-c73f-4f9f-9844-4100522f16ad", "Can save shared workbooks."));
        Roles.Add(new Role("WorkbookReader", "b279062a-9be3-42a0-92ae-8b3cf002ec4d", "Can read workbooks."));

        // Assign Roles
        CustomizeResource<ApplicationInsightsComponentResource>(r => r.GenerateRoleAssignment = true);
    }
}
