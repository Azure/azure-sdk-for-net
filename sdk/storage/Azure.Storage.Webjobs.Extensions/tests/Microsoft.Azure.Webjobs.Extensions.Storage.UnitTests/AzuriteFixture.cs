// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.UnitTests
{
    public class AzuriteFixture : IDisposable
    {
        private const int AccountPoolSize = 30;
        private const string AzuriteLocationKey = "AzureWebJobsStorageAzuriteLocation";
        private string tempDirectory;
        private Process process;
        private Queue<AzuriteAccount> accounts = new Queue<AzuriteAccount>();
        private List<string> accountsList = new List<string>();

        public AzuriteFixture()
        {
            for (int i = 0; i < AccountPoolSize; i++)
            {
                var account = new AzuriteAccount()
                {
                    Name = Guid.NewGuid().ToString(),
                    Key = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())),
            };
                accounts.Enqueue(account);
                accountsList.Add($"{account.Name}:{account.Key}");
            }

            tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            Console.WriteLine(tempDirectory);
            var azuriteLocation = Environment.GetEnvironmentVariable(AzuriteLocationKey);
            process = new Process();
            process.StartInfo.FileName = "node.exe";
            process.StartInfo.Arguments = $"{azuriteLocation} -l {tempDirectory}";
            process.StartInfo.EnvironmentVariables.Add("AZURITE_ACCOUNTS", $"{string.Join(";", accountsList)}");
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
            {
                using (var sw = File.AppendText("C:\\tmp\\azurite.log.txt"))
                {
                    sw.WriteLine(e.Data);
                }
            };
            process.Start();
            process.BeginOutputReadLine();
        }

        public AzuriteAccount GetAccount()
        {
            return accounts.Dequeue();
        }

        public void Dispose()
        {
            if (!process.HasExited)
            {
                process.Kill();
                process.WaitForExit();
            }
            Directory.Delete(tempDirectory, true);
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class AzuriteAccount
#pragma warning restore SA1402 // File may only contain a single type
    {
        public string Name { get; set; }
        public string Key { get; set; }

        public string ConnectionString { get
            {
                return $"DefaultEndpointsProtocol=http;AccountName={Name};AccountKey={Key};BlobEndpoint=http://127.0.0.1:10000/{Name};QueueEndpoint=http://127.0.0.1:10001/{Name};";
            }
        }
    }
}
