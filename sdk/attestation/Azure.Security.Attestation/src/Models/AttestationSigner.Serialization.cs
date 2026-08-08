// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.Attestation
{
    public partial class AttestationSigner : IJsonModel<AttestationSigner>
    {
        void IJsonModel<AttestationSigner>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<JsonWebKey>)ToJsonWebKey()).Write(writer, options);
        }

        AttestationSigner IJsonModel<AttestationSigner>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAttestationSigner(document.RootElement, options);
        }

        BinaryData IPersistableModel<AttestationSigner>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<JsonWebKey>)ToJsonWebKey()).Write(options);
        }

        AttestationSigner IPersistableModel<AttestationSigner>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAttestationSigner(document.RootElement, options);
        }

        string IPersistableModel<AttestationSigner>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static AttestationSigner DeserializeAttestationSigner(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            JsonWebKey key = JsonWebKey.DeserializeJsonWebKey(element, options);
            return FromJsonWebKey(key);
        }

        private JsonWebKey ToJsonWebKey()
        {
            List<string> x5c = new List<string>();
            if (SigningCertificates != null)
            {
                foreach (var certificate in SigningCertificates)
                {
                    x5c.Add(Convert.ToBase64String(certificate.Export(System.Security.Cryptography.X509Certificates.X509ContentType.Cert)));
                }
            }
            return new JsonWebKey(
                alg: null,
                crv: null,
                d: null,
                dp: null,
                dq: null,
                e: null,
                k: null,
                kid: CertificateKeyId,
                kty: "RSA",
                n: null,
                p: null,
                q: null,
                qi: null,
                use: null,
                x: null,
                x5c: x5c,
                y: null,
                additionalBinaryDataProperties: null);
        }
    }
}
