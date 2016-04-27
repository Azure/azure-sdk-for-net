namespace BatchClientIntegrationTests.Application
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;

    public class ApplicationPackageFixture : IDisposable
    {
        private const string ApplicationId = "iaprt" + ApplicationIntegrationCommon.ApplicationId;
        private const string Version = ApplicationIntegrationCommon.Version;

        public ApplicationPackageFixture()
        {
            TestCommon.EnableAutoStorageAsync().Wait();

            ApplicationIntegrationCommon.UploadTestApplicationPackageIfNotAlreadyUploadedAsync(
                ApplicationId,
                Version,
                TestCommon.Configuration.BatchAccountName,
                TestCommon.Configuration.BatchAccountResourceGroup).Wait();
        }

        public void Dispose()
        {
            Task.Run(async () => await ApplicationIntegrationCommon.DeleteApplicationAsync(
                ApplicationId,
                TestCommon.Configuration.BatchAccountResourceGroup,
                TestCommon.Configuration.BatchAccountName)).GetAwaiter().GetResult();
        }
    }
}
