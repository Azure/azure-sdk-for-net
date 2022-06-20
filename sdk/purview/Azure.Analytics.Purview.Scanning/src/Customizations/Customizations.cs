// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Analytics.Purview.Scanning
{
#pragma warning disable SA1402 // File may only contain a single type
    [CodeGenClient("PurviewDataSource")]
    public partial class PurviewDataSource { }

    [CodeGenClient("PurviewScan", ParentClient = typeof(PurviewDataSource))]
    public partial class PurviewScan { }
#pragma warning restore SA1402 // File may only contain a single type
}
