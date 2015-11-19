// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Provides helper extension methods for the Management Poco Client.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "IHD",
        Justification = "Correct casing for circumstance and to match Interface name. [TGS]")]
    internal static class IHDInsightManagementPocoClientExtensions
    {
        /// <summary>
        /// Waits for a condition to be satisfied.
        /// </summary>
        /// <typeparam name="T">
        /// The changeType of object that will be operated on.
        /// </typeparam>
        /// <param name="client">
        /// The client instance this is extending.
        /// </param>
        /// <param name="poll">
        /// The function to poll the client for state.
        /// </param>
        /// <param name="continuePolling">
        /// A function to evaluate the state to see if it matches the condition.
        /// </param>
        /// <param name="notifyHandler">
        /// A notification handler used to rais events when the status changes.
        /// </param>
        /// <param name="interval">
        /// A time frame to wait between polls.
        /// </param>
        /// <param name="timeout">
        /// The amount of time to wait for the condition to be satisfied.
        /// </param>
        /// <param name="cancellationToken">
        /// A Cancelation Token that can be used to cancel the request.
        /// </param>
        /// <returns>
        /// An awaitable task.
        /// </returns>
        public static async Task WaitForCondition<T>(this IHDInsightManagementPocoClient client, Func<Task<T>> poll, Func<T, PollResult> continuePolling, Action<T> notifyHandler, TimeSpan interval, TimeSpan timeout, CancellationToken cancellationToken)
        {
            client.ArgumentNotNull("client");
            poll.ArgumentNotNull("poll");
            continuePolling.ArgumentNotNull("continuePolling");
            var start = DateTime.Now;
            int pollingFailures = 0;
            const int MaxPollingFailuresCount = 10;
            T pollingResult = default(T);
            PollResult result = PollResult.Continue;
            do
            {
                try
                {
                    pollingResult = await poll();
                    result = continuePolling(pollingResult);
                    if (notifyHandler.IsNotNull() && pollingResult.IsNotNull())
                    {
                        notifyHandler(pollingResult);
                    }
                    if (result == PollResult.Unknown || result == PollResult.Null)
                    {
                        pollingFailures++;
                        if (result == PollResult.Null)
                        {
                            client.LogMessage("Poll for cluster returned no cluster.  Current error weight (out of 10): " + pollingFailures.ToString(CultureInfo.InvariantCulture),
                                              Severity.Informational,
                                              Verbosity.Diagnostic);
                        }
                        cancellationToken.WaitForInterval(interval);
                    }
                    else if (result == PollResult.Continue)
                    {
                        pollingFailures = 0;
                        cancellationToken.WaitForInterval(interval);
                    }
                }
                catch (Exception ex)
                {
                    ex = ex.GetFirstException();
                    var hlex = ex as HttpLayerException;
                    var httpEx = ex as HttpRequestException;
                    var webex = ex as WebException;
                    var timeOut = ex as TimeoutException;
                    var taskCancled = ex as TaskCanceledException;
                    var operationCanceled = ex as OperationCanceledException;
                    if (taskCancled.IsNotNull() && taskCancled.CancellationToken.IsNotNull() && taskCancled.CancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                    if (operationCanceled.IsNotNull() && operationCanceled.CancellationToken.IsNotNull() && operationCanceled.CancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                    if (hlex.IsNotNull() || httpEx.IsNotNull() || webex.IsNotNull() || taskCancled.IsNotNull() || timeOut.IsNotNull() || operationCanceled.IsNotNull())
                    {
                        pollingFailures += 5;
                        client.LogMessage("Poll for cluster a manageable exception.  Current error weight (out of 10): " + pollingFailures.ToString(CultureInfo.InvariantCulture),
                                          Severity.Informational,
                                          Verbosity.Diagnostic);
                        client.LogMessage(ex.ToString(), Severity.Informational, Verbosity.Diagnostic);
                        if (pollingFailures >= MaxPollingFailuresCount)
                        {
                            client.LogMessage("Polling error weight exceeded maximum allowed.  Aborting operation.", Severity.Error, Verbosity.Normal);
                            throw;
                        }
                    }
                    else
                    {
                        client.LogMessage("Poll for cluster returned an unmanageable exception.  Aborting operation.", Severity.Error, Verbosity.Normal);
                        client.LogException(ex);
                        throw;
                    }
                }
            }
            while ((result == PollResult.Continue || result == PollResult.Null || result == PollResult.Unknown) &&
                   DateTime.Now - start < timeout &&
                   pollingFailures <= MaxPollingFailuresCount);
            if (pollingFailures > MaxPollingFailuresCount)
            {
                client.LogMessage("Polling error weight exceeded maximum allowed.  Aborting operation.", Severity.Error, Verbosity.Normal);
            }
            if (notifyHandler.IsNotNull() && pollingResult.IsNotNull())
            {
                notifyHandler(pollingResult);
            }
        }

        /// <summary>
        /// Waits for the cluster to not exist (null) or go into an error state.
        /// </summary>
        /// <param name="client">
        /// The client instance this is extending.
        /// </param>
        /// <param name="dnsName">
        /// The dnsName of the cluster.
        /// </param>
        /// <param name="location">The location of the cluster.</param>
        /// <param name="timeout">
        /// The amount of time to wait for the condition to be satisfied.
        /// </param>
        /// <param name="cancellationToken">
        /// A Cancelation Token that can be used to cancel the request.
        /// </param>
        /// <returns>
        /// An awaitable task.
        /// </returns>
        public static async Task WaitForClusterNullOrError(this IHDInsightManagementPocoClient client, string dnsName, string location, TimeSpan timeout, CancellationToken cancellationToken)
        {
            await client.WaitForCondition(() => client.ListContainer(dnsName, location), c => c == null ? PollResult.Stop : c.Error != null ? PollResult.Stop : PollResult.Continue, null, TimeSpan.FromMilliseconds(100), timeout, cancellationToken);
        }

        /// <summary>
        /// Waits for the cluster to not exist (null).
        /// </summary>
        /// <param name="client">The client instance this is extending.</param>
        /// <param name="dnsName">The dnsName of the cluster.</param>
        /// <param name="timeout">The amount of time to wait for the condition to be satisfied.</param>
        /// <param name="pollInterval">The poll interval.</param>
        /// <param name="cancellationToken">A Cancelation Token that can be used to cancel the request.</param>
        /// <returns>
        /// An awaitable task.
        /// </returns>
        public static async Task WaitForClusterNull(this IHDInsightManagementPocoClient client, string dnsName, TimeSpan timeout, TimeSpan pollInterval, CancellationToken cancellationToken)
        {
            await client.WaitForCondition(() => client.ListContainer(dnsName), c => c == null ? PollResult.Stop : PollResult.Continue, null, pollInterval, timeout, cancellationToken);
        }

        /// <summary>
        /// Waits for the cluster to not exist (null).
        /// </summary>
        /// <param name="client">
        /// The client instance this is extending.
        /// </param>
        /// <param name="dnsName">
        /// The dnsName of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        /// <param name="timeout">
        /// The amount of time to wait for the condition to be satisfied.
        /// </param>
        /// <param name="cancellationToken">
        /// A Cancelation Token that can be used to cancel the request.
        /// </param>
        /// <returns>
        /// An awaitable task.
        /// </returns>
        public static async Task WaitForClusterNull(this IHDInsightManagementPocoClient client, string dnsName, string location, TimeSpan timeout, CancellationToken cancellationToken)
        {
            await client.WaitForCondition(() => client.ListContainer(dnsName, location), c => c == null ? PollResult.Stop : PollResult.Continue, null, TimeSpan.FromMilliseconds(100), timeout, cancellationToken);
        }

        /// <summary>
        /// Waits for the cluster to not exist (null). Doesnt work when this overload is called and there are two cluster
        /// with same names. Please call the overload with the location in that case.
        /// </summary>
        /// <param name="client">
        /// The client instance this is extending.
        /// </param>
        /// <param name="dnsName">
        /// The dnsName of the cluster.
        /// </param>
        /// <param name="timeout">
        /// The amount of time to wait for the condition to be satisfied.
        /// </param>
        /// <param name="cancellationToken">
        /// A Cancelation Token that can be used to cancel the request.
        /// </param>
        /// <returns>
        /// An awaitable task.
        /// </returns>
        public static async Task WaitForClusterNull(this IHDInsightManagementPocoClient client, string dnsName, TimeSpan timeout, CancellationToken cancellationToken)
        {
            await client.WaitForCondition(() => client.ListContainer(dnsName), c => c == null ? PollResult.Stop : PollResult.Continue, null, TimeSpan.FromSeconds(15), timeout, cancellationToken);
        }

        /// <summary>
        /// Waits for the cluster to exist (!null).
        /// </summary>
        /// <param name="client">
        /// The client instance this is extending.
        /// </param>
        /// <param name="dnsName">
        /// The dnsName of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        /// <param name="timeout">
        /// The amount of time to wait for the condition to be satisfied.
        /// </param>
        /// <param name="cancellationToken">
        /// A Cancelation Token that can be used to cancel the request.
        /// </param>
        /// <returns>
        /// An awaitable task.
        /// </returns>
        public static async Task WaitForClusterNotNull(this IHDInsightManagementPocoClient client, string dnsName, string location, TimeSpan timeout, CancellationToken cancellationToken)
        {
            await client.WaitForCondition(() => client.ListContainer(dnsName, location), c => c != null ? PollResult.Stop : PollResult.Continue, null, TimeSpan.FromMilliseconds(100), timeout, cancellationToken);
        }

        /// <summary>
        /// Waits for the cluster to not exist (null) or go into an error state or be in one of the listed states.
        /// </summary>
        /// <param name="client">
        /// The client instance this is extending.
        /// </param>
        /// <param name="notifyHandler">
        /// A notification handler used to notify when the state changes.
        /// </param>
        /// <param name="dnsName">
        /// The dnsName of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        /// <param name="timeout">
        /// The amount of time to wait for the condition to be satisfied.
        /// </param>
        /// <param name="interval">
        /// A time frame to wait between polls.
        /// </param>
        /// <param name="context">
        /// A Cancelation Token that can be used to cancel the request.
        /// </param>
        /// <param name="states">
        /// The set of states that would cause this funciton to terminate.
        /// </param>
        /// <returns>
        /// An awaitable task.
        /// </returns>
        public static async Task WaitForClusterInConditionOrError(this IHDInsightManagementPocoClient client, Action<ClusterDetails> notifyHandler, string dnsName, string location, TimeSpan timeout, TimeSpan interval, IAbstractionContext context, params ClusterState[] states)
        {
            await client.WaitForCondition(() => client.ListContainer(dnsName, location), c => client.PollSignal(c, states), notifyHandler, interval, timeout, context.CancellationToken);
        }

        internal enum PollResult
        {
            Continue,
            Unknown,
            Null,
            Stop
        }

        /// <summary>
        /// Poll Signal that is triggered on every poll for the cluster condition.
        /// </summary>
        /// <param name="client">
        /// The client instance this is extending.
        /// </param>
        /// <param name="cluster">HDInsight cluster.</param>
        /// <param name="states">Acceptable states at which the polling can stop.</param>
        /// <returns>True, if we want polling to continue, false otherwise.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
            MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.LogProviderExtensions.LogMessage(Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogProvider,System.String,Microsoft.WindowsAzure.Management.HDInsight.Logging.Severity,Microsoft.WindowsAzure.Management.HDInsight.Logging.Verbosity)",
            Justification = "This is for logging the literal is acceptable. [TGS]")]
        internal static PollResult PollSignal(this IHDInsightManagementPocoClient client, ClusterDetails cluster, params ClusterState[] states)
        {
            if (cluster == null)
            {
                client.LogMessage("Polling for cluster returned null.  Returning null to polling function for retry logic.", Severity.Informational, Verbosity.Diagnostic);
                return PollResult.Null;
            }
            PollResult retval = PollResult.Continue;

            client.RaiseClusterProvisioningEvent(client, new ClusterProvisioningStatusEventArgs(cluster, cluster.State));
            var msg = string.Format(CultureInfo.CurrentCulture, "Current State {0} -> waiting for one state of {1}", cluster.State, string.Join(",", states.Select(s => s.ToString())));
            client.LogMessage(msg, Severity.Informational, Verbosity.Diagnostic);

            if (cluster.State == ClusterState.Error)
            {
                client.LogMessage("Stopping Poll because cluster state was in Error", Severity.Error, Verbosity.Normal);
                retval = PollResult.Stop;
            }
            else if (cluster.Error != null)
            {
                msg = string.Format(CultureInfo.CurrentCulture, "Stopping Poll because cluster returned an error message.  The message was: {0}", cluster.Error);
                client.LogMessage(msg, Severity.Error, Verbosity.Normal);
                retval = PollResult.Stop;
            }
            else if (states.Contains(cluster.State))
            {
                msg = string.Format(CultureInfo.CurrentCulture, "Stopping Poll because cluster returned in a final state.  The message was: {0}", cluster.State);
                client.LogMessage(msg, Severity.Informational, Verbosity.Diagnostic);
                retval = PollResult.Stop;
            }
            else if (cluster.State == ClusterState.Unknown)
            {
                retval = PollResult.Unknown;
            }
            msg = string.Format(CultureInfo.CurrentCulture, "Continue function determined a poll result of: {0}", retval);
            client.LogMessage(msg, Severity.Informational, Verbosity.Diagnostic);
            return retval;
        }

        /// <summary>
        /// Waits for an operation on the cluster to complete.
        /// </summary>
        /// <param name="client">
        /// The client instance this is extending.
        /// </param>
        /// <param name="dnsName">
        /// The dnsName of the cluster.
        /// </param>
        /// <param name="location">
        /// The location of the cluster.
        /// </param>
        /// <param name="operation">
        /// The operation Id to check.
        /// </param>
        /// <param name="timeout">
        /// The amount of time to wait for the condition to be satisfied.
        /// </param>
        /// <param name="cancellationToken">
        /// A Cancelation Token that can be used to cancel the request.
        /// </param>
        /// <returns>
        /// An awaitable task.
        /// </returns>
        public static async Task WaitForOperationCompleteOrError(this IHDInsightManagementPocoClient client, string dnsName, string location, Guid operation,TimeSpan pollingInterval, TimeSpan timeout, CancellationToken cancellationToken)
        {
            await client.WaitForCondition(() => client.GetStatus(dnsName, location, operation), s => s.State == UserChangeRequestOperationStatus.Pending ? PollResult.Continue : PollResult.Stop, null, pollingInterval, timeout, cancellationToken);
        }

        public static async Task WaitForRdfeOperationToComplete(this IHDInsightManagementPocoClient client, Guid operationId, TimeSpan pollingInterval, TimeSpan timeout, CancellationToken cancellationToken)
        {
            await client.WaitForCondition(() => client.GetRdfeOperationStatus(operationId), x => (x.Status == Data.Rdfe.OperationStatus.InProgress) ? PollResult.Continue : PollResult.Stop, null, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(5), cancellationToken);
        }
    }
}
