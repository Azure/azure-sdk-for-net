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
        public static void Reimage(this IVirtualMachineScaleSetVMsOperations operations, string resourceGroupName, string vmScaleSetName, string instanceId, bool? tempDisk)
        {
            operations.ReimageAsync(resourceGroupName, vmScaleSetName, instanceId, tempDisk).GetAwaiter().GetResult();
        }

        public static async Task ReimageAsync(this IVirtualMachineScaleSetVMsOperations operations, string resourceGroupName, string vmScaleSetName, string instanceId, bool? tempDisk, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.ReimageWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, instanceId, tempDisk, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

        public static void BeginReimage(this IVirtualMachineScaleSetVMsOperations operations, string resourceGroupName, string vmScaleSetName, string instanceId, bool? tempDisk)
        {
            operations.BeginReimageAsync(resourceGroupName, vmScaleSetName, instanceId, tempDisk).GetAwaiter().GetResult();
        }

        public static async Task BeginReimageAsync(this IVirtualMachineScaleSetVMsOperations operations, string resourceGroupName, string vmScaleSetName, string instanceId, bool? tempDisk, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.BeginReimageWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, instanceId, tempDisk, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

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
