// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class ApiManagementCircuitBreakerProperties
    {
        /// <summary> Overview of all configured rules and respective details. </summary>
        public IReadOnlyDictionary<string, object> Rules { get; }
    }
}
