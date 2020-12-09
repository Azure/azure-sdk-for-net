// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    /// <summary>
    /// This class manages Azurite Lifecycle for a test class.
    /// - Creates accounts pool, so that each test has own account, bump up pool size if you're running out of accounts
    /// - Starts Azurite process
    /// - Tears down Azurite process after test class is run
    /// It requires Azurite V3. See instalation insturctions here https://github.com/Azure/Azurite.
    /// After installing Azuirte define env variable AZURE_AZURITE_LOCATION that points to azurite installation (e.g. C:\Users\kasobol.REDMOND\AppData\Roaming\npm)
    /// NodeJS installation is also required and node should be in the $PATH.
    /// </summary>
    public class AzuriteFixture : IDisposable
    {
        private const string AzuriteLocationKey = "AZURE_AZURITE_LOCATION";
        private string tempDirectory;
        private Process process;
        private AzuriteAccount account;
        private CountdownEvent countdownEvent = new CountdownEvent(2);
        private StringBuilder azuriteOutput = new StringBuilder();
        private StringBuilder azuriteError = new StringBuilder();
        private int blobsPort;
        private int queuesPort;

        public AzuriteFixture()
        {
            // This is to force newer protocol on machines with older .NET Framework. Otherwise tests don't connect to Azurite with unsigned cert.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var azuriteLocation = Environment.GetEnvironmentVariable(AzuriteLocationKey);
            var defaultPath = Path.Combine(Environment.GetEnvironmentVariable("APPDATA") ?? string.Empty, "npm");

            if (string.IsNullOrWhiteSpace(azuriteLocation))
            {
                if (Directory.Exists(defaultPath))
                {
                    azuriteLocation = defaultPath;
                }
                else
                {
                    throw new ArgumentException(ErrorMessage($"{AzuriteLocationKey} environment variable is not set and {defaultPath} doesn't exist"));
                }
            }
            var azuriteScriptLocation = Path.Combine(azuriteLocation, "node_modules/azurite/dist/src/azurite.js");
            if (!File.Exists(azuriteScriptLocation))
            {
                throw new ArgumentException(ErrorMessage($"{azuriteScriptLocation} does not exist, check if {AzuriteLocationKey} is pointing to right location"));
            }

            account = new AzuriteAccount()
            {
                Name = Guid.NewGuid().ToString(),
                Key = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())),
            };

            tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            process = new Process();
            process.StartInfo.FileName = "node";
            process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            process.StartInfo.Arguments = $"{azuriteScriptLocation} --oauth basic -l {tempDirectory} --blobPort 0 --queuePort 0 --cert cert.pem --key cert.pem --skipApiVersionCheck";
            process.StartInfo.EnvironmentVariables.Add("AZURITE_ACCOUNTS", $"{account.Name}:{account.Key}");
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
            {
                if (e.Data != null)
                {
                    if (e.Data.Contains("Azurite Blob service is successfully listening at"))
                    {
                        blobsPort = ParseAzuritePort(e.Data);
                        countdownEvent.Signal();
                    }
                    if (e.Data.Contains("Azurite Queue service is successfully listening at"))
                    {
                        queuesPort = ParseAzuritePort(e.Data);
                        countdownEvent.Signal();
                    }
                    if (!countdownEvent.IsSet) // stop output collection if it started successfully.
                    {
                        azuriteOutput.AppendLine(e.Data);
                    }
                }
            };
            process.ErrorDataReceived += delegate (object sender, DataReceivedEventArgs e)
            {
                if (e.Data != null)
                {
                    if (!countdownEvent.IsSet) // stop error collection if it started successfully.
                    {
                        azuriteError.AppendLine(e.Data);
                    }
                }
            };
            try
            {
                process.Start();
            } catch (Win32Exception e)
            {
                throw new ArgumentException(ErrorMessage("could not run NodeJS, make sure it's installed"), e);
            }
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            var didAzuriteStart = countdownEvent.Wait(TimeSpan.FromSeconds(15));
            if (!didAzuriteStart)
            {
                if (process.HasExited)
                {
                    throw new InvalidOperationException(ErrorMessage($"azurite process could not start with following output:\n{azuriteOutput}\nerror:\n{azuriteError}\nexit code: {process.ExitCode}"));
                }
                else
                {
                    process.Kill();
                    process.WaitForExit();
                    throw new InvalidOperationException(ErrorMessage($"azurite process could not initialize within timeout with following output:\n{azuriteOutput}\nerror:\n{azuriteError}"));
                }
            }
            account.BlobsPort = blobsPort;
            account.QueuesPort = queuesPort;
        }

        private int ParseAzuritePort(string outputLine)
        {
            int indexFrom = outputLine.LastIndexOf(':') + 1;
            return int.Parse(outputLine.Substring(indexFrom));
        }

        private string ErrorMessage(string specificReason)
        {
            return $"\nCould not run Azurite based test due to: {specificReason}.\n" +
                "Make sure that:\n" +
                "- NodeJS is installed and available in $PATH (i.e. 'node' command can be run in terminal)\n" +
                "- Azurite V3 is installed via NPM (see https://github.com/Azure/Azurite for instructions)\n" +
                $"- {AzuriteLocationKey} envorinment is set and pointing to location of directory that has 'azurite' command (i.e. run 'where azurite' in Windows CMD)\n";
        }

        public BlobServiceClient GetBlobServiceClient()
        {
            var transport = GetTransport();
            return new BlobServiceClient(account.ConnectionString, new BlobClientOptions()
            {
                Transport = transport
            });
        }

        public QueueServiceClient GetQueueServiceClient(QueueClientOptions queueClientOptions = default)
        {
            if (queueClientOptions == default)
            {
                queueClientOptions = new QueueClientOptions()
                {
                    MessageEncoding = QueueMessageEncoding.Base64
                };
            }

            queueClientOptions.Transport = GetTransport();
            return new QueueServiceClient(account.ConnectionString, queueClientOptions);
        }

        public HttpClientTransport GetTransport()
        {
            var transport = new HttpClientTransport(new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            }));
            return transport;
        }

        public TokenCredential GetCredential()
        {
            return new AzuriteTokenCredential();
        }

        public AzuriteAccount GetAzureAccount()
        {
            return account;
        }

        public void Dispose()
        {
            if (process != null)
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    process.WaitForExit();
                }
                Directory.Delete(tempDirectory, true);
            }
        }

        private class AzuriteTokenCredential: TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                //{
                // "aud": "https://storage.azure.com",
                // "iss": "https://sts.windows-ppe.net/ab1f708d-50f6-404c-a006-d71b2ac7a606/",
                // "iat": 1511859603,
                // "nbf": 1511859603,
                // "exp": 9999999999,
                // "alg": "HS256"
                //}
                // Encoded using https://jwt.io/
                return new AccessToken("eyJhdWQiOiJodHRwczovL3N0b3JhZ2UuYXp1cmUuY29tIiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy1wcGUubmV0L2FiMWY3MDhkLTUwZjYtNDA0Yy1hMDA2LWQ3MWIyYWM3YTYwNi8iLCJpYXQiOjE1MTE4NTk2MDMsIm5iZiI6MTUxMTg1OTYwMywiZXhwIjo5OTk5OTk5OTk5LCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJodHRwczovL3N0b3JhZ2UuYXp1cmUuY29tIiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy1wcGUubmV0L2FiMWY3MDhkLTUwZjYtNDA0Yy1hMDA2LWQ3MWIyYWM3YTYwNi8iLCJpYXQiOjE1MTE4NTk2MDMsIm5iZiI6MTUxMTg1OTYwMywiZXhwIjo5OTk5OTk5OTk5LCJhbGciOiJIUzI1NiJ9.z48ZJz_3k0ZOATIMjZ02AQxlDnUT3NXLEJXLgdHIKl8", DateTimeOffset.MaxValue);
            }
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class AzuriteAccount
#pragma warning restore SA1402 // File may only contain a single type
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int BlobsPort { get; set; }
        public int QueuesPort { get; set; }

        public string Endpoint => $"https://127.0.0.1:{BlobsPort}/{Name}";

        public string ConnectionString
        {
            get
            {
                return $"DefaultEndpointsProtocol=http;AccountName={Name};AccountKey={Key};BlobEndpoint=https://127.0.0.1:{BlobsPort}/{Name};QueueEndpoint=https://127.0.0.1:{QueuesPort}/{Name};";
            }
        }
    }
}
