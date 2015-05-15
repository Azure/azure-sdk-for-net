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
using System.Linq;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.WindowsAzure.Management.TrafficManager.Testing
{
    public class ProfileTest
    {
        [Fact]
        public void CheckDnsPrefixesAvailability()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                //Arrange
                using (TrafficManagerTestBase _testFixture = new TrafficManagerTestBase())
                {
                    string randomDomainName = _testFixture.GenerateRandomDomainName();

                    //Act
                    DnsPrefixAvailabilityCheckResponse response =
                        _testFixture.TrafficManagerClient.Profiles.CheckDnsPrefixAvailability(randomDomainName);

                    //Assert
                    Assert.True(response.Result);
                }
            }
        }

        [Fact]
        public void CreateProfile()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                //Arrange
                using (TrafficManagerTestBase _testFixture = new TrafficManagerTestBase())
                {
                    string testDomainName = _testFixture.GenerateRandomDomainName();
                    string testProfileName = _testFixture.CreateTestProfile(testDomainName);

                    //Act
                    ProfileGetResponse profileGetResponse =
                        _testFixture.TrafficManagerClient.Profiles.Get(testProfileName);

                    //Assert
                    Assert.True(profileGetResponse.StatusCode == HttpStatusCode.OK);
                    Assert.Equal<string>(testProfileName, profileGetResponse.Profile.Name);
                    Assert.Equal<string>(testDomainName, profileGetResponse.Profile.DomainName);
                    Assert.True(profileGetResponse.Profile.Definitions.Count == 0);
                    Assert.True(profileGetResponse.Profile.Status == ProfileDefinitionStatus.Disabled);
                }
            }
        }

        [Fact]
        public void DeleteProfile()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                //Arrange
                using (TrafficManagerTestBase _testFixture = new TrafficManagerTestBase())
                {
                    string testProfileName = _testFixture.CreateTestProfile();

                    //Act
                    AzureOperationResponse resp = _testFixture.TrafficManagerClient.Profiles.Delete(testProfileName);

                    //Assert
                    Assert.True(resp.StatusCode == HttpStatusCode.OK);
                }
            }
        }

        [Fact]
        public void UpdateProfile()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                //Arrange
                using (TrafficManagerTestBase _testFixture = new TrafficManagerTestBase())
                {
                    string profileName = _testFixture.CreateTestProfile();
                    string serviceName = _testFixture.CreateTestCloudService();
                    _testFixture.CreateADefinitionAndEnableTheProfile(profileName, serviceName,
                        EndpointType.CloudService);

                    //Act (disable the profile)
                    _testFixture.TrafficManagerClient.Profiles.Update(profileName,
                        ProfileDefinitionStatus.Disabled,
                        1 /*Version will always be 1*/);

                    //Assert
                    ProfileGetResponse profileGetResponse = _testFixture.TrafficManagerClient.Profiles.Get(profileName);
                    Assert.True(profileGetResponse.Profile.Status == ProfileDefinitionStatus.Disabled);
                }
            }
        }

        [Fact]
        public void ListProfiles()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                //Arrange
                using (TrafficManagerTestBase _testFixture = new TrafficManagerTestBase())
                {
                    string testProfileName = _testFixture.CreateTestProfile();

                    //Act
                    ProfilesListResponse resp = _testFixture.TrafficManagerClient.Profiles.List();

                    //Assert
                    Profile testProfile = resp.FirstOrDefault((p) => { return p.Name == testProfileName; });
                    Assert.True(testProfile != null);
                }
            }
        }
    }
}
