// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.TestFramework;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.ResourceManager.Communication.Tests
{
    public abstract class CommunicationManagementClientLiveTestBase : ManagementRecordedTestBase<CommunicationManagementTestEnvironment>
    {
        public string ResourceGroupPrefix { get; private set; }
        public string ResourceLocation { get; private set; }
        public string ResourceDataLocation { get; private set; }

        public ArmClient ArmClient { get; set; }

        protected CommunicationManagementClientLiveTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreTestInLiveMode();
            Init();
        }

        private void Init()
        {
            ResourceGroupPrefix = "Communication-RG-";
            ResourceLocation = "global";
            ResourceDataLocation = "UnitedStates";
            // Sanitizer = new CommunicationManagementRecordedTestSanitizer();
        }

        protected CommunicationManagementClientLiveTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
            IgnoreTestInLiveMode();
            Init();
        }

        internal async Task<CommunicationServiceResource> CreateDefaultCommunicationServices(string communicationServiceName, ResourceGroupResource _resourceGroup)
        {
            CommunicationServiceResourceData data = new CommunicationServiceResourceData(ResourceLocation)
            {
                DataLocation = ResourceDataLocation,
            };
            var communicationServiceLro = await _resourceGroup.GetCommunicationServiceResources().CreateOrUpdateAsync(WaitUntil.Completed, communicationServiceName, data);
            return communicationServiceLro.Value;
        }

        internal async Task<EmailServiceResource> CreateDefaultEmailServices(string emailServiceName, ResourceGroupResource _resourceGroup)
        {
            EmailServiceResourceData data = new EmailServiceResourceData(ResourceLocation)
            {
                DataLocation = ResourceDataLocation,
            };
            var emailServiceLro = await _resourceGroup.GetEmailServiceResources().CreateOrUpdateAsync(WaitUntil.Completed, emailServiceName, data);
            return emailServiceLro.Value;
        }

        internal async Task<CommunicationDomainResource> CreateDefaultDomain(string domainName, EmailServiceResource emailService)
        {
            CommunicationDomainResourceData data = new CommunicationDomainResourceData(ResourceLocation)
            {
                DomainManagement = DomainManagement.CustomerManaged
            };
            var domainLro = await emailService.GetCommunicationDomainResources().CreateOrUpdateAsync(WaitUntil.Completed, domainName, data);
            return domainLro.Value;
        }

        internal async Task<CommunicationDomainResource> CreateAzureManagedDomain(EmailServiceResource emailService)
        {
            CommunicationDomainResourceData data = new CommunicationDomainResourceData(ResourceLocation)
            {
                DomainManagement = DomainManagement.AzureManaged
            };
            var domainLro = await emailService.GetCommunicationDomainResources().CreateOrUpdateAsync(WaitUntil.Completed, "AzureManagedDomain", data);
            return domainLro.Value;
        }

        internal async Task<SenderUsernameResource> CreateDefaultSenderUsernameResource(string username, string displayName, CommunicationDomainResource domain)
        {
            SenderUsernameResourceData data = new SenderUsernameResourceData()
            {
                Username = username,
                DisplayName = displayName
            };

            ArmOperation<SenderUsernameResource> senderUsernameOp = await domain.GetSenderUsernameResources().CreateOrUpdateAsync(WaitUntil.Completed, username, data);
            SenderUsernameResource senderUsername = senderUsernameOp.Value;
            return senderUsername;
        }

        //internal async Task<SuppressionListResource> CreateDefaultSuppressionListResource(CommunicationDomainResource domain, string listName)
        //{
        //    var id = Recording.Random.NewGuid().ToString();

        //    SuppressionListResourceData data = new SuppressionListResourceData
        //    {
        //         ListName = listName
        //    };

        //    ArmOperation<SuppressionListResource> suppressionListOp =
        //        await domain.GetSuppressionListResources().CreateOrUpdateAsync(WaitUntil.Completed, id, data);
        //    SuppressionListResource suppressionList = suppressionListOp.Value;
        //    return suppressionList;
        //}

        //internal async Task<SuppressionListAddressResource> CreateDefaultSuppressionListAddressResource(
        //    SuppressionListResource suppressionList,
        //    string email,
        //    string firstName = default,
        //    string lastName = default,
        //    string notes = default)
        //{
        //    var id = Recording.Random.NewGuid().ToString();

        //    SuppressionListAddressResourceData data = new SuppressionListAddressResourceData
        //    {
        //        Email = email,
        //        FirstName = firstName,
        //        LastName = lastName,
        //        Notes = notes
        //    };

        //    ArmOperation<SuppressionListAddressResource> suppressionListAddressOp =
        //        await suppressionList.GetSuppressionListAddressResources().CreateOrUpdateAsync(WaitUntil.Completed, id, data);
        //    SuppressionListAddressResource suppressionListAddress = suppressionListAddressOp.Value;
        //    return suppressionListAddress;
        //}

        private void IgnoreTestInLiveMode()
        {
            if (Mode == RecordedTestMode.Live)
            {
                Assert.Ignore();
            }
        }
    }
}
