namespace Microsoft.Azure.Management.StorSimple1200Series
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CisTestContextConstants
    {
        #region CisTestContext.xml Tags and Attributes

        public const string TagCisTestContext = "CisTestContext";
        public const string TagAccessDetail = "AccessDetail";
        public const string TagTenantId = "TenantId";
        public const string TagClientId = "ClientId";
        public const string TagSecret = "Secret";
        public const string TagSubscriptionId = "SubscriptionId";
        public const string TagResourceGroupName = "ResourceGroupName";
        public const string TagResourceLocation = "ResourceLocation";
        public const string TagEnvironment = "Environment";
        public const string TagAuthenticationEndPoint = "AuthenticationEndPoint";
        public const string TagTokenAudience = "TokenAudience";
        public const string TagArmEndPoint = "ArmEndPoint";
        public const string TagProviderNamespace = "ProviderNamespace";
        public const string TagCisResource = "CisResource";
        public const string TagCisAppliance = "CisAppliance";
        public const string TagCisIscsiServer = "CisIscsiServer";
        public const string TagCisFileServer = "CisFileServer";
        public const string TagIsOneBox = "IsOneBox";
        public const string TagStorageConnectionString = "StorageConnectionString";
        public const string TagSupportPackagePasskey = "SupportPackagePasskey";
        public const string TagStorageAccount = "StorageAccount";
        public const string TagIsAadEnabled = "IsAadEnabled";
        public const string TagTestAadMigration = "TestAadMigration";
        public const string TagCiSDataQueue = "CiSDataQueue";

        public const string AttrName = "name";
        public const string AttrId = "id";
        public const string AttrType = "type";
        public const string AttrServiceEncryptionKey = "serviceEncryptionKey";
        public const string AttrLogin = "login";
        public const string AttrPrimaryPassword = "primaryPassword";
        public const string AttrSecondaryPassword = "secondaryPassword";
        public const string AttrConnectionString = "connectionString";

        public const string ValResourceTypeHelsinki = "H";
        public const string ValResourceTypeGarda = "G";

        public const string ValApplianceTypeHelsinkiVmIscsi = "I";
        public const string ValApplianceTypeHelsinkiVmNas = "N";
        public const string ValApplianceTypeGarda = "G";
        public const string ValApplianceTypeAzureCis = "A";

        #endregion

        #region CisTestContextConfig.xml Tags and Attributes

        public const string TagTestContextConfiguration = "TestContextConfiguration";
        public const string TagContextDirectoryPath = "ContextDirectoryPath";
        public const string TagContextXMLFileName = "ContextXMLFileName";

        #endregion
    }
}
