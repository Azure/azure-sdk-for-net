namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for VirtualMachinesOperations.
    /// </summary>
    public static partial class VirtualMachinesOperationsExtensions
    {
        public static void Reimage(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, bool? tempDisk)
        {
            operations.ReimageAsync(resourceGroupName, vmName, tempDisk).GetAwaiter().GetResult();
        }

        public static async Task ReimageAsync(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, bool? tempDisk, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.ReimageWithHttpMessagesAsync(resourceGroupName, vmName, tempDisk, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

        public static void BeginReimage(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, bool? tempDisk)
        {
            operations.BeginReimageAsync(resourceGroupName, vmName, tempDisk).GetAwaiter().GetResult();
        }

        public static async Task BeginReimageAsync(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, bool? tempDisk, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.BeginReimageWithHttpMessagesAsync(resourceGroupName, vmName, tempDisk, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

        public static async Task<IPage<VirtualMachine>> ListAsync(this IVirtualMachinesOperations operations, string resourceGroupName, CancellationToken cancellationToken)
        {
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        public static async Task<IPage<VirtualMachine>> ListAllAsync(this IVirtualMachinesOperations operations, string statusOnly, CancellationToken cancellationToken)
        {
            using (var _result = await operations.ListAllWithHttpMessagesAsync(statusOnly, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        public static async Task DeleteAsync(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName)
        {
            await DeleteAsync(operations, resourceGroupName, vmName, false, default(CancellationToken));
        }

        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task DeleteAsync(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, CancellationToken cancellationToken)
        {
            await DeleteAsync(operations, resourceGroupName, vmName, false, cancellationToken);
        }

        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        public static async Task BeginDeleteAsync(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName)
        {
            await BeginDeleteAsync(operations, resourceGroupName, vmName, false, default(CancellationToken));
        }

        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task BeginDeleteAsync(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, CancellationToken cancellationToken)
        {
            await BeginDeleteAsync(operations, resourceGroupName, vmName, false, cancellationToken);
        }
    }
}
