// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using static Azure.Security.ConfidentialLedger.Tests.ConfidentialLedgerClientLiveTests;

namespace Azure.Data.ConfidentialLedger.Tests.Helper
{
    internal static class JSBundle
    {
        /// <summary>
        /// Creates a bundle with metadata and modules.
        /// </summary>
        /// <param name="moduleName">Name of the module (optional).</param>
        /// <param name="jsFilePath">Path to the JavaScript file (optional).</param>
        /// <returns>A undle. Returns an empty bundle if the file is missing.</returns>
        internal static Bundle Create(string? moduleName = null, string? jsFilePath = null)
        {
            // If moduleName or jsFilePath is not provided, return an empty bundle
            if (string.IsNullOrEmpty(moduleName) || string.IsNullOrEmpty(jsFilePath))
            {
                return new Bundle();
            }

            string moduleContent = string.Empty;

            // Read the module file if it exists
            Console.WriteLine($"JSFile Exists: {File.Exists(jsFilePath)}");
            if (File.Exists(jsFilePath))
            {
                try
                {
                    moduleContent = File.ReadAllText(jsFilePath);
                }
                catch (Exception ex)
                {
                    // Log or return an error message if the file cannot be read
                    Console.WriteLine($" Error reading file {jsFilePath}: {ex.Message}");
                    return new Bundle();
                }
            }

            // Define modules list only if the module content is not empty
            var modules = new List<Module> { new Module { Name = moduleName, ModuleContent = moduleContent } };

            var bundle = new Bundle
            {
                Metadata = new Metadata
                {
                    Endpoints = new Dictionary<string, Dictionary<string, Endpoint>>
                    {
                        [_userDefinedEndpoint] = new Dictionary<string, Endpoint>
                        {
                            ["get"] = new Endpoint
                            {
                                JsModule = moduleName,
                                JsFunction = "content",
                                ForwardingRequired = "never",
                                RedirectionStrategy = "none",
                                AuthnPolicies = new List<string> { "no_auth" },
                                Mode = "readonly",
                                OpenApi = new Dictionary<string, object>()
                            }
                        }
                    }
                },
                Modules = modules,
            };

            return bundle;
        }
    }
}
