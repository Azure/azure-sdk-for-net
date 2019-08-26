// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
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
            using (var context = MockContext.Start(this.GetType()))
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
