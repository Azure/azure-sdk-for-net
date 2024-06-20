// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MemoryStorageResourceTests
    {
        [Test]
        public async Task MemoryItemCopyFromStream([Values(true, false)] bool overwrite)
        {
            Random r = new Random();
            byte[] data = new byte[r.Next(1, 9999)];
            r.NextBytes(data);

            MemoryStorageResourceItem item = new();

            await item.CopyFromStreamAsync(
                new MemoryStream(data),
                data.Length,
                overwrite,
                data.Length);

            Assert.That(item.Buffer.ToArray(), Is.EquivalentTo(data));
        }

        [Test]
        public async Task MemoryItemCopyFromStreamOverwrite()
        {
            Random r = new Random();
            byte[] oldData = new byte[r.Next(1, 9999)];
            byte[] newData = new byte[r.Next(1, 9999)];
            r.NextBytes(oldData);
            r.NextBytes(newData);

            MemoryStorageResourceItem item = new()
            {
                Buffer = new Memory<byte>(oldData)
            };

            await item.CopyFromStreamAsync(
                new MemoryStream(newData),
                newData.Length,
                overwrite: true,
                newData.Length);

            Assert.That(item.Buffer.ToArray(), Is.EquivalentTo(newData));
        }

        [Test]
        public async Task MemoryItemDeleteIfExists([Values(true, false)] bool alreadyExists)
        {
            Random r = new Random();
            byte[] data = new byte[r.Next(1, 9999)];
            r.NextBytes(data);

            MemoryStorageResourceItem item = new()
            {
                Buffer = alreadyExists ? new Memory<byte>(data) : Memory<byte>.Empty
            };

            bool deleted = await item.DeleteIfExistsAsync();

            Assert.That(deleted, Is.EqualTo(alreadyExists));
        }

        [Test]
        public async Task MemoryItemReadStream(
            [Values(true, false)] bool nonZeroOffset,
            [Values(true, false)] bool sliceLength)
        {
            Random r = new Random();
            byte[] data = new byte[r.Next(1024, 4096)];
            r.NextBytes(data);

            MemoryStorageResourceItem item = new()
            {
                Buffer = new Memory<byte>(data)
            };

            int position = nonZeroOffset ? r.Next(r.Next(data.Length / 3, data.Length * 2 / 3)) : 0;
            int? length = sliceLength ? r.Next(1, data.Length - position) : null;

            MemoryStream dest = new MemoryStream();
            await (await item.ReadStreamAsync(position, length)).Content.CopyToAsync(dest);

            Memory<byte> expectedData = length.HasValue
                ? new Memory<byte>(data).Slice(position, length.Value)
                : new Memory<byte>(data).Slice(position);
            Assert.That(dest.ToArray(), Is.EquivalentTo(expectedData.ToArray()));
        }

        [Test]
        public async Task MemoryContainerEnumerate([Values(true, false)] bool returnsContainers)
        {
            const string baseUri = "memory://localhost/my/path";
            List<StorageResource> allChildren = new();

            MemoryStorageResourceContainer baseContainer = new(new Uri(baseUri))
            {
                ReturnsContainersOnEnumeration = returnsContainers,
            };

            MemoryStorageResourceItem child1 = new(new Uri(baseUri + "/item"));
            baseContainer.Children.Add(child1);
            allChildren.Add(child1);

            MemoryStorageResourceContainer child2 = new(new Uri(baseUri + "/container"));
            baseContainer.Children.Add(child2);
            allChildren.Add(child2);

            MemoryStorageResourceItem child2_1 = new(new Uri(baseUri + "/container/item1"));
            child2.Children.Add(child1);
            allChildren.Add(child1);

            MemoryStorageResourceItem child2_2 = new(new Uri(baseUri + "/container/item2"));
            child2.Children.Add(child2_2);
            allChildren.Add(child2_2);

            MemoryStorageResourceContainer child2_3 = new(new Uri(baseUri + "/container/container3"));
            child2.Children.Add(child2_3);
            allChildren.Add(child2_3);

            List<StorageResource> result = new();
            await foreach (StorageResource resource in baseContainer.GetStorageResourcesAsync())
            {
                result.Add(resource);
            }

            List<StorageResource> expected = allChildren
                .Where(sr => returnsContainers ? true : sr is MemoryStorageResourceItem)
                .ToList();
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void MemoryContainerGetResource()
        {
            const string baseUri = "memory://localhost/my/path";
            List<StorageResource> allChildren = new();

            MemoryStorageResourceContainer baseContainer = new(new Uri(baseUri));

            MemoryStorageResourceItem foo = new(new Uri(baseUri + "/foo"));
            baseContainer.Children.Add(foo);

            MemoryStorageResourceContainer fizz = new(new Uri(baseUri + "/fizz"));
            baseContainer.Children.Add(fizz);

            MemoryStorageResourceItem buzz = new(new Uri(baseUri + "/fizz/buzz"));
            fizz.Children.Add(buzz);

            Assert.That(baseContainer.GetStorageResourceReference("foo", default), Is.EqualTo(foo));
            Assert.That(baseContainer.GetStorageResourceReference("fizz/buzz", default), Is.EqualTo(buzz));
        }
    }
}
