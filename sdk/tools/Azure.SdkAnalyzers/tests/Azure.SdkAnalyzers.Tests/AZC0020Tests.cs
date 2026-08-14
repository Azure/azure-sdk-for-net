// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.RequestContextCancellationTokenAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0020Tests
    {
        [Test]
        public async Task AZC0020ProducedForMissingCancellationToken()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                {|AZC0020:new RequestContext()|});
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020NotProducedWhenCancellationTokenPropagated()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                new RequestContext { CancellationToken = cancellationToken });
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020NotProducedWhenMethodHasNoCancellationToken()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync()
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                new RequestContext());
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020NotProducedForNonAzureSdkApi()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class MyClient
    {
        public async Task UpdateAsync(string content, RequestContext context)
        {
            return;
        }
    }

    public class MyService
    {
        private MyClient _client = new MyClient();

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _client.UpdateAsync(""test"", new RequestContext());
        }
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020NotProducedWhenRequestContextFromParameter()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync(CancellationToken cancellationToken, RequestContext context)
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                context);
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020NotProducedWhenRequestContextFromLocal()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                context);
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020ProducedWhenCancellationTokenNotSet()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                {|AZC0020:new RequestContext { ErrorOptions = ErrorOptions.Default }|});
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
        public ErrorOptions ErrorOptions { get; set; }
    }

    public enum ErrorOptions
    {
        Default
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020ProducedWhenCancellationTokenSetToNone()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                {|AZC0020:new RequestContext { CancellationToken = CancellationToken.None }|});
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020ProducedForMultipleInvocations()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }

        public async Task<Response> DeleteAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task ProcessAsync(CancellationToken cancellationToken)
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                {|AZC0020:new RequestContext()|});
                
            await _client.DeleteAsync(
                BinaryData.FromString(""test""),
                {|AZC0020:new RequestContext()|});
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020NotProducedInLambdaWithoutCancellationToken()
        {
            const string code = @"
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task ProcessAsync(CancellationToken cancellationToken)
        {
            Func<Task> action = async () =>
            {
                await _client.UpdateAsync(
                    BinaryData.FromString(""test""),
                    new RequestContext());
            };
            
            await action();
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020ProducedInLambdaWithCancellationToken()
        {
            const string code = @"
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task ProcessAsync()
        {
            Func<CancellationToken, Task> action = async (cancellationToken) =>
            {
                await _client.UpdateAsync(
                    BinaryData.FromString(""test""),
                    {|AZC0020:new RequestContext()|});
            };
            
            await action(CancellationToken.None);
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020NotProducedWhenUsingToRequestContextExtension()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                cancellationToken.ToRequestContext());
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }

    public static class CancellationTokenExtensions
    {
        public static RequestContext ToRequestContext(this CancellationToken cancellationToken) 
            => cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020NotProducedWhenUsingCustomHelperMethod()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                CreateContext(cancellationToken));
        }

        private RequestContext CreateContext(CancellationToken token)
        {
            return new RequestContext { CancellationToken = token };
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0020ProducedForMicrosoftAzureNamespace()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Microsoft.Azure.Sample
{
    public class SampleClient
    {
        public async Task<Response> UpdateAsync(BinaryData content, RequestContext context = null)
        {
            return null;
        }
    }
}

namespace MyApp
{
    using Microsoft.Azure.Sample;

    public class MyService
    {
        private SampleClient _client = new SampleClient();

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _client.UpdateAsync(
                BinaryData.FromString(""test""),
                {|AZC0020:new RequestContext()|});
        }
    }
}

namespace Azure
{
    public class RequestContext
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public class Response { }

    public class BinaryData
    {
        public static BinaryData FromString(string s) => new BinaryData();
    }
}
";

            await Verifier.VerifyAnalyzerAsync(code);
        }
    }
}
