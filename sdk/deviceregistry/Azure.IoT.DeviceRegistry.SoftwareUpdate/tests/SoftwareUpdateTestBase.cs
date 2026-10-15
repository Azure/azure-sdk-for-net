// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.IoT.DeviceRegistry._SoftwareUpdate.Tests
{
    public abstract class SoftwareUpdateTestBase : RecordedTestBase<SoftwareUpdateTestEnvironment>
    {
        private const string ServiceHostPattern = @"https://[^/]+\.api\.(?:dev\.)?adu\.microsoft\.com";
        private const string OperationPathPattern = @"/updates/operations/(?<operationId>[0-9a-fA-F-]{36})";
        private const string SanitizedOperationId = "00000000-0000-0000-0000-000000000000";

        protected SoftwareUpdateTestBase(bool isAsync) : base(isAsync)
        {
            ReplacementHost = new Uri(SoftwareUpdateTestEnvironment.SanitizedEndpoint).Host;
            SanitizedHeaders.Add("traceparent");
            SanitizedHeaders.Add("x-ms-correlation-request-id");
            SanitizedHeaders.Add("ETag");

            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = ServiceHostPattern,
                Value = SoftwareUpdateTestEnvironment.SanitizedEndpoint
            });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = OperationPathPattern,
                GroupForReplace = "operationId",
                Value = SanitizedOperationId
            });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("operation-location")
            {
                Regex = ServiceHostPattern,
                Value = SoftwareUpdateTestEnvironment.SanitizedEndpoint
            });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("operation-location")
            {
                Regex = OperationPathPattern,
                GroupForReplace = "operationId",
                Value = SanitizedOperationId
            });
            UriRegexSanitizers.Add(new UriRegexSanitizer(OperationPathPattern)
            {
                GroupForReplace = "operationId",
                Value = SanitizedOperationId
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..resourceLocation")
            {
                Regex = ServiceHostPattern,
                Value = SoftwareUpdateTestEnvironment.SanitizedEndpoint
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..operationId")
            {
                Value = SanitizedOperationId
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..traceId")
            {
                Value = "Sanitized"
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..etag")
            {
                Value = "Sanitized"
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..importManifest.url")
            {
                Value = SoftwareUpdateTestEnvironment.SanitizedManifestUrl
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..files[*].url")
            {
                Value = SoftwareUpdateTestEnvironment.SanitizedPayloadUrl
            });
        }

        protected SoftwareUpdate CreateSoftwareUpdateClient()
        {
            var options = InstrumentClientOptions(new DeviceRegistrySoftwareUpdateClientOptions());
            var client = new DeviceRegistrySoftwareUpdateClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.Credential,
                options);
            return InstrumentClient(client).GetSoftwareUpdateClient();
        }

        protected DeviceClasses CreateDeviceClassesClient()
        {
            var options = InstrumentClientOptions(new DeviceRegistrySoftwareUpdateClientOptions());
            var client = new DeviceRegistrySoftwareUpdateClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.Credential,
                options);
            return InstrumentClient(client).GetDeviceClassesClient();
        }
    }
}