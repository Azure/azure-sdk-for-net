// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.EventHubs
{
    public enum OffsetType
    {
        FromStart = 0,
        FromEnd = 1,
        FromEnqueuedTime = 2
    }
}
