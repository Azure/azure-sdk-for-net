// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenAI.TestFramework.Utils
{
    /// <summary>
    /// Assembly related helper methods
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// Gets the value of the named assembly metadata attribute for the assembly where the <typeparamref name="T"/> is defined.
        /// </summary>
        /// <typeparam name="T">The type whose assembly we want to read from.</typeparam>
        /// <param name="name">The name of the metadata assembly attribute to read.</param>
        /// <returns>The value of the metadata attribute, or null if none was specified or could be found.</returns>
        public static string? GetAssemblyMetadata<T>(string name)
            => GetAssemblyMetadata(typeof(T).Assembly, name);

        /// <summary>
        /// Gets the value of the named assembly metadata attribute from assembly.
        /// </summary>
        /// <param name="assembly">The assembly to read the metadata attribute from</param>
        /// <param name="name">The name of the metadata assembly attribute to read.</param>
        /// <returns>The value of the metadata attribute, or null if none was specified or could be found.</returns>
        public static string? GetAssemblyMetadata(this Assembly assembly, string name)
        {
            return assembly
                ?.GetCustomAttributes<AssemblyMetadataAttribute>()
                .FirstOrDefault(a => a.Key == name && !string.IsNullOrWhiteSpace(a.Value))
                ?.Value;
        }

        /// <summary>
        /// Gets the root source directory for the assembly that defines the type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type whose assembly source path we want to read.</typeparam>
        /// <returns>The directory containing the original source path, or null if it was not set or did not exist.</returns>
        public static DirectoryInfo? GetAssemblySourceDir<T>()
            => GetAssemblySourceDir(typeof(T).Assembly);

        /// <summary>
        /// Gets the source path for the assembly. In order for this to work, you will need to set the assembly metadata attribute
        /// your project file as follows:
        /// <code>
        /// &lt;ItemGroup&gt;
        ///   &lt;AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute"&gt;
        ///     &lt;_Parameter1&gt;SourcePath&lt;/_Parameter1&gt;
        ///     &lt;_Parameter2&gt;$(MSBuildProjectDirectory)&lt;/_Parameter2&gt;
        ///   &lt;/AssemblyAttribute&gt;
        /// &lt;/ItemGroup&gt;
        /// </code>
        /// </summary>
        /// <param name="assembly">The assembly whose source path we want to find.</param>
        /// <returns>The directory containing the original source path, or null if it was not set or did not exist.</returns>
        public static DirectoryInfo? GetAssemblySourceDir(this Assembly assembly)
        {
            string? sourcePath = assembly.GetAssemblyMetadata("SourcePath");
            if (sourcePath == null)
            {
                return null;
            }

            DirectoryInfo dir = new(sourcePath);
            return dir.Exists
                ? dir
                : null;
        }

        /// <summary>
        /// Finds the dotnet executable path for the current system. It does this by reading the DOTNET_INSTALL_DIR environment variable
        /// first, and then inspecting all folders in the current PATH environment variable.
        /// </summary>
        /// <returns>The path to the found dotnet executable, or null if none could be found.</returns>
        public static FileInfo? GetDotnetExecutable()
        {
            string dotnetExeName = "dotnet";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                dotnetExeName += ".exe";
            }

            List<string?> searchDirs =
            [
                Environment.GetEnvironmentVariable("DOTNET_INSTALL_DIR"),
                ..Environment.GetEnvironmentVariable("PATH")
                    ?.Split(Path.PathSeparator)
                    ?? Array.Empty<string>()
            ];

            return searchDirs
                .Where(dir => !string.IsNullOrWhiteSpace(dir))
                .Select(dir => new FileInfo(Path.Combine(dir!, dotnetExeName)))
                .FirstOrDefault(file => file.Exists);
        }
    }
}
