// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Security.KeyVault.Secrets.Models;

namespace Azure.Security.KeyVault.Secrets
{
    // Translates between the generated wire models (under Models/) and the
    // hand-written customer-facing types (KeyVaultSecret, SecretProperties,
    // DeletedSecret, etc). Pure functions, no I/O. Mirrors the layering Java's
    // SecretAsyncClient/secretImpl uses and Python's _generated <-> public
    // model adapter.
    internal static class SecretMapper
    {
        // ---------- generated -> public ----------

        public static KeyVaultSecret ToKeyVaultSecret(SecretBundle bundle)
        {
            if (bundle is null) return null;

            var props = new SecretProperties();
            PopulateProperties(props, bundle.Id, bundle.ContentType, bundle.Kid,
                               bundle.Managed, bundle.PreviousVersion, bundle.Attributes, bundle.Tags);

            return new KeyVaultSecret(props) { Value = bundle.Value };
        }

        public static DeletedSecret ToDeletedSecret(DeletedSecretBundle bundle)
        {
            if (bundle is null) return null;

            var props = new SecretProperties();
            PopulateProperties(props, bundle.Id, bundle.ContentType, bundle.Kid,
                               bundle.Managed, bundle.PreviousVersion, bundle.Attributes, bundle.Tags);

            var deleted = new DeletedSecret(props)
            {
                DeletedOn = bundle.DeletedDate,
                ScheduledPurgeDate = bundle.ScheduledPurgeDate,
            };
            deleted.Value = bundle.Value;
            if (!string.IsNullOrEmpty(bundle.RecoveryId))
            {
                deleted.RecoveryId = new Uri(bundle.RecoveryId);
            }
            return deleted;
        }

        public static SecretProperties ToSecretProperties(SecretItem item)
        {
            if (item is null) return null;

            var props = new SecretProperties();
            PopulateProperties(props, item.Id, item.ContentType, kid: null,
                               managed: item.Managed, previousVersion: null,
                               attrs: item.Attributes, tags: item.Tags);
            return props;
        }

        public static DeletedSecret ToDeletedSecret(DeletedSecretItem item)
        {
            if (item is null) return null;

            var props = new SecretProperties();
            PopulateProperties(props, item.Id, item.ContentType, kid: null,
                               managed: item.Managed, previousVersion: null,
                               attrs: item.Attributes, tags: item.Tags);

            var deleted = new DeletedSecret(props)
            {
                DeletedOn = item.DeletedDate,
                ScheduledPurgeDate = item.ScheduledPurgeDate,
            };
            if (!string.IsNullOrEmpty(item.RecoveryId))
            {
                deleted.RecoveryId = new Uri(item.RecoveryId);
            }
            return deleted;
        }

        public static byte[] ToBackupBytes(BackupSecretResult backup)
            => backup?.Value?.ToArray();

        // ---------- public -> generated ----------

        public static SecretSetParameters ToSetParameters(KeyVaultSecret secret)
        {
            if (secret is null) throw new ArgumentNullException(nameof(secret));

            // The non-null guard for `Value` lives on the generated
            // `SecretSetParameters(string value)` ctor (Argument.AssertNotNull),
            // so a null Value still throws ArgumentNullException client-side.
            // This is unreachable via the public surface today — KeyVaultSecret's
            // ctor rejects null Value and the `Value` setter is internal — so the
            // exact ArgumentException vs. ArgumentNullException distinction is
            // not observable.
            var p = secret.Properties;
            var setParams = new SecretSetParameters(secret.Value)
            {
                ContentType = p?.ContentType,
                SecretAttributes = ToWireAttributes(p),
            };
            CopyTags(p?.Tags, setParams.Tags);
            return setParams;
        }

