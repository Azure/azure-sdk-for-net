// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace Microsoft.AzureStack.AzureConsistentStorage
{
    public static partial class FarmOperationsExtensions
    {
        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.AzureStack.AzureConsistentStorage.IFarmOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. Your documentation here.
        /// </param>
        /// <param name='farmId'>
        /// Required. Your documentation here.
        /// </param>
        /// <param name="startTimeUtc">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="endTimeUtc">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="computerName">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name='resourceUri'>
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="providerGuid">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="eventIds">
        /// Optional. Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        public static IEnumerable<EventModel> ExecuteEventQuery(
            this IFarmOperations operations,
            string resourceGroupName,
            string farmId,
            DateTime startTimeUtc,
            DateTime endTimeUtc,
            string computerName,
            Uri resourceUri,
            Guid? providerGuid,
            IEnumerable<int> eventIds
        )
        {
            return ExecuteEventQuery(
                operations, resourceGroupName, farmId, startTimeUtc, endTimeUtc, computerName, resourceUri, providerGuid, eventIds);
        }

        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.AzureStack.AzureConsistentStorage.IFarmOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. Your documentation here.
        /// </param>
        /// <param name='farmId'>
        /// Required. Your documentation here.
        /// </param>
        /// <param name="startTimeUtc">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="endTimeUtc">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="computerName">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name='resourceUri'>
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="providerGuid">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="eventIds">
        /// Optional. Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        public static IEnumerable<EventModel> ExecuteEventQuery(
            this IFarmOperations operations,
            string resourceGroupName,
            string farmId,
            DateTime startTimeUtc,
            DateTime endTimeUtc,
            string computerName,
            string resourceUri,
            Guid? providerGuid,
            IEnumerable<int> eventIds
        )
        {
            return operations.ExecuteEventQuery(
                resourceGroupName, farmId, startTimeUtc, endTimeUtc, computerName, resourceUri, providerGuid, eventIds);
        }

        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.AzureStack.AzureConsistentStorage.IFarmOperations.
        /// </param>
        /// <param name="eventQuery">
        /// Required. Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        public static IEnumerable<EventModel> ExecuteEventQuery(
            this IFarmOperations operations,
            EventQuery eventQuery)
        {
            return operations.ExecuteEventQuery(eventQuery);
        }

        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.AzureStack.AzureConsistentStorage.IFarmOperations.
        /// </param>
        /// <param name="eventQuery">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="continuationToken">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="maxCount">
        /// Optional. Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        public static EventListResponse ExecuteEventQuerySegmented(
            this IFarmOperations operations,
            EventQuery eventQuery,
            EventQueryContinuationToken continuationToken,
            int? maxCount)
        {
            return operations.ExecuteEventQuerySegmented(eventQuery, continuationToken, maxCount);
        }

        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.AzureStack.AzureConsistentStorage.IFarmOperations.
        /// </param>
        /// <param name="eventQuery">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="continuationToken">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="maxCount">
        /// Optional. Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        public static Task<EventListResponse> ExecuteEventQuerySegmentedAsync(
            this IFarmOperations operations,
            EventQuery eventQuery,
            EventQueryContinuationToken continuationToken,
            int? maxCount)
        {
            return operations.ExecuteEventQuerySegmentedAsync(eventQuery, continuationToken, maxCount, CancellationToken.None);
        }
    }

    /// <summary>
    /// Your documentation here.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXX.aspx for
    /// more information)
    /// </summary>
    public partial interface IFarmOperations
    {
        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name="eventQuery">
        /// Your documentation here.
        /// </param>
        /// <param name="continuationToken">
        /// Your documentation here.
        /// </param>
        /// <param name="maxCount">
        /// Your documentation here.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        Task<EventListResponse> ExecuteEventQuerySegmentedAsync(
           EventQuery eventQuery,
           EventQueryContinuationToken continuationToken,
           int? maxCount,
           CancellationToken cancellationToken);

        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name="eventQuery">
        /// Your documentation here.
        /// </param>
        /// <param name="continuationToken">
        /// Your documentation here.
        /// </param>
        /// <param name="maxCount">
        /// Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        EventListResponse ExecuteEventQuerySegmented(
           EventQuery eventQuery,
           EventQueryContinuationToken continuationToken,
           int? maxCount);

        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name="eventQuery">
        /// Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        IEnumerable<EventModel> ExecuteEventQuery(
            EventQuery eventQuery);


        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Your documentation here.
        /// </param>
        /// <param name='farmId'>
        /// Your documentation here.
        /// </param>
        /// <param name="startTimeUtc">
        /// Your documentation here.
        /// </param>
        /// <param name="endTimeUtc">
        /// Your documentation here.
        /// </param>
        /// <param name="computerName">
        /// Your documentation here.
        /// </param>
        /// <param name="resourceUri">
        /// Your documentation here.
        /// </param>
        /// <param name="providerGuid">
        /// Your documentation here.
        /// </param>
        /// <param name="eventIds">
        /// Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        IEnumerable<EventModel> ExecuteEventQuery(
             string resourceGroupName,
             string farmId,
             DateTime startTimeUtc,
             DateTime endTimeUtc,
             string computerName,
             string resourceUri,
             Guid? providerGuid,
             IEnumerable<int> eventIds);
    }

    /// <summary>
    /// Your documentation here.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXX.aspx for
    /// more information)
    /// </summary>
    internal partial class FarmOperations
    {
        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. Your documentation here.
        /// </param>
        /// <param name='farmId'>
        /// Required. Your documentation here.
        /// </param>
        /// <param name="startTimeUtc">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="endTimeUtc">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="computerName">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="resourceUri">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="providerGuid">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="eventIds">
        /// Optional. Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        public IEnumerable<EventModel> ExecuteEventQuery(
            string resourceGroupName,
            string farmId,
            DateTime startTimeUtc,
            DateTime endTimeUtc,
            string computerName,
            string resourceUri,
            Guid? providerGuid,
            IEnumerable<int> eventIds)
        { 
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceGroupName != null && resourceGroupName.Length > 1000)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (Regex.IsMatch(resourceGroupName, "^[-\\w\\._]+$") == false)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (farmId == null)
            {
                throw new ArgumentNullException("farmId");
            }
            if (startTimeUtc > endTimeUtc)
            {
                throw new ArgumentException("startTime is later than the endTime");
            }

            // Tracing
            var shouldTrace = TracingAdapter.IsEnabled;

            if (shouldTrace)
            {
                var invocationId = TracingAdapter.NextInvocationId.ToString(CultureInfo.InvariantCulture);
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("farmId", farmId);
                tracingParameters.Add("startTimeUtc", startTimeUtc);
                tracingParameters.Add("endTimeUtc", endTimeUtc);
                tracingParameters.Add("computerName", computerName);
                tracingParameters.Add("resourceUri", resourceUri);
                tracingParameters.Add("providerGuid", providerGuid);
                tracingParameters.Add("eventIds", eventIds);
                TracingAdapter.Enter(invocationId, this, "ExecuteEventQuery", tracingParameters);
            }
            var filterList = new List<string>();
            filterList.Add(string.Format(CultureInfo.InvariantCulture, "startTime eq '{0:O}'", startTimeUtc.ToUniversalTime()));
            filterList.Add(string.Format(CultureInfo.InvariantCulture, "endTime eq '{0:O}'", endTimeUtc.ToUniversalTime()));
            if (!string.IsNullOrEmpty(computerName))
            {
                filterList.Add(string.Format(CultureInfo.InvariantCulture, "computerName eq '{0}'", computerName));
            }
            if (!string.IsNullOrEmpty(resourceUri))
            {
                filterList.Add(string.Format(CultureInfo.InvariantCulture, "resourceUri eq '{0}'", resourceUri));
            }
            if (providerGuid != null)
            {
                filterList.Add(string.Format(CultureInfo.InvariantCulture, "providerId eq '{0}'", providerGuid));
            }
            if (eventIds != null)
            {
                var eventIdFilters = new List<string>();
                foreach (var eventId in eventIds)
                {
                    eventIdFilters.Add(string.Format(CultureInfo.InvariantCulture, "eventId eq '{0}'", eventId));
                }
                if (eventIdFilters.Any())
                {
                    var eventIdFilter = eventIdFilters.Aggregate((current, next) => string.Format(CultureInfo.InvariantCulture, "{0} or {1}", current, next));
                    filterList.Add(string.Format(CultureInfo.InvariantCulture, "({0})", eventIdFilter));
                }
            }
            var filter = filterList.Aggregate((current, next) => string.Format(CultureInfo.InvariantCulture, "{0} and {1}", current, next));
            var eventQuery = Client.Farms.GetEventQuery(resourceGroupName, farmId, filter);
            return ExecuteEventQuery(eventQuery);
        }

        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name="eventQuery">
        /// Required. Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        public IEnumerable<EventModel> ExecuteEventQuery(
            EventQuery eventQuery)
        {
            // Validate
            if (eventQuery == null)
                throw new ArgumentNullException("eventQuery");

            var shouldTrace = TracingAdapter.IsEnabled;
            var invocationId = string.Empty;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("eventQuery", eventQuery);
                TracingAdapter.Enter(invocationId, this, "ExecuteEventQuery", tracingParameters);
            }
            EventQueryContinuationToken continuationToken = null;
            do
            {
                var response = ExecuteEventQuerySegmented(eventQuery, continuationToken, null);
                continuationToken = response.ContinuationToken;
                foreach (var eventModel in response.Events)
                {
                    yield return eventModel;
                }
            } while (continuationToken != null);
        }

        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name="eventQuery">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="continuationToken">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="maxCount">
        /// Optional. Your documentation here.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        public EventListResponse ExecuteEventQuerySegmented(
           EventQuery eventQuery,
           EventQueryContinuationToken continuationToken,
           int? maxCount)
        {
            return
                Task.Factory.StartNew(
                    () => ExecuteEventQuerySegmentedAsync(eventQuery, continuationToken, maxCount, CancellationToken.None))
                    .Unwrap().GetAwaiter().GetResult();
        }


        /// <summary>
        /// Your documentation here.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/XXXXX.aspx
        /// for more information)
        /// </summary>
        /// <param name="eventQuery">
        /// Required. Your documentation here.
        /// </param>
        /// <param name="continuationToken">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name="maxCount">
        /// Optional. Your documentation here.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Your documentation here.
        /// </returns>
        public async Task<EventListResponse> ExecuteEventQuerySegmentedAsync(
           EventQuery eventQuery,
           EventQueryContinuationToken continuationToken,
           int? maxCount,
           CancellationToken cancellationToken)
        {
            // Validate
            if (eventQuery == null)
                throw new ArgumentNullException("eventQuery");
            if (maxCount.HasValue && maxCount.Value <= 0)
                throw new ArgumentOutOfRangeException("maxCount");

            var shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = String.Empty;

            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("eventQuery", eventQuery);
                tracingParameters.Add("continuationToken", continuationToken);
                tracingParameters.Add("maxCount", maxCount);
                TracingAdapter.Enter(invocationId, this, "ExecuteEventQuerySegmentedAsync", tracingParameters);
            }
            var response = await QueryEventAsync(eventQuery, continuationToken, maxCount, cancellationToken);
            if (shouldTrace)
            {
                TracingAdapter.Exit(invocationId, response);
            }
            return response;
        }

        #region help function
        private static async Task<EventListResponse> QueryEventAsync(
            EventQuery eventQuery,
            EventQueryContinuationToken continuationToken,
            int? maxCount,
            CancellationToken cancellationToken)
        {
            if (maxCount.HasValue && maxCount.Value <= 0)
            {
                throw new ArgumentOutOfRangeException("maxCount");
            }
            if (eventQuery == null)
            {
                throw new ArgumentNullException("eventQuery");
            }
            if (eventQuery.TableInfos == null)
            {
                throw new ArgumentException("eventQuery.TableInfos is null");
            }

            var response = new EventListResponse
            {
                Events = new List<EventModel>(),
                ContinuationToken = new EventQueryContinuationToken()
            };

            var tableinfoIterator = eventQuery.TableInfos.GetEnumerator();
            do
            {
                if (tableinfoIterator.MoveNext())
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    continue;
                }
                response.ContinuationToken = null;
                return response;
            } while (continuationToken != null && tableinfoIterator.Current.TableName != continuationToken.NextTableName);
            try
            {
                var tableClient = new CloudTableClient(
                    new Uri(eventQuery.TableEndpoint),
                    new StorageCredentials(tableinfoIterator.Current.SasToken));
                var cloudTable = tableClient.GetTableReference(tableinfoIterator.Current.TableName);

                var tableQuery = new TableQuery<DynamicTableEntity>().Where(eventQuery.FilterUri).Take(maxCount);
                cancellationToken.ThrowIfCancellationRequested();
                var tableContinuationToken = continuationToken == null
                    ? null
                    : continuationToken.NextTableContinuationToken;
                var tableResults = await cloudTable.ExecuteQuerySegmentedAsync(tableQuery, tableContinuationToken, cancellationToken);
                response.Events = tableResults.Select(
                    _ => new EventModel
                    {
                        Properties = ResolveEventEntity(_)
                    }).ToList();
                response.ContinuationToken.NextTableContinuationToken = tableResults.ContinuationToken;
                if (response.ContinuationToken.NextTableContinuationToken == null)
                {
                    if (!tableinfoIterator.MoveNext())
                    {
                        response.ContinuationToken = null;
                        return response;
                    }
                }
                response.ContinuationToken.NextTableName = tableinfoIterator.Current.TableName;
            }
            catch (StorageException error)
            {
                throw new EventQueryException("Error occurs when query event table", error);
            }
            return response;
        }

        private static Event ResolveEventEntity(DynamicTableEntity entity)
        {
            var eventEntity = new Event
            {
                Timestamp = entity.Timestamp.UtcDateTime,
                Id = entity.PartitionKey + "_" + entity.RowKey
            };

            foreach (var key in entity.Properties.Keys)
            {
                switch (key)
                {
                    case "Channel":
                        eventEntity.ChannelName = entity[key].StringValue;
                        break;
                    case "PreciseTimeStamp":
                        eventEntity.EventTimeStamp = entity[key].DateTime ?? DateTime.MinValue;
                        break;
                    case "EventId":
                        eventEntity.EventId = entity[key].Int32Value ?? -1;
                        break;
                    case "Level":
                        eventEntity.Level = entity[key].Int32Value.HasValue ? (EventLevel)Enum.Parse(typeof(EventLevel), entity[key].Int32Value.Value.ToString(CultureInfo.InvariantCulture)) : EventLevel.LogAlways;
                        break;
                    case "ProviderName":
                        eventEntity.ProviderName = entity[key].StringValue;
                        break;
                    case "MachineName":
                        eventEntity.ComputerName = entity[key].StringValue;
                        break;
                    case "Description":
                        eventEntity.Message = entity[key].StringValue;
                        break;
                }
            }
            return eventEntity;
        }

        #endregion
    }

    /// <summary>
    /// Your documentation here.
    /// </summary>
    public partial class EventListResponse : AzureOperationResponse, IEnumerable<EventModel>
    {
        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public IList<EventModel> Events
        {
            get; 
            set;
        }

        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public EventQueryContinuationToken ContinuationToken
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the EventListResponse class.
        /// </summary>
        public EventListResponse()
        {
            Events = new LazyList<EventModel>();
        }

        /// <summary>
        /// Gets the sequence of Events.
        /// </summary>
        public IEnumerator<EventModel> GetEnumerator()
        {
            return Events.GetEnumerator();
        }

        /// <summary>
        /// Gets the sequence of Events.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// Your documentation here.
    /// </summary>
    public partial class  EventQueryContinuationToken
    {
        /// <summary>
        /// Required. Next Table Continuation Token to handle.
        /// This identify which pk and rk to handle in a table
        /// </summary>
        public TableContinuationToken NextTableContinuationToken
        {
            get;
            set;
        }

        /// <summary>
        /// Required. Next Table to handle.
        /// This identify which table to handle in eventQuery
        /// </summary>
        public string NextTableName
        {
            get; 
            set;
        }
    }

    /// <summary>
    /// Your documentation here.
    /// </summary>
    public partial class EventModel : Microsoft.AzureStack.AzureConsistentStorage.Models.ResourceBase
    {
        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public Event Properties
        {
            get; 
            set;
        }
    }

    public partial class Event
    { 
        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public DateTimeOffset Timestamp
        {
            get;
            set;
        }

        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public string ComputerName
        {
            get;
            set;
        }

        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public string ChannelName
        {
            get;
            set;
        }

        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public int EventId
        {
            get;
            set;
        }

        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public EventLevel Level
        {
            get;
            set;
        }

        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public string ProviderName
        {
            get;
            set;
        }
        
        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public DateTime EventTimeStamp
        {

            get;
            set;
        }

        /// <summary>
        /// Optional. Your documentation here
        /// </summary>
        public string Message
        {
            get;
            set;
        }
    }

    public enum EventLevel
    {
        // Summary:
        //     No level filtering is done on the event.
        LogAlways = 0,
        //
        // Summary:
        //     This level corresponds to a critical error, which is a serious error that
        //     has caused a major failure.
        Critical = 1,
        //
        // Summary:
        //     This level adds standard errors that signify a problem.
        Error = 2,
        //
        // Summary:
        //     This level adds warning events (for example, events that are published because
        //     a disk is nearing full capacity).
        Warning = 3,
        //
        // Summary:
        //     This level adds informational events or messages that are not errors. These
        //     events can help trace the progress or state of an application.
        Informational = 4,
        //
        // Summary:
        //     This level adds lengthy events or messages. It causes all events to be logged.
        Verbose = 5,
    }
}
