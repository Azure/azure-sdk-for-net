// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET8_0_OR_GREATER
using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;

namespace Azure.Core.Tests.IdentityBinding
{
    internal static class WorkloadIdentityBindingScenarioRunner
    {
        internal static async Task<int> RunAsync(string[] args)
        {
            string scenario = "configuration";
            try
            {
                Require(args.Length == 1 && (args[0] == "enabled" || args[0] == "disabled"),
                    "Specify enabled or disabled.");
                Require(typeof(WorkloadIdentityCredential).Assembly == typeof(TokenCredential).Assembly,
                    "The live tests must exercise the credential implementation in Azure.Core.");
                string tenantId = RequiredEnvironmentVariable("AZURE_TENANT_ID");
                string clientId = RequiredEnvironmentVariable("AZURE_CLIENT_ID");
                Require(Guid.TryParse(tenantId, out _) && Guid.TryParse(clientId, out _),
                    "Tenant and client IDs must be GUIDs.");
                Require(!string.IsNullOrWhiteSpace(File.ReadAllText(RequiredEnvironmentVariable("AZURE_FEDERATED_TOKEN_FILE"))),
                    "The projected token file must not be empty.");
                var authority = new Uri(RequiredEnvironmentVariable("AZURE_AUTHORITY_HOST"));
                Require(authority.Scheme == Uri.UriSchemeHttps, "The authority must use HTTPS.");
                var proxy = new Uri(RequiredEnvironmentVariable("AZURE_KUBERNETES_TOKEN_PROXY"));
                Require(proxy.Scheme == Uri.UriSchemeHttps && proxy.UserInfo.Length == 0 &&
                    proxy.Query.Length == 0 && proxy.Fragment.Length == 0, "The proxy URL must be HTTPS without credentials, query or fragment.");
                Require(Uri.CheckHostName(RequiredEnvironmentVariable("AZURE_KUBERNETES_SNI_NAME")) != UriHostNameType.Unknown,
                    "The proxy TLS host must be valid.");
                string caFile = Environment.GetEnvironmentVariable("AZURE_KUBERNETES_CA_FILE");
                string caData = Environment.GetEnvironmentVariable("AZURE_KUBERNETES_CA_DATA");
                Require(string.IsNullOrEmpty(caFile) != string.IsNullOrEmpty(caData),
                    "Exactly one proxy CA source is required.");
                using (X509Certificate2 ca = X509Certificate2.CreateFromPem(string.IsNullOrEmpty(caFile) ? caData : File.ReadAllText(caFile)))
                {
                    Require(ca.NotAfter.ToUniversalTime() > DateTime.UtcNow, "The proxy CA must not be expired.");
                }

                WriteResult("candidate", new
                {
                    coreVersion = typeof(TokenCredential).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion,
                    coreSha256 = AssemblyHash(typeof(TokenCredential).Assembly),
                    credentialAssembly = typeof(WorkloadIdentityCredential).Assembly.GetName().Name,
                    runtime = Environment.Version.ToString()
                });
                WriteResult(scenario, new { mode = args[0] });

                using var traffic = new ProxyTrafficListener(proxy);
                using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(4));
                var context = new TokenRequestContext(new[] { "https://management.azure.com/.default" });
                if (args[0] == "disabled")
                {
                    scenario = "disabled";
                    var credential = new WorkloadIdentityCredential(new WorkloadIdentityCredentialOptions { IsAzureProxyEnabled = false });
                    try
                    {
                        await credential.GetTokenAsync(context, timeout.Token).ConfigureAwait(false);
                    }
                    catch (AuthenticationFailedException exception)
                    {
                        string errorCode = GetEntraErrorCode(exception);
                        Require(errorCode == "AADSTS70021" || errorCode == "AADSTS700211" || errorCode == "AADSTS700213" || errorCode == "AADSTS70025",
                            $"Proxy-disabled authentication must fail with an expected missing-FIC error (observed: {errorCode ?? "none"}).");
                        Require(traffic.IsValid && traffic.Requests > 0 && traffic.ProxyRequests == 0,
                            "The disabled case must make direct HTTP requests and no proxy requests.");
                        WriteResult(scenario, new { errorCode, proxyRequests = traffic.ProxyRequests, httpRequests = traffic.Requests });
                        return 0;
                    }
                    throw new LiveTestFailureException("Proxy-disabled authentication unexpectedly succeeded.");
                }

                scenario = "async";
                var asyncCredential = new WorkloadIdentityCredential(new WorkloadIdentityCredentialOptions { IsAzureProxyEnabled = true });
                AccessToken token = await asyncCredential.GetTokenAsync(context, timeout.Token).ConfigureAwait(false);
                ValidateToken(token, tenantId, clientId);
                Require(traffic.IsValid && traffic.ProxyRequests > 0, "Async authentication must send requests over an actual proxy connection.");
                WriteResult(scenario, new { proxyRequests = traffic.ProxyRequests });

                scenario = "cache";
                long requestsBeforeCache = traffic.Requests;
                long proxyBeforeCache = traffic.ProxyRequests;
                AccessToken cached = await asyncCredential.GetTokenAsync(context, timeout.Token).ConfigureAwait(false);
                ValidateToken(cached, tenantId, clientId);
                Require(traffic.IsValid && cached.Token == token.Token && traffic.Requests == requestsBeforeCache && traffic.ProxyRequests == proxyBeforeCache,
                    "Cached acquisition must return the same token without an HTTP request.");
                WriteResult(scenario, new { additionalHttpRequests = traffic.Requests - requestsBeforeCache, additionalProxyRequests = traffic.ProxyRequests - proxyBeforeCache });

                scenario = "sync";
                long proxyBeforeSync = traffic.ProxyRequests;
                var syncCredential = new WorkloadIdentityCredential(new WorkloadIdentityCredentialOptions { IsAzureProxyEnabled = true });
                ValidateToken(syncCredential.GetToken(context, timeout.Token), tenantId, clientId);
                Require(traffic.IsValid && traffic.ProxyRequests > proxyBeforeSync, "Fresh synchronous authentication must send proxy requests.");
                WriteResult(scenario, new { additionalProxyRequests = traffic.ProxyRequests - proxyBeforeSync });

                scenario = "concurrent";
                long proxyBeforeConcurrent = traffic.ProxyRequests;
                var concurrentCredential = new WorkloadIdentityCredential(new WorkloadIdentityCredentialOptions { IsAzureProxyEnabled = true });
                AccessToken[] concurrentTokens = await Task.WhenAll(Enumerable.Range(0, 4)
                    .Select(_ => concurrentCredential.GetTokenAsync(context, timeout.Token).AsTask())).ConfigureAwait(false);
                foreach (AccessToken concurrentToken in concurrentTokens)
                {
                    ValidateToken(concurrentToken, tenantId, clientId);
                }
                Require(traffic.IsValid && traffic.ProxyRequests > proxyBeforeConcurrent, "Fresh concurrent authentication must send proxy requests.");
                WriteResult(scenario, new { calls = concurrentTokens.Length, additionalProxyRequests = traffic.ProxyRequests - proxyBeforeConcurrent });

                scenario = "arm-authentication";
                string resourceId = RequiredEnvironmentVariable("ARM_RESOURCE_ID");
                Require(Regex.IsMatch(resourceId, @"^/subscriptions/[0-9a-fA-F-]+/resourceGroups/[a-zA-Z0-9_.()-]+$"),
                    "ARM_RESOURCE_ID must identify the dedicated test resource group.");
                using var http = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Get, $"https://management.azure.com{resourceId}?api-version=2021-04-01");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                using HttpResponseMessage response = await http.SendAsync(request, timeout.Token).ConfigureAwait(false);
                Require(response.StatusCode == HttpStatusCode.Forbidden,
                    "ARM must return exactly 403 for the test identity without Azure roles.");
                using JsonDocument armError = JsonDocument.Parse(await response.Content.ReadAsStringAsync(timeout.Token).ConfigureAwait(false));
                Require(armError.RootElement.GetProperty("error").GetProperty("code").GetString() == "AuthorizationFailed",
                    "ARM must accept the token and report AuthorizationFailed, not an authentication error.");
                WriteResult(scenario, new { status = (int)response.StatusCode, errorCode = "AuthorizationFailed", proxyRequests = traffic.ProxyRequests });
                return 0;
            }
            catch (Exception exception)
            {
                // Authentication exception messages can contain assertions; report only controlled diagnostics.
                Console.WriteLine(JsonSerializer.Serialize(new
                {
                    scenario,
                    passed = false,
                    errorType = exception.GetType().Name,
                    reason = exception is LiveTestFailureException ? exception.Message : "See the failing scenario; sensitive exception details were omitted."
                }));
                return 1;
            }
        }
        private static void ValidateToken(AccessToken token, string tenantId, string clientId)
        {
            Require(!string.IsNullOrWhiteSpace(token.Token) && token.ExpiresOn > DateTimeOffset.UtcNow,
                "An acquired token must be nonempty and unexpired.");
            string[] segments = token.Token.Split('.');
            Require(segments.Length == 3, "The access token must be a JWT.");
            string payload = segments[1].Replace('-', '+').Replace('_', '/');
            payload = payload.PadRight((payload.Length + 3) / 4 * 4, '=');
            using JsonDocument claims = JsonDocument.Parse(Convert.FromBase64String(payload));
            JsonElement root = claims.RootElement;
            Require(string.Equals(root.GetProperty("tid").GetString(), tenantId, StringComparison.OrdinalIgnoreCase),
                "The token tenant must match the expected tenant.");
            JsonElement appId = root.TryGetProperty("appid", out JsonElement v1AppId) ? v1AppId : root.GetProperty("azp");
            Require(string.Equals(appId.GetString(), clientId, StringComparison.OrdinalIgnoreCase),
                "The token application must match the expected managed identity.");
            Require(DateTimeOffset.FromUnixTimeSeconds(root.GetProperty("exp").GetInt64()) > DateTimeOffset.UtcNow,
                "The JWT expiration must be in the future.");
        }

        private static string RequiredEnvironmentVariable(string name)
        {
            string value = Environment.GetEnvironmentVariable(name);
            Require(!string.IsNullOrWhiteSpace(value), $"{name} must be set.");
            return value;
        }

        private static string GetEntraErrorCode(Exception exception)
        {
            for (Exception current = exception; current != null; current = current.InnerException)
            {
                Match match = Regex.Match(current.Message, @"\bAADSTS\d+\b");
                if (match.Success)
                {
                    return match.Value;
                }
            }
            return null;
        }

        private static string AssemblyHash(Assembly assembly) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(assembly.Location)));

        private static void Require(bool condition, string message)
        {
            if (!condition)
            {
                throw new LiveTestFailureException(message);
            }
        }

        private static void WriteResult(string scenario, object details)
        {
            Console.WriteLine(JsonSerializer.Serialize(new { scenario, passed = true, details }));
        }

        private sealed class LiveTestFailureException : Exception
        {
            internal LiveTestFailureException(string message) : base(message) { }
        }

        private sealed class ProxyTrafficListener : EventListener
        {
            private readonly Uri _proxy;
            private readonly ConcurrentDictionary<long, bool> _connections = new();
            private long _requests;
            private long _proxyRequests;
            private int _invalidEvent;

            internal ProxyTrafficListener(Uri proxy) => _proxy = proxy;

            internal long Requests => Interlocked.Read(ref _requests);
            internal long ProxyRequests => Interlocked.Read(ref _proxyRequests);
            internal bool IsValid => Volatile.Read(ref _invalidEvent) == 0;

            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                if (eventSource.Name == "System.Net.Http")
                {
                    EnableEvents(eventSource, EventLevel.Informational, EventKeywords.None);
                }
            }

            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                if (_proxy == null || eventData.Payload == null || eventData.PayloadNames == null)
                {
                    return;
                }

                if (eventData.EventName == "RequestStart")
                {
                    Interlocked.Increment(ref _requests);
                }
                else if (eventData.EventName == "ConnectionEstablished")
                {
                    if (TryGetPayload(eventData, "connectionId", out long id) &&
                        TryGetPayload(eventData, "scheme", out string scheme) &&
                        TryGetPayload(eventData, "host", out string host) &&
                        TryGetPayload(eventData, "port", out int port))
                    {
                        _connections[id] = scheme == Uri.UriSchemeHttps && string.Equals(host, _proxy.IdnHost, StringComparison.OrdinalIgnoreCase) && port == _proxy.Port;
                    }
                    else
                    {
                        Interlocked.Exchange(ref _invalidEvent, 1);
                    }
                }
                else if (eventData.EventName == "RequestHeadersStart")
                {
                    // RequestStart precedes the handler's URL rewrite; the established connection proves routing.
                    if (TryGetPayload(eventData, "connectionId", out long id) && _connections.TryGetValue(id, out bool isProxy))
                    {
                        if (isProxy)
                        {
                            Interlocked.Increment(ref _proxyRequests);
                        }
                    }
                    else
                    {
                        Interlocked.Exchange(ref _invalidEvent, 1);
                    }
                }
            }

            private static bool TryGetPayload<T>(EventWrittenEventArgs eventData, string name, out T value)
            {
                int index = eventData.PayloadNames.IndexOf(name);
                if (index >= 0 && eventData.Payload[index] is T typedValue)
                {
                    value = typedValue;
                    return true;
                }
                value = default;
                return false;
            }
        }
    }
}
#endif
