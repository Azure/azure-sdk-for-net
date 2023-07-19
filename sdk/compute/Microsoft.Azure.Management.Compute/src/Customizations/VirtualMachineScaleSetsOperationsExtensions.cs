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
    /// Extension methods for VirtualMachineScaleSetsOperations.
    /// </summary>
    public static partial class VirtualMachineScaleSetsOperationsExtensions
    {
        public static async Task<RecoveryWalkResponse> ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(this IVirtualMachineScaleSetsOperations operations, string resourceGroupName, string vmScaleSetName, int platformUpdateDomain, CancellationToken cancellationToken)
        {
            using (var _result = await operations.ForceRecoveryServiceFabricPlatformUpdateDomainWalkWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, platformUpdateDomain, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Display information about a virtual machine scale set.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmScaleSetName'>
        /// The name of the VM scale set.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<VirtualMachineScaleSet> GetAsync(this IVirtualMachineScaleSetsOperations operations, string resourceGroupName, string vmScaleSetName, CancellationToken cancellationToken)
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }
            
            /// <summary>
            /// Display information about a virtual machine scale set.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='vmScaleSetName'>
            /// The name of the VM scale set.
            /// </param>
            public static async Task<VirtualMachineScaleSet> GetAsync(this IVirtualMachineScaleSetsOperations operations, string resourceGroupName, string vmScaleSetName)
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, null).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }
    }
    
    
    
}
