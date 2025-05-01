// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;
using Azure.Data.AppConfiguration;

namespace Azure.Projects;

internal class AppConfigConnectionProvider : ClientConnectionProvider
{
    private readonly ConfigurationClient _config;
    private readonly ClientConnectionCollection _connectionCache = new();
    private readonly TokenCredential _credential;

    public AppConfigConnectionProvider(Uri endpoint, TokenCredential credential) : base(maxCacheSize: 100)
    {
        _credential = credential;
        _config = new(endpoint, _credential);
    }

    public override ClientConnection GetConnection(string connectionId)
    {
        if (_connectionCache.Contains(connectionId))
        {
            return _connectionCache[connectionId];
        }

        if (_config != null)
        {
            ConfigurationSetting setting = _config.GetConfigurationSetting(connectionId);
            string value = setting.Value;
            ClientConnection connetion = new(connectionId, value, _credential, CredentialKind.TokenCredential);
            _connectionCache.Add(connetion);
            return connetion;
        }

        throw new Exception("Connection not found");
    }

    public override IEnumerable<ClientConnection> GetAllConnections()
    {
        throw new NotImplementedException();
    }
}
