// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace SampleHost.Models
{
    public class WorkItem
    {
        public string ID { get; set; }
        public int Priority { get; set; }
        public string Region { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
    }
}
