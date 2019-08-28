// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Xunit;

namespace StreamAnalytics.Tests
{
    public class TransformationTests : TestBase
    {
        [Fact]
        public async Task TransformationOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string transformationName = TestUtilities.GenerateName("transformation");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedTransformationType = TestHelper.GetFullRestOnlyResourceType(TestHelper.TransformationResourceType);
                string expectedTransformationResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.TransformationResourceType, transformationName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                Transformation transformation = new Transformation()
                {
                    Query = "Select Id, Name from inputtest",
                    StreamingUnits = 6
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT transformation
                var putResponse = await streamAnalyticsManagementClient.Transformations.CreateOrReplaceWithHttpMessagesAsync(transformation, resourceGroupName, jobName, transformationName);
                ValidationHelper.ValidateTransformation(transformation, putResponse.Body, false);
                Assert.Equal(expectedTransformationResourceId, putResponse.Body.Id);
                Assert.Equal(transformationName, putResponse.Body.Name);
                Assert.Equal(expectedTransformationType, putResponse.Body.Type);

                // Verify GET request returns expected transformation
                var getResponse = await streamAnalyticsManagementClient.Transformations.GetWithHttpMessagesAsync(resourceGroupName, jobName, transformationName);
                ValidationHelper.ValidateTransformation(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // PATCH transformation
                var transformationPatch = new Transformation()
                {
                    Query = "New query"
                };
                putResponse.Body.Query = transformationPatch.Query;
                var patchResponse = await streamAnalyticsManagementClient.Transformations.UpdateWithHttpMessagesAsync(transformationPatch, resourceGroupName, jobName, transformationName);
                ValidationHelper.ValidateTransformation(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET transformation to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Transformations.GetWithHttpMessagesAsync(resourceGroupName, jobName, transformationName);
                ValidationHelper.ValidateTransformation(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);
            }
        }
    }
}
