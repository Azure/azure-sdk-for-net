// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;
using static Azure.Core.PageResponseEnumerator;

namespace Azure.Core.Tests
{
    public class TestResourceContainer
    {
        public virtual Pageable<TestResource> List(int pages = 1, CancellationToken cancellation = default)
        {
            FuncPageable<object> results = GetSyncResults(pages);
            return new PhWrappingPageable<object, TestResource>(results, o => new TestResource());
        }

        private FuncPageable<object> GetSyncResults(int pages)
        {
            Page<object> pageFunc(int? pageSizeHint)
            {
                return Page<object>.FromValues(new object[] { new object(), new object() }, null, null);
            }
            return new FuncPageable<object>((cToken, pageSize) => pageFunc(pageSize));
        }

        public virtual AsyncPageable<TestResource> ListAsync(int pages = 1, CancellationToken cancellation = default)
        {
            FuncAsyncPageable<object> results = GetAsyncResults(pages);
            return new PhWrappingAsyncPageable<object, TestResource>(results, o => new TestResource());
        }

        private FuncAsyncPageable<object> GetAsyncResults(int pages)
        {
            async Task<Page<object>> pageFunc(int? pageSizeHint)
            {
                await Task.Delay(10);
                return Page<object>.FromValues(new object[] { new object(), new object() }, null, null);
            }
            return new FuncAsyncPageable<object>((cToken, pageSize) => pageFunc(pageSize));
        }

        public virtual string Method()
        {
            return "success";
        }
    }
}
