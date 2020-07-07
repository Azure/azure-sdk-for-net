// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Analyzer
{
    // Only support extensions and WebJobs core.
    // Although extensions may refer to other dlls. 
    public class AssemblyCache
    {
        // Map from assembly identities to full paths 
        public static AssemblyCache Instance = new AssemblyCache();

        bool _registered;

        // Assembly Display Name --> Path. 
        Dictionary<string, string> _map = new Dictionary<string, string>();

        // Assembly Display Name --> loaded Assembly object. 
        Dictionary<string, Assembly> _mapRef = new Dictionary<string, Assembly>();

        const string WebJobsAssemblyName = "Microsoft.Azure.WebJobs";
        const string WebJobsHostAssemblyName = "Microsoft.Azure.WebJobs.Host";

        JobHostMetadataProvider _tooling;

        internal JobHostMetadataProvider Tooling => _tooling;
        private int _projectCount;

        // $$$ This can get invoked multiple times concurrently 
        // This will get called on every compilation. 
        // So return early on subseuqnet initializations. 
        internal void Build(Compilation compilation)
        {
            Register();

            int count;
            lock (this)
            {
                // If project references have changed, then reanalyze to pick up new dependencies. 
                var refs = compilation.References.OfType<PortableExecutableReference>().ToArray();
                count = refs.Length;
                if ((count == _projectCount) && (_tooling != null))
                {
                    return; // already initialized. 
                }

                // Even for netStandard/.core projects, this will still be a flattened list of the full transitive closure of dependencies. 
                foreach (var asm in compilation.References.OfType<PortableExecutableReference>())
                {
                    var dispName = asm.Display; // For .net core, the displayname can be the full path 
                    var path = asm.FilePath;

                    _map[dispName] = path;

                }

                // Builtins
                _mapRef["mscorlib"] = typeof(object).Assembly;
                _mapRef[WebJobsAssemblyName] = typeof(Microsoft.Azure.WebJobs.BlobAttribute).Assembly;
                _mapRef[WebJobsHostAssemblyName] = typeof(Microsoft.Azure.WebJobs.JobHost).Assembly;

                // JSON.Net? 
            }

            // Produce tooling object                 
            var hostConfig = Initialize();
            var jh2 = new JobHost(hostConfig);
            var tooling = (JobHostMetadataProvider)jh2.Services.GetService(typeof(IJobHostMetadataProvider));

            lock (this)
            {
                this._projectCount = count;
                this._tooling = tooling;
            }
        }


        private JobHostConfiguration Initialize()
        {
            JobHostConfiguration hostConfig = new Microsoft.Azure.WebJobs.JobHostConfiguration();

            foreach (var path in _map.Values)
            {
                // We don't want to load and reflect over every dll.
                // By convention, restrict to based on filenames.
                var filename = Path.GetFileName(path);
                if (!filename.ToLowerInvariant().Contains("extension"))
                {
                    continue;
                }
                if (path.Contains(@"\ref\")) // Skip reference assemblies. 
                {
                    continue;
                }

                Assembly assembly;
                try
                {
                    // See GetNugetPackagesPath() for details
                    // Script runtime is already setup with assembly resolution hooks, so use LoadFrom
                    assembly = Assembly.LoadFrom(path);

                    string asmName = new AssemblyName(assembly.FullName).Name;
                    _mapRef[asmName] = assembly;
                    LoadExtensions(hostConfig, assembly, path);
                }
                catch (Exception e)
                {
                    //  Could be a reference assembly. 
                    continue;
                }
            }

            return hostConfig;
        }

        private void LoadExtensions(JobHostConfiguration hostConfig, Assembly assembly, string locationHint)
        {
            // Traverseing the exported types will cause type loads and possible type-load failures. 
            foreach (var type in assembly.ExportedTypes)
            {
                if (type.IsAbstract || !typeof(IExtensionConfigProvider).IsAssignableFrom(type))
                {
                    continue;
                }

                try
                {
                    IExtensionConfigProvider instance = (IExtensionConfigProvider)Activator.CreateInstance(type);                    
                    hostConfig.AddExtension(instance);
                }
                catch (Exception e)
                {
                    // this.TraceWriter.Error($"Failed to load custom extension {type} from '{locationHint}'", e);
                }
            }
        } 

        public bool TryMapAssembly(IAssemblySymbol asm, out System.Reflection.Assembly asmRef)
        {
            // Top-level map only supports mscorlib, webjobs, or extensions 
            var asmName = asm.Identity.Name;
            

            Assembly asm2;
            if (_mapRef.TryGetValue(asmName, out asm2))
            {
                asmRef = asm2;
                return true;
            }

            // Is this an extension? Must have a reference to WebJobs
            bool isWebJobsAssembly = false;
            foreach(var module in asm.Modules)
            {
                foreach(var asmReference in module.ReferencedAssemblies)
                {
                    if (asmReference.Name == WebJobsAssemblyName)
                    {
                        isWebJobsAssembly = true;
                        goto Done;
                    }

                }
            }
            Done: 
            if (!isWebJobsAssembly)
            {
                asmRef = null;
                return false;
            }

            foreach (var kv in _map)
            {
                var path = kv.Value;
                var shortName = System.IO.Path.GetFileNameWithoutExtension(path);

                if (string.Equals(asmName, shortName, StringComparison.OrdinalIgnoreCase))
                {
                    var asm3 = Assembly.LoadFile(path);
                    _mapRef[asmName] = asm3;
                    
                    asmRef = asm3;
                    return true;
                }
            }

            throw new NotImplementedException();
        }

        public void Register()
        {
            if (_registered)
            {
                return;
            }
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            _registered = true;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var an = new AssemblyName(args.Name);
            var context = args.RequestingAssembly;            

            Assembly asm2;
            if (_mapRef.TryGetValue(an.Name, out asm2))
            {
                return asm2;
            }

            asm2 = LoadFromProjectReference(an);
            if (asm2 != null)
            {
                _mapRef[an.Name] = asm2;
            }

            return asm2;
        }

        private Assembly LoadFromProjectReference(AssemblyName an)
        {
            foreach(var kv in this._map)
            {
                var path = kv.Key;
                if (path.Contains(@"\ref\")) // Skip reference assemblies. 
                {
                    continue;
                }

                var filename = Path.GetFileNameWithoutExtension(path);

                // Simplifying assumption: assume dll name matches assembly name. 
                // Use this as a filter to limit the number of file-touches. 
                if (string.Equals(filename, an.Name, StringComparison.OrdinalIgnoreCase))
                {
                    var an2 = AssemblyName.GetAssemblyName(path);

                    if (string.Equals(an2.FullName, an.FullName, StringComparison.OrdinalIgnoreCase))
                    {
                        var a = Assembly.LoadFrom(path);
                        return a;
                    }
                }
            }
            return null;
        }
    }



}
