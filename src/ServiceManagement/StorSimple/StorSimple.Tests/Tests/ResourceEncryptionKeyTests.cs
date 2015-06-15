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

using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.Azure.Test;
using Xunit;

namespace StorSimple.Tests.Tests
{
    public class ResourceEncryptionKeyTests : StorSimpleTestBase
    {
        [Fact]
        public void GetResourceEncryptionKeyTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();
                //make call to get the encryptionkeys response
                //no need to pass device Id for this call
                var getEncryptionKeysResponse = client.ResourceEncryptionKeys.Get(GetCustomRequestHeaders());

                Assert.True(getEncryptionKeysResponse != null);
                Assert.True(getEncryptionKeysResponse.ResourceEncryptionKeys != null);
                Assert.True(getEncryptionKeysResponse.ResourceEncryptionKeys.EncodedEncryptedPublicKey != null);
                Assert.True(getEncryptionKeysResponse.ResourceEncryptionKeys.Thumbprint != null);
            }
        }
    }
}
