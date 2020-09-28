// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

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

        public AzuriteFixture()
        {
            var azuriteLocation = Environment.GetEnvironmentVariable(AzuriteLocationKey);
            if (!string.IsNullOrWhiteSpace(azuriteLocation))
            {
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

                var azuriteScriptLocation = Path.Combine(azuriteLocation, "node_modules/azurite/dist/src/azurite.js");
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
                    /* using (var sw = File.AppendText("C:\\tmp\\azurite.log.txt"))
                    {
                        sw.WriteLine(e.Data);
                    }*/
                };
                process.Start();
                process.BeginOutputReadLine();
            }
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
