// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.ClientMethodSyncAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0004Tests
    {
        [Test]
        public async Task AZC0004ProducedForMethodWithoutSyncAlternative()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;

namespace RandomNamespace
{
    public class SomeClient
    {
        public virtual Task {|AZC0004:GetAsync|}(CancellationToken cancellationToken = default)
        {
            return null;
        }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004NotProducedForMethodWithSyncAlternative()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;

namespace RandomNamespace
{
    public class SomeClient
    {
        public virtual Task GetAsync(CancellationToken cancellationToken = default) => null;
        public virtual void Get(CancellationToken cancellationToken = default) { }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004NotProducedForAsyncStreamingMethod()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel
{
    public abstract class AsyncStreamingClientResult<T> { }
}

namespace RandomNamespace
{
    public class SomeClient
    {
        public virtual Task<System.ClientModel.AsyncStreamingClientResult<string>> StreamAsync(
            CancellationToken cancellationToken = default) => null;
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004NotProducedForDerivedAsyncStreamingMethod()
        {
            const string code = @"
using System.Threading.Tasks;

namespace System.ClientModel
{
    public abstract class AsyncStreamingClientResult<T> { }
}

namespace RandomNamespace
{
    public sealed class CustomStreamingResult<T> : System.ClientModel.AsyncStreamingClientResult<T> { }

    public class SomeClient
    {
        public virtual Task<CustomStreamingResult<string>> StreamAsync() => null;
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004ProducedForSameNamedStreamingTypeFromAnotherNamespace()
        {
            const string code = @"
using System.Threading.Tasks;

namespace OtherNamespace
{
    public abstract class AsyncStreamingClientResult<T> { }
}

namespace RandomNamespace
{
    public class SomeClient
    {
        public virtual Task<OtherNamespace.AsyncStreamingClientResult<string>> {|AZC0004:StreamAsync|}() => null;
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004ProducedForDirectAsyncStreamingReturnType()
        {
            const string code = @"
namespace System.ClientModel
{
    public abstract class AsyncStreamingClientResult<T> { }
}

namespace RandomNamespace
{
    public class SomeClient
    {
        public virtual System.ClientModel.AsyncStreamingClientResult<string> {|AZC0004:StreamAsync|}() => null;
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004ProducedForUserDefinedTaskOfStreamingResult()
        {
            const string code = @"
namespace System.ClientModel
{
    public abstract class AsyncStreamingClientResult<T> { }
}

namespace RandomNamespace
{
    public class Task<T> { }

    public class SomeClient
    {
        public virtual Task<System.ClientModel.AsyncStreamingClientResult<string>> {|AZC0004:StreamAsync|}() => null;
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004NotProducedForMatchingGenericMethod()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;

namespace RandomNamespace
{
    public class SomeClient
    {
        public virtual Task GetAsync<T>(T item, CancellationToken cancellationToken = default) => null;
        public virtual void Get<T>(T item, CancellationToken cancellationToken = default) { }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [TestCase("public void Get<T>(string item, CancellationToken cancellationToken = default) { }")]
        [TestCase("public void Get<TItem>(TItem item, CancellationToken cancellationToken = default) { }")]
        [TestCase("public void Get<T>(T differentName, CancellationToken cancellationToken = default) { }")]
        [TestCase("public void Get<T>(ref T item, CancellationToken cancellationToken = default) { }")]
        [TestCase("private void Get<T>(T item, CancellationToken cancellationToken = default) { }")]
        public async Task AZC0004ProducedForNonMatchingGenericMethod(string syncMethod)
        {
            string code = $@"
using System.Threading;
using System.Threading.Tasks;

namespace RandomNamespace
{{
    public class SomeClient
    {{
        public virtual Task {{|AZC0004:GetAsync|}}<T>(T item, CancellationToken cancellationToken = default) => null;
        {syncMethod}
    }}
}}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004NotProducedForNestedGenericParameterMatch()
        {
            const string code = @"
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RandomNamespace
{
    public class SomeClient
    {
        public virtual Task QueryAsync<T>(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default) => null;

        public virtual void Query<T>(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default) { }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004ProducedForDifferentNestedGenericParameter()
        {
            const string code = @"
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RandomNamespace
{
    public class SomeClient
    {
        public virtual Task {|AZC0004:QueryAsync|}<T>(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default) => null;

        public virtual void Query<T>(
            Expression<Func<T, string, bool>> filter,
            CancellationToken cancellationToken = default) { }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [TestCase("Pipeline")]
        [TestCase("PipelineAsync")]
        public async Task AZC0004NotProducedForProperties(string propertyName)
        {
            string code = $@"
namespace RandomNamespace
{{
    public class SomeClient
    {{
        public virtual object {propertyName} => null;
    }}
}}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0004NotProducedForClientNestedInNonPublicType()
        {
            const string code = @"
using System.Threading.Tasks;

namespace RandomNamespace
{
    internal class Outer
    {
        public class SomeClient
        {
            public virtual Task GetAsync() => null;
        }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }
    }
}
