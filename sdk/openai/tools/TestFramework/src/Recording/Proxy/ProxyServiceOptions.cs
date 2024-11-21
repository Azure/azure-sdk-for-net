// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Proxy;

/// <summary>
/// Options for starting the recording test proxy.
/// </summary>
public class ProxyServiceOptions
{
    /// <summary>
    /// Gets the full path to the dotnet executable.
    /// </summary>
    required public string DotnetExecutable { get; set; }

    /// <summary>
    /// Gets the full path to the test proxy DLL.
    /// </summary>
    required public string TestProxyDll { get; set; }

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
    /// Validates the configuration.
    /// </summary>
    /// <exception cref="DirectoryNotFoundException">The storage location directory was could not be found.</exception>
    /// <exception cref="FileNotFoundException">The HTTPS certificate file could not be found.</exception>
    /// <exception cref="InvalidOperationException">No password was specified for the developer certificate file.</exception>
    internal protected virtual void Validate()
    {
        List<Exception> exceptions = new();

        if (!File.Exists(DotnetExecutable))
        {
            exceptions.Add(new FileNotFoundException("Could not find (or read from) the dotnet executable: " + DotnetExecutable));
        }
        else if (!File.Exists(TestProxyDll))
        {
            exceptions.Add(new FileNotFoundException("Could not find (or read from) the test proxy DLL: " + TestProxyDll));
        }
        else if (!Directory.Exists(StorageLocationDir))
        {
            exceptions.Add(new DirectoryNotFoundException("Could not find (or read from) the following directory: " + StorageLocationDir));
        }
        else if (DevCertFile != null && !File.Exists(DevCertFile))
        {
            exceptions.Add(new FileNotFoundException("Could not find (or read from) the HTTPS certificate file: " + DevCertFile));
        }
        else if (DevCertFile != null && DevCertPassword == null)
        {
            exceptions.Add(new InvalidOperationException($"You must set the {nameof(DevCertPassword)} property if you specify the {nameof(DevCertFile)}"));
        }

        if (exceptions.Any())
        {
            throw new AggregateException("The test proxy service configuration is invalid", exceptions); ;
        }
    }
}
