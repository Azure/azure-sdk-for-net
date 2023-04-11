// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.DataBoxEdge.Models;

namespace Azure.ResourceManager.DataBoxEdge.Tests.Helpers
{
    public class BandwidthScheduleHelper
    {
        /// <summary>
        /// Gets a bandwidth schedule object
        /// </summary>
        /// <returns>BandwidthSchedule</returns>
        public static BandwidthScheduleData GetBWSObject()
        {
            string start = string.Format("{0}:{1}:{2}", 10, 0, 0);
            string stopTime = string.Format("{0}:{1}:{2}", 11, 22, 0);
            List<DataBoxEdgeDayOfWeek> days = new List<DataBoxEdgeDayOfWeek> { "Tuesday", "Wednesday" };
            BandwidthScheduleProperties properties = new BandwidthScheduleProperties(start, stopTime, 100, days);

            BandwidthScheduleData bws = new BandwidthScheduleData(properties);
            return bws;
        }
    }
}
