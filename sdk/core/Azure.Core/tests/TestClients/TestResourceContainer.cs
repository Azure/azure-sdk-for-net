// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests
{
    public class TestResourceContainer
    {
        private DiagnosticScopeFactory _diagnostic = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

        [ForwardsClientCalls]
        public virtual Pageable<TestResource> List(int pages = 1, CancellationToken cancellation = default)
        {
            Page<TestResource> pageFunc(int? pageSizeHint)
            {
                //simulates forwarding with todays wrapper.  This should go away after codegen is finished
                using var scope = _diagnostic.CreateScope("TestResourceContainer.GetSyncResults");
                scope.Start();

                try
                {
                    var result = new object[] { new object(), new object() };
                    return Page.FromValues(result.Select(o => new TestResource()), null, new MockResponse(200));
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(pageFunc, null);
        }

        [ForwardsClientCalls]
        public virtual AsyncPageable<TestResource> ListAsync(int pages = 1, CancellationToken cancellation = default)
        {
            async Task<Page<TestResource>> pageFunc(int? pageSizeHint)
            {
                using var scope = _diagnostic.CreateScope("TestResourceContainer.GetAsyncResults");
                scope.Start();

                try
                {
                    await Task.Delay(10);
                    var result = new object[] { new object(), new object() };
                    return Page.FromValues(result.Select(o => new TestResource()), null, new MockResponse(200));
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(pageFunc, null);
        }

        public virtual string Method()
        {
            return "success";
        }
    }
}
