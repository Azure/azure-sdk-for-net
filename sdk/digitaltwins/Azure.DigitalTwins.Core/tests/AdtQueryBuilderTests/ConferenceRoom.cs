// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.DigitalTwins.Core.Tests.QueryBuilderTests
{
    public class ConferenceRoom
    {
        public string Room { get; set; }
        public string Factory { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public int Occupants { get; set; }
        public bool IsOccupied { get; set; }
    }
}
