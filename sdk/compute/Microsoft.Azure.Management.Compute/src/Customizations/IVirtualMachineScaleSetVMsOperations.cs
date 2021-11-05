namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// VirtualMachineScaleSetVMsOperations operations.
    /// </summary>
    public partial interface IVirtualMachineScaleSetVMsOperations
    {
    
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName, string instanceId, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken);
        
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName, string instanceId, Dictionary<string, List<string>> customHeaders);
        
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName, string instanceId, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken);
        
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName, string instanceId, Dictionary<string, List<string>> customHeaders);
    
    }
}
