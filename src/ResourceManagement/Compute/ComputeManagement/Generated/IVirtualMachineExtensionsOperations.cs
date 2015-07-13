namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure.OData;
    using System.Linq.Expressions;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IVirtualMachineExtensionsOperations
    {
        /// <summary>
        /// The operation to create or update the extension.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine where the extension should be
        /// create or updated.
        /// </param>
        /// <param name='vmExtensionName'>
        /// The name of the virtual machine extension.
        /// </param>
        /// <param name='extensionParameters'>
        /// Parameters supplied to the Create Virtual Machine Extension
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineExtension>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtension extensionParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to create or update the extension.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine where the extension should be
        /// create or updated.
        /// </param>
        /// <param name='vmExtensionName'>
        /// The name of the virtual machine extension.
        /// </param>
        /// <param name='extensionParameters'>
        /// Parameters supplied to the Create Virtual Machine Extension
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineExtension>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string vmName, string vmExtensionName, VirtualMachineExtension extensionParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to delete the extension.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine where the extension should be
        /// deleted.
        /// </param>
        /// <param name='vmExtensionName'>
        /// The name of the virtual machine extension.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, string vmExtensionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to delete the extension.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine where the extension should be
        /// deleted.
        /// </param>
        /// <param name='vmExtensionName'>
        /// The name of the virtual machine extension.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, string vmExtensionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to get the extension.
        /// </summary>
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
        /// Name of the property to expand. Allowed value is null or
        /// 'instanceView'.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineExtension>> GetWithHttpMessagesAsync(string resourceGroupName, string vmName, string vmExtensionName, string expand = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
