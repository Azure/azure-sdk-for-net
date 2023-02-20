// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return await DeleteAsync(waitUntil, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return Delete(waitUntil, null, cancellationToken);
        }

        /// <summary>
        /// Deletes a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ignorePodDisruptionBudget"> ignore-pod-disruption-budget=true to delete those pods on a node without considering Pod Disruption Budget. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? ignorePodDisruptionBudget = null, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Delete");
            scope.Start();
            try
            {
                var response = await _containerServiceManagedClusterManagedClustersRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ignorePodDisruptionBudget, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ignorePodDisruptionBudget).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ignorePodDisruptionBudget"> ignore-pod-disruption-budget=true to delete those pods on a node without considering Pod Disruption Budget. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? ignorePodDisruptionBudget = null, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Delete");
            scope.Start();
            try
            {
                var response = _containerServiceManagedClusterManagedClustersRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ignorePodDisruptionBudget, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ignorePodDisruptionBudget).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_UpdateTags</description>
        /// </item>
        /// </list>
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
                var response = await _containerServiceManagedClusterManagedClustersRestClient.UpdateTagsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, containerServiceTagsObject, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation<ContainerServiceManagedClusterResource>(new ContainerServiceManagedClusterOperationSource(Client), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateUpdateTagsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, containerServiceTagsObject).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_UpdateTags</description>
        /// </item>
        /// </list>
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
                var response = _containerServiceManagedClusterManagedClustersRestClient.UpdateTags(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, containerServiceTagsObject, cancellationToken);
                var operation = new ContainerServiceArmOperation<ContainerServiceManagedClusterResource>(new ContainerServiceManagedClusterOperationSource(Client), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateUpdateTagsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, containerServiceTagsObject).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/resetServicePrincipalProfile</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_ResetServicePrincipalProfile</description>
        /// </item>
        /// </list>
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
                var response = await _containerServiceManagedClusterManagedClustersRestClient.ResetServicePrincipalProfileAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterServicePrincipalProfile, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateResetServicePrincipalProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterServicePrincipalProfile).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/resetServicePrincipalProfile</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_ResetServicePrincipalProfile</description>
        /// </item>
        /// </list>
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
                var response = _containerServiceManagedClusterManagedClustersRestClient.ResetServicePrincipalProfile(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterServicePrincipalProfile, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateResetServicePrincipalProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterServicePrincipalProfile).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/resetAADProfile</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_ResetAADProfile</description>
        /// </item>
        /// </list>
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
                var response = await _containerServiceManagedClusterManagedClustersRestClient.ResetAadProfileAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterAadProfile, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateResetAadProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterAadProfile).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/resetAADProfile</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_ResetAADProfile</description>
        /// </item>
        /// </list>
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
                var response = _containerServiceManagedClusterManagedClustersRestClient.ResetAadProfile(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterAadProfile, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateResetAadProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, managedClusterAadProfile).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/rotateClusterCertificates</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_RotateClusterCertificates</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> RotateClusterCertificatesAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.RotateClusterCertificates");
            scope.Start();
            try
            {
                var response = await _containerServiceManagedClusterManagedClustersRestClient.RotateClusterCertificatesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateRotateClusterCertificatesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/rotateClusterCertificates</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_RotateClusterCertificates</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation RotateClusterCertificates(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.RotateClusterCertificates");
            scope.Start();
            try
            {
                var response = _containerServiceManagedClusterManagedClustersRestClient.RotateClusterCertificates(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateRotateClusterCertificatesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/stop</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Stop</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> StopAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Stop");
            scope.Start();
            try
            {
                var response = await _containerServiceManagedClusterManagedClustersRestClient.StopAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateStopRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/stop</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Stop</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Stop(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Stop");
            scope.Start();
            try
            {
                var response = _containerServiceManagedClusterManagedClustersRestClient.Stop(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateStopRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/start</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Start</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> StartAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Start");
            scope.Start();
            try
            {
                var response = await _containerServiceManagedClusterManagedClustersRestClient.StartAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateStartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/start</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Start</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Start(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterResource.Start");
            scope.Start();
            try
            {
                var response = _containerServiceManagedClusterManagedClustersRestClient.Start(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new ContainerServiceArmOperation(_containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateStartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/runCommand</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_RunCommand</description>
        /// </item>
        /// </list>
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
                var response = await _containerServiceManagedClusterManagedClustersRestClient.RunCommandAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation<ManagedClusterRunCommandResult>(new ManagedClusterRunCommandResultOperationSource(), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateRunCommandRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/runCommand</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_RunCommand</description>
        /// </item>
        /// </list>
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
                var response = _containerServiceManagedClusterManagedClustersRestClient.RunCommand(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                var operation = new ContainerServiceArmOperation<ManagedClusterRunCommandResult>(new ManagedClusterRunCommandResultOperationSource(), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateRunCommandRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
