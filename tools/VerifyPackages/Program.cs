using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.WindowsAzure.Management.Scheduler.Models;
using Microsoft.WindowsAzure.Management.TrafficManager;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using System.Xml.Linq;

namespace VerifyPackages
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                throw new ArgumentNullException("publish settings informations");
            }
            SubscriptionCloudCredentials cred = GetCredentials(args[0]);

            //WATM
            TrafficManagerManagementClient watmClient = new TrafficManagerManagementClient(cred);
            string atmDns = "adxsdk12345.trafficmanager.net";
            DnsPrefixAvailabilityCheckResponse watmResp = 
                watmClient.Profiles.CheckDnsPrefixAvailability("adxsdk12345.trafficmanager.net");
            Console.WriteLine("Invoke WATM->CheckDnsPrefixAvailability(\'{0}\'). Result: {1}", atmDns, watmResp.Result);

            //Compute
            ComputeManagementClient computeClient = new ComputeManagementClient(cred);
            string hostServiceName = "adxsdk12345";
            HostedServiceCheckNameAvailabilityResponse computeResp = 
                computeClient.HostedServices.CheckNameAvailability(hostServiceName);
            Console.WriteLine("Invoke Compute->CheckNameAvailability(\'{0}\'). Result: {1}", 
                hostServiceName, computeResp.IsAvailable);

            //Websites
            WebSiteManagementClient websiteClient = new WebSiteManagementClient(cred);
            string webSiteName = "adxsdk12345";
            WebSiteIsHostnameAvailableResponse webSiteResp = websiteClient.WebSites.IsHostnameAvailable(webSiteName);
            Console.WriteLine("Invoke WebSite->IsHostnameAvailable(\'{0}\'). Result: {1}", 
                webSiteName, webSiteResp.IsAvailable);

            //Scheduler
            SchedulerManagementClient schedulerClient = new SchedulerManagementClient(cred);
            string schedulerCloudServiceName = "foobarrr";
            string expectedSchedulerException = string.Format(
                "ResourceNotFound: The cloud service with name {0} was not found.", schedulerCloudServiceName);
            bool exceptionFromSchedulerServiceOccurred = false;
            try
            {
                schedulerClient.JobCollections.CheckNameAvailability(schedulerCloudServiceName, "doesnotmatter");
            }
            catch (Exception ex)
            {
                if (ex.Message == expectedSchedulerException)
                {
                    exceptionFromSchedulerServiceOccurred = true;
                    Console.WriteLine("Invoke Scheduler->CheckNameAvailability(\'{0}\'). Get back correct exception", 
                        schedulerCloudServiceName, expectedSchedulerException);
                }
            }
            if (!exceptionFromSchedulerServiceOccurred)
            {
                throw new Exception("we didn't get expected exception message from scheduler service");
            }

            Console.WriteLine("Smoke test is good");
        }

        private static SubscriptionCloudCredentials GetCredentials(string publishSettingsFile)
        {
            string xml = System.IO.File.ReadAllText(publishSettingsFile);
            XElement root = XElement.Parse(xml);
            string certificate = root.Descendants("PublishProfile").First()
                .Attributes("ManagementCertificate").First().Value;
            string subscriptionId = root.Descendants("PublishProfile").First()
                .Descendants("Subscription").First().Attributes("Id").First().Value;

            return new CertificateCloudCredentials(subscriptionId,
                new X509Certificate2(Convert.FromBase64String(certificate)));
        }
    }
}
