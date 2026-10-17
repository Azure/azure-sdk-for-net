// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class ArmToolPageTokenTests
{
    private const string Scope = "/subscriptions/sub/resourceGroups/rg/providers/Example/widgets";
    private static readonly Uri Endpoint = new("https://management.example.test");

    [Test]
    public void ReturnedTokenResumesOnlyTheSameOperationScopeAndCloud()
    {
        var token = ArmToolPageToken.Wrap(Endpoint + Scope[1..] + "?skip=next", "Example.list", Scope, Endpoint);
        Assert.That(ArmToolPageToken.Resume(token, "Example.list", Scope, Endpoint),
            Is.EqualTo(Endpoint + Scope[1..] + "?skip=next"));
        Assert.That(() => ArmToolPageToken.Resume(token, "Example.other", Scope, Endpoint), Throws.ArgumentException);
        Assert.That(() => ArmToolPageToken.Resume(token, "Example.list", Scope.Replace("/rg/", "/other/"), Endpoint), Throws.ArgumentException);
        Assert.That(() => ArmToolPageToken.Resume(token, "Example.list", Scope, new Uri("https://other-cloud.test")), Throws.ArgumentException);
    }

    [TestCase("not-base64")]
    [TestCase("https://management.example.test/subscriptions/sub")]
    [TestCase("")]
    public void RawSdkUrlsAndInvalidTokensAreNotAccepted(string token)
    {
        Assert.That(() => ArmToolPageToken.Resume(token, "Example.list", Scope, Endpoint), Throws.ArgumentException);
    }

    [TestCase("//evil.test/path")]
    [TestCase("/other?skip=next")]
    [TestCase("/subscriptions/sub/resourceGroups/rg/providers/Example/widgets#fragment")]
    public void ForgedTokensCannotRedirectScopeOrAuthority(string path)
    {
        var token = Convert.ToBase64String(Encoding.UTF8.GetBytes("Example.list\n" + Scope + "\n" +
            Endpoint.GetLeftPart(UriPartial.Authority) + "\n" + path));
        Assert.That(() => ArmToolPageToken.Resume(token, "Example.list", Scope, Endpoint), Throws.ArgumentException);
    }

    [Test]
    public void SdkNextLinkOutsideConfiguredCloudIsRejected()
    {
        Assert.That(() => ArmToolPageToken.Wrap("https://other.test" + Scope, "Example.list", Scope, Endpoint),
            Throws.ArgumentException);
        Assert.That(ArmToolPageToken.Wrap(null, "Example.list", Scope, Endpoint), Is.Null);
        Assert.That(ArmToolPageToken.Resume(null, "Example.list", Scope, Endpoint), Is.Null);
    }
}
