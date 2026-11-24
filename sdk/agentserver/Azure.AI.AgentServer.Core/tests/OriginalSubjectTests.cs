// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

#pragma warning disable AAAS005 // Tests exercise experimental attribution.

namespace Azure.AI.AgentServer.Core.Tests;

public class OriginalSubjectTests
{
    [Test]
    public void Parse_PreservesOrderIndependentValuesAndEscapes()
    {
        var headers = new HeaderDictionary
        {
            ["x-ms-original-subject"] = " idtype=\"service\", tid=\"tenant\\\\id\", oid=\"ob\\\"ject\" ",
        };
        var subject = FoundryOriginalSubject.FromHeaders(headers)!;
        Assert.That(subject.ObjectId, Is.EqualTo("ob\"ject"));
        Assert.That(subject.TenantId, Is.EqualTo("tenant\\id"));
        Assert.That(subject.IdentityType, Is.EqualTo("service"));
        Assert.That(FoundryOriginalSubject.FromHeaders(new HeaderDictionary()), Is.Null);
        Assert.That(FoundryOriginalSubject.FromHeaders(new HeaderDictionary
        {
            ["x-ms-original-subject"] = "oid=\"\"",
        })!.ObjectId, Is.Empty);
    }

    [TestCase("")]
    [TestCase("oid=\"a\",")]
    [TestCase("oid=\"a\", oid=\"b\"")]
    [TestCase("unknown=\"a\"")]
    [TestCase("oid=a")]
    [TestCase("oid=\"a\";x=1")]
    [TestCase("oid=\"a\\q\"")]
    [TestCase("oid=\"a\r\nb\"")]
    [TestCase("oid=\"a\" tid=\"b\"")]
    public void Parse_RejectsMalformedValues(string value)
    {
        var headers = new HeaderDictionary { ["x-ms-original-subject"] = value };
        Assert.Throws<FormatException>(() => FoundryOriginalSubject.FromHeaders(headers));
    }

    [Test]
    public void Parse_RejectsDuplicateHeaderFields()
    {
        var headers = new HeaderDictionary
        {
            ["x-ms-original-subject"] = new StringValues(new[] { "oid=\"one\"", "tid=\"two\"" }),
        };
        Assert.Throws<FormatException>(() => FoundryOriginalSubject.FromHeaders(headers));
    }

    [Test]
    public void ModelHeaders_ReplaceStaleAssertionsWithoutMutatingInput()
    {
        var incoming = new Dictionary<string, string>
        {
            ["X-MS-Original-Subject"] = "stale",
            ["x-ms-original-subject-oid"] = "stale",
            ["X-Agent-Foundry-Call-Id"] = "stale",
            ["X-MS-Foundry-Baggage"] = "other=one,foundry.original_subject=old,foundry.original_subject.oid=old,other=two",
            ["x-example"] = "value",
        };
        var context = new FoundryAgentRequestContext
        {
            CallId = "current-call",
            UserId = "not-for-model",
            OriginalSubject = new FoundryOriginalSubject("a\"b", "c\\d", "service"),
        };

        var result = context.ModelAttributionHeaders(incoming);

        Assert.That(incoming["X-MS-Original-Subject"], Is.EqualTo("stale"));
        Assert.That(result.ContainsKey("x-ms-original-subject"), Is.False);
        Assert.That(result.ContainsKey("x-ms-original-subject-oid"), Is.False);
        Assert.That(result.ContainsKey("x-agent-user-id"), Is.False);
        Assert.That(result["x-agent-foundry-call-id"], Is.EqualTo("current-call"));
        Assert.That(result["x-example"], Is.EqualTo("value"));
        string[] baggage = result["x-ms-foundry-baggage"].Split(',');
        Assert.That(baggage, Has.Length.EqualTo(3));
        Assert.That(baggage[0], Does.StartWith("foundry.original_subject="));
        Assert.That(Uri.UnescapeDataString(baggage[0].Substring("foundry.original_subject=".Length)),
            Is.EqualTo("oid=\"a\\\"b\", tid=\"c\\\\d\", idtype=\"service\""));
        Assert.That(baggage[1..], Is.EqualTo(new[] { "other=one", "other=two" }));
        Assert.That(context.PlatformHeaders().Select(h => h.Key), Is.EqualTo(new[] { "x-agent-foundry-call-id" }));
    }

