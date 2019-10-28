// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Properties pertaining to the status of a certificate operation
    /// </summary>
    public class CertificateOperationProperties : IJsonDeserializable
    {
        private const string IdPropertyName = "id";
        private const string IssuerProperyName = "issuer";
        private const string IssuerNamePropertyName = "name";
        private const string CsrPropertyName = "csr";
        private const string CancellationRequestedPropertyName = "cancellation_requested";
        private const string RequestIdPropertyName = "request_id";
        private const string StatusPropertyName = "status";
        private const string StatusDetailsPropertyName = "status_details";
        private const string TargetPropertyName = "target";
        private const string ErrorPropertyName = "error";

        /// <summary>
        /// The Id of the certificate operation
        /// </summary>
        public Uri Id { get; private set; }

        /// <summary>
        /// The name of the certificate to which the operation applies
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The Uri of the vault executing the certificate operation
        /// </summary>
        public Uri VaultUri { get; private set; }

        /// <summary>
        /// The name of the <see cref="Issuer"/> for the certificate to which the operation applies
        /// </summary>
        public string IssuerName { get; private set; }

        /// <summary>
        /// The CSR which is pending signature for the certificate operation
        /// </summary>
        public string CertificateSigningRequest { get; private set; }

        /// <summary>
        /// Specifies whether a cancellation has been requested for the operation
        /// </summary>
        public bool CancellationRequested { get; private set; }

        /// <summary>
        /// The request id of the certificate operation
        /// </summary>
        public string RequestId { get; private set; }

        /// <summary>
        /// The current status of the operation
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Extended details on the status of the operation
        /// </summary>
        public string StatusDetails { get; private set; }

        /// <summary>
        /// The location which will contain the result of the certificate operation
        /// </summary>
        public string Target { get; private set; }

        /// <summary>
        /// Errors encountered, if any, during the processing of the certificate operation
        /// </summary>
        public Error Error { get; private set; }

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
                        IssuerName = prop.Value.GetProperty(IssuerNamePropertyName).GetString();
                        break;

                    case CsrPropertyName:
                        CertificateSigningRequest = prop.Value.GetString();
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
                        Error = new Error();
                        ((IJsonDeserializable)Error).ReadProperties(prop.Value);
                        break;
                }
            }
        }

        private void ParseId(Uri idToParse)
        {
            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (idToParse.Segments.Length != 3 && idToParse.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", idToParse, idToParse.Segments.Length));

            if (!string.Equals(idToParse.Segments[1], "certificates" + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be 'certificates/', found '{1}'", idToParse, idToParse.Segments[1]));

            VaultUri = new Uri($"{idToParse.Scheme}://{idToParse.Authority}");
            Name = idToParse.Segments[2].Trim('/');
        }
    }
}
