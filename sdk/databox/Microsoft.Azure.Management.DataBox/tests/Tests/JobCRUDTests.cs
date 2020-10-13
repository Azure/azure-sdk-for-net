using DataBox.Tests.Helpers;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
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
            JobDetails jobDetails = new DataBoxJobDetails
            {
                ContactDetails = contactDetails,
                ShippingAddress = shippingAddress,
                DestinationAccountDetails = GetDestinationAccountsList(),
                
            };

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
            JobDetails jobDetails = new DataBoxJobDetails
            {
                ContactDetails = contactDetails,
                ShippingAddress = shippingAddress,
                DestinationAccountDetails = GetDestinationAccountsList(),

            };

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

        
    }
}

