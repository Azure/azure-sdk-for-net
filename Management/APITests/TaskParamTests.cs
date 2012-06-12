using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Azure.Management.v1_7;
using System.IO;

namespace APITests
{
    /// <summary>
    /// All tests in this file should be catching exceptions
    /// and not get through to the server. They should therefore run quickly.
    /// They are validating proper exceptions for bad parameters
    /// </summary>
    [TestClass]
    public class TaskParamTests : TaskTestsBase
    {
        public TaskParamTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //None in this class *on purpose* do *not* add
        //if you need it do it in another class
        #endregion

        private const string dummyServiceName = "DummyServiceName";
        private const string dummyLocation = "US Ozarks";
        private const string dummyAffinityGroup = "0000000000000000000000000000";
        private const string dummyDeploymentName = dummyAffinityGroup;
        private static readonly Uri dummyUri = new Uri("http://dummy.dum");
        private const string dummyConfigFilePath = @"M:\DummyFile.cfg";
        private const string labelMax =         "ThisLabelIs100CharactersLongThisLabelIs100CharactersLongThisLabelIs100CharactersLongThisLabelIs100Ch";
        private const string tooLongLabel =     "ThisLabelIs101CharactersLongThisLabelIs101CharactersLongThisLabelIs101CharactersLongThisLabelIs101Cha";
        private const string descriptionMax =   "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersL" +
                                                "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersL" +
                                                "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersL" +
                                                "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersL" +
                                                "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersL" +
                                                "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersL" +
                                                "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersL" +
                                                "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersL" +
                                                "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersL" +
                                                "ThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongThisDescriptionIs1024CharactersLongX";
        private const string tooLongDescription = descriptionMax + "X";
        private const string storageAccountNameMax = "storageaccountmaxlenis24";
        private const string tooLongStorageAccountName = storageAccountNameMax + "x";
        private const string tooShortStorageAccountName = "ab";
        private const string storageAccountNameWithCaps = "StorageAccountMaxLenIs24";
        private const string storageAccountNameWithOtherChars = "storageaccountillegal`~!";

