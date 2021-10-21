// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Analytics.Purview.Administration
{
#pragma warning disable SA1402 // File may only contain a single type
    [CodeGenClient("AccountsClient")]
    public partial class PurviewAccountClient { }

    [CodeGenClient("CollectionsClient", ParentClient = typeof(PurviewAccountClient))]
    public partial class PurviewCollection { }

    [CodeGenClient("ResourceSetRulesClient", ParentClient = typeof(PurviewAccountClient))]
    public partial class PurviewResourceSetRule { }
#pragma warning restore SA1402 // File may only contain a single type
}
