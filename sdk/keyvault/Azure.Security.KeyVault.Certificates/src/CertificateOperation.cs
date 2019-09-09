// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateOperation : Operation<CertificateWithPolicy>
    {
        private bool _hasValue = false;
        private bool _completed = false;
        private CertificateClient _client;

        internal CertificateOperation(Response<CertificateOperationProperties> properties, CertificateClient client)
            : base(properties.Value.Id.ToString())
        {
            Properties = properties;

            _client = client;
        }

        public CertificateOperationProperties Properties { get; private set; }

        public override bool HasCompleted => _completed;

        public override bool HasValue => _hasValue;

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!_completed)
            {
                Response<CertificateOperationProperties> pollResponse = _client.GetPendingCertificate(Properties.Name, cancellationToken);

                SetRawResponse(pollResponse.GetRawResponse());

                Properties = pollResponse;
            }

            if (Properties.Status == "completed")
            {
                Response<CertificateWithPolicy> getResponse = _client.GetCertificateWithPolicy(Properties.Name, cancellationToken);

                SetRawResponse(getResponse.GetRawResponse());

                Value = getResponse.Value;

                _completed = true;

                _hasValue = true;
            }
            else if (Properties.Status == "cancelled")
            {
                _completed = true;

                throw new OperationCanceledException("The certificate opertation has been canceled");
            }
            else if (Properties.Error != null)
            {
                _completed = true;

                throw new InvalidOperationException("The certificate operation failed");
            }

            return GetRawResponse();
        }

        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!_completed)
            {
                Response<CertificateOperationProperties> pollResponse = await _client.GetPendingCertificateAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

                SetRawResponse(pollResponse.GetRawResponse());

                Properties = pollResponse;
            }

            if (Properties.Status == "completed")
            {
                Response<CertificateWithPolicy> getResponse = await _client.GetCertificateWithPolicyAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

                SetRawResponse(getResponse.GetRawResponse());

                Value = getResponse.Value;

                _completed = true;

                _hasValue = true;
            }
            else if (Properties.Status == "cancelled")
            {
                _completed = true;

                throw new OperationCanceledException("The certificate opertation has been canceled");
            }
            else if (Properties.Error != null)
            {
                _completed = true;

                throw new InvalidOperationException("The certificate operation failed, see Properties.Error for more details");
            }

            return GetRawResponse();
        }
    }

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

        public Uri Id { get; private set; }

        public string Name { get; private set; }

        public Uri VaultUri { get; private set; }

        public string IssuerName { get; private set; }

        public string CertificateSigningRequest { get; private set; }

        public bool CancellationRequested { get; private set; }

        public string RequestId { get; private set; }

        public string Status { get; private set; }

        public string StatusDetails { get; private set; }

        public string Target { get; private set; }

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
                        ParseId(id);
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
        private void ParseId(string id)
        {
            var idToParse = new Uri(id, UriKind.Absolute); ;

            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (idToParse.Segments.Length != 3 && idToParse.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", id, idToParse.Segments.Length));

            if (!string.Equals(idToParse.Segments[1], "certificates" + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be 'certificates/', found '{1}'", id, idToParse.Segments[1]));

            VaultUri = new Uri($"{idToParse.Scheme}://{idToParse.Authority}");
            Name = idToParse.Segments[2].Trim('/');
        }
    }
}
