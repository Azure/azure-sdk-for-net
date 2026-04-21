// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

[TestFixture]
public class FoundryStorageLoggingPolicyTests
{
    [Test]
    public void MaskStorageUrl_RedactsProjectPathAndKeepsStorageSegment()
    {
        var url = "https://acct.services.ai.azure.com/api/projects/myproj/storage/responses/resp_123";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/responses/resp_123"));
    }

    [Test]
    public void MaskStorageUrl_StripsQueryParamsExceptApiVersion()
    {
        var url = "https://acct.services.ai.azure.com/api/projects/myproj/storage/responses/resp_123?api-version=2025-01-01&token=secret";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/responses/resp_123?api-version=2025-01-01"));
    }

    [Test]
    public void MaskStorageUrl_StripsAllQueryParamsWhenNoApiVersion()
    {
        var url = "https://acct.services.ai.azure.com/api/projects/myproj/storage/responses/resp_123?token=secret&other=val";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/responses/resp_123"));
    }

    [Test]
    public void MaskStorageUrl_PreservesApiVersionOnly()
    {
        var url = "https://host/proj/storage/data?other=1&api-version=2024-06-01&extra=2";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/data?api-version=2024-06-01"));
    }

    [Test]
    public void MaskStorageUrl_RedactsWhenNoStorageSegment()
    {
        var url = "https://acct.services.ai.azure.com/api/projects/myproj/other/path";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("(redacted)"));
    }

    [Test]
    public void MaskStorageUrl_ReturnsRedactedForNull()
    {
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(null), Is.EqualTo("(redacted)"));
    }

    [Test]
    public void MaskStorageUrl_ReturnsRedactedForEmpty()
    {
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(""), Is.EqualTo("(redacted)"));
    }

    [Test]
    public void MaskStorageUrl_HandlesStorageAtRoot()
    {
        var url = "https://host/storage/items/item_1";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/items/item_1"));
    }

    [Test]
    public void MaskStorageUrl_CaseInsensitiveApiVersionParam()
    {
        var url = "https://host/proj/storage/data?Api-Version=2024-06-01";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/data?Api-Version=2024-06-01"));
    }
}