    [Test]
    public void ModelHeaders_SubjectFreeCallRemovesStaleAttribution()
    {
        var result = new FoundryAgentRequestContext { CallId = "not-emitted" }.ModelAttributionHeaders(
            new Dictionary<string, string>
            {
                ["x-ms-foundry-baggage"] = "%66oundry.original_subject=old,unrelated=ok",
                ["x-ms-original-subject"] = "old",
                ["x-agent-foundry-call-id"] = "old",
            });
        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result["x-ms-foundry-baggage"], Is.EqualTo("unrelated=ok"));
    }

    [TestCase(null, "tenant", "user")]
    [TestCase("", "tenant", "user")]
    [TestCase("white space", "tenant", "user")]
    [TestCase("object", "tenant\r\nx:1", "user")]
    [TestCase("object", "tenant", "us\u00e9r")]
    public void ModelHeaders_RejectsIncompleteOrUnsafeSubjects(string? oid, string? tid, string? idtype)
    {
        var context = new FoundryAgentRequestContext { OriginalSubject = new FoundryOriginalSubject(oid, tid, idtype) };
        Assert.Throws<InvalidOperationException>(() => context.ModelAttributionHeaders());
    }

    [Test]
    public void ModelHeaders_RejectsOversizedSubjectAndBaggage()
    {
        var oversized = new FoundryAgentRequestContext
        {
            OriginalSubject = new FoundryOriginalSubject(new string('a', 256), "tenant", "user"),
        };
        Assert.Throws<InvalidOperationException>(() => oversized.ModelAttributionHeaders());
        var context = new FoundryAgentRequestContext
        {
            OriginalSubject = new FoundryOriginalSubject("object", "tenant", "user"),
        };
        Assert.Throws<InvalidOperationException>(() => context.ModelAttributionHeaders(
            new Dictionary<string, string> { ["x-ms-foundry-baggage"] = "other=" + new string('x', 1024) }));
    }

    [Test]
    public async Task Middleware_IsolatesConcurrentRequestsAndRejectsMalformedMetadata()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        await using var app = builder.Build();
        app.UseAgentServerCore();
        app.MapGet("/test", async () =>
        {
            await Task.Delay(20);
            return FoundryAgentRequestContext.Current.OriginalSubject?.ObjectId ?? "none";
        });
        await app.StartAsync();
        using var client = app.GetTestClient();

        async Task<string> SendAsync(string? value)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "/test");
            if (value is not null)
            {
                request.Headers.TryAddWithoutValidation("x-ms-original-subject", value);
            }
            return await (await client.SendAsync(request)).Content.ReadAsStringAsync();
        }

        var results = await Task.WhenAll(SendAsync("oid=\"one\""), SendAsync("oid=\"two\""), SendAsync(null));
        Assert.That(results, Is.EqualTo(new[] { "one", "two", "none" }));
        using var bad = new HttpRequestMessage(HttpMethod.Get, "/test");
        bad.Headers.TryAddWithoutValidation("x-ms-original-subject", "oid=invalid");
        using var response = await client.SendAsync(bad);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(response.Headers.GetValues("x-platform-error-source"), Does.Contain("platform"));
        Assert.That(response.Headers.GetValues("x-platform-error-detail"), Does.Contain("invalid_original_subject"));
        Assert.That(response.Headers.GetValues(PlatformHeaders.RequestId), Is.Not.Empty);
        Assert.That(response.Headers.GetValues(PlatformHeaders.ServerVersion), Is.Not.Empty);
        Assert.That(FoundryAgentRequestContext.Current.OriginalSubject, Is.Null);
    }
}
