// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shims for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version changed action operation return types from generic result types
    // (StateUpdateCommonPostActionResult / DeviceUpdateCommonPostActionResult) to operation-specific types.
    // The generated methods were renamed via operationId directives (adding synonym-based renaming),
    // and these shims preserve the original v1.1.2 method signatures.
    public partial class NetworkDeviceResource
    {
        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateDeviceAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.UpdateAdministrativeState");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateSetAdministrativeStateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, UpdateDeviceAdministrativeStateContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkDeviceUpdateAdministrativeStateResult> operation = new ManagedNetworkFabricArmOperation<NetworkDeviceUpdateAdministrativeStateResult>(
                    new NetworkDeviceUpdateAdministrativeStateResultOperationSource(),
                    _networkDevicesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<NetworkDeviceUpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateDeviceAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.UpdateAdministrativeState");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateSetAdministrativeStateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, UpdateDeviceAdministrativeStateContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkDeviceUpdateAdministrativeStateResult> operation = new ManagedNetworkFabricArmOperation<NetworkDeviceUpdateAdministrativeStateResult>(
                    new NetworkDeviceUpdateAdministrativeStateResultOperationSource(),
                    _networkDevicesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<NetworkDeviceUpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for Reboot. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RebootAsync(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.Reboot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateRestartRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkDeviceRebootContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<OperationStatusResult> operation = new ManagedNetworkFabricArmOperation<OperationStatusResult>(
                    new OperationStatusResultOperationSource(),
                    _networkDevicesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for Reboot. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Reboot(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.Reboot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateRestartRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkDeviceRebootContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<OperationStatusResult> operation = new ManagedNetworkFabricArmOperation<OperationStatusResult>(
                    new OperationStatusResultOperationSource(),
                    _networkDevicesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RefreshConfigurationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.RefreshConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateReloadConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkDeviceRefreshConfigurationResult> operation = new ManagedNetworkFabricArmOperation<NetworkDeviceRefreshConfigurationResult>(
                    new NetworkDeviceRefreshConfigurationResultOperationSource(),
                    _networkDevicesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<NetworkDeviceRefreshConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> RefreshConfiguration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.RefreshConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateReloadConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkDeviceRefreshConfigurationResult> operation = new ManagedNetworkFabricArmOperation<NetworkDeviceRefreshConfigurationResult>(
                    new NetworkDeviceRefreshConfigurationResultOperationSource(),
                    _networkDevicesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<NetworkDeviceRefreshConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with NetworkDeviceUpgradeContent instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with NetworkDeviceUpgradeContent instead.")]
        public virtual Task<ArmOperation<StateUpdateCommonPostActionResult>> UpgradeAsync(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use UpgradeAsync with NetworkDeviceUpgradeContent instead.");
        }

        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with NetworkDeviceUpgradeContent instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with NetworkDeviceUpgradeContent instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Upgrade(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use Upgrade with NetworkDeviceUpgradeContent instead.");
        }
    }
}
