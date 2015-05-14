using System.Linq;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
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
