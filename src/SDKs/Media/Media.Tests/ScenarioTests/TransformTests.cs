// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class TransformTests : MediaScenarioTestBase
    {
        [Fact]
        public void TransformComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                try
                {
                    CreateMediaServicesAccount();

                    // List transforms, which should be empty
                    var transforms = MediaClient.Transforms.List(ResourceGroup, AccountName);
                    Assert.Empty(transforms);

                    string transformName = TestUtilities.GenerateName("transform");
                    string transformDescription = "A test transform";

                    // Get tranform, which should not exist
                    Transform transform = MediaClient.Transforms.Get(ResourceGroup, AccountName, transformName);
                    Assert.Null(transform);

                    // Create a transform
                    TransformOutput[] outputs = new TransformOutput[]
                        {
                            new TransformOutput(new BuiltInStandardEncoderPreset(EncoderNamedPreset.AdaptiveStreaming))
                        };

                    Transform createdTransform = MediaClient.Transforms.CreateOrUpdate(ResourceGroup, AccountName, transformName, outputs, transformDescription);
                    ValidateTransform(createdTransform, transformName, transformDescription, outputs);

                    // List transforms and validate the created transform shows up
                    transforms = MediaClient.Transforms.List(ResourceGroup, AccountName);
                    Assert.Single(transforms);
                    ValidateTransform(transforms.First(), transformName, transformDescription, outputs);

                    // Get the newly created transform
                    transform = MediaClient.Transforms.Get(ResourceGroup, AccountName, transformName);
                    Assert.NotNull(transform);
                    ValidateTransform(transform, transformName, transformDescription, outputs);

                    // Update the transform
                    TransformOutput[] outputs2 = new TransformOutput[]
                        {
                            new TransformOutput(new BuiltInStandardEncoderPreset(EncoderNamedPreset.AdaptiveStreaming)),
                            new TransformOutput(new VideoAnalyzerPreset("en-US", false))
                        };

                    Transform updatedByPutTransform = MediaClient.Transforms.CreateOrUpdate(ResourceGroup, AccountName, transformName, outputs2, transformDescription);
                    ValidateTransform(updatedByPutTransform, transformName, transformDescription, outputs2);

                    // List transforms and validate the updated transform shows up as expected
                    transforms = MediaClient.Transforms.List(ResourceGroup, AccountName);
                    Assert.Single(transforms);
                    ValidateTransform(transforms.First(), transformName, transformDescription, outputs2);

                    // Get the newly updated transform
                    transform = MediaClient.Transforms.Get(ResourceGroup, AccountName, transformName);
                    Assert.NotNull(transform);
                    ValidateTransform(transform, transformName, transformDescription, outputs2);

                    // Update the transform again
                    TransformOutput[] outputs3 = new TransformOutput[]
                        {
                            new TransformOutput(new BuiltInStandardEncoderPreset(EncoderNamedPreset.AdaptiveStreaming)),
                            new TransformOutput(new AudioAnalyzerPreset("en-US")),
                        };

                    Transform updatedByPatchTransform = MediaClient.Transforms.Update(ResourceGroup, AccountName, transformName, outputs3);
                    ValidateTransform(updatedByPatchTransform, transformName, transformDescription, outputs3);

                    // List transforms and validate the updated transform shows up as expected
                    transforms = MediaClient.Transforms.List(ResourceGroup, AccountName);
                    Assert.Single(transforms);
                    ValidateTransform(transforms.First(), transformName, transformDescription, outputs3);

                    // Get the newly updated transform
                    transform = MediaClient.Transforms.Get(ResourceGroup, AccountName, transformName);
                    Assert.NotNull(transform);
                    ValidateTransform(transform, transformName, transformDescription, outputs3);

                    // Delete the transform
                    MediaClient.Transforms.Delete(ResourceGroup, AccountName, transformName);

                    // List transforms, which should be empty again
                    transforms = MediaClient.Transforms.List(ResourceGroup, AccountName);
                    Assert.Empty(transforms);

                    // Get tranform, which should not exist
                    transform = MediaClient.Transforms.Get(ResourceGroup, AccountName, transformName);
                    Assert.Null(transform);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateTransform(Transform transform, string expectedTransformName, string expectedTransformDescription, TransformOutput[] expectedOutputs)
        {
            Assert.Equal(expectedTransformDescription, transform.Description);
            Assert.Equal(expectedTransformName, transform.Name);
            Assert.Equal(expectedOutputs.Length, transform.Outputs.Count);

            for (int i = 0; i < expectedOutputs.Length; i++)
            {
                Type expectedType = expectedOutputs[i].Preset.GetType();
                Assert.Equal(expectedType, transform.Outputs[i].Preset.GetType());

                if (typeof(BuiltInStandardEncoderPreset) == expectedType)
                {
                    BuiltInStandardEncoderPreset expected = (BuiltInStandardEncoderPreset)expectedOutputs[i].Preset;
                    BuiltInStandardEncoderPreset actual = (BuiltInStandardEncoderPreset)transform.Outputs[i].Preset;

                    Assert.Equal(expected.PresetName, actual.PresetName);
                }
                else if (typeof(VideoAnalyzerPreset) == expectedType)
                {
                    VideoAnalyzerPreset expected = (VideoAnalyzerPreset)expectedOutputs[i].Preset;
                    VideoAnalyzerPreset actual = (VideoAnalyzerPreset)transform.Outputs[i].Preset;

                    Assert.Equal(expected.AudioInsightsOnly, actual.AudioInsightsOnly);
                    Assert.Equal(expected.AudioLanguage, actual.AudioLanguage);
                }
                else if (typeof(AudioAnalyzerPreset) == expectedType)
                {
                    AudioAnalyzerPreset expected = (AudioAnalyzerPreset)expectedOutputs[i].Preset;
                    AudioAnalyzerPreset actual = (AudioAnalyzerPreset)transform.Outputs[i].Preset;

                    Assert.Equal(expected.AudioLanguage, actual.AudioLanguage);
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected type {expectedType.Name}");
                }
            }
        }
    }
}
