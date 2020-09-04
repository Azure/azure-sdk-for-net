// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests.Samples
{
#pragma warning disable SA1649 // File name should match first type name
    public class SchemaRegistryReadmeSnippets : SamplesBase<SchemaRegistryClientTestEnvironment>
#pragma warning restore SA1649 // File name should match first type name
    {
        [Test]
        public void CreateSchemaRegistryClient()
        {
            var endpoint = TestEnvironment.SchemaRegistryUri;
            var credentials = TestEnvironment.Credential;

            #region Snippet:CreateSchemaRegistryClient
            //@@ string endpoint = "<event_hubs_namespace_hostname>";
            //@@ var credentials = new ClientSecretCredential(
            //@@     "<tenant_id>",
            //@@     "<client_id>",
            //@@     "<client_secret>"
            //@@ );
            var client = new SchemaRegistryClient(endpoint, credentials);
            #endregion
        }
    }
}
