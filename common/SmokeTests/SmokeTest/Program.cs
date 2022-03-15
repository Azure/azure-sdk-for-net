// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

// The goal of the smoke tests is to ensure that each of the Azure SDK
// packages can be used in the same project without causing conflicts.
//
// To validate, this project has been generated with references to all
// packages for the current generation of the Azure SDK.  Each package assembly
// and all of its transitive dependencies will be loaded, the types for each
// enumerated, and instances will be created for any type with a parameterless constructor.
//
// This will ensure that all referenced packages have been loaded and can be used in
// the same application without requiring specific knowledge of each SDK or code related to
// its functionality.
//
// Execution will be logged to the console, using standard output for informational messages
// and standard error for errors.   A return code of "0" will indicate a successful run; a
// non-zero return indicates a test failure.

const string AssemblyFileMask = "*.dll";

LogInformation($"Smoke Test run starting...{ Environment.NewLine }");

var returnCode = 0;

// Starting with the entry assembly as the root, walk all references, both
// direct and transient to process them.

foreach (var assembly in LoadAssemblies(Assembly.GetEntryAssembly(), AssemblyFileMask))
{
    LogInformation($"Processing assembly: [{ assembly.FullName }]...");

    var typeCount = 0;

    try
    {
        // Process each type in the assembly.  The call to "ProcessType" is safe and
        // will not throw.

        foreach (var type in assembly.GetTypes())
        {
            ++typeCount;
            ProcessType(type);
        }
    }
    catch (Exception ex)
    {
        ReportError();
        LogError($"{Environment.NewLine }[{ assembly.FullName }] could not be fully processed.  Error: { ex }{ Environment.NewLine }");
    }

    LogInformation($"Completed assembly: [{ assembly.FullName }].  { typeCount } types inspected.{ Environment.NewLine }");
}

// End the test run and report on the state.

LogInformation($"{ Environment.NewLine }Smoke Test run complete.");

if (returnCode == 0)
{
    LogInformation("Passed.", ConsoleColor.Green);
}
else
{
    LogInformation("Failed.", ConsoleColor.Red);
}

return returnCode;

// Local function definitions

void ReportError() => returnCode = -1;

void LogError(string message, ConsoleColor? color = default)
{
    Console.ForegroundColor = color ?? ConsoleColor.Red;
    Console.Error.WriteLine(message);
    Console.ResetColor();
}

void LogInformation(string message, ConsoleColor? color = default)
{
    Console.ForegroundColor = color ?? Console.ForegroundColor;
    Console.WriteLine(message);
    Console.ResetColor();
}

void ProcessType(Type type)
{
    // Inspect the members of the type, walking each to force metadata to be loaded.  If a parameterless
    // constructor is found during the scan, take note for later use if it is public or belongs to an Azure
    // client type.

    var isConstructable = false;

    try
    {
        foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            if ((member is ConstructorInfo constructor) && (constructor.GetParameters().Length == 0))
            {
                isConstructable = ((constructor.IsPublic) || (IsAzureClientType(type)));
            }
        }

        // If the type is non-generic, non-abstract, and has a parameterless constructor, it should be constructed.

        if ((!type.ContainsGenericParameters) && (!type.IsAbstract) && (isConstructable))
        {
            try
            {
                _ = Activator.CreateInstance(type, true);

                if (IsAzureClientType(type))
                {
                    Console.WriteLine($"\tConstructed: '{ type.FullName }'");
                }
            }
            catch (TargetInvocationException ex) when (ex.InnerException is NotImplementedException)
            {
                // Expected; this occurs when the parameterless constructor is present but has been marked obsolete.  Since we do
                // not report types without a parameterless constructor, ignore the type and do not log.
            }
            catch (TargetInvocationException ex) when (ex.InnerException is ArgumentException)
            {
                // Expected; this occurs when the parameterless constructor is present but the type cannot be constructed due to failing
                // an internal state validation.  Since we do not report types without a parameterless constructor, ignore the type
                // and do not log.
            }
            catch (TargetInvocationException ex) when (ex.InnerException is FileNotFoundException fileEx)
            {
                // Expected; this indicates that a library is not available on a platform.  For
                // example, System.Windows.Forms on macOS.

                LogInformation($"\t[{ fileEx.FileName }] needed for type [{ type.FullName }] was not found.  This is expected for some platform-specific types, such as those in System.Windows.Forms when running on a non-Windows platform.");
            }
            catch (TargetInvocationException ex) when ((ex.InnerException is PlatformNotSupportedException) || (ex.InnerException is NotSupportedException))
            {
                // Expected; this indicates that a type is not available on a platform.  For example, Windows Principal-related types on Linux.

                LogInformation($"\t[{ type.FullName }] is not available on this platform.  This is expected for some platform-specific types.");
            }
        }
    }
    catch (Exception ex)
    {
        ReportError();
        LogError($"{Environment.NewLine }[{ type.FullName }] could not be processed.  Error: { ex }{ Environment.NewLine }");
    }
}

IEnumerable<Assembly> LoadAssemblies(Assembly rootAssembly, string assemblyFileMask)
{
    var processedAssemblies = new HashSet<string>();
    var assembliesToProcess = new Stack<Assembly>();

    // Start with the root assembly.

    assembliesToProcess.Push(rootAssembly);

    // Include any libraries referenced that have not been explicitly loaded; these should appear in
    // the directory that the entry assembly is in.

    foreach (var file in Directory.GetFiles(Path.GetDirectoryName(rootAssembly.Location), assemblyFileMask, SearchOption.AllDirectories))
    {
        if (file != rootAssembly.Location)
        {
            try
            {
                assembliesToProcess.Push(Assembly.LoadFrom(file));
            }
            catch (BadImageFormatException)
            {
                // Expected; this occurs when an assembly is not compiled for the current framework
                // or platform and is most often seen for platform-specific interop assemblies.

                LogInformation($"[{ file }] was not in the correct format to load.  This is expected for some framework or platform-specific libraries, particularly those with \"Interop\" or \"Compat\" in their name.");
            }
            catch (Exception ex)
            {
                ReportError();
                LogError($"{Environment.NewLine }[{ file }] could not be loaded for inspection.  Error: { ex }{ Environment.NewLine }");
            }
        }
    }

    // Include all assemblies loaded into the domain.

    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
        assembliesToProcess.Push(assembly);
    }

    // Process the selected assemblies recursively, capturing references discovered along the way.

    while (assembliesToProcess.Count > 0)
    {
        var assembly = assembliesToProcess.Pop();
        processedAssemblies.Add(assembly.FullName);

        foreach (var refAssembly in assembly.GetReferencedAssemblies())
        {
            if (!processedAssemblies.Contains(refAssembly.FullName))
            {
                try
                {
                    assembliesToProcess.Push(Assembly.Load(refAssembly.FullName));
                }
                catch (BadImageFormatException)
                {
                    // Expected; this occurs when an assembly is not compiled for the current framework
                    // or platform and is most often seen for platform-specific interop assemblies.

                    LogInformation($"[{ refAssembly.FullName }] was not in the correct format to load.  This is expected for some framework or platform-specific libraries, particularly those with \"Interop\" or \"Compat\" in their name.");
                }
                catch (Exception ex)
                {
                    ReportError();
                    LogError($"{Environment.NewLine }[{ refAssembly.FullName }] could not be loaded for inspection.  Error: { ex }{ Environment.NewLine }");
                }
            }
        }

        yield return assembly;
    }
}

bool IsAzureClientType(Type type) => (type.Namespace?.Contains("Azure.") ?? false) && (type.Name?.EndsWith("Client") ?? false);