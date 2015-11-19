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
namespace Microsoft.WindowsAzure.Management.HDInsight.InversionOfControl
{
    using System;
    using Microsoft.Hadoop.Client.ClientLayer;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Asv;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.AzureManagementClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ClusterManager;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.LocationFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ResourceTypeFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.ClustersResource;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.IaasClusters;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.RestClient;

    /// <summary>
    /// Registers services with the IOC for use by this assembly.
    /// </summary>
    internal class SdkServiceLocationRegistrar : IServiceLocationRegistrar
    {
        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "This method is registering types for use as a part of a service location patern, coupling is expected. WF")]
        public void Register(IServiceLocationRuntimeManager manager, IServiceLocator locator)
        {
            if (manager.IsNull())
            {
                throw new ArgumentNullException("manager");
            }

            if (locator.IsNull())
            {
                throw new ArgumentNullException("locator");
            }

            var overrideManager = new HDInsightClusterOverrideManager();
            overrideManager.AddOverride<HDInsightCertificateCredential>(new VersionFinderClientFactory(),
                                                                        new HDInsightManagementRdfeUriBuilderFactory(),
                                                                        new PayloadConverter());

            overrideManager.AddOverride<HDInsightAccessTokenCredential>(new VersionFinderClientFactory(),
                                                                        new HDInsightManagementRdfeUriBuilderFactory(),
                                                                        new PayloadConverter());

            manager.RegisterInstance<IHDInsightClusterOverrideManager>(overrideManager);
            manager.RegisterType<ICloudServiceNameResolver, CloudServiceNameResolver>();
            manager.RegisterType<IHDInsightManagementRestClientFactory, HDInsightManagementRestClientFactory>();
            manager.RegisterType<IHDInsightManagementPocoClientFactory, HDInsightManagementPocoClientFactory>();
            manager.RegisterType<IHDInsightJobSubmissionRestClientFactory, HDInsightJobSubmissionRestClientFactory>();
            manager.RegisterType<IHDInsightClientFactory, HDInsightClientFactory>();
            manager.RegisterType<IAsvValidatorClientFactory, AsvValidatorValidatorClientFactory>();
            manager.RegisterType<IHDInsightSubscriptionCredentialsFactory, ProductionIHDInsightSubscriptionCertificateCredentialsFactory>();
            manager.RegisterType<ISubscriptionRegistrationClientFactory, SubscriptionRegistrationClientFactory>();
            manager.RegisterType<ILocationFinderClientFactory, LocationFinderClientFactory>();
            manager.RegisterType<IRdfeServiceRestClientFactory, RdfeServiceRestClientFactory>();
            manager.RegisterType<IHDInsightJobSubmissionPocoClientFactory, HDInsightJobSubmissionPocoClientFactory>();
            manager.RegisterType<IHDInsightHttpClientAbstractionFactory, HDInsightHttpClientAbstractionFactory>();
            manager.RegisterType<IJobSubmissionCache, JobSubmissionCache>();
            manager.RegisterType<IRdfeClustersResourceRestClientFactory, RdfeClustersResourceRestClientFactory>();
            manager.RegisterType<IRdfeResourceTypeFinderFactory, RdfeResourceTypeFinderClientFactory>();
            manager.RegisterType<IRdfeIaasClustersRestClientFactory, RdfeIaasClustersRestClientFactory>();
            
            var changeManager = new UserChangeRequestManager();
            changeManager.RegisterUserChangeRequestHandler(typeof (HDInsightCertificateCredential),
                UserChangeRequestUserType.Http, HttpChangeRequestUriBuilder,
                PayloadConverter.SerializeHttpConnectivityRequest);
            changeManager.RegisterUserChangeRequestHandler(typeof (HDInsightCertificateCredential),
                UserChangeRequestUserType.Rdp, RdpChangeRequestUriBuilder,
                PayloadConverter.SerializeRdpConnectivityRequest);
            manager.RegisterInstance<IUserChangeRequestManager>(changeManager);
            var hadoopManager = locator.Locate<IHadoopClientFactoryManager>();
            hadoopManager.RegisterFactory<JobSubmissionCertificateCredential, IHDInsightHadoopClientFactory, HDInsightHadoopClientFactory>();
            hadoopManager.RegisterFactory<JobSubmissionAccessTokenCredential, IHDInsightHadoopClientFactory, HDInsightHadoopClientFactory>();
        }

        internal static Uri HttpChangeRequestUriBuilder(IHDInsightSubscriptionAbstractionContext context, string dnsName, string location)
        {
            var overrideHandlers =
                ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>()
                    .GetHandlers(context.Credentials, context, false);
            return overrideHandlers.UriBuilder.GetEnableDisableHttpUri(dnsName, location);
        }

        internal static Uri RdpChangeRequestUriBuilder(IHDInsightSubscriptionAbstractionContext context, string dnsName,
            string location)
        {
            var overrideHandlers =
                ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>()
                    .GetHandlers(context.Credentials, context, false);
            return overrideHandlers.UriBuilder.GetEnableDisableRdpUri(dnsName, location);
        }
    }
}
