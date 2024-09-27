// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning;

/// <summary>
/// Represents a composed collection of resources that can be compiled to bicep
/// source, saved to disk, compiled to an ARM template, linted, validated, and
/// deployed.
/// </summary>
/// <remarks>
/// Features that require the Bicep compiler or deployments are exposed via
/// extension methods in the Azure.Provisioning.Deployment package.
/// </remarks>
public partial class ProvisioningPlan
{
    /// <summary>
    /// Gets the provisioning context used to compose these resources.
    /// </summary>
    public ProvisioningContext ProvisioningContext { get; }

    /// <summary>
    /// Gets the resources to be composed.
    /// </summary>
    public Infrastructure Infrastructure { get; }

    internal ProvisioningPlan(Infrastructure infrastructure, ProvisioningContext context)
    {
        Infrastructure = infrastructure;
        ProvisioningContext = context;
    }

    // This is a placeholder until we get proper module splitting in place
    public IDictionary<string, string> Compile()
    {
        Dictionary<string, string> source = [];
        foreach (KeyValuePair<string, IEnumerable<Statement>> pair in Infrastructure.CompileModules(ProvisioningContext))
        {
            source[$"{pair.Key}.bicep"] = string.Join(Environment.NewLine, pair.Value).Trim();
        }
        return source;
    }

    // TODO: Support overloads taking callbacks for writing to arbitrary streams
    public IEnumerable<string> Save(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            throw new ArgumentException($"Directory {directoryPath} does not exist", nameof(directoryPath));
        }
        List<string> paths = [];
        foreach (KeyValuePair<string, string> pair in Compile())
        {
            string path = Path.Combine(directoryPath, pair.Key);
            File.WriteAllText(path, pair.Value);
            paths.Add(path);
        }
        return paths;
    }

    // TODO: Dump out az/ps scripts
    // TODO: Dump out azd template
    // TODO: Dump out Github actions
}
