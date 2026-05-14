// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

[TestFixture]
public class ServerVersionPolicyTests
{
    [Test]
    public void SetsUserAgentOnRequest()
    {
        var request = new MockPipelineRequest();
        var message = new HttpMessage(request, new ResponseClassifier());

        ServerVersionPolicy.ApplyUserAgent(message, "azure-ai-agentserver-responses/1.0.0 (dotnet/10.0)");

        Assert.That(request.TryGetHeaderValue("User-Agent", out var ua), Is.True);
        Assert.That(ua, Is.EqualTo("azure-ai-agentserver-responses/1.0.0 (dotnet/10.0)"));
    }

    [Test]
    public void PrependsToExistingUserAgent()
    {
        var request = new MockPipelineRequest();
        request.SetHeaderValue("User-Agent", "existing-ua/2.0");
        var message = new HttpMessage(request, new ResponseClassifier());

        ServerVersionPolicy.ApplyUserAgent(message, "myserver/1.0");

        Assert.That(request.TryGetHeaderValue("User-Agent", out var ua), Is.True);
        Assert.That(ua, Is.EqualTo("myserver/1.0 existing-ua/2.0"));
    }

    /// <summary>
    /// Minimal Request implementation backed by a dictionary for unit testing.
    /// </summary>
    private sealed class MockPipelineRequest : Request
    {
        private readonly Dictionary<string, string> _headers = new(StringComparer.OrdinalIgnoreCase);

        public override string ClientRequestId { get; set; } = Guid.NewGuid().ToString();

        public void SetHeaderValue(string name, string value) => _headers[name] = value;

        public bool TryGetHeaderValue(string name, out string? value)
        {
            if (_headers.TryGetValue(name, out var v))
            {
                value = v;
                return true;
            }
            value = null;
            return false;
        }

        protected override void AddHeader(string name, string value)
        {
            if (_headers.TryGetValue(name, out var existing))
            {
                _headers[name] = existing + "," + value;
            }
            else
            {
                _headers[name] = value;
            }
        }

        protected override bool ContainsHeader(string name) => _headers.ContainsKey(name);

        protected override IEnumerable<HttpHeader> EnumerateHeaders() =>
            _headers.Select(kvp => new HttpHeader(kvp.Key, kvp.Value));

        protected override bool RemoveHeader(string name) => _headers.Remove(name);

        protected override bool TryGetHeader(string name, out string? value)
        {
            if (_headers.TryGetValue(name, out var v))
            {
                value = v;
                return true;
            }
            value = null;
            return false;
        }

        protected override bool TryGetHeaderValues(string name, out IEnumerable<string>? values)
        {
            if (_headers.TryGetValue(name, out var v))
            {
                values = new[] { v };
                return true;
            }
            values = null;
            return false;
        }

        public override void Dispose() { }
    }
}
