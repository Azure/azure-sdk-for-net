// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace StreamAnalytics.Tests.OperationTests
{
    public class TransformationOperationsTest : TestBase
    {
        [Fact]
        public void Test_TransformationOperations_E2E()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string resourceGroupName = TestUtilities.GenerateName("StreamAnalytics");
                string resourceName = TestUtilities.GenerateName("MyStreamingJobSubmittedBySDK");

                string serviceLocation = TestHelper.GetDefaultLocation();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetStreamAnalyticsManagementClient(handler);

                try
                {
                    ResourceGroup resourceGroup = new ResourceGroup() { Location = serviceLocation };
                    resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroup);

                    // Construct the JobCreateProperties
                    JobCreateOrUpdateParameters jobCreateOrUpdateParameters =
                        new JobCreateOrUpdateParameters(TestHelper.GetDefaultJob(resourceName, serviceLocation));

                    // Create a streaming job
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse = client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Construct the Transformation
                    string transformationName = TestUtilities.GenerateName("transformationtest");
                    int numberOfStreamingUnits = 1;
                    Transformation transformation = new Transformation()
                    {
                        Name = transformationName,
                        Properties = new TransformationProperties()
                        {
                            Query = "Select Id, Name from inputtest",
                            StreamingUnits = numberOfStreamingUnits
                        }
                    };

                    // Add an Transformation
                    TransformationCreateOrUpdateParameters transformationCreateOrUpdateParameters = new TransformationCreateOrUpdateParameters();
                    transformationCreateOrUpdateParameters.Transformation = transformation;
                    TransformationCreateOrUpdateResponse transformationCreateOrUpdateResponse = client.Transformations.CreateOrUpdate(resourceGroupName, resourceName, transformationCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, transformationCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(numberOfStreamingUnits, transformationCreateOrUpdateResponse.Transformation.Properties.StreamingUnits);
                    Assert.NotNull(transformationCreateOrUpdateResponse.Transformation.Properties.Etag);

                    // Update the Transformation
                    transformation.Properties.StreamingUnits = 3;
                    transformation.Properties.Etag = transformationCreateOrUpdateResponse.Transformation.Properties.Etag;
                    TransformationPatchParameters transformationPatchParameters = new TransformationPatchParameters(transformation.Properties);
                    TransformationPatchResponse transformationPatchResponse = client.Transformations.Patch(resourceGroupName, resourceName, transformationName, transformationPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, transformationPatchResponse.StatusCode);
                    Assert.Equal(3, transformationPatchResponse.Properties.StreamingUnits);
                    Assert.NotNull(transformationPatchResponse.Properties.Etag);
                    Assert.NotEqual(transformationCreateOrUpdateResponse.Transformation.Properties.Etag, transformationPatchResponse.Properties.Etag);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }
    }
}