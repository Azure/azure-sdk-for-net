// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class AzMonListExtensions
    {
        /// <summary>
        /// Recognized database systems.
        /// <see href="https://github.com/open-telemetry/semantic-conventions/blob/v1.24.0/docs/database/database-spans.md#connection-level-attributes"/>.
        /// </summary>
        // TODO: This single item HashSet is used to map "mssql" to "SQL". This could be replaced with a helper method.
        internal static readonly HashSet<string?> s_dbSystems = new HashSet<string?>() { "mssql" };

        ///<summary>
        /// Gets http request url from activity tag objects.
        ///</summary>
        internal static string? GetRequestUrl(this AzMonList tagObjects)
        {
            // From spec: one of the following combinations is required in case of server spans:
            // https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/http.md#http-server-semantic-conventions
            // http.url
            // http.scheme, http.host, http.target
            // http.scheme, http.server_name, net.host.port, http.target
            // http.scheme, net.host.name, net.host.port, http.target
            string? url = null;
            url = tagObjects.GetUrlUsingHttpUrl();
            if (url != null)
            {
                return url;
            }

            var httpScheme = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpScheme)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpScheme))
            {
                var httpTarget = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpTarget)?.ToString();
                // http.target is required in other three possible combinations
                // If not available then do not proceed.
                if (string.IsNullOrWhiteSpace(httpTarget))
                {
                    return null;
                }

                string defaultPort = GetDefaultHttpPort(httpScheme);
                url = tagObjects.GetUrlUsingHttpHost(httpScheme!, defaultPort, httpTarget!);
                if (url != null)
                {
                    return url;
                }

                var httpServerName = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpServerName)?.ToString();
                string? host;
                if (!string.IsNullOrWhiteSpace(httpServerName))
                {
                    host = httpServerName;
                }
                else
                {
                    host = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetHostName)?.ToString();
                }
                if (!string.IsNullOrWhiteSpace(host))
                {
                    var netHostPort = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetHostPort)?.ToString();
                    if (!string.IsNullOrWhiteSpace(netHostPort))
                    {
                        url = tagObjects.GetUrlUsingHostAndPort(httpScheme!, host!, netHostPort!, defaultPort, httpTarget!);
                        return url;
                    }
                }
            }

            return url;
        }

        ///<summary>
        /// Gets http dependency url from activity tag objects.
        ///</summary>
        internal static string? GetDependencyUrl(this AzMonList tagObjects)
        {
            // From spec: one of the following combinations is required in case of client spans:
            // https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/http.md#http-client
            // http.url
            // http.scheme, http.host, http.target
            // http.scheme, net.peer.name, net.peer.port, http.target
            // http.scheme, net.peer.ip, net.peer.port, http.target
            string? url = null;
            url = tagObjects.GetUrlUsingHttpUrl();
            if (url != null)
            {
                return url;
            }

            var httpScheme = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpScheme)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpScheme))
            {
                var httpTarget = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpTarget)?.ToString();
                // http.target is required in other three possible combinations
                // If not available then do not proceed.
                if (string.IsNullOrWhiteSpace(httpTarget))
                {
                    return null;
                }

                string defaultPort = GetDefaultHttpPort(httpScheme);
                url = tagObjects.GetUrlUsingHttpHost(httpScheme!, defaultPort, httpTarget!);
                if (url != null)
                {
                    return url;
                }

                var host = tagObjects.GetHostUsingNetPeerAttributes();
                if (!string.IsNullOrWhiteSpace(host))
                {
                    var netPeerPort = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetPeerPort)?.ToString();
                    if (!string.IsNullOrWhiteSpace(netPeerPort))
                    {
                        url = tagObjects.GetUrlUsingHostAndPort(httpScheme!, host!, netPeerPort!, defaultPort, httpTarget!);
                        return url;
                    }
                }
            }

            return url;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetDefaultHttpPort(string? httpScheme)
        {
            if (string.Equals(httpScheme, "http", StringComparison.OrdinalIgnoreCase))
            {
                return "80";
            }
            else if (string.Equals(httpScheme, "https", StringComparison.OrdinalIgnoreCase))
            {
                return "443";
            }
            else
            {
                return "0";
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetDefaultDbPort(string? dbSystem)
        {
            if (dbSystem == null)
            {
                return "0";
            }
            else if (string.Equals(dbSystem, "mssql", StringComparison.OrdinalIgnoreCase))
            {
                return "1433";
            }
            else if (string.Equals(dbSystem, "redis", StringComparison.OrdinalIgnoreCase))
            {
                return "6379";
            }
            else
            {
                return "0";
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string? GetUrlUsingHttpUrl(this AzMonList tagObjects)
        {
            string? url = null;
            var httpUrl = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpUrl)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpUrl))
            {
                url = httpUrl;
            }

            return url;
        }

        internal static string? GetUrlUsingHttpHost(this AzMonList tagObjects, string httpScheme, string defaultPort, string httpTarget)
        {
            string? url = null;
            var httpHost = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpHost)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpHost))
            {
                string portSection = $":{defaultPort}";
                if (httpHost!.EndsWith(portSection, StringComparison.OrdinalIgnoreCase))
                {
                    var truncatedHost = httpHost.Substring(0, httpHost.IndexOf(portSection, StringComparison.OrdinalIgnoreCase));
                    url = $"{httpScheme}://{truncatedHost}{httpTarget}";
                }
                else
                {
                    url = $"{httpScheme}://{httpHost}{httpTarget}";
                }
            }

            return url;
        }

        internal static string? GetUrlUsingHostAndPort(this AzMonList tagObjects, string httpScheme, string host, string port, string defaultPort, string httpTarget)
        {
            string? url = null;
            if (port == defaultPort)
            {
                url = $"{httpScheme}://{host}{httpTarget}";
            }
            else
            {
                url = $"{httpScheme}://{host}:{port}{httpTarget}";
            }

            return url;
        }

        internal static string? GetHostUsingNetPeerAttributes(this AzMonList tagObjects)
        {
            var netPeerName = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetPeerName)?.ToString();
            string? host;
            if (!string.IsNullOrWhiteSpace(netPeerName))
            {
                host = netPeerName;
            }
            else
            {
                host = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetPeerIp)?.ToString();
            }

            return host;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string? GetTargetUsingNetPeerAttributes(this AzMonList tagObjects, string defaultPort)
        {
            string? target = tagObjects.GetHostUsingNetPeerAttributes();
            if (!string.IsNullOrWhiteSpace(target))
            {
                var netPeerPort = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeNetPeerPort)?.ToString();
                if (!string.IsNullOrWhiteSpace(netPeerPort) && netPeerPort != defaultPort)
                {
                    target = $"{target}:{netPeerPort}";
                }
            }

            return target;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string? GetTargetUsingServerAttributes(this AzMonList tagObjects, string defaultPort)
        {
            var values = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributeServerAddress, SemanticConventions.AttributeServerSocketAddress, SemanticConventions.AttributeServerPort);
            string? target = values[0]?.ToString() ?? values[1]?.ToString();
            var port = values[2]?.ToString();
            if (!string.IsNullOrWhiteSpace(target) &&  port != null && port != defaultPort)
            {
                target = target + ":" + port;
            }

            return target;
        }

        ///<summary>
        /// Gets Http dependency target from activity tag objects.
        ///</summary>
        internal static string? GetHttpDependencyTarget(this AzMonList tagObjects)
        {
            string? target;
            string defaultPort = GetDefaultHttpPort(AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpScheme)?.ToString());
            var peerService = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributePeerService)?.ToString();
            if (!string.IsNullOrWhiteSpace(peerService))
            {
                target = peerService;
                return target;
            }

            var httpHost = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpHost)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpHost))
            {
                string portSection = $":{defaultPort}";
                if (httpHost!.EndsWith(portSection, StringComparison.OrdinalIgnoreCase))
                {
                    var truncatedHost = httpHost.Substring(0, httpHost.IndexOf(portSection, StringComparison.OrdinalIgnoreCase));
                    target = truncatedHost;
                }
                else
                {
                    target = httpHost;
                }
                return target;
            }

            var httpUrl = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpUrl)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpUrl)
                && Uri.TryCreate(httpUrl!.ToString(), UriKind.RelativeOrAbsolute, out var uri)
                && uri.IsAbsoluteUri)
            {
                target = uri.Authority;
                if (!string.IsNullOrWhiteSpace(target))
                {
                    return target;
                }
            }

            target = tagObjects.GetTargetUsingNetPeerAttributes(defaultPort);

            return target;
        }

        ///<summary>
        /// Gets Database dependency target and name from activity tag objects.
        ///</summary>
        internal static (string? DbName, string? DbTarget) GetDbDependencyTargetAndName(this AzMonList tagObjects)
        {
            var peerServiceAndDbSystem = AzMonList.GetTagValues(ref tagObjects, SemanticConventions.AttributePeerService, SemanticConventions.AttributeDbSystem);
            string? target = peerServiceAndDbSystem[0]?.ToString();
            var defaultPort = GetDefaultDbPort(peerServiceAndDbSystem[1]?.ToString());

            if (string.IsNullOrWhiteSpace(target))
            {
                target = tagObjects.GetTargetUsingServerAttributes(defaultPort) ?? tagObjects.GetTargetUsingNetPeerAttributes(defaultPort);
            }

            var dbName = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeDbName)?.ToString();
            bool isTargetEmpty = string.IsNullOrWhiteSpace(target);
            bool isDbNameEmpty = string.IsNullOrWhiteSpace(dbName);
            if (!isTargetEmpty && !isDbNameEmpty)
            {
                target = $"{target} | {dbName}";
            }
            else if (isTargetEmpty && !isDbNameEmpty)
            {
                target = dbName;
            }
            else if (isTargetEmpty && isDbNameEmpty)
            {
                target = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeDbSystem)?.ToString();
            }

            return (DbName: dbName, DbTarget: target);
        }

        ///<summary>
        /// Gets dependency target from activity tag objects.
        ///</summary>
        internal static string? GetDependencyTarget(this AzMonList tagObjects, OperationType type)
        {
            switch (type)
            {
                case OperationType.Http:
                    return tagObjects.GetHttpDependencyTarget();
                case OperationType.Db:
                    return tagObjects.GetDbDependencyTargetAndName().DbTarget;
                case OperationType.Messaging:
                    return tagObjects.GetMessagingUrlAndSourceOrTarget(ActivityKind.Producer).SourceOrTarget;
                default:
                    return null;
            }
        }

        internal static string? GetHttpDependencyName(this AzMonList tagObjects, string? httpUrl)
        {
            if (string.IsNullOrWhiteSpace(httpUrl))
            {
                return null;
            }

            var httpMethod = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeHttpMethod)?.ToString();
            if (!string.IsNullOrWhiteSpace(httpMethod))
            {
                if (Uri.TryCreate(httpUrl!.ToString(), UriKind.RelativeOrAbsolute, out var uri) && uri.IsAbsoluteUri)
                {
                    return $"{httpMethod} {uri.AbsolutePath}";
                }
            }

            return null;
        }

        internal static string? GetDependencyType(this AzMonList tagObjects, OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.Http:
                    {
                        return "Http";
                    }
                case OperationType.Db:
                    {
                        var dbSystem = AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeDbSystem)?.ToString();
                        return AzMonListExtensions.s_dbSystems.Contains(dbSystem) ? "SQL" : dbSystem?.Truncate(SchemaConstants.RemoteDependencyData_Type_MaxLength);
                    }
                case OperationType.Rpc:
                    {
                        return AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeRpcSystem)?.ToString();
                    }
                case OperationType.Messaging:
                    {
                        return AzMonList.GetTagValue(ref tagObjects, SemanticConventions.AttributeMessagingSystem)?.ToString();
                    }
            }

            return "Unknown";
        }
    }
}
