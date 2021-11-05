namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for VirtualMachineScaleSetVMsOperations.
    /// </summary>
    public static partial class VirtualMachineScaleSetVMsOperationsExtensions
    {
        public static async Task DeleteAsync(this IVirtualMachineScaleSetVMsOperations operations, string resourceGroupName, string vmScaleSetName, string instanceId, CancellationToken cancellationToken)
        {
            (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, instanceId, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
            
        public static async Task BeginDeleteAsync(this IVirtualMachineScaleSetVMsOperations operations, string resourceGroupName, string vmScaleSetName, string instanceId, CancellationToken cancellationToken)
        {
            (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, instanceId, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
    }
       
}
