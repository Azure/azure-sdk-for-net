using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Windows.Azure.Management.v1_7;
using System.Threading;
using System.Globalization;
using System.Threading.Tasks;

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
            this.TestContext.WriteLine("Entering CreateCloudServiceForTest Method");
            CancellationToken token = this.TokenSource.Token;
            this.TestContext.WriteLine("Generating Name and Label for new cloud service");
            this.CloudServiceName = Guid.NewGuid().ToString("N");
            this.CloudServiceLabel = this.CloudServiceName + "_TestService";
            this.TestContext.WriteLine("Generated Name and Label are: {0}, {1}", this.CloudServiceName, this.CloudServiceLabel);

            this.TestContext.WriteLine("Listing available locations:");
            var listTask = TestClient.ListLocationsAsync(token);
            this.TestContext.WriteLine(listTask.Result.ToString());

            this.TestContext.WriteLine("Choosing a location at random");
            Random r = new Random();
            int idx = r.Next(listTask.Result.Count);
            String locationToUse = listTask.Result[idx].Name;
            this.TestContext.WriteLine("Chose Location {0} randomly", locationToUse);

            //TODO: Deal with affinity groups half the time...
            bool doAffinityGroup = r.Next(2) == 1;

            if (doAffinityGroup)
            {
                //create an affinity group with a unique name
                String affinityGroupName = Guid.NewGuid().ToString("N");
                String affinityGroupLabel = affinityGroupName + "_TestAffinityGroup";
                this.TestContext.WriteLine("Randomly chose to create an affinity group, with name {0} and label {1}.", affinityGroupName, affinityGroupLabel);

                var affinityGroupTask = this.TestClient.CreateAffinityGroupAsync(affinityGroupName, affinityGroupLabel, null, locationToUse);
                affinityGroupTask.Wait();
                this.TestContext.WriteLine("Affinity Group {0} created.", affinityGroupName);

                this.TestContext.WriteLine("Getting properties for affinity group {0}", affinityGroupName);
                var getAffinityGroupTask = this.TestClient.GetAffinityGroupAsync(affinityGroupName, token);

                this.TestContext.WriteLine(getAffinityGroupTask.Result.ToString());

                this.AffinityGroup = getAffinityGroupTask.Result.Name;
            }
            else
            {
                this.Location = locationToUse;
            }

            this.TestContext.WriteLine("Creating Cloud Service");
            //TODO: Do something with description...
            var createTask = TestClient.CreateCloudServiceAsync(this.CloudServiceName, this.CloudServiceLabel, null, this.Location, this.AffinityGroup, null, token);

            createTask.Wait();
            this.TestContext.WriteLine("Cloud Service Creation complete");
            this.TestContext.WriteLine("Exiting CreateCloudServiceForTest method");
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
                this.TestContext.WriteLine("Entering DeleteCloudServiceForTest method");
                this.TestContext.WriteLine("Calling GetCloudServiceProperties, embedDetail=true for CloudService named {0}", this.CloudServiceName);
                CancellationToken token = this.TokenSource.Token;
                var propsTask = TestClient.GetCloudServicePropertiesAsync(this.CloudServiceName, true, token);
                this.TestContext.WriteLine(propsTask.Result.ToString());

                this.TestContext.WriteLine("Cloud Service {0} has {1} deployments.", propsTask.Result.ServiceName, propsTask.Result.Deployments == null ? 0 : propsTask.Result.Deployments.Count);

                List<Task> deleteDeployments = new List<Task>();

                foreach (var d in propsTask.Result.Deployments)
                {
                    this.TestContext.WriteLine("Deleting deployment with label {0} in slot {1}", d.Label, d.DeploymentSlot.ToString());

                    var deleteDepTask = this.TestClient.DeleteDeploymentAsync(propsTask.Result.ServiceName, d.DeploymentSlot, token)
                                                       .ContinueWith(Utilities.PollUntilComplete(this.TestClient, "Delete Deployment", this.TestContext, token));
                    deleteDeployments.Add(deleteDepTask);
                }

                if (deleteDeployments.Count > 0)
                {
                    this.TestContext.WriteLine("Waiting for deployment deletion to complete...");
                    Task.WaitAll(deleteDeployments.ToArray());
                    this.TestContext.WriteLine("Deployments deleted.");
                }

                this.TestContext.WriteLine("Deleting Cloud Service {0}", propsTask.Result.ServiceName);
                var deleteTask = TestClient.DeleteCloudServiceAsync(propsTask.Result.ServiceName, token);
                deleteTask.Wait();

                this.TestContext.WriteLine("Cloud Service {0} deleted.", this.CloudServiceName);

                if (this.AffinityGroup != null)
                {
                    this.TestContext.WriteLine("Deleting Affinity Group {0}", this.AffinityGroup);

                    var deleteAffinityGroupTask = this.TestClient.DeleteAffinityGroupAsync(this.AffinityGroup);

                    deleteAffinityGroupTask.Wait();

                    this.TestContext.WriteLine("Affinity Group {0} deleted.", this.AffinityGroup);

                }
                this.TestContext.WriteLine("Exiting DeleteCloudServiceForTest method");
            }
            finally
            {
                //clear out the members regardless of if we succeeded above, other test will want to use these...
                this.CloudServiceName = null;
                this.CloudServiceLabel = null;
                this.AffinityGroup = null;
                this.Location = null;
            }
        }
        #region Per Test Members
        private String CloudServiceName { get; set; }
        private String CloudServiceLabel { get; set; }
        private String Location { get; set; }
        private String AffinityGroup { get; set; }

        #endregion
        #endregion

        private const string DataPath = @"..\..\..\ApiTests\Data";
        private const string PackageName = "CloudProjectForDeploying.cspkg";
        private const string ConfigFileGood = "ServiceConfiguration.cscfg";
        private const string CertFile = "AzureTestCert.pfx";

        [TestMethod]
        public void CreateDeploymentNoStart()
        {
            this.TestContext.WriteLine("Beginning CreateDeploymentNoStart test.");
            CancellationToken token = this.TokenSource.Token;

            string storageAccountName = null;
            Uri blob = null;
            try
            {
                storageAccountName = CreateStorageAccountInternal();

                blob = Utilities.UploadToBlob(this.TestClient, this.TestContext, storageAccountName, Path.Combine(DataPath, PackageName), token);

                Deployment dep = CreateDeploymentInternal(DeploymentSlot.Staging, blob);

                Assert.IsTrue(dep.Status == DeploymentStatus.Suspended);
            }
            finally
            {
                if (blob != null)
                {
                    Utilities.DeleteBlob(storageAccountName, blob, this.TestClient, this.TestContext, token);
                }

                if(storageAccountName != null)
                {
                    DeleteStorageAccountInternal(storageAccountName);
                }
            }

            this.TestContext.WriteLine("Ending CreateDeploymentNoStart test.");
 
        }

        [TestMethod]
        public void CreateDeploymentAutoStart()
        {
            this.TestContext.WriteLine("Beginning CreateDeploymentAutoStart test.");
            CancellationToken token = this.TokenSource.Token;

            string storageAccountName = null;
            Uri blob = null;
            try
            {
                storageAccountName = CreateStorageAccountInternal();

                blob = Utilities.UploadToBlob(this.TestClient, this.TestContext, storageAccountName, Path.Combine(DataPath, PackageName), token);

                Deployment dep = CreateDeploymentInternal(DeploymentSlot.Staging, blob, true);

                Assert.IsTrue(dep.Status == DeploymentStatus.Running);
            }
            finally
            {
                if (blob != null)
                {
                    Utilities.DeleteBlob(storageAccountName, blob, this.TestClient, this.TestContext, token);
                }

                if (storageAccountName != null)
                {
                    DeleteStorageAccountInternal(storageAccountName);
                }
            }

            this.TestContext.WriteLine("Ending CreateDeploymentAutoStart test.");

        }

        [TestMethod]
        public void CreateDeploymentManualStart()
        {
            this.TestContext.WriteLine("Beginning CreateDeploymentManualStart test.");
            CancellationToken token = this.TokenSource.Token;

            string storageAccountName = null;
            Uri blob = null;
            try
            {
                storageAccountName = CreateStorageAccountInternal();

                blob = Utilities.UploadToBlob(this.TestClient, this.TestContext, storageAccountName, Path.Combine(DataPath, PackageName), token);

                Deployment dep = CreateDeploymentInternal(DeploymentSlot.Staging, blob);

                Assert.IsTrue(dep.Status == DeploymentStatus.Suspended);

                this.TestContext.WriteLine("Manually starting deployment {0}.", dep.Name);

                var startTask = this.TestClient.StartDeploymentAsync(this.CloudServiceName, dep.DeploymentSlot, token)
                               .ContinueWith(Utilities.PollUntilComplete(this.TestClient, "Start Deployment", this.TestContext, token));

                this.TestContext.WriteLine("Start Deployment called for deployment {0}, waiting...", dep.Name);

                startTask.Wait();

                this.TestContext.WriteLine("Getting properties for deployment {0}", dep.Name);

                var getTask = this.TestClient.GetDeploymentAsync(this.CloudServiceName, dep.DeploymentSlot, token);

                this.TestContext.WriteLine(getTask.Result.ToString());

                Assert.IsTrue(getTask.Result.Status == DeploymentStatus.Running);
            }
            finally
            {
                if (blob != null)
                {
                    Utilities.DeleteBlob(storageAccountName, blob, this.TestClient, this.TestContext, token);
                }

                if (storageAccountName != null)
                {
                    DeleteStorageAccountInternal(storageAccountName);
                }
            }

            this.TestContext.WriteLine("Ending CreateDeploymentManualStart test.");

        }

        [TestMethod]
        public void CreateTwoDeploymentsAndVipSwap()
        {
            this.TestContext.WriteLine("Beginning CreateTwoDeploymentsAndVipSwap test.");
            CancellationToken token = this.TokenSource.Token;

            string storageAccountName = null;
            Uri blob = null;
            try
            {
                storageAccountName = CreateStorageAccountInternal();

                blob = Utilities.UploadToBlob(this.TestClient, this.TestContext, storageAccountName, Path.Combine(DataPath, PackageName), token);

                Random r = new Random();
                this.TestContext.WriteLine("Creating two deployments, and randomly deciding whether to start them automatically.");

                //can only create one deployment at a time (or you get a 409), so have to do this serially...
                bool start = r.Next(2) == 1;
                Deployment staging = CreateDeploymentInternal(DeploymentSlot.Staging, blob, start);

                start = r.Next(2) == 1;
                Deployment production = CreateDeploymentInternal(DeploymentSlot.Production, blob, start);

                this.TestContext.WriteLine("Two deployments complete.");

                this.TestContext.WriteLine("Staging Deployment:");
                this.TestContext.WriteLine(staging.ToString());
                this.TestContext.WriteLine("Production Deployment:");
                this.TestContext.WriteLine(production.ToString());

                List<Task> startTasks = new List<Task>();
                if (staging.Status == DeploymentStatus.Suspended)
                {
                    this.TestContext.WriteLine("Staging deployment is not started, randomly deciding whether to start it...");
                    start = r.Next(2) == 1;
                    if (start)
                    {
                        this.TestContext.WriteLine("Starting staging deployment.");
                        var startTask = this.TestClient.StartDeploymentAsync(this.CloudServiceName, DeploymentSlot.Staging)
                                                       .ContinueWith(Utilities.PollUntilComplete(this.TestClient, "Start Deployment", this.TestContext, token));
                        startTasks.Add(startTask);
                    }
                    else
                    {
                        this.TestContext.WriteLine("Not starting staging deployment.");
                    }
                }

                if (production.Status == DeploymentStatus.Suspended)
                {
                    this.TestContext.WriteLine("Production deployment is not started, randomly deciding whether to start it...");
                    start = r.Next(2) == 1;
                    if (start)
                    {
                        this.TestContext.WriteLine("Starting production deployment.");
                        var startTask = this.TestClient.StartDeploymentAsync(this.CloudServiceName, DeploymentSlot.Production)
                                                       .ContinueWith(Utilities.PollUntilComplete(this.TestClient, "Start Deployment", this.TestContext, token));
                        startTasks.Add(startTask);
                    }
                    else
                    {
                        this.TestContext.WriteLine("Not starting production deployment.");
                    }
                }

                if (startTasks.Count > 0)
                {
                    this.TestContext.WriteLine("Deployments starting, waiting...");
                    Task.WaitAll(startTasks.ToArray());

                    //update the deployments...
                    var stagingTask = this.TestClient.GetDeploymentAsync(this.CloudServiceName, DeploymentSlot.Staging, token);
                    var productionTask = this.TestClient.GetDeploymentAsync(this.CloudServiceName, DeploymentSlot.Production, token);

                    Task.WaitAll(stagingTask, productionTask);

                    staging = stagingTask.Result;
                    production = productionTask.Result;
                }

                this.TestContext.WriteLine("Beginning Vip Swap operation on Cloud Service {0}", this.CloudServiceLabel);

                var vipSwapTask = this.TestClient.VipSwapAsync(this.CloudServiceName, token)
                                                 .ContinueWith(Utilities.PollUntilComplete(this.TestClient, "Vip Swap", this.TestContext, token));

                this.TestContext.WriteLine("Vip swap started, waiting...");

                vipSwapTask.Wait();

                this.TestContext.WriteLine("Vip swal complete.");

                this.TestContext.WriteLine("Getting current properties of the deployments.");

                var getdep1Task = this.TestClient.GetDeploymentAsync(this.CloudServiceName, DeploymentSlot.Staging, token);
                var getdep2Task = this.TestClient.GetDeploymentAsync(this.CloudServiceName, DeploymentSlot.Production, token);

                Task.WaitAll(getdep2Task, getdep1Task);
                Deployment newStaging = getdep1Task.Result;
                Deployment newProduction = getdep2Task.Result;

                this.TestContext.WriteLine("New staging Deployment:");
                this.TestContext.WriteLine(newStaging.ToString());
                this.TestContext.WriteLine("New production Deployment:");
                this.TestContext.WriteLine(newProduction.ToString());

                Assert.AreEqual(production.Name, newStaging.Name);
                Assert.AreEqual(production.Status, newStaging.Status);
                Assert.AreEqual(staging.Name, newProduction.Name);
                Assert.AreEqual(staging.Status, newProduction.Status);

            }
            finally
            {
                if (blob != null)
                {
                    Utilities.DeleteBlob(storageAccountName, blob, this.TestClient, this.TestContext, token);
                }

                if (storageAccountName != null)
                {
                    DeleteStorageAccountInternal(storageAccountName);
                }
            }

            this.TestContext.WriteLine("Ending CreateTwoDeploymentsAndVipSwap test.");

        }


        [TestMethod]
        public void CreateStorageAccount()
        {
            this.TestContext.WriteLine("Beginning CreateStorageAccount test.");

            //just run the two internal methods...
            String name = CreateStorageAccountInternal();

            DeleteStorageAccountInternal(name);

            this.TestContext.WriteLine("Ending CreateStorageAccount test.");

        }

        [TestMethod]
        public void AddListGetDeleteServiceCertificate()
        {
            this.TestContext.WriteLine("Beginning AddCertificate test.");
            CancellationToken token = this.TokenSource.Token;

            this.TestContext.WriteLine("Loading test certificate.");

            X509Certificate2 certPwd = Utilities.CreateCert(true);

            X509Certificate2 certNoPwd = Utilities.CreateCert(false);

            this.TestContext.WriteLine("Calling AddServiceCertificateAsync with Cert {0} to Service {1}.", certPwd.Thumbprint, this.CloudServiceName);

            var addCertTask = this.TestClient.AddServiceCertificateAsync(this.CloudServiceName, certPwd, Utilities.CertPassword, token)
                                             .ContinueWith(Utilities.PollUntilComplete(this.TestClient, "Add Certificate", this.TestContext, token));

            this.TestContext.WriteLine("AddServiceCertificate called, waiting...");

            addCertTask.Wait();

            this.TestContext.WriteLine("Certificate Added to service {0}", this.CloudServiceName);

            this.TestContext.WriteLine("Calling AddServiceCertificateAsync with Cert {0} to Service {1}.", certNoPwd.Thumbprint, this.CloudServiceName);

            addCertTask = this.TestClient.AddServiceCertificateAsync(this.CloudServiceName, certNoPwd, null, token)
                                             .ContinueWith(Utilities.PollUntilComplete(this.TestClient, "Add Certificate", this.TestContext, token));

            this.TestContext.WriteLine("AddServiceCertificate called, waiting...");

            addCertTask.Wait();

            this.TestContext.WriteLine("Certificate Added to service {0}", this.CloudServiceName);
            this.TestContext.WriteLine("End AddCertificate test.");

            this.TestContext.WriteLine("Calling List Certificates for service {0} to get all cert properties.", this.CloudServiceName);

            var listCertsTask = this.TestClient.ListServiceCertificatesAsync(this.CloudServiceName);

            this.TestContext.WriteLine(listCertsTask.Result.ToString());

            //should only be two certs, since we just created the service...
            Assert.IsTrue(listCertsTask.Result.Count == 2);
            //X509Certificate2 listCert = listCertsTask.Result.First().Certificate;

            //Assert.AreEqual(cert.Thumbprint, listCert.Thumbprint);

            this.TestContext.WriteLine("Calling Get Certificate for cert {0} on Service {1}.", certPwd.Thumbprint, this.CloudServiceName);

            var getCertTask = this.TestClient.GetServiceCertificateAsync(this.CloudServiceName, certPwd.Thumbprint, token);

            X509Certificate2 getCert = getCertTask.Result;

            this.TestContext.WriteLine("Got certificate with thumbprint {0} from Service {1}.", getCert.Thumbprint, this.CloudServiceName);

            Assert.AreEqual(certPwd.Thumbprint, getCert.Thumbprint);

            this.TestContext.WriteLine("Deleting certificate with thumbprint {0} from Service {1}.", certPwd.Thumbprint, this.CloudServiceName);

            var deleteTask = this.TestClient.DeleteServiceCertificate(this.CloudServiceName, certPwd.Thumbprint, token);

            deleteTask.Wait();

            this.TestContext.WriteLine("Deleting certificate with thumbprint {0} from Service {1}.", certNoPwd.Thumbprint, this.CloudServiceName);

            deleteTask = this.TestClient.DeleteServiceCertificate(this.CloudServiceName, certNoPwd.Thumbprint, token);

            deleteTask.Wait();

            this.TestContext.WriteLine("Certificate deleted, calling ListCertificates again to confirm deletion.");

            listCertsTask = this.TestClient.ListServiceCertificatesAsync(this.CloudServiceName);

            this.TestContext.WriteLine(listCertsTask.Result.ToString());

            //should be gone now, since we just created the service...
            Assert.IsTrue(listCertsTask.Result.Count == 0);

        }

        //separating this out because it gets used in several places
        private String CreateStorageAccountInternal()
        {
            this.TestContext.WriteLine("Beginning CreateStorageAccount operation.");

            String storageAccountName = this.CloudServiceName.ToLower().Substring(0, 24);

            this.TestContext.WriteLine("Creating Storage account with name {0}", storageAccountName);

            var createAndWaitTask = this.TestClient.CreateStorageAccountAsync(storageAccountName, this.CloudServiceName, null, this.Location, this.AffinityGroup, true, null)
                .ContinueWith(Utilities.PollUntilComplete(this.TestClient, "Create Storage Account", this.TestContext, this.TokenSource.Token));

            createAndWaitTask.Wait();

            this.TestContext.WriteLine("Storage account {0} created.", storageAccountName);

            this.TestContext.WriteLine("End CreateStorageAccount operation.");

            this.TestContext.WriteLine("Get StorageAccountProperties on new account.");

            var getTask = this.TestClient.GetStorageAccountPropertiesAsync(storageAccountName);

            this.TestContext.WriteLine(getTask.Result.ToString());

            return storageAccountName;
        }

        //ditto
        private void DeleteStorageAccountInternal(String storageAccountName)
        {
            this.TestContext.WriteLine("Beginning DeleteStorageAccount operation.");
            this.TestContext.WriteLine("Deleting Storage account {0}.", storageAccountName);
            //create is a polling operation, delete is not...
            var deleteTask = this.TestClient.DeleteStorageAccountAsync(storageAccountName);

            deleteTask.Wait();
            this.TestContext.WriteLine("Storage account {0} deleted.", storageAccountName);
            this.TestContext.WriteLine("End DeleteStorageAccount operation.");
        }

        private Deployment CreateDeploymentInternal(DeploymentSlot slot, Uri blobUri, bool startWithDeployment = false, bool treatWarningsAsError = false)
        {
            this.TestContext.WriteLine("Beginning CreateDeployment operation");
            CancellationToken token = this.TokenSource.Token;

            String name = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
            String label = name + "_TestDeployment";

            this.TestContext.WriteLine("Creating Deployment with name {0} and label {1} in slot {2}", name, label, slot.ToString());

            var createAndWaitTask = this.TestClient.CreateDeploymentAsync(this.CloudServiceName, slot, name, blobUri, label, Path.Combine(DataPath, ConfigFileGood), startWithDeployment, treatWarningsAsError, token)
                                    .ContinueWith(Utilities.PollUntilComplete(this.TestClient, "Create Deployment", this.TestContext, token));


            this.TestContext.WriteLine("CreateDeployment called, waiting...");

            createAndWaitTask.Wait();
            this.TestContext.WriteLine("Deployment in slot {0} created.", slot.ToString());
            this.TestContext.WriteLine("End CreateDeployment operation");
            this.TestContext.WriteLine("Getting properties of new Deployment");
            var getTask = this.TestClient.GetDeploymentAsync(this.CloudServiceName, slot, token);

            this.TestContext.WriteLine(getTask.Result.ToString());

            return getTask.Result;
        }
    }
}
