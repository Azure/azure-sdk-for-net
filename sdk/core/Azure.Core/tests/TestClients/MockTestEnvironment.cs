// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Core.Tests
{
    internal class MockTestEnvironment : TestEnvironment
    {
        public static MockTestEnvironment Instance { get; } = new MockTestEnvironment();
        public string RecordedValue => GetRecordedVariable("RECORDED");
        public string NotRecordedValue => GetVariable("NOTRECORDED");

        public string Base64Secret => GetRecordedVariable("Base64Secret", option => option.IsSecret(SanitizedValue.Base64));
        public string DefaultSecret => GetRecordedVariable("DefaultSecret", option => option.IsSecret(SanitizedValue.Default));
        public string CustomSecret => GetRecordedVariable("CustomSecret", option => option.IsSecret("Custom"));
        public string MissingOptionalSecret => GetRecordedOptionalVariable("MissingOptionalSecret", option => option.IsSecret("INVALID"));
        public string ConnectionStringWithSecret => GetRecordedVariable("ConnectionStringWithSecret", option => option.HasSecretConnectionStringParameter("key"));
    }
}