        #region Cloud Service Tests
        #region CreateCloudService Tests
        //every method with no optional parameters needs several small
        //tests to validate null and bad data
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateServiceNameNull()
        {
            try
            {
                this.TestClient.CreateCloudServiceAsync(null, labelMax, descriptionMax, dummyLocation, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateServiceLabelNull()
        {
            try
            {
                this.TestClient.CreateCloudServiceAsync(dummyServiceName, null, descriptionMax, null, dummyAffinityGroup);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateServiceLabelTooLong()
        {
            try
            {
                this.TestClient.CreateCloudServiceAsync(dummyServiceName, tooLongLabel, descriptionMax, dummyLocation, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateServiceDescriptionTooLong()
        {
            try
            {
                this.TestClient.CreateCloudServiceAsync(dummyServiceName, labelMax, tooLongDescription, null, dummyAffinityGroup);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateServiceLocationAffinityGroupNull()
        {
            try
            {
                this.TestClient.CreateCloudServiceAsync(dummyServiceName, labelMax, descriptionMax, null, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateServiceLocationAffinityGroupBoth()
        {
            try
            {
                this.TestClient.CreateCloudServiceAsync(dummyServiceName, labelMax, descriptionMax, dummyLocation, dummyAffinityGroup);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region UpdateCloudService Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateServiceNameNull()
        {
            try
            {
                this.TestClient.UpdateCloudServiceAsync(null, labelMax, descriptionMax, dummyLocation, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        //label is allowed to be null in Update, so no UpdateServiceLabelNull test...

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateServiceLabelTooLong()
        {
            try
            {
                this.TestClient.UpdateCloudServiceAsync(dummyServiceName, tooLongLabel, descriptionMax, dummyLocation, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateServiceDescriptionTooLong()
        {
            try
            {
                this.TestClient.UpdateCloudServiceAsync(dummyServiceName, labelMax, tooLongDescription, null, dummyAffinityGroup);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        //In update location and affinity group *are* both allowed to be null, so no UpdateServiceLocationAffinityGroupNull test

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateServiceLocationAffinityGroupBoth()
        {
            try
            {
                this.TestClient.UpdateCloudServiceAsync(dummyServiceName, labelMax, descriptionMax, dummyLocation, dummyAffinityGroup);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        #endregion

        #region DeleteCloudService Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteServiceNameNull()
        {
            try
            {
                this.TestClient.DeleteCloudServiceAsync(null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region GetCloudServiceProperties Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCloudServicePropertiesNameNull()
        {
            try
            {
                this.TestClient.GetCloudServicePropertiesAsync(null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region CreateDeployment Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateDeploymentServiceNameNull()
        {
            try
            {
                this.TestClient.CreateDeploymentAsync(null, DeploymentSlot.Staging, dummyDeploymentName, dummyUri, labelMax, dummyConfigFilePath);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateDeploymentDeploymentNameNull()
        {
            try
            {
                this.TestClient.CreateDeploymentAsync(dummyServiceName, DeploymentSlot.Staging, null, dummyUri, labelMax, dummyConfigFilePath);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateDeploymentUriNull()
        {
            try
            {
                this.TestClient.CreateDeploymentAsync(dummyServiceName, DeploymentSlot.Staging, dummyDeploymentName, null, labelMax, dummyConfigFilePath);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateDeploymentLabelNull()
        {
            try
            {
                this.TestClient.CreateDeploymentAsync(dummyServiceName, DeploymentSlot.Production, dummyDeploymentName, dummyUri, null, dummyConfigFilePath);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateDeploymentLabelToLong()
        {
            try
            {
                this.TestClient.CreateDeploymentAsync(dummyServiceName, DeploymentSlot.Staging, dummyDeploymentName, dummyUri, tooLongLabel, dummyConfigFilePath);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateDeploymentConfigNull()
        {
            try
            {
                this.TestClient.CreateDeploymentAsync(dummyServiceName, DeploymentSlot.Production, dummyDeploymentName, dummyUri, labelMax, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CreateDeploymentConfigNotFound()
        {
            try
            {
                this.TestClient.CreateDeploymentAsync(dummyServiceName, DeploymentSlot.Staging, dummyDeploymentName, dummyUri, labelMax, dummyConfigFilePath);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region GetDeployment Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDeploymentServiceNameNull()
        {
            try
            {
                this.TestClient.GetDeploymentAsync(null, DeploymentSlot.Production);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region VipSwap Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VipSwapServiceNameNull()
        {
            try
            {
                this.TestClient.VipSwapAsync(null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region DeleteDeployment Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteDeploymentServiceNameNull()
        {
            try
            {
                this.TestClient.DeleteDeploymentAsync(null, DeploymentSlot.Staging);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region ChangeDeploymentConfiguration Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeConfigServiceNameNull()
        {
            try
            {
                this.TestClient.ChangeDeploymentConfigurationAsync(null, DeploymentSlot.Staging, dummyConfigFilePath);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeConfigConfigFileNull()
        {
            try
            {
                this.TestClient.ChangeDeploymentConfigurationAsync(dummyServiceName, DeploymentSlot.Staging, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ChangeConfigConfigFileNotFound()
        {
            try
            {
                this.TestClient.ChangeDeploymentConfigurationAsync(dummyServiceName, DeploymentSlot.Staging, dummyConfigFilePath);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region Start\Stop Deployment Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StartDeploymentServiceNameNull()
        {
            try
            {
                this.TestClient.StartDeploymentAsync(null, DeploymentSlot.Production);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StopDeploymentServiceNameNull()
        {
            try
            {
                this.TestClient.StopDeploymentAsync(null, DeploymentSlot.Production);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region UpgradeDeployment Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpgradeDeploymentServiceNameNull()
        {
            try
            {
                this.TestClient.UpgradeDeploymentAsync(null, DeploymentSlot.Production, UpgradeType.Auto, dummyUri, dummyConfigFilePath, labelMax);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpgradeDeploymentUriNull()
        {
            try
            {
                this.TestClient.UpgradeDeploymentAsync(dummyServiceName, DeploymentSlot.Production, UpgradeType.Auto, null, dummyConfigFilePath, labelMax);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpgradeDeploymentLabelNull()
        {
            try
            {
                this.TestClient.UpgradeDeploymentAsync(dummyServiceName, DeploymentSlot.Production, UpgradeType.Auto, dummyUri, dummyConfigFilePath, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpgradeDeploymentLabelToLong()
        {
            try
            {
                this.TestClient.UpgradeDeploymentAsync(dummyServiceName, DeploymentSlot.Production, UpgradeType.Auto, dummyUri, dummyConfigFilePath, tooLongLabel);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpgradeDeploymentConfigNull()
        {
            try
            {
                this.TestClient.UpgradeDeploymentAsync(dummyServiceName, DeploymentSlot.Production, UpgradeType.Auto, dummyUri, null, labelMax);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void UpgradeDeploymentConfigNotFound()
        {
            try
            {
                this.TestClient.UpgradeDeploymentAsync(dummyServiceName, DeploymentSlot.Production, UpgradeType.Auto, dummyUri, dummyConfigFilePath, labelMax);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region WalkUpgradeDomain Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WalkUpgradeDomainServiceNameNull()
        {
            try
            {
                this.TestClient.WalkUpgradeDomainAsync(null, DeploymentSlot.Production, 0); ;
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion
        #endregion

        #region Storage Account Tests
        #region GetStorageAccountProperties Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStorageAccountPropertiesNameNull()
        {
            try
            {
                this.TestClient.GetStorageAccountPropertiesAsync(null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region GetStorageAccountKeys Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStorageAccountKeysNameNull()
        {
            try
            {
                this.TestClient.GetStorageAccountKeysAsync(null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region CreateStorageAccount Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateStorageAccountNameNull()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(null, labelMax, descriptionMax, dummyLocation, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStorageAccountNameTooLong()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(tooLongStorageAccountName, labelMax, descriptionMax, null, dummyAffinityGroup);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStorageAccountNameTooShort()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(tooShortStorageAccountName, labelMax, descriptionMax, dummyLocation, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStorageAccountNameWithCaps()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(storageAccountNameWithCaps, labelMax, descriptionMax, dummyLocation, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStorageAccountNameIllegalChar()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(storageAccountNameWithOtherChars, labelMax, descriptionMax, null, dummyAffinityGroup);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStorageAccountDescriptionTooLong()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(storageAccountNameMax, labelMax, tooLongDescription, dummyLocation, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateStorageAccountLabelNull()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(storageAccountNameMax, null, descriptionMax, null, dummyAffinityGroup);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStorageAccountLabelTooLong()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(storageAccountNameMax, tooLongLabel, descriptionMax, dummyLocation, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStorageAccountLocationAffinityGroupNull()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(storageAccountNameMax, labelMax, descriptionMax, null, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStorageAccountLocationAffinityGroupBoth()
        {
            try
            {
                this.TestClient.CreateStorageAccountAsync(storageAccountNameMax, labelMax, descriptionMax, dummyLocation, dummyAffinityGroup);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region DeleteStorageAccount Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteStorageAccountNameNull()
        {
            try
            {
                this.TestClient.DeleteStorageAccountAsync(null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion
        #endregion

        #region Tracking Operations Tests
        #region GetOperationStatus tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOperationStatusRequestIdNull()
        {
            try
            {
                this.TestClient.GetOperationStatusAsync(null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion
        #endregion

        //Only location operation is ListLocations, no non-default params, so no tests here...

        #region Affinity Group Tests
        #region CreateAffinityGroup Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAffinityGroupNameNull()
        {
            try
            {
                this.TestClient.CreateAffinityGroupAsync(null, labelMax, descriptionMax, dummyLocation);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAffinityGroupLabelNull()
        {
            try
            {
                this.TestClient.CreateAffinityGroupAsync(dummyAffinityGroup, null, descriptionMax, dummyLocation);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateAffinityGroupLabelTooLong()
        {
            try
            {
                this.TestClient.CreateAffinityGroupAsync(dummyAffinityGroup, tooLongLabel, descriptionMax, dummyLocation);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateAffinityGroupDescriptionTooLong()
        {
            try
            {
                this.TestClient.CreateAffinityGroupAsync(dummyAffinityGroup, labelMax, tooLongDescription, dummyLocation);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAffinityGroupLocationNull()
        {
            try
            {
                this.TestClient.CreateAffinityGroupAsync(dummyAffinityGroup, labelMax, descriptionMax, null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region DeleteAffinityGroup Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteAffinityGroupNameNull()
        {
            try
            {
                this.TestClient.DeleteAffinityGroupAsync(null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion

        #region GetAffinityGroup Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAffinityGroupNameNull()
        {
            try
            {
                this.TestClient.GetAffinityGroupAsync(null);
            }
            catch (Exception e)
            {
                this.TestContext.WriteLine(e.Message);
                throw;
            }
        }
        #endregion
        #endregion
    }
}
