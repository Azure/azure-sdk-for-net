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
    public class JobTests : MediaScenarioTestBase
    {
        [Fact]
        public void JobComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                try
                {
                    string transformName = TestUtilities.GenerateName("transform");
                    string transformDescription = "A test transform";
                    string jobName = TestUtilities.GenerateName("job");
                    string outputAssetName = TestUtilities.GenerateName("outputAsset");

                    CreateMediaServicesAccount();

                    // Create a transform as it is the parent of Jobs
                    TransformOutput[] outputs = new TransformOutput[]
                        {
                            new TransformOutput(new BuiltInStandardEncoderPreset(EncoderNamedPreset.AdaptiveStreaming))
                        };

                    Transform transform = MediaClient.Transforms.CreateOrUpdate(ResourceGroup, AccountName, transformName, outputs, transformDescription);

                    // List jobs, which should be empty
                    var jobs = MediaClient.Jobs.List(ResourceGroup, AccountName, transformName);
                    Assert.Empty(jobs);

                    // Try to get the job, which should not exist
                    Job job = MediaClient.Jobs.Get(ResourceGroup, AccountName, transformName, jobName);
                    Assert.Null(job);

                    // Create a job using an input from an HTTP url and an output to an Asset
                    Asset outputAsset = MediaClient.Assets.CreateOrUpdate(ResourceGroup, AccountName, outputAssetName, new Asset());

                    JobInputHttp jobInputHttp = new JobInputHttp(files: new string[] { "https://amssamples.streaming.mediaservices.windows.net/2e91931e-0d29-482b-a42b-9aadc93eb825/AzurePromo.mp4" });
                    JobInputs jobInputs = new JobInputs(inputs: new JobInput[] { jobInputHttp });
                    JobOutputAsset jobOutput = new JobOutputAsset(outputAssetName);
                    JobOutput[] jobOutputs = new JobOutput[] { jobOutput };
                    Job input = new Job(jobInputs, jobOutputs);

                    Job createdJob = MediaClient.Jobs.Create(ResourceGroup, AccountName, transformName, jobName, input);
                    ValidateJob(createdJob, jobName, null, jobInputs, jobOutputs);

                    // List jobs and validate the created job shows up
                    jobs = MediaClient.Jobs.List(ResourceGroup, AccountName, transformName);
                    Assert.Single(jobs);
                    ValidateJob(jobs.First(), jobName, null, jobInputs, jobOutputs);

                    // Get the newly created job
                    job = MediaClient.Jobs.Get(ResourceGroup, AccountName, transformName, jobName);
                    Assert.NotNull(job);
                    ValidateJob(job, jobName, null, jobInputs, jobOutputs);

                    // If the job isn't already finished, cancel it
                    if (job.State != JobState.Finished)
                    {
                        MediaClient.Jobs.CancelJob(ResourceGroup, AccountName, transformName, jobName);

                        do
                        {
                            System.Threading.Thread.Sleep(15 * 1000);
                            job = MediaClient.Jobs.Get(ResourceGroup, AccountName, transformName, jobName);
                        }
                        while (job.State != JobState.Finished && job.State != JobState.Canceled);
                    }

                    // Delete the job
                    MediaClient.Jobs.Delete(ResourceGroup, AccountName, transformName, jobName);

                    // List jobs, which should be empty again
                    jobs = MediaClient.Jobs.List(ResourceGroup, AccountName, transformName);
                    Assert.Empty(jobs);

                    // Try to get the job, which should not exist
                    job = MediaClient.Jobs.Get(ResourceGroup, AccountName, transformName, jobName);
                    Assert.Null(job);

                    // Delete the transform
                    MediaClient.Transforms.Delete(ResourceGroup, AccountName, transformName);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateJob(Job job, string expectedJobName, string expectedDescription, JobInput expectedInput, JobOutput[] expectedOutputs)
        {
            Assert.Equal(expectedDescription, job.Description);
            Assert.Equal(expectedJobName, job.Name);
            Assert.Equal(expectedOutputs.Length, job.Outputs.Count);

            for (int i = 0; i < expectedOutputs.Length; i++)
            {
                Type expectedOutputType = expectedOutputs[i].GetType();
                Assert.Equal(expectedOutputType, job.Outputs[i].GetType());

                if (typeof(JobOutputAsset) == expectedOutputType)
                {
                    JobOutputAsset expected = (JobOutputAsset)expectedOutputs[i];
                    JobOutputAsset actual = (JobOutputAsset)job.Outputs[i];

                    Assert.Equal(expected.AssetName, actual.AssetName);
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected output type {expectedOutputType.Name}");
                }
            }

            VerifyJobInput(expectedInput, job.Input);
        }

        private static void VerifyJobInput(JobInput expectedInput, JobInput actualInput, bool jobInputsAcceptable = true)
        {
            Type expectedInputType = expectedInput.GetType();
            Assert.Equal(expectedInputType, actualInput.GetType());

            if (typeof(JobInputAsset) == expectedInputType)
            {
                JobInputAsset expected = (JobInputAsset)expectedInput;
                JobInputAsset actual = (JobInputAsset)actualInput;

                Assert.Equal(expected.AssetName, actual.AssetName);
            }
            else if (typeof(JobInputHttp) == expectedInputType)
            {
                JobInputHttp expected = (JobInputHttp)expectedInput;
                JobInputHttp actual = (JobInputHttp)actualInput;

                Assert.Equal(expected.BaseUri, actual.BaseUri);
                Assert.Equal(expected.Label, actual.Label);
                Assert.Equal(expected.Files.Count, actual.Files.Count);

                for (int i = 0; i < expected.Files.Count; i++)
                {
                    Assert.Equal(expected.Files[i], actual.Files[i]);
                }
            }
            else if (typeof(JobInputs) == expectedInputType)
            {
                if (!jobInputsAcceptable)
                {
                    throw new InvalidOperationException("Only top level JobInputs are supported.");
                }

                JobInputs expected = (JobInputs)expectedInput;
                JobInputs actual = (JobInputs)actualInput;

                Assert.Equal(expected.Inputs.Count, actual.Inputs.Count);

                for (int i = 0; i < expected.Inputs.Count; i++)
                {
                    VerifyJobInput(expected.Inputs[i], actual.Inputs[i], false);
                }
            }
            else
            {
                throw new InvalidOperationException($"Unexpected input type {expectedInputType.Name}");
            }
        }
    }
}
