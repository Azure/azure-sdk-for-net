namespace Microsoft.Azure.Management.Automation
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.Management.Automation.Models;
    using System;

    /// <summary>
    /// Extension methods for SoftwareUpdateConfigurationRunsOperations.
    /// </summary>
    public static partial class SoftwareUpdateConfigurationMachineRunsOperationsExtensions
    {
        private const string StatusProperty = "status";
        private const string CorrelationIdProperty = "correlationId";
        private const string TargetComputerProperty = "targetComputer";
        private const string FilterFormatEqual = "properties/{0} eq {1}";
        private const string FilterFormatStringEqual = "properties/{0} eq '{1}'";

        #region status filtering
        /// <summary>
        /// Return list of software update configuration machine runs with the given the status
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='status'>
        /// status of the machine run
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationMachineRunListResult ListByStatus(this ISoftwareUpdateConfigurationMachineRunsOperations operations, string status, string skip = default(string), string top = default(string))
        {
            return operations.ListByStatusAsync(status, skip, top).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Return list of software update configuration machine runs with the given the status
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='status'>
        /// Status of the machine run
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
        public static async Task<SoftwareUpdateConfigurationMachineRunListResult> ListByStatusAsync(this ISoftwareUpdateConfigurationMachineRunsOperations operations, string status, string skip = default(string), string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = string.Format(FilterFormatStringEqual, StatusProperty, status);
            using (var _result = await operations.ListWithHttpMessagesAsync(filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        #region correlationId filtering
        /// <summary>
        /// Return list of software update configuration machine runs corresponding to the software update configuration run with the given correlation id
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='correlationId'>
        /// Id of the parent software update configuration run
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationMachineRunListResult ListByCorrelationId(this ISoftwareUpdateConfigurationMachineRunsOperations operations, Guid correlationId, string skip = default(string), string top = default(string))
        {
            return operations.ListByCorrelationIdAsync(correlationId, skip, top).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Return list of software update configuration machine runs corresponding to the software update configuration run with the given correlation id
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='correlationId'>
        /// Id of the parent software update configuration run
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
        public static async Task<SoftwareUpdateConfigurationMachineRunListResult> ListByCorrelationIdAsync(this ISoftwareUpdateConfigurationMachineRunsOperations operations, Guid correlationId, string skip = default(string), string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = string.Format(FilterFormatEqual, CorrelationIdProperty, correlationId);
            using (var _result = await operations.ListWithHttpMessagesAsync(filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        #region targetComputer filtering
        /// <summary>
        /// Return list of software update configuration machine runs targeting the given computer
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='targetComputer'>
        /// The computer targeted by this machine run
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationMachineRunListResult ListByTargetComputer(this ISoftwareUpdateConfigurationMachineRunsOperations operations, string osType, string skip = default(string), string top = default(string))
        {
            return operations.ListByTargetComputerAsync(osType, skip, top).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Return list of software update configuration machine runs targeting the given computer
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='targetComputer'>
        /// The computer targeted by this machine run
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
        public static async Task<SoftwareUpdateConfigurationMachineRunListResult> ListByTargetComputerAsync(this ISoftwareUpdateConfigurationMachineRunsOperations operations, string targetComputer, string skip = default(string), string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = string.Format(FilterFormatStringEqual, TargetComputerProperty, targetComputer);
            using (var _result = await operations.ListWithHttpMessagesAsync(filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion
    }
}
