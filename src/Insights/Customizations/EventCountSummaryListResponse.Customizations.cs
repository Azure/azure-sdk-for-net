using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights.Models
{
    /// <summary>
    /// The extension methods for event count summary list response
    /// </summary>
    partial class EventCountSummaryListResponse
    {
        /// <summary>
        /// Create the event count summary response
        /// </summary>
        /// <param name="startTime">start time</param>
        /// <param name="endTime">end time</param>
        /// <param name="propertyName">property name over which the events are summarized</param>
        /// <param name="propertyValue">property value</param>
        /// <returns>the event count summary response</returns>
        public EventCountSummaryResponse CreateEventCountSummaryResponse(
            DateTime startTime,
            DateTime endTime,
            string propertyName,
            string propertyValue)
        {
            var response = new EventCountSummaryResponse()
            {
                StartTime = startTime,
                EndTime = endTime.ToUniversalTime().ToString(CultureInfo.InvariantCulture),
                EventPropertyName = propertyName,
                EventPropertyValue = propertyValue,
                RequestId = this.RequestId,
                StatusCode = this.StatusCode,
                SummaryItems = new List<CountSummaryItem>()
            };

            // Build summary items
            if ((this.EventCountSummaryItemCollection != null) &&
                (this.EventCountSummaryItemCollection.Value != null) &&
                (this.EventCountSummaryItemCollection.Value.Any()))
            {
                ILookup<DateTime, EventCountSummaryItem> summaryItemsByTime = this
                    .EventCountSummaryItemCollection.Value.ToLookup(item => item.EventTime);

                var listOfItems = new SortedList<DateTime, CountSummaryItem>(new DescendingDateTimeComparer());
                foreach (var summaryItems in summaryItemsByTime)
                {
                    listOfItems.Add(
                        key: summaryItems.Key,
                        value: new CountSummaryItem()
                        {
                            EventTime = summaryItems.Key,
                            FailedEventsCount = summaryItems.Sum(item => item.FailedEventsCount),
                            TotalEventsCount = summaryItems.Sum(item => item.TotalEventsCount),
                        });
                }

                // fill in the missing items
                var currentTime = startTime;
                var timeGrain = this.EventCountSummaryItemCollection.Value.First().TimeGrain;
                while (currentTime <= endTime)
                {
                    if (listOfItems.All(item => item.Key != currentTime))
                    {
                        listOfItems.Add(
                            key: currentTime, 
                            value: new CountSummaryItem()
                            {
                                EventTime = currentTime
                            });
                    }

                    currentTime += timeGrain;
                }

                response.SummaryItems = listOfItems.Values;
            }

            return response;
        }

        /// <summary>
        /// Decensing order comparer of date time items.
        /// </summary>
        private class DescendingDateTimeComparer : IComparer<DateTime>
        {
            public int Compare(DateTime x, DateTime y)
            {
                if (x == y)
                {
                    return 0;
                }

                return (x < y) ? 1 : -1;
            }
        }
    }
}
