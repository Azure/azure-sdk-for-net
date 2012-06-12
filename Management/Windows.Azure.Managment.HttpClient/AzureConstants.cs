using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows.Azure.Management
{
    static class AzureConstants
    {
        internal const string AzureSchemaNamespace = "http://schemas.microsoft.com/windowsazure";

        internal const string AzureDefaultEndpoint = "https://management.core.windows.net/";

        internal const int LabelMax = 100;

        internal const int DescriptionMax = 1024;

        internal const int StorageAccountNameMin = 3;

        internal const int StorageAccountNameMax = 24;
    }

    static class UriFragments
    {
        internal const string DefaultBaseUri = "https://management.core.windows.net/";
        internal const string HostedServicesPath = "/services/hostedservices";
        internal const string DeploymentSlotsPath = "/deploymentslots";
        internal const string OperationsPath = "/operations";
        internal const string StorageServicesPath = "/services/storageservices";
        internal const string LocationsPath = "/locations";
        internal const string AffinityGroupsPath = "/affinitygroups";
        internal const string KeysPath = "/keys";
        internal const string CertificatesPath = "/certificates";
        internal const string RegenerateQueryString = "?action=regenerate";
        internal const string EmbedDetailQuery = "?embed-detail=true";
        internal const string CompStatusQuery = "/?comp=status";
        internal const string CompConfigQuery = "/?comp=config";
        internal const string CompUpgradeQuery = "/?comp=upgrade";
        internal const string CompWalkUpgradeDomainQuery = "/?comp=walkupgradedomain";
        internal const string Production = "Production";
        internal const string Staging = "Staging";
        internal const string VersionHeader = "x-ms-version";
        internal const string VersionTarget_1_7 = "2012-03-01";
        internal const string RequestIdHeader = "x-ms-request-id";
        internal const string ErrorRequestId = "EXCEPTION";
        internal const string ContentTypeXml = "application/xml";
        internal const string Secondary = "Secondary";
    }

    //these are the URI fragments for each API
    //they are built from those above.
    //{0} is *always* the subscription id
    static class UriFormatStrings
    {
        internal const string HostedServices = "{0}" + UriFragments.HostedServicesPath;
        internal const string HostedServicesAndService = HostedServices + "/{1}";
        internal const string DeploymentSlot = HostedServicesAndService + UriFragments.DeploymentSlotsPath + "/{2}";
        internal const string GetHostedServicePropertiesEmbedDetail = HostedServicesAndService + UriFragments.EmbedDetailQuery;
        internal const string DeploymentSlotChangeConfig = DeploymentSlot + UriFragments.CompConfigQuery;
        internal const string DeploymentSlotUpdateStatus = DeploymentSlot + UriFragments.CompStatusQuery;
        internal const string DeploymentSlotUpgrade = DeploymentSlot + UriFragments.CompUpgradeQuery;
        internal const string DeploymentSlotWalkUpgradeDomain = DeploymentSlot + UriFragments.CompWalkUpgradeDomainQuery;
        internal const string StorageServices = "{0}" + UriFragments.StorageServicesPath;
        internal const string StorageServicesAndAccount = StorageServices + "/{1}";
        internal const string GetStorageAccountKeys = StorageServicesAndAccount + UriFragments.KeysPath;
        internal const string GetOperationStatus = "{0}" + UriFragments.OperationsPath + "/{1}";
        internal const string Locations = "{0}" + UriFragments.LocationsPath;
        internal const string AffinityGroups = "{0}" + UriFragments.AffinityGroupsPath;
        internal const string AffinityGroupsAndAffinityGroup = "{0}" + UriFragments.AffinityGroupsPath + "/{1}";
        internal const string ServiceCertificates = HostedServicesAndService + UriFragments.CertificatesPath;
        internal const string ServiceCertificatesAndCertificate = ServiceCertificates + "/{2}-{3}";
        internal const string ManagementCertificates = "{0}" + UriFragments.CertificatesPath;
        internal const string ManagementCertificatesAndCertificate = ManagementCertificates + "/{1}";
    }
}
