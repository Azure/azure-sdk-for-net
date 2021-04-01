// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using static Azure.Core.PageResponseEnumerator;

namespace Azure.Core.Tests
{
    public class TestResourceContainer
    {
        private DiagnosticScopeFactory _diagnostic = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

        [ForwardsClientCalls]
        public virtual Pageable<TestResource> List(int pages = 1, CancellationToken cancellation = default)
        {
            FuncPageable<object> results = GetSyncResults(pages);
            return new PhWrappingPageable<object, TestResource>(results, o => new TestResource());
        }

        private FuncPageable<object> GetSyncResults(int pages)
        {
            Page<object> pageFunc(int? pageSizeHint)
            {
                //simulates forwarding with todays wrapper.  This should go away after codegen is finished
                using var scope = _diagnostic.CreateScope("TestResourceContainer.GetSyncResults");
                scope.Start();

                try
                {
                    return Page<object>.FromValues(new object[] { new object(), new object() }, null, null);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return new FuncPageable<object>((cToken, pageSize) => pageFunc(pageSize));
        }

        [ForwardsClientCalls]
        public virtual AsyncPageable<TestResource> ListAsync(int pages = 1, CancellationToken cancellation = default)
        {
            FuncAsyncPageable<object> results = GetAsyncResults(pages);
            return new PhWrappingAsyncPageable<object, TestResource>(results, o => new TestResource());
        }

        private FuncAsyncPageable<object> GetAsyncResults(int pages)
        {
            async Task<Page<object>> pageFunc(int? pageSizeHint)
            {
                using var scope = _diagnostic.CreateScope("TestResourceContainer.GetAsyncResults");
                scope.Start();

                try
                {
                    await Task.Delay(10);
                    return Page<object>.FromValues(new object[] { new object(), new object() }, null, null);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return new FuncAsyncPageable<object>((cToken, pageSize) => pageFunc(pageSize));
        }

        public virtual string Method()
        {
            return "success";
        }
    }
}
