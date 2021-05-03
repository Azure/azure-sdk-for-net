// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    /// <summary>
    /// A service client test environment.
    /// </summary>
    /// <seealso cref="TestEnvironment"/>
    public class ServiceClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the ServiceClientTestEnvironment class.
        /// </summary>
        public ServiceClientTestEnvironment()
        { }

        /// <summary>
        /// ADU account identifier
        /// </summary>
        public string AccountEndpoint => GetRecordedVariable("DEVICEUPDATE_ACCOUNT_ENDPOINT");

        /// <summary>
        /// ADU account instance identifier
        /// </summary>
        public string InstanceId => GetRecordedVariable("DEVICEUPDATE_INSTANCE_ID");

        /// <summary>
        /// Device manufacturers
        /// </summary>
        public string Provider => "Contoso";

        /// <summary>
        /// Device model
        /// </summary>
        public string Model => "Virtual-Machine";

        /// <summary>
        /// Imported update version
        /// </summary>
        public string Version => GetRecordedVariable("DEVICEUPDATE_UPDATE_VERSION");

        /// <summary>
        /// Job for the update import
        /// </summary>
        public string OperationId => GetRecordedVariable("DEVICEUPDATE_UPDATE_OPERATION");

        /// <summary>
        /// Device identity where update was deployed
        /// </summary>
        public string DeviceId => GetRecordedVariable("DEVICEUPDATE_DEVICE_ID");

        /// <summary>
        /// Device class identity
        /// </summary>
        public string DeviceClassId => "b83e3c87fbf98063c20c3269f1c9e58d255906dd";

        /// <summary>
        /// Deployment identity used for the device update deployment
        /// </summary>
        public string DeploymentId => GetRecordedVariable("DEVICEUPDATE_DEPLOYMENT_ID");
    }
}
