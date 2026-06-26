// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ActiveDirectoryConfigProperties : IJsonModel<ActiveDirectoryConfigProperties>, IPersistableModel<ActiveDirectoryConfigProperties>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public ActiveDirectoryConfigProperties(string site, string domain, NetAppSecretPassword secretPassword)
        {
            Argument.AssertNotNull(site, nameof(site));
            Argument.AssertNotNull(domain, nameof(domain));
            Argument.AssertNotNull(secretPassword, nameof(secretPassword));

            Dns = new ChangeTrackingList<IPAddress>();
            Site = site;
            BackupOperators = new ChangeTrackingList<string>();
            Administrators = new ChangeTrackingList<string>();
            SecurityOperators = new ChangeTrackingList<string>();
            Domain = domain;
            SecretPassword = secretPassword;
        }

        internal ActiveDirectoryConfigProperties(string userName, IList<IPAddress> dns, string smbServerName, string organizationalUnit, string site, IList<string> backupOperators, IList<string> administrators, IList<string> securityOperators, NetAppAccountActiveDirectoryStatus? activeDirectoryStatus, NetAppProvisioningState? provisioningState, string domain, NetAppSecretPassword secretPassword, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            UserName = userName;
            Dns = dns;
            SmbServerName = smbServerName;
            OrganizationalUnit = organizationalUnit;
            Site = site;
            BackupOperators = backupOperators;
            Administrators = administrators;
            SecurityOperators = securityOperators;
            ActiveDirectoryStatus = activeDirectoryStatus;
            ProvisioningState = provisioningState;
            Domain = domain;
            SecretPassword = secretPassword;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string UserName { get; set; }

        public IList<IPAddress> Dns { get; }

        public string SmbServerName { get; set; }

        public string OrganizationalUnit { get; set; }

        public string Site { get; set; }

        public IList<string> BackupOperators { get; }

        public IList<string> Administrators { get; }

        public IList<string> SecurityOperators { get; }

        public NetAppAccountActiveDirectoryStatus? ActiveDirectoryStatus { get; }

        public NetAppProvisioningState? ProvisioningState { get; }

        public string Domain { get; set; }

        public NetAppSecretPassword SecretPassword { get; set; }

        protected virtual ActiveDirectoryConfigProperties PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return System.BinaryData.FromString("{}");
        }

        ActiveDirectoryConfigProperties IPersistableModel<ActiveDirectoryConfigProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<ActiveDirectoryConfigProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<ActiveDirectoryConfigProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<ActiveDirectoryConfigProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        ActiveDirectoryConfigProperties IJsonModel<ActiveDirectoryConfigProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        protected virtual ActiveDirectoryConfigProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new ActiveDirectoryConfigProperties(string.Empty, string.Empty, new NetAppSecretPassword());
        }
    }
}
