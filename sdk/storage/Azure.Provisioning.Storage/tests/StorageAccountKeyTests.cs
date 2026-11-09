// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Provisioning.Storage.Tests;

public class StorageAccountKeyTests
{
    [TestCase(0)]
    [TestCase(1)]
    public void UnwrapKeyPreservesPropertyExpressions(int index)
    {
        StorageAccount storage = new("storageVolume")
        {
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
            Kind = StorageKind.StorageV2,
            LargeFileSharesState = LargeFileSharesState.Enabled
        };

        StorageAccountKey key = storage.GetKeys()[index].Unwrap();
        BicepValue<string> value = key.Value;

        Assert.That(((IBicepValue)key).Compile().ToString(),
            Is.EqualTo($"storageVolume.listKeys().keys[{index}]"));
        Assert.That(value.Compile().ToString(),
            Is.EqualTo($"storageVolume.listKeys().keys[{index}].value"));
        Assert.That(((IBicepValue)value).Kind, Is.EqualTo(BicepValueKind.Expression));
        Assert.That(((IBicepValue)value).IsSecure, Is.True);
    }
}
