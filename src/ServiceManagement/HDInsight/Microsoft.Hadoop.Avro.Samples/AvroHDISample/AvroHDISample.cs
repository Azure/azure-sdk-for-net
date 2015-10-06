// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

//
// This example illustrates some programming techniques related to interaction with Microsoft Azure HDInsight service.
// It also illustrate the usage of Microsoft Avro Library
// To run this sample you need to have an active Azure Subscription together with provisioned HDInsight cluster
// You also need to edit App.config file and insert the required Azure Subscription information before building the sample
// (or you can edit AvroHDISample.exe.config after the build)
//
// This file (AvroHDISample.cs) contains the major classes and methods required for the sample.
//
// Cluster.cs contains all classes that work directly with Microsoft Azure HDInsight clusters
//
// Stock.cs contains a definition of Stock class which is used to represent the sample data.
// Stock.cs is auto-generated from JSON schema using Microsoft Avro Library Code Generation utility
// 

namespace Microsoft.Hadoop.Avro.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Microsoft.Hadoop.Avro;
    using Microsoft.Hadoop.Avro.Container;
    using Microsoft.Hadoop.Client;

    /// <summary>
    /// This class will convert CSV files to Avro files, uploads them to corresponding Azure Blobs,
    /// creates an external Hive table backed by these files, performs some BI queries of the table, 
    /// gets the results and writes them to Console.
    /// </summary>
    internal sealed class AvroHdiSample
    {
        /// <summary>
        /// Program main entry.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            var sample = new AvroHdiSample();

            //Read Azure subscription and HDIsnight cluster information from config file
            sample.ParseAppConfig();

            //Parse command like arguments
            sample.ParseArguments(args);

            //Execute the major part of the sample
            sample.Execute();
        }

        #region Sample execution

        /// <summary>
        /// Execute the sample based on the command line arguments
        /// </summary>
        private void Execute()
        {
            if (this.option == "clean")
            {
                //Cleaning cluster
                this.CleanCluster();
            }
            else
            {
                //Run the main sample
                this.RunSample();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// Runs the sample (including pre- and post-cleaning the cluster)
        /// </summary>
        private void RunSample()
        {
            //Connects to cluster based upon the information from config file
            var cluster = new Cluster();
            this.ExecuteStep("Connecting to cluster", () => cluster.Connect(this.certificate, this.subscription, this.clusterName, this.storageAccountName, this.storageAccountKey));
            
            //Cleans cluster
            this.ExecuteStep("Cleaning cluster", cluster.CleanUp);
            
            //Read input CSV files, serialize them and upload to Azure blob
            this.ExecuteStep(
                "Uploading files",
                () =>
                {
                    //The sample expects an excerpt from historical AMEX stock data as distributed by Infochimps, http://www.infochimps.com/
                    //CSV files are distributed with the sample
                    for (char i = 'A'; i < 'C'; i++)
                    {
                        var input = Path.Combine(this.dataSetLocation, "AMEX_daily_prices_" + i + ".csv");

                        // Convert CSV file to Avro format using Reflection and auto generated C# types code,
                        // write it to stream and upload it to cluster
                        using (var stream = new MemoryStream())
                        {
                            SerializeCsv(input, stream);
                            cluster.UploadAvro("AMEX_daily_prices_" + i + ".avro", stream);
                        }
                    }
                });

            //Create Hive table
            this.ExecuteStep("Creating Hive table", cluster.CreateStocksTable);

            //Execute a Hive query
            this.ExecuteStep(
                "Executing Query ",
                () =>
                {
                    const string Query = "SELECT YEAR(stockdate), AVG(closeprice) FROM Stocks WHERE symbol='AIP' GROUP BY year(stockdate);";
                    Console.WriteLine(Query);
                    Console.Out.WriteLine(
                        cluster.Query(new HiveJobCreateParameters { Query = Query, JobName = "YearlyAverages" }));
                },
                true);
            
            //Another Hive query
            //Commented out to diminsh the sample run time
            //this.ExecuteStep(
            //   "Executing Query ",
            //    () =>
            //    {
            //        const string Query = "SELECT YEAR(stockdate), MAX(closeprice) FROM Stocks GROUP BY year(stockdate);";
            //        Console.WriteLine(Query);
            //        Console.Out.WriteLine(
            //            cluster.Query(new HiveJobCreateParameters { Query = Query, JobName = "YearlyMaxes" }));
            //    },
            //    true);
            
            //Clean the cluster
            this.ExecuteStep("Cleaning cluster", cluster.CleanUp);
        }

        /// <summary>
        /// Cleans the cluster.
        /// </summary>
        private void CleanCluster()
        {
            //Connects to cluster based upon the information from config file
            var cluster = new Cluster();
            this.ExecuteStep("Connecting to cluster", () => cluster.Connect(this.certificate, this.subscription, this.clusterName, this.storageAccountName, this.storageAccountKey));
            
            //Call the actual clean up procedure
            this.ExecuteStep("Cleaning cluster", cluster.CleanUp);
        }        

        /// <summary>
        /// Executes a sample step.
        /// </summary>
        /// <param name="consoleInfo">The console information.</param>
        /// <param name="step">The step.</param>
        /// <param name="actionHasOutput">if set to <c>true</c> then the console output will be formatted slightly differently.</param>
        private void ExecuteStep(string consoleInfo, Action step, bool actionHasOutput = false)
        {
            Console.Write(consoleInfo + " ... ");
            if (actionHasOutput)
            {
                Console.Write("\n");
            }

            step();
            if (actionHasOutput)
            {
                Console.Write("\n" + consoleInfo + " is done\n");
            }
            else
            {
                Console.Write(" Done\n");
            }
        }

        #endregion Sample execution

        #region Parsing arguments and appconfig

        //Defining config variables

        /// <summary>
        /// Azure Subscription
        /// </summary>
        private string subscription;

        /// <summary>
        /// Subscription Management Certificate Thumbprint
        /// </summary>
        private string certificate;

        /// <summary>
        /// HDInsight Cluster name
        /// </summary>
        private string clusterName;

        /// <summary>
        /// Azure Storage Account name
        /// </summary>
        private string storageAccountName;

        /// <summary>
        /// Azure Storage Account Access Key
        /// </summary>
        private string storageAccountKey;

        /// <summary>
        /// Path to CSV files
        /// </summary>
        private string dataSetLocation;

        /// <summary>
        /// Execution parameter (Run or Clean)
        /// </summary>
        private string option;

        /// <summary>
        /// Parses the application configuration file.
        /// </summary>
        private void ParseAppConfig()
        {
            // Read cluster access information from App.Config
            this.certificate = ConfigurationManager.AppSettings["certificate"];
            if (string.IsNullOrEmpty(this.certificate))
            {
                ReportError("Please specify a valid Management Certificate thumbprint for 'cerfiticate' key in App.config.");
            }

            this.subscription = ConfigurationManager.AppSettings["subscription"];
            if (string.IsNullOrEmpty(this.subscription))
            {
                ReportError("Please specify a valid Azure Subscription ID for 'subscription' key in App.config.");
            }

            this.clusterName = ConfigurationManager.AppSettings["clustername"];
            if (string.IsNullOrEmpty(this.clusterName))
            {
                ReportError("Please specify a valid Azure HDInsight Cluster name for 'clustername' key in App.config.");
            }

            this.storageAccountName = ConfigurationManager.AppSettings["storageAccountName"];
            if (string.IsNullOrEmpty(this.storageAccountName))
            {
                ReportError("Please specify a valid Azure Storage Account name for 'storageAccountName' key in App.config.");
            }

            this.storageAccountKey = ConfigurationManager.AppSettings["storageAccountKey"];
            if (string.IsNullOrEmpty(this.storageAccountKey))
            {
                ReportError("Please specify a valid Azure Storage Account Primary or Secondary Access Key for 'storageAccountKey' key in App.config.");
            }
        }

        /// <summary>
        /// Parses the arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        private void ParseArguments(IList<string> arguments)
        {
            //Usage command prompt
            string Usage = "Usage: AvroHDISample.exe [clean|run <dataset path>]";

            // Get data set location
            if (!arguments.Any())
            {
                ReportError("Error: Missing argument.\n" + Usage);
            }

            this.option = arguments[0].ToLower(CultureInfo.InvariantCulture);
            if (this.option != "clean" && this.option != "run")
            {
                ReportError("Error: Unknown argument.\n" + Usage);
            }

            if (this.option == "run")
            {
                if (arguments.Count < 2)
                {
                    ReportError("Error: dataset location is missing, to run the sample please the path of the folder containing CSV data files.\n" + Usage);
                }

                this.dataSetLocation = arguments[1];
                if (!Directory.Exists(this.dataSetLocation))
                {
                    ReportError("Error: The folder " + this.dataSetLocation + " does not exist, please specify a valid folder.");
                }

                if (!this.dataSetLocation.EndsWith("\\"))
                {
                    this.dataSetLocation += "\\";
                }

                if (Directory.GetFiles(this.dataSetLocation, "AMEX_daily_prices_*.csv", SearchOption.TopDirectoryOnly).Length == 0)
                {
                    ReportError("Error: The provided folder " + this.dataSetLocation + " does not contain expected CSV files (AMEX_daily_prices_*.csv), please specify a folder containing these files.");
                }
            }
        }
        
        /// <summary>
        /// Reports the error and exits the program.
        /// </summary>
        /// <param name="error">The error.</param>
        internal static void ReportError(string error)
        {
            Console.WriteLine("\n" + error);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
            Environment.Exit(-1);
        }
        #endregion //Parsing arguments and appconfig

        #region Handling CSV files

        /// <summary>
        /// Reads CSV file data and converts records to instances of Stock class then serializes them using Reflection.
        /// Stock type definition is created from JSON schema using Microsoft Avro Library Code Generation utility
        /// </summary>
        /// <param name="inputFilePath">The input file path.</param>
        /// <param name="outputStream">The output stream.</param>
        private void SerializeCsv(string inputFilePath, Stream outputStream)
        {
            try
            {
                // Create an Avro writer using Null Codec
                var writer = AvroContainer.CreateWriter<Stock>(
                    outputStream,
                    new AvroSerializerSettings { Resolver = new AvroDataContractResolver(true) },
                    Codec.Null);

                // Create a new sequential writer and use it to write Avro file using a block length of 100
                using (var seq = new SequentialWriter<Stock>(writer, 100))
                {
                    foreach (var stock in this.ReadCsv(inputFilePath))
                    {
                        seq.Write(stock);
                    }
                }
            }
            catch (Exception e)
            {
                ReportError("Error while creating Avro file(s) from CSV file(s)" + e);
            }
        }

        /// <summary>
        /// Reads the CSV file entries and creates a <see cref="Stock"/> object from each of them.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>List of stocks.</returns>
        private IEnumerable<Stock> ReadCsv(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    streamReader.ReadLine();
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var values = line.Split(new[] { ',' });
                        yield return
                            new Stock(
                                values[1],
                                values[2],
                                float.Parse(values[3], CultureInfo.InvariantCulture),
                                float.Parse(values[4], CultureInfo.InvariantCulture),
                                float.Parse(values[5], CultureInfo.InvariantCulture),
                                float.Parse(values[6], CultureInfo.InvariantCulture),
                                long.Parse(values[7]),
                                float.Parse(values[8], CultureInfo.InvariantCulture));
                    }
                }
            }
        }

        #endregion //Handling CSV files
    }
}