        // Build the JSON body the service expects for PATCH. We pass through
        // exactly the fields the customer may have changed (enabled / nbf /
        // exp / contentType / tags) — the same fields the hand-written
        // SecretClient writes. Read-only fields are deliberately omitted to
        // avoid the service rejecting the request.
        public static System.IO.Stream WriteUpdateBody(SecretProperties properties)
        {
            if (properties is null) throw new ArgumentNullException(nameof(properties));

            var ms = new System.IO.MemoryStream();
            using (var writer = new System.Text.Json.Utf8JsonWriter(ms))
            {
                writer.WriteStartObject();

                if (properties.ContentType != null)
                {
                    writer.WriteString("contentType", properties.ContentType);
                }

                bool hasEnabled  = properties.Enabled.HasValue;
                bool hasNbf      = properties.NotBefore.HasValue;
                bool hasExp      = properties.ExpiresOn.HasValue;
                if (hasEnabled || hasNbf || hasExp)
                {
                    writer.WriteStartObject("attributes");
                    if (hasEnabled) writer.WriteBoolean("enabled", properties.Enabled.Value);
                    if (hasNbf)     writer.WriteNumber("nbf", properties.NotBefore.Value.ToUnixTimeSeconds());
                    if (hasExp)     writer.WriteNumber("exp", properties.ExpiresOn.Value.ToUnixTimeSeconds());
                    writer.WriteEndObject();
                }

                // Match the legacy SecretClient PATCH body exactly: emit a "tags" object
                // only if the customer touched the dictionary (non-null backing store)
                // *and* it has at least one entry. This avoids replacing the server's
                // tags with an empty bag when the caller didn't intend to change them.
                IDictionary<string, string> existingTags = properties.TagsIfSet;
                if (existingTags is { Count: > 0 })
                {
                    writer.WriteStartObject("tags");
                    foreach (var kvp in existingTags)
                    {
                        writer.WriteString(kvp.Key, kvp.Value);
                    }
                    writer.WriteEndObject();
                }

                writer.WriteEndObject();
            }
            ms.Position = 0;
            return ms;
        }

        public static SecretRestoreParameters ToRestoreParameters(byte[] backup)
        {
            if (backup is null) throw new ArgumentNullException(nameof(backup));
            return new SecretRestoreParameters(BinaryData.FromBytes(backup));
        }

        // ---------- helpers ----------

        private static void PopulateProperties(SecretProperties props,
                                               string id,
                                               string contentType,
                                               string kid,
                                               bool? managed,
                                               string previousVersion,
                                               SecretAttributesBundle attrs,
                                               IDictionary<string, string> tags)
        {
            if (!string.IsNullOrEmpty(id))
            {
                props.Id = new Uri(id);
                props.ParseId(props.Id);
            }
            props.ContentType     = contentType;
            if (!string.IsNullOrEmpty(kid)) props.KeyId = new Uri(kid);
            props.Managed         = managed ?? false;
            props.PreviousVersion = previousVersion;

            if (attrs != null)
            {
                props.Enabled         = attrs.Enabled;
                props.NotBefore       = attrs.NotBefore;
                props.ExpiresOn       = attrs.Expires;
                props.CreatedOn       = attrs.Created;
                props.UpdatedOn       = attrs.Updated;
                props.RecoverableDays = attrs.RecoverableDays;
                props.RecoveryLevel   = attrs.RecoveryLevel?.ToString();
            }

            if (tags != null && tags.Count > 0)
            {
                foreach (var kvp in tags)
                {
                    props.Tags[kvp.Key] = kvp.Value;
                }
            }
        }

        private static SecretAttributesBundle ToWireAttributes(SecretProperties p)
        {
            if (p is null) return null;
            if (!p.Enabled.HasValue && !p.NotBefore.HasValue && !p.ExpiresOn.HasValue) return null;

            // ctor on generated SecretAttributesBundle accepts only enabled/notBefore/expires
            // at the "write" path; the rest are read-only and never echoed back to the service.
            return new SecretAttributesBundle
            {
                Enabled   = p.Enabled,
                NotBefore = p.NotBefore,
                Expires   = p.ExpiresOn,
            };
        }

        private static void CopyTags(IDictionary<string, string> source, IDictionary<string, string> dest)
        {
            if (source is null || dest is null) return;
            foreach (var kvp in source)
            {
                dest[kvp.Key] = kvp.Value;
            }
        }
    }
}
