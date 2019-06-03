using Microsoft.Azure.ApplicationInsights.Query.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace Microsoft.Azure.ApplicationInsights.Query
{
    public partial interface IEvents
    {
        /// <summary>
        /// Execute OData query for trace events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for trace events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsTraceResult>>> GetTraceEventsWithHttpMessagesAsync(
            string appId, string timespan = default(string), string filter = default(string), string search = default(string),
            string orderby = default(string), string select = default(string), int? skip = default(int?),
            int? top = default(int?), string format = default(string), bool? count = default(bool?),
            string apply = default(string), Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a trace event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single trace event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsTraceResult>>> GetTraceEventWithHttpMessagesAsync(
            string appId, string eventId = default(string), string timespan = default(string),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for custom events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsCustomEventResult>>> GetCustomEventsWithHttpMessagesAsync(string appId, string timespan = default(string), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Get a custom event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsCustomEventResult>>> GetCustomEventWithHttpMessagesAsync(string appId, string eventId = default(string), string timespan = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Execute OData query for page view events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for page view events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsPageViewResult>>> GetPageViewEventsWithHttpMessagesAsync(string appId, string timespan = default(string), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Get a page view event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single page view event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsPageViewResult>>> GetPageViewEventWithHttpMessagesAsync(string appId, string eventId = default(string), string timespan = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for browser timing events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for browser timing events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsBrowserTimingResult>>> GetBrowserTimingEventsWithHttpMessagesAsync(string appId, string timespan = default(string),
                string filter = default(string), string search = default(string), string orderby = default(string),
                string select = default(string), int? skip = default(int?), int? top = default(int?),
                string format = default(string), bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a browser timing event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single browser timing event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsBrowserTimingResult>>> GetBrowserTimingEventWithHttpMessagesAsync(string appId, string eventId = default(string), string timespan = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for request events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for request events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsRequestResult>>> GetRequestEventsWithHttpMessagesAsync(string appId, string timespan = default(string), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a request event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single request event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsRequestResult>>> GetRequestEventWithHttpMessagesAsync(string appId, string eventId = default(string), string timespan = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for dependency events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for dependency events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsDependencyResult>>> GetDependencyEventsWithHttpMessagesAsync(string appId, string timespan = default(string), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a dependency event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single dependency event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsDependencyResult>>> GetDependencyEventWithHttpMessagesAsync(string appId, string eventId = default(string), string timespan = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for exception events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for exception events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsExceptionResult>>> GetExceptionEventsWithHttpMessagesAsync(string appId, string timespan = default(string), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Get an exception event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single exception event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsExceptionResult>>> GetExceptionEventWithHttpMessagesAsync(string appId, string eventId = default(string), string timespan = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for availability result events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for availability result events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsAvailabilityResultResult>>> GetAvailabilityResultEventsWithHttpMessagesAsync(string appId, string timespan = default(string),
                string filter = default(string), string search = default(string), string orderby = default(string),
                string select = default(string), int? skip = default(int?), int? top = default(int?),
                string format = default(string), bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get an availability result event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single availability result event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsAvailabilityResultResult>>> GetAvailabilityResultEventWithHttpMessagesAsync(string appId, string eventId = default(string), string timespan = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for performance counter events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for performance counter events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsPerformanceCounterResult>>> GetPerformanceCounterEventsWithHttpMessagesAsync(string appId, string timespan = default(string),
                string filter = default(string), string search = default(string), string orderby = default(string),
                string select = default(string), int? skip = default(int?), int? top = default(int?),
                string format = default(string), bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a performance counter event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single performance counter event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsPerformanceCounterResult>>> GetPerformanceCounterEventWithHttpMessagesAsync(string appId, string eventId = default(string), string timespan = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for custom metric events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom metric events
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsCustomMetricResult>>> GetCustomMetricEventsWithHttpMessagesAsync(string appId, string timespan = default(string),
                string filter = default(string), string search = default(string), string orderby = default(string),
                string select = default(string), int? skip = default(int?), int? top = default(int?),
                string format = default(string), bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a custom metricevent
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom metric event
        /// </remarks>
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsCustomMetricResult>>> GetCustomMetricEventWithHttpMessagesAsync(string appId, string eventId = default(string), string timespan = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken));
    }
}
