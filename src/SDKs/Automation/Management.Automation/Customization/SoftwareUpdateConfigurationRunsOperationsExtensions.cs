namespace Microsoft.Azure.Management.Automation
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.Management.Automation.Models;
    using System;

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
        public static SoftwareUpdateConfigurationRunListResult ListByConfigurationName(this ISoftwareUpdateConfigurationRunsOperations operations, string configurationName, string skip = default(string), string top = default(string))
        {
            return operations.ListByConfigurationNameAsync(configurationName, skip, top).GetAwaiter().GetResult();
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
        public static async Task<SoftwareUpdateConfigurationRunListResult> ListByConfigurationNameAsync(this ISoftwareUpdateConfigurationRunsOperations operations, string configurationName, string skip = default(string), string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = string.Format(FilterFormatStringEqual, ConfigurationNameProperty, configurationName);
            using (var _result = await operations.ListWithHttpMessagesAsync(filter, skip, top, null, cancellationToken).ConfigureAwait(false))
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
        public static SoftwareUpdateConfigurationRunListResult ListByOsType(this ISoftwareUpdateConfigurationRunsOperations operations, string osType, string skip = default(string), string top = default(string))
        {
            return operations.ListByOsTypeAsync(osType, skip, top).GetAwaiter().GetResult();
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
        public static async Task<SoftwareUpdateConfigurationRunListResult> ListByOsTypeAsync(this ISoftwareUpdateConfigurationRunsOperations operations, string osType, string skip = default(string), string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = string.Format(FilterFormatStringEqual, OsTypeProperty, osType);
            using (var _result = await operations.ListWithHttpMessagesAsync(filter, skip, top, null, cancellationToken).ConfigureAwait(false))
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
        public static SoftwareUpdateConfigurationRunListResult ListByStatus(this ISoftwareUpdateConfigurationRunsOperations operations, string status, string skip = default(string), string top = default(string))
        {
            return operations.ListByStatusAsync(status, skip, top).GetAwaiter().GetResult();
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
        public static async Task<SoftwareUpdateConfigurationRunListResult> ListByStatusAsync(this ISoftwareUpdateConfigurationRunsOperations operations, string status, string skip = default(string), string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = string.Format(FilterFormatStringEqual, StatusProperty, status);
            using (var _result = await operations.ListWithHttpMessagesAsync(filter, skip, top, null, cancellationToken).ConfigureAwait(false))
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
        public static SoftwareUpdateConfigurationRunListResult ListByStartTime(this ISoftwareUpdateConfigurationRunsOperations operations, DateTime startTime, string skip = default(string), string top = default(string))
        {
            return operations.ListByStartTimeAsync(startTime, skip, top).GetAwaiter().GetResult();
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
        public static async Task<SoftwareUpdateConfigurationRunListResult> ListByStartTimeAsync(this ISoftwareUpdateConfigurationRunsOperations operations, DateTime startTime, string skip = default(string), string top = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = string.Format(FilterFormatGreaterEqual, StartTimeProperty, startTime.ToString("o"));
            using (var _result = await operations.ListWithHttpMessagesAsync(filter, skip, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion
    }
}
