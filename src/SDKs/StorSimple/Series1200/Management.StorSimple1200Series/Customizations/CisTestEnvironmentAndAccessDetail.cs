namespace Microsoft.Azure.Management.StorSimple1200Series
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CisTestEnvironmentAndAccessDetail
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string SubscriptionId { get; set; }
        public string ResourceGroupName { get; set; }
        public string ResourceLocation { get; set; }
        public string AuthenticationEndPoint { get; set; }
        public string TokenAudience { get; set; }
        public string ArmEndPoint { get; set; }
        public string ProviderNamespace { get; set; }
        public bool IsOneBox { get; set; }
        public string StorageConnectionString { get; set; }
        public string SupportPackagePasskey { get; set; }
        public string StorageAccountName { get; set; }
        public string StorageAccountLogin { get; set; }
        public string StorageAccountPrimaryPassword { get; set; }
        public string StorageAccountSecondaryPassword { get; set; }
        public bool UseAadFlow { get; set; }
        public bool TestAadMigration { get; set; }
        public string CiSDataQueueName { get; set; }
        public string CiSDataQueueConnectionString { get; set; }
    }
}
