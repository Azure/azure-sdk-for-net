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
    public class TestResourceContainer : ResourceContainer
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

        public virtual Response<TestResource> Get(bool shouldExist, string name, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceContainer.Get");
            scope.Start();

            try
            {
                if (shouldExist)
                {
                    return Response.FromValue(new TestResource(), new MockResponse(200));
                }
                else
                {
                    throw new RequestFailedException(404, "Failed because you asked me to");
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<TestResource>> GetAsync(bool shouldExist, string name, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceContainer.Get");
            scope.Start();

            try
            {
                if (shouldExist)
                {
                    await Task.Delay(10);
                    return Response.FromValue(new TestResource(), new MockResponse(200));
                }
                else
                {
                    throw new RequestFailedException(404, "Failed because you asked me to");
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual NullableResponse<TestResource> GetIfExists(bool shouldExist, string name, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceContainer.GetIfExists");
            scope.Start();

            try
            {
                return Get(shouldExist, name, cancellationToken);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return Response.FromNullableValue<TestResource>(null, new MockResponse(404));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<NullableResponse<TestResource>> GetIfExistsAsync(bool shouldExist, string name, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceContainer.GetIfExists");
            scope.Start();

            try
            {
                return await GetAsync(shouldExist, name, cancellationToken);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return Response.FromNullableValue<TestResource>(null, new MockResponse(404));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<TestResource> GetIfExistsResponse(bool shouldExist, string name, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceContainer.GetIfExistsResponse");
            scope.Start();

            try
            {
                return Get(shouldExist, name, cancellationToken);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return Response.FromValue<TestResource>(null, new MockResponse(404));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<TestResource>> GetIfExistsResponseAsync(bool shouldExist, string name, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceContainer.GetIfExistsResponse");
            scope.Start();

            try
            {
                return await GetAsync(shouldExist, name, cancellationToken);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return Response.FromValue<TestResource>(null, new MockResponse(404));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual string Method()
        {
            return "success";
        }
    }
}
