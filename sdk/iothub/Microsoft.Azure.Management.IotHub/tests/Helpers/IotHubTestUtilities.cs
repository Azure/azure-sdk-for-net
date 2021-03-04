// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Net;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ServiceBus;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace IotHub.Tests.Helpers
{
    public class IotHubTestUtilities
    {
        public static string DefaultLocation = "WestUS2";
        public static string DefaultFailoverLocation = "WestCentralUS";
        public static string DefaultIotHubName = "DotNetHub";
        public static string DefaultUpdateIotHubName = "UpdateDotNetHub";
        public static string DefaultResourceGroupName = "DotNetHubRG";
        public static string DefaultUpdateResourceGroupName = "UpdateDotNetHubRG";
        public static string EventsEndpointName = "events";
        public static string DefaultCertificateIotHubName = "DotNetCertificateHub";
        public static string DefaultCertificateResourceGroupName = "DotNetCertificateHubRG";
        public static string DefaultIotHubCertificateName = "DotNetCertificateHubCertificate";
        public static string DefaultIotHubCertificateSubject = "Azure IoT Root CA";
        public static string DefaultIotHubCertificateThumbprint = "9F0983E8F2DB2DB3582997FEF331247D872DEE32";
        public static string DefaultIotHubCertificateType = "Microsoft.Devices/IotHubs/Certificates";
        public static string DefaultIotHubCertificateContent = "MIIBvjCCAWOgAwIBAgIQG6PoBFT6GLJGNKn/EaxltTAKBggqhkjOPQQDAjAcMRow"
                                                             + "GAYDVQQDDBFBenVyZSBJb1QgUm9vdCBDQTAeFw0xNzExMDMyMDUyNDZaFw0xNzEy"
                                                             + "MDMyMTAyNDdaMBwxGjAYBgNVBAMMEUF6dXJlIElvVCBSb290IENBMFkwEwYHKoZI"
                                                             + "zj0CAQYIKoZIzj0DAQcDQgAE+CgpnW3K+KRNIi/U6Zqe/Al9m8PExHX2KgakmGTf"
                                                             + "E04nNBwnSoygWb0ekqpT+Lm+OP56LMMe9ynVNryDEr9OSKOBhjCBgzAOBgNVHQ8B"
                                                             + "Af8EBAMCAgQwHQYDVR0lBBYwFAYIKwYBBQUHAwIGCCsGAQUFBwMBMB8GA1UdEQQY"
                                                             + "MBaCFENOPUF6dXJlIElvVCBSb290IENBMBIGA1UdEwEB/wQIMAYBAf8CAQwwHQYD"
                                                             + "VR0OBBYEFDjiklfHQzw1G0A33BcmRQTjAivTMAoGCCqGSM49BAMCA0kAMEYCIQCt"
                                                             + "jJ4bAvoYuDhwr92Kk+OkvpPF+qBFiRfrA/EC4YGtzQIhAO79WPtbUnBQ5fsQnW2a"
                                                             + "UAT4yJGWL+7l4/qfmqblb96n";
        public static IotHubClient GetIotHubClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<IotHubClient>(handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static EventHubManagementClient GetEhClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<EventHubManagementClient>(handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static ServiceBusManagementClient GetSbClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<ServiceBusManagementClient>(handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }
    }
}
