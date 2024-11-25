// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    /// <summary>
    /// A class representing the SecurityInsightsEntity data model.
    /// Specific entity.
    /// Please note <see cref="SecurityInsightsEntity"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="SecurityInsightsAccountEntity"/>, <see cref="SecurityInsightsAzureResourceEntity"/>, <see cref="SecurityInsightsHuntingBookmark"/>, <see cref="SecurityInsightsCloudApplicationEntity"/>, <see cref="SecurityInsightsDnsEntity"/>, <see cref="SecurityInsightsFileEntity"/>, <see cref="SecurityInsightsFileHashEntity"/>, <see cref="SecurityInsightsHostEntity"/>, <see cref="SecurityInsightsIotDeviceEntity"/>, <see cref="SecurityInsightsIPEntity"/>, <see cref="SecurityInsightsMailboxEntity"/>, <see cref="SecurityInsightsMailClusterEntity"/>, <see cref="SecurityInsightsMailMessageEntity"/>, <see cref="SecurityInsightsMalwareEntity"/>, <see cref="NicEntity"/>, <see cref="SecurityInsightsProcessEntity"/>, <see cref="SecurityInsightsRegistryKeyEntity"/>, <see cref="SecurityInsightsRegistryValueEntity"/>, <see cref="SecurityInsightsAlert"/>, <see cref="SecurityInsightsGroupEntity"/>, <see cref="SecurityInsightsSubmissionMailEntity"/> and <see cref="SecurityInsightsUriEntity"/>.
    /// </summary>
    [CodeGenModel("SecurityInsightsEntityData")]
    public partial class SecurityInsightsEntity
    {
    }
}
