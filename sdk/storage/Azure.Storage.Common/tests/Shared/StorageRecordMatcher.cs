// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using Azure.Core.TestFramework;

namespace Azure.Storage.Test.Shared
{
    /// <summary>
    /// There are a lot of Storage tests and it can be difficult to manage
    /// updating tests with meaningful changes with new recordings since the
    /// diffs are very busy.
    ///
    /// This RecordMatcher provides a lot of Storage specific guidance on what
    /// counts as an updated recording and what can probably be ignored.  It's
    /// not exact and we're making some safe guesses which should be good
    /// enough to catch most meaningful changes.  If you ever want to force
    /// something to be updated, just delete the original recording and there
    /// will be nothing to compare against.
    ///
    /// The core idea here is to convert different types of structured text
    /// data (urls, XML, JSON) into a general structured format that we can
    /// run through a crude diff.  The general structure is just:
    ///
    ///     Obj := Dictionary{string, Obj}
    ///         |  string
    ///         |  byte[]
    ///         |  null
    /// </summary>
    public class StorageRecordMatcher : RecordMatcher
    {
        /// <summary>
        /// A list of field names that contain values which we don't expect to
        /// be the same across re-recordings.
        /// </summary>
        private static readonly HashSet<string> s_volatileFieldNames = new HashSet<string>()
        {
            // General
            "LastModified",
            "Last-Modified",
            "Creation-Time",
            "Etag",
            "Message", // Error.Message contains the current time/request ID
            "Marker",
            "NextMarker",
            "LastSyncTime",

            // Storage query parameters
            "copyid",
            "st",
            "se",
            "skt",
            "ske",
            "snapshot",
            "prevsnapshot",

            // Storage XML
            "Start",
            "Expiry",
            "SignedStart",
            "SignedExpiry",
            "Value", // UserDelegationKey.Value might be too general...
            "DeletedTime",
            "Snapshot",
            "MessageId",
            "InsertionTime",
            "ExpirationTime",
            "TimeNextVisible",
            "PopReceipt",

            // AD JSON
            "expires_in",
            "ext_expires_in"
        };

        /// <summary>
        /// Creates a new StorageRecordMatcher to determine whether recordings
        /// have been meaningfully updated.
        /// </summary>
        // TODO: https://github.com/Azure/azure-sdk-for-net/issues/11632
        public StorageRecordMatcher():base(compareBodies: false)
        {
            // Storage specific request headers to ignore
            VolatileHeaders.Add("x-ms-source-if-match");
            VolatileHeaders.Add("x-ms-source-if-none-match");
            VolatileHeaders.Add("x-ms-source-if-modified-since");
            VolatileHeaders.Add("x-ms-source-if-unmodified-since");
            VolatileHeaders.Add("x-ms-copy-source");
            VolatileHeaders.Add("x-ms-rename-source");

            // Storage specific response headers to ignore
            VolatileResponseHeaders.Add("Server");
            VolatileResponseHeaders.Add("x-ms-snapshot");
            VolatileResponseHeaders.Add("x-ms-copy-id");
            VolatileResponseHeaders.Add("x-ms-creation-time");
            VolatileResponseHeaders.Add("x-ms-copy-completion-time");
            VolatileResponseHeaders.Add("x-ms-copy-destination-snapshot");
            VolatileResponseHeaders.Add("x-ms-copy-source");
            VolatileResponseHeaders.Add("Set-Cookie");
            VolatileResponseHeaders.Add("Referrer-Policy");
        }

        /// <summary>
        /// Checks if two recorded URIs have no meaningful changes.
        /// </summary>
        /// <param name="entryUri">The first URI.</param>
        /// <param name="otherEntryUri">The second URI.</param>
        /// <returns>Whether the URIs are equivalent.</returns>
        protected override bool IsEquivalentUri(string entryUri, string otherEntryUri) =>
            AreSimilar(ParseUri(entryUri), ParseUri(otherEntryUri));

        /// <summary>
        /// Checks if two recorded response bodies have no meaningful changes.
        /// </summary>
        /// <param name="entry">The first response body.</param>
        /// <param name="otherEntry">The second response body.</param>
        /// <returns>Whether the response bodies are equivalent.</returns>
        protected override bool IsBodyEquivalent(RecordEntry entry, RecordEntry otherEntry) =>
            AreSimilar(ParseBody(entry), ParseBody(otherEntry));

        /// <summary>
        /// Determine if two values are equivalent with respect to the list of
        /// fields known to be volatile.  The values can be null, byte[],
        /// string, or Dictionary{string, object} (where the values are closed
        /// over this list).  Any other type will result in false.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The seocnd value.</param>
        /// <returns>Whether the two values are similar.</returns>
        private static bool AreSimilar(object a, object b)
        {
            switch (a, b)
            {
                case (null, null):
                    return true;
                case (null, _):
                    return false;
                case (_, null):
                    return false;
                case (string sa, string sb):
                    return string.Equals(sa, sb, StringComparison.Ordinal);
                case (byte[] ba, byte[] bb):
                    return (ba ?? Array.Empty<byte>()).SequenceEqual(bb ?? Array.Empty<byte>());
                case (Dictionary<string, object> da, Dictionary<string, object> db):
                    return da.Keys.Union(db.Keys).All(key =>
                        da.TryGetValue(key, out var va) &&
                        db.TryGetValue(key, out var vb) &&
                        (s_volatileFieldNames.Contains(key) || AreSimilar(va, vb)));
                // We just assume any other types contain differences since we
                // can't analyze them
                default:
                    return false;
            }
        }

