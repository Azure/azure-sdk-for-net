// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    // Translates between the generated transport layer (request/response bodies
    // exchanged with the TypeSpec-generated KeyVaultCertificatesClient over
    // protocol overloads) and the hand-written customer-facing types
    // (KeyVaultCertificate, CertificatePolicy, CertificateIssuer, ...).
    //
    // The hand-written model classes already implement IJsonSerializable /
    // IJsonDeserializable producing the exact JSON the service expects (and the
    // exact JSON the service returns). This mapper is a thin adapter on top:
    // build a RequestContent from a writer, deserialize a Response into a
    // reader, project Pageable<BinaryData> to Pageable<T>. Doing it this way
    // preserves the byte-identical wire shape that previously-shipped 4.x
    // recordings depend on, and avoids re-implementing the JSON shape in a
    // separate field-by-field mapper.
    //
    // The Mapper is intentionally I/O-free: nothing here calls the network. It
    // mirrors the layering Java's CertificatesImpl uses (request/response
    // serialization adapters) and Python's _generated <-> public model adapter.
    internal static class CertificateMapper
    {
        // -------------------- public -> wire (RequestContent) --------------------

        // Wraps an IJsonSerializable model as a RequestContent. The writer always
        // emits a JSON object (StartObject/EndObject) bracketing the per-property
        // writes the hand-written models perform.
        public static RequestContent ToRequestContent(IJsonSerializable serializable)
        {
            Argument.AssertNotNull(serializable, nameof(serializable));

            ReadOnlyMemory<byte> body = serializable.Serialize();
            return RequestContent.Create(body);
        }

        // Build the JSON body the service expects for the certificate PATCH. The
        // legacy CertificateClient sent exactly { attributes?: { enabled }, tags? }
        // and never emitted a "tags" object when the caller hadn't touched the
        // bag (TagsIfSet null) -- mirror that here so recordings line up.
        public static RequestContent WriteUpdateBody(CertificateProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                writer.WriteStartObject();

                if (properties.Enabled.HasValue)
                {
                    writer.WriteStartObject("attributes");
                    writer.WriteBoolean("enabled", properties.Enabled.Value);
                    writer.WriteEndObject();
                }

                IDictionary<string, string> existingTags = properties.TagsIfSet;
                if (existingTags is { Count: > 0 })
                {
                    writer.WriteStartObject("tags");
                    foreach (KeyValuePair<string, string> kvp in existingTags)
                    {
                        writer.WriteString(kvp.Key, kvp.Value);
                    }
                    writer.WriteEndObject();
                }

                writer.WriteEndObject();
            }

            return RequestContent.Create(stream.ToArray());
        }

        // Build { "cancellation_requested": true } for the PATCH /pending body
        // that powers CertificateOperation.Cancel/CancelAsync.
        public static RequestContent WriteCancelOperationBody()
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                writer.WriteStartObject();
                writer.WriteBoolean("cancellation_requested", true);
                writer.WriteEndObject();
            }
            return RequestContent.Create(stream.ToArray());
        }

        // -------------------- wire (Response) -> public --------------------

        // Deserialize the body of `response` into a fresh T built by `factory`.
        // T must implement IJsonDeserializable -- the hand-written models all do.
        public static T Deserialize<T>(Response response, Func<T> factory)
            where T : IJsonDeserializable
        {
            Argument.AssertNotNull(response, nameof(response));
            Argument.AssertNotNull(factory, nameof(factory));

            T result = factory();
            using Stream stream = response.ContentStream ?? new MemoryStream(response.Content?.ToArray() ?? Array.Empty<byte>());
            using JsonDocument doc = JsonDocument.Parse(stream, default);
            result.ReadProperties(doc.RootElement);
            return result;
        }

        // Deserialize a single page item carried in the generated Pageable<BinaryData>.
        public static T DeserializeItem<T>(BinaryData data, Func<T> factory)
            where T : IJsonDeserializable
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(factory, nameof(factory));

            T result = factory();
            using JsonDocument doc = JsonDocument.Parse(data.ToMemory());
            result.ReadProperties(doc.RootElement);
            return result;
        }

        // The certificate backup endpoint returns { value: "<base64url>" }. The
        // legacy CertificateClient used the internal CertificateBackup reader to
        // round-trip the same shape; reuse it here so the response handling matches.
        public static Response<byte[]> ToBackupResponse(Response raw)
        {
            CertificateBackup backup = Deserialize(raw, () => new CertificateBackup());
            return Response.FromValue(backup.Value, raw);
        }

        // The contacts endpoint returns { contacts: [...] }. The legacy reader is
        // ContactList; project to the public IList<CertificateContact> facade.
        public static Response<IList<CertificateContact>> ToContactsResponse(Response raw)
        {
            ContactList list = Deserialize(raw, () => new ContactList());
            return Response.FromValue(list.ToList(), raw);
        }
    }
}
