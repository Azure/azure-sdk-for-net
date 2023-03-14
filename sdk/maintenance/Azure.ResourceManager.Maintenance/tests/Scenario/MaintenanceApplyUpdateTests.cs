using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Maintenance.Tests.Scenario
{
    public sealed class MaintenanceApplyUpdateTests : MaintenanceManagementTestBase
    {
        private SubscriptionResource _subscription;

        public MaintenanceApplyUpdateTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
        }
    }
}
