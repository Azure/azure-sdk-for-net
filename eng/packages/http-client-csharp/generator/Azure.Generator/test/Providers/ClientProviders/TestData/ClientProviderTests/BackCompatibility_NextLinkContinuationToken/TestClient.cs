// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure;
using Samples.Models;

namespace Samples
{
    public partial class TestClient
    {
        public virtual Pageable<BinaryData> GetItems(string token, string filter, RequestContext context) => throw new NotImplementedException();
        public virtual AsyncPageable<BinaryData> GetItemsAsync(string token, string filter, RequestContext context) => throw new NotImplementedException();
        public virtual Pageable<Item> GetItems(string token, string filter, CancellationToken cancellationToken) => throw new NotImplementedException();
        public virtual AsyncPageable<Item> GetItemsAsync(string token, string filter, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}

namespace Samples.Models
{
    public partial class Item
    {
    }
}
