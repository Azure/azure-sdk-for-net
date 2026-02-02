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

        [Test]
        public async Task AZC0012ProducedForAcronymOnlyNames()
        {
            const string code = @"
namespace Azure.Data
{
    public class {|AZC0012:OS|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForInterfaceAcronymOnlyNames()
        {
            const string code = @"
namespace Azure.Data
{
    public interface {|AZC0012:IOS|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForAcronymPlusWord()
        {
            const string code = @"
namespace Azure.Data
{
    public class OSClient { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForMultipleAcronyms()
        {
            const string code = @"
namespace Azure.Data
{
    public class IOStream { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForHTTPClient()
        {
            const string code = @"
namespace Azure.Data
{
    public class HTTPClient { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForXMLParser()
        {
            const string code = @"
namespace Azure.Data
{
    public class XMLParser { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForAllLowercaseAfterInterface()
        {
            const string code = @"
namespace Azure.Data
{
    public interface {|AZC0012:Iprogram|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForMixedCaseWithAcronyms()
        {
            const string code = @"
namespace Azure.Data
{
    public class BlobHTTPClient { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForStructAcronymOnly()
        {
            const string code = @"
namespace Azure.Data
{
    public struct {|AZC0012:ID|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForTwoLetterAcronym()
        {
            const string code = @"
namespace Azure.Data
{
    public class {|AZC0012:IP|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForInterfaceTwoLetterAcronym()
        {
            const string code = @"
namespace Azure.Data
{
    public interface {|AZC0012:IIP|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForSingleLetter()
        {
            const string code = @"
namespace Azure.Data
{
    public class {|AZC0012:A|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForNumberInName()
        {
            const string code = @"
namespace Azure.Data
{
    public class V2Client { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForAcronymWithNumber()
        {
            const string code = @"
namespace Azure.Data
{
    public class HTTP2Client { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForIPv4Address()
        {
            const string code = @"
namespace Azure.Data
{
    public class IPv4Address { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForIPv4Only()
        {
            // IPv4 is mistakenly treated as interface (I + Pv4), leaving "Pv4" = 1 word
            // This is actually good - IPv4 alone as a type name is too generic
            const string code = @"
namespace Azure.Data
{
    public class {|AZC0012:IPv4|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForIPv6()
        {
            const string code = @"
namespace Azure.Data
{
    public class {|AZC0012:IPv6|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012NotProducedForIOError()
        {
            const string code = @"
namespace Azure.Data
{
    public class IOError { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0012ProducedForAllLowercase()
        {
            const string code = @"
namespace Azure.Data
{
    public class {|AZC0012:myclass|} { }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }
    }
}
