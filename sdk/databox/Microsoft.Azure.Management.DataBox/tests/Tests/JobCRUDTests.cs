using DataBox.Tests.Helpers;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DataBox.Tests.Tests
{
    public class JobCRUDTests : DataBoxTestBase
    {
        public JobCRUDTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void TestJobCRUDOperations()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var jobName = TestUtilities.GenerateName("SdkJob");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            Sku sku = GetDefaultSku();
            var destinationAccountsList = GetDestinationAccountsList();
            JobDetails jobDetails = new DataBoxJobDetails
            {
                ContactDetails = contactDetails,
                ShippingAddress = shippingAddress
            };
            jobDetails.DataImportDetails = new List<DataImportDetails>();
            jobDetails.DataImportDetails.Add(new DataImportDetails(destinationAccountsList.FirstOrDefault()));
            var jobResource = new JobResource
            {
                Sku = sku,
                Location = TestConstants.DefaultResourceLocation,
                Details = jobDetails
            };

            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = TestConstants.DefaultResourceLocation
                });

            var job = this.Client.Jobs.Create(resourceGroupName, jobName, jobResource);
            ValidateJobWithoutDetails(jobName, sku, job);
            Assert.Equal(StageName.DeviceOrdered, job.Status);

            var getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, getJob);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);
            Assert.Equal(StageName.DeviceOrdered, job.Status);

            contactDetails.ContactName = "Update Job";
            getJob.Details.ContactDetails = contactDetails;

            var Details = new UpdateJobDetails
            {
                ContactDetails = getJob.Details.ContactDetails,
                ShippingAddress = getJob.Details.ShippingAddress
            };

            var updateParams = new JobResourceUpdateParameter
            {
                Details = Details
            };
            var updateJob = this.Client.Jobs.Update(resourceGroupName, jobName, updateParams);
            ValidateJobWithoutDetails(jobName, sku, updateJob);
            Assert.Equal(StageName.DeviceOrdered, updateJob.Status);

            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, getJob);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);
            Assert.Equal(StageName.DeviceOrdered, getJob.Status);

            var jobList = this.Client.Jobs.List();
            Assert.NotNull(jobList);

            jobList = this.Client.Jobs.ListByResourceGroup(resourceGroupName);
            Assert.NotNull(jobList);

            this.Client.Jobs.Cancel(resourceGroupName, jobName, "CancelTest");
            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            Assert.Equal(StageName.Cancelled, getJob.Status);

            while (!string.IsNullOrWhiteSpace(getJob.Details.ContactDetails.ContactName))
            {
                Wait(TimeSpan.FromMinutes(5));
                getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            }
            this.Client.Jobs.Delete(resourceGroupName, jobName);
        }

        [Fact]
        public void TestScheduledJob()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var jobName = TestUtilities.GenerateName("SdkJob");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            Sku sku = GetDefaultSku();
            var destinationAccountsList = GetDestinationAccountsList();
            JobDetails jobDetails = new DataBoxJobDetails
            {
                ContactDetails = contactDetails,
                ShippingAddress = shippingAddress,

            };
            jobDetails.DataImportDetails = new List<DataImportDetails>();
            jobDetails.DataImportDetails.Add(new DataImportDetails(destinationAccountsList.FirstOrDefault()));

            var jobResource = new JobResource
            {
                Sku = sku,
                Location = TestConstants.DefaultResourceLocation,
                Details = jobDetails,
                DeliveryType = JobDeliveryType.Scheduled,
                DeliveryInfo = new JobDeliveryInfo
                {
                    ScheduledDateTime = DateTime.UtcNow.AddDays(20)
                }
            };

            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = TestConstants.DefaultResourceLocation
                });

            var job = this.Client.Jobs.Create(resourceGroupName, jobName, jobResource);
            ValidateJobWithoutDetails(jobName, sku, job);
            Assert.Equal(StageName.DeviceOrdered, job.Status);

            var getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, getJob);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.Scheduled);
            Assert.Equal(StageName.DeviceOrdered, job.Status);

            contactDetails.ContactName = "Update Job";
            getJob.Details.ContactDetails = contactDetails;

            var Details = new UpdateJobDetails
            {
                ContactDetails = getJob.Details.ContactDetails,
                ShippingAddress = getJob.Details.ShippingAddress
            };

            var updateParams = new JobResourceUpdateParameter
            {
                Details = Details
            };
            var updateJob = this.Client.Jobs.Update(resourceGroupName, jobName, updateParams);
            ValidateJobWithoutDetails(jobName, sku, updateJob);
            Assert.Equal(StageName.DeviceOrdered, updateJob.Status);

            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, getJob);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.Scheduled);
            Assert.Equal(StageName.DeviceOrdered, getJob.Status);

            var jobList = this.Client.Jobs.List();
            Assert.NotNull(jobList);

            jobList = this.Client.Jobs.ListByResourceGroup(resourceGroupName);
            Assert.NotNull(jobList);

            this.Client.Jobs.Cancel(resourceGroupName, jobName, "CancelTest");
            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            Assert.Equal(StageName.Cancelled, getJob.Status);

            while (!string.IsNullOrWhiteSpace(getJob.Details.ContactDetails.ContactName))
            {
                Wait(TimeSpan.FromMinutes(5));
                getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            }
            this.Client.Jobs.Delete(resourceGroupName, jobName);
        }

        [Fact]
        public void TestExportJobCRUDOperations()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var jobName = TestUtilities.GenerateName("SdkJob");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            Sku sku = GetDefaultSku();
            var sourceAccountsList = GetSourceAccountsList();

            JobDetails jobDetails = new DataBoxJobDetails
            {
                ContactDetails = contactDetails,
                ShippingAddress = shippingAddress
            };

            jobDetails.DataExportDetails = new List<DataExportDetails>();
            TransferConfiguration transferCofiguration = new TransferConfiguration
            {
                TransferConfigurationType = TransferConfigurationType.TransferAll,
                TransferAllDetails = new TransferConfigurationTransferAllDetails
                {
                    Include = new TransferAllDetails
                    {
                        DataAccountType = DataAccountType.StorageAccount,
                        TransferAllBlobs = true,
                        TransferAllFiles = true
                    }
                }
            };

            jobDetails.DataExportDetails.Add(new DataExportDetails(transferCofiguration, sourceAccountsList.FirstOrDefault()));
            var jobResource = new JobResource
            {
                Sku = sku,
                Location = TestConstants.DefaultResourceLocation,
                Details = jobDetails,
                TransferType = TransferType.ExportFromAzure
            };

            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = TestConstants.DefaultResourceLocation
                });

            var job = this.Client.Jobs.Create(resourceGroupName, jobName, jobResource);
            ValidateJobWithoutDetails(jobName, sku, job);
            Assert.Equal(StageName.DeviceOrdered, job.Status);

            var getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, getJob);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);
            Assert.Equal(StageName.DeviceOrdered, job.Status);

            contactDetails.ContactName = "Update Job";
            getJob.Details.ContactDetails = contactDetails;

            var Details = new UpdateJobDetails
            {
                ContactDetails = getJob.Details.ContactDetails,
                ShippingAddress = getJob.Details.ShippingAddress
            };

            var updateParams = new JobResourceUpdateParameter
            {
                Details = Details
            };
            var updateJob = this.Client.Jobs.Update(resourceGroupName, jobName, updateParams);
            ValidateJobWithoutDetails(jobName, sku, updateJob);
            Assert.Equal(StageName.DeviceOrdered, updateJob.Status);

            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, getJob);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);
            Assert.Equal(StageName.DeviceOrdered, getJob.Status);

            var jobList = this.Client.Jobs.List();
            Assert.NotNull(jobList);

            jobList = this.Client.Jobs.ListByResourceGroup(resourceGroupName);
            Assert.NotNull(jobList);

            this.Client.Jobs.Cancel(resourceGroupName, jobName, "CancelTest");
            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            Assert.Equal(StageName.Cancelled, getJob.Status);

            while (!string.IsNullOrWhiteSpace(getJob.Details.ContactDetails.ContactName))
            {
                Wait(TimeSpan.FromMinutes(5));
                getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            }
            this.Client.Jobs.Delete(resourceGroupName, jobName);
        }

        [Fact]
        public void DevicePasswordTest()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var jobName = TestUtilities.GenerateName("SdkJob");
            //var jobName = "SdkJob5929";
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            Sku sku = GetDefaultSku();
            var destinationAccountsList = new List<StorageAccountDetails>
            {
                new StorageAccountDetails
                {
                    StorageAccountId = "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/databoxbvt1/providers/Microsoft.Storage/storageAccounts/databoxbvttestaccount2"
                }
            };

            destinationAccountsList[0].SharePassword = "Abcd223@22344Abcd223@22344";
            JobDetails jobDetails = new DataBoxJobDetails
            {
                ContactDetails = contactDetails,
                ShippingAddress = shippingAddress,
                DevicePassword = "Abcd223@22344"
            };
            jobDetails.DataImportDetails = new List<DataImportDetails>();
            jobDetails.DataImportDetails.Add(new DataImportDetails(destinationAccountsList.FirstOrDefault()));

            var jobResource = new JobResource
            {
                Sku = sku,
                Location = TestConstants.DefaultResourceLocation,
                Details = jobDetails,
            };

            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = TestConstants.DefaultResourceLocation
                });

            var job = this.Client.Jobs.Create(resourceGroupName, jobName, jobResource);

            var getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, job);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);

            Assert.Equal(StageName.DeviceOrdered, job.Status);
        }

        [Fact]
        public void CmkEnablementTest()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var jobName = TestUtilities.GenerateName("SdkJob");
            //var jobName = "SdkJob5929";
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            Sku sku = GetDefaultSku();
            var destinationAccountsList = new List<StorageAccountDetails>
            {
                new StorageAccountDetails
                {
                    StorageAccountId = "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/databoxbvt1/providers/Microsoft.Storage/storageAccounts/databoxbvttestaccount2"
                }
            };
            JobDetails jobDetails = new DataBoxJobDetails
            {
                ContactDetails = contactDetails,
                ShippingAddress = shippingAddress
            };
            jobDetails.DataImportDetails = new List<DataImportDetails>();
            jobDetails.DataImportDetails.Add(new DataImportDetails(destinationAccountsList.FirstOrDefault()));

            var jobResource = new JobResource
            {
                Sku = sku,
                Location = TestConstants.DefaultResourceLocation,
                Details = jobDetails,
            };

            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = TestConstants.DefaultResourceLocation
                });

            var job = this.Client.Jobs.Create(resourceGroupName, jobName, jobResource);
            ValidateJobWithoutDetails(jobName, sku, job);
            Assert.Equal(StageName.DeviceOrdered, job.Status);

            // Set Msi details.
            string tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            string identityType = "SystemAssigned";
            var identity = new ResourceIdentity(identityType, Guid.NewGuid().ToString(), tenantId);
            var updateParams = new JobResourceUpdateParameter
            {
                Identity = identity
            };

            var updateJob = this.Client.Jobs.Update(resourceGroupName, jobName, updateParams);
            ValidateJobWithoutDetails(jobName, sku, updateJob);

            var getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, job);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);

            Assert.Equal(StageName.DeviceOrdered, updateJob.Status);
            Assert.Equal(identityType, updateJob.Identity.Type);

            var keyEncryptionKey = new KeyEncryptionKey(KekType.CustomerManaged)
            {
                KekUrl = @"https://sdkkeyvault.vault.azure.net/keys/SSDKEY/",
                KekVaultResourceID =
                    "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/akvenkat/providers/Microsoft.KeyVault/vaults/SDKKeyVault"
            };

            var details = new UpdateJobDetails
            {
                KeyEncryptionKey = keyEncryptionKey
            };

            updateParams = new JobResourceUpdateParameter
            {
                Details = details
            };

            updateJob = this.Client.Jobs.Update(resourceGroupName, jobName, updateParams);
            ValidateJobWithoutDetails(jobName, sku, updateJob);
            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);

            Assert.Equal(StageName.DeviceOrdered, updateJob.Status);
            Assert.Equal(KekType.CustomerManaged, getJob.Details.KeyEncryptionKey.KekType);
        }

        [Fact]
        public void DoubleEncryptionTest()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var jobName = TestUtilities.GenerateName("SdkJob");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            Preferences preferences = new Preferences
            {
                EncryptionPreferences = new EncryptionPreferences
                {
                    DoubleEncryption = DoubleEncryption.Enabled
                }
            };
            Sku sku = GetDefaultSku();
            var destinationAccountsList = GetDestinationAccountsList();
            JobDetails jobDetails = new DataBoxJobDetails
            {
                ContactDetails = contactDetails,
                ShippingAddress = shippingAddress,
                Preferences=preferences
            };
            jobDetails.DataImportDetails = new List<DataImportDetails>();
            jobDetails.DataImportDetails.Add(new DataImportDetails(destinationAccountsList.FirstOrDefault()));

            var jobResource = new JobResource
            {
                Sku = sku,
                Location = TestConstants.DefaultResourceLocation,
                Details = jobDetails
            };

            
            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = TestConstants.DefaultResourceLocation
                });

            var job = this.Client.Jobs.Create(resourceGroupName, jobName, jobResource);
            ValidateJobWithoutDetails(jobName, sku, job);
            Assert.Equal(StageName.DeviceOrdered, job.Status);

            var getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, getJob);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);
            Assert.Equal(StageName.DeviceOrdered, job.Status);
            Assert.Equal(DoubleEncryption.Enabled, getJob.Details.Preferences.EncryptionPreferences.DoubleEncryption);

            contactDetails.ContactName = "Update Job";
            getJob.Details.ContactDetails = contactDetails;

            var Details = new UpdateJobDetails
            {
                ContactDetails = getJob.Details.ContactDetails,
                ShippingAddress = getJob.Details.ShippingAddress
            };

            var updateParams = new JobResourceUpdateParameter
            {
                Details = Details
            };
            var updateJob = this.Client.Jobs.Update(resourceGroupName, jobName, updateParams);
            ValidateJobWithoutDetails(jobName, sku, updateJob);
            Assert.Equal(StageName.DeviceOrdered, updateJob.Status);

            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, getJob);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);
            Assert.Equal(StageName.DeviceOrdered, getJob.Status);

            var jobList = this.Client.Jobs.List();
            Assert.NotNull(jobList);

            jobList = this.Client.Jobs.ListByResourceGroup(resourceGroupName);
            Assert.NotNull(jobList);

            this.Client.Jobs.Cancel(resourceGroupName, jobName, "CancelTest");
            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            Assert.Equal(StageName.Cancelled, getJob.Status);

            while (!string.IsNullOrWhiteSpace(getJob.Details.ContactDetails.ContactName))
            {
                Wait(TimeSpan.FromMinutes(5));
                getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            }
            this.Client.Jobs.Delete(resourceGroupName, jobName);
        }

        [Fact]
        public void CreateJobWithUserAssignedIdentity()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var jobName = TestUtilities.GenerateName("SdkJob");
            //var jobName = "SdkJob5929";
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            Sku sku = GetDefaultSku();
            var destinationAccountsList = new List<StorageAccountDetails>
            {
                new StorageAccountDetails
                {
                    StorageAccountId = "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/databoxbvt1/providers/Microsoft.Storage/storageAccounts/databoxbvttestaccount2"
                }
            };

            var uaiId = "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/akvenkat/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdkIdentity";
            var kekDetails = new KeyEncryptionKey(KekType.CustomerManaged)
            {
                KekType = KekType.CustomerManaged,
                KekUrl = @"https://sdkkeyvault.vault.azure.net/keys/SSDKEY/",
                KekVaultResourceID =
                   "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/akvenkat/providers/Microsoft.KeyVault/vaults/SDKKeyVault",
                IdentityProperties = new IdentityProperties
                {
                    Type = "UserAssigned",
                    UserAssigned = new UserAssignedProperties { ResourceId = uaiId }
                }
            };
            JobDetails jobDetails = new DataBoxJobDetails(contactDetails,
                default(IList<JobStages>),shippingAddress, default(PackageShippingDetails),
                default(PackageShippingDetails), default(IList<DataImportDetails>),
                default(IList<DataExportDetails>),default(Preferences),
                default(IList<CopyLogDetails>),default(string),default(string),
                kekDetails);
           
            jobDetails.DataImportDetails = new List<DataImportDetails>();
            jobDetails.DataImportDetails.Add(new DataImportDetails(destinationAccountsList.FirstOrDefault()));

            var jobResource = new JobResource
            {
                Sku = sku,
                Location = TestConstants.DefaultResourceLocation,
                Details = jobDetails,
            };

            
            UserAssignedIdentity uid = new UserAssignedIdentity();
            var identity = new ResourceIdentity//ResourceIdentity checked by auto mapper
            {
                Type = "UserAssigned",
                UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>
                {
                    { uaiId, uid }
                },
            };

            jobResource.Identity = identity;

            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = TestConstants.DefaultResourceLocation
                });

            var job = this.Client.Jobs.Create(resourceGroupName, jobName, jobResource);
            ValidateJobWithoutDetails(jobName, sku, job);
            Assert.Equal(StageName.DeviceOrdered, job.Status);
            String iden ="UserAssigned";
            Assert.Equal(iden, job.Identity.Type);
            var getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, getJob);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);
            Assert.Equal(StageName.DeviceOrdered, getJob.Status);
            Assert.True(!string.IsNullOrEmpty(getJob.Identity.UserAssignedIdentities[uaiId].ClientId));
            Assert.True(!string.IsNullOrEmpty(getJob.Identity.UserAssignedIdentities[uaiId].PrincipalId));
            Assert.Equal(KekType.CustomerManaged, getJob.Details.KeyEncryptionKey.KekType);
        }

        [Fact]
        public void UpdateSystemAssignedToUserAssigned()     
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var jobName = TestUtilities.GenerateName("SdkJob");
            //var jobName = "SdkJob5929";
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            Sku sku = GetDefaultSku();
            var destinationAccountsList = new List<StorageAccountDetails>
            {
                new StorageAccountDetails
                {
                    StorageAccountId = "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/databoxbvt1/providers/Microsoft.Storage/storageAccounts/databoxbvttestaccount2"
                }
            };
            JobDetails jobDetails = new DataBoxJobDetails
            {
                ContactDetails = contactDetails,
                ShippingAddress = shippingAddress
            };
            jobDetails.DataImportDetails = new List<DataImportDetails>();
            jobDetails.DataImportDetails.Add(new DataImportDetails(destinationAccountsList.FirstOrDefault()));

            var jobResource = new JobResource
            {
                Sku = sku,
                Location = TestConstants.DefaultResourceLocation,
                Details = jobDetails,
            };

            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = TestConstants.DefaultResourceLocation
                });

            var job = this.Client.Jobs.Create(resourceGroupName, jobName, jobResource);
            ValidateJobWithoutDetails(jobName, sku, job);
            Assert.Equal(StageName.DeviceOrdered, job.Status);

            // Set Msi details.
            string tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            string identityType = "SystemAssigned";
            var identity = new ResourceIdentity(identityType, Guid.NewGuid().ToString(), tenantId);
            var updateParams = new JobResourceUpdateParameter
            {
                Identity = identity
            };

            var updateJob = this.Client.Jobs.Update(resourceGroupName, jobName, updateParams);
            ValidateJobWithoutDetails(jobName, sku, updateJob);

            var getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobWithoutDetails(jobName, sku, job);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);

            Assert.Equal(StageName.DeviceOrdered, updateJob.Status);
            Assert.Equal(identityType, updateJob.Identity.Type);

            //Updating to User Assigned
            var uaiId = "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/akvenkat/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdkIdentity";
            var keyEncryptionKey = new KeyEncryptionKey(KekType.CustomerManaged)
            {
                KekUrl = @"https://sdkkeyvault.vault.azure.net/keys/SSDKEY/",
                KekVaultResourceID =
                    "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/akvenkat/providers/Microsoft.KeyVault/vaults/SDKKeyVault",
                IdentityProperties = new IdentityProperties
                {
                    Type = "UserAssigned",
                    UserAssigned = new UserAssignedProperties { ResourceId = uaiId }
                }
            };

            UserAssignedIdentity uid = new UserAssignedIdentity();
            identity = new ResourceIdentity//ResourceIdentity checked by auto mapper
            {
                Type = "SystemAssigned,UserAssigned",
                UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>
                {
                    { uaiId, uid }
                },
            };

            var details = new UpdateJobDetails
            {
                KeyEncryptionKey = keyEncryptionKey
            };

            updateParams = new JobResourceUpdateParameter
            {
                Details = details,
                Identity = identity
            };

            updateJob = this.Client.Jobs.Update(resourceGroupName, jobName, updateParams);
            ValidateJobWithoutDetails(jobName, sku, updateJob);
            getJob = this.Client.Jobs.Get(resourceGroupName, jobName, TestConstants.Details);
            ValidateJobDetails(contactDetails, shippingAddress, getJob, JobDeliveryType.NonScheduled);
            Assert.Equal(StageName.DeviceOrdered, getJob.Status);
            Assert.True(!string.IsNullOrEmpty(getJob.Identity.UserAssignedIdentities[uaiId].ClientId));
            Assert.True(!string.IsNullOrEmpty(getJob.Identity.UserAssignedIdentities[uaiId].PrincipalId));
        }
    }
}

