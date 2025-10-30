// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Identity
{
    internal class KubernetesProxyConfig
    {
        public Uri ProxyUrl { get; private set; }
        public string CaFilePath { get; private set; }
        public string CaData { get; private set; }
        public string SniName { get; private set; }

        private KubernetesProxyConfig() { }

        /// <summary>
        /// Attempts to create a KubernetesProxyConfig from environment variables.
        /// This method should only be called when the user has explicitly enabled the feature.
        /// </summary>
        /// <returns>A valid config if proxy configuration is found, null if no configuration exists</returns>
        /// <exception cref="InvalidOperationException">Thrown when proxy configuration is invalid or incomplete</exception>
        public static KubernetesProxyConfig TryCreate()
        {
            string proxyUrl = EnvironmentVariables.AzureKubernetesTokenProxy;
            string caFile = EnvironmentVariables.AzureKubernetesCaFile;
            string caData = EnvironmentVariables.AzureKubernetesCaData;
            string sniName = EnvironmentVariables.AzureKubernetesSniName;

            // Check if any proxy configuration exists
            bool hasAnyConfig = !string.IsNullOrEmpty(proxyUrl) ||
                              !string.IsNullOrEmpty(caFile) ||
                              !string.IsNullOrEmpty(caData) ||
                              !string.IsNullOrEmpty(sniName);

            // If no configuration at all, return null (no proxy mode)
            if (!hasAnyConfig)
            {
                return null;
            }

            // Validate that proxy URL is present when other variables are set
            if (string.IsNullOrEmpty(proxyUrl))
            {
                throw new InvalidOperationException(
                    "AZURE_KUBERNETES_TOKEN_PROXY environment variable is not set but other proxy-related " +
                    "environment variables are present. This is likely a configuration issue.");
            }

            // Validate CA configuration is not ambiguous
            if (!string.IsNullOrEmpty(caFile) && !string.IsNullOrEmpty(caData))
            {
                throw new InvalidOperationException(
                    "Azure Kubernetes token proxy configuration is ambiguous. " +
                    "Both AZURE_KUBERNETES_CA_FILE and AZURE_KUBERNETES_CA_DATA are set. " +
                    "Please set only one of these environment variables.");
            }

            // Validate proxy URL format
            if (!Uri.TryCreate(proxyUrl, UriKind.Absolute, out Uri parsedUrl))
            {
                throw new InvalidOperationException(
                    $"AZURE_KUBERNETES_TOKEN_PROXY value '{proxyUrl}' is not a valid URL.");
            }

            // Validate HTTPS scheme
            if (!string.Equals(parsedUrl.Scheme, "https", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"AZURE_KUBERNETES_TOKEN_PROXY must use HTTPS scheme. Got: {parsedUrl.Scheme}");
            }

            // Validate no user info, query, or fragment
            if (!string.IsNullOrEmpty(parsedUrl.UserInfo))
            {
                throw new InvalidOperationException(
                    "AZURE_KUBERNETES_TOKEN_PROXY must not contain user info.");
            }

            if (!string.IsNullOrEmpty(parsedUrl.Query))
            {
                throw new InvalidOperationException(
                    "AZURE_KUBERNETES_TOKEN_PROXY must not contain query parameters.");
            }

            if (!string.IsNullOrEmpty(parsedUrl.Fragment))
            {
                throw new InvalidOperationException(
                    "AZURE_KUBERNETES_TOKEN_PROXY must not contain a fragment.");
            }

            // Validate CA file exists if specified (content validation happens at use time)
            if (!string.IsNullOrEmpty(caFile))
            {
                if (!File.Exists(caFile))
                {
                    throw new InvalidOperationException(
                        $"AZURE_KUBERNETES_CA_FILE path '{caFile}' does not exist.");
                }
            }

            // Basic validation for CA data if specified (detailed validation happens at use time)
            if (!string.IsNullOrEmpty(caData) && string.IsNullOrWhiteSpace(caData))
            {
                throw new InvalidOperationException(
                    "AZURE_KUBERNETES_CA_DATA is empty or contains only whitespace.");
            }

            return new KubernetesProxyConfig
            {
                ProxyUrl = parsedUrl,
                CaFilePath = caFile,
                CaData = caData,
                SniName = sniName
            };
        }

        /// <summary>
        /// Gets the CA certificate bundle content, either from the file or from the inline data.
        /// </summary>
        /// <returns>PEM-encoded certificate bundle, or null if no CA configuration exists</returns>
        public string GetCaCertificateContent()
        {
            if (!string.IsNullOrEmpty(CaData))
            {
                return CaData;
            }

            if (!string.IsNullOrEmpty(CaFilePath))
            {
                try
                {
                    return File.ReadAllText(CaFilePath);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"Failed to read CA certificate file at '{CaFilePath}': {ex.Message}", ex);
                }
            }

            return null;
        }
    }
}
