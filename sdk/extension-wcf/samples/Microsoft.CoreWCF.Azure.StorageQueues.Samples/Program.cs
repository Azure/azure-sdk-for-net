// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.CoreWCF.Azure.StorageQueues.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<StartupDefaultCredentials>();
                })
        #region Snippet:CoreWCF_Azure_Storage_Queus_Sample_Logging
                .ConfigureLogging((logging) =>
                {
                    logging.AddFilter("Microsoft.CoreWCF", LogLevel.Debug);
                });
        #endregion
    }
}
