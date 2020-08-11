using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    /// <summary>
    /// Contains the tests for trigger APIs
    /// </summary>
    public class  TriggerTests : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Creates an instance to test share APIs
        /// </summary>
        public TriggerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests share management APIs
        /// </summary>
        [Fact]
        public void Test_TriggerOperations()
        {
            Trigger fileTrigger = TestUtilities.GetFileTriggerObject();
                
            // Create a file event trigger
            Client.Triggers.CreateOrUpdate(TestConstants.EdgeResourceName, "trigger-fileEventTrigger", fileTrigger, TestConstants.DefaultResourceGroupName);

            // Create a periodic timer event trigger

            Trigger periodicTrigger = TestUtilities.GetPeriodicTriggerObject();
            Client.Triggers.CreateOrUpdate(TestConstants.EdgeResourceName, "trigger-periodicTrigger", periodicTrigger, TestConstants.DefaultResourceGroupName);
           
            // Get a trigger by name
            var trigger = Client.Triggers.Get(TestConstants.EdgeResourceName, "trigger-periodicTrigger", TestConstants.DefaultResourceGroupName);

            string continuationToken = null;
            // List all triggers in the device
            var triggers = TestUtilities.ListTriggers(Client, TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, out continuationToken);

            // Delete a share
            Client.Triggers.Delete(TestConstants.EdgeResourceName, "trigger-periodicTrigger", TestConstants.DefaultResourceGroupName);
        }
        #endregion Test Methods

    }
}

