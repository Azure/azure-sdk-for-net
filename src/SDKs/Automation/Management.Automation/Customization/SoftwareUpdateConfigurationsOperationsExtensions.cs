namespace Microsoft.Azure.Management.Automation
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.Management.Automation.Models;
    using System;

    /// <summary>
    /// Extension methods for SoftwareUpdateConfigurationRunsOperations.
    /// </summary>
    public static partial class SoftwareUpdateConfigurationsOperationsExtensions
    {
        private const string AzureVirtualMachinesProperty = "updateConfiguration/azureVirtualMachines";
        private const string LambdaFilterFormat = "properties/{0}/any(m: m eq '{1}')";

        /// <summary>
        /// Return list of software update configurations targetting the given virtual machine
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='virtualMachineId'>
        /// Azure resource manager Id of the virtual machine
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationListResult ListByAzureVirtualMachine(this ISoftwareUpdateConfigurationsOperations operations, string virtualMachineId)
        {
            return operations.ListByAzureVirtualMachineAsync(virtualMachineId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Return list of software update configurations targetting the given virtual machine
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='virtualMachineId'>
        /// Azure resource manager Id of the virtual machine
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<SoftwareUpdateConfigurationListResult> ListByAzureVirtualMachineAsync(this ISoftwareUpdateConfigurationsOperations operations, string virtualMachineId, string skip = default(string), string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = string.Format(LambdaFilterFormat, AzureVirtualMachinesProperty, virtualMachineId);
            using (var _result = await operations.ListWithHttpMessagesAsync(filter, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
