// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Provides different ways of authenticating to a <see cref="DataFeedSource"/> for data ingestion when the
    /// default authentication method does not suffice. The supported credentials are:
    /// <list type="bullet">
    ///   <item><see cref="DataLakeSharedKeyCredentialEntity"/></item>
    ///   <item><see cref="ServicePrincipalCredentialEntity"/></item>
    ///   <item><see cref="ServicePrincipalInKeyVaultCredentialEntity"/></item>
    ///   <item><see cref="SqlConnectionStringCredentialEntity"/></item>
    /// </list>
    /// </summary>
    [CodeGenModel("DataSourceCredential")]
    public abstract partial class DataSourceCredentialEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceCredentialEntity"/> class.
        /// </summary>
        internal DataSourceCredentialEntity(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// The credential kind.
        /// </summary>
        [CodeGenMember("DataSourceCredentialType")]
        public DataSourceCredentialKind CredentialKind { get; internal set; }

        /// <summary>
        /// The unique identifier of this <see cref="DataSourceCredentialEntity"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c>, it means this instance has not been sent to the service to be created yet. This property
        /// will be set by the service after creation.
        /// </remarks>
        [CodeGenMember("DataSourceCredentialId")]
        public string Id { get; }

        /// <summary>
        /// A custom name for this <see cref="DataSourceCredentialEntity"/> to be displayed on the web portal. Data feed
        /// names must be unique across the same Metris Advisor resource.
        /// </summary>
        [CodeGenMember("DataSourceCredentialName")]
        public string Name { get; set; }

        /// <summary>
        /// A description of this <see cref="DataSourceCredentialEntity"/>. Defaults to an empty string.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        [CodeGenMember("DataSourceCredentialDescription")]
        public string Description { get; set; }

        internal DataSourceCredentialPatch GetPatchModel()
        {
            DataSourceCredentialPatch patch = this switch
            {
                DataLakeSharedKeyCredentialEntity c => new DataLakeGen2SharedKeyCredentialPatch()
                {
                    Parameters = new() { AccountKey = c.AccountKey }
                },
                ServicePrincipalCredentialEntity c => new ServicePrincipalCredentialPatch()
                {
                    Parameters = new() { ClientId = c.ClientId, ClientSecret = c.ClientSecret, TenantId = c.TenantId }
                },
                ServicePrincipalInKeyVaultCredentialEntity c => new ServicePrincipalInKVCredentialPatch()
                {
                    Parameters = new()
                    {
                        KeyVaultEndpoint = c.Endpoint.AbsoluteUri,
                        KeyVaultClientId = c.KeyVaultClientId,
                        KeyVaultClientSecret = c.KeyVaultClientSecret,
                        TenantId = c.TenantId,
                        ServicePrincipalIdNameInKV = c.SecretNameForClientId,
                        ServicePrincipalSecretNameInKV = c.SecretNameForClientSecret
                    }
                },
                SqlConnectionStringCredentialEntity c => new AzureSQLConnectionStringCredentialPatch()
                {
                    Parameters = new() { ConnectionString = c.ConnectionString }
                },
                _ => new DataSourceCredentialPatch()
            };

            patch.DataSourceCredentialType = CredentialKind;
            patch.DataSourceCredentialName = Name;
            patch.DataSourceCredentialDescription = Description;

            return patch;
        }

        internal static DataSourceCredentialEntity DeserializeDataSourceCredentialEntity(JsonElement element)
        {
            if (element.TryGetProperty("dataSourceCredentialType", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "AzureSQLConnectionString":
                        return SqlConnectionStringCredentialEntity.DeserializeSqlConnectionStringCredentialEntity(element);
                    case "DataLakeGen2SharedKey":
                        return DataLakeSharedKeyCredentialEntity.DeserializeDataLakeSharedKeyCredentialEntity(element);
                    case "ServicePrincipal":
                        return ServicePrincipalCredentialEntity.DeserializeServicePrincipalCredentialEntity(element);
                    case "ServicePrincipalInKV":
                        return ServicePrincipalInKeyVaultCredentialEntity.DeserializeServicePrincipalInKeyVaultCredentialEntity(element);
                }
            }
            DataSourceCredentialKind dataSourceCredentialType = default;
            string dataSourceCredentialId = default;
            string dataSourceCredentialName = default;
            string dataSourceCredentialDescription = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("dataSourceCredentialType"))
                {
                    dataSourceCredentialType = new DataSourceCredentialKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("dataSourceCredentialId"))
                {
                    dataSourceCredentialId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dataSourceCredentialName"))
                {
                    dataSourceCredentialName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dataSourceCredentialDescription"))
                {
                    dataSourceCredentialDescription = property.Value.GetString();
                    continue;
                }
            }
            return new UnknownCredentialEntity(dataSourceCredentialType, dataSourceCredentialId, dataSourceCredentialName, dataSourceCredentialDescription);
        }

        private class UnknownCredentialEntity : DataSourceCredentialEntity
        {
            public UnknownCredentialEntity(DataSourceCredentialKind dataSourceCredentialType, string id, string name, string description)
                : base(dataSourceCredentialType, id, name, description)
            {
            }
        }
    }
}
