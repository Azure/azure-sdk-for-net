using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the tests for trigger APIs
    /// </summary>
    public class TriggerTests : DataBoxEdgeTestBase
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
            string localShareId = null, iotRoleId = null;

            // Get an iot role by name
            var iotRole = Client.Roles.Get(TestConstants.EdgeResourceName, "iot-1", TestConstants.DefaultResourceGroupName);
            if (iotRole != null)
            {
                iotRoleId = iotRole.Id;
            }
            var localShare = Client.Shares.Get(TestConstants.EdgeResourceName, "localshare", TestConstants.DefaultResourceGroupName);
            if (localShare != null)
            {
                localShareId = localShare.Id;
            }

            Trigger fileTrigger = TestUtilities.GetFileTriggerObject(localShareId, iotRoleId);

            // Create a file event trigger
            Client.Triggers.CreateOrUpdate(TestConstants.EdgeResourceName, "trigger-fileEventTrigger", fileTrigger, TestConstants.DefaultResourceGroupName);

            // Create a periodic timer event trigger

            Trigger periodicTrigger = TestUtilities.GetPeriodicTriggerObject(iotRoleId);
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

