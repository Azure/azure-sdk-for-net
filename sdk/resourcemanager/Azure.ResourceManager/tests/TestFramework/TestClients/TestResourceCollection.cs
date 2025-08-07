// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.Core.TestFramework.Tests
{
    public class TestResourceCollection : ArmCollection, IEnumerable<TestResource>, IAsyncEnumerable<TestResource>
    {
        private DiagnosticScopeFactory _diagnostic = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true, true);

        public virtual Pageable<TestResource> GetAll(int pages = 1, CancellationToken cancellation = default)
        {
            Page<TestResource> pageFunc(int? pageSizeHint)
            {
                //simulates forwarding with todays wrapper.  This should go away after codegen is finished
                using var scope = _diagnostic.CreateScope("TestResourceCollection.GetAll");
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
                using var scope = _diagnostic.CreateScope("TestResourceCollection.GetAll");
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

        /// <summary>
        /// Iterates through all resource groups.
        /// </summary>
        public IEnumerator<TestResource> GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <summary>
        /// Iterates through all resource groups.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public IAsyncEnumerator<TestResource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return GetAllAsync(cancellation: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
