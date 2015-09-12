// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;

namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Reader;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json;

    /// <summary>
    /// Converts data from objects into payloads.
    /// </summary>
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "This complexity is needed to handle all the types in the submit payload.")]
    internal class PayloadConverter : IPayloadConverter
    {
        private const string WindowsAzureNamespace = "http://schemas.microsoft.com/windowsazure";
        private static readonly XName CloudServicesElementName = XName.Get("CloudServices", WindowsAzureNamespace);
        private static readonly XName CloudServiceElementName = XName.Get("CloudService", WindowsAzureNamespace);
        private static readonly XName GeoRegionElementName = XName.Get("GeoRegion", WindowsAzureNamespace);
        private static readonly XName ResourceElementName = XName.Get("Resource", WindowsAzureNamespace);
        private static readonly XName ResourceProviderNamespaceElementName = XName.Get("ResourceProviderNamespace", WindowsAzureNamespace);
        private static readonly XName TypeElementName = XName.Get("Type", WindowsAzureNamespace);
        private static readonly XName IntrinsicSettingItemElementName = XName.Get("IntrinsicSettings", WindowsAzureNamespace);
        private static readonly XName NameElementName = XName.Get("Name", WindowsAzureNamespace);
        private static readonly XName SubStateElementName = XName.Get("SubState", WindowsAzureNamespace);
        private static readonly XName OutputItemElementName = XName.Get("OutputItem", WindowsAzureNamespace);
        private static readonly XName KeyElementName = XName.Get("Key", WindowsAzureNamespace);
        private static readonly XName ValueElementName = XName.Get("Value", WindowsAzureNamespace);
        private static readonly XName OperationStatusElementName = XName.Get("OperationStatus", WindowsAzureNamespace);
        private static readonly XName ErrorElementName = XName.Get("Error", WindowsAzureNamespace);
        private static readonly XName HttpCodeElementName = XName.Get("HttpCode", WindowsAzureNamespace);
        private static readonly XName MessageElementName = XName.Get("Message", WindowsAzureNamespace);
        private const string ClusterUserName = "ClusterUsername";
        private const string ExtendedErrorElementName = "ExtendedErrorMessage";
        private const string NodesCount = "NodesCount";
        private const string ConnectionUrl = "ConnectionURL";
        private const string CreatedDate = "CreatedDate";
        private const string VersionName = "Version";
        private const string HttpUserName = "Http_Username";
        private const string RdpUserName = "RDP_Username";
        private const string HttpPassword = "Http_Password";
        private const string BlobContainersElementName = "BlobContainers";
        private const string Create = "Create";
        private const string SchemaVersion20 = "2.0";
        private const string WorkerNodeRoleName = "WorkerNodeRole";
        private const string HeadNodeRoleName = "HeadNodeRole";
        private const string ClusterTypePropertyName = "Type";
        private const string HadoopAndHBaseType = "MR,HBase";
        private const string HadoopAndStormType = "MR,Storm";
        private const string HadoopAndSparkType = "MR,Spark";
        private const string ContainersResourceType = "containers";
      
        /// <summary>
        /// Provides the namespace for the May2013 contracts.
        /// </summary>
        public const string May2013 = "http://schemas.microsoft.com/hdinsight/2013/05/management";

        /// <summary>
        /// Provides the namespace for the System contracts.
        /// </summary>
        public const string System = "http://schemas.datacontract.org/2004/07/System";

        internal static string SerializeHttpConnectivityRequest(UserChangeRequestOperationType type, string username, string password, DateTimeOffset experation)
        {
            Help.DoNothing(experation);
            if (username.IsNull())
            {
                username = string.Empty;
            }
            if (password.IsNull())
            {
                password = string.Empty;
            }
            dynamic dynaXml = DynaXmlBuilder.Create(false, Formatting.None);

            dynaXml.xmlns(May2013)
                   .HttpUserChangeRequest
                   .b
                     .Operation(type.ToString())
                     .Username(username)
                     .Password(password)
                   .d
                   .End();

            return dynaXml.ToString();
        }

        /// <summary>
        /// Serializes a connectivity request.
        /// </summary>
        /// <param name="type">Operation type.</param>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password for service.</param>
        /// <param name="expiration">Date when this service access expires.</param>
        /// <returns>A Serialized connectivity request.</returns>
        internal static string SerializeRdpConnectivityRequest(UserChangeRequestOperationType type, string userName, string password, DateTimeOffset expiration)
        {
            if (userName.IsNull())
            {
                userName = string.Empty;
            }
            if (password.IsNull())
            {
                password = string.Empty;
            }
            dynamic dynaXml = DynaXmlBuilder.Create(false, Formatting.None);

            dynaXml.xmlns(May2013)
                   .xmlns.a(System)
                   .RdpUserChangeRequest
                   .b
                     .Operation(type.ToString())
                     .Username(userName)
                     .Password(password)
                     .ExpirationDate
                     .b
                       .xmlns.a.DateTime(expiration.DateTime.ToString("o", CultureInfo.InvariantCulture))
                       .xmlns.a.OffsetMinutes(expiration.Offset.TotalMinutes)
                     .d
                   .d
                   .End();

            return dynaXml.ToString();
        }

        /// <inheritdoc />
        public PayloadResponse<UserChangeRequestStatus> DeserializeConnectivityStatus(string payload)
        {
            XmlDocument doc = new XmlDocument();
            using (var stream = payload.ToUtf8Stream())
            using (var reader = XmlReader.Create(stream))
            {
                doc.Load(reader);
            }
            var manager = new DynaXmlNamespaceTable(doc);
            PayloadResponse<UserChangeRequestStatus> result = new PayloadResponse<UserChangeRequestStatus>();
            var node = doc.SelectSingleNode("/def:PassthroughResponse/def:Data", manager.NamespaceManager);
            if (node.IsNotNull())
            {
                result.Data = new UserChangeRequestStatus();
                var data = node;
                node = data.SelectSingleNode("def:State", manager.NamespaceManager);
                UserChangeRequestOperationStatus status;
                if (node.IsNull() || !UserChangeRequestOperationStatus.TryParse(node.InnerText, out status))
                {
                    throw new SerializationException("Unable to deserialize the server response.");
                }
                result.Data.State = status;

                node = data.SelectSingleNode("def:UserType", manager.NamespaceManager);
                UserChangeRequestUserType userType;
                if (node.IsNull() || !UserChangeRequestUserType.TryParse(node.InnerText, out userType))
                {
                    throw new SerializationException("Unable to deserialize the server response.");
                }
                result.Data.UserType = userType;

                node = data.SelectSingleNode("def:OperationType", manager.NamespaceManager);
                UserChangeRequestOperationType operationType;
                if (node.IsNull() || !UserChangeRequestOperationType.TryParse(node.InnerText, out operationType))
                {
                    throw new SerializationException("Unable to deserialize the server response.");
                }
                result.Data.OperationType = operationType;

                node = data.SelectSingleNode("def:RequestIssueDate", manager.NamespaceManager);
                DateTime requestTime;
                if (node.IsNull() || !DateTime.TryParse(node.InnerText, out requestTime))
                {
                    throw new SerializationException("Unable to deserialize the server response.");
                }
                result.Data.RequestIssueDate = requestTime.ToUniversalTime();

                node = data.SelectSingleNode("def:Error", manager.NamespaceManager);
                result.Data.ErrorDetails = this.GetErrorDetails(node, manager.NamespaceManager);

            }
            node = doc.SelectSingleNode("/def:PassthroughResponse/def:Error", manager.NamespaceManager);
            result.ErrorDetails = this.GetErrorDetails(node, manager.NamespaceManager);

            return result;
        }

        private PayloadErrorDetails GetErrorDetails(XmlNode root, XmlNamespaceManager manager)
        {
            PayloadErrorDetails details = null;
            if (root.HasChildNodes)
            {
                details = new PayloadErrorDetails();
                HttpStatusCode statusCode;
                var node = root.SelectSingleNode("def:StatusCode", manager);
                if (node.IsNull() || !HttpStatusCode.TryParse(node.InnerText, out statusCode))
                {
                    throw new SerializationException("Unable to parse the Status Code of the Error Details.");
                }
                details.StatusCode = statusCode;
                node = root.SelectSingleNode("def:ErrorId", manager);
                if (node.IsNull())
                {
                    throw new SerializationException("Unable to parse the error id of the Error response component.");
                }
                details.ErrorId = node.InnerText;
                node = root.SelectSingleNode("def:ErrorMessage", manager);
                if (node.IsNull())
                {
                    throw new SerializationException("Unable to parse the error message of the Error response component.");
                }
                details.ErrorMessage = node.InnerText;
            }
            return details;
        }

        /// <summary>
        /// Deserializes a Connectivity Response.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>
        /// A PayloadResponse object with the operation id for the data.
        /// </returns>
        public PayloadResponse<Guid> DeserializeConnectivityResponse(string payload)
        {
            XmlDocument doc = new XmlDocument();
            using (var stream = payload.ToUtf8Stream())
            using (var reader = XmlReader.Create(stream))
            {
                doc.Load(reader);
            }
            var manager = new DynaXmlNamespaceTable(doc);
            PayloadResponse<Guid> result = new PayloadResponse<Guid>();
            var node = doc.SelectSingleNode("/def:PassthroughResponse/def:Data", manager.NamespaceManager);
            if (node.IsNotNull() && node.InnerText.IsNotNullOrEmpty())
            {
                var text = node.InnerText;
                Guid guid;
                if (!Guid.TryParse(text, out guid))
                {
                    throw new SerializationException("Unable to deserialize the server response.");
                }
                result.Data = guid;
            }
            node = doc.SelectSingleNode("/def:PassthroughResponse/def:Error", manager.NamespaceManager);
            result.ErrorDetails = this.GetErrorDetails(node, manager.NamespaceManager);
            return result;
        }

        /// <inheritdoc />
        public Collection<ClusterDetails> DeserializeListContainersResult(string payload, string deploymentNamespace, Guid subscriptionId)
        {
            var data = this.DeserializeHDInsightClusterList(payload, deploymentNamespace, subscriptionId);

            return new Collection<ClusterDetails>(data.ToList());
        }

        /// <inheritdoc />
        public string SerializeClusterCreateRequestV3(ClusterCreateParametersV2 cluster)
        {
            Contracts.May2014.ClusterCreateParameters ccp = null;
            if (cluster.ClusterType == ClusterType.HBase)
            {
                ccp = HDInsightClusterRequestGenerator.Create3XClusterForMapReduceAndHBaseTemplate(cluster);
            }
            else if (cluster.ClusterType == ClusterType.Storm)
            {
                ccp = HDInsightClusterRequestGenerator.Create3XClusterForMapReduceAndStormTemplate(cluster);
            }
            else if (cluster.ClusterType == ClusterType.Spark)
            {
                ccp = HDInsightClusterRequestGenerator.Create3XClusterForMapReduceAndSparkTemplate(cluster);
            }
            else if (cluster.ClusterType == ClusterType.Hadoop)
            {
                ccp = HDInsightClusterRequestGenerator.Create3XClusterFromMapReduceTemplate(cluster);
            }
            else
            {
                throw new InvalidDataException("Invalid cluster type");
            }
            return this.CreateClusterRequest_ToInternalV3(ccp);
        }

        /// <inheritdoc />
        public string SerializeClusterCreateRequest(ClusterCreateParametersV2 cluster)
        {
            return this.CreateClusterRequest_ToInternal(cluster);
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
            Justification = "This is a result of interface flowing and not a true measure of complexity.")]
        private string CreateClusterRequest_ToInternal(ClusterCreateParametersV2 cluster)
        {
            dynamic dynaXml = DynaXmlBuilder.Create(false, Formatting.None);
            // The RP translates 1 XL into 2 L for SU 4 and up.
            // This is done as part of the HA improvement where in the RP would never
            // create clusters without 2 nodes for SU 4 release (May '14) and up.
            var headnodeCount = cluster.HeadNodeSize.Equals(VmSize.ExtraLarge.ToString()) ? 1 : 2;
            dynaXml.xmlns("http://schemas.microsoft.com/windowsazure")
                   .Resource
                   .b
                     .SchemaVersion(SchemaVersion20)
                     .IntrinsicSettings
                     .b
                       .xmlns(May2013)
                       .ClusterContainer
                       .b
                         .Deployment
                         .b
                         .AdditionalStorageAccounts
                         .b
                         .d
                         .ClusterPassword(cluster.Password)
                         .ClusterUsername(cluster.UserName)
                         .Roles
                           .b
                             .ClusterRole
                             .b
                               .Count(headnodeCount)
                               .RoleType(ClusterRoleType.HeadNode)
                               .VMSize(cluster.HeadNodeSize)
                             .d
                             .ClusterRole
                             .b
                               .Count(cluster.ClusterSizeInNodes)
                               .RoleType(ClusterRoleType.DataNode)
                               .VMSize(cluster.DataNodeSize)
                             .d
                           .d
                         .Version(cluster.Version)
                         .d
                         .DeploymentAction(Create)
                         .ClusterName(cluster.Name)
                         .Region(cluster.Location)
                         .StorageAccounts
                           .b
                             .BlobContainerReference
                             .b
                               .AccountName(cluster.DefaultStorageAccountName)
                               .BlobContainerName(cluster.DefaultStorageContainer)
                               .Key(cluster.DefaultStorageAccountKey)
                             .d
                             .sp("asv")
                          .d
                        .Settings
                         .b
                            .Core
                                .b
                                  .sp("coresettings")
                                .d
                            .d
                           .b
                            .Hdfs
                                .b
                                  .sp("hdfssettings")
                                .d
                            .d
                            .b
                            .MapReduce
                                .b
                                  .sp("mapreduceconfiguration")
                                  .sp("mapreducecapacityschedulerconfiguration")
                                .d
                            .d
                           .b
                           .Hive
                           .b
                              .sp("hivesettings")
                              .sp("hiveresources")
                           .d
                           .Oozie
                           .b
                              .sp("ooziesettings")
                              .sp("oozieadditionalsharedlibraries")
                              .sp("ooziesharedexecutables")
                           .d
                           .Yarn
                           .b
                              .sp("yarnsettings")
                         .d
                       .d
                     .d
                   .d
                   .d
                   .End();

            dynaXml.rp("asv");
            foreach (var asv in cluster.AdditionalStorageAccounts)
            {
                this.AddStorageAccount(dynaXml, asv, "deploymentcontainer");
            }

            this.AddConfigurationOptions(dynaXml, cluster.CoreConfiguration, "coresettings");
            this.AddConfigurationOptions(dynaXml, cluster.HdfsConfiguration, "hdfssettings");
            this.AddConfigurationOptions(dynaXml, cluster.YarnConfiguration, "yarnsettings");
            if (cluster.MapReduceConfiguration != null)
            {
                this.AddConfigurationOptions(dynaXml, cluster.MapReduceConfiguration.ConfigurationCollection, "mapreduceconfiguration");
                this.AddConfigurationOptions(dynaXml, cluster.MapReduceConfiguration.CapacitySchedulerConfigurationCollection, "mapreducecapacityschedulerconfiguration");
            }

            this.AddConfigurationOptions(dynaXml, cluster.HiveConfiguration.ConfigurationCollection, "hivesettings");

            this.SerializeOozieConfiguration(cluster, dynaXml);

            this.SerializeHiveConfiguration(cluster, dynaXml);

            string xml;
            using (var stream = new MemoryStream())
            using (var reader = new StreamReader(stream))
            {
                dynaXml.Save(stream);
                stream.Position = 0;
                xml = reader.ReadToEnd();
            }

            return xml;
        }

        private string CreateClusterRequest_ToInternalV3(Contracts.May2014.ClusterCreateParameters ccp)
        {
            var ccpAsXmlString = ccp.SerializeAndOptionallyWriteToStream();
            var doc = new XmlDocument();
            using (var stringReader = new StringReader(ccpAsXmlString))
            {
                using (var reader = XmlReader.Create(stringReader))
                {
                    doc.Load(reader);
                }
            }
            var resource = new RDFEResource { SchemaVersion = "3.0", IntrinsicSettings = new XmlNode[] { doc.DocumentElement } };

            using (var str = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(RDFEResource));
                serializer.WriteObject(str, resource);

                str.Position = 0;
                using (var reader = new StreamReader(str))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private void SerializeHiveConfiguration(ClusterCreateParametersV2 cluster, dynamic dynaXml)
        {
            if (cluster.HiveConfiguration.AdditionalLibraries != null)
            {
                dynaXml.rp("hiveresources")
                       .AdditionalLibraries.b.AccountName(cluster.HiveConfiguration.AdditionalLibraries.Name)
                       .BlobContainerName(cluster.HiveConfiguration.AdditionalLibraries.Container)
                       .Key(cluster.HiveConfiguration.AdditionalLibraries.Key)
                       .d.End();
            }

            if (cluster.HiveMetastore != null)
            {
                dynaXml.rp("hivesettings")
                       .Catalog.b.DatabaseName(cluster.HiveMetastore.Database)
                       .Password(cluster.HiveMetastore.Password)
                       .Server(cluster.HiveMetastore.Server)
                       .Username(cluster.HiveMetastore.User)
                       .d.End();
            }
        }

        private void SerializeOozieConfiguration(ClusterCreateParametersV2 cluster, dynamic dynaXml)
        {
            this.AddConfigurationOptions(dynaXml, cluster.OozieConfiguration.ConfigurationCollection, "ooziesettings");
            if (cluster.OozieConfiguration.AdditionalSharedLibraries != null)
            {
                dynaXml.rp("oozieadditionalsharedlibraries")
                       .AdditionalSharedLibraries
                       .b
                        .AccountName(cluster.OozieConfiguration.AdditionalSharedLibraries.Name)
                        .BlobContainerName(cluster.OozieConfiguration.AdditionalSharedLibraries.Container)
                        .Key(cluster.OozieConfiguration.AdditionalSharedLibraries.Key)
                       .d.End();
            }

            if (cluster.OozieConfiguration.AdditionalActionExecutorLibraries != null)
            {
                dynaXml.rp("ooziesharedexecutables")
                       .AdditionalActionExecutorLibraries
                       .b
                        .AccountName(cluster.OozieConfiguration.AdditionalActionExecutorLibraries.Name)
                        .BlobContainerName(cluster.OozieConfiguration.AdditionalActionExecutorLibraries.Container)
                        .Key(cluster.OozieConfiguration.AdditionalActionExecutorLibraries.Key)
                       .d.End();
            }

            this.SerializeOozieMetastore(cluster, dynaXml);
        }

        private void SerializeOozieMetastore(ClusterCreateParametersV2 cluster, dynamic dynaXml)
        {
            if (cluster.OozieMetastore != null)
            {
                dynaXml.rp("ooziesettings")
                       .Catalog.b.DatabaseName(cluster.OozieMetastore.Database)
                       .Password(cluster.OozieMetastore.Password)
                       .Server(cluster.OozieMetastore.Server)
                       .Username(cluster.OozieMetastore.User)
                       .d.End();
            }
        }

        private void AddStorageAccount(dynamic dynaXml, WabStorageAccountConfiguration asv, string containerName)
        {
            dynaXml.BlobContainerReference
                .b
                    .AccountName(asv.Name)
                    .BlobContainerName(containerName)
                    .Key(asv.Key)
                .d.End();
        }

        private void AddConfigurationOptions(dynamic dynaXml, ConfigValuesCollection configProperties, string sectionName)
        {
            if (configProperties.Any())
            {
                var configurationElement = dynaXml.rp(sectionName).Configuration.b;
                foreach (var configPropety in configProperties)
                {
                    configurationElement.Property.b.Name(configPropety.Key).Value(configPropety.Value).d.End();
                }

                configurationElement.d.End();
            }
        }

        internal IEnumerable<ClusterDetails> DeserializeHDInsightClusterList(string payload, string deploymentNamespace, Guid subscriptionId)
        {
            payload.ArgumentNotNullOrEmpty("payload");
            var payloadDocument = XDocument.Parse(payload);
            var clusterList = new List<ClusterDetails>();
            var clusterEnumerable = from cloudServices in payloadDocument.Elements(CloudServicesElementName)
                                    from cloudService in cloudServices.Elements(CloudServiceElementName)
                                    let geoRegion = cloudService.Element(GeoRegionElementName)
                                    from resource in cloudService.Descendants(ResourceElementName)
                                    let resourceNamespace = this.GetStringValue(resource, ResourceProviderNamespaceElementName)
                                    let intrinsicSettings = this.GetIntrinsicSettings(resource)
                                    let storageAccounts = this.GetStorageAccounts(resource, intrinsicSettings)
                                    let rdfeResourceType = this.GetStringValue(resource, TypeElementName)
                                    where resourceNamespace == deploymentNamespace && rdfeResourceType.Equals(ContainersResourceType, StringComparison.OrdinalIgnoreCase)
                                    let versionString = this.GetClusterProperty(resource, intrinsicSettings, VersionName)
                                    select new ClusterDetails()
                                    {
                                        Name = this.GetStringValue(resource, NameElementName),
                                        Location = geoRegion.Value,
                                        StateString = this.GetStringValue(resource, SubStateElementName),
                                        RdpUserName = this.GetClusterProperty(resource, intrinsicSettings, RdpUserName),
                                        HttpUserName = this.GetClusterProperty(resource, intrinsicSettings, HttpUserName),
                                        HttpPassword = this.GetClusterProperty(resource, intrinsicSettings, HttpPassword),
                                        ClusterSizeInNodes = this.ExtractClusterPropertyIntValue(resource, intrinsicSettings, NodesCount),
                                        ConnectionUrl = this.GetClusterProperty(resource, intrinsicSettings, ConnectionUrl),
                                        CreatedDate = this.ExtractClusterPropertyDateTimeValue(resource, intrinsicSettings, CreatedDate),
                                        Version = versionString,
                                        VersionStatus = VersionFinderClient.GetVersionStatus(versionString),
                                        DefaultStorageAccount = this.GetDefaultStorageAccount(storageAccounts),
                                        AdditionalStorageAccounts = this.GetAdditionalStorageAccounts(storageAccounts),
                                        VersionNumber = this.ConvertStringToVersion(versionString),
                                        Error = this.DeserializeClusterError(resource),
                                        SubscriptionId = subscriptionId,
                                        ClusterType = this.GetClusterType(resource, intrinsicSettings)
                                    };

            clusterList.AddRange(clusterEnumerable);
            return clusterList;
        }

        internal ClusterType GetClusterType(XElement resource, IEnumerable<KeyValuePair<string, string>> intrinsicSettings)
        {
            string clusterType = this.GetClusterProperty(resource, intrinsicSettings, ClusterTypePropertyName);
            if (clusterType != null && clusterType.Equals(HadoopAndHBaseType))
            {
                return ClusterType.HBase;
            }
            else if (clusterType != null && clusterType.Equals(HadoopAndStormType))
            {
                return ClusterType.Storm;
            }
            else if (clusterType != null && clusterType.Equals(HadoopAndSparkType))
            {
                return ClusterType.Spark;
            }
            return ClusterType.Hadoop;
        }

        // Get a certificate object from a string property encoded as base 64.
        private static X509Certificate2 GetCertificate(string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return null;
            }

            var bytes = Convert.FromBase64String(property);
            return new X509Certificate2(bytes);
        }

        private IEnumerable<WabStorageAccountConfiguration> GetAdditionalStorageAccounts(IEnumerable<WabStorageAccountConfiguration> storageAccounts)
        {
            return storageAccounts.Skip(1);
        }

        private WabStorageAccountConfiguration GetDefaultStorageAccount(IEnumerable<WabStorageAccountConfiguration> storageAccounts)
        {
            return storageAccounts.FirstOrDefault();
        }

        private IEnumerable<WabStorageAccountConfiguration> GetStorageAccounts(XElement resource, IEnumerable<KeyValuePair<string, string>> intrinsicSettings)
        {
            var blobContainerSerializedJson = this.GetClusterProperty(resource, intrinsicSettings, BlobContainersElementName);
            if (blobContainerSerializedJson.IsNullOrEmpty())
            {
                return Enumerable.Empty<WabStorageAccountConfiguration>();
            }

            return this.GetStorageAccountsFromJson(blobContainerSerializedJson);
        }

        /// <summary>
        /// Converts an HDInsight version string to a Version object.
        /// </summary>
        /// <param name="version">
        /// The version string.
        /// </param>
        /// <returns>
        /// A version object that represents the components of the version string.
        /// </returns>
        public Version ConvertStringToVersion(string version)
        {
            if (version.IsNotNullOrEmpty())
            {
                version.ArgumentNotNullOrEmpty("version");
                if (version.IsNotNullOrEmpty())
                {
                    Version outVersion = new Version();
                    if (Version.TryParse(version, out outVersion))
                    {
                        return outVersion;
                    }
                    else
                    {
                        string[] parts = version.Split('.');
                        int major;
                        int minor;
                        int build;
                        int rev;
                        if (parts.Length >= 4 && int.TryParse(parts[0], out major) && int.TryParse(parts[1], out minor) &&
                            int.TryParse(parts[2], out build) && int.TryParse(parts[3], out rev))
                        {
                            return new Version(major, minor, build, rev);
                        }
                    }
                    return outVersion;
                }
            }

            return new Version();
        }

        internal ClusterErrorStatus DeserializeClusterError(XElement resource)
        {
            resource.ArgumentNotNull("resource");
            var operationStatusElement = resource.Element(OperationStatusElementName);
            if (operationStatusElement == null)
            {
                return null;
            }

            string errorMessage;
            ClusterErrorStatus clusterErrorStatus = null;
            var errorElement = operationStatusElement.Element(ErrorElementName);
            var extendedErrorElement = this.ExtractResourceOutputStringValue(resource, ExtendedErrorElementName);

            if (errorElement != null)
            {
                var errorType = this.GetStringValue(operationStatusElement, TypeElementName);
                var httpCode = int.Parse(this.GetStringValue(errorElement, HttpCodeElementName), CultureInfo.InvariantCulture);
                errorMessage = this.GetStringValue(errorElement, MessageElementName);
                clusterErrorStatus = new ClusterErrorStatus(httpCode, errorMessage, errorType);
            }

            if (extendedErrorElement.IsNotNullOrEmpty())
            {
                if (clusterErrorStatus == null)
                {
                    clusterErrorStatus = new ClusterErrorStatus();
                }

                clusterErrorStatus.Message = extendedErrorElement;
            }

            return clusterErrorStatus;
        }

        internal int ExtractClusterPropertyIntValue(XElement resource, IEnumerable<KeyValuePair<string, string>> intrinsicSettings, string name)
        {
            int intValue;
            var intString = this.GetClusterProperty(resource, intrinsicSettings, name);
            if (int.TryParse(intString, NumberStyles.None, CultureInfo.InvariantCulture, out intValue))
            {
                return intValue;
            }

            return 0;
        }

        internal DateTime ExtractClusterPropertyDateTimeValue(XElement resource, IEnumerable<KeyValuePair<string, string>> intrinsicSettings, string name)
        {
            DateTime outputDateTime;
            var dateTimeString = this.GetClusterProperty(resource, intrinsicSettings, name);
            if (DateTime.TryParse(dateTimeString, CultureInfo.InvariantCulture, DateTimeStyles.None, out outputDateTime))
            {
                return outputDateTime;
            }

            return DateTime.MinValue;
        }

        internal string GetClusterProperty(XElement resource, IEnumerable<KeyValuePair<string, string>> intrinsicSettings, string intrinsicSettingPropertyName)
        {
            return GetClusterProperty(resource, intrinsicSettings, intrinsicSettingPropertyName, intrinsicSettingPropertyName);
        }

        internal string GetClusterProperty(XElement resource, IEnumerable<KeyValuePair<string, string>> intrinsicSettings, string intrinsicSettingPropertyName, string outputItemPropertyName)
        {
            var intrinsicSettingsList = intrinsicSettings.ToList();
            if (intrinsicSettingsList.Any(setting => setting.Key == intrinsicSettingPropertyName))
            {
                var valueFromIntrinsicSetting = intrinsicSettingsList.First(setting => setting.Key == intrinsicSettingPropertyName);
                return valueFromIntrinsicSetting.Value;

            }

            return this.ExtractResourceOutputStringValue(resource, outputItemPropertyName);
        }

        internal string ExtractResourceOutputStringValue(XElement resource, string name)
        {
            var outputItemValue = from outputItem in resource.Descendants(OutputItemElementName)
                                  let outputItemName = this.GetStringValue(outputItem, KeyElementName)
                                  where outputItemName == name
                                  select this.GetStringValue(outputItem, ValueElementName);

            return outputItemValue.FirstOrDefault();
        }

        internal IEnumerable<KeyValuePair<string, string>> GetIntrinsicSettings(XElement resource)
        {
            var intrinsicSettingsElement = resource.Descendants(IntrinsicSettingItemElementName).FirstOrDefault();
            if (intrinsicSettingsElement != null)
            {
                return this.GetOutputItemsFromJson(intrinsicSettingsElement.Value);
            }

            return Enumerable.Empty<KeyValuePair<string, string>>();
        }

        private IEnumerable<KeyValuePair<string, string>> GetOutputItemsFromJson(string value)
        {
            var outputItems = new List<KeyValuePair<string, string>>();
            var bytes = Encoding.UTF8.GetBytes(value);
            using (var memoryStream = new MemoryStream(bytes))
            {
                var jsonParser = new JsonParser(memoryStream);
                var jsonItem = jsonParser.ParseNext();
                var jsonArray = jsonItem as JsonArray;
                if (jsonArray == null)
                {
                    return Enumerable.Empty<KeyValuePair<string, string>>();
                }

                for (int index = 0; index < jsonArray.Count(); index++)
                {
                    var outputItem = jsonArray.GetIndex(index);
                    var keyProperty = this.GetJsonStringValue(outputItem.GetProperty("Key"));
                    var valueProperty = this.GetJsonStringValue(outputItem.GetProperty("Value"));

                    outputItems.Add(new KeyValuePair<string, string>(keyProperty, valueProperty));
                }
            }

            return outputItems;
        }

        private IEnumerable<WabStorageAccountConfiguration> GetStorageAccountsFromJson(string value)
        {
            var storageAccounts = new List<WabStorageAccountConfiguration>();
            var bytes = Encoding.UTF8.GetBytes(value);
            using (var memoryStream = new MemoryStream(bytes))
            {
                var jsonParser = new JsonParser(memoryStream);
                var jsonItem = jsonParser.ParseNext();
                var jsonArray = jsonItem as JsonArray;
                if (jsonArray == null)
                {
                    return Enumerable.Empty<WabStorageAccountConfiguration>();
                }

                for (int index = 0; index < jsonArray.Count(); index++)
                {
                    var outputItem = jsonArray.GetIndex(index);
                    var key = this.GetJsonStringValue(outputItem.GetProperty("Key"));
                    var account = this.GetJsonStringValue(outputItem.GetProperty("AccountName"));
                    var container = this.GetJsonStringValue(outputItem.GetProperty("Container"));

                    storageAccounts.Add(new WabStorageAccountConfiguration(account, key, container));
                }
            }

            return storageAccounts;
        }

        private string GetJsonStringValue(JsonItem item)
        {
            string value;
            item.TryGetValue(out value);
            return value;
        }

        internal string GetStringValue(XElement element, XName elementName)
        {
            element.ArgumentNotNull("element");
            var childElement = element.Element(elementName);
            return childElement != null ? childElement.Value : string.Empty;
        }
    }
}