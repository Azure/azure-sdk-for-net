using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.EntitySearch;
using Microsoft.Azure.CognitiveServices.Search.EntitySearch.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace EntitySearchSDK.Tests
{
    public class EntitySearchTests : BaseTests
    {
        [Fact]
        public void EntitySearch()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "EntitySearch");

                IEntitySearchAPI client = GetClient(HttpMockServer.CreateInstance());

                var resp = client.Entities.Search(query: "tom cruise");

                Assert.NotNull(resp);
                Assert.NotNull(resp.Entities);
                Assert.NotNull(resp.Entities.Value);
                Assert.Equal(resp.Entities.Value.Count, 1);

                Assert.NotNull(resp.Entities.Value[0].ContractualRules);

                var licenseAttribution = resp.Entities.Value[0].ContractualRules.Where(rule => rule is ContractualRulesLicenseAttribution).FirstOrDefault();

                Assert.NotNull(licenseAttribution);
                Assert.Equal(licenseAttribution.TargetPropertyName, "description");

                var image = resp.Entities.Value[0].Image;

                Assert.NotNull(image);
                Assert.NotNull(image.Provider);

                var provider = image.Provider.FirstOrDefault();

                Assert.NotNull(provider);
                Assert.IsType(typeof(Organization), provider);
            }
        }
    }
}
