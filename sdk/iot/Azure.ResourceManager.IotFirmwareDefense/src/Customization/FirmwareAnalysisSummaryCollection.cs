// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense
{
     /// <summary>
    /// A class representing a collection of <see cref="FirmwareAnalysisSummaryResource"/> and their operations.
    /// Each <see cref="FirmwareAnalysisSummaryResource"/> in the collection will belong to the same instance of <see cref="IotFirmwareResource"/>.
    /// To get a <see cref="FirmwareAnalysisSummaryCollection"/> instance call the GetFirmwareAnalysisSummaries method from an instance of <see cref="IotFirmwareResource"/>.
    /// </summary>
    public partial class FirmwareAnalysisSummaryCollection
    {
        /// <summary>
        /// Get an analysis result summary of a firmware by name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/summaries/{summaryName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Summaries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirmwareAnalysisSummaryResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="summaryName"> The Firmware analysis summary name describing the type of summary. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<FirmwareAnalysisSummaryResource>> GetAsync(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default)
        {
            return await GetAsync(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get an analysis result summary of a firmware by name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/summaries/{summaryName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Summaries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirmwareAnalysisSummaryResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="summaryName"> The Firmware analysis summary name describing the type of summary. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<FirmwareAnalysisSummaryResource> Get(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default) =>
            Get(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken);

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/summaries/{summaryName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Summaries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirmwareAnalysisSummaryResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="summaryName"> The Firmware analysis summary name describing the type of summary. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/summaries/{summaryName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Summaries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirmwareAnalysisSummaryResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="summaryName"> The Firmware analysis summary name describing the type of summary. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default) =>
            Exists(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken);

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/summaries/{summaryName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Summaries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirmwareAnalysisSummaryResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="summaryName"> The Firmware analysis summary name describing the type of summary. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<FirmwareAnalysisSummaryResource>> GetIfExistsAsync(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/summaries/{summaryName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Summaries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FirmwareAnalysisSummaryResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="summaryName"> The Firmware analysis summary name describing the type of summary. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<FirmwareAnalysisSummaryResource> GetIfExists(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default) =>
            GetIfExists(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken);
    }
}
