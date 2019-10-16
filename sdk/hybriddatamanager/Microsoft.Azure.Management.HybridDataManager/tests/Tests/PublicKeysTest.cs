namespace HybridData.Tests.Tests
{
    using Microsoft.Azure.Management.HybridData;
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class PublicKeysTest : HybridDataTestBase
    {
        public PublicKeysTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {

        }

        [Fact]
        //PublicKeys_ListByDataManager
        public void PublicKeys_ListByDataManager()
        {
            try
            {
                var publicKeysList = Client.PublicKeys.ListByDataManager(ResourceGroupName, DataManagerName);
                Assert.NotNull(publicKeysList);
                Assert.NotEmpty(publicKeysList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //PublicKeys_Get
        [Fact]
        public void PublicKeys_Get()
        {
            try
            {
                var publicKeysList = Client.PublicKeys.ListByDataManager(ResourceGroupName, DataManagerName);
                Assert.NotNull(publicKeysList);
                Assert.NotEmpty(publicKeysList);
                foreach (var publicKey in publicKeysList)
                {
                    var returnedPublicKey = Client.PublicKeys.Get(publicKey.Name, ResourceGroupName, DataManagerName);
                    Assert.NotNull(returnedPublicKey);
                    Assert.Equal(publicKey.Name, returnedPublicKey.Name);
                }
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

    }
}

