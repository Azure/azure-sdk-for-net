using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Azure.Management.v1_7;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace APITests
{
    /// <summary>
    /// This class tests the various List XXX methods
    /// they require no special setup, so just simple calls
    /// that should succeed
    /// </summary>
    [TestClass]
    public class TaskListTests : TaskTestsBase
    {
        public TaskListTests()
        {
        }

        [TestMethod]
        public void ListCloudServices()
        {
            this.TestContext.WriteLine("Beginning ListCloudServices test.");
            CancellationToken token = this.TokenSource.Token;

            var task = TestClient.ListCloudServicesAsync(token);

            this.TestContext.WriteLine(task.Result.ToString());

            this.TestContext.WriteLine("Enumerating properties of CloudServices.");
            foreach (var service in task.Result)
            {
                this.TestContext.WriteLine("Getting properties for Cloud Service with Label: {0}", service.Label);

                var propsTask = TestClient.GetCloudServicePropertiesAsync(service.ServiceName);

                //should be no deployments if embedDetail is false...
                Assert.IsNull(propsTask.Result.Deployments);

                this.TestContext.WriteLine(propsTask.Result.ToString());

                this.TestContext.WriteLine("Getting properties for Cloud Service with Label, and embedding detail: {0}", service.Label);

                var propsTask2 = TestClient.GetCloudServicePropertiesAsync(service.ServiceName, true, token);

                this.TestContext.WriteLine(propsTask2.Result.ToString());
            }

            this.TestContext.WriteLine("Done Enumerating properties of CloudServices.");

            this.TestContext.WriteLine("Ending ListCloudServices test.");
        }

        [TestMethod]
        public void ListStorageAccounts()
        {
            this.TestContext.WriteLine("Beginning ListStorageAccounts test.");
            CancellationToken token = this.TokenSource.Token;

            var task = TestClient.ListStorageAccountsAsync(token);

            this.TestContext.WriteLine(task.Result.ToString());

            this.TestContext.WriteLine("Enumerating StorageAccount properties and Keys.");
            foreach (var account in task.Result)
            {
                this.TestContext.WriteLine("Getting properties for Storage account {0}", account.Name);
                var propsTask = TestClient.GetStorageAccountPropertiesAsync(account.Name);

                this.TestContext.WriteLine(propsTask.Result.ToString());

                this.TestContext.WriteLine("Getting keys for Storage account with Label: {0}", account.Label);
                var keysTask = TestClient.GetStorageAccountKeysAsync(account.Name);

                this.TestContext.WriteLine(keysTask.Result.ToString());
            }
            this.TestContext.WriteLine("Done Enumerating properties of Storage accounts.");

            this.TestContext.WriteLine("Ending ListStorageAccounts test.");
        }

        [TestMethod]
        public void ListLocations()
        {
            this.TestContext.WriteLine("Beginning ListLocations test.");
            CancellationToken token = this.TokenSource.Token;

            var task = TestClient.ListLocationsAsync(token);
            this.TestContext.WriteLine(task.Result.ToString());

            //there is no GetLocation, so no reason to loop here

            this.TestContext.WriteLine("Ending ListLocations test.");
        }

        [TestMethod]
        public void ListAffinityGroups()
        {
            this.TestContext.WriteLine("Beginning ListAffinityGroups test.");
            CancellationToken token = this.TokenSource.Token;

            var task = TestClient.ListAffinityGroupsAsync(token);

            this.TestContext.WriteLine(task.Result.ToString());

            this.TestContext.WriteLine("Enumerating Affinity Groups");
            foreach (var ag in task.Result)
            {
                this.TestContext.WriteLine("Getting properties for Affinity Group {0}", ag.Name);
                var propsTask = TestClient.GetAffinityGroupAsync(ag.Name);

                this.TestContext.WriteLine(propsTask.Result.ToString());
            }
            this.TestContext.WriteLine("Done Enumerating properties of AffinityGroups.");
            this.TestContext.WriteLine("Ending ListAffinityGroups test.");
        }

        [TestMethod]
        public void ListManagementCertificates()
        {
            this.TestContext.WriteLine("Beginning ListManagementCertificates test.");
            CancellationToken token = this.TokenSource.Token;

            var task = TestClient.ListManagementCertificatesAsync(token);

            this.TestContext.WriteLine(task.Result.ToString());

            this.TestContext.WriteLine("Enumerating Management Certificates");
            foreach (var cert in task.Result)
            {
                this.TestContext.WriteLine("Getting properties for Management Certificate with thumbpring {0}", cert.Thumbprint);
                var propsTask = TestClient.GetManagementCertificateAsync(cert.Thumbprint);

                this.TestContext.WriteLine(propsTask.Result.ToString());
            }
            this.TestContext.WriteLine("Done Enumerating properties of Management Certificates.");
            this.TestContext.WriteLine("Ending ListManagementCertificates test.");
        }

        [TestMethod]
        public void AddListGetDeleteManagementCertificate()
        {
            this.TestContext.WriteLine("Beginning AddListGetDeleteManagementCertificate test.");
            CancellationToken token = this.TokenSource.Token;

            X509Certificate2 cert = Utilities.CreateCert(false);

            this.TestContext.WriteLine("Adding ManagementCertificate with thumbprint {0}.", cert.Thumbprint);
            var addTask = TestClient.AddManagementCertificateAsync(cert);

            addTask.Wait();

            this.TestContext.WriteLine("Certificate with thumbprint {0} added.", cert.Thumbprint);

            this.TestContext.WriteLine("To make sure the certificate works, the rest of the API calls in this test will use the new certificate.");
            this.TestContext.WriteLine("Instantiating new AzureHttpClient with cert with thumbprint: {0}", cert.Thumbprint);
            //make sure the cert works, call the rest of the APIs using this cert!
            AzureHttpClient newClient = new AzureHttpClient(Utilities.SubscriptionId, cert);

            this.TestContext.WriteLine("Calling ListManagmentCertificate with new certificate.");
            var task = newClient.ListManagementCertificatesAsync(token);

            this.TestContext.WriteLine(task.Result.ToString());

            this.TestContext.WriteLine("Verifying the new cert is in the list.");

            var listCert = (from c in task.Result
                            where String.CompareOrdinal(c.Thumbprint, cert.Thumbprint) == 0
                            select c).FirstOrDefault();

            Assert.IsNotNull(listCert);

            this.TestContext.WriteLine("Certificate with thumbprint {0} is in list", listCert.Thumbprint);

            this.TestContext.WriteLine("Getting certificate with thumbprint {0}.", cert.Thumbprint);

            var getCert = newClient.GetManagementCertificateAsync(cert.Thumbprint, token);

            this.TestContext.WriteLine(getCert.Result.ToString());

            Assert.AreEqual(getCert.Result.Thumbprint, cert.Thumbprint);

            this.TestContext.WriteLine("Certificate gotten.");

            this.TestContext.WriteLine("Deleting certificate with Thumbprint {0}.", cert.Thumbprint);

            var deleteCert = newClient.DeleteManagementCertificateAsync(cert.Thumbprint);

            deleteCert.Wait();

            //dispose new client, won't work anymore...
            newClient.Dispose();

            this.TestContext.WriteLine("Confirming cert is not in list...");

            task = this.TestClient.ListManagementCertificatesAsync(token);

            this.TestContext.WriteLine(task.Result.ToString());

            this.TestContext.WriteLine("Verifying the new cert is not in the list.");

            listCert = (from c in task.Result
                            where String.CompareOrdinal(c.Thumbprint, cert.Thumbprint) == 0
                            select c).FirstOrDefault();

            Assert.IsNull(listCert);

            this.TestContext.WriteLine("Certificate deleted.");

            this.TestContext.WriteLine("Ending AddListGetDeleteManagementCertificate test.");
        }

        [TestMethod]
        public void ListServiceCertificates()
        {
            //certs are stored at service level, so enumerate them
            //to get to certs
            this.TestContext.WriteLine("Beginning ListServiceCertificates test.");
            CancellationToken token = this.TokenSource.Token;

            this.TestContext.WriteLine("Listing Cloud Services.");
            var task = TestClient.ListCloudServicesAsync(token);

            this.TestContext.WriteLine(task.Result.ToString());

            this.TestContext.WriteLine("Enumerating CloudServices.");
            foreach (var service in task.Result)
            {
                this.TestContext.WriteLine("Listing certificates Cloud Service with Label: {0}", service.Label);

                var propsTask = TestClient.ListServiceCertificatesAsync(service.ServiceName);

                this.TestContext.WriteLine(propsTask.Result.ToString());

                this.TestContext.WriteLine("Enumerating certificates for Cloud Service {0}", service.ServiceName);

                foreach (var info in propsTask.Result)
                {
                    this.TestContext.WriteLine("Getting certificate with thumbprint {0} from service {1}", info.Thumbprint, service.ServiceName);

                    var getTask = this.TestClient.GetServiceCertificateAsync(service.ServiceName, info.Thumbprint);

                    this.TestContext.WriteLine("Got cert with thumbprint {0}", getTask.Result.Thumbprint);

                    Assert.AreEqual(info.Thumbprint, getTask.Result.Thumbprint);
                }

                this.TestContext.WriteLine("Done Enumerating certificates for Cloud Service {0}", service.ServiceName);
            }

            this.TestContext.WriteLine("Done Enumerating CloudServices.");

            this.TestContext.WriteLine("Ending ListServiceCertificates test.");
        }

    }
}
