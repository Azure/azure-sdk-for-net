// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.ClientConstructorAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0007Tests
    {
        [Test]
        public async Task AZC0007ProducedForClientsWithoutOptionsCtor()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClient
    {
        public {|AZC0007:SomeClient|}() {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0007ProducedForClientsWithoutOptionsCtorWithArguments()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClient
    {
        protected SomeClient() {}
        public {|AZC0007:SomeClient|}(string connectionString) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0007ProducedForClientsWithOptionsNotDerivedFromClientOptions()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientOptions { }

    public class SomeClient
    {
        protected SomeClient() {}
        public {|AZC0007:SomeClient|}(string connectionString, SomeClientOptions options) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

#if !NETFRAMEWORK // Deriving from Azure.Core.ClientOptions requires netstandard2.0+ support (net472+)
        [Test]
        public async Task AZC0007NotProducedForClientsWithDefaultOptionsCtorWithArguments()
        {
            const string code = @"
namespace RandomNamespace
{
    using System;

    public class SomeClientOptions : Azure.Core.ClientOptions {}

    public class SomeClient
    {
        protected SomeClient() {}
        public SomeClient(string connectionString, SomeClientOptions clientOptions = default) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0007NotProducedForClientWithMultipleCtors()
        {
            const string code = @"
using System;
using Azure;
using Azure.Core;

namespace RandomNamespace.Foo
{
    public partial class RoomsClientOptions : ClientOptions {}

    public partial class RoomsClient
    {
        protected RoomsClient() {}
        public RoomsClient(string connectionString) {}
        public RoomsClient(string connectionString, RoomsClientOptions options) {}
        public RoomsClient(Uri endpoint, AzureKeyCredential credential, RoomsClientOptions options = null) {}
        public RoomsClient(Uri endpoint, TokenCredential credential, RoomsClientOptions options = null) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }
#endif

        [Test]
        public async Task AZC0007NotProducedForClientWithClientSettings()
        {
            const string code = @"
namespace System.ClientModel.Primitives
{
    public class ClientSettings {}
}

namespace RandomNamespace
{
    public class SomeClientSettings : System.ClientModel.Primitives.ClientSettings {}

    public class SomeClient
    {
        protected SomeClient() {}
        public SomeClient(SomeClientSettings settings) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

#if !NETFRAMEWORK // Deriving from Azure.Core.ClientOptions requires netstandard2.0+ support (net472+)
        [Test]
        public async Task AZC0007NotProducedForClientWithClientSettingsAndOtherOverloads()
        {
            const string code = @"
namespace System.ClientModel.Primitives
{
    public class ClientSettings {}
}

namespace RandomNamespace
{
    using Azure.Core;

    public class SomeClientOptions : ClientOptions {}
    public class SomeClientSettings : System.ClientModel.Primitives.ClientSettings {}

    public class SomeClient
    {
        protected SomeClient() {}
        public SomeClient(string connectionString) {}
        public SomeClient(string connectionString, SomeClientOptions options) {}
        public SomeClient(SomeClientSettings settings) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }
#endif

        [Test]
        public async Task AZC0007ProducedForClientWithClientSettingsButMissingOptionsOverload()
        {
            const string code = @"
namespace System.ClientModel.Primitives
{
    public class ClientSettings {}
}

namespace RandomNamespace
{
    public class SomeClientSettings : System.ClientModel.Primitives.ClientSettings {}

    public class SomeClient
    {
        protected SomeClient() {}
        public {|AZC0007:SomeClient|}(string connectionString) {}
        public SomeClient(SomeClientSettings settings) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0007NotProducedForClientWithMultipleClientSettingsOverloads()
        {
            const string code = @"
namespace System.ClientModel.Primitives
{
    public class ClientSettings {}
}

namespace RandomNamespace
{
    using System;
    using Azure;

    public class SomeClientSettings : System.ClientModel.Primitives.ClientSettings {}
    public class AnotherClientSettings : System.ClientModel.Primitives.ClientSettings {}

    public class SomeClient
    {
        protected SomeClient() {}
        public SomeClient(SomeClientSettings settings) {}
        public SomeClient(AnotherClientSettings settings) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0007ProducedForClientsWithSettingsNotDerivedFromClientSettings()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientSettings { }

    public class SomeClient
    {
        protected SomeClient() {}
        public {|AZC0007:SomeClient|}(SomeClientSettings settings) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

#if !NETFRAMEWORK // Deriving from Azure.Core.ClientOptions requires netstandard2.0+ support (net472+)
        // Regression for azure-sdk-tools#127: a sub-client constructed from another client
        // (Storage's BlobLeaseClient takes a BlobBaseClient/BlobContainerClient plus an optional
        // lease id) inherits its configuration from that client and has no service-connection or
        // options overload, so AZC0007 should not fire.
        [Test]
        public async Task AZC0007NotProducedForSubClientConstructedFromAnotherClient()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientOptions : Azure.Core.ClientOptions { }

    public class ParentClient
    {
        protected ParentClient() {}
        public ParentClient(string connectionString) {}
        public ParentClient(string connectionString, SomeClientOptions options) {}
    }

    public class LeaseClient
    {
        protected LeaseClient() {}
        public LeaseClient(ParentClient client, string leaseId = null) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        // Regression: overload matching must distinguish generic parameter types by their full
        // identity, not just metadata name + arity. Two generic types with the same name and arity
        // in different namespaces (NsA.Wrapper<string> vs NsB.Wrapper<string>) must NOT be treated
        // as equivalent, otherwise the analyzer wrongly pairs the constructors and suppresses the
        // AZC0006/AZC0007 diagnostics that should fire.
        [Test]
        public async Task AZC0007AndAZC0006ProducedWhenGenericParametersDifferOnlyByNamespace()
        {
            const string code = @"
namespace NsA { public class Wrapper<T> { } }
namespace NsB { public class Wrapper<T> { } }

namespace RandomNamespace
{
    public class SomeClientOptions : Azure.Core.ClientOptions { }

    public class SomeClient
    {
        protected SomeClient() {}
        public {|AZC0007:SomeClient|}(NsA.Wrapper<string> w) {}
        public {|AZC0006:SomeClient|}(NsB.Wrapper<string> w, SomeClientOptions options) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }
#endif
    }
}
