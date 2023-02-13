// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerService
{
    /// <summary>
    /// A Class representing a ContainerServiceManagedCluster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ContainerServiceManagedClusterResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetContainerServiceManagedClusterResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetContainerServiceManagedCluster method.
    /// </summary>
    public partial class ContainerServiceManagedClusterResource : ArmResource
    {
        /// <summary>
        /// Deletes a managed cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}
        /// Operation Id: ManagedClusters_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Delete");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
                var response = await _containerServiceManagedClusterManagedClustersRestClient.DeleteAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a managed cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}
        /// Operation Id: ManagedClusters_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Delete");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
                var response = _containerServiceManagedClusterManagedClustersRestClient.Delete(message, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates tags on a managed cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}
        /// Operation Id: ManagedClusters_UpdateTags
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="containerServiceTagsObject"> Parameters supplied to the Update Managed Cluster Tags operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerServiceTagsObject"/> is null. </exception>
        public virtual async Task<ArmOperation<ContainerServiceManagedClusterResource>> UpdateAsync(WaitUntil waitUntil, ContainerServiceTagsObject containerServiceTagsObject, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(containerServiceTagsObject, nameof(containerServiceTagsObject));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Update");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateUpdateTagsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, containerServiceTagsObject);
                var response = await _containerServiceManagedClusterManagedClustersRestClient.UpdateTagsAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation<ContainerServiceManagedClusterResource>(new ContainerServiceManagedClusterOperationSource(Client), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates tags on a managed cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}
        /// Operation Id: ManagedClusters_UpdateTags
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="containerServiceTagsObject"> Parameters supplied to the Update Managed Cluster Tags operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerServiceTagsObject"/> is null. </exception>
        public virtual ArmOperation<ContainerServiceManagedClusterResource> Update(WaitUntil waitUntil, ContainerServiceTagsObject containerServiceTagsObject, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(containerServiceTagsObject, nameof(containerServiceTagsObject));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Update");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateUpdateTagsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, containerServiceTagsObject);
                var response = _containerServiceManagedClusterManagedClustersRestClient.UpdateTags(message, cancellationToken);
                var operation = new ContainerServiceArmOperation<ContainerServiceManagedClusterResource>(new ContainerServiceManagedClusterOperationSource(Client), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This action cannot be performed on a cluster that is not using a service principal
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/resetServicePrincipalProfile
        /// Operation Id: ManagedClusters_ResetServicePrincipalProfile
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="managedClusterServicePrincipalProfile"> The service principal profile to set on the managed cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managedClusterServicePrincipalProfile"/> is null. </exception>
        public virtual async Task<ArmOperation> ResetServicePrincipalProfileAsync(WaitUntil waitUntil, ManagedClusterServicePrincipalProfile managedClusterServicePrincipalProfile, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managedClusterServicePrincipalProfile, nameof(managedClusterServicePrincipalProfile));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.ResetServicePrincipalProfile");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateResetServicePrincipalProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterServicePrincipalProfile);
                var response = await _containerServiceManagedClusterManagedClustersRestClient.ResetServicePrincipalProfileAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This action cannot be performed on a cluster that is not using a service principal
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/resetServicePrincipalProfile
        /// Operation Id: ManagedClusters_ResetServicePrincipalProfile
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="managedClusterServicePrincipalProfile"> The service principal profile to set on the managed cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managedClusterServicePrincipalProfile"/> is null. </exception>
        public virtual ArmOperation ResetServicePrincipalProfile(WaitUntil waitUntil, ManagedClusterServicePrincipalProfile managedClusterServicePrincipalProfile, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managedClusterServicePrincipalProfile, nameof(managedClusterServicePrincipalProfile));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.ResetServicePrincipalProfile");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateResetServicePrincipalProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterServicePrincipalProfile);
                var response = _containerServiceManagedClusterManagedClustersRestClient.ResetServicePrincipalProfile(message, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reset the AAD Profile of a managed cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/resetAADProfile
        /// Operation Id: ManagedClusters_ResetAADProfile
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="managedClusterAadProfile"> The AAD profile to set on the Managed Cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managedClusterAadProfile"/> is null. </exception>
        public virtual async Task<ArmOperation> ResetAadProfileAsync(WaitUntil waitUntil, ManagedClusterAadProfile managedClusterAadProfile, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managedClusterAadProfile, nameof(managedClusterAadProfile));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.ResetAadProfile");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateResetAadProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterAadProfile);
                var response = await _containerServiceManagedClusterManagedClustersRestClient.ResetAadProfileAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reset the AAD Profile of a managed cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/resetAADProfile
        /// Operation Id: ManagedClusters_ResetAADProfile
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="managedClusterAadProfile"> The AAD profile to set on the Managed Cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managedClusterAadProfile"/> is null. </exception>
        public virtual ArmOperation ResetAadProfile(WaitUntil waitUntil, ManagedClusterAadProfile managedClusterAadProfile, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managedClusterAadProfile, nameof(managedClusterAadProfile));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.ResetAadProfile");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateResetAadProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterAadProfile);
                var response = _containerServiceManagedClusterManagedClustersRestClient.ResetAadProfile(message, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// See [Certificate rotation](https://docs.microsoft.com/azure/aks/certificate-rotation) for more details about rotating managed cluster certificates.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/rotateClusterCertificates
        /// Operation Id: ManagedClusters_RotateClusterCertificates
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> RotateClusterCertificatesAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.RotateClusterCertificates");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateRotateClusterCertificatesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
                var response = await _containerServiceManagedClusterManagedClustersRestClient.RotateClusterCertificatesAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// See [Certificate rotation](https://docs.microsoft.com/azure/aks/certificate-rotation) for more details about rotating managed cluster certificates.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/rotateClusterCertificates
        /// Operation Id: ManagedClusters_RotateClusterCertificates
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation RotateClusterCertificates(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.RotateClusterCertificates");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateRotateClusterCertificatesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
                var response = _containerServiceManagedClusterManagedClustersRestClient.RotateClusterCertificates(message, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This can only be performed on Azure Virtual Machine Scale set backed clusters. Stopping a cluster stops the control plane and agent nodes entirely, while maintaining all object and cluster state. A cluster does not accrue charges while it is stopped. See [stopping a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about stopping a cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/stop
        /// Operation Id: ManagedClusters_Stop
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> StopAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Stop");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateStopRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
                var response = await _containerServiceManagedClusterManagedClustersRestClient.StopAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This can only be performed on Azure Virtual Machine Scale set backed clusters. Stopping a cluster stops the control plane and agent nodes entirely, while maintaining all object and cluster state. A cluster does not accrue charges while it is stopped. See [stopping a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about stopping a cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/stop
        /// Operation Id: ManagedClusters_Stop
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Stop(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Stop");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateStopRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
                var response = _containerServiceManagedClusterManagedClustersRestClient.Stop(message, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// See [starting a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about starting a cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/start
        /// Operation Id: ManagedClusters_Start
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> StartAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Start");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateStartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
                var response = await _containerServiceManagedClusterManagedClustersRestClient.StartAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// See [starting a cluster](https://docs.microsoft.com/azure/aks/start-stop-cluster) for more details about starting a cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/start
        /// Operation Id: ManagedClusters_Start
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Start(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Start");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateStartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
                var response = _containerServiceManagedClusterManagedClustersRestClient.Start(message, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// AKS will create a pod to run the command. This is primarily useful for private clusters. For more information see [AKS Run Command](https://docs.microsoft.com/azure/aks/private-clusters#aks-run-command-preview).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/runCommand
        /// Operation Id: ManagedClusters_RunCommand
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The run command request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<ManagedClusterRunCommandResult>> RunCommandAsync(WaitUntil waitUntil, ManagedClusterRunCommandContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.RunCommand");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateRunCommandRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content);
                var response = await _containerServiceManagedClusterManagedClustersRestClient.RunCommandAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation<ManagedClusterRunCommandResult>(new ManagedClusterRunCommandResultOperationSource(), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// AKS will create a pod to run the command. This is primarily useful for private clusters. For more information see [AKS Run Command](https://docs.microsoft.com/azure/aks/private-clusters#aks-run-command-preview).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/runCommand
        /// Operation Id: ManagedClusters_RunCommand
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The run command request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<ManagedClusterRunCommandResult> RunCommand(WaitUntil waitUntil, ManagedClusterRunCommandContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.RunCommand");
            scope.Start();
            try
            {
                using var message = _containerServiceManagedClusterManagedClustersRestClient.CreateRunCommandRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content);
                var response = _containerServiceManagedClusterManagedClustersRestClient.RunCommand(message, cancellationToken);
                var operation = new ContainerServiceArmOperation<ManagedClusterRunCommandResult>(new ManagedClusterRunCommandResultOperationSource(), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
