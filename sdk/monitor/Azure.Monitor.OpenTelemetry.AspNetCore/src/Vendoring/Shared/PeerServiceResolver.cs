// <copyright file="PeerServiceResolver.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

#nullable enable

using System.Runtime.CompilerServices;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter;

internal static class PeerServiceResolver
{
    private static readonly Dictionary<string, int> PeerServiceKeyResolutionDictionary = new(StringComparer.OrdinalIgnoreCase)
    {
        [SemanticConventions.AttributePeerService] = 0, // priority 0 (highest).
        ["peer.hostname"] = 1,
        ["peer.address"] = 1,
        [SemanticConventions.AttributeHttpHost] = 2, // peer.service for Http.
        [SemanticConventions.AttributeDbInstance] = 2, // peer.service for Redis.
    };

    public interface IPeerServiceState
    {
        string? PeerService { get; set; }

        int? PeerServicePriority { get; set; }

        string? HostName { get; set; }

        string? IpAddress { get; set; }

        long Port { get; set; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InspectTag<T>(ref T state, string key, string? value)
        where T : struct, IPeerServiceState
    {
        if (PeerServiceKeyResolutionDictionary.TryGetValue(key, out int priority)
            && (state.PeerService == null || priority < state.PeerServicePriority))
        {
            state.PeerService = value;
            state.PeerServicePriority = priority;
        }
        else if (key == SemanticConventions.AttributeNetPeerName)
        {
            state.HostName = value;
        }
        else if (key == SemanticConventions.AttributeNetPeerIp)
        {
            state.IpAddress = value;
        }
        else if (key == SemanticConventions.AttributeNetPeerPort && long.TryParse(value, out var port))
        {
            state.Port = port;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InspectTag<T>(ref T state, string key, long value)
        where T : struct, IPeerServiceState
    {
        if (key == SemanticConventions.AttributeNetPeerPort)
        {
            state.Port = value;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Resolve<T>(ref T state, out string? peerServiceName, out bool addAsTag)
        where T : struct, IPeerServiceState
    {
        peerServiceName = state.PeerService;

        // If priority = 0 that means peer.service was included in tags
        addAsTag = state.PeerServicePriority != 0;

        if (addAsTag)
        {
            var hostNameOrIpAddress = state.HostName ?? state.IpAddress;

            // peer.service has not already been included, but net.peer.name/ip and optionally net.peer.port are present
            if (hostNameOrIpAddress != null)
            {
                peerServiceName = state.Port == default
                    ? hostNameOrIpAddress
                    : $"{hostNameOrIpAddress}:{state.Port}";
            }
            else if (state.PeerService != null)
            {
                peerServiceName = state.PeerService;
            }
        }
    }
}
