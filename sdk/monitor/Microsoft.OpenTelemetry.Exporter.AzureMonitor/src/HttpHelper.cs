// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal static class HttpHelper
    {
        private const string SchemePostfix = "://";
        private const string Colon = ":";

        /// <summary>
        /// This method follows OpenTelemetry specification to retrieve http URL.
        /// Reference: https://github.com/open-telemetry/opentelemetry-specification/blob/master/specification/trace/semantic_conventions/http.md#http-client.
        /// </summary>
        /// <param name="tagObjects">Activity Tags</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetUrl(this PooledList<KeyValuePair<string, object>> tagObjects)
        {
            var httpurl = tagObjects.GetTagValue(SemanticConventions.AttributeHttpUrl);

            if (httpurl != null && Uri.TryCreate(httpurl.ToString(), UriKind.RelativeOrAbsolute, out var uri) && uri.IsAbsoluteUri)
            {
                return uri.AbsoluteUri;
            }

            string url = null;

            var httpScheme = tagObjects.GetTagValue(SemanticConventions.AttributeHttpScheme);

            if (httpScheme != null)
            {
                var httpHost = tagObjects.GetTagValue(SemanticConventions.AttributeHttpHost);

                if (httpHost != null)
                {
                    var httpPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeHttpHostPort, SemanticConventions.AttributeHttpTarget);

                    if (httpPortAndTarget[0] != null && httpPortAndTarget[0].ToString() != "80" && httpPortAndTarget[0].ToString() != "443")
                    {
                        url = $"{httpScheme}://{httpHost}:{httpPortAndTarget[0]}{httpPortAndTarget[1]}";
                    }
                    else
                    {
                        url = $"{httpScheme}://{httpHost}{httpPortAndTarget[1]}";
                    }

                    return url;
                }

                var netPeerName = tagObjects.GetTagValue(SemanticConventions.AttributeNetPeerName);

                if (netPeerName != null)
                {
                    var netPeerPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeNetPeerPort, SemanticConventions.AttributeHttpTarget);
                    return string.IsNullOrWhiteSpace(netPeerName?.ToString()) ? null : $"{httpScheme}{SchemePostfix}{netPeerName}{(string.IsNullOrWhiteSpace(netPeerPortAndTarget[0]?.ToString()) ? null : Colon)}{netPeerPortAndTarget[0]}{netPeerPortAndTarget[1]}";
                }

                var netPeerIP = tagObjects.GetTagValue(SemanticConventions.AttributeNetPeerIp);

                if (netPeerIP != null)
                {
                    var netPeerPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeNetPeerPort, SemanticConventions.AttributeHttpTarget);
                    return string.IsNullOrWhiteSpace(netPeerIP?.ToString()) ? null : $"{httpScheme}{SchemePostfix}{netPeerIP}{(string.IsNullOrWhiteSpace(netPeerPortAndTarget[0]?.ToString()) ? null : Colon)}{netPeerPortAndTarget[0]}{netPeerPortAndTarget[1]}";
                }
            }

            var host = tagObjects.GetTagValue(SemanticConventions.AttributeHttpHost);

            if (host != null)
            {
                var httpPortAndTarget = tagObjects.GetTagValues(SemanticConventions.AttributeHttpHostPort, SemanticConventions.AttributeHttpTarget);
                url = $"{host}{(string.IsNullOrWhiteSpace(httpPortAndTarget[0]?.ToString()) ? null : ":")}{httpPortAndTarget[0]}{httpPortAndTarget[1]}";
            }

            return string.IsNullOrWhiteSpace(url) ? null : url;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetHttpStatusCode(this PooledList<KeyValuePair<string, object>> tagObjects)
        {
            var status = tagObjects.GetTagValue(SemanticConventions.AttributeHttpStatusCode)?.ToString();
            return status ?? "0";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetMessagingUrl(this PooledList<KeyValuePair<string, object>> tagObjects)
        {
            return tagObjects.GetTagValue(SemanticConventions.AttributeMessagingUrl)?.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool GetSuccessFromHttpStatusCode(string statusCode)
        {
            return statusCode == "200" || statusCode == "Ok";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetHost(this PooledList<KeyValuePair<string, object>> tagObjects)
        {
            return tagObjects.GetTagValue(SemanticConventions.AttributeHttpHost)?.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object GetTagValue(this PooledList<KeyValuePair<string, object>> tagObjects, string tagName)
        {
            ActivitySingleTagEnumerator state = new ActivitySingleTagEnumerator(tagName);
            ActivityTagsEnumeratorFactory<ActivitySingleTagEnumerator>.Enumerate(tagObjects, ref state);

            return state.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object[] GetTagValues(this PooledList<KeyValuePair<string, object>> tagObjects, params string[] tagNames)
        {
            if (tagNames.Length == 0)
            {
                return null;
            }

            ActivityMultipleTagEnumerator state = new ActivityMultipleTagEnumerator(tagNames);
            ActivityTagsEnumeratorFactory<ActivityMultipleTagEnumerator>.Enumerate(tagObjects, ref state);

            return state.Values;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object GetTagValues(this PooledList<KeyValuePair<string, object>> tagObjects, string tagName)
        {
            ActivitySingleTagEnumerator state = new ActivitySingleTagEnumerator(tagName);
            ActivityTagsEnumeratorFactory<ActivitySingleTagEnumerator>.Enumerate(tagObjects, ref state);

            return state.Value;
        }

        internal struct ActivitySingleTagEnumerator : IActivityEnumerator<KeyValuePair<string, object>>
        {
            public object Value;

            private readonly string tagName;

            public ActivitySingleTagEnumerator(string tagName)
            {
                this.tagName = tagName;
                this.Value = null;
            }

            public bool ForEach(KeyValuePair<string, object> item)
            {
                if (item.Key == this.tagName)
                {
                    this.Value = item.Value;
                    return false;
                }

                return true;
            }
        }

        internal struct ActivityMultipleTagEnumerator : IActivityEnumerator<KeyValuePair<string, object>>
        {
            public object[] Values;

            private readonly string[] tagNames;
            private int length;

            public ActivityMultipleTagEnumerator(params string[] tagNames)
            {
                this.tagNames = tagNames;
                this.length = tagNames.Length;
                this.Values = new object[this.length];
            }

            public bool ForEach(KeyValuePair<string, object> item)
            {
                var index = Array.IndexOf(tagNames, item.Key);
                if (index >= 0)
                {
                    this.Values[index] = item.Value;
                    this.length--;

                    if (length == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        internal static class ActivityTagsEnumeratorFactory<TState>
           where TState : struct, IActivityEnumerator<KeyValuePair<string, object>>
        {
            private static readonly DictionaryEnumerator<string, object, TState>.AllocationFreeForEachDelegate
                PooledListObjectsEnumerator = DictionaryEnumerator<string, object, TState>.BuildAllocationFreeForEachDelegate(
                    typeof(PooledList<KeyValuePair<string, object>>).GetField("buffer", BindingFlags.Instance | BindingFlags.NonPublic).FieldType);

            private static readonly DictionaryEnumerator<string, object, TState>.AllocationFreeForEachDelegate
                KeyValuePairEnumerator = DictionaryEnumerator<string, object, TState>.BuildAllocationFreeForEachDelegate(typeof(IEnumerable<KeyValuePair<string, object>>));

            private static readonly DictionaryEnumerator<string, object, TState>.ForEachDelegate ForEachTagValueCallbackRef = ForEachTagValueCallback;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void Enumerate(PooledList<KeyValuePair<string, object>> tagObjects, ref TState state)
            {
                if (tagObjects.Count == 0)
                {
                    return;
                }

                PooledListObjectsEnumerator(
                    tagObjects,
                    ref state,
                    ForEachTagValueCallbackRef);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void Enumerate(IEnumerable<KeyValuePair<string, object>> tagObjects, ref TState state)
            {
                if (tagObjects == null || tagObjects.Count() == 0)
                {
                    return;
                }

                KeyValuePairEnumerator(
                    tagObjects,
                    ref state,
                    ForEachTagValueCallbackRef);
            }

            private static bool ForEachTagValueCallback(ref TState state, KeyValuePair<string, object> item)
                => state.ForEach(item);
        }
    }
}
