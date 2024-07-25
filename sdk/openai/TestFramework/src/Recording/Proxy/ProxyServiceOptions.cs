// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenAI.TestFramework.Recording.Proxy;

/// <summary>
/// Options for starting the recording test proxy.
/// </summary>
public class ProxyServiceOptions
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="dotnetExecutable">(Optional) The full path to the DOTNET executable. Will attempt to automatically
    /// determine what this is if none was specified.</param>
    /// <param name="testProxyDll">(Optional) The full path to the test proxy DLL. This will attempt to read the path
    /// from the assembly metadata if not specified.</param>
    /// <exception cref="InvalidOperationException">The DOTNET executable or test proxy DLL paths could not be determined.</exception>
    public ProxyServiceOptions(string? dotnetExecutable = null, string? testProxyDll = null)
    {
        if (string.IsNullOrWhiteSpace(dotnetExecutable))
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

            dotnetExecutable = searchDirs
                .Where(dir => !string.IsNullOrWhiteSpace(dir))
                .Select(dir => Path.Combine(dir!, dotnetExeName))
                .FirstOrDefault(file => File.Exists(file));
            if (dotnetExecutable == null)
            {
                throw new InvalidOperationException("DOTNET install directory was not found");
            }
        }

        if (string.IsNullOrWhiteSpace(testProxyDll))
        {
            testProxyDll = typeof(ProxyServiceOptions).Assembly
                .GetCustomAttributes<AssemblyMetadataAttribute>()
                .FirstOrDefault(attrib => attrib.Key == "TestProxyPath" && !string.IsNullOrWhiteSpace(attrib.Value))
                ?.Value;

            if (string.IsNullOrWhiteSpace(testProxyDll))
            {
                throw new InvalidOperationException("Could not find the test proxy DLL");
            }
        }

        DotnetExecutable = dotnetExecutable!;
        TestProxyDll = testProxyDll!;
    }

    /// <summary>
    /// The path to the directory to store or read recordings from.
    /// </summary>
    required public string StorageLocationDir { get; set; }

    /// <summary>
    /// (Optional) The file to use for the HTTPS endpoint certificate.
    /// </summary>
    public string? DevCertFile { get; set; }

    /// <summary>
    /// (Optional) The password to use for opening the <see cref="DevCertFile"/> for the HTTPS endpoint.
    /// </summary>
    public string? DevCertPassword { get; set; }

    /// <summary>
    /// (Optional) The HTTP port the test proxy should listen on. Set this to 0 to have the next available port be automatically selected.
    /// </summary>
    public ushort HttpPort { get; set; }

    /// <summary>
    /// (Optional) The HTTPS port the test proxy should listen on. Set this to 0 to have the next available port be automatically selected.
    /// </summary>
    public ushort HttpsPort { get; set; }

    /// <summary>
    /// Gets the full path to the dotnet executable.
    /// </summary>
    internal string DotnetExecutable { get; }

    /// <summary>
    /// Gets the full path to the test proxy DLL.
    /// </summary>
    internal string TestProxyDll { get; }

    /// <summary>
    /// Validates the configuration.
    /// </summary>
    /// <exception cref="DirectoryNotFoundException">The storage location directory was could not be found.</exception>
    /// <exception cref="FileNotFoundException">The HTTPS certificate file could not be found.</exception>
    /// <exception cref="InvalidOperationException">No password was specified for the developer certificate file.</exception>
    internal protected virtual void Validate()
    {
        if (!Directory.Exists(StorageLocationDir))
        {
            throw new DirectoryNotFoundException("Could not find (or read from) the following directory: " + StorageLocationDir);
        }
        else if (DevCertFile != null && !File.Exists(DevCertFile))
        {
            throw new FileNotFoundException("Could not find (or read from) the HTTPS certificate file: " + DevCertFile);
        }
        else if (DevCertFile != null && DevCertPassword == null)
        {
            throw new InvalidOperationException($"You must set the {nameof(DevCertPassword)} property if you specify the {nameof(DevCertFile)}");
        }
    }
}
