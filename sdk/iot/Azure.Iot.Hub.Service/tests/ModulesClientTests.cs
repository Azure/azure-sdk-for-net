// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;
using FluentAssertions;
using Microsoft.Azure.Devices.Client;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
{
    /// <summary>
    /// Test all APIs of the ModulesClient.
    /// </summary>
    /// <remarks>
    /// All API calls are wrapped in a try catch block so we can clean up resources regardless of the test outcome.
    /// </remarks>
    public class ModulesClientTests : E2eTestBase
    {
        private const int BULK_MODULE_COUNT = 10;
        private readonly TimeSpan _queryMaxWaitTime = TimeSpan.FromSeconds(30);
        private readonly TimeSpan _queryRetryInterval = TimeSpan.FromSeconds(2);

        public ModulesClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Test basic lifecycle of a Device Identity.
        /// This test includes CRUD operations only.
        /// </summary>
        [Test]
        public async Task ModulesClient_IdentityLifecycle()
        {
            string testDeviceId = $"IdentityLifecycleDevice{GetRandom()}";
            string testModuleId = $"IdentityLifecycleModule{GetRandom()}";

            DeviceIdentity device = null;
            ModuleIdentity module = null;
            IotHubServiceClient client = GetClient();

            try
            {
                // Create a device to house the module
                device = (await client.Devices
                    .CreateOrUpdateIdentityAsync(
                        new DeviceIdentity
                        {
                            DeviceId = testDeviceId
                        })
                    .ConfigureAwait(false))
                    .Value;

                // Create a module on the device
                Response<ModuleIdentity> createResponse = await client.Modules.CreateOrUpdateIdentityAsync(
                    new ModuleIdentity
                    {
                        DeviceId = testDeviceId,
                        ModuleId = testModuleId
                    }).ConfigureAwait(false);

                module = createResponse.Value;

                module.DeviceId.Should().Be(testDeviceId);
                module.ModuleId.Should().Be(testModuleId);

                // Get device
                // Get the device and compare ETag values (should remain unchanged);
                Response<ModuleIdentity> getResponse = await client.Modules.GetIdentityAsync(testDeviceId, testModuleId).ConfigureAwait(false);

                getResponse.Value.Etag.Should().BeEquivalentTo(module.Etag, "ETag value should not have changed.");

                module = getResponse.Value;

                // Update a module
                string managedByValue = "SomeChangedValue";
                module.ManagedBy = managedByValue;

                // TODO: (azabbasi) We should leave the IfMatchPrecondition to be the default value once we know more about the fix.
                Response<ModuleIdentity> updateResponse = await client.Modules.CreateOrUpdateIdentityAsync(module, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);

                updateResponse.Value.ManagedBy.Should().Be(managedByValue, "Module should have changed its managedBy value");

                // Delete the device
                // Deleting the device happens in the finally block as cleanup.
            }
            finally
            {
                await CleanupAsync(client, device).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Test the logic for ETag if-match header
        /// </summary>
        [Test]
        public async Task ModulesClient_UpdateDevice_EtagDoesNotMatch()
        {
            string testDeviceId = $"UpdateWithETag{GetRandom()}";
            string testModuleId = $"UpdateWithETag{GetRandom()}";

            DeviceIdentity device = null;
            ModuleIdentity module = null;
            IotHubServiceClient client = GetClient();

            try
            {
                // Create a device
                device = (await client.Devices.CreateOrUpdateIdentityAsync(
                    new DeviceIdentity
                    {
                        DeviceId = testDeviceId
                    }).ConfigureAwait(false)).Value;

                // Create a module on that device
                module = (await client.Modules.CreateOrUpdateIdentityAsync(
                    new ModuleIdentity
                    {
                        DeviceId = testDeviceId,
                        ModuleId = testModuleId
                    }).ConfigureAwait(false)).Value;

                // Update the module to get a new ETag value.
                string managedByValue = "SomeChangedValue";
                module.ManagedBy = managedByValue;

                ModuleIdentity updatedModule = (await client.Modules.CreateOrUpdateIdentityAsync(module).ConfigureAwait(false)).Value;

                Assert.AreNotEqual(updatedModule.Etag, module.Etag, "ETag should have been updated.");

                // Perform another update using the old device object to verify precondition fails.
                string anotherManagedByValue = "SomeOtherChangedValue";
                module.ManagedBy = anotherManagedByValue;
                try
                {
                    await client.Modules.CreateOrUpdateIdentityAsync(module, IfMatchPrecondition.IfMatch).ConfigureAwait(false);
                    Assert.Fail($"Update call with outdated ETag should fail with 412 (PreconditionFailed)");
                }
                // We will catch the exception and verify status is 412 (PreconditionfFailed)
                catch (RequestFailedException ex)
                {
                    Assert.AreEqual(412, ex.Status, $"Expected the update to fail with http status code 412 (PreconditionFailed)");
                }

                // Perform the same update and ignore the ETag value by providing UnconditionalIfMatch precondition
                ModuleIdentity forcefullyUpdatedModule = (await client.Modules.CreateOrUpdateIdentityAsync(module, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false)).Value;
                forcefullyUpdatedModule.ManagedBy.Should().Be(anotherManagedByValue);
            }
            finally
            {
                await CleanupAsync(client, device).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Test basic operations of a Device Twin.
        /// </summary>
        [Test]
        public async Task ModulesClient_DeviceTwinLifecycle()
        {
            string testDeviceId = $"TwinLifecycleDevice{GetRandom()}";
            string testModuleId = $"TwinLifecycleModule{GetRandom()}";

            DeviceIdentity device = null;
            ModuleIdentity module = null;

            IotHubServiceClient client = GetClient();

            try
            {
                // Create a device
                device = (await client.Devices.CreateOrUpdateIdentityAsync(
                    new DeviceIdentity
                    {
                        DeviceId = testDeviceId
                    }).ConfigureAwait(false)).Value;

                // Create a module on that device. Note that this implicitly creates the module twin
                module = (await client.Modules.CreateOrUpdateIdentityAsync(
                    new ModuleIdentity
                    {
                        DeviceId = testDeviceId,
                        ModuleId = testModuleId
                    }).ConfigureAwait(false)).Value;

                // Get the module twin
                TwinData moduleTwin = (await client.Modules.GetTwinAsync(testDeviceId, testModuleId).ConfigureAwait(false)).Value;

                moduleTwin.ModuleId.Should().BeEquivalentTo(testModuleId, "ModuleId on the Twin should match that of the module identity.");

                // Update device twin
                string propName = "username";
                string propValue = "userA";
                moduleTwin.Properties.Desired.Add(new KeyValuePair<string, object>(propName, propValue));

                // TODO: (azabbasi) We should leave the IfMatchPrecondition to be the default value once we know more about the fix.
                Response<TwinData> updateResponse = await client.Modules.UpdateTwinAsync(moduleTwin, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);

                updateResponse.Value.Properties.Desired.Where(p => p.Key == propName).First().Value.Should().Be(propValue, "Desired property value is incorrect.");

                // Delete the module
                // Deleting the module happens in the finally block as cleanup.
            }
            finally
            {
                await CleanupAsync(client, device).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Test that ETag and If-Match headers work as expected
        /// </summary>
        [Test]
        public async Task ModulesClient_UpdateModuleTwin_EtagDoesNotMatch()
        {
            string testDeviceId = $"TwinLifecycleDevice{GetRandom()}";
            string testModuleId = $"TwinLifecycleModule{GetRandom()}";

            DeviceIdentity device = null;
            ModuleIdentity module = null;

            IotHubServiceClient client = GetClient();

            try
            {
                // Create a device
                device = (await client.Devices.CreateOrUpdateIdentityAsync(
                    new DeviceIdentity
                    {
                        DeviceId = testDeviceId
                    }).ConfigureAwait(false)).Value;

                // Create a module on that device. Note that this implicitly creates the module twin
                module = (await client.Modules.CreateOrUpdateIdentityAsync(
                    new ModuleIdentity
                    {
                        DeviceId = testDeviceId,
                        ModuleId = testModuleId
                    }).ConfigureAwait(false)).Value;

                // Get the module twin
                TwinData moduleTwin = (await client.Modules.GetTwinAsync(testDeviceId, testModuleId).ConfigureAwait(false)).Value;

                moduleTwin.ModuleId.Should().BeEquivalentTo(testModuleId, "ModuleId on the Twin should match that of the module identity.");

                // Update device twin
                string propName = "username";
                string propValue = "userA";
                moduleTwin.Properties.Desired.Add(new KeyValuePair<string, object>(propName, propValue));

                // TODO: (azabbasi) We should leave the IfMatchPrecondition to be the default value once we know more about the fix.
                Response<TwinData> updateResponse = await client.Modules.UpdateTwinAsync(moduleTwin, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);

                updateResponse.Value.Properties.Desired.Where(p => p.Key == propName).First().Value.Should().Be(propValue, "Desired property value is incorrect.");

                // Perform another update using the old device object to verify precondition fails.
                try
                {
                    // Try to update the twin with the previously up-to-date twin
                    await client.Modules.UpdateTwinAsync(moduleTwin, IfMatchPrecondition.IfMatch).ConfigureAwait(false);
                    Assert.Fail($"Update call with outdated ETag should fail with 412 (PreconditionFailed)");
                }
                // We will catch the exception and verify status is 412 (PreconditionfFailed)
                catch (RequestFailedException ex)
                {
                    Assert.AreEqual(412, ex.Status, $"Expected the update to fail with http status code 412 (PreconditionFailed)");
                }

                // Delete the module
                // Deleting the module happens in the finally block as cleanup.
            }
            finally
            {
                await CleanupAsync(client, device).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task ModulesClient_GetModulesOnDevice()
        {
            int moduleCount = 5;
            string testDeviceId = $"IdentityLifecycleDevice{GetRandom()}";
            string[] testModuleIds = new string[moduleCount];
            for (int i = 0; i < moduleCount; i++)
            {
                testModuleIds[i] = $"IdentityLifecycleModule{i}-{GetRandom()}";
            }

            DeviceIdentity device = null;
            IotHubServiceClient client = GetClient();

            try
            {
                // Create a device to house the modules
                device = (await client.Devices
                    .CreateOrUpdateIdentityAsync(
                        new DeviceIdentity
                        {
                            DeviceId = testDeviceId
                        })
                    .ConfigureAwait(false))
                    .Value;

                // Create the modules on the device
                for (int i = 0; i < moduleCount; i++)
                {
                    Response<ModuleIdentity> createResponse = await client.Modules.CreateOrUpdateIdentityAsync(
                    new ModuleIdentity
                    {
                        DeviceId = testDeviceId,
                        ModuleId = testModuleIds[i]
                    }).ConfigureAwait(false);
                }

                // List the modules on the test device
                IReadOnlyList<ModuleIdentity> modulesOnDevice = (await client.Modules.GetIdentitiesAsync(testDeviceId).ConfigureAwait(false)).Value;

                IEnumerable<string> moduleIdsOnDevice = modulesOnDevice
                    .ToList()
                    .Select(module => module.ModuleId);

                Assert.AreEqual(moduleCount, modulesOnDevice.Count);
                for (int i = 0; i < moduleCount; i++)
                {
                    Assert.IsTrue(moduleIdsOnDevice.Contains(testModuleIds[i]));
                }
            }
            finally
            {
                await CleanupAsync(client, device).ConfigureAwait(false);
            }
        }

        [Test]
        [Ignore("module client has no way to record/playback since it doesn't use http. As such, this test can only be run in Live mode")]
        public async Task ModulesClient_InvokeMethodOnModule()
        {
            if (!this.IsAsync)
            {
                // TODO: Tim: The module client doesn't appear to open a connection to iothub or start
                // listening for method invocations when this test is run in Sync mode. Not sure why though.
                // calls to track 1 library don't throw, but seem to silently fail
                return;
            }

            string testDeviceId = $"InvokeMethodDevice{GetRandom()}";
            string testModuleId = $"InvokeMethodModule{GetRandom()}";

            DeviceIdentity device = null;
            ModuleIdentity module = null;
            ModuleClient moduleClient = null;
            IotHubServiceClient serviceClient = GetClient();

            try
            {
                // Create a device to house the modules
                device = (await serviceClient.Devices
                    .CreateOrUpdateIdentityAsync(
                        new DeviceIdentity
                        {
                            DeviceId = testDeviceId
                        })
                    .ConfigureAwait(false))
                    .Value;

                // Create the module on the device
                module = (await serviceClient.Modules.CreateOrUpdateIdentityAsync(
                    new ModuleIdentity
                    {
                        DeviceId = testDeviceId,
                        ModuleId = testModuleId
                    }).ConfigureAwait(false)).Value;

                // Method expectations
                string expectedMethodName = "someMethodToInvoke";
                int expectedStatus = 222;
                object expectedRequestPayload = null;

                // Create module client instance to receive the method invocation
                string moduleClientConnectionString = $"HostName={GetHostName()};DeviceId={testDeviceId};ModuleId={testModuleId};SharedAccessKey={module.Authentication.SymmetricKey.PrimaryKey}";
                moduleClient = ModuleClient.CreateFromConnectionString(moduleClientConnectionString, TransportType.Mqtt_Tcp_Only);

                // These two methods are part of our track 1 device client. When the test fixture runs when isAsync = true,
                // these methods work. When isAsync = false, these methods silently don't work.
                await moduleClient.OpenAsync().ConfigureAwait(false);
                await moduleClient.SetMethodHandlerAsync(
                    expectedMethodName,
                    (methodRequest, userContext) =>
                    {
                        return Task.FromResult(new MethodResponse(expectedStatus));
                    },
                    null).ConfigureAwait(false);

                // Invoke the method on the module
                CloudToDeviceMethodRequest methodRequest = new CloudToDeviceMethodRequest()
                {
                    MethodName = expectedMethodName,
                    Payload = expectedRequestPayload,
                    ConnectTimeoutInSeconds = 5,
                    ResponseTimeoutInSeconds = 5
                };

                var methodResponse = (await serviceClient.Modules.InvokeMethodAsync(testDeviceId, testModuleId, methodRequest).ConfigureAwait(false)).Value;

                Assert.AreEqual(expectedStatus, methodResponse.Status);
            }
            finally
            {
                if (moduleClient != null)
                {
                    await moduleClient.CloseAsync().ConfigureAwait(false);
                }

                await CleanupAsync(serviceClient, device).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Test creating multiple modules on a single device
        /// </summary>
        [Test]
        public async Task ModulesClient_BulkCreation_SingleDevice()
        {
            string testDevicePrefix = $"bulkDevice";
            string testModulePrefix = $"bulkModule";

            string deviceId = $"{testDevicePrefix}{GetRandom()}";
            var deviceIdentity = new DeviceIdentity()
            {
                DeviceId = deviceId
            };

            IList<ModuleIdentity> moduleIdentities = BuildMultipleModules(deviceId, testModulePrefix, BULK_MODULE_COUNT);

            IotHubServiceClient client = GetClient();

            try
            {
                // Create single device to house these bulk modules
                await client.Devices.CreateOrUpdateIdentityAsync(deviceIdentity).ConfigureAwait(false);

                // Create modules in bulk on that device
                Response<BulkRegistryOperationResponse> createResponse = await client.Modules.CreateIdentitiesAsync(moduleIdentities).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk module creation ended with errors");
            }
            finally
            {
                await CleanupAsync(client, deviceIdentity).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Test creating multiple modules on a multiple devices
        /// </summary>
        [Test]
        public async Task ModulesClient_BulkCreation_MultipleDevices()
        {
            string testDevicePrefix = $"bulkDevice";
            string testModulePrefix = $"bulkModule";

            List<DeviceIdentity> deviceIdentities = new List<DeviceIdentity>();
            List<ModuleIdentity> moduleIdentities = new List<ModuleIdentity>();
            for (int moduleIndex = 0; moduleIndex < BULK_MODULE_COUNT; moduleIndex++)
            {
                string deviceId = $"{testDevicePrefix}{GetRandom()}";
                deviceIdentities.Add(new DeviceIdentity()
                {
                    DeviceId = deviceId
                });

                moduleIdentities.Add(new ModuleIdentity()
                {
                    DeviceId = deviceId,
                    ModuleId = $"{testModulePrefix}{GetRandom()}"
                });
            }

            IotHubServiceClient client = GetClient();

            try
            {
                // Create devices to house these bulk modules
                await client.Devices.CreateIdentitiesAsync(deviceIdentities).ConfigureAwait(false);

                // Create modules in bulk on those devices
                Response<BulkRegistryOperationResponse> createResponse = await client.Modules.CreateIdentitiesAsync(moduleIdentities).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk module creation ended with errors");
            }
            finally
            {
                await CleanupAsync(client, deviceIdentities).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Creates a device to house some modules, creates two modules, and then uses the bulk update API to update
        /// both of these modules.
        /// </summary>
        [Test]
        public async Task ModulesClient_BulkUpdate()
        {
            string testDevicePrefix = $"bulkDeviceUpdate";
            string testModulePrefix = $"bulkModuleUpdate";

            IotHubServiceClient client = GetClient();

            string deviceId = $"{testDevicePrefix}{GetRandom()}";
            var deviceIdentity = new DeviceIdentity()
            {
                DeviceId = deviceId
            };

            IList<ModuleIdentity> listOfModulesToUpdate = new List<ModuleIdentity>();

            try
            {
                // Create the device to house two modules
                await client.Devices.CreateOrUpdateIdentityAsync(deviceIdentity).ConfigureAwait(false);

                AuthenticationMechanismType initialAuthenticationType = AuthenticationMechanismType.Sas;
                AuthenticationMechanismType updatedAuthenticationType = AuthenticationMechanismType.SelfSigned;

                for (int moduleIndex = 0; moduleIndex < BULK_MODULE_COUNT; moduleIndex++)
                {
                    // Create modules on that device
                    ModuleIdentity createdModule = (await client.Modules.CreateOrUpdateIdentityAsync(
                        new ModuleIdentity
                        {
                            DeviceId = deviceId,
                            ModuleId = $"{testModulePrefix}{GetRandom()}",
                            Authentication = new AuthenticationMechanism()
                            {
                                Type = initialAuthenticationType
                            },
                        }).ConfigureAwait(false)).Value;

                    // Update the authentication field so that we can test updating this identity later
                    createdModule.Authentication = new AuthenticationMechanism()
                    {
                        Type = AuthenticationMechanismType.SelfSigned
                    };

                    listOfModulesToUpdate.Add(createdModule);
                }

                // Make the API call to update the modules.
                Response<BulkRegistryOperationResponse> updateResponse =
                    await client.Modules.UpdateIdentitiesAsync(listOfModulesToUpdate, BulkIfMatchPrecondition.Unconditional)
                    .ConfigureAwait(false);

                // TODO: (azabbasi) Once the issue with the error parsing is resolved, include the error message in the message of the assert statement.
                Assert.IsTrue(updateResponse.Value.IsSuccessful, "Bulk module update ended with errors");

                // Verify that each module successfully updated its authentication field
                foreach (ModuleIdentity module in listOfModulesToUpdate)
                {
                    var updatedModule = (await client.Modules.GetIdentityAsync(module.DeviceId, module.ModuleId).ConfigureAwait(false)).Value;
                    updatedModule.Authentication.Type.Should().Be(updatedAuthenticationType, "Module should have been updated");
                }
            }
            finally
            {
                await CleanupAsync(client, deviceIdentity).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Test bulk module creation with an expected error.
        /// All but one module are going to be brand new. One module already exists and we expect an error regarding that specific module.
        /// </summary>
        [Test]
        [Ignore("DeviceRegistryOperationError cannot be parsed since service sends integer instead of a string")]
        public async Task ModulesClient_BulkCreation_OneAlreadyExists()
        {
            string testDevicePrefix = $"bulkDeviceCreate";
            string testModulePrefix = $"bulkModuleCreate";

            IotHubServiceClient client = GetClient();

            string deviceId = $"{testDevicePrefix}{GetRandom()}";
            var deviceIdentity = new DeviceIdentity()
            {
                DeviceId = deviceId
            };

            IList<ModuleIdentity> modules = BuildMultipleModules(deviceId, testModulePrefix, BULK_MODULE_COUNT - 1);

            try
            {
                // We first create a single device to house these bulk modules.
                await client.Devices.CreateOrUpdateIdentityAsync(deviceIdentity).ConfigureAwait(false);

                // Create a single module on that device that will be used to cause a conflict later
                await client.Modules.CreateOrUpdateIdentityAsync(
                    new ModuleIdentity()
                    {
                        DeviceId = deviceId,
                        ModuleId = modules.ElementAt(0).ModuleId //Use the same module id as the first module in the bulk list
                    }).ConfigureAwait(false);

                // Create all devices
                Response<BulkRegistryOperationResponse> createResponse = await client.Modules.CreateIdentitiesAsync(modules).ConfigureAwait(false);

                // TODO: (azabbasi) Once the issue with the error parsing is resolved, include the error message in the message of the assert statement.
                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation failed with errors");
                createResponse.Value.Errors.Count.Should().Be(1);

                // Since there is exactly one error, it is safe to just look at the first one here
                var error = createResponse.Value.Errors.First();
                error.ModuleId.Should().Be(modules.ElementAt(0).ModuleId, "Error should have been tied to the moduleId that was already created");
            }
            finally
            {
                await CleanupAsync(client, deviceIdentity).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task ModulesClient_BulkCreation_ModuleWithTwin()
        {
            string testDevicePrefix = $"bulkDeviceWithTwin";
            string testModulePrefix = $"bulkModuleWithTwin";
            string userPropertyName = "user";
            string userPropertyValue = "userA";

            IotHubServiceClient client = GetClient();

            string deviceId = $"{testDevicePrefix}{GetRandom()}";
            DeviceIdentity deviceIdentity = new DeviceIdentity()
            {
                DeviceId = deviceId
            };

            IDictionary<string, object> desiredProperties = new Dictionary<string, object>
            {
                { userPropertyName, userPropertyValue }
            };

            // We will build a single device with multiple modules, and each module will have the same initial twin.
            IDictionary<ModuleIdentity, TwinData> modulesAndTwins = BuildModulesAndTwins(deviceId, testModulePrefix, BULK_MODULE_COUNT, desiredProperties);

            try
            {
                // Create device to house the modules
                await client.Devices.CreateOrUpdateIdentityAsync(deviceIdentity).ConfigureAwait(false);

                // Create the modules with an initial twin in bulk
                Response<BulkRegistryOperationResponse> createResponse = await client.Modules.CreateIdentitiesWithTwinAsync(modulesAndTwins).ConfigureAwait(false);

                // TODO: (azabbasi) Once the issue with the error parsing is resolved, include the error message in the message of the assert statement.
                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk module creation ended with errors");

                // Verify that the desired properties were set
                // For quicker test run, we will only verify the first device on the list.
                Response<TwinData> getResponse = await client.Modules.GetTwinAsync(modulesAndTwins.Keys.First().DeviceId, modulesAndTwins.Keys.First().ModuleId).ConfigureAwait(false);
                getResponse.Value.Properties.Desired[userPropertyName].Should().Be(userPropertyValue);
            }
            finally
            {
                await CleanupAsync(client, deviceIdentity).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Test query by getting all twins.
        /// For the purpose of this test, we will create a single device with multiple modules
        /// and list all twins and verify the query returns everything expected.
        /// </summary>
        [Test]
        public async Task ModulesClient_Query_GetTwins()
        {
            string testDevicePrefix = $"bulkDevice";
            string testModulePrefix = $"bulkModule";

            IotHubServiceClient client = GetClient();

            string deviceId = $"{testDevicePrefix}{GetRandom()}";
            DeviceIdentity deviceIdentity = new DeviceIdentity()
            {
                DeviceId = deviceId
            };

            IList<ModuleIdentity> moduleIdentities = BuildMultipleModules(deviceId, testModulePrefix, BULK_MODULE_COUNT);

            try
            {
                // Create the device to house all these modules
                await client.Devices.CreateOrUpdateIdentityAsync(deviceIdentity).ConfigureAwait(false);

                // Create the modules in bulk so they can be queried later
                Response<BulkRegistryOperationResponse> createResponse = await client.Modules.CreateIdentitiesAsync(moduleIdentities).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk module creation ended with errors");

                // We will retry the operation since it can take some time for the query to match what was recently created.
                int matchesFound = 0;
                DateTimeOffset startTime = DateTime.UtcNow;

                while (DateTime.UtcNow - startTime < _queryMaxWaitTime)
                {
                    matchesFound = 0;
                    AsyncPageable<TwinData> twins = client.Modules.GetTwinsAsync();

                    // We will verify we have twins for all recently created devices.
                    await foreach (TwinData twin in twins)
                    {
                        if (moduleIdentities.Any(d => d.DeviceId.Equals(twin.DeviceId, StringComparison.OrdinalIgnoreCase)))
                        {
                            matchesFound++;
                        }
                    }

                    if (matchesFound == BULK_MODULE_COUNT)
                    {
                        break;
                    }

                    await Task.Delay(_queryRetryInterval).ConfigureAwait(false);
                }

                matchesFound.Should().Be(BULK_MODULE_COUNT, "Timed out waiting for all the bulk created modules to be query-able." +
                    " Number of matching modules must be equal to the number of recently created modules.");
            }
            finally
            {
                await CleanupAsync(client, deviceIdentity).ConfigureAwait(false);
            }
        }

        private IDictionary<ModuleIdentity, TwinData> BuildModulesAndTwins(string deviceId, string testModulePrefix, int deviceCount, IDictionary<string, object> desiredProperties)
        {
            IList<ModuleIdentity> modules = BuildMultipleModules(deviceId, testModulePrefix, deviceCount);
            IDictionary<ModuleIdentity, TwinData> modulesAndTwins = new Dictionary<ModuleIdentity, TwinData>();

            foreach (ModuleIdentity module in modules)
            {
                var twinProperties = new TwinProperties();

                foreach (var desiredProperty in desiredProperties)
                {
                    twinProperties.Desired.Add(desiredProperty);
                }

                modulesAndTwins.Add(module, new TwinData { Properties = twinProperties });
            }

            return modulesAndTwins;
        }

        /// <summary>
        /// Builds a list of module identities that all belong to the provided device
        /// </summary>
        private IList<ModuleIdentity> BuildMultipleModules(string deviceId, string testModulePrefix, int deviceCount)
        {
            List<ModuleIdentity> moduleList = new List<ModuleIdentity>();

            for (int i = 0; i < deviceCount; i++)
            {
                moduleList.Add(new ModuleIdentity
                {
                    DeviceId = deviceId,
                    ModuleId = $"{testModulePrefix}{GetRandom()}"
                });
            }

            return moduleList;
        }

        private async Task CleanupAsync(IotHubServiceClient client, IEnumerable<DeviceIdentity> devices)
        {
            try
            {
                if (devices != null && devices.Any())
                {
                    await client.Devices.DeleteIdentitiesAsync(devices, BulkIfMatchPrecondition.Unconditional).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test clean up failed: {ex.Message}");
            }
        }

        private async Task CleanupAsync(IotHubServiceClient client, DeviceIdentity device)
        {
            // cleanup
            try
            {
                if (device != null)
                {
                    await client.Devices.DeleteIdentityAsync(device, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test clean up failed: {ex.Message}");
            }
        }
    }
}
