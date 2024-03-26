// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning
{
    internal class ModuleConstruct : Construct
    {
        public ModuleConstruct(ModuleResource resource)
            : base(
                resource.Scope,
                GetConstructName(resource.Resource),
                ResourceToConstructScope(resource.Resource),
                tenant: GetTenant(resource.Resource),
                subscription: GetSubscription(resource.Resource),
                resourceGroup: resource.Resource as ResourceGroup)
        {
        }

        private static string GetConstructName(Resource resource)
        {
            var prefix = resource is Subscription ? resource.Name : resource.Id.Name.Replace('-', '_');
            return $"{prefix}_module";
        }

        private string GetScopeName()
        {
            return ResourceGroup?.Name ?? (Subscription != null ? $"subscription('{Subscription.Name}')" : "tenant()");
        }

        public bool IsRoot { get; set; }

        private static Tenant? GetTenant(Resource resource)
        {
            return resource switch
            {
                Tenant tenant => tenant,
                Subscription sub => (Tenant) sub.Parent!,
                ResourceGroup rg => (Tenant) rg.Parent!.Parent!,
                _ => null,
            };
        }

        private static Subscription? GetSubscription(Resource resource)
        {
            return resource switch
            {
                Subscription subscription => subscription,
                ResourceGroup rg => (Subscription) rg.Parent!,
                _ => null,
            };
        }

        private static ConstructScope ResourceToConstructScope(Resource resource)
        {
            return resource switch
            {
                ResourceManager.Tenant => ConstructScope.Tenant,
                ResourceManager.Subscription => ConstructScope.Subscription,
                //TODO managementgroup support
                ResourceManager.ResourceGroup => ConstructScope.ResourceGroup,
                _ => throw new InvalidOperationException(),
            };
        }

        public BinaryData SerializeModuleReference()
        {
            using var stream = new MemoryStream();
            stream.WriteLine($"module {Name} './resources/{Name}/{Name}.bicep' = {{");
            stream.WriteLine($"  name: '{Name}'");
            stream.WriteLine($"  scope: {GetScopeName()}");

            var parametersToWrite = new HashSet<Parameter>();
            var outputs = new HashSet<Output>(GetOutputs());
            foreach (var p in GetParameters(false))
            {
                if (!ShouldExposeParameter(p, outputs))
                {
                    continue;
                }
                parametersToWrite.Add(p);
            }
            if (parametersToWrite.Count > 0)
            {
                stream.WriteLine($"  params: {{");
                foreach (var parameter in parametersToWrite)
                {
                    stream.WriteLine($"    {parameter.Name}: {parameter.GetParameterString(Scope!)}");
                }
                stream.WriteLine($"  }}");
            }
            stream.WriteLine($"}}");

            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        public BinaryData SerializeModule()
        {
            using var stream = new MemoryStream();
            var options = new ModelReaderWriterOptions("bicep");

            WriteScopeLine(stream);

            WriteParameters(stream);

            WriteExistingResources(stream);

            foreach (var resource in GetResources(false))
            {
                if (resource.IsExisting)
                {
                    continue;
                }
                if (resource is Tenant)
                {
                    continue;
                }
                if (resource is ResourceGroup && resource.Id.Name == ResourceGroup.ResourceGroupFunction)
                {
                    continue;
                }

                stream.WriteLine();
                WriteLines(0, ModelReaderWriter.Write(resource, options), stream, resource);
            }

            foreach (var construct in GetConstructs(false).Select(c => (ModuleConstruct)c))
            {
                stream.WriteLine();
                stream.Write(construct.SerializeModuleReference().ToArray());
            }

            WriteOutputs(stream);

            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        private void WriteExistingResources(MemoryStream stream)
        {
            foreach (var resource in GetResources(false).Where(r => r.IsExisting))
            {
                stream.WriteLine();
                stream.WriteLine($"resource {resource.Name} '{resource.Id.ResourceType}@{resource.Version}' existing = {{");

                var name = resource.Parent is not ResourceManager.ResourceGroup && resource.Id.Name.StartsWith("'")
                    // child resource with a literal name
                    ? $"'${{{resource.Parent!.Name}}}/{resource.Id.Name.Substring(1, resource.Id.Name.Length - 2)}'"
                    : resource.Parent is not ResourceManager.ResourceGroup
                        // child resource with a parameterized name
                        ? $"'${{{resource.Parent!.Name}}}/${{{resource.Id.Name}}}'"
                        // parent resource with literal or parameterized name
                        : resource.Id.Name;

                stream.WriteLine($"  name: {name}");

                stream.WriteLine($"}}");
            }
        }

        private void WriteScopeLine(MemoryStream stream)
        {
            if (ConstructScope != ConstructScope.ResourceGroup || IsRoot)
            {
                stream.WriteLine($"targetScope = '{ConstructScope.ToString().ToCamelCase()}'{Environment.NewLine}");
            }
        }

        internal void WriteOutputs(MemoryStream stream)
        {
            if (GetOutputs().Any())
            {
                stream.WriteLine();
            }

            var outputsToWrite = new HashSet<Output>();
            GetAllOutputsRecursive(this, outputsToWrite, false);
            foreach (var output in outputsToWrite)
            {
                string value;
                if (output.IsLiteral || ReferenceEquals(this, output.Resource.ModuleScope))
                {
                    value = output.IsLiteral ? $"'{output.Value}'" : output.Value;
                }
                else
                {
                    value = $"{output.Resource.ModuleScope!.Name}.outputs.{output.Name}";
                }
                string name = output.Name;
                stream.WriteLine($"output {name} string = {value}");
            }
        }

        private void GetAllOutputsRecursive(IConstruct construct, HashSet<Output> visited, bool isChild)
        {
            if (!isChild)
            {
                foreach (var output in construct.GetOutputs())
                {
                    if (!visited.Contains(output))
                    {
                        visited.Add(output);
                    }
                }
            }
        }

        private void WriteParameters(MemoryStream stream)
        {
            var parametersToWrite = new HashSet<Parameter>();
            GetAllParametersRecursive(this, parametersToWrite, false);
            var outputs = new HashSet<Output>(GetOutputs());
            foreach (var parameter in parametersToWrite)
            {
                if (!ShouldExposeParameter(parameter, outputs))
                {
                    continue;
                }
                string defaultValue =
                    parameter.DefaultValue is null ?
                        string.Empty :
                        parameter.IsExpression ? $" = {parameter.DefaultValue}" : $" = '{parameter.DefaultValue}'";

                if (parameter.IsSecure)
                    stream.WriteLine($"@secure()");

                stream.WriteLine($"@description('{parameter.Description}')");
                stream.WriteLine($"param {parameter.Name} string{defaultValue}{Environment.NewLine}");
            }
        }

        private bool ShouldExposeParameter(Parameter parameter, HashSet<Output> outputs)
        {
            // Don't expose the parameter if the output that was used to create the parameter is already in scope.
            return parameter.Output == null || !outputs.Contains(parameter.Output);
        }

        private void GetAllParametersRecursive(IConstruct construct, HashSet<Parameter> visited, bool isChild)
        {
            if (!isChild)
            {
                foreach (var parameter in construct.GetParameters())
                {
                    if (!visited.Contains(parameter))
                    {
                        visited.Add(parameter);
                    }
                }
                foreach (var child in construct.GetConstructs(false))
                {
                    GetAllParametersRecursive(child, visited, isChild);
                }
            }
        }

        private static void WriteLines(int depth, BinaryData data, MemoryStream stream, Resource resource)
        {
            string indent = new string(' ', depth * 2);
            string[] lines = data.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                string lineToWrite = lines[i];

                ReadOnlySpan<char> line = lines[i].AsSpan();
                int start = 0;
                while (line.Length > start && line[start] == ' ')
                {
                    start++;
                }
                stream.WriteLine($"{indent}{lineToWrite}");
            }
        }
    }
}
