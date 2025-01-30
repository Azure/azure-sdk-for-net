// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;

namespace Azure.Data.ConfidentialLedger.Tests.Helper
{
    public static class JSBundle
    {
        /// <summary>
        /// Creates a dictionary bundle with metadata and modules.
        /// </summary>
        /// <param name="moduleName">Name of the module (optional).</param>
        /// <param name="jsFilePath">Path to the JavaScript file (optional).</param>
        /// <returns>A dictionary representing the bundle. Returns an empty bundle if the file is missing.</returns>
        public static Dictionary<string, object> Create(string? moduleName = null, string? jsFilePath = null)
        {
            // If moduleName or jsFilePath is not provided, return an empty bundle
            if (string.IsNullOrEmpty(moduleName) || string.IsNullOrEmpty(jsFilePath))
            {
                return new Dictionary<string, object>
                {
                    ["metadata"] = new Dictionary<string, object> { ["endpoints"] = new Dictionary<string, object>() },
                    ["modules"] = new List<Dictionary<string, object>>()
                };
            }

            string moduleContent = string.Empty;

            // Read the module file if it exists
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
                    return new Dictionary<string, object>
                    {
                        ["metadata"] = new Dictionary<string, object> { ["endpoints"] = new Dictionary<string, object>() },
                        ["modules"] = new List<Dictionary<string, object>>()
                    };
                }
            }

            // Define endpoints dictionary only if the module content is not empty
            var endpoints = new Dictionary<string, object>
            {
                ["/content"] = new Dictionary<string, object>
                {
                    ["get"] = new Dictionary<string, object>
                    {
                        ["js_module"] = moduleName == null ? "" : moduleName,
                        ["js_function"] = "content",
                        ["forwarding_required"] = "never",
                        ["redirection_strategy"] = "none",
                        ["authn_policies"] = new List<string> { "no_auth" },
                        ["mode"] = "readonly",
                        ["openapi"] = new Dictionary<string, object>()
                    }
                }
            };

            // Define modules list only if the module content is not empty
            var modules = new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>
                    {
                        ["name"] = moduleName == null ? "" : moduleName,
                        ["module"] = moduleContent
                    }
                };

            // Construct the Bundle
            return new Dictionary<string, object>
            {
                ["metadata"] = new Dictionary<string, object> { ["endpoints"] = endpoints },
                ["modules"] = modules
            };
        }
    }
}
