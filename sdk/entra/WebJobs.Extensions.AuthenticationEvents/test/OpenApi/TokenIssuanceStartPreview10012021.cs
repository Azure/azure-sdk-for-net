using Microsoft.Azure.WebJobs.Extensions.CustomAuthenticationExtension;
using Microsoft.Azure.WebJobs.Extensions.CustomAuthenticationExtension.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using payloads = WebJobs.Extensions.CustomAuthenticationExtension.Tests.Payloads;
namespace WebJobs.Extensions.CustomAuthenticationExtension.Tests.OpenApi
{
    /// <summary>Class to house open api tests for the OnTokenIssuanceStart event version preview_10_01_2021</summary>
    public class OpenApi
    {
        /// <summary>Tests the the open api document and related schemas can be exported successfully.</summary>
        [Fact]
        public void OpenApiDocumentExportTest()
        {
            string testDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid().ToString());
            Directory.CreateDirectory(testDir);
            try
            {
                OpenApiDocument openApiDocument = OpenApiDocument.Load(EventDefinition.TokenIssuanceStart_V2021_10_01_Preview);
                Dictionary<OpenAPIDocumentTypes, string> paths = openApiDocument.SaveAsync(testDir).Result;
                Assert.True(TestHelper.DoesFilePayloadMatch(payloads.OpenApi.OpenApi.OpenApiDocument, paths[OpenAPIDocumentTypes.OpenApiDocument]));
                Assert.True(TestHelper.DoesFilePayloadMatch(payloads.TokenIssuanceStart.Preview10012021.TokenIssuanceStartPreview10012021.RequestSchema, paths[OpenAPIDocumentTypes.RequestSchema]));
                Assert.True(TestHelper.DoesFilePayloadMatch(payloads.TokenIssuanceStart.Preview10012021.TokenIssuanceStartPreview10012021.ResponseSchema, paths[OpenAPIDocumentTypes.ResponseSchema]));
            }
            finally
            {
                Directory.Delete(testDir, true);
            }
        }

        /// <summary>Tests the the open api document and related schemas can be merged successfully.</summary>
        [Fact]
        public void OpenApiDocumentMergeTest()
        {
            OpenApiDocument openApiDocument = OpenApiDocument.Load(EventDefinition.TokenIssuanceStart_V2021_10_01_Preview);
            AuthEventJsonElement result = openApiDocument.EmbedReferences();

            Assert.True(TestHelper.DoesPayloadMatch(payloads.OpenApi.OpenApi.OpenApiDocumentMerge, result.ToString()));
        }

        /// <summary>Tests the the open api document and related schemas can be merged successfully.</summary>
        [Fact]
        public void OpenApiDocumentMergeAndSaveTest()
        {
            string testDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid().ToString());
            Directory.CreateDirectory(testDir);
            string testFile = Path.Combine(testDir, $"{Guid.NewGuid()}.json");
            try
            {
                OpenApiDocument openApiDocument = OpenApiDocument.Load(EventDefinition.TokenIssuanceStart_V2021_10_01_Preview);
                openApiDocument.EmbedReferencesAndSaveAsync(testFile).Wait();
                string actual = File.ReadAllText(testFile);
                Assert.True(TestHelper.DoesPayloadMatch(payloads.OpenApi.OpenApi.OpenApiDocumentMerge, actual));
            }
            finally
            {
                Directory.Delete(testDir, true);
            }
        }

        /// <summary>Tests the the open api document can be loaded from a namespace successfully.</summary>
        [Fact]
        public void OpenApiDocument_NameSpace_load()
        {
            OpenApiDocument openApiDocument = OpenApiDocument.Load(payloads.TokenIssuanceStart.Preview10012021.TokenIssuanceStartPreview10012021.VersionNameSpace);
            Assert.True(openApiDocument.EventNameSpace == payloads.TokenIssuanceStart.Preview10012021.TokenIssuanceStartPreview10012021.VersionNameSpace);
        }
    }
}
