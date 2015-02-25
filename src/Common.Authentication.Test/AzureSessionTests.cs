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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xunit;

namespace Common.Authentication.Test
{
    public class AzureSessionTests
    {
        [Fact]
        public void DefaultAzureSessionIsCorrectlyConstructed()
        {
            AzureSession.CurrentProfile = AzureSession.InitializeDefaultProfile();
            var profile = AzureSession.CurrentProfile;
            Assert.NotNull(profile);
            Assert.Equal(profile.ProfilePath, Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            Assert.NotNull(AzureSession.TokenCache);
            Assert.NotNull(AzureSession.DataStore);
            Assert.True(AzureSession.DataStore is  DiskDataStore);
            Assert.True(AzureSession.TokenCache is ProtectedFileTokenCache);
        }

        [Fact]
        public void SetCurrentAzureProfileUpdatesAssociatedData()
        {
            var profile = new AzureProfile();
            AzureSession.CurrentProfile = profile;
            Assert.NotNull(AzureSession.TokenCache);
            Assert.NotNull(AzureSession.DataStore);
            Assert.True(AzureSession.DataStore is  MemoryDataStore);
            Assert.True(AzureSession.TokenCache is TokenCache);
            Assert.False(AzureSession.TokenCache is ProtectedFileTokenCache);

            AzureSession.CurrentProfile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            Assert.Equal(AzureSession.CurrentProfile.ProfilePath, Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            Assert.NotNull(AzureSession.TokenCache);
            Assert.NotNull(AzureSession.DataStore);
            Assert.True(AzureSession.DataStore is  DiskDataStore);
            Assert.True(AzureSession.TokenCache is ProtectedFileTokenCache);
        }
    }
}
