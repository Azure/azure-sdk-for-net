// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.IoT.DeviceRegistry._SoftwareUpdate.Tests
{
    public class SoftwareUpdateRecordedTests : SoftwareUpdateTestBase
    {
        private const string Provider = "Contoso";
        private const string Name = "Toaster";
        private const string Version = "1.0";

        public SoftwareUpdateRecordedTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ImportUpdateLifecycle()
        {
            SoftwareUpdate client = CreateSoftwareUpdateClient();
            var manifest = new ImportManifestMetadata(
                TestEnvironment.ManifestUrl,
                712,
                new Dictionary<string, string>
                {
                    ["sha256"] = "PHuSWFOX73yLXeaIrSo9gtsiGGKOKY6fw5n6/6rFFh4="
                });
            var importItem = new ImportUpdateInputItem(manifest);
            importItem.Files.Add(new FileImportMetadata("README.md", TestEnvironment.PayloadUrl));
            var request = new ImportUpdateRequest(new[] { importItem })
            {
                EnableScan = false
            };

            try
            {
                Operation importOperation = await client.ImportUpdateAsync(WaitUntil.Completed, request);

                Assert.That(importOperation.HasCompleted, Is.True);
                Assert.That(importOperation.GetRawResponse().Status, Is.InRange(200, 299));

                Response<UpdateContent> response = await client.GetUpdateAsync(Provider, Name, Version);
                Assert.That(response.Value, Is.InstanceOf<UpdateContent>());
                Assert.That(response.Value.ManifestVersion, Is.EqualTo("4.0"));
                Assert.That(response.Value.ImportedOn, Is.Not.EqualTo(default(System.DateTimeOffset)));
                Assert.That(response.Value.CreatedOn, Is.Not.EqualTo(default(System.DateTimeOffset)));
            }
            finally
            {
                Operation deleteOperation = await client.DeleteUpdateAsync(WaitUntil.Completed, Provider, Name, Version);

                Assert.That(deleteOperation.HasCompleted, Is.True);
                Assert.That(deleteOperation.GetRawResponse().Status, Is.InRange(200, 299));
            }
        }

        [RecordedTest]
        public async Task ListDeviceClasses()
        {
            var deviceClasses = new List<DeviceClass>();

            await foreach (DeviceClass deviceClass in CreateDeviceClassesClient().GetAllAsync())
            {
                deviceClasses.Add(deviceClass);
            }

            Assert.That(deviceClasses, Is.All.InstanceOf<DeviceClass>());
        }

        [RecordedTest]
        public async Task ListUpdates()
        {
            var updates = new List<UpdateContent>();

            await foreach (UpdateContent update in CreateSoftwareUpdateClient().GetUpdatesAsync())
            {
                updates.Add(update);
            }

            Assert.That(updates, Is.All.InstanceOf<UpdateContent>());
        }

        [RecordedTest]
        public async Task ListUpdateProviders()
        {
            var providers = new List<string>();

            await foreach (string provider in CreateSoftwareUpdateClient().GetProvidersAsync())
            {
                providers.Add(provider);
            }

            Assert.That(providers, Is.All.InstanceOf<string>());
        }
    }
}