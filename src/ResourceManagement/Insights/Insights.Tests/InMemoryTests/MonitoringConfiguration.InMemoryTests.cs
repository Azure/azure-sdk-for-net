//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Insights.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;
using Xunit.Sdk;

namespace Insights.Tests.InMemoryTests
{
    public class MonitoringConfigurationInMemoryTests : TestBase
    {
        [Fact]
        public void GetStorageConfigurationTest()
        {
            string storageConfigurationContent =
                @"{
	                'location': 'location1',
	                'name': 'name1',
	                'properties': {
		                'logging': {
			                'delete': true,
			                'read': false,
			                'retention': 'P30D',
			                'write': true
		                },
		                'metrics': {
			                'aggregations': [{
				                'level': 'Service',
				                'retention': 'P10D',
				                'scheduledTransferPeriod': 'P1D'
			                }]
		                }
	                },
	                'requestId': 'requestid1'	
                }";

            StorageConfigurationGetResponse expectedStorageConfiguration = GetStorageConfiguration();
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(storageConfigurationContent)
            };

            var handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsManagementClient(handler);
            StorageConfigurationGetResponse actualStorageConfiguration = insightsClient.MonitoringConfigurationOperations.GetStorageConfiguration(resourceUri: "r1");
            AreEqual(expectedStorageConfiguration.Properties, actualStorageConfiguration.Properties);
        }

        [Fact]
        public void GetConfigurationTest()
        {
            string expectedMonitoringConfigurationContent =
                @"{
	                'location': 'l1',
	                'name': 'n1',
	                'properties': {
		                'description': 'd1',
		                'name': 'n1',
		                'publicConfiguration': {
			                'odata.type': 'Microsoft.Azure.Management.Insights.Models.PublicMonitoringConfiguration',
			                'diagnosticMonitorConfiguration': {
				                'crashDumps': {
					                'containerName': 'c1',
					                'directoryQuotaPercentage': 50,
					                'dumpType': 'Mini',
					                'processes': ['w3wp.exe']
				                },
				                'diagnosticInfrastructureLogs': {
					                'scheduledTransferLogLevelFilter': 'Verbose',
					                'scheduledTransferPeriod': 'PT10M'
				                },
				                'directories': {
					                'dataSources': [{
						                'containerName': 'c1',
						                'path': {
                                            'odata.type': 'Microsoft.Azure.Management.Insights.Models.DirectoryAbsolute',
							                'expandEnvironment': true,
							                'path': 'p1'
						                }
					                }],
					                'failedRequestLogs': 'f1',
					                'iisLogs': 'i1',
					                'scheduledTransferPeriod': 'P1D'
				                },
				                'etwProviders': {
					                'eventSourceProviders': [{
						                'defaultDestination': 'dd1',
						                'events': [{
							                'destination': 'dd1',
							                'eventId': 23
						                }],
						                'provider': 'p1',
						                'scheduledTransferKeywordFilter': 10,
						                'scheduledTransferLogLevelFilter': 'Verbose',
						                'scheduledTransferPeriod': 'P2D'
					                }],
					                'manifestProviders': [{
						                'defaultDestination': 'dd1',
						                'events': [{
							                'destination': 'dd1',
							                'eventId': 23
						                }],
						                'provider': 'p1',
						                'scheduledTransferKeywordFilter': 10,
						                'scheduledTransferLogLevelFilter': 'Verbose',
						                'scheduledTransferPeriod': 'P2D'
					                }]
				                },
				                'metrics': {
					                'aggregations': [{
						                'scheduledTransferPeriod': 'PT0.01S'
					                }],
					                'resourceId': 'r1'
				                },
				                'overallQuotaInMB': 100,
				                'performanceCounters': {
					                'counters': [{
						                'annotations': [{
							                'locale': 'en-US',
							                'value': 'val1'
						                }],
						                'counterSpecifier': 'c1',
						                'sampleRate': 'P2D',
						                'unit': 'Bytes'
					                }],
					                'scheduledTransferPeriod': 'P1D'
				                },
				                'windowsEventLog': {
					                'dataSources': ['d1'],
					                'scheduledTransferPeriod': 'PT10S'
				                }
			                },
			                'localResourceDirectory': null,
			                'storageAccount': null
		                }
	                },
	                'requestId': 'r1'
                }";
            MonitoringConfigurationGetResponse expectedResponse = GetMonitoringConfiguration();
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedMonitoringConfigurationContent)
            };
            var handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsManagementClient(handler);
            MonitoringConfigurationGetResponse actualResponse = insightsClient.MonitoringConfigurationOperations.GetConfiguration(resourceUri: "res1");
            AreEqual(expectedResponse.Properties, actualResponse.Properties);
        }

        [Fact]
        public void CreateOrUpdateStorageConfigurationTest()
        {
            CreateOrUpdateStorageConfigurationParameters expectedParameters = GetCreateOrUpdateStorageConfigurationParameters();
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);
            insightsClient.MonitoringConfigurationOperations.CreateOrUpdateStorageConfiguration(
                resourceUri: "res1",
                parameters: expectedParameters);
            var fixedRequestString = handler.Request
                .Replace("\"logging\":", "\"loggingConfiguration\":")
                .Replace("\"metrics\":", "\"metricConfiguration\":")
                .Replace("\"aggregations\":", "\"metricAggregations\":");
            var actualParameters = JsonExtensions.FromJson<CreateOrUpdateStorageConfigurationParameters>(fixedRequestString);
            AreEqual(expectedParameters.Properties, actualParameters.Properties);
        }

        private CreateOrUpdateStorageConfigurationParameters GetCreateOrUpdateStorageConfigurationParameters()
        {
            return new CreateOrUpdateStorageConfigurationParameters()
            {
                Properties = GetStorageConfiguration().Properties
            };
        }

        [Fact]
        public void CreateOrUpdateConfigurationTest()
        {
            MonitoringConfigurationCreateOrUpdateParameters expectedParameters = GetCreateOrUpdateConfigurationParameters();
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);
            insightsClient.MonitoringConfigurationOperations.CreateOrUpdateConfiguration(
                resourceUri: "res1",
                parameters: expectedParameters);

            var fixedRequestString = handler.Request
                .Replace("\"aggregations\":", "\"metricAggregations\":");
            var actualParameters = JsonExtensions.FromJson<MonitoringConfigurationCreateOrUpdateParameters>(fixedRequestString);
            AreEqual(expectedParameters.Properties, actualParameters.Properties);
        }

        private MonitoringConfigurationCreateOrUpdateParameters GetCreateOrUpdateConfigurationParameters()
        {
            return new MonitoringConfigurationCreateOrUpdateParameters()
            {
                Properties = GetMonitoringConfiguration().Properties
            };
        }

        [Fact]
        public void UpdateStorageConfiguration()
        {
            // This is he same as the CreateOrUpdateStorageConfiguration test
        }

        [Fact]
        public void UpdateCOnfiguration()
        {
            // This is the same as the CreateOrUpdateConfigation test
        }

        private void AreEqual(StorageConfiguration exp, StorageConfiguration act)
        {
            if (exp != null)
            {
                AreEqual(exp.LoggingConfiguration, act.LoggingConfiguration);
                AreEqual(exp.MetricConfiguration, act.MetricConfiguration);
            }
        }

        private void AreEqual(StorageMetricConfiguration exp, StorageMetricConfiguration act)
        {
            if (exp != null)
            {
                AreEqual(exp.MetricAggregations, act.MetricAggregations);
            }
        }

        private void AreEqual(IList<StorageMetricAggregation> exp, IList<StorageMetricAggregation> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private void AreEqual(StorageMetricAggregation exp, StorageMetricAggregation act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Level, act.Level);
                Assert.Equal(exp.Retention, act.Retention);
                Assert.Equal(exp.ScheduledTransferPeriod, act.ScheduledTransferPeriod);
            }
        }

        private void AreEqual(StorageLoggingConfiguration exp, StorageLoggingConfiguration act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Delete, act.Delete);
                Assert.Equal(exp.Read, act.Read);
                Assert.Equal(exp.Retention, act.Retention);
                Assert.Equal(exp.Write, act.Write);
            }
        }

        private StorageConfigurationGetResponse GetStorageConfiguration()
        {
            return new StorageConfigurationGetResponse()
            {
                Location = "location1",
                Name = "name1",
                RequestId = "requestid1",
                Properties = new StorageConfiguration
                {
                    LoggingConfiguration = new StorageLoggingConfiguration()
                    {
                        Delete = true,
                        Retention = TimeSpan.FromDays(30),
                        Read = false,
                        Write = true
                    },
                    MetricConfiguration = new StorageMetricConfiguration()
                    {
                        MetricAggregations = new List<StorageMetricAggregation>()
                        {
                            new StorageMetricAggregation()
                            {
                                Level = StorageMetricLevel.Service,
                                Retention = TimeSpan.FromDays(10),
                                ScheduledTransferPeriod = TimeSpan.FromDays(1)
                            }
                        }
                    }
                }
            };
        }

        private void AreEqual(DiagnosticSettings exp, DiagnosticSettings act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.Name, act.Name);
                AreEqual(exp.PublicConfiguration, act.PublicConfiguration);
            }
        }

        private void AreEqual(PublicConfiguration exp, PublicConfiguration act)
        {
            if (exp is PublicMonitoringConfiguration)
            {
                var expMonConfig = exp as PublicMonitoringConfiguration;
                var actMonConfig = act as PublicMonitoringConfiguration;

                AreEqual(expMonConfig.DiagnosticMonitorConfiguration, actMonConfig.DiagnosticMonitorConfiguration);
                AreEqual(expMonConfig.LocalResourceDirectory, actMonConfig.LocalResourceDirectory);
                Assert.Equal(expMonConfig.StorageAccount, actMonConfig.StorageAccount);
            }
        }

        private void AreEqual(DirectoryAbsolute exp, DirectoryAbsolute act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ExpandEnvironment, act.ExpandEnvironment);
                Assert.Equal(exp.Path, act.Path);
            }
        }

        private void AreEqual(DiagnosticMonitorConfiguration exp, DiagnosticMonitorConfiguration act)
        {
            if (exp != null)
            {
                AreEqual(exp.CrashDumps, act.CrashDumps);
                AreEqual(exp.DiagnosticInfrastructureLogs, act.DiagnosticInfrastructureLogs);
                AreEqual(exp.Directories, act.Directories);
                AreEqual(exp.EtwProviders, act.EtwProviders);
                AreEqual(exp.Metrics, act.Metrics);
                Assert.Equal(exp.OverallQuotaInMB, act.OverallQuotaInMB);
                AreEqual(exp.PerformanceCounters, act.PerformanceCounters);
                AreEqual(exp.WindowsEventLog, act.WindowsEventLog);
            }
        }

        private void AreEqual(WindowsEventLog exp, WindowsEventLog act)
        {
            if (exp != null)
            {
                AreEqual(exp.DataSources, act.DataSources);
            }
        }

        private void AreEqual(PerformanceCounters exp, PerformanceCounters act)
        {
            if (exp != null)
            {
                AreEqual(exp.Counters, act.Counters);
            }
        }

        private void AreEqual(IList<PerformanceCounterConfiguration> exp, IList<PerformanceCounterConfiguration> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private void AreEqual(PerformanceCounterConfiguration exp, PerformanceCounterConfiguration act)
        {
            if (exp != null)
            {
                AreEqual(exp.Annotations, act.Annotations);
                Assert.Equal(exp.CounterSpecifier, act.CounterSpecifier);
                Assert.Equal(exp.SampleRate, act.SampleRate);
                Assert.Equal(exp.Unit, act.Unit);
            }
        }

        private void AreEqual(IList<LocalizedString> exp, IList<LocalizedString> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private void AreEqual(LocalizedString exp, LocalizedString act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Locale, act.Locale);
                Assert.Equal(exp.Value, act.Value);
            }
        }

        private void AreEqual(Metrics exp, Metrics act)
        {
            if (exp != null)
            {
                AreEqual(exp.MetricAggregations, act.MetricAggregations);
                Assert.Equal(exp.ResourceId, act.ResourceId);
            }
        }

        private void AreEqual(IList<MetricAggregation> exp, IList<MetricAggregation> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private void AreEqual(MetricAggregation exp, MetricAggregation act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ScheduledTransferPeriod, act.ScheduledTransferPeriod);
            }
        }

        private void AreEqual(EtwProviders exp, EtwProviders act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.EventSourceProviders.Count; i++)
                {
                    AreEqual(exp.EventSourceProviders[i], act.EventSourceProviders[i]);
                }

                for (int i = 0; i < exp.ManifestProviders.Count; i++)
                {
                    AreEqual(exp.ManifestProviders[i], act.ManifestProviders[i]);
                }
            }
        }

        private void AreEqual(EtwProvider exp, EtwProvider act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.DefaultDestination, act.DefaultDestination);
                AreEqual(exp.Events, act.Events);
                Assert.Equal(exp.Provider, act.Provider);
                Assert.Equal(exp.ScheduledTransferKeywordFilter, act.ScheduledTransferKeywordFilter);
                Assert.Equal(exp.ScheduledTransferLogLevelFilter, act.ScheduledTransferLogLevelFilter);
                Assert.Equal(exp.ScheduledTransferPeriod, act.ScheduledTransferPeriod);
            }
        }

        private void AreEqual(IList<EtwEventConfiguration> exp, IList<EtwEventConfiguration> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private void AreEqual(EtwEventConfiguration exp, EtwEventConfiguration act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Destination, act.Destination);
                Assert.Equal(exp.EventId, act.EventId);
            }
        }

        private void AreEqual(Directories exp, Directories act)
        {
            if (exp != null)
            {
                AreEqual(exp.DataSources, act.DataSources);
                Assert.Equal(exp.FailedRequestLogs, act.FailedRequestLogs);
                Assert.Equal(exp.IISLogs, act.IISLogs);
            }
        }

        private void AreEqual(IList<DirectoryConfiguration> exp, IList<DirectoryConfiguration> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private void AreEqual(DirectoryConfiguration exp, DirectoryConfiguration act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ContainerName, act.ContainerName);
                AreEqual(exp.Path, act.Path);
            }
        }

        private void AreEqual(DirectoryPath exp, DirectoryPath act)
        {
            if (exp is DirectoryAbsolute)
            {
                var expAbsDir = exp as DirectoryAbsolute;
                var actAbsDir = act as DirectoryAbsolute;

                Assert.Equal(expAbsDir.ExpandEnvironment, actAbsDir.ExpandEnvironment);
                Assert.Equal(expAbsDir.Path, actAbsDir.Path);
            }
        }

        private void AreEqual(DiagnosticInfrastructureLogs exp, DiagnosticInfrastructureLogs act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ScheduledTransferLogLevelFilter, act.ScheduledTransferLogLevelFilter);
            }
        }

        private void AreEqual(CrashDumps exp, CrashDumps act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ContainerName, act.ContainerName);
                Assert.Equal(exp.DirectoryQuotaPercentage, act.DirectoryQuotaPercentage);
                Assert.Equal(exp.DumpType, act.DumpType);
                AreEqual(exp.Processes, act.Processes);
            }
        }

        private MonitoringConfigurationGetResponse GetMonitoringConfiguration()
        {
            return new MonitoringConfigurationGetResponse()
            {
                Location = "l1",
                Name = "n1",
                RequestId = "r1",
                Properties = new DiagnosticSettings
                {
                    Description = "d1",
                    Name = "n1",
                    PublicConfiguration = new PublicMonitoringConfiguration()
                    {
                        DiagnosticMonitorConfiguration = new DiagnosticMonitorConfiguration()
                        {
                            CrashDumps = new CrashDumps()
                            {
                                ContainerName = "c1",
                                DirectoryQuotaPercentage = 50,
                                DumpType = CrashDumpType.Mini,
                                Processes = new List<string>() { "w3wp.exe" }
                            },
                            DiagnosticInfrastructureLogs = new DiagnosticInfrastructureLogs()
                            {
                                ScheduledTransferPeriod = TimeSpan.FromMinutes(10),
                                ScheduledTransferLogLevelFilter = LogLevel.Verbose
                            },
                            Directories = new Directories()
                            {
                                DataSources = new List<DirectoryConfiguration>()
                                {
                                    new DirectoryConfiguration()
                                    {
                                        ContainerName = "c1",
                                        Path = new DirectoryAbsolute() {ExpandEnvironment = true, Path = "p1"}
                                    }
                                },
                                FailedRequestLogs = "f1",
                                IISLogs = "i1",
                                ScheduledTransferPeriod = TimeSpan.FromDays(1)
                            },
                            EtwProviders = new EtwProviders()
                            {
                                EventSourceProviders = new List<EtwProvider>()
                                {
                                    new EtwProvider()
                                    {
                                        DefaultDestination = "dd1",
                                        Events = new List<EtwEventConfiguration>()
                                        {
                                            new EtwEventConfiguration()
                                            {
                                                Destination = "dd1",
                                                EventId = 23
                                            }
                                        },
                                        Provider = "p1",
                                        ScheduledTransferKeywordFilter = 10,
                                        ScheduledTransferLogLevelFilter = LogLevel.Verbose,
                                        ScheduledTransferPeriod = TimeSpan.FromDays(2)
                                    }
                                },
                                ManifestProviders = new List<EtwProvider>()
                                {
                                    new EtwProvider()
                                    {
                                        DefaultDestination = "dd1",
                                        Events = new List<EtwEventConfiguration>()
                                        {
                                            new EtwEventConfiguration()
                                            {
                                                Destination = "dd1",
                                                EventId = 23
                                            }
                                        },
                                        Provider = "p1",
                                        ScheduledTransferKeywordFilter = 10,
                                        ScheduledTransferLogLevelFilter = LogLevel.Verbose,
                                        ScheduledTransferPeriod = TimeSpan.FromDays(2)
                                    }
                                }
                            },
                            Metrics = new Metrics()
                            {
                                MetricAggregations = new List<MetricAggregation>()
                                {
                                    new MetricAggregation()
                                    {
                                        ScheduledTransferPeriod = TimeSpan.FromMilliseconds(10)
                                    }
                                },
                                ResourceId = "r1"
                            },
                            OverallQuotaInMB = 100,
                            PerformanceCounters = new PerformanceCounters()
                            {
                                Counters = new List<PerformanceCounterConfiguration>()
                                {
                                    new PerformanceCounterConfiguration()
                                    {
                                        Annotations = new List<LocalizedString>()
                                        {
                                            new LocalizedString() {Locale = "en-US", Value = "val1"}
                                        },
                                        CounterSpecifier = "c1",
                                        SampleRate = TimeSpan.FromDays(2),
                                        Unit = Units.Bytes
                                    }
                                },
                                ScheduledTransferPeriod = TimeSpan.FromDays(1),
                            },
                            WindowsEventLog = new WindowsEventLog()
                            {
                                DataSources = new List<string>() { "d1" },
                                ScheduledTransferPeriod = TimeSpan.FromSeconds(10)
                            }
                        }
                    }
                }
            };
        }
    }
}
