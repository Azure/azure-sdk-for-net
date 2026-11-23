// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Batch.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests
{
    public class BatchAccountPoolPatchTests
    {
        [Test]
        public void EnableAutoScaleWritesPatchProperties()
        {
            #region Snippet:Azure_ResourceManager_Batch_CreatePoolPatch
            var patch = new BatchAccountPoolPatch
            {
                Properties = new PoolPatchProperties
                {
                    ScaleSettings = new BatchAccountPoolScaleSettings
                    {
                        AutoScale = new BatchAccountAutoScaleSettings("$TargetDedicatedNodes=34")
                    }
                }
            };
            #endregion

            var json = ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W"));

            Assert.That(json.ToString(), Is.EqualTo("{\"properties\":{\"scaleSettings\":{\"autoScale\":{\"formula\":\"$TargetDedicatedNodes=34\"}}}}"));
        }

        [Test]
        public void MetadataAndApplicationPackagesWritePatchProperties()
        {
            const string applicationId = "/subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/default-azurebatch-japaneast/providers/Microsoft.Batch/batchAccounts/sampleacct/applications/app_1234";
            var patch = new BatchAccountPoolPatch
            {
                Properties = new PoolPatchProperties
                {
                    Metadata = { new BatchAccountPoolMetadataItem("key1", "value1") },
                    ApplicationPackages =
                    {
                        new BatchApplicationPackageReference(new ResourceIdentifier(applicationId)),
                        new BatchApplicationPackageReference(new ResourceIdentifier(applicationId)) { Version = "1.0" }
                    }
                }
            };

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W")));
            var properties = json.RootElement.GetProperty("properties");
            var metadata = properties.GetProperty("metadata");
            Assert.That(metadata.GetArrayLength(), Is.EqualTo(1));
            Assert.That(metadata[0].GetProperty("name").GetString(), Is.EqualTo("key1"));
            Assert.That(metadata[0].GetProperty("value").GetString(), Is.EqualTo("value1"));
            var applicationPackages = properties.GetProperty("applicationPackages");
            Assert.That(applicationPackages.GetArrayLength(), Is.EqualTo(2));
            Assert.That(applicationPackages[0].GetProperty("id").GetString(), Is.EqualTo(applicationId));
            Assert.That(applicationPackages[0].TryGetProperty("version", out _), Is.False);
            Assert.That(applicationPackages[1].GetProperty("id").GetString(), Is.EqualTo(applicationId));
            Assert.That(applicationPackages[1].GetProperty("version").GetString(), Is.EqualTo("1.0"));
        }

        [Test]
        public void RemoveStartTaskWritesEmptyObject()
        {
            var patch = new BatchAccountPoolPatch
            {
                Properties = new PoolPatchProperties
                {
                    StartTask = new BatchAccountPoolStartTask()
                }
            };

            var json = ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W"));

            Assert.That(json.ToString(), Is.EqualTo("{\"properties\":{\"startTask\":{}}}"));
        }

        [Test]
        public void ResizePoolPreservesFixedScaleSettings()
        {
            var patch = new BatchAccountPoolPatch
            {
                Properties = new PoolPatchProperties
                {
                    ScaleSettings = new BatchAccountPoolScaleSettings
                    {
                        FixedScale = new BatchAccountFixedScaleSettings
                        {
                            ResizeTimeout = TimeSpan.FromMinutes(8),
                            TargetDedicatedNodes = 5,
                            TargetLowPriorityNodes = 0,
                            NodeDeallocationOption = BatchNodeDeallocationOption.TaskCompletion
                        }
                    }
                }
            };

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W")));
            var scaleSettings = json.RootElement.GetProperty("properties").GetProperty("scaleSettings");
            Assert.That(scaleSettings.TryGetProperty("autoScale", out _), Is.False);
            var fixedScale = scaleSettings.GetProperty("fixedScale");
            Assert.That(fixedScale.GetProperty("resizeTimeout").GetString(), Is.EqualTo("PT8M"));
            Assert.That(fixedScale.GetProperty("targetDedicatedNodes").GetInt32(), Is.EqualTo(5));
            Assert.That(fixedScale.GetProperty("targetLowPriorityNodes").GetInt32(), Is.Zero);
            Assert.That(fixedScale.GetProperty("nodeDeallocationOption").GetString(), Is.EqualTo("TaskCompletion"));
        }
    }
}
