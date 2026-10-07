// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.ClientConstructorAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0005Tests
    {
        [Test]
        public async Task AZC0005ProducedForClientWithOnlyClientSettingsAndNoParameterlessCtor()
        {
            const string code = @"
namespace System.ClientModel.Primitives
{
    public class ClientSettings {}
}

namespace RandomNamespace
{
    public class SomeClientSettings : System.ClientModel.Primitives.ClientSettings {}

    public class {|AZC0005:SomeClient|}
    {
        public SomeClient(SomeClientSettings settings) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

#if !NETFRAMEWORK // Deriving from Azure.Core.ClientOptions requires netstandard2.0+ support (net472+)
        [Test]
        public async Task AZC0005ProducedForClientTypesWithoutProtectedCtor()
        {
            const string code = @"
namespace RandomNamespace
{
    public class SomeClientOptions : Azure.Core.ClientOptions { }

    public class {|AZC0005:SomeClient|}
    {
        public SomeClient(string connectionString) {}
        public SomeClient(string connectionString, SomeClientOptions options) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }
#endif
    }
}
