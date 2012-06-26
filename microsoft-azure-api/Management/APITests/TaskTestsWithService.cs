using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.WindowsAzure.ManagementClient.v1_7;
using System.Threading;
using System.Globalization;
using System.Threading.Tasks;
using System.Security;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace APITests
{
    /// <summary>
    /// These tests test the Task API. All tests here use a service, see the TestInitialize and Cleanup methods
    /// DO NOT RUN THESE IN PARALLEL, we'd have to do additional work to enable that...
    /// </summary>
    [TestClass]
    public class TaskTestsWithService : TaskTestsBase
    {
        public TaskTestsWithService()
        {
        }

        #region Additional test attributes
        [TestInitialize()]
        public void CreateCloudServiceForTest()
        {
            //This method creates a new hosted service with a unique name,
            //and randomly chooses a location or creates an affinity group
            //with a random location. It sets the Location or AffinityGroup member,
            //so subsequent calls in the rest of the test can use the same ones
            //It always exercises the CreateCloudService and
            //ListLocations APIs, and 50% of the time exercises the CreateAffinityGroup API
            TestContext.WriteLine("Entering CreateCloudServiceForTest Method");
            CancellationToken token = TokenSource.Token;
            TestContext.WriteLine("Generating Name and Label for new cloud service");
            string name, label;
            Utilities.CreateUniqueNameAndLabel(out name, out label);
            CloudServiceName = name;
            CloudServiceLabel = label;
            TestContext.WriteLine("Generated Name and Label are: {0}, {1}", CloudServiceName, CloudServiceLabel);

            string location, affinityGroup;

            AvailableServices requiredServices = Utilities.DetermineRequiredServices(this.GetType(), TestContext.TestName);

            Utilities.GetLocationOrAffinityGroup(TestContext, TestClient, out location, out affinityGroup, requiredServices);

            Location = location;
            AffinityGroup = affinityGroup;
            
            TestContext.WriteLine("Creating Cloud Service");
            //TODO: Do something with description...
            var createTask = TestClient.CreateCloudServiceAsync(CloudServiceName, CloudServiceLabel, null, Location, AffinityGroup, null, token);

            createTask.Wait();
            TestContext.WriteLine("Cloud Service Creation complete");
            TestContext.WriteLine("Exiting CreateCloudServiceForTest method");
        }

        [TestCleanup()]
        public void DeleteCloudServiceForTest()
        {
            //this method undoes what is done CreateCloudServiceForTest
            //it deletes the new service created, and if there are deployments, it deletes them as well
            //then clears out the members set
            //this always exercises GetHostedServiceProperties with embeddetail = true
            //and DeleteCloudService
            //if there are deployments it also exercises DeletedDeployment and since that is a polling 
            //api, in that case it also exercises GetOperationStatus
            try
            {
                TestContext.WriteLine("Entering DeleteCloudServiceForTest method");
                TestContext.WriteLine("Calling GetCloudServiceProperties, embedDetail=true for CloudService named {0}", CloudServiceName);
                CancellationToken token = TokenSource.Token;
                var propsTask = TestClient.GetCloudServicePropertiesAsync(CloudServiceName, true, token);
                TestContext.WriteLine(propsTask.Result.ToString());

                TestContext.WriteLine("Cloud Service {0} has {1} deployments.", propsTask.Result.ServiceName, propsTask.Result.Deployments == null ? 0 : propsTask.Result.Deployments.Count);

                List<Task> deleteDeployments = new List<Task>();

                foreach (var d in propsTask.Result.Deployments)
                {
                    TestContext.WriteLine("Deleting deployment with label {0} in slot {1}", d.Label, d.DeploymentSlot.ToString());

                    var deleteDepTask = TestClient.DeleteDeploymentAsync(propsTask.Result.ServiceName, d.DeploymentSlot, token)
                                                       .ContinueWith(Utilities.PollUntilComplete(TestClient, "Delete Deployment", TestContext, token));
                    deleteDeployments.Add(deleteDepTask);
                }

                if (deleteDeployments.Count > 0)
                {
                    TestContext.WriteLine("Waiting for deployment deletion to complete...");
                    Task.WaitAll(deleteDeployments.ToArray());
                    TestContext.WriteLine("Deployments deleted.");
                }

                TestContext.WriteLine("Deleting Cloud Service {0}", propsTask.Result.ServiceName);
                var deleteTask = TestClient.DeleteCloudServiceAsync(propsTask.Result.ServiceName, token);
                deleteTask.Wait();

                TestContext.WriteLine("Cloud Service {0} deleted.", CloudServiceName);

                if (AffinityGroup != null)
                {
                    TestContext.WriteLine("Deleting Affinity Group {0}", AffinityGroup);

                    var deleteAffinityGroupTask = TestClient.DeleteAffinityGroupAsync(AffinityGroup);

                    deleteAffinityGroupTask.Wait();

                    TestContext.WriteLine("Affinity Group {0} deleted.", AffinityGroup);

                }
                TestContext.WriteLine("Exiting DeleteCloudServiceForTest method");
            }
            finally
            {
                //clear out the members regardless of if we succeeded above, other test will want to use these...
                CloudServiceName = null;
                CloudServiceLabel = null;
                AffinityGroup = null;
                Location = null;
            }
        }
        #region Per Test Members
        private string CloudServiceName { get; set; }
        private string CloudServiceLabel { get; set; }
        private string Location { get; set; }
        private string AffinityGroup { get; set; }

        #endregion
        #endregion

        private const string DataPath = @"..\..\..\ApiTests\Data";
        private const string PackageName = "CloudProjectForDeploying.cspkg";
        private const string ConfigFileGood = "ServiceConfiguration.cscfg";
        private const string CertFile = "AzureTestCert.pfx";

        private const string extendedPropNameMax = "ThisPropertyNameIs64CharactersLongThisPropertyNameIs64Characters";

        private const string extendedPropValueMax = "ThisPropertyValueIs255CharactersLongThisPropertyValueIs255CharactersLongThisPropertyValueIs255CharactersLong"+
                                                    "ThisPropertyValueIs255CharactersLongThisPropertyValueIs255CharactersLongThisPropertyValueIs255CharactersLong"+
                                                    "ThisPropertyValueIs255CharactersLongThi";

        private const string NewLabel = "Changed Label";
        private const string NewDescription = "Changed Description";
        private const string NewLocation = "East US";


        #region CloudService tests
        [TestMethod]
        [RequiredServices(AvailableServices.Compute)]
        public void UpdateCloudService()
        {
            TestContext.WriteLine("Beginning UpdateCloudService test");

            TestContext.WriteLine("Getting props for a baseline.");
            var getTask = TestClient.GetCloudServicePropertiesAsync(CloudServiceName);

            TestContext.WriteLine(getTask.Result.ToString());

            TestContext.WriteLine("Updating Label to {0}, Description to {1}, Location to {2}, and adding extended property.", NewLabel, NewDescription, NewLocation);
            var updateTask = TestClient.UpdateCloudServiceAsync(CloudServiceName, NewLabel, NewDescription, NewLocation, null,
                new Dictionary<string, string> {{ extendedPropNameMax, extendedPropValueMax }});

            updateTask.Wait();

            TestContext.WriteLine("Getting new properties.");

            getTask = TestClient.GetCloudServicePropertiesAsync(CloudServiceName);

            TestContext.WriteLine(getTask.Result.ToString());

            TestContext.WriteLine("Verifying Changes.");

            Assert.AreEqual(getTask.Result.Label, NewLabel);
            Assert.AreEqual(getTask.Result.Description, NewDescription);
            Assert.AreEqual(getTask.Result.Location, NewLocation);
            Assert.IsNull(getTask.Result.AffinityGroup);
            Assert.AreEqual(getTask.Result.ExtendedProperties[extendedPropNameMax], extendedPropValueMax);

            TestContext.WriteLine("Cloud Service Updated.");

            TestContext.WriteLine("End UpdateCloudService test.");
        }
        #endregion

        #region Deployment tests
        [TestMethod]
        [RequiredServices(AvailableServices.Compute | AvailableServices.Storage)]
        public void CreateDeploymentNoStart()
        {
            TestContext.WriteLine("Beginning CreateDeploymentNoStart test.");
            CancellationToken token = TokenSource.Token;

            string storageAccountName = null;
            Uri blob = null;
            try
            {
                storageAccountName = CreateStorageAccountInternal();

                blob = Utilities.UploadToBlob(TestClient, TestContext, storageAccountName, Path.Combine(DataPath, PackageName), token);

                Deployment dep = CreateDeploymentInternal(DeploymentSlot.Staging, blob);

                Assert.IsTrue(dep.Status == DeploymentStatus.Suspended);
            }
            finally
            {
                if (blob != null)
                {
                    Utilities.DeleteBlob(storageAccountName, blob, TestClient, TestContext, token);
                }

                if(storageAccountName != null)
                {
                    DeleteStorageAccountInternal(storageAccountName);
                }
            }

            TestContext.WriteLine("Ending CreateDeploymentNoStart test.");
 
        }

        [TestMethod]
        [RequiredServices(AvailableServices.Compute | AvailableServices.Storage)]
        public void CreateDeploymentAutoStart()
        {
            TestContext.WriteLine("Beginning CreateDeploymentAutoStart test.");
            CancellationToken token = TokenSource.Token;

            string storageAccountName = null;
            Uri blob = null;
            try
            {
                storageAccountName = CreateStorageAccountInternal();

                blob = Utilities.UploadToBlob(TestClient, TestContext, storageAccountName, Path.Combine(DataPath, PackageName), token);

                Deployment dep = CreateDeploymentInternal(DeploymentSlot.Staging, blob, true);

                Assert.IsTrue(dep.Status == DeploymentStatus.Running);
            }
            finally
            {
                if (blob != null)
                {
                    Utilities.DeleteBlob(storageAccountName, blob, TestClient, TestContext, token);
                }

                if (storageAccountName != null)
                {
                    DeleteStorageAccountInternal(storageAccountName);
                }
            }

            TestContext.WriteLine("Ending CreateDeploymentAutoStart test.");

        }

        [TestMethod]
        [RequiredServices(AvailableServices.Compute | AvailableServices.Storage)]
        public void CreateDeploymentManualStart()
        {
            TestContext.WriteLine("Beginning CreateDeploymentManualStart test.");
            CancellationToken token = TokenSource.Token;

            string storageAccountName = null;
            Uri blob = null;
            try
            {
                storageAccountName = CreateStorageAccountInternal();

                blob = Utilities.UploadToBlob(TestClient, TestContext, storageAccountName, Path.Combine(DataPath, PackageName), token);

                Deployment dep = CreateDeploymentInternal(DeploymentSlot.Staging, blob);

                Assert.IsTrue(dep.Status == DeploymentStatus.Suspended);

                TestContext.WriteLine("Manually starting deployment {0}.", dep.Name);

                var startTask = TestClient.StartDeploymentAsync(CloudServiceName, dep.DeploymentSlot, token)
                               .ContinueWith(Utilities.PollUntilComplete(TestClient, "Start Deployment", TestContext, token));

                TestContext.WriteLine("Start Deployment called for deployment {0}, waiting...", dep.Name);

                startTask.Wait();

                TestContext.WriteLine("Getting properties for deployment {0}", dep.Name);

                var getTask = TestClient.GetDeploymentAsync(CloudServiceName, dep.DeploymentSlot, token);

                TestContext.WriteLine(getTask.Result.ToString());

                Assert.IsTrue(getTask.Result.Status == DeploymentStatus.Running);
            }
            finally
            {
                if (blob != null)
                {
                    Utilities.DeleteBlob(storageAccountName, blob, TestClient, TestContext, token);
                }

                if (storageAccountName != null)
                {
                    DeleteStorageAccountInternal(storageAccountName);
                }
            }

            TestContext.WriteLine("Ending CreateDeploymentManualStart test.");

        }

        [TestMethod]
        [RequiredServices(AvailableServices.Compute | AvailableServices.Storage)]
        public void CreateTwoDeploymentsAndVipSwap()
        {
            TestContext.WriteLine("Beginning CreateTwoDeploymentsAndVipSwap test.");
            CancellationToken token = TokenSource.Token;

            string storageAccountName = null;
            Uri blob = null;
            try
            {
                storageAccountName = CreateStorageAccountInternal();

                blob = Utilities.UploadToBlob(TestClient, TestContext, storageAccountName, Path.Combine(DataPath, PackageName), token);

                Random r = new Random();
                TestContext.WriteLine("Creating two deployments, and randomly deciding whether to start them automatically.");

                //can only create one deployment at a time (or you get a 409), so have to do this serially...
                bool start = r.Next(2) == 1;
                Deployment staging = CreateDeploymentInternal(DeploymentSlot.Staging, blob, start);

                start = r.Next(2) == 1;
                Deployment production = CreateDeploymentInternal(DeploymentSlot.Production, blob, start);

                TestContext.WriteLine("Two deployments complete.");

                TestContext.WriteLine("Staging Deployment:");
                TestContext.WriteLine(staging.ToString());
                TestContext.WriteLine("Production Deployment:");
                TestContext.WriteLine(production.ToString());

                List<Task> startTasks = new List<Task>();
                if (staging.Status == DeploymentStatus.Suspended)
                {
                    TestContext.WriteLine("Staging deployment is not started, randomly deciding whether to start it...");
                    start = r.Next(2) == 1;
                    if (start)
                    {
                        TestContext.WriteLine("Starting staging deployment.");
                        var startTask = TestClient.StartDeploymentAsync(CloudServiceName, DeploymentSlot.Staging)
                                                       .ContinueWith(Utilities.PollUntilComplete(TestClient, "Start Deployment", TestContext, token));
                        startTasks.Add(startTask);
                    }
                    else
                    {
                        TestContext.WriteLine("Not starting staging deployment.");
                    }
                }

                if (production.Status == DeploymentStatus.Suspended)
                {
                    TestContext.WriteLine("Production deployment is not started, randomly deciding whether to start it...");
                    start = r.Next(2) == 1;
                    if (start)
                    {
                        TestContext.WriteLine("Starting production deployment.");
                        var startTask = TestClient.StartDeploymentAsync(CloudServiceName, DeploymentSlot.Production)
                                                       .ContinueWith(Utilities.PollUntilComplete(TestClient, "Start Deployment", TestContext, token));
                        startTasks.Add(startTask);
                    }
                    else
                    {
                        TestContext.WriteLine("Not starting production deployment.");
                    }
                }

                if (startTasks.Count > 0)
                {
                    TestContext.WriteLine("Deployments starting, waiting...");
                    Task.WaitAll(startTasks.ToArray());

                    //update the deployments...
                    var stagingTask = TestClient.GetDeploymentAsync(CloudServiceName, DeploymentSlot.Staging, token);
                    var productionTask = TestClient.GetDeploymentAsync(CloudServiceName, DeploymentSlot.Production, token);

                    Task.WaitAll(stagingTask, productionTask);

                    staging = stagingTask.Result;
                    production = productionTask.Result;
                }

                TestContext.WriteLine("Beginning Vip Swap operation on Cloud Service {0}", CloudServiceLabel);

                var vipSwapTask = TestClient.VipSwapAsync(CloudServiceName, token)
                                                 .ContinueWith(Utilities.PollUntilComplete(TestClient, "Vip Swap", TestContext, token));

                TestContext.WriteLine("Vip swap started, waiting...");

                vipSwapTask.Wait();

                TestContext.WriteLine("Vip swal complete.");

                TestContext.WriteLine("Getting current properties of the deployments.");

                var getdep1Task = TestClient.GetDeploymentAsync(CloudServiceName, DeploymentSlot.Staging, token);
                var getdep2Task = TestClient.GetDeploymentAsync(CloudServiceName, DeploymentSlot.Production, token);

                Task.WaitAll(getdep2Task, getdep1Task);
                Deployment newStaging = getdep1Task.Result;
                Deployment newProduction = getdep2Task.Result;

                TestContext.WriteLine("New staging Deployment:");
                TestContext.WriteLine(newStaging.ToString());
                TestContext.WriteLine("New production Deployment:");
                TestContext.WriteLine(newProduction.ToString());

                Assert.AreEqual(production.Name, newStaging.Name);
                Assert.AreEqual(production.Status, newStaging.Status);
                Assert.AreEqual(staging.Name, newProduction.Name);
                Assert.AreEqual(staging.Status, newProduction.Status);

            }
            finally
            {
                if (blob != null)
                {
                    Utilities.DeleteBlob(storageAccountName, blob, TestClient, TestContext, token);
                }

                if (storageAccountName != null)
                {
                    DeleteStorageAccountInternal(storageAccountName);
                }
            }

            TestContext.WriteLine("Ending CreateTwoDeploymentsAndVipSwap test.");

        }
        #endregion

        #region Storage Account Tests
        [TestMethod]
        [RequiredServices(AvailableServices.Storage)]
        public void CreateListGetUpdateRegenerateDeleteStorageAccount()
        {
            TestContext.WriteLine("Beginning CreateListGetDeleteStorageAccount test.");

            string name = CreateStorageAccountInternal();

            try
            {
                TestContext.WriteLine("Listing storage accounts and verifying the account is in there");

                var listTask = TestClient.ListStorageAccountsAsync();

                TestContext.WriteLine(listTask.Result.ToString());

                var account = (from a in listTask.Result
                               where string.Compare(a.Name, name, StringComparison.Ordinal) == 0
                               select a).FirstOrDefault();

                Assert.IsNotNull(account);

                TestContext.WriteLine("StorageAccount {0} is present in the list", account.Name);

                TestContext.WriteLine("Getting properties and keys for storage account {0}", account.Name);

                var propsTask = TestClient.GetStorageAccountPropertiesAsync(name);
                var keysTask = TestClient.GetStorageAccountKeysAsync(name);

                Task.WaitAll(propsTask, keysTask);

                TestContext.WriteLine(propsTask.Result.ToString());
                TestContext.WriteLine(keysTask.Result.ToString());

                TestContext.WriteLine("Update Storage account with Label {0}, Description {1}, GeoReplicationEnabled {2}, and adding an extended property",
                                                                               NewLabel, NewDescription, !propsTask.Result.GeoReplicationEnabled);

                var updateTask = TestClient.UpdateStorageAccountAsync(name, NewLabel, NewDescription, !propsTask.Result.GeoReplicationEnabled, new Dictionary<string, string> { { extendedPropNameMax, extendedPropValueMax } });

                updateTask.Wait();

                var newProps = TestClient.GetStorageAccountPropertiesAsync(name).Result;

                TestContext.WriteLine("New Properties:");
                TestContext.WriteLine(newProps.ToString());

                Assert.AreEqual(newProps.Label, NewLabel);
                Assert.AreEqual(newProps.Description, NewDescription);
                Assert.AreEqual(newProps.GeoReplicationEnabled, !propsTask.Result.GeoReplicationEnabled);

                TestContext.WriteLine("Regenerate Primary Key");

                var newKeys1 = TestClient.RegenerateStorageAccountKeys(name, StorageAccountKeyType.Primary).Result;

                TestContext.WriteLine("New Keys:");
                TestContext.WriteLine(newKeys1.ToString());

                Assert.AreNotEqual(Convert.ToBase64String(newKeys1.Primary), Convert.ToBase64String(keysTask.Result.Primary));
                Assert.AreEqual(Convert.ToBase64String(newKeys1.Secondary), Convert.ToBase64String(keysTask.Result.Secondary));

                TestContext.WriteLine("Regenerate Secondary Key");

                var newKeys2 = TestClient.RegenerateStorageAccountKeys(name, StorageAccountKeyType.Secondary).Result;

                TestContext.WriteLine("New Keys:");
                TestContext.WriteLine(newKeys2.ToString());

                Assert.AreEqual(Convert.ToBase64String(newKeys1.Primary), Convert.ToBase64String(newKeys2.Primary));
                Assert.AreNotEqual(Convert.ToBase64String(newKeys1.Secondary), Convert.ToBase64String(newKeys2.Secondary));
            }
            finally
            {
                DeleteStorageAccountInternal(name);

                TestContext.WriteLine("Ending CreateListGetDeleteStorageAccount test.");
            }

        }
        #endregion

        #region PersistentVMTests
        [TestMethod]
        [RequiredServices(AvailableServices.Compute | AvailableServices.Storage | AvailableServices.PersistentVMRole)]
        public void CreatePersistentVMDeploymentTests()
        {
            TestContext.WriteLine("Beginning CreatePersistentVMDeployment test.");
            CancellationToken token = TokenSource.Token;

            TestContext.WriteLine("Getting OS Images");
            var images = TestClient.ListVMOSImagesAsync(token).Result;

            TestContext.WriteLine("Getting a windows image (for now).");
            OSImage image = (from i in images
                             where i.OSType == OperatingSystemType.Windows
                             select i).First();

            TestContext.WriteLine("Selected OS Image:");
            TestContext.WriteLine(image.ToString());

            string name = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
            string label = name + "_TestDeployment";

            TestContext.WriteLine("Need a place to put the image, create a StorageAccount");

            string storageAccountName = CreateStorageAccountInternal();

            try
            {

                TestContext.WriteLine("Get storage account properties and keys");

                var stgacct = TestClient.GetStorageAccountPropertiesAsync(storageAccountName);
                var stgacctKeys = TestClient.GetStorageAccountKeysAsync(storageAccountName);

                Task.WaitAll(stgacct, stgacctKeys);

                TestContext.WriteLine(stgacct.ToString());
                TestContext.WriteLine(stgacctKeys.ToString());

                TestContext.WriteLine("Create CloudStorageAccount");

                Uri blob, table, queue;

                Utilities.FixupEndpoints(stgacct.Result, out blob, out queue, out table);

                CloudStorageAccount account = new CloudStorageAccount(
                                                    new StorageCredentialsAccountAndKey(
                                                        stgacct.Result.Name,
                                                        stgacctKeys.Result.Primary),
                                                        blob, queue, table);

                TestContext.WriteLine("Create container for disk");

                CloudBlobClient client = account.CreateCloudBlobClient();

                CloudBlobContainer container = client.GetContainerReference("disks");

                container.CreateIfNotExist();

                CloudBlob blobRef = container.GetBlobReference(string.Format("{0}-{1}-0-{2}", CloudServiceName, name, DateTime.Now.ToString("yyyyMMddhhmmss")));

                //create password
                SecureString pwd = new SecureString();
                pwd.AppendChar('P');
                pwd.AppendChar('a');
                pwd.AppendChar('$');
                pwd.AppendChar('$');
                pwd.AppendChar('w');
                pwd.AppendChar('0');
                pwd.AppendChar('r');
                pwd.AppendChar('d');
                pwd.MakeReadOnly();

                string rolename = "testrolename";
                var createVMDeploymentTask = TestClient.CreateVirtualMachineDeploymentAsync(CloudServiceName, name, label, new PersistentVMRole(rolename, new WindowsProvisioningConfigurationSet("testcompname", pwd),
                                                                                            OSVirtualHardDisk.OSDiskFromImage(image.Name, image.OSType, blobRef.Uri)), token)
                                                                                            .ContinueWith(Utilities.PollUntilComplete(TestClient, "Create PersistentVM Deployment", TestContext, token));

                createVMDeploymentTask.Wait();

                TestContext.WriteLine("Calling GetCloudServiceProperties for this new VM Hosted Service");

                var getProps = TestClient.GetCloudServicePropertiesAsync(CloudServiceName, true).Result;

                TestContext.WriteLine(getProps.ToString());

                TestContext.WriteLine("Calling GetRole for the VM role we just created.");

                var getRole = TestClient.GetVirtualMachineRoleAsync(CloudServiceName, name, rolename).Result;

                TestContext.WriteLine(getRole.ToString());

                TestContext.WriteLine("Save off the osdisk media link: {0} and name {1}.", getRole.OSVirtualHardDisk.MediaLink, getRole.OSVirtualHardDisk.DiskName);

                Uri OSDiskMediaLink = getRole.OSVirtualHardDisk.MediaLink;
                string OSDiskName = getRole.OSVirtualHardDisk.DiskName;

                TestContext.WriteLine("Delete the deployment");

                var deleteDeploymentTask = TestClient.DeleteDeploymentAsync(CloudServiceName, DeploymentSlot.Production)
                                                                           .ContinueWith(Utilities.PollUntilComplete(TestClient, "Create PersistentVM Deployment", TestContext, token));

                deleteDeploymentTask.Wait();

                TestContext.WriteLine("Deployment deleted, now delete the disk");

                var deleteOSDisk = TestClient.DeleteDiskAsync(OSDiskName);

                deleteOSDisk.Wait();

                TestContext.WriteLine("OS Disk Deleted");

            }
            finally
            {
                DeleteStorageAccountInternal(storageAccountName);

                TestContext.WriteLine("Ending CreatePersistentVMDeployment test.");
            }
        }
        #endregion

        [TestMethod]
        [RequiredServices(AvailableServices.Compute)]
        public void AddListGetDeleteServiceCertificate()
        {
            TestContext.WriteLine("Beginning AddCertificate test.");
            CancellationToken token = TokenSource.Token;

            TestContext.WriteLine("Loading test certificate.");

            X509Certificate2 certPwd = Utilities.CreateCert(true);

            X509Certificate2 certNoPwd = Utilities.CreateCert(false);

            TestContext.WriteLine("Calling AddServiceCertificateAsync with Cert {0} to Service {1}.", certPwd.Thumbprint, CloudServiceName);

            var addCertTask = TestClient.AddServiceCertificateAsync(CloudServiceName, certPwd, Utilities.CertPassword, token)
                                             .ContinueWith(Utilities.PollUntilComplete(TestClient, "Add Certificate", TestContext, token));

            TestContext.WriteLine("AddServiceCertificate called, waiting...");

            addCertTask.Wait();

            TestContext.WriteLine("Certificate Added to service {0}", CloudServiceName);

            TestContext.WriteLine("Calling AddServiceCertificateAsync with Cert {0} to Service {1}.", certNoPwd.Thumbprint, CloudServiceName);

            addCertTask = TestClient.AddServiceCertificateAsync(CloudServiceName, certNoPwd, null, token)
                                             .ContinueWith(Utilities.PollUntilComplete(TestClient, "Add Certificate", TestContext, token));

            TestContext.WriteLine("AddServiceCertificate called, waiting...");

            addCertTask.Wait();

            TestContext.WriteLine("Certificate Added to service {0}", CloudServiceName);
            TestContext.WriteLine("End AddCertificate test.");

            TestContext.WriteLine("Calling List Certificates for service {0} to get all cert properties.", CloudServiceName);

            var listCertsTask = TestClient.ListServiceCertificatesAsync(CloudServiceName);

            TestContext.WriteLine(listCertsTask.Result.ToString());

            //should only be two certs, since we just created the service...
            Assert.IsTrue(listCertsTask.Result.Count == 2);

            TestContext.WriteLine("Calling Get Certificate for cert {0} on Service {1}.", certPwd.Thumbprint, CloudServiceName);

            var getCertTask = TestClient.GetServiceCertificateAsync(CloudServiceName, certPwd.Thumbprint, token);

            X509Certificate2 getCert = getCertTask.Result;

            TestContext.WriteLine("Got certificate with thumbprint {0} from Service {1}.", getCert.Thumbprint, CloudServiceName);

            Assert.AreEqual(certPwd.Thumbprint, getCert.Thumbprint);

            TestContext.WriteLine("Deleting certificate with thumbprint {0} from Service {1}.", certPwd.Thumbprint, CloudServiceName);

            var deleteTask = TestClient.DeleteServiceCertificateAsync(CloudServiceName, certPwd.Thumbprint, token);

            deleteTask.Wait();

            TestContext.WriteLine("Deleting certificate with thumbprint {0} from Service {1}.", certNoPwd.Thumbprint, CloudServiceName);

            deleteTask = TestClient.DeleteServiceCertificateAsync(CloudServiceName, certNoPwd.Thumbprint, token);

            deleteTask.Wait();

            TestContext.WriteLine("Certificate deleted, calling ListCertificates again to confirm deletion.");

            listCertsTask = TestClient.ListServiceCertificatesAsync(CloudServiceName);

            TestContext.WriteLine(listCertsTask.Result.ToString());

            //should be gone now, since we just created the service...
            Assert.IsTrue(listCertsTask.Result.Count == 0);

        }

        //separating this out because it gets used in several places
        private string CreateStorageAccountInternal()
        {
            TestContext.WriteLine("Beginning CreateStorageAccount operation.");

            string storageAccountName = CloudServiceName.ToLower().Substring(0, 24);

            TestContext.WriteLine("Creating Storage account with name {0}", storageAccountName);

            var createAndWaitTask = TestClient.CreateStorageAccountAsync(storageAccountName, CloudServiceName, null, Location, AffinityGroup, true, null)
                .ContinueWith(Utilities.PollUntilComplete(TestClient, "Create Storage Account", TestContext, TokenSource.Token));

            createAndWaitTask.Wait();

            TestContext.WriteLine("Storage account {0} created.", storageAccountName);

            TestContext.WriteLine("End CreateStorageAccount operation.");

            TestContext.WriteLine("Get StorageAccountProperties on new account.");

            var getTask = TestClient.GetStorageAccountPropertiesAsync(storageAccountName);

            TestContext.WriteLine(getTask.Result.ToString());

            return storageAccountName;
        }

        //ditto
        private void DeleteStorageAccountInternal(string storageAccountName)
        {
            TestContext.WriteLine("Beginning DeleteStorageAccount operation.");
            TestContext.WriteLine("Deleting Storage account {0}.", storageAccountName);
            //create is a polling operation, delete is not...
            var deleteTask = TestClient.DeleteStorageAccountAsync(storageAccountName);

            deleteTask.Wait();
            TestContext.WriteLine("Storage account {0} deleted.", storageAccountName);
            TestContext.WriteLine("End DeleteStorageAccount operation.");
        }

        private Deployment CreateDeploymentInternal(DeploymentSlot slot, Uri blobUri, bool startWithDeployment = false, bool treatWarningsAsError = false)
        {
            TestContext.WriteLine("Beginning CreateDeployment operation");
            CancellationToken token = TokenSource.Token;

            string name = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
            string label = name + "_TestDeployment";

            TestContext.WriteLine("Creating Deployment with name {0} and label {1} in slot {2}", name, label, slot.ToString());

            var createAndWaitTask = TestClient.CreateDeploymentAsync(CloudServiceName, slot, name, blobUri, label, Path.Combine(DataPath, ConfigFileGood), startWithDeployment, treatWarningsAsError, null, token)
                                    .ContinueWith(Utilities.PollUntilComplete(TestClient, "Create Deployment", TestContext, token));


            TestContext.WriteLine("CreateDeployment called, waiting...");

            createAndWaitTask.Wait();
            TestContext.WriteLine("Deployment in slot {0} created.", slot.ToString());
            TestContext.WriteLine("End CreateDeployment operation");
            TestContext.WriteLine("Getting properties of new Deployment");
            var getTask = TestClient.GetDeploymentAsync(CloudServiceName, slot, token);

            TestContext.WriteLine(getTask.Result.ToString());

            return getTask.Result;
        }
    }
}
