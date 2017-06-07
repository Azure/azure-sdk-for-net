using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.ManagementClient.v1_7;
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
            TestContext.WriteLine("Beginning ListCloudServices test.");
            CancellationToken token = TokenSource.Token;

            var task = TestClient.ListCloudServicesAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            TestContext.WriteLine("Enumerating properties of CloudServices.");
            foreach (var service in task.Result)
            {
                TestContext.WriteLine("Getting properties for Cloud Service with Label: {0}", service.Label);

                var propsTask = TestClient.GetCloudServicePropertiesAsync(service.ServiceName);

                //should be no deployments if embedDetail is false...
                Assert.IsNull(propsTask.Result.Deployments);

                TestContext.WriteLine(propsTask.Result.ToString());

                TestContext.WriteLine("Getting properties for Cloud Service with Label, and embedding detail: {0}", service.Label);

                var propsTask2 = TestClient.GetCloudServicePropertiesAsync(service.ServiceName, true, token);

                TestContext.WriteLine(propsTask2.Result.ToString());
            }

            TestContext.WriteLine("Done Enumerating properties of CloudServices.");

            TestContext.WriteLine("Ending ListCloudServices test.");
        }

        [TestMethod]
        public void ListStorageAccounts()
        {
            TestContext.WriteLine("Beginning ListStorageAccounts test.");
            CancellationToken token = TokenSource.Token;

            var task = TestClient.ListStorageAccountsAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            TestContext.WriteLine("Enumerating StorageAccount properties and Keys.");
            foreach (var account in task.Result)
            {
                TestContext.WriteLine("Getting properties for Storage account {0}", account.Name);
                var propsTask = TestClient.GetStorageAccountPropertiesAsync(account.Name);

                TestContext.WriteLine(propsTask.Result.ToString());

                TestContext.WriteLine("Getting keys for Storage account with Label: {0}", account.Label);
                var keysTask = TestClient.GetStorageAccountKeysAsync(account.Name);

                TestContext.WriteLine(keysTask.Result.ToString());
            }
            TestContext.WriteLine("Done Enumerating properties of Storage accounts.");

            TestContext.WriteLine("Ending ListStorageAccounts test.");
        }

        [TestMethod]
        public void ListLocations()
        {
            TestContext.WriteLine("Beginning ListLocations test.");
            CancellationToken token = TokenSource.Token;

            var task = TestClient.ListLocationsAsync(token);
            TestContext.WriteLine(task.Result.ToString());

            //there is no GetLocation, so no reason to loop here

            TestContext.WriteLine("Ending ListLocations test.");
        }

        [TestMethod]
        public void ListAffinityGroups()
        {
            TestContext.WriteLine("Beginning ListAffinityGroups test.");
            CancellationToken token = TokenSource.Token;

            var task = TestClient.ListAffinityGroupsAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            TestContext.WriteLine("Enumerating Affinity Groups");
            foreach (var ag in task.Result)
            {
                TestContext.WriteLine("Getting properties for Affinity Group {0}", ag.Name);
                var propsTask = TestClient.GetAffinityGroupAsync(ag.Name);

                TestContext.WriteLine(propsTask.Result.ToString());
            }
            TestContext.WriteLine("Done Enumerating properties of AffinityGroups.");
            TestContext.WriteLine("Ending ListAffinityGroups test.");
        }

        [TestMethod]
        public void ListManagementCertificates()
        {
            TestContext.WriteLine("Beginning ListManagementCertificates test.");
            CancellationToken token = TokenSource.Token;

            var task = TestClient.ListManagementCertificatesAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            TestContext.WriteLine("Enumerating Management Certificates");
            foreach (var cert in task.Result)
            {
                TestContext.WriteLine("Getting properties for Management Certificate with thumbprint {0}", cert.Thumbprint);
                var propsTask = TestClient.GetManagementCertificateAsync(cert.Thumbprint);

                TestContext.WriteLine(propsTask.Result.ToString());
            }
            TestContext.WriteLine("Done Enumerating properties of Management Certificates.");
            TestContext.WriteLine("Ending ListManagementCertificates test.");
        }

        [TestMethod]
        public void AddListGetDeleteManagementCertificate()
        {
            TestContext.WriteLine("Beginning AddListGetDeleteManagementCertificate test.");
            CancellationToken token = TokenSource.Token;

            X509Certificate2 cert = Utilities.CreateCert(false);

            TestContext.WriteLine("Adding ManagementCertificate with thumbprint {0}.", cert.Thumbprint);
            var addTask = TestClient.AddManagementCertificateAsync(cert);

            addTask.Wait();

            TestContext.WriteLine("Certificate with thumbprint {0} added.", cert.Thumbprint);

            TestContext.WriteLine("To make sure the certificate works, the rest of the API calls in this test will use the new certificate.");
            TestContext.WriteLine("Instantiating new AzureHttpClient with cert with thumbprint: {0}", cert.Thumbprint);
            //make sure the cert works, call the rest of the APIs using this cert!
            AzureHttpClient newClient = new AzureHttpClient(new Guid(Utilities.SubscriptionId), cert);

            TestContext.WriteLine("Calling ListManagmentCertificate with new certificate.");
            var task = newClient.ListManagementCertificatesAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            TestContext.WriteLine("Verifying the new cert is in the list.");

            var listCert = (from c in task.Result
                            where string.CompareOrdinal(c.Thumbprint, cert.Thumbprint) == 0
                            select c).FirstOrDefault();

            Assert.IsNotNull(listCert);

            TestContext.WriteLine("Certificate with thumbprint {0} is in list", listCert.Thumbprint);

            TestContext.WriteLine("Getting certificate with thumbprint {0}.", cert.Thumbprint);

            var getCert = newClient.GetManagementCertificateAsync(cert.Thumbprint, token);

            TestContext.WriteLine(getCert.Result.ToString());

            Assert.AreEqual(getCert.Result.Thumbprint, cert.Thumbprint);

            TestContext.WriteLine("Certificate gotten.");

            TestContext.WriteLine("Deleting certificate with Thumbprint {0}.", cert.Thumbprint);

            var deleteCert = newClient.DeleteManagementCertificateAsync(cert.Thumbprint);

            deleteCert.Wait();

            //dispose new client, won't work anymore...
            newClient.Dispose();

            TestContext.WriteLine("Confirming cert is not in list...");

            task = TestClient.ListManagementCertificatesAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            TestContext.WriteLine("Verifying the new cert is not in the list.");

            listCert = (from c in task.Result
                            where string.CompareOrdinal(c.Thumbprint, cert.Thumbprint) == 0
                            select c).FirstOrDefault();

            Assert.IsNull(listCert);

            TestContext.WriteLine("Certificate deleted.");

            TestContext.WriteLine("Ending AddListGetDeleteManagementCertificate test.");
        }

        [TestMethod]
        public void ListServiceCertificates()
        {
            //certs are stored at service level, so enumerate them
            //to get to certs
            TestContext.WriteLine("Beginning ListServiceCertificates test.");
            CancellationToken token = TokenSource.Token;

            TestContext.WriteLine("Listing Cloud Services.");
            var task = TestClient.ListCloudServicesAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            TestContext.WriteLine("Enumerating CloudServices.");
            foreach (var service in task.Result)
            {
                TestContext.WriteLine("Listing certificates Cloud Service with Label: {0}", service.Label);

                var propsTask = TestClient.ListServiceCertificatesAsync(service.ServiceName);

                TestContext.WriteLine(propsTask.Result.ToString());

                TestContext.WriteLine("Enumerating certificates for Cloud Service {0}", service.ServiceName);

                foreach (var info in propsTask.Result)
                {
                    TestContext.WriteLine("Getting certificate with thumbprint {0} from service {1}", info.Thumbprint, service.ServiceName);

                    var getTask = TestClient.GetServiceCertificateAsync(service.ServiceName, info.Thumbprint);

                    TestContext.WriteLine("Got cert with thumbprint {0}", getTask.Result.Thumbprint);

                    Assert.AreEqual(info.Thumbprint, getTask.Result.Thumbprint);
                }

                TestContext.WriteLine("Done Enumerating certificates for Cloud Service {0}", service.ServiceName);
            }

            TestContext.WriteLine("Done Enumerating CloudServices.");

            TestContext.WriteLine("Ending ListServiceCertificates test.");
        }

        [TestMethod]
        public void ListOSImages()
        {
            TestContext.WriteLine("Beginning ListOSImages test.");
            CancellationToken token = TokenSource.Token;

            var task = TestClient.ListVMOSImagesAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            //TestContext.WriteLine("Enumerating Affinity Groups");
            //foreach (var ag in task.Result)
            //{
            //    TestContext.WriteLine("Getting properties for Affinity Group {0}", ag.Name);
            //    var propsTask = TestClient.GetAffinityGroupAsync(ag.Name);

            //    TestContext.WriteLine(propsTask.Result.ToString());
            //}
            //TestContext.WriteLine("Done Enumerating properties of OSimages.");
            TestContext.WriteLine("Ending ListOSImages test.");
        }

        [TestMethod]
        public void ListVirtualHardDisks()
        {
            TestContext.WriteLine("Beginning ListVirtualHardDisks test.");
            CancellationToken token = TokenSource.Token;

            var task = TestClient.ListDisksAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            //TestContext.WriteLine("Enumerating Affinity Groups");
            //foreach (var ag in task.Result)
            //{
            //    TestContext.WriteLine("Getting properties for Affinity Group {0}", ag.Name);
            //    var propsTask = TestClient.GetAffinityGroupAsync(ag.Name);

            //    TestContext.WriteLine(propsTask.Result.ToString());
            //}
            //TestContext.WriteLine("Done Enumerating properties of OSimages.");
            TestContext.WriteLine("Ending ListVirtualHardDisks test.");
        }

        [TestMethod]
        public void GetPersistentVMRoles()
        {
            TestContext.WriteLine("Beginning GetPersistentVMRoles test.");
            CancellationToken token = TokenSource.Token;

            TestContext.WriteLine("Listing cloud services looking for VM roles");
            var task = TestClient.ListCloudServicesAsync(token);

            TestContext.WriteLine(task.Result.ToString());

            TestContext.WriteLine("Enumerating properties of CloudServices looking for VM roles.");
            foreach (var service in task.Result)
            {
                TestContext.WriteLine("Getting properties for Cloud Service with Label, and embedding detail: {0}", service.Label);

                var propsTask2 = TestClient.GetCloudServicePropertiesAsync(service.ServiceName, true, token);

                TestContext.WriteLine(propsTask2.Result.ToString());

                TestContext.WriteLine("Looking for VM roles");

                foreach(var dep in propsTask2.Result.Deployments)
                {
                    var vmRoles = from vm in dep.Roles
                                 where vm.RoleType == "PersistentVMRole"
                                 select vm;

                    if (vmRoles != null && vmRoles.Count() > 0)
                    {
                        foreach (var v in vmRoles)
                        {
                            TestContext.WriteLine("Found VM Role with name: {0}. Calling GetRole", v.Name);

                            var getRoleTask = TestClient.GetVirtualMachineRoleAsync(service.ServiceName, dep.Name, v.Name, token);
                            TestContext.WriteLine(getRoleTask.Result.ToString());
                        }
                    }
                }
            }

            TestContext.WriteLine("Done Enumerating properties of CloudServices.");

        }
    }
}
