using Microsoft.Azure.ApplicationInsights.Query.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.ApplicationInsights.Query
{
    public partial class EventsExtensions
    {
        
        #region Event Extensions

        /// <summary>
        /// Execute OData query for trace events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for trace events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsTraceResult> GetTraceEvents(this IEvents operations, string appId,
            string timespan = default(string), string filter = default(string), string search = default(string),
            string orderby = default(string), string select = default(string), int? skip = default(int?),
            int? top = default(int?), string format = default(string), bool? count = default(bool?),
            string apply = default(string))
        {
            return operations
                .GetTraceEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for trace events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for trace events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsTraceResult>> GetTraceEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetTraceEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a trace event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single trace event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsTraceResult> GetTraceEvent(this IEvents operations, string appId,
            string eventId, string timespan = default(string))
        {
            return operations.GetTraceEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a trace event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single trace event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsTraceResult>> GetTraceEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetTraceEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for custom events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsCustomEventResult> GetCustomEvents(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetCustomEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for custom events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsCustomEventResult>> GetCustomEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetCustomEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a custom event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsCustomEventResult> GetCustomEvent(
            this IEvents operations, string appId, string eventId, string timespan = default(string))
        {
            return operations.GetCustomEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a custom event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsCustomEventResult>> GetCustomEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetCustomEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for page view events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for page view events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsPageViewResult> GetPageViewEvents(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetPageViewEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for page view events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for page view events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsPageViewResult>> GetPageViewEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetPageViewEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a page view event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single page view event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsPageViewResult> GetPageViewEvent(
            this IEvents operations, string appId, string eventId, string timespan = default(string))
        {
            return operations.GetPageViewEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a page view event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single page view event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsPageViewResult>> GetPageViewEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetPageViewEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for browser timing events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for browser timing events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsBrowserTimingResult> GetBrowserTimingEvents(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetBrowserTimingEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for browser timing events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for browser timing events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsBrowserTimingResult>> GetBrowserTimingEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetBrowserTimingEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a browser timing event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single browser timing event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsBrowserTimingResult> GetBrowserTimingEvent(
            this IEvents operations, string appId, string eventId, string timespan = default(string))
        {
            return operations.GetBrowserTimingEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a browser timing event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single browser timing event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsBrowserTimingResult>> GetBrowserTimingEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetBrowserTimingEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for request events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for request events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsRequestResult> GetRequestEvents(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetRequestEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for request events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for request events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsRequestResult>> GetRequestEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetRequestEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a request event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single request event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsRequestResult> GetRequestEvent(this IEvents operations, string appId,
            string eventId, string timespan = default(string))
        {
            return operations.GetRequestEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a request event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single request event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsRequestResult>> GetRequestEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetRequestEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for dependency events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for dependency events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsDependencyResult> GetDependencyEvents(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetDependencyEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for dependency events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for dependency events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsDependencyResult>> GetDependencyEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetDependencyEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a dependency event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single dependency event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsDependencyResult> GetDependencyEvent(
            this IEvents operations, string appId, string eventId, string timespan = default(string))
        {
            return operations.GetDependencyEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a dependency event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single dependency event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsDependencyResult>> GetDependencyEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetDependencyEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for exception events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for exception events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsExceptionResult> GetExceptionEvents(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetExceptionEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for exception events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for exception events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsExceptionResult>> GetExceptionEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetExceptionEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get an exception event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single exception event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsExceptionResult> GetExceptionEvent(
            this IEvents operations, string appId, string eventId, string timespan = default(string))
        {
            return operations.GetExceptionEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get an exception event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single exception event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsExceptionResult>> GetExceptionEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetExceptionEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for availability result events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for availability result events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsAvailabilityResultResult> GetAvailabilityResultEvents(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetAvailabilityResultEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for availability result events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for availability result events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsAvailabilityResultResult>> GetAvailabilityResultEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetAvailabilityResultEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get an availability result event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single availability result event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsAvailabilityResultResult> GetAvailabilityResultEvent(
            this IEvents operations, string appId, string eventId, string timespan = default(string))
        {
            return operations.GetAvailabilityResultEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get an availability result event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single availability result event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsAvailabilityResultResult>> GetAvailabilityResultEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetAvailabilityResultEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for performance counter events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for performance counter events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsPerformanceCounterResult> GetPerformanceCounterEvents(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetPerformanceCounterEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for performance counter events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for performance counter events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsPerformanceCounterResult>> GetPerformanceCounterEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetPerformanceCounterEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a performance counter event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single performance counter event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsPerformanceCounterResult> GetPerformanceCounterEvent(
            this IEvents operations, string appId, string eventId, string timespan = default(string))
        {
            return operations.GetPerformanceCounterEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a performance counter event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single performance counter event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsPerformanceCounterResult>> GetPerformanceCounterEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetPerformanceCounterEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for custom metric events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom metric events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsCustomMetricResult> GetCustomMetricEvents(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetCustomMetricEventsAsync(appId, timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for custom metric events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom metric events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsCustomMetricResult>> GetCustomMetricEventsAsync(
            this IEvents operations, string appId, string timespan = default(string),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetCustomMetricEventsWithHttpMessagesAsync(appId, timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a custom metricevent
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom metric event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsCustomMetricResult> GetCustomMetricEvent(
            this IEvents operations, string appId, string eventId, string timespan = default(string))
        {
            return operations.GetCustomMetricEventAsync(appId, eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a custom metricevent
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom metric event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsCustomMetricResult>> GetCustomMetricEventAsync(
            this IEvents operations, string appId, string eventId, string timespan = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetCustomMetricEventWithHttpMessagesAsync(appId, eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        #endregion
    }
}