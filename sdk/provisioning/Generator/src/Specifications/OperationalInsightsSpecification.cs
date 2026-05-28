// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.OperationalInsights;
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class OperationalInsightsSpecification() :
    Specification("OperationalInsights", typeof(OperationalInsightsExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<LogAnalyticsQueryResource>("Id");
        RemoveProperty<OperationalInsightsSavedSearchResource>("SavedSearchId");
        RemoveProperty<OperationalInsightsTableResource>("RetentionInDaysAsDefault");
        RemoveProperty<OperationalInsightsTableResource>("TotalRetentionInDaysAsDefault");

        // Patch models
        CustomizeProperty<OperationalInsightsClusterSku>("Capacity", p => p.Path = ["capacity"]);
        CustomizeProperty<OperationalInsightsClusterSku>("Name", p => p.Path = ["name"]);
        CustomizeProperty<OperationalInsightsWorkspaceSharedKeys>("PrimarySharedKey", p => p.IsSecure = true);
        CustomizeProperty<OperationalInsightsWorkspaceSharedKeys>("SecondarySharedKey", p => p.IsSecure = true);

        // Naming requirements
        AddNameRequirements<OperationalInsightsClusterResource>(min: 4, max: 63, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<OperationalInsightsWorkspaceResource>(min: 4, max: 63, lower: true, upper: true, digits: true, hyphen: true);
    }
}
