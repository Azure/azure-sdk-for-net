// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Resources;
using Azure.ResourceManager;

namespace Azure.Provisioning
{
    /// <summary>
    /// Represents an Azure resource to be provisioned.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Resource : IPersistableModel<Resource>
#pragma warning restore AZC0012 // Avoid single word type names
    {
        internal Dictionary<object, Dictionary<string, string>> ParameterOverrides { get; }

        private IList<Resource> Dependencies { get; }

        internal void AddDependency(Resource resource)
        {
            Dependencies.Add(resource);
        }

        /// <summary>
        /// Gets the parent <see cref="Resource"/>.
        /// </summary>
        public Resource? Parent { get; }
        private protected object ResourceData { get; }
        /// <summary>
        /// Gets the version of the resource.
        /// </summary>
        public string Version { get; }
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        public string Name { get; }

        private ResourceType ResourceType { get; }
        /// <summary>
        /// Gets the <see cref="ResourceIdentifier"/> of the resource.
        /// </summary>
        public ResourceIdentifier Id { get; }

        /// <summary>
        /// Gets the <see cref="IConstruct"/> scope of the resource.
        /// </summary>
        public IConstruct Scope { get; }
        /// <summary>
        /// Gets the parameters of the resource.
        /// </summary>
        public IList<Parameter> Parameters { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource"/>.
        /// </summary>
        /// <param name="scope">The resource scope.</param>
        /// <param name="parent">The resource parent.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="version">The resource version.</param>
        /// <param name="createProperties">Lambda to create the ARM properties.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="scope"/> is null.</exception>
        protected Resource(IConstruct scope, Resource? parent, string resourceName, ResourceType resourceType, string version, Func<string, object> createProperties)
        {
            if (scope is null) throw new ArgumentNullException(nameof(scope));

            var azureName = GetAzureName(scope, resourceName);
            Scope = scope;
            Parameters = new List<Parameter>();
            Parent =  parent ?? FindParentInScope(scope);
            Scope.AddResource(this);
            ResourceData = createProperties(azureName);
            Version = version;
            ParameterOverrides = new Dictionary<object, Dictionary<string, string>>();
            Dependencies = new List<Resource>();
            ResourceType = resourceType;
            Id = Parent is null
                ? ResourceIdentifier.Root
                : Parent is ResourceGroup
                    ? Parent.Id.AppendProviderResource(ResourceType.Namespace, ResourceType.GetLastType(), azureName)
                    : Parent.Id.AppendChildResource(ResourceType.GetLastType(), azureName);
            Name = GetHash();
        }

        /// <summary>
        /// Validate and sanitize the resource name.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <returns>Sanitized resource name.</returns>
        /// <exception cref="ArgumentException">If the resource name violates rules that cannot be sanitized.</exception>
        protected virtual string GetAzureName(IConstruct scope, string resourceName)
        {
            var span = resourceName.AsSpan();
            if (!char.IsLetter(span[0]))
            {
                throw new ArgumentException("Resource name must start with a letter", nameof(resourceName));
            }
            if (!char.IsLetterOrDigit(span[span.Length - 1]))
            {
                throw new ArgumentException("Resource name must end with a letter or digit", nameof(resourceName));
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < span.Length; i++)
            {
                char c = span[i];
                if (!char.IsLetterOrDigit(c) && c != '-')
                {
                    continue;
                }
                stringBuilder.Append(c);
            }

            stringBuilder.Append('-');
            stringBuilder.Append(scope.EnvironmentName);
            return stringBuilder.ToString(0, Math.Min(stringBuilder.Length, 24));
        }

        /// <summary>
        /// Finds the parent resource in the scope.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <returns>The parent <see cref="Resource"/>.</returns>
        protected virtual Resource? FindParentInScope(IConstruct scope)
        {
            return scope is Resource resource ? resource : null;
        }

        /// <summary>
        /// Assigns a property of the resource to a <see cref="Parameter"/>.
        /// </summary>
        /// <param name="instance">The property instance.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="parameter">The <see cref="Parameter"/> to assign.</param>
        public void AssignParameter(object instance, string propertyName, Parameter parameter)
        {
            if (ParameterOverrides.TryGetValue(instance, out var overrides))
            {
                overrides[propertyName] = parameter.Name;
            }
            else
            {
                ParameterOverrides.Add(instance, new Dictionary<string, string> {  { propertyName, parameter.Name } });
            }
            Parameters.Add(parameter);
        }

        /// <summary>
        /// Adds an output to the resource.
        /// </summary>
        /// <param name="name">The name of the output.</param>
        /// <param name="propertyName">The property name to output.</param>
        /// <param name="isLiteral">Is the output literal.</param>
        /// <param name="isSecure">Is the output secure.</param>
        /// <returns>The <see cref="Output"/>.</returns>
        /// <exception cref="ArgumentException">If the <paramref name="propertyName"/> is not found on the resources properties.</exception>
        public Output AddOutput(string name, string propertyName, bool isLiteral = false, bool isSecure = false)
        {
            string? reference = GetReference(ResourceData.GetType(), propertyName, Name.ToCamelCase());
            if (reference is null)
                throw new ArgumentException(nameof(propertyName), $"{propertyName} was not found in the property tree for {ResourceData.GetType().Name}");
            var result = new Output(name, reference, Scope, isLiteral, isSecure);
            Scope.AddOutput(result);
            return result;
        }

        private static string? GetReference(Type type, string propertyName, string str)
        {
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.Name.Equals(propertyName, StringComparison.Ordinal))
                {
                    return $"{str}.{property.Name.ToCamelCase()}";
                }
            }

            //need to check next level
            foreach (var property in properties)
            {
                var result = GetReference(property.PropertyType, propertyName, $"{str}.{property.Name.ToCamelCase()}");
                if (result is not null)
                    return result;
            }

            return null;
        }

