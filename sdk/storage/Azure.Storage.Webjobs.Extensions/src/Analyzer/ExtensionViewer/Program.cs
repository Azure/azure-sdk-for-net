// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Utility;

namespace Microsoft.Azure.WebJobs.ExtensionViewer
{
    // Thisis 
    class Program
    {
        const string WebJobsAssemblyName = "Microsoft.Azure.WebJobs.dll";

        // Load a csproj (in which case we will build it with dotnet.exe) or an already built dll. 
        static Assembly Load(string pathToDll)
        {
            Console.WriteLine("Loading from: {0}", pathToDll);
            if (!File.Exists(pathToDll))
            {
                throw new InvalidOperationException("Path does not exist: " + pathToDll);
            }

            if (pathToDll.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase))
            {
                return DotNetPublish(pathToDll);
            }

            if (!pathToDll.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Path must be dll or csproj: " + pathToDll);
            }

            var dir = Path.GetDirectoryName(pathToDll);

            // If there's a webjobs.dll, it's flattened 
            var webJobsDll = Path.Combine(dir, WebJobsAssemblyName);
            if (!File.Exists(webJobsDll))
            {
                // Missing, there may 
                Console.WriteLine("WARNING: webjobs.dll is missing. May not be able to resolve all dependencies.");
            }


            var asm = Assembly.LoadFrom(pathToDll);
            try
            {
                asm.GetTypes(); // verify it loaded and dependencies are resolved 

                return asm;
            }
            catch (ReflectionTypeLoadException re)
            {
                // Print out in more details. 
                Console.WriteLine("ERROR: Failed to fully load assembly's dependencies.");

                // These may repeat. 
                foreach (var ex in re.LoaderExceptions)
                {
                    Console.WriteLine("  " + ex.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Failed to fully load assembly's dependencies.");
            }
            Console.WriteLine("Successfully loaded dll from: " + pathToDll);

            Environment.Exit(1);
            return null;
        }

        static Assembly DotNetPublish(string pathCsProj)
        {
            var outDir = Path.Combine(Path.GetTempPath(), "wj-ext-analyzer");
            Directory.CreateDirectory(outDir);
            Directory.Delete(outDir, true);
            Directory.CreateDirectory(outDir);


            var dotnet = DotNetMuxer.MuxerPath;
            var args = "publish " + pathCsProj + " -o " + outDir;

            Console.WriteLine("Building csproj: " + args);

            var proc = Process.Start(dotnet, args);
            proc.WaitForExit();

            // Main dll is the one with a deps.json next to it
            var deps = Directory.EnumerateFiles(outDir, "*.deps.json").ToArray();
            if (deps.Length != 1)
            {
                Console.WriteLine("Failed to find .deps.json file");
                Environment.Exit(1);
            }

            string path = deps[0].Replace(".deps.json", ".dll");
            return Load(path);
        }

        static int Main(string[] args)
        {
            Console.WriteLine("WebJobs BYOB Extension Analyzer v0.1");

            var config = new JobHostConfiguration();
            config.DashboardConnectionString = null;

            if (args.Length == 0)
            {
                Console.WriteLine("Error: arg0 should be path to a WebJobs extension (either .dll or .csproj)");
                return 1;
            }
            var path = args[0];

            var webjobsAsssembly = typeof(JobHostConfiguration).Assembly;
            Assembly asm = (path == "builtin") ? webjobsAsssembly : Load(path);

            var types = asm.GetTypes();

            Console.WriteLine("=============================");

            foreach (var type in asm.GetTypes())
            {
                if (typeof(IExtensionConfigProvider).IsAssignableFrom(type) && !type.IsInterface)
                {
                    Console.WriteLine("Found extension: {0}", type.FullName);

                    try
                    {
                        var obj = Activator.CreateInstance(type);
                        var extension = (IExtensionConfigProvider)obj;
                                                
                        config.AddExtension(extension);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR: Failed to instantiate extension: " + e.Message);
                    }
                }
            }
            Console.WriteLine();

            // This will run the extension's Initialize() method and build up the binding graph. 
            var host = new JobHost(config);
            var metadata = (JobHostMetadataProvider)host.Services.GetService(typeof(IJobHostMetadataProvider));
                        
            var rules = metadata.GetRules();

            // Limit to just this extension 
            if (asm != webjobsAsssembly)
            {
                rules = rules.Where(rule => rule.SourceAttribute.Assembly == asm).ToArray();
            }


            HashSet<Type> attrs = new HashSet<Type>();
            foreach (var rule in rules)
            {
                attrs.Add(rule.SourceAttribute);
            }
            DumpAttributes(attrs);

            Console.WriteLine("--------");
            Console.WriteLine("Binding Rules:");
            Console.WriteLine();
            DumpRule(rules, Console.Out);

            return 0;
        }

        // Dump the attributes defined by this extension. 
        private static void DumpAttributes(IEnumerable<Type> attrs)
        {
            Console.WriteLine("--------");

            foreach (var attr in attrs)
            {
                Console.WriteLine(attr.FullName);


                foreach (var prop in attr.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (prop.DeclaringType == typeof(Attribute))
                    {
                        continue;
                    }
                    var customAttrs = prop.GetCustomAttributes();

                    Console.Write("   {1} : {0}", prop.PropertyType.Name, prop.Name);

                    foreach (Attribute customAttr in customAttrs)
                    {
                        if (customAttr is AutoResolveAttribute)
                        {
                            Console.Write(" [AutoResolve]");
                        }

                        if (customAttr is AppSettingAttribute)
                        {
                            Console.Write(" [AppSetting]");
                        }

                        if (customAttr is ValidationAttribute)
                        {
                            Console.Write(" [Validate:{0}]", customAttr.GetType().Name);
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        internal static void DumpRule(IEnumerable<BindingRule> rules, TextWriter output)
        {
            foreach (var rule in rules)
            {                
                output.WriteLine(rule);
            }
        }
    }
}
