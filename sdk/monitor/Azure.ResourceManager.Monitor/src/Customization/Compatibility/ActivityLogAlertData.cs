// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor
{
    // AutoRest generated activity log alerts as tracked resources; TypeSpec models the wire shape as a proxy resource
    // with explicit tags/location. Restore TrackedResourceData and the AzureLocation constructor to preserve the
    // stable public API while keeping the TypeSpec wire shape unchanged.
    public partial class ActivityLogAlertData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ActivityLogAlertData"/>. </summary>
        /// <param name="location"> The location. </param>
        public ActivityLogAlertData(AzureLocation location) : base(location)
        {
        }
    }
}