        BinaryData IPersistableModel<Resource>.Write(ModelReaderWriterOptions options) => options.Format switch
        {
            "bicep" => SerializeModule(options),
            _ => throw new FormatException($"Unsupported format {options.Format}")
        };

        private BinaryData SerializeModule(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();

            stream.WriteLine($"resource {Name} '{ResourceType}@{Version}' = {{");

            if (this.IsChildResource() && this is not DeploymentScript)
            {
                stream.WriteLine($"  parent: {Parent!.Name}");
            }
            else if (NeedsScope())
            {
                stream.WriteLine($"  scope: {Parent!.Name}");
            }

            if (Dependencies.Count > 0)
            {
                stream.WriteLine($"  dependsOn: [");
                foreach (var dependency in Dependencies)
                {
                    stream.WriteLine($"    {dependency.Name}");
                }
                stream.WriteLine($"  ]");
            }

            var bicepOptions = new BicepModelReaderWriterOptions();
            foreach (var parameter in ParameterOverrides)
            {
                bicepOptions.ParameterOverrides.Add(parameter.Key, parameter.Value);
            }
            var data = ModelReaderWriter.Write(ResourceData, bicepOptions).ToMemory();

#if NET6_0_OR_GREATER
            WriteLines(0, BinaryData.FromBytes(data[2..]), stream, this);
#else
            WriteLines(0, BinaryData.FromBytes(data.Slice(2).ToArray()), stream, this);
#endif

            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        private bool NeedsScope()
        {
            switch (Parent)
            {
                case ResourceGroup _:
                    return Scope.ConstructScope != ConstructScope.ResourceGroup;
                case Subscription _:
                    return Scope.ConstructScope != ConstructScope.Subscription;
                case Tenant _:
                    return Scope.ConstructScope != ConstructScope.Tenant;
                default:
                    return Scope.ConstructScope != ConstructScope.ResourceGroup;
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
                line = line.Slice(start);
                int end = line.IndexOf(':');
                if (end > 0)
                {
                    string name = line.Slice(0, end).ToString();
                    // if (resource.ParameterOverrides.TryGetValue(name, out var value))
                    // {
                    //     lineToWrite = $"{new string(' ', start)}{name}: {value}";
                    // }
                }
                stream.WriteLine($"{indent}{lineToWrite}");
            }
        }

        Resource IPersistableModel<Resource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        internal string GetHash()
        {
            string fullScope = $"{GetScopedName(this, Id.Name)}";
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(fullScope));

                // Convert the hash bytes to a base64 string and take the first 8 characters
                string base64Hash = Convert.ToBase64String(hashBytes);
                return $"{GetType().Name.ToCamelCase()}_{GetAlphaNumeric(base64Hash, 8)}";
            }
        }

        private string GetAlphaNumeric(string base64Hash, int chars)
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            while (sb.Length <= chars && index < base64Hash.Length)
            {
                if (char.IsLetterOrDigit(base64Hash[index]))
                    sb.Append(base64Hash[index]);
                index++;
            }
            return sb.ToString();
        }

        private static string GetScopedName(Resource resource, string scopedName)
        {
            Resource? parent = resource.Parent;

            return parent is null || parent is Tenant ? scopedName : GetScopedName(parent, $"{parent.Id.Name}_{scopedName}");
        }

        string IPersistableModel<Resource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "bicep";
    }
}
