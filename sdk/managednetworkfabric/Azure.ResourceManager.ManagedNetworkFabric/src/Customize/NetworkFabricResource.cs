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
    // (StateUpdateCommonPostActionResult / DeviceUpdateCommonPostActionResult / ValidateConfigurationResult)
    // to operation-specific types. The generated methods were renamed via operationId directives
    // (adding synonym-based renaming), and these shims preserve the original v1.1.2 method signatures.
    // Removing them would drop the old method names/return types even though the REST actions still exist.
    public partial class NetworkFabricResource
    {
        /// <summary> Backward-compatible shim for CommitConfiguration. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> CommitConfigurationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.CommitConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateApplyConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, CommitConfigurationContent.ToRequestContent(null), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<CommitConfigurationResult> operation = new ManagedNetworkFabricArmOperation<CommitConfigurationResult>(
                    new CommitConfigurationResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<CommitConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for CommitConfiguration. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> CommitConfiguration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.CommitConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateApplyConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, CommitConfigurationContent.ToRequestContent(null), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<CommitConfigurationResult> operation = new ManagedNetworkFabricArmOperation<CommitConfigurationResult>(
                    new CommitConfigurationResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<CommitConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for Deprovision. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DeviceUpdateCommonPostActionResult>> DeprovisionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.Deprovision");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateDeactivateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<OperationStatusResult> operation = new ManagedNetworkFabricArmOperation<OperationStatusResult>(
                    new OperationStatusResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for Deprovision. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DeviceUpdateCommonPostActionResult> Deprovision(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.Deprovision");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateDeactivateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<OperationStatusResult> operation = new ManagedNetworkFabricArmOperation<OperationStatusResult>(
                    new OperationStatusResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for Provision. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DeviceUpdateCommonPostActionResult>> ProvisionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.Provision");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateActivateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<OperationStatusResult> operation = new ManagedNetworkFabricArmOperation<OperationStatusResult>(
                    new OperationStatusResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for Provision. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DeviceUpdateCommonPostActionResult> Provision(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.Provision");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateActivateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<OperationStatusResult> operation = new ManagedNetworkFabricArmOperation<OperationStatusResult>(
                    new OperationStatusResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
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
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.RefreshConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateReloadConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<OperationStatusResult> operation = new ManagedNetworkFabricArmOperation<OperationStatusResult>(
                    new OperationStatusResultOperationSource(),
                    _networkFabricsClientDiagnostics,
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

        /// <summary> Backward-compatible shim for RefreshConfiguration. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> RefreshConfiguration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.RefreshConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateReloadConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<OperationStatusResult> operation = new ManagedNetworkFabricArmOperation<OperationStatusResult>(
                    new OperationStatusResultOperationSource(),
                    _networkFabricsClientDiagnostics,
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

        /// <summary> Backward-compatible shim for UpdateInfraManagementBfdConfiguration. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateInfraManagementBfdConfigurationAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.UpdateInfraManagementBfdConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateSetInfraManagementBfdConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, UpdateAdministrativeStateContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult> operation = new ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult>(
                    new UpdateAdministrativeStateResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for UpdateInfraManagementBfdConfiguration. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateInfraManagementBfdConfiguration(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.UpdateInfraManagementBfdConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateSetInfraManagementBfdConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, UpdateAdministrativeStateContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult> operation = new ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult>(
                    new UpdateAdministrativeStateResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for UpdateWorkloadManagementBfdConfiguration. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateWorkloadManagementBfdConfigurationAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.UpdateWorkloadManagementBfdConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateSetWorkloadManagementBfdConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, UpdateAdministrativeStateContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult> operation = new ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult>(
                    new UpdateAdministrativeStateResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for UpdateWorkloadManagementBfdConfiguration. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateWorkloadManagementBfdConfiguration(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.UpdateWorkloadManagementBfdConfiguration");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateSetWorkloadManagementBfdConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, UpdateAdministrativeStateContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult> operation = new ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult>(
                    new UpdateAdministrativeStateResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with UpgradeNetworkFabricProperties instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with UpgradeNetworkFabricProperties instead.")]
        public virtual Task<ArmOperation<StateUpdateCommonPostActionResult>> UpgradeAsync(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use UpgradeAsync with UpgradeNetworkFabricProperties instead.");
        }

        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with UpgradeNetworkFabricProperties instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with UpgradeNetworkFabricProperties instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Upgrade(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use Upgrade with UpgradeNetworkFabricProperties instead.");
        }

        /// <summary> Backward-compatible shim for GetTopology. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ValidateConfigurationResult>> GetTopologyAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.GetTopology");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateRetrieveTopologyRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<GetTopologyResult> operation = new ManagedNetworkFabricArmOperation<GetTopologyResult>(
                    new GetTopologyResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<GetTopologyResult, ValidateConfigurationResult>(operation, r => new ValidateConfigurationResult(r.Error, null, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for GetTopology. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ValidateConfigurationResult> GetTopology(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.GetTopology");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateRetrieveTopologyRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<GetTopologyResult> operation = new ManagedNetworkFabricArmOperation<GetTopologyResult>(
                    new GetTopologyResultOperationSource(),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<GetTopologyResult, ValidateConfigurationResult>(operation, r => new ValidateConfigurationResult(r.Error, null, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
