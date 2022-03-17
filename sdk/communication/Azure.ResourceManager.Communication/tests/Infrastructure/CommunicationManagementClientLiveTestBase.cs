// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Communication.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class CommunicationManagementClientLiveTestBase : ManagementRecordedTestBase<CommunicationManagementTestEnvironment>
    {
        public string ResourceGroupPrefix { get; private set; }
        public string ResourceLocation { get; private set; }
        public string ResourceDataLocation { get; private set; }

        public ArmClient ArmClient { get; set; }

        protected CommunicationManagementClientLiveTestBase(bool isAsync)
            : base(isAsync)
        {
            Init();
        }

        private void Init()
        {
            ResourceGroupPrefix = "Communication-RG-";
            ResourceLocation = "global";
            ResourceDataLocation = "UnitedStates";
            //Sanitizer = new CommunicationManagementRecordedTestSanitizer();
        }

        protected CommunicationManagementClientLiveTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
            Init();
        }

        internal async Task<CommunicationServiceResource> CreateDefaultCommunicationServices(string communicationServiceName, ResourceGroupResource _resourceGroup)
        {
            CommunicationServiceData data = new CommunicationServiceData()
            {
                Location = ResourceLocation,
                DataLocation = ResourceDataLocation,
            };
            var communicationServiceLro = await _resourceGroup.GetCommunicationServices().CreateOrUpdateAsync(WaitUntil.Completed, communicationServiceName, data);
            return communicationServiceLro.Value;
        }
    }
}