        /// <summary>
        /// Convert a URI into the general structured format supported by
        /// AreSimilar.
        /// </summary>
        /// <param name="value">The URI to parse.</param>
        /// <returns>The URI in our general structured format.</returns>
        private static Dictionary<string, object> ParseUri(string value)
        {
            var parts = new Dictionary<string, object>();
            var builder = new UriBuilder(value);
            parts.Add("Scheme", builder.Scheme);
            parts.Add("Host", builder.Host);
            parts.Add("Port", builder.Port.ToString(CultureInfo.InvariantCulture));
            parts.Add("UserName", builder.UserName);
            parts.Add("Password", builder.Password);
            parts.Add("Fragment", builder.Fragment);

            var index = 0;
            var path = new Dictionary<string, object>();
            foreach (var segment in builder.Path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
            {
                path.Add(index++.ToString(CultureInfo.InvariantCulture), segment);
            }
            parts.Add("Path", path);

            var query = new Dictionary<string, object>();
            foreach (KeyValuePair<string, string> pair in new UriQueryParamsCollection(builder.Query))
            {
                query.Add(pair.Key, pair.Value);
            }
            parts.Add("Query", query);

            return parts;
        }

        /// <summary>
        /// Convert a response body into the general structured format
        /// supported by AreSimilar.
        /// </summary>
        /// <param name="entry">Entry containing the body.</param>
        /// <returns>
        /// The response body in our general structured format.
        /// </returns>
        private static object ParseBody(RecordEntry entry)
        {
            // Switch on the Content-Type to check for XML or JSON
            var body = entry.Response.Body ?? Array.Empty<byte>();
            if (body.Length > 0 &&
                entry.Response.Headers.TryGetValue("Content-Type", out var types) &&
                types?.Length > 0)
            {
                if (types.Any(t => t.Contains("xml")))
                {
                    return ParseXmlBody(body);
                }
                else if (types.Any(t => t.Contains("json")))
                {
                    return ParseJsonBody(body);
                }
            }

            // But default to byte[]
            return body;
        }

        /// <summary>
        /// Convert an XML response body into the general structured format
        /// supported by AreSimilar.
        /// </summary>
        /// <param name="body">The response body.</param>
        /// <returns>
        /// The response body in our general structured format.
        /// </returns>
        private static object ParseXmlBody(byte[] body)
        {
            using var stream = new MemoryStream(body);
            var doc = XDocument.Load(stream);
            return Parse(doc.Root);

            static object Parse(XElement element)
            {
                // Return null or the inner text for simple elements
                if (element == null) { return null; }
                if (!element.HasElements && !element.HasAttributes)
                {
                    return new Dictionary<string, object> { { element.Name.LocalName, element.Value } };
                }

                var value = new Dictionary<string, object>
                {
                    { "Name", element.Name.LocalName }
                };

                if (element.HasAttributes)
                {
                    var attrs = new Dictionary<string, object>();
                    foreach (XAttribute attr in element.Attributes())
                    {
                        attrs.Add(attr.Name.LocalName, attr.Value);
                    }
                    value.Add("Attributes", attrs);
                }

                if (element.HasElements)
                {
                    var elts = new Dictionary<string, object>();
                    var index = 0;
                    foreach (XElement child in element.Elements())
                    {
                        elts.Add(index++.ToString(CultureInfo.InvariantCulture), Parse(child));
                    }
                    value.Add("Elements", elts);
                }
                else if (!string.IsNullOrEmpty(element.Value))
                {
                    value.Add("Value", element.Value);
                }

                return value;
            }
        }

        /// <summary>
        /// Convert a JSON response body into the general structured format
        /// supported by AreSimilar.
        /// </summary>
        /// <param name="body">The response body.</param>
        /// <returns>
        /// The response body in our general structured format.
        /// </returns>
        private static object ParseJsonBody(byte[] body)
        {
            var reader = new Utf8JsonReader(body.AsSpan(), true, new JsonReaderState());
            return JsonDocument.TryParseValue(ref reader, out JsonDocument doc) ?
                Parse(doc.RootElement) :
                null;

            static object Parse(JsonElement element)
            {
                switch (element.ValueKind)
                {
                    // Keep all primitives (except null) as strings
                    case JsonValueKind.False:
                        return "false";
                    case JsonValueKind.True:
                        return "true";
                    case JsonValueKind.Undefined:
                        return "undefined";
                    case JsonValueKind.Number:
                        return element.GetRawText();
                    case JsonValueKind.String:
                        return element.GetString();
                    case JsonValueKind.Object:
                        var obj = new Dictionary<string, object>();
                        foreach (JsonProperty property in element.EnumerateObject())
                        {
                            obj.Add(property.Name, Parse(property.Value));
                        }
                        return obj;
                    case JsonValueKind.Array:
                        var values = new Dictionary<string, object>();
                        var index = 0;
                        foreach (JsonElement value in element.EnumerateArray())
                        {
                            values.Add(index++.ToString(CultureInfo.InvariantCulture), Parse(value));
                        }
                        return values;
                    case JsonValueKind.Null:
                    default:
                        return null;
                }
            }
        }
    }
}
