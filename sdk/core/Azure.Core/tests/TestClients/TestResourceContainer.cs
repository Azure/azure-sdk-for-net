// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.Core.Tests
{
    public class TestResourceContainer : ArmContainer
    {
        private DiagnosticScopeFactory _diagnostic = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

        protected override ResourceType ValidResourceType => "MyFake.Namespace/testResource";

        public virtual Pageable<TestResource> GetAll(int pages = 1, CancellationToken cancellation = default)
        {
            Page<TestResource> pageFunc(int? pageSizeHint)
            {
                //simulates forwarding with todays wrapper.  This should go away after codegen is finished
                using var scope = _diagnostic.CreateScope("TestResourceContainer.GetAll");
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

        public virtual AsyncPageable<TestResource> GetAllAsync(int pages = 1, CancellationToken cancellation = default)
        {
            async Task<Page<TestResource>> pageFunc(int? pageSizeHint)
            {
                using var scope = _diagnostic.CreateScope("TestResourceContainer.GetAll");
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
