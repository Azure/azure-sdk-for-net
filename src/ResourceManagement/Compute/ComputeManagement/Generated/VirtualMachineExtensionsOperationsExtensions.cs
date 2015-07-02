namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    public static partial class VirtualMachineExtensionsOperationsExtensions
    {
            /// <summary>
            /// The operation to create or update the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine where the extension should be create or
            /// updated.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            /// <param name='extensionParameters'>
            /// Parameters supplied to the Create Virtual Machine Extension operation.
            /// </param>
            public static VirtualMachineExtension CreateOrUpdate(this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtension extensionParameters)
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineExtensionsOperations)s).CreateOrUpdateAsync(resourceGroupName, vmName, vmExtensionName, extensionParameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to create or update the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine where the extension should be create or
            /// updated.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            /// <param name='extensionParameters'>
            /// Parameters supplied to the Create Virtual Machine Extension operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualMachineExtension> CreateOrUpdateAsync( this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtension extensionParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineExtension> result = await operations.CreateOrUpdateWithOperationResponseAsync(resourceGroupName, vmName, vmExtensionName, extensionParameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The operation to create or update the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine where the extension should be create or
            /// updated.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            /// <param name='extensionParameters'>
            /// Parameters supplied to the Create Virtual Machine Extension operation.
            /// </param>
            public static VirtualMachineExtension BeginCreateOrUpdate(this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtension extensionParameters)
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineExtensionsOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, vmName, vmExtensionName, extensionParameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to create or update the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine where the extension should be create or
            /// updated.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            /// <param name='extensionParameters'>
            /// Parameters supplied to the Create Virtual Machine Extension operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualMachineExtension> BeginCreateOrUpdateAsync( this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtension extensionParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineExtension> result = await operations.BeginCreateOrUpdateWithOperationResponseAsync(resourceGroupName, vmName, vmExtensionName, extensionParameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The operation to delete the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine where the extension should be deleted.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            public static void Delete(this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName)
            {
                Task.Factory.StartNew(s => ((IVirtualMachineExtensionsOperations)s).DeleteAsync(resourceGroupName, vmName, vmExtensionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to delete the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine where the extension should be deleted.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithOperationResponseAsync(resourceGroupName, vmName, vmExtensionName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The operation to delete the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine where the extension should be deleted.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            public static void BeginDelete(this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName)
            {
                Task.Factory.StartNew(s => ((IVirtualMachineExtensionsOperations)s).BeginDeleteAsync(resourceGroupName, vmName, vmExtensionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to delete the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine where the extension should be deleted.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync( this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithOperationResponseAsync(resourceGroupName, vmName, vmExtensionName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The operation to get the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine containing the extension.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            /// <param name='expand'>
            /// Name of the property to expand. Allowed value is null or 'instanceView'.
            /// </param>
            public static VirtualMachineExtension Get(this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName, string expand = default(string))
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineExtensionsOperations)s).GetAsync(resourceGroupName, vmName, vmExtensionName, expand), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to get the extension.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine containing the extension.
            /// </param>
            /// <param name='vmExtensionName'>
            /// The name of the virtual machine extension.
            /// </param>
            /// <param name='expand'>
            /// Name of the property to expand. Allowed value is null or 'instanceView'.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualMachineExtension> GetAsync( this IVirtualMachineExtensionsOperations operations, string resourceGroupName, string vmName, string vmExtensionName, string expand = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineExtension> result = await operations.GetWithOperationResponseAsync(resourceGroupName, vmName, vmExtensionName, expand, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
