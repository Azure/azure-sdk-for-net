// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Shared stubs / common state used across the per-article snippet files.
// These let the doc snippets compile as-is by providing the variables that
// the docs assume exist in the surrounding context.

using System;
using Azure.Compute.Batch;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;

namespace BatchDocSamples;

internal static class Stubs
{
    public const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
    public const string ResourceGroupName = "rg";
    public const string AccountName = "acct";
    public const string BatchAccountUrl = "https://acct.eastus.batch.azure.com";

    public static readonly TokenCredential Credential = new DefaultAzureCredential();
    public static readonly ArmClient ArmClient = new ArmClient(Credential);
    public static readonly BatchClient BatchClient = new BatchClient(new Uri(BatchAccountUrl), Credential);

    public static readonly ResourceIdentifier BatchAccountResourceId =
        BatchAccountResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, AccountName);

    public static BatchAccountResource GetBatchAccount() => ArmClient.GetBatchAccountResource(BatchAccountResourceId);

    public static BatchAccountPoolCollection GetPoolCollection() => GetBatchAccount().GetBatchAccountPools();
}
