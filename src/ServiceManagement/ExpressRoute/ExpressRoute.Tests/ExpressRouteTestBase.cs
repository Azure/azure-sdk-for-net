//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Management.ExpressRoute.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using Hyak.Common;
    using Microsoft.WindowsAzure.Management.ExpressRoute;
    using Test;
    using Test.HttpRecorder;
    using Test.PublishSettings;

    public abstract class ExpressRouteTestBase : TestBase
    {
        public static string FakeServiceKey = (new Guid()).ToString();

        public const int PrivatePeerAsn = 64495;

        public const string PrivatePrimaryPeerSubnet = "192.168.6.252/30";

        public const string PrivateSecondaryPeerSubnet = "192.168.9.252/30";

        public const int PrivateVlanId = 1349;

        public const int PublicPeerAsn = 64494;

        public const string PublicPrimaryPeerSubnet = "192.168.7.252/30";

        public const string PublicSecondaryPeerSubnet = "192.168.10.252/30";

        public const int PublicVlanId = 1350;

        public const int UpdatePrivatePeerAsn = 14495;

        public const string UpdatePrivatePrimaryPeerSubnet = "192.168.1.252/30";

        public const string UpdatePrivateSecondaryPeerSubnet = "192.168.2.252/30";

        public const int UpdatePrivateVlanId = 1370;

        public const int UpdatePublicPeerAsn = 14495;

        public const string UpdatePublicPrimaryPeerSubnet = "192.168.3.252/30";

        public const string UpdatePublicSecondaryPeerSubnet = "192.168.4.252/30";

        public const int UpdatePublicVlanId = 1371;

        public const string InvalidSubnet = "98.251.199.31/30";

        public const int DefaultCircuitBandwidth = 999;

        public static ExpressRouteManagementClient GetCustomerExpressRouteManagementClient()
        {
            return GetServiceClient<ExpressRouteManagementClient>();
        }


        public static ExpressRouteManagementClient GetSecondCustomerExpressRouteManagementClient()
        {
            string managementCertificate = "";
            string baseUri;
            string subscriptionId;
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                baseUri = HttpMockServer.Variables["TEST_CUSTOMER2_BASE_URI"];
                subscriptionId = HttpMockServer.Variables["TEST_CUSTOMER2_SUBSCRIPTION_ID"];
                managementCertificate = HttpMockServer.Variables["TEST_CUSTOMER2_MANAGEMENT_CERTIFICATE"];
            }
            else
            {
                string publishSettingsFile = Environment.GetEnvironmentVariable("TEST_CUSTOMER2_PUBLISHSETTINGS_FILE");
                PublishData publishData = XmlSerializationHelpers.DeserializeXmlFile<PublishData>(publishSettingsFile);
                managementCertificate = Enumerable.First<PublishDataPublishProfile>((IEnumerable<PublishDataPublishProfile>) publishData.Items).ManagementCertificate;
                if (string.IsNullOrEmpty(managementCertificate))
                    managementCertificate = Enumerable.First<PublishDataPublishProfileSubscription>((IEnumerable<PublishDataPublishProfileSubscription>) Enumerable.First<PublishDataPublishProfile>((IEnumerable<PublishDataPublishProfile>) publishData.Items).Subscription).ManagementCertificate;
                if (string.IsNullOrEmpty(managementCertificate))
                    throw new ArgumentException(string.Format("{0} is not a valid publish settings file, you must provide a valid publish settings file in the environment variable {1}", (object) publishSettingsFile, (object) "TEST_PUBLISHSETTINGS_FILE"));
                
                
                subscriptionId = Enumerable.First<PublishDataPublishProfileSubscription>((IEnumerable<PublishDataPublishProfileSubscription>) Enumerable.First<PublishDataPublishProfile>((IEnumerable<PublishDataPublishProfile>) publishData.Items).Subscription).Id;
                
                baseUri =  Enumerable.First<PublishDataPublishProfileSubscription>(
                        (IEnumerable<PublishDataPublishProfileSubscription>)
                        Enumerable.First<PublishDataPublishProfile>(
                            (IEnumerable<PublishDataPublishProfile>) publishData.Items).Subscription)
                              .ServiceManagementUrl ?? publishData.Items[0].Url;

                HttpMockServer.Variables["TEST_CUSTOMER2_MANAGEMENT_CERTIFICATE"] = managementCertificate;
                HttpMockServer.Variables["TEST_CUSTOMER2_SUBSCRIPTION_ID"] = subscriptionId;
                HttpMockServer.Variables["TEST_CUSTOMER2_BASE_URI"] = baseUri;
            }

            var credentials = new CertificateCloudCredentials(subscriptionId, new X509Certificate2(Convert.FromBase64String(managementCertificate), string.Empty));
            var client = new ExpressRouteManagementClient(credentials, new Uri(baseUri));
            client.AddHandlerToPipeline(HttpMockServer.CreateInstance());
            return client;
        }

        public static ExpressRouteManagementClient GetProviderExpressRouteManagementClient()
        {
            
            string managementCertificate = "";
            string baseUri;
            string subscriptionId;
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                baseUri = HttpMockServer.Variables["TEST_PROVIDER_BASE_URI"];
                subscriptionId = HttpMockServer.Variables["TEST_PROVIDER_SUBSCRIPTION_ID"];
                managementCertificate = HttpMockServer.Variables["TEST_PROVIDER_MANAGEMENT_CERTIFICATE"];
            }
            else
            {
                string publishSettingsFile = Environment.GetEnvironmentVariable("TEST_PUBLISHSETTINGS_FILE_P");
                if (string.IsNullOrEmpty(publishSettingsFile))
                {
                    // Take default path
                    publishSettingsFile = @"C:\Powershell\PublishSettings\defaultProvider.publishsettings";
                }
                PublishData publishData = XmlSerializationHelpers.DeserializeXmlFile<PublishData>(publishSettingsFile);
                managementCertificate = Enumerable.First<PublishDataPublishProfile>((IEnumerable<PublishDataPublishProfile>)publishData.Items).ManagementCertificate;
                if (string.IsNullOrEmpty(managementCertificate))
                    managementCertificate = Enumerable.First<PublishDataPublishProfileSubscription>((IEnumerable<PublishDataPublishProfileSubscription>)Enumerable.First<PublishDataPublishProfile>((IEnumerable<PublishDataPublishProfile>)publishData.Items).Subscription).ManagementCertificate;
                if (string.IsNullOrEmpty(managementCertificate))
                    throw new ArgumentException(string.Format("{0} is not a valid publish settings file, you must provide a valid publish settings file in the environment variable {1}", (object)publishSettingsFile, (object)"TEST_PROVIDER_PUBLISHSETTINGS_FILE"));


                subscriptionId = Enumerable.First<PublishDataPublishProfileSubscription>((IEnumerable<PublishDataPublishProfileSubscription>)Enumerable.First<PublishDataPublishProfile>((IEnumerable<PublishDataPublishProfile>)publishData.Items).Subscription).Id;

                baseUri = Enumerable.First<PublishDataPublishProfileSubscription>(
                        (IEnumerable<PublishDataPublishProfileSubscription>)
                        Enumerable.First<PublishDataPublishProfile>(
                            (IEnumerable<PublishDataPublishProfile>)publishData.Items).Subscription)
                              .ServiceManagementUrl ?? publishData.Items[0].Url;

                HttpMockServer.Variables["TEST_PROVIDER_MANAGEMENT_CERTIFICATE"] = managementCertificate;
                HttpMockServer.Variables["TEST_PROVIDER_SUBSCRIPTION_ID"] = subscriptionId;
                HttpMockServer.Variables["TEST_PROVIDER_BASE_URI"] = baseUri;
            }

            var credentials = new CertificateCloudCredentials(subscriptionId, new X509Certificate2(Convert.FromBase64String(managementCertificate), string.Empty));
            var client = new ExpressRouteManagementClient(credentials, new Uri(baseUri));
            client.AddHandlerToPipeline(HttpMockServer.CreateInstance());
            return client;
        }

        public static string GetProviderName()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                return HttpMockServer.Variables["TEST_PROVIDER_NAME"];
            }
            else
            {
                HttpMockServer.Variables["TEST_PROVIDER_NAME"] = Environment.GetEnvironmentVariable("TEST_PROVIDER_NAME");
                return Environment.GetEnvironmentVariable("TEST_PROVIDER_NAME");
            }
        }

        public static string GetVNetName()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                return HttpMockServer.Variables["TEST_VNET_NAME"];
            }
            else
            {
                HttpMockServer.Variables["TEST_VNET_NAME"] = Environment.GetEnvironmentVariable("TEST_VNET_NAME");
                return Environment.GetEnvironmentVariable("TEST_VNET_NAME");
            }
        }

    }
}
