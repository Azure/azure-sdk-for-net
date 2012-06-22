//-----------------------------------------------------------------------
// <copyright file="AzureConstants.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains constant classes.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.ManagementClient
{
    /// <summary>
    /// Azure constant values
    /// </summary>
    static class AzureConstants
    {
        internal const string AzureSchemaNamespace = "http://schemas.microsoft.com/windowsazure";

        internal const string AzureDefaultEndpoint = "https://management.core.windows.net/";

        internal const int LabelMax = 100;

        internal const int DescriptionMax = 1024;

        internal const int StorageAccountNameMin = 3;

        internal const int StorageAccountNameMax = 24;

        internal const int ExtPropKeyMax = 64;

        internal const int ExtPropValMax = 255;
    }

    /// <summary>
    /// Fragments used to build Uris to Azure APIs
    /// </summary>
    static class UriFragments
    {
        internal const string HostedServicesPath = "/services/hostedservices";
        internal const string DeploymentSlotsPath = "/deploymentslots";
        internal const string DeploymentsPath = "/deployments";
        internal const string RolesPath = "/roles";
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
        internal const string ImagesPath = "/services/images";
        internal const string DisksPath = "/services/disks";
        internal const string Production = "Production";
        internal const string Staging = "Staging";
        internal const string VersionHeader = "x-ms-version";
        internal const string VersionTarget_1_7 = "2012-03-01";
        internal const string RequestIdHeader = "x-ms-request-id";
        internal const string ErrorRequestId = "EXCEPTION";
        internal const string ContentTypeXml = "application/xml";
    }

    //these are the URI fragments for each API
    //they are built from those above.
    //{0} is *always* the subscription id
    /// <summary>
    /// Uri format strings used to create Uris for each API.
    /// </summary>
    static class UriFormatStrings
    {
        internal const string HostedServices = "{0}" + UriFragments.HostedServicesPath;
        internal const string HostedServicesAndService = HostedServices + "/{1}";
        internal const string DeploymentSlot = HostedServicesAndService + UriFragments.DeploymentSlotsPath + "/{2}";
        internal const string Deployments = HostedServicesAndService + UriFragments.DeploymentsPath;
        internal const string DeploymentsAndDeployment = Deployments + "/{2}";
        internal const string GetHostedServicePropertiesEmbedDetail = HostedServicesAndService + UriFragments.EmbedDetailQuery;
        internal const string DeploymentSlotChangeConfig = DeploymentSlot + UriFragments.CompConfigQuery;
        internal const string DeploymentSlotUpdateStatus = DeploymentSlot + UriFragments.CompStatusQuery;
        internal const string DeploymentSlotUpgrade = DeploymentSlot + UriFragments.CompUpgradeQuery;
        internal const string DeploymentSlotWalkUpgradeDomain = DeploymentSlot + UriFragments.CompWalkUpgradeDomainQuery;
        internal const string RolesAndRole = DeploymentsAndDeployment + UriFragments.RolesPath + "/{3}";
        internal const string StorageServices = "{0}" + UriFragments.StorageServicesPath;
        internal const string StorageServicesAndAccount = StorageServices + "/{1}";
        internal const string GetStorageAccountKeys = StorageServicesAndAccount + UriFragments.KeysPath;
        internal const string RegenerateStorageAccountKeys = GetStorageAccountKeys + UriFragments.RegenerateQueryString;
        internal const string GetOperationStatus = "{0}" + UriFragments.OperationsPath + "/{1}";
        internal const string Locations = "{0}" + UriFragments.LocationsPath;
        internal const string AffinityGroups = "{0}" + UriFragments.AffinityGroupsPath;
        internal const string AffinityGroupsAndAffinityGroup = "{0}" + UriFragments.AffinityGroupsPath + "/{1}";
        internal const string ServiceCertificates = HostedServicesAndService + UriFragments.CertificatesPath;
        internal const string ServiceCertificatesAndCertificate = ServiceCertificates + "/{2}-{3}";
        internal const string ManagementCertificates = "{0}" + UriFragments.CertificatesPath;
        internal const string ManagementCertificatesAndCertificate = ManagementCertificates + "/{1}";
        internal const string OSImages = "{0}" + UriFragments.ImagesPath;
        internal const string Disks = "{0}" + UriFragments.DisksPath;
        internal const string DisksAndDisk = Disks + "/{1}";
    }
}
