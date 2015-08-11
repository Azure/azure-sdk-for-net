namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClustersTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.ClustersResource;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.ClustersResource;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    [TestClass]
    public class ClustersRestClientTests : ClustersTestsBase
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCreateRestClient()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            Assert.IsNotNull(restClient);
        }

    }
}
