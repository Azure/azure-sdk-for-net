//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Globalization;

namespace Microsoft.Azure.Insights.Models
{
    /// <summary>
    /// The extension methods for event count summary list response
    /// </summary>
    partial class EventCountSummaryListResponse
    {
        /// <summary>
        /// Count summary is at 1 day granularity.
        /// </summary>
        private static readonly TimeSpan SupportedTimeGrain = TimeSpan.FromDays(1);

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
            int expectedNumberOfItems = (int)((endTime - startTime).Ticks / SupportedTimeGrain.Ticks) + 1;

            // Aggregate the summary items
            var listOfItems = new CountSummaryItem[expectedNumberOfItems];
            foreach (var summaryItem in this.EventCountSummaryItemCollection.Value)
            {
                int position = GetPosition(startTime, SupportedTimeGrain, expectedNumberOfItems, summaryItem.EventTime);

                CountSummaryItem item = listOfItems[position];
                if (item == null)
                {
                    item = new CountSummaryItem() { EventTime = summaryItem.EventTime };
                    listOfItems[position] = item;
                }

                item.FailedEventsCount += summaryItem.FailedEventsCount;
                item.TotalEventsCount += summaryItem.TotalEventsCount;
            }

            // Fill in the gaps
            DateTime currentTime = startTime;
            for (int i = expectedNumberOfItems - 1; i >= 0; i--)
            {
                if (listOfItems[i] == null)
                {
                    listOfItems[i] = new CountSummaryItem() { EventTime = currentTime.ToUniversalTime() };
                }

                currentTime += SupportedTimeGrain;
            }

            return new EventCountSummaryResponse()
            {
                StartTime = startTime,
                EndTime = endTime,
                EventPropertyName = propertyName,
                EventPropertyValue = propertyValue,
                RequestId = this.RequestId,
                StatusCode = this.StatusCode,
                SummaryItems = listOfItems
            };
        }

        private static int GetPosition(
            DateTime startTime,
            TimeSpan timeGrain,
            int expectedNumberOfItems,
            DateTime eventTime)
        {
            TimeSpan eventTimeOffSet = eventTime - startTime;
            return expectedNumberOfItems - 1 - (int)(eventTimeOffSet.Ticks / timeGrain.Ticks);
        }
    }
}