//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Threading;

    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class ImageScenarioTests
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        static ImageScenarioTests()
        {
            HubName = AppSettings.HubName;
            ResourceGroupName = AppSettings.ResourceGroupName;
        }

        /// <summary>
        ///     Hub Name
        /// </summary>
        private static readonly string HubName;

        /// <summary>
        ///     Reosurce Group Name
        /// </summary>
        private static readonly string ResourceGroupName;

        [Fact]
        public void GetImageUploadUrl()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();
                var profileName = "Contact";
                var interactionName = "BankWithdrawal";

                var entityprofileimagerelativepath = "images/profile1.png";
                var entityinteractionimagerelativepath = "images/interacation1.png";
                var dataprofileimagerelativepath = "images/profile1.png";
                var datainteractionimagerelativepath = "images/interacation2.png";

                var entityTypeImageUploadUrlProfile = new GetImageUploadUrlInput
                                                          {
                                                              EntityType = "Profile",
                                                              EntityTypeName = profileName,
                                                              RelativePath = entityprofileimagerelativepath
                                                          };
                var entityTypeImageUploadUrlInteraction = new GetImageUploadUrlInput
                                                              {
                                                                  EntityType = "Interaction",
                                                                  EntityTypeName = interactionName,
                                                                  RelativePath = entityinteractionimagerelativepath
                                                              };

                var dataImageUploadUrlProfile = new GetImageUploadUrlInput
                                                    {
                                                        EntityType = "Profile",
                                                        EntityTypeName = profileName,
                                                        RelativePath = dataprofileimagerelativepath
                                                    };
                var dataImageUploadUrlInteraction = new GetImageUploadUrlInput
                                                        {
                                                            EntityType = "Interaction",
                                                            EntityTypeName = interactionName,
                                                            RelativePath = datainteractionimagerelativepath
                                                        };

                var returnentityTypeImageUploadUrlProfile = aciClient.Images.GetUploadUrlForEntityType(
                    ResourceGroupName,
                    HubName,
                    entityTypeImageUploadUrlProfile);
                Assert.Equal(returnentityTypeImageUploadUrlProfile.RelativePath, entityprofileimagerelativepath);
                Assert.NotNull(returnentityTypeImageUploadUrlProfile.ContentUrl);

                var returnentityTypeImageUploadUrlInteraction =
                    aciClient.Images.GetUploadUrlForEntityType(
                        ResourceGroupName,
                        HubName,
                        entityTypeImageUploadUrlInteraction);
                Assert.Equal(returnentityTypeImageUploadUrlInteraction.RelativePath, entityinteractionimagerelativepath);
                Assert.NotNull(returnentityTypeImageUploadUrlInteraction.ContentUrl);

                var returndataImageUploadUrlProfile = aciClient.Images.GetUploadUrlForData(
                    ResourceGroupName,
                    HubName,
                    dataImageUploadUrlProfile);
                Assert.Equal(returndataImageUploadUrlProfile.RelativePath, dataprofileimagerelativepath);
                Assert.NotNull(returndataImageUploadUrlProfile.ContentUrl);

                var returndataImageUploadUrlInteraction = aciClient.Images.GetUploadUrlForData(
                    ResourceGroupName,
                    HubName,
                    dataImageUploadUrlInteraction);
                Assert.Equal(returndataImageUploadUrlInteraction.RelativePath, datainteractionimagerelativepath);
                Assert.NotNull(returndataImageUploadUrlInteraction.ContentUrl);
            }
        }
    }
}