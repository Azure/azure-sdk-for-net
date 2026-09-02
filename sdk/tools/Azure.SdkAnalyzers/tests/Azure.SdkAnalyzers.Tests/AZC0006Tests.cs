// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.ClientConstructorAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0006Tests
    {
#if !NETFRAMEWORK // Deriving from Azure.Core.ClientOptions requires netstandard2.0+ support (net472+)
        [Test]
        public async Task AZC0006ProducedForClientsWithoutOptionsCtor()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientOptions : Azure.Core.ClientOptions { }

    public class SomeClient
    {
        protected SomeClient() {}
        public {|AZC0006:SomeClient|}(SomeClientOptions options) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0006ProducedForClientsWithoutOptionsCtorWithArguments()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientOptions : Azure.Core.ClientOptions { }

    public class SomeClient
    {
        protected SomeClient() {}
        public {|AZC0006:SomeClient|}(string connectionString, SomeClientOptions options) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0006NotProducedWhenOptionsParameterIsOptional()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientOptions : Azure.Core.ClientOptions { }

    public class SomeClient
    {
        protected SomeClient() {}
        public SomeClient(string connectionString, SomeClientOptions options = null) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0006NotProducedForSharedClientOptions()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SharedClientOptions : Azure.Core.ClientOptions { }

    public class SomeClient
    {
        protected SomeClient() {}
        public SomeClient(string connectionString, SharedClientOptions options = null) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0006NotProducedForClientsOptions()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientsOptions : Azure.Core.ClientOptions { } // 'ClientsOptions' suffix instead of 'ClientOptions'

    public class SomeClient
    {
        protected SomeClient() {}
        public SomeClient(string connectionString, SomeClientsOptions options = null) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0006NotProducedForClientsWithStaticProperties()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientOptions : Azure.Core.ClientOptions { }

    public class SomeClient
    {
        public static int a = 1;
        public SomeClient() {}
        public SomeClient(SomeClientOptions options) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        // Regression for azure-sdk-tools#127: a required-options constructor and its non-options
        // overload differ only in a parameter name (Storage's BlockBlobClient uses "containerName"
        // on one and "blobContainerName" on the other). Overload equivalence is by type, not name,
        // so neither AZC0006 nor AZC0007 should fire.
        [Test]
        public async Task AZC0006NotProducedWhenOverloadDiffersOnlyByParameterName()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientOptions : Azure.Core.ClientOptions { }

    public class SomeClient
    {
        protected SomeClient() {}
        public SomeClient(string connectionString, string containerName, string blobName) {}
        public SomeClient(string connectionString, string blobContainerName, string blobName, SomeClientOptions options) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        // Parameter ref-kind (ref/out/in) is part of the constructor signature, so overloads that
        // differ only by a ref modifier are NOT equivalent and must not be paired: the minimal ctor
        // still lacks a matching options overload (AZC0007) and the options ctor still lacks a
        // matching non-options overload (AZC0006).
        [Test]
        public async Task AZC0006AndAZC0007ProducedWhenOverloadsDifferOnlyByRefModifier()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientOptions : Azure.Core.ClientOptions { }

    public class SomeClient
    {
        protected SomeClient() {}
        public {|AZC0007:SomeClient|}(int x) {}
        public {|AZC0006:SomeClient|}(ref int x, SomeClientOptions options) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }
#endif
    }
}
