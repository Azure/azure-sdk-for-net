// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.EnergyServices.Tests.Infrastructure
{
    public class EnergyServicesClientLiveTestBase : RecordedTestBase<EnergyServicesManagementTestEnvironment>
    {
        public EnergyServicesClientLiveTestBase(bool isAsync) : base(isAsync)
        {
        }

        /*public new EnergyServicesRestOperations GetEnergyServicesClient(Energy options = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            options ??= new FarmBeatsClientOptions();

            return InstrumentClient(new FarmersClient(endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
        }*/
    }
}
