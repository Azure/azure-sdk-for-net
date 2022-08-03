// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
namespace Azure.Analytics.LoadTestService
{
    /// <summary></summary>
    public class AppComponentModel
    {
        /// <summary></summary>
        public string resourceId { get; set; }
        /// <summary></summary>
        public string testId { get; set; }
        /// <summary></summary>
        public string testRunId { get; set; }
        /// <summary></summary>
        public string name { get; set; }
        /// <summary></summary>
        public ValueAppComponent value { get; set; }
    }
    /// <summary></summary>
    public class ValueAppComponent
    {
        /// <summary></summary>
        public ResourceAppComponent resourceappcomponent { get; set; }
    }
    /// <summary></summary>
    public class ResourceAppComponent
    {
        /// <summary></summary>
        public string resourceId { get; set; }
        /// <summary></summary>
        public string resourceType { get; set; }
        /// <summary></summary>
        public string resourceName { get; set; }
        /// <summary></summary>
        public string displayName { get; set; }
        /// <summary></summary>
        public string resourceGroup { get; set; }
        /// <summary></summary>
        public string subscriptionId { get; set; }
        /// <summary></summary>
        public string kind { get; set; }
    }
}
