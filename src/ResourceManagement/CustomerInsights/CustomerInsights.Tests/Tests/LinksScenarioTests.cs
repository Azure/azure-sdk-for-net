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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class LinksScenarioTests
    {
        static LinksScenarioTests()
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
        public void CrdLinksFullCycle()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var profileName = TestUtilities.GenerateName("testProfile");
                var interactionName1 = TestUtilities.GenerateName("testInteraction");
                var linkName = TestUtilities.GenerateName("linkTest");

                var profileResourceFomrat = Helpers.GetTestProfile(profileName);
                aciClient.Profiles.CreateOrUpdate(ResourceGroupName, HubName, profileName, profileResourceFomrat);

                var interactionResourceFormat = Helpers.GetTestInteraction(interactionName1, "profile1");;

                var linkResourceFormat = new LinkResourceFormat
                                             {
                                                 TargetProfileType = profileName,
                                                 SourceInteractionType = interactionName1,
                                                 DisplayName =
                                                     new Dictionary<string, string> { { "en-us", "Link DisplayName" } },
                                                 Description =
                                                     new Dictionary<string, string> { { "en-us", "Link Description" } },
                                                 Mappings =
                                                     new[]
                                                         {
                                                             new TypePropertiesMapping
                                                                 {
                                                                     InteractionTypePropertyName = interactionName1,
                                                                     ProfileTypePropertyName = profileName,
                                                                     IsProfileTypeId = true,
                                                                     LinkType = LinkTypes.UpdateAlways
                                                                 }
                                                         },
                                                 ParticipantPropertyReferences =
                                                     new[]
                                                         {
                                                             new ParticipantPropertyReference
                                                                 {
                                                                     ProfilePropertyName = "ProfileId",
                                                                     InteractionPropertyName = interactionName1
                                                                 }
                                                         }
                                             };

                aciClient.Interactions.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    interactionName1,
                    interactionResourceFormat);

                var createLinkResult = aciClient.Links.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    linkName,
                    linkResourceFormat);

                Assert.Equal(linkName, createLinkResult.LinkName);
                Assert.Equal(createLinkResult.Name, HubName + "/" + linkName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    createLinkResult.Type,
                    "Microsoft.CustomerInsights/hubs/links",
                    StringComparer.OrdinalIgnoreCase);

                var getLinkResult = aciClient.Links.Get(ResourceGroupName, HubName, linkName);
                Assert.Equal(linkName, getLinkResult.LinkName);
                Assert.Equal(getLinkResult.Name, HubName + "/" + linkName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    getLinkResult.Type,
                    "Microsoft.CustomerInsights/hubs/links",
                    StringComparer.OrdinalIgnoreCase);

                var listlinkResult = aciClient.Links.ListByHub(ResourceGroupName, HubName);

                Assert.True(listlinkResult.ToList().Count >= 1);
                Assert.True(listlinkResult.ToList().Any(linkReturned => linkName == linkReturned.LinkName));
            }
        }
    }
}