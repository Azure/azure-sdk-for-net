// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Samples
{
    public class MyStoreClient
    {
        public GetProductsOperation StartGetProducts(CancellationToken cancellationToken = default) => new();
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "<Pending>")]
    public class GetProductsOperation : PageableOperation<Product>
    {
        private bool _completed;

        public override bool HasValue => _completed;
        public override bool HasCompleted => _completed;

        public override string Id { get; }

        public override Response GetRawResponse() => throw new NotImplementedException();

        internal GetProductsOperation()
        {
            Id = "MyOperationID";
            _completed = true;
        }

        public override Pageable<Product> GetValues(CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public override AsyncPageable<Product> GetValuesAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => throw new NotImplementedException();

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "<Pending>")]
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
