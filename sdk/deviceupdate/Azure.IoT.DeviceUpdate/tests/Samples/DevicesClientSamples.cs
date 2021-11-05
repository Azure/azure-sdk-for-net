// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.IoT.DeviceUpdate.Models;
using NUnit.Framework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    /// <summary>
    /// Device management samples
    /// </summary>
    /// <seealso cref="SamplesBase{ServiceClientTestEnvironment}"/>
    public class DevicesClientSamples : SamplesBase<ServiceClientTestEnvironment>
    {
        private DevicesClient CreateClient()
        {
            return new DevicesClient(
                TestEnvironment.AccountEndpoint,
                TestEnvironment.InstanceId,
                TestEnvironment.Credential);
        }

        [Test]
        public async Task GetAllDeviceClasses()
        {
            var client = CreateClient();
            AsyncPageable<DeviceClass> response = client.GetAllDeviceClassesAsync();
            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetDeviceClass()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var response = await client.GetDeviceClassAsync(expected.DeviceClassId);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            var actual = response.Value;
            Assert.AreEqual(expected.Provider, actual.Manufacturer);
            Assert.AreEqual(expected.Model, actual.Model);
        }

        [Test]
        public async Task GetDeviceClass_NotFound()
        {
            var client = CreateClient();
            try
            {
                await client.GetDeviceClassAsync("foo");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetDeviceClassDeviceIds()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            AsyncPageable<string> response = client.GetDeviceClassDeviceIdsAsync(expected.DeviceClassId);
            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetDeviceClassDeviceIds_NotFound()
        {
            var client = CreateClient();
            AsyncPageable<string> response = client.GetDeviceClassDeviceIdsAsync("foo");
            Assert.IsNotNull(response);
            try
            {
                await foreach (var _ in response)
                { }
                Assert.Fail("Should have thrown 404");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetDeviceClassInstallableUpdates()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            AsyncPageable<UpdateId> response = client.GetDeviceClassInstallableUpdatesAsync(expected.DeviceClassId);
            Assert.IsNotNull(response);
            var list = new List<UpdateId>();
            await foreach (var item in response)
            {
                list.Add(item);
            }

            Assert.IsTrue(list.Count > 0);
            Assert.IsTrue(
                list.Any(
                    u => u.Provider == expected.Provider &&
                         u.Name == expected.Model &&
                         u.Version == expected.Version));
        }

        [Test]
        public async Task GetDeviceClassInstallableUpdates_NotFound()
        {
            var client = CreateClient();
            AsyncPageable<UpdateId> response = client.GetDeviceClassInstallableUpdatesAsync("foo");
            Assert.IsNotNull(response);
            try
            {
                await foreach (var _ in response)
                { }
                Assert.Fail("Should have thrown 404");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetAllDevices()
        {
            var client = CreateClient();
            AsyncPageable<Device> response = client.GetAllDevicesAsync();
            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetDevice()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var response = await client.GetDeviceAsync(expected.DeviceId);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            var actual = response.Value;
            Assert.AreEqual(expected.Provider, actual.Manufacturer);
            Assert.AreEqual(expected.Model, actual.Model);
        }

        [Test]
        public async Task GetDevice_NotFound()
        {
            var client = CreateClient();
            try
            {
                await client.GetDeviceAsync("foo");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetUpdateCompliance()
        {
            var client = CreateClient();
            var response = await client.GetUpdateComplianceAsync();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.IsTrue(response.Value.TotalDeviceCount > 0);
        }

        [Test]
        public async Task GetAllDevicesTags()
        {
            var client = CreateClient();
            AsyncPageable<DeviceTag> response = client.GetAllDeviceTagsAsync();
            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetDeviceTag()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var tagName = expected.DeviceId;
            var response = await client.GetDeviceTagAsync(tagName);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            var actual = response.Value;
            Assert.AreEqual(tagName, actual.TagName);
        }

        [Test]
        public async Task GetDeviceTag_NotFound()
        {
            var client = CreateClient();
            try
            {
                await client.GetDeviceTagAsync("foo");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetAllGroups()
        {
            var client = CreateClient();
            AsyncPageable<Group> response = client.GetAllGroupsAsync();
            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }
            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetGroup()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var groupId = expected.DeviceId;
            var response = await client.GetGroupAsync(groupId);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            var actual = response.Value;
            Assert.AreEqual(groupId, actual.GroupId);
        }

        [Test]
        public async Task GetGroup_NotFound()
        {
            var client = CreateClient();
            try
            {
                await client.GetGroupAsync("foo");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetGroupUpdateCompliance()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var groupId = expected.DeviceId;
            var response = await client.GetGroupUpdateComplianceAsync(groupId);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            var actual = response.Value;
            Assert.IsTrue(actual.TotalDeviceCount > 0);
        }

        [Test]
        public async Task GetGroupUpdateCompliance_NotFound()
        {
            var client = CreateClient();
            try
            {
                await client.GetGroupUpdateComplianceAsync("foo");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetGroupBestUpdates()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var groupId = expected.DeviceId;
            AsyncPageable<UpdatableDevices> response = client.GetGroupBestUpdatesAsync(groupId);
            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }
            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetGroupBestUpdates_NotFound()
        {
            var client = CreateClient();
            AsyncPageable<UpdatableDevices> response = client.GetGroupBestUpdatesAsync("foo");
            Assert.IsNotNull(response);
            try
            {
                await foreach (var _ in response)
                { }
                Assert.Fail("Should have thrown 404");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }
    }
}
