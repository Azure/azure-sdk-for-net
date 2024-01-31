// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public class TestComponentFactory : AzureComponentFactory
    {
        private readonly AzureComponentFactory _factory;
        private readonly TokenCredential _tokenCredential;

        public TestComponentFactory(AzureComponentFactory factory, TokenCredential tokenCredential)
        {
            _factory = factory;
            _tokenCredential = tokenCredential;
        }

        public override TokenCredential CreateTokenCredential(IConfiguration configuration)
        {
            return _tokenCredential != null ? _tokenCredential : _factory.CreateTokenCredential(configuration);
        }

        public override object CreateClientOptions(Type optionsType, object serviceVersion, IConfiguration configuration)
            => _factory.CreateClientOptions(optionsType, serviceVersion, configuration);

        public override object CreateClient(Type clientType, IConfiguration configuration, TokenCredential credential, object clientOptions)
            => _factory.CreateClient(clientType, configuration, credential, clientOptions);
    }
}
