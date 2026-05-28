// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Utils.Processes;

namespace OpenAI.TestFramework.Recording.Proxy;

/// <summary>
/// Represents the test proxy. See here for more information:
/// https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md
/// </summary>
public class ProxyService : IDisposable
{
    private const int c_maxLines = 50;

    private Process _testProxyProcess;
    private Uri? _http;
    private Uri? _https;
    private TaskCompletionSource<(int, int)> _portsAvailableTcs;
    private StringBuilder _errorOutput;
    private int _lines;
    private ProxyClient? _client;
    private WindowsJob? _windowsJob;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="options">The options to use.</param>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> was null.</exception>
    private ProxyService(ProxyServiceOptions options)
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        options.Validate();

        ProcessStartInfo startInfo = new()
        {
            FileName = options.DotnetExecutable,
            Arguments = $@"""{options.TestProxyDll}"" start -u --storage-location=""{options.StorageLocationDir}""",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            EnvironmentVariables =
            {
                ["ASPNETCORE_URLS"] = $"http://127.0.0.1:{options.HttpPort};https://127.0.0.1:{options.HttpsPort}",
                ["Logging__LogLevel__Azure.Sdk.Tools.TestProxy"] = "Error",
                ["Logging__LogLevel__Default"] = "Error",
                ["Logging__LogLevel__Microsoft.AspNetCore"] = "Error",
                ["Logging__LogLevel__Microsoft.Hosting.Lifetime"] = "Information",
            }
        };

        if (options.DevCertFile != null)
        {
            startInfo.EnvironmentVariables["ASPNETCORE_Kestrel__Certificates__Default__Path"] = options.DevCertFile;
            if (options.DevCertPassword != null)
            {
                startInfo.EnvironmentVariables["ASPNETCORE_Kestrel__Certificates__Default__Password"] = options.DevCertPassword;
            }
        }

        _errorOutput = new();
        _portsAvailableTcs = new();
        _testProxyProcess = new Process()
        {
            EnableRaisingEvents = true,
            StartInfo = startInfo
        };

        _testProxyProcess.Exited += (_, _) =>
        {
            _portsAvailableTcs.TrySetException(new InvalidOperationException("Test proxy process exited unexpectedly"));
        };
        _testProxyProcess.ErrorDataReceived += HandleStdErr;
        _testProxyProcess.OutputDataReceived += HandleStdOut;

        _windowsJob = null;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // If running on Windows, use a Job to instruct the OS to kill the test proxy service process
            // should this current process die for any reason.
            _windowsJob = new($"TestProxy_{Process.GetCurrentProcess().Id}");
        }
    }

    /// <summary>
    /// Gets the client to use to communicate with this recording test proxy.
    /// </summary>
    public ProxyClient Client => _client
        ?? throw new InvalidOperationException("Please wait for the proxy to finish starting first");

    /// <summary>
    /// Gets the HTTP endpoint the test recording proxy is listening on.
    /// </summary>
    public Uri HttpEndpoint => _http
        ?? throw new InvalidOperationException("Please wait for the proxy to finish starting first");

    /// <summary>
    /// Gets the HTTPS endpoint the test recording proxy is listening on.
    /// </summary>
    public Uri HttpsEndpoint => _https
        ?? throw new InvalidOperationException("Please wait for the proxy to finish starting first");

    /// <summary>
    /// Creates a new instance of the recording test proxy.
    /// </summary>
    /// <param name="options">The options to use for the proxy.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The initialized recording test proxy instance.</returns>
    public static async Task<ProxyService> CreateNewAsync(ProxyServiceOptions options, CancellationToken token = default)
    {
        token.ThrowIfCancellationRequested();

        ProxyService proxy = new ProxyService(options);

        // Try to make sure the test proxy process is terminated when we exit
        AppDomain.CurrentDomain.DomainUnload += (_, _) => proxy.Dispose();
        // TODO FIXME: On Windows, use a job to ensure the OS will properly kill the process

        await proxy.StartAsync(token).ConfigureAwait(false);
        return proxy;
    }

    /// <summary>
    /// Tears down the recording test proxy instance.
    /// </summary>
    public void Dispose()
    {
        _portsAvailableTcs.TrySetException(new ObjectDisposedException(nameof(ProxyService)));
        try
        {
            _testProxyProcess.Kill();
            if (_windowsJob != null)
            {
                // do NOT call Dispose here. This will terminate this process too.
            }
        } catch { /* we tried */ }
    }

    /// <summary>
    /// Checks to see if any errors were encountered in the test proxy, and if so throws an exception.
    /// </summary>
    /// <exception cref="InvalidOperationException">If there were any errors encountered.</exception>
    public void ThrowOnErrors()
    {
        lock (_errorOutput)
        {
            if (_errorOutput.Length > 0)
            {
                string error = _errorOutput.ToString();
                _errorOutput.Clear();
                throw new InvalidOperationException($"An error occurred in the test proxy:\n{error}");
            }
        }
    }

    /// <summary>
    /// For testing purposes only
    /// </summary>
    /// <param name="client">The client to set.</param>
    internal void SetClient(ProxyClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Starts the recording test proxy instance, and waits until we can read the ports it is listening on for
    /// HTTP and HTTPS.
    /// </summary>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>Asynchronous tas</returns>
    /// <exception cref="InvalidOperationException">The test proxy failed to start, or we encountered some other error.</exception>
    protected async Task StartAsync(CancellationToken token = default)
    {
        token.Register(_portsAvailableTcs.SetCanceled);

        bool success = _testProxyProcess.Start();
        if (!success)
        {
            throw new InvalidOperationException("The test proxy process failed to start");
        }

        _windowsJob?.Add(_testProxyProcess);

        _testProxyProcess.BeginOutputReadLine();
        _testProxyProcess.BeginErrorReadLine();

        await _portsAvailableTcs.Task.ConfigureAwait(false);
    }

    private static Uri? ParseListeningOnUri(string line)
    {
        const string nowListeningOn = "Now listening on: ";
        int index = line.IndexOf(nowListeningOn, StringComparison.OrdinalIgnoreCase);
        if (index < 0)
        {
            return null;
        }

        Uri.TryCreate(line.AsSpan().Slice(index + nowListeningOn.Length).Trim().ToString(), UriKind.Absolute, out Uri? uri);
        return uri;
    }

    private void HandleStdErr(object sender, DataReceivedEventArgs args)
    {
        if (args?.Data != null)
        {
            lock (_errorOutput)
            {
                _errorOutput.Append(args.Data);
            }

            TestContext.Progress.WriteLine(args.Data);
        }
    }

    private void HandleStdOut(object sender, DataReceivedEventArgs args)
    {
        if (_lines++ >= c_maxLines)
        {
            _portsAvailableTcs.TrySetException(new InvalidOperationException(
                $"Failed to start the test proxy. One or both the ports was not populated. http: {_http}, https: {_https}"));
            _testProxyProcess.OutputDataReceived -= HandleStdOut;
            return;
        }
        else if (args?.Data == null)
        {
            return;
        }

        Uri? uri = ParseListeningOnUri(args.Data);
        if (_http == null && uri?.Scheme == "http")
        {
            _http = uri;
            _client = new ProxyClient(new ProxyClientOptions(_http!));
        }
        else if (_https == null && uri?.Scheme == "https")
        {
            _https = uri;
        }

        if (_http != null && _https != null)
        {
            _testProxyProcess.OutputDataReceived -= HandleStdOut;
            _portsAvailableTcs.TrySetResult((_http.Port, _https.Port));
        }
    }
}
