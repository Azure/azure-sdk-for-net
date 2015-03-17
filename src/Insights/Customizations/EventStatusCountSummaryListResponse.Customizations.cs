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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Insights.Models
{
    /// <summary>
    /// The extension methods for event count summary list response
    /// </summary>
    partial class EventStatusCountSummaryListResponse
    {
        /// <summary>
        /// Count summary is at 1 day granularity.
        /// </summary>
        private static readonly TimeSpan SupportedTimeGrain = TimeSpan.FromDays(1);

        /// <summary>
        /// Create a cross resource event status count summary
        /// </summary>
        /// <param name="startTime">start time</param>
        /// <param name="endTime">end time</param>
        /// <returns>the event count summary response</returns>
        public EventStatusCountSummaryItemCollection AggregateSummary(DateTime startTime, DateTime endTime)
        {
            int expectedNumberOfItems = (int)((endTime - startTime).Ticks / SupportedTimeGrain.Ticks) + 1;

            // Aggregate the summary items
            var listOfItems = new EventStatusCountSummaryItem[expectedNumberOfItems];
            foreach (var summaryItem in this.EventStatusCountSummaryItemCollection.Value)
            {
                int position = GetPosition(startTime, SupportedTimeGrain, expectedNumberOfItems, summaryItem.EventTime);

                EventStatusCountSummaryItem item = listOfItems[position];
                if (item == null)
                {
                    item = new EventStatusCountSummaryItem
                    {
                        EventTime = summaryItem.EventTime, 
                        StatusCounts = new List<StatusCount>(),
                        TimeGrain = SupportedTimeGrain,
                        Id = null
                    };

                    listOfItems[position] = item;
                }

                item.StatusCounts = MergeStatusCounts(item.StatusCounts, summaryItem.StatusCounts);
            }

            // Fill in the gaps
            DateTime currentTime = startTime;
            for (int i = expectedNumberOfItems - 1; i >= 0; i--)
            {
                if (listOfItems[i] == null)
                {
                    listOfItems[i] = new EventStatusCountSummaryItem
                    {
                        EventTime = currentTime.ToUniversalTime(),
                        StatusCounts = new List<StatusCount>(),
                        TimeGrain = SupportedTimeGrain,
                        Id = null
                    };
                }

                currentTime += SupportedTimeGrain;
            }

            return new EventStatusCountSummaryItemCollection
            {                
                Value = listOfItems
            };
        }

        private static int GetPosition(
            DateTime startTime, 
            TimeSpan timeGrain, 
            int expectedNumberOfItems,
            DateTime eventTime)
        {
            TimeSpan eventTimeOffSet = eventTime - startTime;
            return expectedNumberOfItems - 1 - (int) (eventTimeOffSet.Ticks/timeGrain.Ticks);
        }

        private static List<StatusCount> MergeStatusCounts(IList<StatusCount> list1, IList<StatusCount> list2)
        {
            List<StatusCount> mergedList = new List<StatusCount>();

            if ((list1 == null) && (list2 == null))
            {
                return mergedList;
            }

            if (list1 == null)
            {
                mergedList.AddRange(list2);
            }
            else if (list2 == null)
            {
                mergedList.AddRange(list1);
            }
            else
            {
                mergedList.AddRange(list1);
                foreach (var item in list2)
                {
                    var invariantStatusValue = (item.Status != null) ? item.Status.Value : string.Empty;
                    var statusCount = mergedList.FirstOrDefault(s =>(s.Status != null) && (s.Status.Value.Equals(invariantStatusValue, StringComparison.OrdinalIgnoreCase)));
                    if (statusCount == null)
                    {
                        mergedList.Add(item);
                    }
                    else
                    {
                        statusCount.Count += item.Count;
                    }
                }
            }

            return mergedList;
        }
    }
}
