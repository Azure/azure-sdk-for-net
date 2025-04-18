// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense
{
    /// <summary>
    /// A Class representing a FirmwareAnalysisSummary along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="FirmwareAnalysisSummaryResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetFirmwareAnalysisSummaryResource method.
    /// Otherwise you can get one from its parent resource <see cref="IotFirmwareResource"/> using the GetFirmwareAnalysisSummary method.
    /// </summary>
    public partial class FirmwareAnalysisSummaryResource
    {
        /// <summary> Generate the resource identifier of a <see cref="FirmwareAnalysisSummaryResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="workspaceName"> The workspaceName. </param>
        /// <param name="firmwareId"> The firmwareId. </param>
        /// <param name="summaryName"> The summaryName. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, FirmwareAnalysisSummaryName summaryName) =>
            CreateResourceIdentifier(subscriptionId, resourceGroupName, workspaceName, firmwareId, new FirmwareAnalysisSummaryType(summaryName.ToString()));
    }
}
