// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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
    private readonly TokenCredential _credential = BuildCredential(default);

    /// <summary>
    /// The project ID.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ProjectId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectClient"/>.
    /// </summary>
    public ProjectClient()
    {
        // TODO: should it ever create?
        ProjectId = ReadOrCreateProjectId();

        _config = new(new Uri($"https://{ProjectId}.azconfig.io"), _credential);

        Messaging = new MessagingServices(this);
        Storage = new StorageServices(this);
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
