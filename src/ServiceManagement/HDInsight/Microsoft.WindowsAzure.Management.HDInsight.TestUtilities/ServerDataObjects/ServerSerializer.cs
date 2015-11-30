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
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.YarnApplications;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Tests.ServerDataObjects.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.CustomActions;

    internal static class ServerSerializer
    {
        private const string WindowsAzureNamespace = "http://schemas.microsoft.com/windowsazure";
        private static readonly XName ResourceElementName = XName.Get("Resource", WindowsAzureNamespace);
        private static readonly XName OutputItemElementName = XName.Get("OutputItem", WindowsAzureNamespace);
        private static readonly XName OutputItemsElementName = XName.Get("OutputItems", WindowsAzureNamespace);
        private static readonly XName IntrinsicSettingsElementName = XName.Get("IntrinsicSettings", WindowsAzureNamespace);
        private static readonly XName KeyElementName = XName.Get("Key", WindowsAzureNamespace);
        private static readonly XName ValueElementName = XName.Get("Value", WindowsAzureNamespace);
        private const string ClusterUserName = "ClusterUsername";
        private const string HttpUserName = "Http_Username";
        private const string HttpPassword = "Http_Password";
        private const string RdpUserName = "RDP_Username";
        private const string NodesCount = "NodesCount";
        private const string ConnectionUrl = "ConnectionURL";
        private const string CreatedDate = "CreatedDate";
        private const string Version = "Version";
        private const string BlobContainers = "BlobContainers";
        private const string ExtendedErrorMessage = "ExtendedErrorMessage";
        private const string HeadNodeRoleName = "HeadNodeRole";
        private const string WorkerNodeRoleName = "WorkerNodeRole";
        private const string ZookeeperNodeRoleName = "ZKRole";

        internal static string SerializeListContainersResult(IEnumerable<ClusterDetails> containers, string deploymentNamespace, bool writeError, bool writeExtendedError)
        {
            var serviceList = new CloudServiceList();
            foreach (var containerGroup in containers.GroupBy(container => container.Location))
            {
                serviceList.Add(new CloudService()
                {
                    GeoRegion = containerGroup.Key,
                    Resources = new ResourceList(from container in containerGroup
                                                 select ListClusterContainerResult_ToInternal(container, deploymentNamespace, writeError, writeExtendedError))
                });
            }

            return serviceList.SerializeToXml();
        }

        internal static Resource DeserializeClusterCreateRequestIntoResource(string payload)
        {
            return DeserializeFromXml<Resource>(payload);
        }

        internal static HDInsight.ClusterCreateParametersV2 DeserializeClusterCreateRequest(string payload)
        {
            var resource = DeserializeFromXml<Resource>(payload);
            var createPayload = DeserializeFromXml<ClusterContainer>(resource.IntrinsicSettings[0].OuterXml);
            return CreateClusterRequest_FromInternal(createPayload);
        }

        internal static HDInsight.ClusterCreateParametersV2 DeserializeClusterCreateRequestV3(string payload)
        {
            var resource = DeserializeFromXml<Resource>(payload);
            var createPayload =
                DeserializeFromXml<Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters>(resource.IntrinsicSettings[0].OuterXml);
            return CreateClusterRequest_FromInternalV3(createPayload);
        }

        internal static ClusterContainer DeserializeClusterCreateRequestToInternal(string payload)
        {
            var resource = DeserializeFromXml<Resource>(payload);
            var createPayload = DeserializeFromXml<ClusterContainer>(resource.IntrinsicSettings[0].OuterXml);
            return createPayload;
        }

        internal static Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters DeserializeClusterCreateRequestToInternalV3(string payload)
        {
            var resource = DeserializeFromXml<Resource>(payload);
            var createPayload = DeserializeFromXml<Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters>(resource.IntrinsicSettings[0].OuterXml);
            return createPayload;
        }

        internal static XElement SerializeResource(Resource resource)
        {
            var xdoc = new XDocument();
            xdoc.Add(
                new XElement(ResourceElementName,
                    new XElement(OutputItemsElementName,
                        from outputItem in resource.OutputItems
                        select new XElement(OutputItemElementName,
                            new XElement(KeyElementName, outputItem.Key),
                            new XElement(ValueElementName, outputItem.Value)))));

            return xdoc.Root;
        }

        internal static XElement SerializeResource<TIntrinsic>(Resource resource, IEnumerable<TIntrinsic> intrinsicSettings)
        {
            var intrinsicTextNode = SerializeToJson(intrinsicSettings);
            var xdoc = new XDocument();
            xdoc.Add(
                new XElement(ResourceElementName,
                    new XElement(IntrinsicSettingsElementName, intrinsicTextNode),
                    new XElement(OutputItemsElementName,
                        from outputItem in resource.OutputItems
                        select new XElement(OutputItemElementName,
                            new XElement(KeyElementName, outputItem.Key),
                            new XElement(ValueElementName, outputItem.Value)))));

            return xdoc.Root;
        }

        internal static object SerializeXml(XmlNode xNode)
        {
            var ser = new DataContractSerializer(typeof(XmlNode[]));
            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, new XmlNode[] { xNode });
                ms.Seek(0, SeekOrigin.Begin);
                return new StreamReader(ms).ReadToEnd();
            }
        }

        public static XmlNode SerializeToXmlNode<T>(T o)
        {
            var objAsJson = SerializeToJson(o);
            var doc = new XmlDocument();
            //var readerSettings = new XmlReaderSettings();
            //readerSettings.DtdProcessing = DtdProcessing.Prohibit;
            return doc.CreateTextNode(objAsJson);
        }

        public static string SerializeToJson<T>(T o)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, o);
                ms.Seek(0, SeekOrigin.Begin);
                return new StreamReader(ms).ReadToEnd();
            }
        }

        public static string GetClusterUsernameFromPayloadObject(
            Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters cluster)
        {
            GatewayComponent gateway = cluster.Components.OfType<GatewayComponent>().Single();
            return gateway.RestAuthCredential.Username;
        }

        public static string GetClusterPasswordFromPayloadObject(
            Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters cluster)
        {
            GatewayComponent gateway = cluster.Components.OfType<GatewayComponent>().Single();
            return gateway.RestAuthCredential.Password;
        }

        public static int GetClusterSizeFromPayloadObject(Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters cluster)
        {
            var workerNodeRoles = cluster.ClusterRoleCollection.ToList().Where(role => role.FriendlyName == WorkerNodeRoleName).ToList();
            if (workerNodeRoles.Any())
            {
                return workerNodeRoles.First().InstanceCount;
            }
            return 0;
        }

        public static WabStorageAccountConfiguration GetDefaultStorageAccountFromFromPayloadObject(
            Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters cluster)
        {
            // For Yarn clusters (version later than 3.0 inclusive), the default storage account is for MapReduceApplication
            YarnComponent yarn = cluster.Components.OfType<YarnComponent>().Single();
            MapReduceApplication mrApp = yarn.Applications.OfType<MapReduceApplication>().Single();
            if (mrApp.DefaultStorageAccountAndContainer.ShouldProvisionNew)
            {
                return null;
            }
            return new WabStorageAccountConfiguration(
                mrApp.DefaultStorageAccountAndContainer.AccountDnsName,
                mrApp.DefaultStorageAccountAndContainer.Key,
                mrApp.DefaultStorageAccountAndContainer.BlobContainerName);
        }

        public static IEnumerable<WabStorageAccountConfiguration> GetAdditionalStorageAccountFromFromPayloadObject(
            Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters cluster)
        {
            // For Yarn clusters (HDI version starts from 3.0), the additional storage account is for MapReduceApplication
            YarnComponent yarn = cluster.Components.OfType<YarnComponent>().Single();
            MapReduceApplication mrApp = yarn.Applications.OfType<MapReduceApplication>().Single();
            var additionalStorageAccounts = mrApp.AdditionalStorageContainers.ToList();
            if (additionalStorageAccounts.Any())
            {
                var result = (from BlobContainerCredentialBackedResource tem in additionalStorageAccounts
                              select new WabStorageAccountConfiguration(tem.AccountDnsName, tem.Key, tem.BlobContainerName)).ToList();
                return result;
            }
            return Enumerable.Empty<WabStorageAccountConfiguration>();
        }

        private static HDInsight.ClusterCreateParametersV2 CreateClusterRequest_FromInternalV3(
            Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters payloadObject)
        {
            var cluster = new HDInsight.ClusterCreateParametersV2
            {
                Location = payloadObject.Location,
                Name = payloadObject.DnsName,
                UserName = GetClusterUsernameFromPayloadObject(payloadObject),
                Password = GetClusterPasswordFromPayloadObject(payloadObject),
                Version = payloadObject.Version,
                DefaultStorageAccountName = GetDefaultStorageAccountFromFromPayloadObject(payloadObject).Name,
                DefaultStorageAccountKey = GetDefaultStorageAccountFromFromPayloadObject(payloadObject).Key,
                DefaultStorageContainer = GetDefaultStorageAccountFromFromPayloadObject(payloadObject).Container,
                ClusterSizeInNodes = payloadObject.ClusterRoleCollection.ToList().Single(role => role.FriendlyName == WorkerNodeRoleName).InstanceCount,
            };

            var headNodeRole = payloadObject.ClusterRoleCollection.ToList().Where(role => role.FriendlyName == HeadNodeRoleName).ToList();
            if (headNodeRole.Any())
            {
                 cluster.HeadNodeSize = headNodeRole.First().VMSizeAsString;
            }

            var dataNodeRole = payloadObject.ClusterRoleCollection.ToList().Where(role => role.FriendlyName == WorkerNodeRoleName).ToList();
            if (dataNodeRole.Any())
            {
                cluster.DataNodeSize = dataNodeRole.First().VMSizeAsString;
            }

            var zookeeperNodeRole = payloadObject.ClusterRoleCollection.ToList().Where(role => role.FriendlyName == ZookeeperNodeRoleName).ToList();
            if (zookeeperNodeRole.Any())
            {
                cluster.ZookeeperNodeSize = zookeeperNodeRole.First().VMSizeAsString;
            }

            if (payloadObject.VirtualNetworkConfiguration != null)
            {
                cluster.VirtualNetworkId = payloadObject.VirtualNetworkConfiguration.VirtualNetworkSite;
                cluster.SubnetName = payloadObject.VirtualNetworkConfiguration.AddressAssignments.First().Subnets.First().Name;
            }

            CopyConfigurationForCluster(payloadObject, cluster);

            return cluster;
        }

        private static HDInsight.ClusterCreateParametersV2 CreateClusterRequest_FromInternal(ClusterContainer payloadObject)
        {
            var cluster = new HDInsight.ClusterCreateParametersV2
            {
                Location = payloadObject.Region,
                Name = payloadObject.ClusterName
            };
            cluster.UserName = payloadObject.Deployment.ClusterUsername;
            cluster.Password = payloadObject.Deployment.ClusterPassword;
            cluster.Version = payloadObject.Deployment.Version;
            cluster.DefaultStorageAccountName = payloadObject.StorageAccounts[0].AccountName;
            cluster.DefaultStorageAccountKey = payloadObject.StorageAccounts[0].Key;
            cluster.DefaultStorageContainer = payloadObject.StorageAccounts[0].BlobContainerName;

            var headnodeRole = payloadObject.Deployment.Roles.Single(r => r.RoleType == ClusterRoleType.HeadNode);

            //if headnode count is 1 and size XL, then we treat it as Default on the server side
            if (headnodeRole.VMSize == Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013.NodeVMSize.ExtraLarge && headnodeRole.Count == 1)
            {
                //changed this to no-op for ccpv2
                //cluster.HeadNodeSize = HDInsight.NodeVMSize.Default;
            }
            else switch (headnodeRole.VMSize)
            {
                case Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013.NodeVMSize.ExtraLarge:
                    cluster.HeadNodeSize = HDInsight.NodeVMSize.ExtraLarge.ToString();
                    break;
                case Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013.NodeVMSize.Large:
                    cluster.HeadNodeSize = HDInsight.NodeVMSize.Large.ToString();
                    break;
                default:
                    throw new InvalidDataContractException(string.Format("The server returned an unsupported value for head node VM size '{0}", headnodeRole.VMSize));
            }

            foreach (var asv in payloadObject.StorageAccounts.Skip(1))
            {
                cluster.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration(asv.AccountName, asv.Key));
            }

            if (payloadObject.Settings != null)
            {
                CopyConfiguration(payloadObject, cluster);

                if (payloadObject.Settings.Oozie != null)
                {
                    if (payloadObject.Settings.Oozie.Catalog != null)
                    {
                        var oozieMetaStore = payloadObject.Settings.Oozie.Catalog;
                        cluster.OozieMetastore = new Metastore(oozieMetaStore.Server,
                                                                        oozieMetaStore.DatabaseName,
                                                                        oozieMetaStore.Username,
                                                                        oozieMetaStore.Password);
                    }
                }

                if (payloadObject.Settings.Hive != null)
                {
                    if (payloadObject.Settings.Hive.Catalog != null)
                    {
                        var hiveMetaStore = payloadObject.Settings.Hive.Catalog;
                        cluster.HiveMetastore = new Metastore(hiveMetaStore.Server,
                                                                       hiveMetaStore.DatabaseName,
                                                                       hiveMetaStore.Username,
                                                                       hiveMetaStore.Password);
                    }
                }
            }

            cluster.ClusterSizeInNodes =
                payloadObject.Deployment.Roles.Where(r => r.RoleType == ClusterRoleType.DataNode)
                    .Sum(role => role.Count);

            return cluster;
        }

        private static Microsoft.WindowsAzure.Management.HDInsight.ClusterNodeType[] ConvertClusterRoleToClusterNodeType(CustomAction ca)
        {
            IList<Microsoft.WindowsAzure.Management.HDInsight.ClusterNodeType> cnt = 
                new List<Microsoft.WindowsAzure.Management.HDInsight.ClusterNodeType>();

            if (ca.ClusterRoleCollection.IsNotNull() && ca.ClusterRoleCollection.Count > 0)
            {
                // Converts ClusterRole to ClusterNodeType based on the assigned name.
                foreach (var cr in ca.ClusterRoleCollection)
                {
                    if (cr.FriendlyName.IsNullOrEmpty())
                    {
                        throw new ArgumentException("No valid node type provided.");
                    }

                    if (cr.FriendlyName.ToLower(CultureInfo.CurrentCulture).Equals("headnoderole"))
                    {
                        cnt.Add(Microsoft.WindowsAzure.Management.HDInsight.ClusterNodeType.HeadNode);
                    }
                    else if (cr.FriendlyName.ToLower(CultureInfo.CurrentCulture).Equals("workernoderole"))
                    {
                        cnt.Add(Microsoft.WindowsAzure.Management.HDInsight.ClusterNodeType.DataNode);
                    }
                    else
                    {
                        throw new NotSupportedException("No such node type supported.");
                    }
                }

            }

            return cnt.ToArray();
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
            Justification = "This complexity is needed to handle all the types in the submit payload.")]
        private static void CopyConfigurationForCluster(
            Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters payloadObject, HDInsight.ClusterCreateParametersV2 cluster)
        {
            var yarn = payloadObject.Components.OfType<YarnComponent>().Single();
            var mapreduce = yarn.Applications.OfType<MapReduceApplication>().Single();
            var hive = payloadObject.Components.OfType<HiveComponent>().Single();
            var oozie = payloadObject.Components.OfType<OozieComponent>().Single();
            var hdfs = payloadObject.Components.OfType<HdfsComponent>().Single();
            var hadoopCore = payloadObject.Components.OfType<HadoopCoreComponent>().Single();

            HBaseComponent hbase = null;
            if (payloadObject.Components.OfType<HBaseComponent>().Count() == 1)
            {
                hbase = payloadObject.Components.OfType<HBaseComponent>().Single();
            }
            StormComponent storm = null;
            if (payloadObject.Components.OfType<StormComponent>().Count() == 1)
            {
                storm = payloadObject.Components.OfType<StormComponent>().Single();
            }
            SparkComponent spark = null;
            if (payloadObject.Components.OfType<SparkComponent>().Count() == 1)
            {
                spark = payloadObject.Components.OfType<SparkComponent>().Single();
            }
            CustomActionComponent configActions = null;
            if (payloadObject.Components.OfType<CustomActionComponent>().Count() == 1)
            {
                configActions = payloadObject.Components.OfType<CustomActionComponent>().Single();
            }

            if (hadoopCore.CoreSiteXmlProperties.Any())
            {
                cluster.CoreConfiguration.AddRange(
                    hadoopCore.CoreSiteXmlProperties.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (hdfs.HdfsSiteXmlProperties.Any())
            {
                cluster.HdfsConfiguration.AddRange(hdfs.HdfsSiteXmlProperties.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (mapreduce.MapRedSiteXmlProperties.Any())
            {
                cluster.MapReduceConfiguration.ConfigurationCollection.AddRange(
                    mapreduce.MapRedSiteXmlProperties.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (mapreduce.CapacitySchedulerConfiguration.Any())
            {
                cluster.MapReduceConfiguration.CapacitySchedulerConfigurationCollection.AddRange(
                    mapreduce.CapacitySchedulerConfiguration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (mapreduce.AdditionalStorageContainers.ToList().Any())
            {
                cluster.AdditionalStorageAccounts.AddRange(
                    from BlobContainerCredentialBackedResource tem in mapreduce.AdditionalStorageContainers
                    select new WabStorageAccountConfiguration(tem.AccountDnsName, tem.Key, tem.BlobContainerName));
            }

            if (yarn.Configuration.Any())
            {
                cluster.YarnConfiguration.AddRange(yarn.Configuration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (hive.HiveSiteXmlProperties.Any())
            {
                cluster.HiveConfiguration.ConfigurationCollection.AddRange(
                    hive.HiveSiteXmlProperties.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (hive.AdditionalLibraries != null)
            {
                cluster.HiveConfiguration.AdditionalLibraries = new WabStorageAccountConfiguration(
                    hive.AdditionalLibraries.AccountDnsName, hive.AdditionalLibraries.Key, hive.AdditionalLibraries.BlobContainerName);
            }

            if (!hive.Metastore.ShouldProvisionNew)
            {
                var metaStore = (SqlAzureDatabaseCredentialBackedResource)hive.Metastore;
                cluster.HiveMetastore = new Metastore(
                    metaStore.SqlServerName, metaStore.DatabaseName, metaStore.Credentials.Username, metaStore.Credentials.Password);
            }

            if (configActions != null)
            {
                foreach (var configAction in configActions.CustomActions)
                {
                    ScriptCustomAction sca = configAction as ScriptCustomAction;

                    if (sca != null)
                    {
                        cluster.ConfigActions.Add(new ScriptAction(
                                sca.Name, ConvertClusterRoleToClusterNodeType(sca), sca.Uri, sca.Parameters));
                    }
                }
            }

            if (oozie.Configuration.Any())
            {
                cluster.OozieConfiguration.ConfigurationCollection.AddRange(
                    oozie.Configuration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (oozie.AdditionalSharedLibraries != null)
            {
                cluster.OozieConfiguration.AdditionalSharedLibraries =
                    new WabStorageAccountConfiguration(
                        oozie.AdditionalSharedLibraries.AccountDnsName,
                        oozie.AdditionalSharedLibraries.Key,
                        oozie.AdditionalSharedLibraries.BlobContainerName);
            }

            if (oozie.AdditionalActionExecutorLibraries != null)
            {
                cluster.OozieConfiguration.AdditionalActionExecutorLibraries =
                    new WabStorageAccountConfiguration(
                        oozie.AdditionalActionExecutorLibraries.AccountDnsName,
                        oozie.AdditionalActionExecutorLibraries.Key,
                        oozie.AdditionalActionExecutorLibraries.BlobContainerName);
            }

            if (!oozie.Metastore.ShouldProvisionNew)
            {
                var metaStore = (SqlAzureDatabaseCredentialBackedResource)oozie.Metastore;
                cluster.OozieMetastore = new Metastore(
                    metaStore.SqlServerName, metaStore.DatabaseName, metaStore.Credentials.Username, metaStore.Credentials.Password);
            }

            if (hbase != null && hbase.HBaseConfXmlProperties.Any())
            {
                cluster.HBaseConfiguration.ConfigurationCollection.AddRange(
                    hbase.HBaseConfXmlProperties.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (hbase != null && hbase.AdditionalLibraries != null)
            {
                cluster.HBaseConfiguration.AdditionalLibraries = new WabStorageAccountConfiguration(
                    hbase.AdditionalLibraries.AccountDnsName, hbase.AdditionalLibraries.Key, hbase.AdditionalLibraries.BlobContainerName);
            }

            if (storm != null && storm.StormConfiguration.Any())
            {
                cluster.StormConfiguration.AddRange(
                    storm.StormConfiguration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (spark != null && spark.SparkConfiguration.Any())
            {
                cluster.SparkConfiguration.AddRange(
                    spark.SparkConfiguration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "This complexity is needed to handle all the types in the submit payload.")]
        private static void CopyConfiguration(ClusterContainer payloadObject, HDInsight.ClusterCreateParametersV2 cluster)
        {
            if (payloadObject.Settings.Core != null && payloadObject.Settings.Core.Configuration != null)
            {
                cluster.CoreConfiguration.AddRange(
                    payloadObject.Settings.Core.Configuration.Select(config => new KeyValuePair<string, string>(config.Name, config.Value)));
            }

            if (payloadObject.Settings.Yarn != null && payloadObject.Settings.Yarn.Configuration != null)
            {
                cluster.YarnConfiguration.AddRange(
                    payloadObject.Settings.Yarn.Configuration.Select(config => new KeyValuePair<string, string>(config.Name, config.Value)));
            }

            if (payloadObject.Settings.Hive != null)
            {
                if (payloadObject.Settings.Hive.AdditionalLibraries != null)
                {
                    cluster.HiveConfiguration.AdditionalLibraries =
                        new WabStorageAccountConfiguration(
                            payloadObject.Settings.Hive.AdditionalLibraries.AccountName,
                            payloadObject.Settings.Hive.AdditionalLibraries.Key,
                            payloadObject.Settings.Hive.AdditionalLibraries.BlobContainerName);
                }

                if (payloadObject.Settings.Hive.Configuration != null)
                {
                    cluster.HiveConfiguration.ConfigurationCollection.AddRange(
                        payloadObject.Settings.Hive.Configuration.Select(config => new KeyValuePair<string, string>(config.Name, config.Value)));
                }
            }

            if (payloadObject.Settings.Hdfs != null && payloadObject.Settings.Hdfs.Configuration != null)
            {
                cluster.HdfsConfiguration.AddRange(
                    payloadObject.Settings.Hdfs.Configuration.Select(config => new KeyValuePair<string, string>(config.Name, config.Value)));
            }

            if (payloadObject.Settings.MapReduce != null && payloadObject.Settings.MapReduce.Configuration != null)
            {
                cluster.MapReduceConfiguration = new HDInsight.MapReduceConfiguration();

                if (payloadObject.Settings.MapReduce.Configuration != null)
                {
                    cluster.MapReduceConfiguration.ConfigurationCollection.AddRange(
                        payloadObject.Settings.MapReduce.Configuration.Select(config => new KeyValuePair<string, string>(config.Name, config.Value)));
                }

                if (payloadObject.Settings.MapReduce.CapacitySchedulerConfiguration != null)
                {
                    cluster.MapReduceConfiguration.CapacitySchedulerConfigurationCollection.AddRange(
                        payloadObject.Settings.MapReduce.CapacitySchedulerConfiguration.Select(config => new KeyValuePair<string, string>(config.Name, config.Value)));
                }
            }

            if (payloadObject.Settings.Oozie != null && payloadObject.Settings.Oozie.Configuration != null)
            {
                if (cluster.OozieConfiguration.ConfigurationCollection != null)
                {
                    cluster.OozieConfiguration.ConfigurationCollection.AddRange(
                        payloadObject.Settings.Oozie.Configuration.Select(config => new KeyValuePair<string, string>(config.Name, config.Value)));
                }

                if (payloadObject.Settings.Oozie.AdditionalSharedLibraries != null)
                {
                    cluster.OozieConfiguration.AdditionalSharedLibraries =
                       new WabStorageAccountConfiguration(
                           payloadObject.Settings.Oozie.AdditionalSharedLibraries.AccountName,
                           payloadObject.Settings.Oozie.AdditionalSharedLibraries.Key,
                           payloadObject.Settings.Oozie.AdditionalSharedLibraries.BlobContainerName);
                }

                if (payloadObject.Settings.Oozie.AdditionalActionExecutorLibraries != null)
                {
                    cluster.OozieConfiguration.AdditionalActionExecutorLibraries =
                       new WabStorageAccountConfiguration(
                           payloadObject.Settings.Oozie.AdditionalActionExecutorLibraries.AccountName,
                           payloadObject.Settings.Oozie.AdditionalActionExecutorLibraries.Key,
                           payloadObject.Settings.Oozie.AdditionalActionExecutorLibraries.BlobContainerName);
                }
            }
        }

        private static Resource ListClusterContainerResult_ToInternal(ClusterDetails result, string nameSpace, bool writeError, bool writeExtendedError)
        {
            var resource = new Resource { Name = result.Name, SubState = result.StateString, ResourceProviderNamespace = nameSpace, Type = "containers" };
            if (result.AdditionalStorageAccounts == null)
            {
                result.AdditionalStorageAccounts = new List<WabStorageAccountConfiguration>();
            }
            resource.Type = "containers";
            resource.OutputItems = new OutputItemList
            {
                new OutputItem { Key = CreatedDate, Value = result.CreatedDate.ToString(CultureInfo.InvariantCulture) },
                new OutputItem { Key = ConnectionUrl, Value = result.ConnectionUrl },
                new OutputItem { Key = ClusterUserName, Value = result.HttpUserName },
                new OutputItem { Key = Version, Value = result.Version },
                new OutputItem { Key = BlobContainers, Value = SerializeStorageAccounts(result) },
                new OutputItem { Key = NodesCount, Value = result.ClusterSizeInNodes.ToString(CultureInfo.InvariantCulture) }
            };

            if (result.Error != null)
            {
                if (writeError)
                {
                    resource.OperationStatus = new ResourceOperationStatus { Type = result.Error.OperationType };
                    resource.OperationStatus.Error = new ResourceErrorInfo { HttpCode = result.Error.HttpCode, Message = result.Error.Message };
                }

                if (writeExtendedError)
                {
                    resource.OperationStatus = new ResourceOperationStatus { Type = result.Error.OperationType };
                    resource.OperationStatus.Error = new ResourceErrorInfo { HttpCode = result.Error.HttpCode, Message = result.Error.Message };
                    resource.OutputItems.Add(new OutputItem { Key = ExtendedErrorMessage, Value = result.Error.Message });
                }
            }

            var intrinsicSettings = new List<OutputItem> 
            {
                new OutputItem { Key = RdpUserName, Value = result.RdpUserName },
                new OutputItem { Key = HttpUserName, Value = result.HttpUserName },
                new OutputItem { Key = HttpPassword, Value = result.HttpPassword },
                new OutputItem { Key = Version, Value = result.Version }
            };

            resource.IntrinsicSettings = new XmlNode[] { SerializeToXmlNode(intrinsicSettings) };
            return resource;
        }

        private static string SerializeStorageAccounts(ClusterDetails cluster)
        {
            var blobContainerReferences = new List<BlobContainerSerializedAsJson>();
            if (cluster.DefaultStorageAccount != null)
            {
                blobContainerReferences.Add(
                    new BlobContainerSerializedAsJson()
                    {
                        AccountName = cluster.DefaultStorageAccount.Name,
                        Key = cluster.DefaultStorageAccount.Key,
                        Container = cluster.DefaultStorageAccount.Container
                    });
            }

            blobContainerReferences.AddRange(cluster.AdditionalStorageAccounts.Select(
                        acc => new BlobContainerSerializedAsJson() { AccountName = acc.Name, Key = acc.Key, Container = acc.Container }));

            return SerializeToJson(blobContainerReferences.ToList());
        }

        private static T DeserializeFromXml<T>(string data) where T : new()
        {
            var ser = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                return (T)ser.ReadObject(ms);
            }
        }

        [DataContract]
        internal class BlobContainerSerializedAsJson
        {
            [DataMember]
            public string Key { get; set; }

            [DataMember]
            public string AccountName { get; set; }

            [DataMember]
            public string Container { get; set; }
        }
    }
}
