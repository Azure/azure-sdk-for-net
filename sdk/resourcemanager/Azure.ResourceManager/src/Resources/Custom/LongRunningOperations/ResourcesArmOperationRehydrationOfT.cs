// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class to rehydrate LRO for Resources
    /// </summary>
#pragma warning disable SA1649 // File name should match first type name
    public class ResourcesArmOperationRehydration<T>: ArmOperationRehydration<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary> Initializes a new instance of the <see cref="ResourcesArmOperationRehydration"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The id of the ArmOperation. </param>
        public ResourcesArmOperationRehydration(ArmClient client, string id): base(client, id)
        {
        }

        // <summary> Rehydrate an LRO. </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public override async Task<ArmOperation<T>> RehydrateAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", "Microsoft.Resources", Diagnostics);
            using var scope = clientDiagnostics.CreateScope("ResourcesArmOperationRehydration.Rehydrate");
            scope.Start();
            try
            {
                Type genericType = typeof(T);
                IOperationSource<T> source;
                if (genericType == typeof(GenericResource))
                {
                    source = (IOperationSource<T>)(new GenericResourceOperationSource(Client));
                }
                else if (genericType == typeof(ResourceGroupExportResult))
                {
                    source = (IOperationSource<T>)(new ResourceGroupExportResultOperationSource());
                }
                else if (genericType == typeof(ResourceGroupResource))
                {
                    source = (IOperationSource<T>)(new ResourceGroupOperationSource(Client));
                }
                else if (genericType == typeof(ManagementLockResource))
                {
                    source = (IOperationSource<T>)(new ManagementLockOperationSource(Client));
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Not expected generic type: {genericType}");
                }
                var operation = new ResourcesArmOperation<T>(source, clientDiagnostics, Pipeline, Id);
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

        // <summary> Rehydrate an LRO. </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public override ArmOperation<T> Rehydrate(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ContainerService", "Microsoft.ContainerService", Diagnostics);
            using var scope = clientDiagnostics.CreateScope("ContainerServiceArmOperationRehydration.Rehydrate");
            scope.Start();
            try
            {
                Type genericType = typeof(T);
                IOperationSource<T> source;
                if (genericType == typeof(GenericResource))
                {
                    source = (IOperationSource<T>)(new GenericResourceOperationSource(Client));
                }
                else if (genericType == typeof(ResourceGroupExportResult))
                {
                    source = (IOperationSource<T>)(new ResourceGroupExportResultOperationSource());
                }
                else if (genericType == typeof(ResourceGroupResource))
                {
                    source = (IOperationSource<T>)(new ResourceGroupOperationSource(Client));
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Not expected generic type: {genericType}");
                }
                var operation = new ResourcesArmOperation<T>(source, clientDiagnostics, Pipeline, Id);
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
    }
}
