// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Test.Shared
{
    /// <summary>
    /// Collection of values used across various service-specific request conditions.
    /// </summary>
    public class AccessConditionParameters
    {
        public DateTimeOffset? IfModifiedSince { get; set; }
        public DateTimeOffset? IfUnmodifiedSince { get; set; }
        public string Match { get; set; }
        public string NoneMatch { get; set; }
        public string LeaseId { get; set; }
    }
}
