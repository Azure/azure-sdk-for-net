// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Azure.WebJobs.Extensions.Storage.Common.Tests
{
    /// <summary>
    /// This class manages Azurite Lifecycle for a test class.
    /// - Creates accounts pool, so that each test has own account, bump up pool size if you're running out of accounts
    /// - Starts Azurite process
    /// - Tears down Azurite process after test class is run
    /// It requires Azurite V3. See instalation insturctions here https://github.com/Azure/Azurite.
    /// After installing Azuirte define env variable AZURE_AZURITE_LOCATION that points to azurite installation (e.g. C:\Users\kasobol.REDMOND\AppData\Roaming\npm)
    /// NodeJS installation is also required and node should be in the $PATH.
    ///
    /// The lifecycle of this class is managed by XUnit, see https://xunit.net/docs/shared-context.
    /// </summary>
    public class AzuriteFixture : IDisposable
    {
        private const int AccountPoolSize = 50;
        private const string AzuriteLocationKey = "AZURE_AZURITE_LOCATION";
        private string tempDirectory;
        private Process process;
        private Queue<AzuriteAccount> accounts = new Queue<AzuriteAccount>();
        private List<string> accountsList = new List<string>();
        private CountdownEvent countdownEvent = new CountdownEvent(2);
        private StringBuilder azuriteOutput = new StringBuilder();

        public AzuriteFixture()
        {
            var azuriteLocation = Environment.GetEnvironmentVariable(AzuriteLocationKey);
            if (string.IsNullOrWhiteSpace(azuriteLocation))
            {
                throw new ArgumentException(ErrorMessage($"{AzuriteLocationKey} environment variable is not set"));
            }
            var azuriteScriptLocation = Path.Combine(azuriteLocation, "node_modules/azurite/dist/src/azurite.js");
            if (!File.Exists(azuriteScriptLocation))
            {
                throw new ArgumentException(ErrorMessage($"{azuriteScriptLocation} does not exist, check if {AzuriteLocationKey} is pointing to right location"));
            }

            int blobsPort = FindFreeTcpPort();
            int queuesPort = FindFreeTcpPort();
            for (int i = 0; i < AccountPoolSize; i++)
            {
                var account = new AzuriteAccount()
                {
                    Name = Guid.NewGuid().ToString(),
                    Key = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())),
                    BlobsPort = blobsPort,
                    QueuesPort = queuesPort,
                };
                accounts.Enqueue(account);
                accountsList.Add($"{account.Name}:{account.Key}");
            }

            tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            process = new Process();
            process.StartInfo.FileName = "node";
            process.StartInfo.Arguments = $"{azuriteScriptLocation} -l {tempDirectory} --blobPort {blobsPort} --queuePort {queuesPort}";
            process.StartInfo.EnvironmentVariables.Add("AZURITE_ACCOUNTS", $"{string.Join(";", accountsList)}");
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
            {
                if (e.Data != null)
                {
                    if (e.Data.Contains("Azurite Blob service is successfully listening at"))
                    {
                        countdownEvent.Signal();
                    }
                    if (e.Data.Contains("Azurite Queue service is successfully listening at"))
                    {
                        countdownEvent.Signal();
                    }
                    if (!countdownEvent.IsSet) // stop output collection if it started successfully.
                    {
                        azuriteOutput.AppendLine(e.Data);
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
            var didAzuriteStart = countdownEvent.Wait(TimeSpan.FromSeconds(5));
            if (!didAzuriteStart)
            {
                throw new InvalidOperationException(ErrorMessage($"azurite process could not start with following output:\n{azuriteOutput}"));
            }
        }

        private string ErrorMessage(string specificReason)
        {
            return $"\nCould not run Azurite based test due to: {specificReason}.\n" +
                "Make sure that:\n" +
                "- NodeJS is installed and available in $PATH (i.e. 'node' command can be run in terminal)\n" +
                "- Azurite V3 is installed via NPM (see https://github.com/Azure/Azurite for instructions)\n" +
                $"- {AzuriteLocationKey} envorinment is set and pointing to location of directory that has 'azurite' command (i.e. run 'where azurite' in Windows CMD)\n";
        }

        private static int FindFreeTcpPort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }

        public AzuriteAccount GetAccount()
        {
            return accounts.Dequeue();
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
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class AzuriteAccount
#pragma warning restore SA1402 // File may only contain a single type
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int BlobsPort { get; set; }
        public int QueuesPort { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"DefaultEndpointsProtocol=http;AccountName={Name};AccountKey={Key};BlobEndpoint=http://127.0.0.1:{BlobsPort}/{Name};QueueEndpoint=http://127.0.0.1:{QueuesPort}/{Name};";
            }
        }
    }
}
