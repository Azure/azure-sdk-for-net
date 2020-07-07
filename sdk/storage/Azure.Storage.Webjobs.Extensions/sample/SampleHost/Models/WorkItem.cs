// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
