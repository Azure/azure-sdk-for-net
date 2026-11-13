// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense
{
    /// <summary>
    /// A Class representing an IotFirmware along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="IotFirmwareResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetIotFirmwareResource method.
    /// Otherwise you can get one from its parent resource <see cref="FirmwareAnalysisWorkspaceResource"/> using the GetIotFirmware method.
    /// </summary>
    public partial class IotFirmwareResource : ArmResource
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
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<FirmwareAnalysisSummaryResource>> GetFirmwareAnalysisSummaryAsync(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default)
        {
            return await GetFirmwareAnalysisSummaryAsync(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken).ConfigureAwait(false);
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
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<FirmwareAnalysisSummaryResource> GetFirmwareAnalysisSummary(FirmwareAnalysisSummaryName summaryName, CancellationToken cancellationToken = default) =>
            GetFirmwareAnalysisSummary(new FirmwareAnalysisSummaryType(summaryName.ToString()), cancellationToken);

        /// <summary>
        /// Lists CVE analysis results of a firmware.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/cves</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cves_ListByFirmware</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CveResult"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CveResult> GetCommonVulnerabilitiesAndExposuresAsync(CancellationToken cancellationToken = default) =>
            GetCvesAsync(cancellationToken);

        /// <summary>
        /// Lists CVE analysis results of a firmware.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/cves</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cves_ListByFirmware</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CveResult"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CveResult> GetCommonVulnerabilitiesAndExposures(CancellationToken cancellationToken = default) =>
            GetCves(cancellationToken);

        /// <summary>
        /// The operation to a url for file download.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/generateDownloadUrl</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Firmwares_GenerateDownloadUri</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotFirmwareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<FirmwareUriToken>> GenerateDownloadUriAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _iotFirmwareFirmwaresClientDiagnostics.CreateScope("IotFirmwareResource.GenerateDownloadUri");
            scope.Start();
            try
            {
                var response = await _iotFirmwareFirmwaresRestClient.GenerateDownloadUriAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to a url for file download.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/generateDownloadUrl</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Firmwares_GenerateDownloadUri</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotFirmwareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<FirmwareUriToken> GenerateDownloadUri(CancellationToken cancellationToken = default)
        {
            using var scope = _iotFirmwareFirmwaresClientDiagnostics.CreateScope("IotFirmwareResource.GenerateDownloadUri");
            scope.Start();
            try
            {
                var response = _iotFirmwareFirmwaresRestClient.GenerateDownloadUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to a url for tar file download.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/generateFilesystemDownloadUrl</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Firmwares_GenerateFilesystemDownloadUri</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotFirmwareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<FirmwareUriToken>> GenerateFilesystemDownloadUriAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _iotFirmwareFirmwaresClientDiagnostics.CreateScope("IotFirmwareResource.GenerateFilesystemDownloadUri");
            scope.Start();
            try
            {
                var response = await _iotFirmwareFirmwaresRestClient.GenerateFilesystemDownloadUriAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to a url for tar file download.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTFirmwareDefense/workspaces/{workspaceName}/firmwares/{firmwareId}/generateFilesystemDownloadUrl</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Firmwares_GenerateFilesystemDownloadUri</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-10</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotFirmwareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<FirmwareUriToken> GenerateFilesystemDownloadUri(CancellationToken cancellationToken = default)
        {
            using var scope = _iotFirmwareFirmwaresClientDiagnostics.CreateScope("IotFirmwareResource.GenerateFilesystemDownloadUri");
            scope.Start();
            try
            {
                var response = _iotFirmwareFirmwaresRestClient.GenerateFilesystemDownloadUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
