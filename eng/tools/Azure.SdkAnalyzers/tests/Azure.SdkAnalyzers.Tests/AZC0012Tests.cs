// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.TypeNameAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0012Tests
    {
        [Test]
        public async Task AZC0012ProducedForSingleWordTypeNames()
        {
            const string code = @"
namespace Azure.Data
{
    public class {|AZC0012:Program|} { }
}";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForSingleWordInterfaceNames()
        {
            const string code = @"
namespace Azure.Data
{
    public interface {|AZC0012:IProgram|} { }
}";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForNonPublicTypes()
        {
            const string code = @"
namespace Azure.Data
{
    internal class Program { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForMultiWordTypes()
        {
            const string code = @"
namespace Azure.Data
{
    public class NiceProgram { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForNestedTypes()
        {
            const string code = @"
namespace Azure.Data
{
    public class NiceProgram {
        public class Wow { }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForNestedInterfaces()
        {
            const string code = @"
namespace Azure.Data
{
    public class NiceProgram {
        public interface IWow { }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForSingleWordStructNames()
        {
            const string code = @"
namespace Azure.Data
{
    public struct {|AZC0012:Point|} { }
}";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForMultiWordStructs()
        {
            const string code = @"
namespace Azure.Data
{
    public struct DataPoint { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForNonPublicStructs()
        {
            const string code = @"
namespace Azure.Data
{
    internal struct Point { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForNestedStructs()
        {
            const string code = @"
namespace Azure.Data
{
    public class NiceProgram {
        public struct Point { }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }
    }
}
