using System;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit.Abstractions;
using Xunit.Sdk;
using Microsoft.Azure.Management.DataBox;
using System.Reflection;
using DataBox.Tests.Helpers;
using Microsoft.Azure.Management.Resources;
using System.Threading;
using Microsoft.Azure.Management.DataBox.Models;
using System.Collections.Generic;
using Xunit;

namespace DataBox.Tests
{
    public class DataBoxTestBase : TestBase, IDisposable
    {
        protected const string SubIdKey = "SubId";

        protected const int DefaultWaitingTimeInMs = 60000;

        protected MockContext Context { get; set; }

        public DataBoxManagementClient Client { get; protected set; }

        public ResourceManagementClient RMClient { get; protected set; }

        public DataBoxTestBase(ITestOutputHelper testOutputHelper)
        {
            // Getting test method name here as we are not initializing context from each method
            var helper = (TestOutputHelper)testOutputHelper;
            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance)
                                  .GetValue(helper);
            this.Context = MockContext.Start(this.GetType().FullName, test.TestCase.TestMethod.Method.Name);

            this.Client = this.Context.GetServiceClient<DataBoxManagementClient>();
            this.RMClient = this.Context.GetServiceClient<ResourceManagementClient>();

            var testEnv = TestEnvironmentFactory.GetTestEnvironment();
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables[SubIdKey] = testEnv.SubscriptionId;
            }
        }

        /// <summary>
        /// Wait for the specified span unless we are in mock playback mode
        /// </summary>
        /// <param name="timeout">The span of time to wait for</param>
        public static void Wait(TimeSpan timeout)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                Thread.Sleep(timeout);
            }
        }

        public void Dispose()
        {
            this.Client.Dispose();
            this.Context.Dispose();
        }

        ~DataBoxTestBase()
        {
            Dispose();
        }

        protected static object GetResourceManagementClient(object context, object handler)
        {
            throw new NotImplementedException();
        }

        protected static Sku GetDefaultSku()
        {
            return new Sku
            {
                Name = "DataBox"
            };
        }

        protected static List<DestinationAccountDetails> GetDestinationAccountsList()
        {
            return new List<DestinationAccountDetails>
            {
                new DestinationAccountDetails
                {
                    AccountId = "/subscriptions/3c66da21-607e-49b4-8bdf-f25fbb8f705f/resourceGroups/kvtestWUSrg/providers/microsoft.storage/storageAccounts/kvtestwus",
                }
            };
        }

        protected static ContactDetails GetDefaultContactDetails()
        {
            return new ContactDetails
            {
                ContactName = "Public SDK Test",
                Phone = "1234567890",
                PhoneExtension = "1234",
                EmailList = new List<string> { "testing@microsoft.com" },
            };
        }

        protected static ShippingAddress GetDefaultShippingAddress()
        {
            return new ShippingAddress
            {
                StreetAddress1 = "16 TOWNSEND ST",
                StreetAddress2 = "Unit 1",
                City = "San Francisco",
                StateOrProvince = "CA",
                Country = "US",
                PostalCode = "94107",
                CompanyName = "Microsoft",
                AddressType = AddressType.Commercial
            };
        }

        protected static void ValidateJobDetails(ContactDetails contactDetails, ShippingAddress shippingAddress, JobResource getJob)
        {
            Assert.NotNull(getJob.Details);
            Assert.NotNull(getJob.Details.ContactDetails.NotificationPreference);
            Assert.Equal(contactDetails.ContactName, getJob.Details.ContactDetails.ContactName);
            Assert.Equal(contactDetails.Phone, getJob.Details.ContactDetails.Phone);
            Assert.Equal(contactDetails.PhoneExtension, getJob.Details.ContactDetails.PhoneExtension);
            Assert.Equal(contactDetails.EmailList, getJob.Details.ContactDetails.EmailList);
            Assert.Equal(shippingAddress.AddressType, getJob.Details.ShippingAddress.AddressType);
            Assert.Equal(shippingAddress.City, getJob.Details.ShippingAddress.City);
            Assert.Equal(shippingAddress.CompanyName, getJob.Details.ShippingAddress.CompanyName);
            Assert.Equal(shippingAddress.Country, getJob.Details.ShippingAddress.Country);
            Assert.Equal(shippingAddress.PostalCode, getJob.Details.ShippingAddress.PostalCode);
            Assert.Equal(shippingAddress.StateOrProvince, getJob.Details.ShippingAddress.StateOrProvince);
            Assert.Equal(shippingAddress.StreetAddress1, getJob.Details.ShippingAddress.StreetAddress1);
            Assert.Equal(shippingAddress.StreetAddress2, getJob.Details.ShippingAddress.StreetAddress2);
            Assert.Equal(shippingAddress.StreetAddress3, getJob.Details.ShippingAddress.StreetAddress3);
        }

        protected static void ValidateJobWithoutDetails(string jobName, List<DestinationAccountDetails> destinationAccountList,
            Sku sku, JobResource job, bool cancellableCheck = true)
        {
            Assert.NotNull(job);
            job.Validate();
            Assert.NotNull(job.DestinationAccountDetails);
            Assert.NotNull(job.Id);
            Assert.NotNull(job.Type);
            Assert.Equal(cancellableCheck, job.IsCancellable);
            Assert.Equal(cancellableCheck, job.IsShippingAddressEditable);
            Assert.NotNull(job.Sku);
            Assert.NotNull(job.StartTime);
            Assert.Equal(sku.Name, job.Sku.Name);
            Assert.Equal(TestConstants.DefaultResourceLocation, job.Location);
            Assert.Equal(jobName, job.Name);
            Assert.Equal(TestConstants.DefaultType, job.Type);
            Assert.Equal(destinationAccountList[0].AccountId, job.DestinationAccountDetails[0].AccountId);
            Assert.Equal(DeviceType.Pod, job.DeviceType);
        }
    }
}
