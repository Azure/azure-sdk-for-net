namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Globalization;
    using System.IO;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;
    using System.Linq;

    public class AppsTests : BaseTest
    {
        [Fact]
        public void ListApplications()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "Existing LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                // Test
                var result = await client.Apps.ListAsync();

                Assert.NotEqual(0, result.Count);
                Assert.Contains(result, o => o.Name == "Existing LUIS App");

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void AddApplication()
        {
            UseClientFor(async client =>
            {
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "New LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var savedApp = await client.Apps.GetAsync(testAppId);

                Assert.NotNull(savedApp);
                Assert.Equal("New LUIS App", savedApp.Name);
                Assert.Equal("New LUIS App", savedApp.Description);
                Assert.Equal("en-us", savedApp.Culture);
                Assert.Equal("Comics", savedApp.Domain);
                Assert.Equal("IoT", savedApp.UsageScenario);

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void GetApplication()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "Existing LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var result = await client.Apps.GetAsync(testAppId);
                Assert.Equal(testAppId, result.Id);
                Assert.Equal("Existing LUIS App", result.Name);
                Assert.Equal("en-us", result.Culture);
                Assert.Equal("Comics", result.Domain);
                Assert.Equal("IoT", result.UsageScenario);

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void UpdateApplication()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App to be renamed",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Apps.UpdateAsync(testAppId, new ApplicationUpdateObject
                {
                    Name = "LUIS App name updated",
                    Description = "LUIS App description updated"
                });

                var app = await client.Apps.GetAsync(testAppId);

                Assert.Equal("LUIS App name updated", app.Name);
                Assert.Equal("LUIS App description updated", app.Description);

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void DeleteApplication()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App to be deleted",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Apps.DeleteAsync(testAppId);

                // Assert
                var result = await client.Apps.ListAsync();
                Assert.DoesNotContain(result, o => o.Id == testAppId);
            });
        }

        [Fact]
        public void ListEndpoints()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for endpoint test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var result = await client.Apps.ListEndpointsAsync(testAppId);

                Assert.Equal("https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/" + testAppId, result["westus"]);
                Assert.Equal("https://eastus2.api.cognitive.microsoft.com/luis/v2.0/apps/" + testAppId, result["eastus2"]);
                Assert.Equal("https://westcentralus.api.cognitive.microsoft.com/luis/v2.0/apps/" + testAppId, result["westcentralus"]);
                Assert.Equal("https://southeastasia.api.cognitive.microsoft.com/luis/v2.0/apps/" + testAppId, result["southeastasia"]);

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void PublishApplication()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.PublishAsync(appId, new ApplicationPublishObject
                {
                    IsStaging = false,
                    Region = "westus",
                    VersionId = "0.1"
                });

                Assert.Equal("https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/" + appId, result.EndpointUrl);
                Assert.Equal("westus", result.EndpointRegion);
                Assert.False(result.IsStaging);
            });
        }

        [Fact]
        public void DownloadQueryLogs()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for Query Logs test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var downloadStream = await client.Apps.DownloadQueryLogsAsync(testAppId);
                var reader = new StreamReader(downloadStream);

                var csv = reader.ReadToEnd();
                Assert.False(string.IsNullOrEmpty(csv));

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void GetSettings()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for Settings test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var settings = await client.Apps.GetSettingsAsync(testAppId);

                Assert.Equal(testAppId, settings.Id);
                Assert.False(settings.IsPublic);

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void UpdateSettings()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for Settings test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Apps.UpdateSettingsAsync(testAppId, new ApplicationSettingUpdateObject
                {
                    PublicProperty = true
                });

                // Assert
                var settings = await client.Apps.GetSettingsAsync(testAppId);
                Assert.True(settings.IsPublic);

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void GetPublishSettings()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for Settings test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var settings = await client.Apps.GetPublishSettingsAsync(testAppId);

                Assert.Equal(testAppId, settings.Id);
                Assert.False(settings.IsSentimentAnalysisEnabled);
                Assert.False(settings.IsSpeechEnabled);
                Assert.False(settings.IsSpellCheckerEnabled);

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void UpdatePublishSettings()
        {
            UseClientFor(async client =>
            {
                // Initialize
                var testAppId = await client.Apps.AddAsync(new ApplicationCreateObject()
                {
                    Name = "LUIS App for Settings test",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Apps.UpdatePublishSettingsAsync(testAppId, new PublishSettingUpdateObject
                {
                    SentimentAnalysis = true,
                    Speech = true,
                    SpellChecker = true
                });

                // Assert
                var settings = await client.Apps.GetPublishSettingsAsync(testAppId);
                Assert.True(settings.IsSentimentAnalysisEnabled);
                Assert.True(settings.IsSpeechEnabled);
                Assert.True(settings.IsSpellCheckerEnabled);

                // Cleanup
                await client.Apps.DeleteAsync(testAppId);
            });
        }

        [Fact]
        public void ListDomains()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.ListDomainsAsync();
                foreach (var domain in result)
                {
                    Assert.False(string.IsNullOrWhiteSpace(domain));
                }
            });
        }

        [Fact]
        public void ListSupportedCultures()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.ListSupportedCulturesAsync();
                foreach (var culture in result)
                {
                    var cult = new CultureInfo(culture.Code);
                    Assert.Equal(cult.Name.ToLowerInvariant(), culture.Code);
                }
            });
        }

        [Fact]
        public void ListUsageScenarios()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.ListUsageScenariosAsync();
                foreach (var scenario in result)
                {
                    Assert.False(string.IsNullOrWhiteSpace(scenario));
                }
            });
        }

        [Fact]
        public void ListAvailableCustomPrebuiltDomains()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.ListAvailableCustomPrebuiltDomainsAsync();
                foreach (var prebuiltDomain in result)
                {
                    Assert.NotNull(prebuiltDomain);
                    Assert.False(string.IsNullOrWhiteSpace(prebuiltDomain.Description));
                    Assert.NotNull(prebuiltDomain.Intents);
                    Assert.NotNull(prebuiltDomain.Entities);
                }
            });
        }

        [Fact]
        public void ListAvailableCustomPrebuiltDomainsForCulture()
        {
            UseClientFor(async client =>
            {
                var resultsUS = await client.Apps.ListAvailableCustomPrebuiltDomainsForCultureAsync("en-US");
                var resultsCN = await client.Apps.ListAvailableCustomPrebuiltDomainsForCultureAsync("zh-CN");

                foreach (var resultUS in resultsUS)
                {
                    Assert.DoesNotContain(resultsCN, r => r.Description == resultUS.Description);
                }
                foreach (var resultCN in resultsCN)
                {
                    Assert.DoesNotContain(resultsUS, r => r.Description == resultCN.Description);
                }
            });
        }

        [Fact]
        public void AddCustomPrebuiltApplication()
        {
            UseClientFor(async client =>
            {
                var domain = new PrebuiltDomainCreateObject
                {
                    Culture = "en-US",
                    DomainName = "Calendar"
                };

                var result = await client.Apps.AddCustomPrebuiltDomainAsync(domain);

                // Cleanup
                await client.Apps.DeleteAsync(result);

                // Assert
                Assert.True(result != Guid.Empty);
            });
        }
        
        [Fact]
        public void ListCortanaEndpoints()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.ListCortanaEndpointsAsync();

                Assert.True(result.EndpointUrls.Values.All(url => Uri.TryCreate(url, UriKind.Absolute, out Uri uri)));
            });
        }
    }
}
