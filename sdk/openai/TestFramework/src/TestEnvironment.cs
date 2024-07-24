// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Reflection;
using NUnit.Framework;

namespace OpenAI.TestFramework;

/// <summary>
/// Represents the environment in which a test is being run.
/// </summary>
public class TestEnvironment
{
    /// <summary>
    /// Creates a new instance
    /// </summary>
    public TestEnvironment()
    {
        RepositoryRoot = FindRepoRoot();
        IsFiddlerEnabled = CheckIfFiddlerEnabled();
    }

    /// <summary>
    /// Gets the directory that is the root of the current GIT repository.
    /// </summary>
    public DirectoryInfo RepositoryRoot { get; }

    /// <summary>
    /// Determines if Fiddler is either programmatically enabled, or is currently running.
    /// </summary>
    public bool IsFiddlerEnabled { get; }

    /// <summary>
    /// Determines whether or not we are currently running an CI/CD environment.
    /// </summary>
    public static bool IsRunningInCI => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("TF_BUILD"));

    /// <summary>
    /// Gets the path to where the source of the current assembly can be found on disk.
    /// </summary>
    /// <param name="assembly">The assembly to check.</param>
    /// <returns>The directory information for the source, or null if the it could not be determined or could not be found on disk.</returns>
    /// <exception cref="ArgumentNullException">If the assembly was null</exception>
    public virtual DirectoryInfo? GetSourcePath(Assembly assembly)
    {
        if (assembly == null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        // This works because we expect either the test project file to inject a SourcePath assembly metadata,
        // or for a Directory.Build.props file somewhere in the ancestor tree directory structure to do so.
        // For example, right now this is auto injected by <RepositoryRoot>/Directory.Build.targets
        string? sourcePath = assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
            .FirstOrDefault(attrib => attrib?.Key == "SourcePath" && !string.IsNullOrWhiteSpace(attrib?.Value))
            ?.Value;

        if (sourcePath == null)
        {
            return null;
        }

        DirectoryInfo dir = new(sourcePath);
        if (!dir.Exists)
        {
            return null;
        }

        return dir;
    }

    /// <summary>
    /// Gets the value of an optional variable.
    /// </summary>
    /// <param name="name">The name of the environment variable.</param>
    /// <returns>The value of the variable, or null if it doesn't exist.</returns>
    public virtual string? GetOptionalVariable(string name)
    {
        name = name.ToUpperInvariant();
        string? value = Environment.GetEnvironmentVariable($"SCM_{name}");
        if (value == null)
        {
            value = Environment.GetEnvironmentVariable(name);
        }

        return value;
    }

    /// <summary>
    /// Gets the value of a required variable.
    /// </summary>
    /// <param name="name">The name of the variable.</param>
    /// <returns>The value of the variable. An exception will be thrown if it doesn't exist.</returns>
    /// <exception cref="InvalidOperationException">If the variable doesn't exist.</exception>
    public virtual string GetRequiredVariable(string name)
    {
        return GetOptionalVariable(name)
            ?? throw new InvalidOperationException("Could not get the value for: " + name);
    }

    /// <summary>
    /// Finds the root of GIT repository.
    /// </summary>
    /// <returns>The root folder.</returns>
    /// <exception cref="InvalidOperationException">If the root folder could not be determined.</exception>
    protected virtual DirectoryInfo FindRepoRoot()
    {
        /**
         * This code assumes that we are running in the standard Azure .Net SDK repository layout. With this in mind, 
         * we generally assume that we are running our test code from
         * <root>/artifacts/bin/<NameOfProject>/<Configuration>/<TargetFramework>
         * So to find the root we keep navigating up until we find a folder with a .git subfolder
         * 
         * Another alternative would be to call: git rev-parse --show-toplevel
         */

        DirectoryInfo? current = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
        while (current != null && !current.EnumerateDirectories(".git").Any())
        {
            current = current.Parent;
        }

        return current
            ?? throw new InvalidOperationException("Could not determine the root folder for this repository");
    }

    /// <summary>
    /// Gets whether or not Fiddler is enabled from the configuration.
    /// </summary>
    /// <returns>True if Fiddler is enabled, false otherwise.</returns>
    protected virtual bool CheckIfFiddlerEnabled()
    {
        // Is the use of Fiddler enabled via the test context or environment?
        string? switchString = TestContext.Parameters["EnableFiddler"]
            ?? Environment.GetEnvironmentVariable("SCM_ENABLE_FIDDLER");

        if (bool.TryParse(switchString, out bool fiddlerEnabled)
            && fiddlerEnabled)
        {
            return true;
        }

        // Check to see if Fiddler is already running and capturing traffic by checking to see if a proxy is configured for
        // 127.0.0.1:8888 with no credentials
        try
        {
            Uri dummyUri = new("https://not.a.real.uri.com");

            IWebProxy webProxy = WebRequest.GetSystemWebProxy();
            Uri? proxyUri = webProxy?.GetProxy(dummyUri);
            if (proxyUri == null || proxyUri == dummyUri)
            {
                return false;
            }

            // assume default of 127.0.0.1:8888 with no credentials
            var cred = webProxy?.Credentials?.GetCredential(dummyUri, string.Empty);
            return proxyUri.Host == "127.0.0.1"
                && proxyUri.Port == 8888
                && string.IsNullOrWhiteSpace(cred?.UserName)
                && string.IsNullOrWhiteSpace(cred?.Password);
        }
        catch
        {
            return false;
        }
    }
}
