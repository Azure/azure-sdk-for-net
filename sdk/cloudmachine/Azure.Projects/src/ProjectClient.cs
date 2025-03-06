// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Data.AppConfiguration;
using Azure.Identity;

namespace Azure.Projects;

/// <summary>
/// The project client.
/// </summary>
public partial class ProjectClient : ConnectionProvider
{
    private readonly ConfigurationClient _config;

    /// <summary>
    /// The project ID.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Id { get; }

    private readonly TokenCredential Credential = BuildCredential(default);

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectClient"/> class for mocking purposes..
    /// </summary>
    public ProjectClient()
    {
        Id = ReadOrCreateProjectId();
        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
        _config = new(new Uri($"https://{Id}.azconfig.io"), Credential);
    }

    /// <summary>
    /// Gets the messaging services.
    /// </summary>
    public MessagingServices Messaging { get; }

    /// <summary>
    /// Gets the storage services.
    /// </summary>
    public StorageServices Storage { get; }

    private static TokenCredential BuildCredential(TokenCredential credential)
    {
        if (credential == default)
        {
            // This environment variable is set by the Project App Service feature during provisioning.
            credential = Environment.GetEnvironmentVariable("CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID") switch
            {
                string clientId when !string.IsNullOrEmpty(clientId) => new ManagedIdentityCredential(clientId),
                _ => new ChainedTokenCredential(new AzureCliCredential(), new AzureDeveloperCliCredential())
            };
        }

        return credential;
    }
}
