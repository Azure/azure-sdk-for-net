// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
namespace Azure.Analytics.LoadTestService
{
    /// <summary></summary>
    public class ServerMetricsModel
    {
        /// <summary></summary>
        public string name { get; set; }
        /// <summary></summary>
        public string testId { get; set; }
        /// <summary></summary>
        public string testRunId { get; set; }
        /// <summary></summary>
        public ServerMetrics metrics { get; set; }
    }
    /// <summary></summary>
    public class ServerMetrics
    {
        /// <summary></summary>
        public ResourceData resourcedata { get; set; }
    }
    /// <summary></summary>
    public class ResourceData
    {
        /// <summary></summary>
        public string id { get; set; }
        /// <summary></summary>
        public string resourceId { get; set; }
        /// <summary></summary>
        public string metricnamespace { get; set; }
        /// <summary></summary>
        public string displayDescription { get; set; }
        /// <summary></summary>
        public ServerMetricsName name { get; set; }
        /// <summary></summary>
        public string aggregation { get; set; }
        /// <summary></summary>
        public object unit { get; set; }
        /// <summary></summary>
        public string resourceType { get; set; }
    }
    /// <summary></summary>
    public class ServerMetricsName
    {
        /// <summary></summary>
        public string value { get; set; }
        /// <summary></summary>
        public string localizedValue { get; set; }
    }
}
