// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Workloads.Tests
{
    public class WorkloadsManagementTestBase : ManagementRecordedTestBase<WorkloadsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected WorkloadsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected WorkloadsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        public async Task<T> ReadAsync<T>(string filePath)
        {
            using FileStream stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public JsonDocument GetJsonElement(string filePath)
        {
            using FileStream stream = File.OpenRead(filePath);
            return JsonDocument.Parse(stream);
        }

        public async Task<string> getObjectAsString<T>(T data)
        {
            var _stream = new MemoryStream();
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            await content.WriteToAsync(_stream, System.Threading.CancellationToken.None);
            return Encoding.UTF8.GetString(_stream.ToArray());
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(
            SubscriptionResource subscription, string rgName, AzureLocation location)
        {
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups()
                .CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
