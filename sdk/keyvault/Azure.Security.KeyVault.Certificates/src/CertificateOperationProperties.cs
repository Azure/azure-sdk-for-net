// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Properties pertaining to the status of a certificate operation.
    /// </summary>
    public class CertificateOperationProperties : IJsonDeserializable
    {
        private const string IdPropertyName = "id";
        private const string IssuerProperyName = "issuer";
        private const string CsrPropertyName = "csr";
        private const string CancellationRequestedPropertyName = "cancellation_requested";
        private const string RequestIdPropertyName = "request_id";
        private const string StatusPropertyName = "status";
        private const string StatusDetailsPropertyName = "status_details";
        private const string TargetPropertyName = "target";
        private const string ErrorPropertyName = "error";
        private const string PreserveCertificateOrderPropertyName = "preserveCertOrder";
        private const string Collection = "certificates/";

        private IssuerParameters _issuer;

        internal CertificateOperationProperties()
        {
        }

        internal CertificateOperationProperties(Uri vaultUri, string name)
        {
            VaultUri = vaultUri;
            Name = name;

            RequestUriBuilder builder = new RequestUriBuilder
            {
                Scheme = vaultUri.Scheme,
                Host = vaultUri.Host,
                Port = vaultUri.Port,
                Path = Collection + name,
            };

            Id = builder.ToUri();
        }

        /// <summary>
        /// Gets the identifier of the certificate operation.
        /// </summary>
        public Uri Id { get; internal set; }

        /// <summary>
        /// Gets the name of the certificate to which the operation applies.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the vault executing the certificate operation.
        /// </summary>
        public Uri VaultUri { get; internal set; }

        /// <summary>
        /// Gets the name of the <see cref="CertificateIssuer"/> for the certificate to create.
        /// </summary>
        public string IssuerName
        {
            get => _issuer.IssuerName;
            internal set => _issuer.IssuerName = value;
        }

        /// <summary>
        /// Gets the type of the certificate to create.
        /// </summary>
        public string CertificateType
        {
            get => _issuer.CertificateType;
            internal set => _issuer.CertificateType = value;
        }

        /// <summary>
        /// Gets a value indicating whether the certificate will be published to the certificate transparency list when created.
        /// </summary>
        public bool? CertificateTransparency
        {
            get => _issuer.CertificateTransparency;
            internal set => _issuer.CertificateTransparency = value;
        }

        /// <summary>
        /// Gets the certificate signing request (CSR) that is being used in the certificate operation.
        /// </summary>
        public byte[] Csr { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether a cancellation has been requested for the operation.
        /// </summary>
        public bool CancellationRequested { get; internal set; }

        /// <summary>
        /// Gets the request identifier of the certificate operation.
        /// </summary>
        public string RequestId { get; internal set; }

        /// <summary>
        /// Gets the current status of the operation.
        /// </summary>
        public string Status { get; internal set; }

        /// <summary>
        /// Gets extended details on the status of the operation.
        /// </summary>
        public string StatusDetails { get; internal set; }

        /// <summary>
        /// Gets the location which will contain the result of the certificate operation.
        /// </summary>
        public string Target { get; internal set; }

        /// <summary>
        /// Gets any errors encountered during the processing of the certificate operation.
        /// </summary>
        public CertificateOperationError Error { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the certificate chain preserves its original order.
        /// The default value is false, which sets the leaf certificate at index 0.
        /// </summary>
        public bool? PreserveCertificateOrder { get; internal set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case IdPropertyName:
                        var id = prop.Value.GetString();
                        Id = new Uri(id);
                        ParseId(Id);
                        break;

                    case IssuerProperyName:
                        _issuer.ReadProperties(prop.Value);
                        break;

                    case CsrPropertyName:
                        Csr = prop.Value.GetBytesFromBase64();
                        break;

                    case CancellationRequestedPropertyName:
                        CancellationRequested = prop.Value.GetBoolean();
                        break;

                    case RequestIdPropertyName:
                        RequestId = prop.Value.GetString();
                        break;

                    case StatusPropertyName:
                        Status = prop.Value.GetString();
                        break;

                    case StatusDetailsPropertyName:
                        StatusDetails = prop.Value.GetString();
                        break;

                    case TargetPropertyName:
                        Target = prop.Value.GetString();
                        break;

                    case ErrorPropertyName:
                        Error = new CertificateOperationError();
                        ((IJsonDeserializable)Error).ReadProperties(prop.Value);
                        break;

                    case PreserveCertificateOrderPropertyName:
                        PreserveCertificateOrder = prop.Value.GetBoolean();
                        break;
                }
            }
        }

        private void ParseId(Uri idToParse)
        {
            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (idToParse.Segments.Length != 3 && idToParse.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", idToParse, idToParse.Segments.Length));

            if (!string.Equals(idToParse.Segments[1], Collection, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be '{1}', found '{2}'", idToParse, Collection, idToParse.Segments[1]));

            VaultUri = new Uri($"{idToParse.Scheme}://{idToParse.Authority}");
            Name = idToParse.Segments[2].Trim('/');
        }
    }
}
