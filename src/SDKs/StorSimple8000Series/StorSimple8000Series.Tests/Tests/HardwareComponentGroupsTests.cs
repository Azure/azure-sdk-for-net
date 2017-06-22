using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Threading;
using System.Linq.Expressions;
using Xunit;
using Xunit.Sdk;
using Xunit.Abstractions;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Rest.Azure.OData;

namespace StorSimple8000Series.Tests
{
    public class HardwareComponentGroupsTests : StorSimpleTestBase
    {
        public HardwareComponentGroupsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestDeviceHardwareComponents()
        {
            //checking for prerequisites
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var deviceName = device.Name;

            try
            {
                //Get hardware component groups
                var hardwareComponentGroups = GetHardwareComponentGroups(deviceName);

                //Change controller power state
                ChangeControllerPowerState(deviceName, "Controller0Components", ControllerId.Controller0, ControllerPowerStateAction.Start);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        /// <summary>
        /// List hardware component groups on the device.
        /// </summary>
        private IEnumerable<HardwareComponentGroup> GetHardwareComponentGroups(string deviceName)
        {
            var hardwareComponents = this.Client.HardwareComponentGroups.ListByDevice(
                deviceName,
                this.ResourceGroupName,
                this.ManagerName);

            return hardwareComponents;
        }

        /// <summary>
        /// Changes the power state of the controller.
        /// </summary>
        private void ChangeControllerPowerState(string deviceName, string hardwareComponentGroupName,
        ControllerId activeController, ControllerPowerStateAction controllerAction)
        {
            ControllerPowerStateChangeRequest powerChangeRequest = new ControllerPowerStateChangeRequest();
            powerChangeRequest.ActiveController = activeController;
            powerChangeRequest.Controller0State = ControllerStatus.Ok;
            powerChangeRequest.Controller1State = ControllerStatus.NotPresent;
            powerChangeRequest.Action = controllerAction;

            this.Client.HardwareComponentGroups.ChangeControllerPowerState(
                deviceName,
                hardwareComponentGroupName,
                powerChangeRequest,
                this.ResourceGroupName,
                this.ManagerName);
        }
    }
}
