// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Administration
{
    [CodeGenClient("CollectionsClient", ParentClient = typeof(PurviewAccountClient))]
    public partial class PurviewCollection
    {
    }
}
