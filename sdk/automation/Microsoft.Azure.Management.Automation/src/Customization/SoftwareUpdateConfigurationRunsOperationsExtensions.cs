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
    public static partial class SoftwareUpdateConfigurationRunsOperationsExtensions
    {
        private const string ConfigurationNameProperty = "softwareUpdateConfiguration/name";
        private const string OsTypeProperty = "osType";
        private const string StatusProperty = "status";
        private const string StartTimeProperty = "startTime";
        private const string FilterFormatStringEqual = "properties/{0} eq '{1}'";
        private const string FilterFormatGreaterEqual = "properties/{0} ge {1}";    // No commas in {1} is intentional!

        #region configurationName filtering
        /// <summary>
        /// Return list of software update configuration runs triggered by the software update configuration with the given name
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='configurationName'>
        /// Name of the software update configuration triggered this run
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationRunListResult ListByConfigurationName(
            this ISoftwareUpdateConfigurationRunsOperations operations,
            string resourceGroupName, string automationAccountName, string configurationName,
            string clientRequestId = default(string), string skip = default(string), string top = default(string))
        {
            return operations.ListByConfigurationNameAsync(resourceGroupName, automationAccountName, configurationName, clientRequestId, skip, top).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Return list of software update configuration runs triggered by the software update configuration with the given name
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='configurationName'>
        /// Name of the software update configuration triggered this run
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
        public static async Task<SoftwareUpdateConfigurationRunListResult> ListByConfigurationNameAsync(
            this ISoftwareUpdateConfigurationRunsOperations operations,
            string resourceGroupName, string automationAccountName, string configurationName,
            string clientRequestId = default(string), string skip = default(string), string top = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = GetConfigurationNameFilter(configurationName);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, automationAccountName, clientRequestId, filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        #region osType filtering
        /// <summary>
        /// Return list of software update configuration runs triggered by the software update configuration with the given name
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='osType'>
        /// Operating system type
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationRunListResult ListByOsType(
            this ISoftwareUpdateConfigurationRunsOperations operations,
            string resourceGroupName, string automationAccountName, string osType,
            string clientRequestId = default(string), string skip = default(string), string top = default(string))
        {
            return operations.ListByOsTypeAsync(resourceGroupName, automationAccountName, osType, clientRequestId, skip, top).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Return list of software update configuration runs triggered by the software update configuration with the given name
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='osType'>
        /// Operating system type
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
        public static async Task<SoftwareUpdateConfigurationRunListResult> ListByOsTypeAsync(
            this ISoftwareUpdateConfigurationRunsOperations operations,
            string resourceGroupName, string automationAccountName, string osType,
            string clientRequestId = default(string), string skip = default(string), string top = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = GetOsTypeFilter(osType);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, automationAccountName, clientRequestId, filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        #region status filtering
        /// <summary>
        /// Return list of software update configuration runs triggered by the software update configuration with the given name
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='status'>
        /// status of the run
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationRunListResult ListByStatus(
            this ISoftwareUpdateConfigurationRunsOperations operations,
            string resourceGroupName, string automationAccountName, string status,
            string clientRequestId = default(string), string skip = default(string), string top = default(string))
        {
            return operations.ListByStatusAsync(resourceGroupName, automationAccountName, status, clientRequestId, skip, top).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Return list of software update configuration runs triggered by the software update configuration with the given name
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='status'>
        /// Status of the run
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
        public static async Task<SoftwareUpdateConfigurationRunListResult> ListByStatusAsync(
            this ISoftwareUpdateConfigurationRunsOperations operations,
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

        #region startTime filtering
        /// <summary>
        /// Return list of software update configuration runs started at or after the given time
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='startTime'>
        /// start time of the run
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationRunListResult ListByStartTime(
            this ISoftwareUpdateConfigurationRunsOperations operations,
            string resourceGroupName, string automationAccountName, DateTime startTime,
            string clientRequestId = default(string), string skip = default(string), string top = default(string))
        {
            return operations.ListByStartTimeAsync(resourceGroupName, automationAccountName, startTime, clientRequestId, skip, top).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Return list of software update configuration runs started at or after the given time
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='startTime'>
        /// Start time
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
        public static async Task<SoftwareUpdateConfigurationRunListResult> ListByStartTimeAsync(
            this ISoftwareUpdateConfigurationRunsOperations operations,
            string resourceGroupName, string automationAccountName, DateTime startTime,
            string clientRequestId = default(string), string skip = default(string), string top = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = GetStartTimeFilter(startTime);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, automationAccountName, clientRequestId, filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        #region all filters

        /// <summary>
        /// Return list of software update configuration runs started at or after the given time
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='configurationName'>
        /// Name of the software update configuration triggered this run
        /// </param>
        /// <param name='osType'>
        /// Operating system type
        /// </param>
        /// <param name='status'>
        /// status of the run
        /// </param>
        /// <param name='startTime'>
        /// start time of the run
        /// </param>
        /// <param name='skip'>
        /// number of entries you skip before returning results
        /// </param>
        /// <param name='top'>
        /// Maximum number of entries returned in the results collection
        /// </param>
        public static SoftwareUpdateConfigurationRunListResult ListAll(
            this ISoftwareUpdateConfigurationRunsOperations operations,
            string resourceGroupName, string automationAccountName,
            string configurationName = null, string osType = null, string status = null, DateTime? startTime = null,
            string clientRequestId = default(string), string skip = default(string), string top = default(string))
        {
            return operations.ListAllAsync(resourceGroupName, automationAccountName, configurationName, osType, status, startTime, clientRequestId, skip, top).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Return list of software update configuration runs started at or after the given time
        /// <see href="http://aka.ms/azureautomationsdk/softwareupdateconfigurationoperations" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='configurationName'>
        /// Name of the software update configuration triggered this run
        /// </param>
        /// <param name='osType'>
        /// Operating system type
        /// </param>
        /// <param name='status'>
        /// status of the run
        /// </param>
        /// <param name='startTime'>
        /// start time of the run
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
        public static async Task<SoftwareUpdateConfigurationRunListResult> ListAllAsync(
            this ISoftwareUpdateConfigurationRunsOperations operations,
            string resourceGroupName, string automationAccountName,
            string configurationName = null, string osType = null, string status = null, DateTime? startTime = null,
            string clientRequestId = default(string), string skip = default(string), string top = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = GetCombinedFilters(configurationName, osType, status, startTime);
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, automationAccountName, clientRequestId, filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        private static string GetConfigurationNameFilter(string configurationName)
        {
            return string.IsNullOrWhiteSpace(configurationName) ? null : string.Format(FilterFormatStringEqual, ConfigurationNameProperty, configurationName);
        }

        private static string GetOsTypeFilter(string osType)
        {
            return string.IsNullOrWhiteSpace(osType) ? null : string.Format(FilterFormatStringEqual, OsTypeProperty, osType);
        }

        private static string GetStatusFilter(string status)
        {
            return string.IsNullOrWhiteSpace(status) ? null : string.Format(FilterFormatStringEqual, StatusProperty, status);
        }

        private static string GetStartTimeFilter(DateTime startTime)
        {
            return string.Format(FilterFormatGreaterEqual, StartTimeProperty, startTime.ToString("o"));
        }

        private static string GetCombinedFilters(string configurationName, string osType, string status, DateTime? startTime)
        {
            var filters = new string[] {
                string.IsNullOrWhiteSpace(configurationName) ? null : GetConfigurationNameFilter(configurationName),
                string.IsNullOrWhiteSpace(osType)            ? null : GetOsTypeFilter(osType),
                string.IsNullOrWhiteSpace(status)            ? null : GetStatusFilter(status),
                !startTime.HasValue                          ? null : GetStartTimeFilter(startTime.Value)
            };

            var filter = string.Join(" and ", filters.Where(f => !string.IsNullOrWhiteSpace(f)));
            return string.IsNullOrWhiteSpace(filter) ? null : filter;
        }
    }
}
