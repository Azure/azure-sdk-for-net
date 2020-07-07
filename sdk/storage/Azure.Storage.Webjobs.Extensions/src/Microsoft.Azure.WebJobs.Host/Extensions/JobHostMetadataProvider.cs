// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host
{
    // Provides additional bookkeeping on extensions 
    internal class JobHostMetadataProvider : IJobHostMetadataProvider
    {
        // Map from binding types to their corresponding attribute. 
        private readonly IDictionary<string, Type> _attributeTypes = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        // Map of simple assembly name to assembly.
        private readonly Dictionary<string, Assembly> _resolvedAssemblies = new Dictionary<string, Assembly>(StringComparer.OrdinalIgnoreCase);

        private IBindingProvider _root;

        private readonly IFunctionIndexProvider _functionIndexProvider;
        private readonly IExtensionRegistry _extensionRegistry;
        private readonly IBindingProvider _bindingProvider;
        private readonly IConverterManager _converter;

        public JobHostMetadataProvider(IFunctionIndexProvider functionIndexProvider, IExtensionRegistry extensionRegistry, IBindingProvider bindingProvider, IConverterManager converter)
        {
            _functionIndexProvider = functionIndexProvider;
            _extensionRegistry = extensionRegistry;
            _bindingProvider = bindingProvider;
            _converter = converter;
        }

        internal void Initialize()
        {
            foreach (var extension in _extensionRegistry.GetExtensions<IExtensionConfigProvider>())
            {
                this.AddExtension(extension);
            }

            this._root = _bindingProvider;

            // Populate assembly resolution from converters.            
            if (_converter != null)
            {
               // _converter.AddAssemblies((type) => AddAssembly(type));
            }

            AddTypesFromGraph(_bindingProvider as IBindingRuleProvider);
        }

        // Resolve an assembly from the given name. 
        // Name could be the short name or full name. 
        //    Name
        //    Name, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
        public bool TryResolveAssembly(string assemblyName, out Assembly assembly)
        {
            // Give precedence to the full name. This can be important if multiple assemblies are loaded side-by-side.
            if (!_resolvedAssemblies.TryGetValue(assemblyName, out assembly))
            {
                // If full name fails, try on just the short name. 
                var nameOnly = new AssemblyName(assemblyName).Name;
                _resolvedAssemblies.TryGetValue(nameOnly, out assembly);
            }
            return assembly != null;
        }

        // USed by core extensions where the attribute lives in a different assembly than the extension. 
        internal void AddAttributesFromAssembly(Assembly asm)
        {
            var attributeTypes = GetAttributesFromAssembly(asm);
            foreach (var attributeType in attributeTypes)
            {
                string bindingName = GetNameFromAttribute(attributeType);
                this._attributeTypes[bindingName] = attributeType;
            }
        }

        private static IEnumerable<Type> GetAttributesFromAssembly(Assembly assembly)
        {
            foreach (var type in assembly.GetExportedTypes())
            {
                if (typeof(Attribute).IsAssignableFrom(type))
                {
                    if (type.GetCustomAttribute(typeof(BindingAttribute)) != null)
                    {
                        yield return type;
                    }
                }
            }
        }

        // Do extra bookkeeping for a new extension. 
        public void AddExtension(IExtensionConfigProvider extension)
        {
            AddAttributesFromAssembly(extension.GetType().Assembly);
            AddAssembly(extension.GetType());
        }

        private void AddAssembly(Type type)
        {
            AddAssembly(type.Assembly);
        }

        private void AddAssembly(Assembly assembly)
        {
            AssemblyName name = AssemblyNameCache.GetName(assembly);
            _resolvedAssemblies[name.FullName] = assembly;
            _resolvedAssemblies[name.Name] = assembly;
        }

        // By convention, typeof(EventHubAttribute) --> "EventHub"
        private static string GetNameFromAttribute(Type attributeType)
        {
            string fullname = attributeType.Name; // no namespace
            const string Suffix = "Attribute";

            if (!fullname.EndsWith(Suffix, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException($"Attribute type '{fullname}' must end in 'Attribute'");
            }
            string name = fullname.Substring(0, fullname.Length - Suffix.Length);
            return name;
        }

        public Type GetAttributeTypeFromName(string name)
        {
            Type attrType;
            if (_attributeTypes.TryGetValue(name, out attrType))
            {
                return attrType;
            }
            return null;
        }

        public Attribute GetAttribute(Type attributeType, JObject metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            metadata = Touchups(attributeType, metadata);

            var resolve = AttributeCloner.CreateDirect(attributeType, metadata);
            return resolve;
        }

        // Handle touchups where automatically conversion would break. 
        // Ideally get rid of this method by either 
        // a) removing the inconsistencies
        // b) having some hook that lets the extension handle it. 
        private static JObject Touchups(Type attributeType, JObject metadata)
        {
            metadata = (JObject)metadata.DeepClone(); // avoid mutating the inpout 

            JToken token;
            if (attributeType.Name == "BlobAttribute" ||
                attributeType.Name == "BlobTriggerAttribute")
            {
                // Path --> BlobPath
                if (metadata.TryGetValue("path", StringComparison.OrdinalIgnoreCase, out token))
                {
                    metadata["BlobPath"] = token;
                }
            }

            if (string.Equals(attributeType.Name, "ServiceBusAttribute", StringComparison.OrdinalIgnoreCase))
            {
                // queueName --> queueOrTopicName, topicName --> queueOrTopicName
                if (metadata.TryGetValue("queueName", StringComparison.OrdinalIgnoreCase, out token))
                {
                    metadata["queueOrTopicName"] = token;
                    metadata["entityType"] = "Queue";
                }
                else if (metadata.TryGetValue("topicName", StringComparison.OrdinalIgnoreCase, out token))
                {
                    metadata["queueOrTopicName"] = token;
                    metadata["entityType"] = "Topic";
                }
            }

            // Other "look like a stream" attributes may expose an Access property for stream direction. 
            var prop = attributeType.GetProperty("Access", BindingFlags.Instance | BindingFlags.Public);
            if (prop != null)
            {
                if (prop.PropertyType == typeof(FileAccess?))
                {
                    if (metadata.TryGetValue("direction", StringComparison.OrdinalIgnoreCase, out token))
                    {
                        FileAccess access;
                        switch (token.ToString().ToLowerInvariant())
                        {
                            case "in":
                                access = FileAccess.Read;
                                break;
                            case "out":
                                access = FileAccess.Write;
                                break;
                            case "inout":
                                access = FileAccess.ReadWrite;
                                break;
                            default:
                                throw new InvalidOperationException($"Illegal direction value: '{token}'");
                        }
                        metadata["access"] = access.ToString();
                    }
                }
            }

            return metadata;
        }

        // Get a better implementation 
        public Type GetDefaultType(
            Attribute attribute,
            FileAccess access, // direction In, Out, In/Out
            Type requestedType) // combination of Cardinality and DataType.
        {
            if (attribute == null)
            {
                throw new ArgumentNullException(nameof(attribute));
            }
            if (requestedType == null)
            {
                requestedType = typeof(object);
            }
            var providers = this._root;

            IBindingRuleProvider root = (IBindingRuleProvider)providers;
            var type = root.GetDefaultType(attribute, access, requestedType);

            if (type == null)
            {
                if (access == FileAccess.Read)
                {
                    // For input bindings, if we have a specific requested type, then return and try to bind against that. 
                    // ITriggerBindingProvider doesn't provide rules.
                    if (requestedType != typeof(object))
                    {
                        return requestedType;
                    }
                    else
                    {
                        // common default. If binder doesn't support this, it will fail later in the pipeline. 
                        return typeof(String);
                    }
                }

                // IBindingProvider does not provide rules. Attempt to use IAsyncCollector<string>.
                if (access == FileAccess.Write)
                {
                    return typeof(IAsyncCollector<string>);
                }
            }

            if (type == null)
            {
                throw new InvalidOperationException($"Can't bind {attribute.GetType().Name} to a script-compatible type for {access} access" +
                    ((requestedType != null) ? $" to { requestedType.Name }." : "."));
            }
            return type;
        }

        public BindingRule[] GetRules()
        {
            var providers = this._root;

            IBindingRuleProvider root = (IBindingRuleProvider)providers;
            return root.GetRules().ToArray();
        }

        /// <summary>
        /// Debug helper to dump the entire extension graph 
        /// </summary>        
        public void DebugDumpGraph(TextWriter output)
        {
            var providers = this._root;

            IBindingRuleProvider root = (IBindingRuleProvider)providers;
            DumpRule(root, output);
        }

        internal static void DumpRule(IBindingRuleProvider root, TextWriter output)
        {
            foreach (var rule in root.GetRules())
            {
                var attr = rule.SourceAttribute;

                output.Write($"[{attr.Name}] -->");
                if (rule.Filter != null)
                {
                    output.Write($"[filter: {rule.Filter}]-->");
                }

                if (rule.Converters != null)
                {
                    foreach (var converterType in rule.Converters)
                    {
                        output.Write($"{OpenType.ExactMatch.TypeToString(converterType)}-->");
                    }
                }

                output.Write(rule.UserType.GetDisplayName());
                output.WriteLine();
            }
        }

        private void AddTypesFromGraph(IBindingRuleProvider root)
        {
            foreach (var rule in root.GetRules())
            {
                var type = rule.UserType as OpenType.ExactMatch;
                if (type != null)
                {
                    AddAssembly(type.ExactType);
                }
            }
        }

        public FunctionMetadata GetFunctionMetadata(string functionName)
        {
            FunctionMetadata result = null;

            var index = _functionIndexProvider.GetAsync(CancellationToken.None).GetAwaiter().GetResult();
            var functionDefinition = index.LookupByName(functionName);
            if (functionDefinition != null)
            {
                result = new FunctionMetadata()
                {
                    IsDisabled = functionDefinition.Descriptor.IsDisabled
                };
            }

            return result;
        }
    }
}
