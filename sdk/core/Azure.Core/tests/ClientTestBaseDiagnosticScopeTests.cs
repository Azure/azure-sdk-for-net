// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ClientTestBaseDiagnosticScopeTests : ClientTestBase
    {
        public ClientTestBaseDiagnosticScopeTests(bool isAsync)
            : base(isAsync)
        {
            TestDiagnostics = true;
        }

        [Test]
        public void ThrowsWhenNoDiagnosticScope()
        {
            InvalidDiagnosticScopeTestClient client = InstrumentClient(new InvalidDiagnosticScopeTestClient());
            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await client.NoScopeAsync());
            StringAssert.Contains("Expected some diagnostic scopes to be created, found none", ex.Message);
        }

        [Test]
        public void ThrowsWhenDuplicateDiagnosticScope_DirectAncestor()
        {
            InvalidDiagnosticScopeTestClient client = InstrumentClient(new InvalidDiagnosticScopeTestClient());
            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await client.DuplicateScopeDirectAncestorAsync());
            StringAssert.Contains($"A scope has already started for event '{typeof(InvalidDiagnosticScopeTestClient).Name}.{nameof(client.DuplicateScopeDirectAncestor)}'", ex.Message);
        }

        [Test]
        public void ThrowsWhenDuplicateDiagnosticScope_Ancestor()
        {
            InvalidDiagnosticScopeTestClient client = InstrumentClient(new InvalidDiagnosticScopeTestClient());
            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await client.DuplicateScopeAncestorAsync());
            StringAssert.Contains($"A scope has already started for event '{typeof(InvalidDiagnosticScopeTestClient).Name}.{nameof(client.DuplicateScopeAncestor)}'", ex.Message);
        }

        [Test]
        public async Task DoesNotThrowWhenDuplicateDiagnosticScopeProperlyDisposed()
        {
            InvalidDiagnosticScopeTestClient client = InstrumentClient(new InvalidDiagnosticScopeTestClient());
            await client.DuplicateScopeProperlyDisposedAsync();
        }

        [Test]
        public void ThrowsWhenNoDiagnosticScopeInsidePageable()
        {
            InvalidDiagnosticScopeTestClient client = InstrumentClient(new InvalidDiagnosticScopeTestClient());
            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await client.GetPageableNoPageableScopesAsync().ToEnumerableAsync());

            // Make the error message more helpful
            StringAssert.Contains($"{typeof(InvalidDiagnosticScopeTestClient).Name}.{nameof(client.GetPageableNoPageableScopes)}", ex.Message);
            StringAssert.Contains("ForwardsClientCalls", ex.Message);
            StringAssert.Contains("operationId", ex.Message);
        }

        [Test]
        public void ThrowsWhenWrongDiagnosticScope()
        {
            InvalidDiagnosticScopeTestClient client = InstrumentClient(new InvalidDiagnosticScopeTestClient());
            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await client.WrongScopeAsync());

            // Make the error message more helpful
            StringAssert.Contains($"{typeof(InvalidDiagnosticScopeTestClient).Name}.{nameof(client.WrongScope)}", ex.Message);
            StringAssert.Contains("ForwardsClientCalls", ex.Message);
            StringAssert.Contains("operationId", ex.Message);
        }

        [Test]
        public async Task DoesNotThrowForCorrectPageableScopes()
        {
            InvalidDiagnosticScopeTestClient client = InstrumentClient(new InvalidDiagnosticScopeTestClient());
            Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6}, await client.GetPageableValidScopesAsync().ToEnumerableAsync());
            await client.ForwardsAsync();
        }

        [Test]
        public async Task DoesNotThrowForForwardedDiagnosticScope()
        {
            InvalidDiagnosticScopeTestClient client = InstrumentClient(new InvalidDiagnosticScopeTestClient());
            await client.ForwardsAsync();
        }

        [Test]
        public async Task DoesNotThrowForCorrectDiagnosticScope()
        {
            InvalidDiagnosticScopeTestClient client = InstrumentClient(new InvalidDiagnosticScopeTestClient());
            await client.CorrectScopeAsync();
        }

        public class InvalidDiagnosticScopeTestClient
        {
            private DiagnosticScope CreateScope(string method)
            {
                DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Core.Tests", "random", true);
                string activityName = $"{typeof(InvalidDiagnosticScopeTestClient).Name}.{method}";
                DiagnosticScope scope = clientDiagnostics.CreateScope(activityName);
                return scope;
            }

            private void CreateAndFireScope(string method)
            {
                DiagnosticScope scope = CreateScope(method);
                scope.Start();
                scope.Dispose();
            }

            [ForwardsClientCalls]
            public virtual Task<bool> NoScopeAsync()
            {
                return Task.FromResult(true);
            }

            [ForwardsClientCalls]
            public virtual bool NoScope()
            {
                return true;
            }

            public virtual Task<bool> DuplicateScopeDirectAncestorAsync()
            {
                return Task.FromResult(DuplicateScopeDirectAncestor());
            }

            public virtual bool DuplicateScopeDirectAncestor()
            {
                using DiagnosticScope scope1 = CreateScope(nameof(DuplicateScopeDirectAncestor));
                scope1.Start();
                using DiagnosticScope scope2 = CreateScope(nameof(DuplicateScopeDirectAncestor));
                scope2.Start();
                return true;
            }

            public virtual Task<bool> DuplicateScopeAncestorAsync()
            {
                return Task.FromResult(DuplicateScopeAncestor());
            }

            public virtual bool DuplicateScopeAncestor()
            {
                using DiagnosticScope scope1 = CreateScope(nameof(DuplicateScopeAncestor));
                scope1.Start();
                using DiagnosticScope scope2 = CreateScope(nameof(CorrectScope));
                scope2.Start();
                using DiagnosticScope scope3 = CreateScope(nameof(DuplicateScopeAncestor));
                scope3.Start();
                return true;
            }

            public virtual Task<bool> DuplicateScopeProperlyDisposedAsync()
            {
                return Task.FromResult(DuplicateScopeProperlyDisposed());
            }

            public virtual bool DuplicateScopeProperlyDisposed()
            {
                DiagnosticScope scope1 = CreateScope(nameof(DuplicateScopeProperlyDisposed));
                scope1.Start();
                scope1.Dispose();
                using DiagnosticScope scope2 = CreateScope(nameof(DuplicateScopeProperlyDisposed));
                scope2.Start();
                return true;
            }

            public virtual Task<bool> WrongScopeAsync()
            {
                CreateAndFireScope("DoesNotExist");
                return Task.FromResult(true);
            }

            public virtual bool WrongScope()
            {
                CreateAndFireScope("DoesNotExist");
                return true;
            }

            public virtual Task<bool> CorrectScopeAsync()
            {
                CreateAndFireScope(nameof(CorrectScope));
                return Task.FromResult(true);
            }

            public virtual bool CorrectScope()
            {
                CreateAndFireScope(nameof(CorrectScope));
                return true;
            }

            [ForwardsClientCalls]
            public virtual Task<bool> ForwardsAsync()
            {
                CreateAndFireScope(nameof(CorrectScope));
                return Task.FromResult(true);
            }

            [ForwardsClientCalls]
            public virtual bool Forwards()
            {
                CreateAndFireScope(nameof(CorrectScope));
                return true;
            }

            public virtual AsyncPageable<int> GetPageableNoPageableScopesAsync()
            {
                CreateAndFireScope(nameof(GetPageableNoPageableScopesAsync));

                return PageResponseEnumerator.CreateAsyncEnumerable(s =>
                {
                    if (s == null)
                    {
                        return Task.FromResult(Page<int>.FromValues(new[] {1, 2, 3}, "1", new MockResponse(200)));
                    }

                    return Task.FromResult(Page<int>.FromValues(new[] {4, 5, 6}, null, new MockResponse(200)));
                });
            }

            public virtual Pageable<int> GetPageableNoPageableScopes()
            {
                CreateAndFireScope(nameof(GetPageableNoPageableScopes));

                return PageResponseEnumerator.CreateEnumerable(s =>
                {
                    if (s == null)
                    {
                        return Page<int>.FromValues(new[] {1, 2, 3}, "1", new MockResponse(200));
                    }

                    return Page<int>.FromValues(new[] {4, 5, 6}, null, new MockResponse(200));
                });
            }

            public virtual AsyncPageable<int> GetPageableValidScopesAsync()
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(s =>
                {
                    CreateAndFireScope(nameof(GetPageableValidScopes));

                    if (s == null)
                    {
                        return Task.FromResult(Page<int>.FromValues(new[] {1, 2, 3}, "1", new MockResponse(200)));
                    }

                    return Task.FromResult(Page<int>.FromValues(new[] {4, 5, 6}, null, new MockResponse(200)));
                });
            }

            public virtual Pageable<int> GetPageableValidScopes()
            {
                return PageResponseEnumerator.CreateEnumerable(s =>
                {
                    CreateAndFireScope(nameof(GetPageableValidScopes));

                    if (s == null)
                    {
                        return Page<int>.FromValues(new[] {1, 2, 3}, "1", new MockResponse(200));
                    }

                    return Page<int>.FromValues(new[] {4, 5, 6}, null, new MockResponse(200));
                });
            }
        }
    }
}
