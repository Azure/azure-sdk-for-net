// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// General Service Response.
    /// </summary>
    public abstract class ServiceResponse
    {
        internal Dictionary<string, object> States { get; set; } = new Dictionary<string, object>();
    }
}
