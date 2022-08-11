using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using payloads = WebJobs.Extensions.AuthenticationEvents.Tests.Payloads;
namespace WebJobs.Extensions.AuthenticationEvents.Tests.OpenApi
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
                OpenApiDocument openApiDocument = OpenApiDocument.Load(EventDefinition.TokenIssuanceStartV20211001Preview);
                Dictionary<OpenAPIDocumentType, string> paths = openApiDocument.Save(testDir);
                Assert.True(TestHelper.DoesFilePayloadMatch(payloads.OpenApi.OpenApi.OpenApiDocument, paths[OpenAPIDocumentType.OpenApiDocument]));
                Assert.True(TestHelper.DoesFilePayloadMatch(payloads.TokenIssuanceStart.Preview10012021.TokenIssuanceStartPreview10012021.RequestSchema, paths[OpenAPIDocumentType.RequestSchema]));
                Assert.True(TestHelper.DoesFilePayloadMatch(payloads.TokenIssuanceStart.Preview10012021.TokenIssuanceStartPreview10012021.ResponseSchema, paths[OpenAPIDocumentType.ResponseSchema]));
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
            OpenApiDocument openApiDocument = OpenApiDocument.Load(EventDefinition.TokenIssuanceStartV20211001Preview);
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
                OpenApiDocument openApiDocument = OpenApiDocument.Load(EventDefinition.TokenIssuanceStartV20211001Preview);
                openApiDocument.EmbedReferencesAndSave(testFile);
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
