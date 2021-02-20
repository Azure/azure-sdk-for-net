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
