namespace Microsoft.Azure.Management.Automation
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.Management.Automation.Models;

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
        public static SoftwareUpdateConfigurationMachineRunListResult ListByStatus(
            this ISoftwareUpdateConfigurationMachineRunsOperations operations,
            string resourceGroupName, string automationAccountName, string status,
            string clientRequestId = default(string), string skip = default(string), string top = default(string))
        {
            return operations.ListByStatusAsync(resourceGroupName, automationAccountName, status, clientRequestId, skip, top).GetAwaiter().GetResult();
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
        public static async Task<SoftwareUpdateConfigurationMachineRunListResult> ListByStatusAsync(
            this ISoftwareUpdateConfigurationMachineRunsOperations operations,
            string resourceGroupName, string automationAccountName, string status,
            string clientRequestId = default(string), string skip = default(string), string top = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = GetStatusFilter(status);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, automationAccountName, clientRequestId, filter, skip, top, null, cancellationToken).ConfigureAwait(false))
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
        public static SoftwareUpdateConfigurationMachineRunListResult ListByCorrelationId(
            this ISoftwareUpdateConfigurationMachineRunsOperations operations,
            string resourceGroupName, string automationAccountName, Guid correlationId,
            string clientRequestId = default(string), string skip = default(string), string top = default(string))
        {
            return operations.ListByCorrelationIdAsync(resourceGroupName, automationAccountName, correlationId, clientRequestId, skip, top).GetAwaiter().GetResult();
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
        public static async Task<SoftwareUpdateConfigurationMachineRunListResult> ListByCorrelationIdAsync(
            this ISoftwareUpdateConfigurationMachineRunsOperations operations,
            string resourceGroupName, string automationAccountName, Guid correlationId,
            string clientRequestId = default(string), string skip = default(string), string top = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = GetCorrelationIdFilter(correlationId);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, automationAccountName, clientRequestId, filter, skip, top, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='osType'>
        /// The computer osType targeted by this machine run
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationMachineRunListResult ListByTargetComputer(
            this ISoftwareUpdateConfigurationMachineRunsOperations operations,
            string resourceGroupName, string automationAccountName, string targetComputer,
            string clientRequestId = default(string), string skip = default(string), string top = default(string))
        {
            return operations.ListByTargetComputerAsync(resourceGroupName, automationAccountName, targetComputer, clientRequestId, skip, top).GetAwaiter().GetResult();
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
        public static async Task<SoftwareUpdateConfigurationMachineRunListResult> ListByTargetComputerAsync(
            this ISoftwareUpdateConfigurationMachineRunsOperations operations,
            string resourceGroupName, string automationAccountName, string targetComputer,
            string clientRequestId = default(string), string skip = default(string), string top = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = GetTargetComputerFilter(targetComputer);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, automationAccountName, clientRequestId, filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        #region combined filters
        /// <summary>
        /// Return list of software update configuration machine runs targeting the given computer
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='osType'>
        /// The computer osType targeted by this machine run
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationMachineRunListResult ListAll(
            this ISoftwareUpdateConfigurationMachineRunsOperations operations,
            string resourceGroupName, string automationAccountName,
            Guid? correlationId = null, string status = null, string targetComputer = null,
            string clientRequestId = default(string), string skip = default(string), string top = default(string))
        {
            return operations.ListAllAsync(resourceGroupName, automationAccountName, correlationId, status, targetComputer, clientRequestId, skip, top).GetAwaiter().GetResult();
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
        public static async Task<SoftwareUpdateConfigurationMachineRunListResult> ListAllAsync(
            this ISoftwareUpdateConfigurationMachineRunsOperations operations,
            string resourceGroupName, string automationAccountName,
            Guid? correlationId = null, string status = null, string targetComputer = null,
            string clientRequestId = default(string), string skip = default(string), string top = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = GetCombinedFilter(correlationId, status, targetComputer);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, automationAccountName, clientRequestId, filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        private static string GetStatusFilter(string status)
        {
            return string.IsNullOrWhiteSpace(status) ? null : string.Format(FilterFormatStringEqual, StatusProperty, status);
        }

        private static string GetCorrelationIdFilter(Guid correlationId)
        {
            return string.Format(FilterFormatEqual, CorrelationIdProperty, correlationId);
        }

        private static string GetTargetComputerFilter(string targetComputer)
        {
            return string.IsNullOrWhiteSpace(targetComputer) ? null : string.Format(FilterFormatStringEqual, TargetComputerProperty, targetComputer);
        }

        private static string GetCombinedFilter(Guid? correlationId = null, string status = null, string targetComputer = null)
        {
            var filters = new string[]
            {
                !correlationId.HasValue ? null : GetCorrelationIdFilter(correlationId.Value),
                string.IsNullOrWhiteSpace(status) ? null : GetStatusFilter(status),
                string.IsNullOrWhiteSpace(targetComputer) ? null : GetTargetComputerFilter(targetComputer)
            };

            var filter = string.Join(" and ", filters.Where(f => !string.IsNullOrWhiteSpace(f)));
            return string.IsNullOrWhiteSpace(filter) ? null : filter;
        }
    }
}
