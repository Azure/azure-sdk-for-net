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
using System.Net;
using Microsoft.Azure.Common.OData;
using Microsoft.Azure.Common.Test.Fakes;
using Xunit;

namespace Microsoft.Azure.Common.Test
{
    [Flags]
    public enum EventChannels
    {
        Admin = 1,
        Operation = 2,
        Debug = 4,
        Analytics = 8,
    }
    public class ListEventsParameters
    {
        [FilterParameter("startTime", "O")]
        public DateTime? StartTime { get; set; }

        [FilterParameter("eventChannels")]
        public EventChannels? EventChannels { get; set; }

        [FilterParameter("status")]
        public string Status { get; set; }

        [FilterParameter("timeGrain")]
        public TimeSpan? TimeGrain { get; set; }

    }

    public class FilterStringTest
    {
        [Fact]
        public void FilterStringDateTime()
        {
            var startTime = DateTime.Parse("2015-10-09T00:00:00.0000000Z");
            var filterString = FilterString.Generate<ListEventsParameters>(parameters => parameters.StartTime >= startTime);

            // Console.WriteLine(filterString);
            Assert.Equal(filterString, "startTime ge '2015-10-09T00:00:00.0000000Z'");
        }

        // right side is TimeSpan
        [Fact]
        public void FilterStringTimeSpan()
        {
            var timeSpan = TimeSpan.FromMinutes(5);
            var filterString = FilterString.Generate<ListEventsParameters>(parameters => parameters.TimeGrain == timeSpan);

//            Console.WriteLine(filterString);
            Assert.Equal(filterString, "timeGrain eq duration'PT5M'");
        }

    }
}
