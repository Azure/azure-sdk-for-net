// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.ClientConstructorAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0021Tests
    {
        [Test]
        public async Task AZC0021ProducedForClientSettingsCtorWithAdditionalParameter()
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
        public {|AZC0021:SomeClient|}(string connectionString, SomeClientSettings settings) {}
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0021NotProducedForClientSettingsCtorWithSingleParameter()
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
    }
}
