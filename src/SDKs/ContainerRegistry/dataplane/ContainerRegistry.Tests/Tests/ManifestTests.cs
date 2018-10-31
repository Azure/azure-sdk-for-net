// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class ManifestTests
    {
        private static readonly AcrManifestAttributes ExpectedAttributesOfProdRepository = new AcrManifestAttributes()
        {
            ImageName = ACRTestUtil.ProdRepository,
            Registry = ACRTestUtil.ManagedTestRegistryFullName,
            Manifest = new AcrManifestAttributesBase()
            {
                Architecture = "amd64",
                CreatedTime = "2018-09-28T23:37:51.9987277Z",
                LastUpdateTime = "2018-09-28T23:37:51.9987277Z",
                Digest = "sha256:eabe547f78d4c18c708dd97ec3166cf7464cc651f1cbb67e70d407405b7ad7b6",
                MediaType = "application/vnd.docker.distribution.manifest.v2+json",
                Os = "linux",
                Tags = new List<string>() { "latest" },
                ChangeableAttributes = new ChangeableAttributes()
                {
                    DeleteEnabled = true,
                    ListEnabled = true,
                    ReadEnabled = true,
                    WriteEnabled = true
                }
            }
        };

        [Fact]        
        public async Task GetAcrManifestAttributesMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrManifestAttributesMR)))
            {                
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var repositoryAttributes = await client.GetAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, 
                    "sha256:eabe547f78d4c18c708dd97ec3166cf7464cc651f1cbb67e70d407405b7ad7b6");

                Assert.Equal(ExpectedAttributesOfProdRepository.ImageName, repositoryAttributes.ImageName);
                Assert.Equal(ExpectedAttributesOfProdRepository.Registry, repositoryAttributes.Registry);
                VerifyAcrManifestAttributesBase(ExpectedAttributesOfProdRepository.Manifest, repositoryAttributes.Manifest);
            }            
        }
        
        [Fact]
        public async Task GetAcrManifestAttributesCRReturnsNull()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrManifestAttributesCRReturnsNull)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                var manifestAttributes = await client.GetAcrManifestAttributesAsync(ACRTestUtil.ProdRepository,
                    "sha256:eabe547f78d4c18c708dd97ec3166cf7464cc651f1cbb67e70d407405b7ad7b6");

                Assert.Null(manifestAttributes);
            }
        }

        [Fact]
        public async Task GetAcrManifestsMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrManifestsMR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var manifests = await client.GetAcrManifestsAsync(ACRTestUtil.ProdRepository);

                Assert.Equal(ExpectedAttributesOfProdRepository.ImageName, manifests.ImageName);
                Assert.Equal(ExpectedAttributesOfProdRepository.Registry, manifests.Registry);
                Assert.Equal(1, manifests.Manifests.Count);
                VerifyAcrManifestAttributesBase(ExpectedAttributesOfProdRepository.Manifest, manifests.Manifests[0]);
            }
        }

        [Fact]
        public async Task GetAcrManifestsCRThrowException()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrManifestsCRThrowException)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                await Assert.ThrowsAsync<AcrErrorsException>(() => client.GetAcrManifestsAsync(ACRTestUtil.ProdRepository));
            }
        }

        [Fact]
        public async Task GetManifestMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetManifestMR)))
            {
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var manifest = await client.GetManifestAsync(ACRTestUtil.TestRepository, tag);

                Assert.Equal(1, manifest.SchemaVersion);
                Assert.Equal(ACRTestUtil.TestRepository, manifest.Name);
                Assert.Equal(tag, manifest.Tag);
                Assert.Equal("amd64", manifest.Architecture);
                Assert.Equal(10, manifest.FsLayers.Count);
                Assert.Equal(10, manifest.ImageHistories.Count);
                Assert.Equal(1, manifest.Signatures.Count);
                var signature = manifest.Signatures[0];
                Assert.NotEqual(string.Empty, signature.ProtectedHeader);
                Assert.NotEqual(string.Empty, signature.Signature);
                Assert.Equal("P-256", signature.Header.Jwk.Crv);
                Assert.NotEqual(string.Empty, signature.Header.Jwk.Kid);
                Assert.Equal("EC", signature.Header.Jwk.Kty);
                Assert.NotEqual(string.Empty, signature.Header.Jwk.X);
                Assert.NotEqual(string.Empty, signature.Header.Jwk.Y);
            }
        }

        [Fact]
        public async Task GetManifestCR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetManifestCR)))
            {
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                var manifest = await client.GetManifestAsync(ACRTestUtil.ProdRepository, tag);

                Assert.Equal(1, manifest.SchemaVersion);
                Assert.Equal(ACRTestUtil.ProdRepository, manifest.Name);
                Assert.Equal(tag, manifest.Tag);
                Assert.Equal("amd64", manifest.Architecture);
                Assert.Equal(10, manifest.FsLayers.Count);
                Assert.Equal(10, manifest.ImageHistories.Count);
                Assert.Equal(1, manifest.Signatures.Count);
                var signature = manifest.Signatures[0];
                Assert.NotEqual(string.Empty, signature.ProtectedHeader);
                Assert.NotEqual(string.Empty, signature.Signature);
                Assert.Equal("P-256", signature.Header.Jwk.Crv);
                Assert.NotEqual(string.Empty, signature.Header.Jwk.Kid);
                Assert.Equal("EC", signature.Header.Jwk.Kty);
                Assert.NotEqual(string.Empty, signature.Header.Jwk.X);
                Assert.NotEqual(string.Empty, signature.Header.Jwk.Y);
            }
        }

        [Fact]
        public async Task UpdateAcrManifestAttributesMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(UpdateAcrManifestAttributesMR)))
            {
                var updateAttributes = new ChangeableAttributes() { DeleteEnabled = true, ListEnabled = true, ReadEnabled = true, WriteEnabled = false };
                var digest = "sha256:eabe547f78d4c18c708dd97ec3166cf7464cc651f1cbb67e70d407405b7ad7b6";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                await client.UpdateAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, digest, updateAttributes);
                var updatedManifest = await client.GetAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, digest);
                Assert.False(updatedManifest.Manifest.ChangeableAttributes.WriteEnabled);

                updateAttributes.WriteEnabled = true;
                await client.UpdateAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, digest, updateAttributes);
                updatedManifest = await client.GetAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, digest);
                Assert.Equal(ExpectedAttributesOfProdRepository.ImageName, updatedManifest.ImageName);
                Assert.Equal(ExpectedAttributesOfProdRepository.Registry, updatedManifest.Registry);
                VerifyAcrManifestAttributesBase(ExpectedAttributesOfProdRepository.Manifest, updatedManifest.Manifest);
            }
        }

        private void VerifyAcrManifestAttributesBase(AcrManifestAttributesBase expectedManifestBase, AcrManifestAttributesBase actualManifestBase)
        {
            Assert.Equal(expectedManifestBase.Architecture, actualManifestBase.Architecture);
            Assert.Equal(expectedManifestBase.CreatedTime, actualManifestBase.CreatedTime);
            Assert.Equal(expectedManifestBase.Digest, actualManifestBase.Digest);
            Assert.Equal(expectedManifestBase.LastUpdateTime, actualManifestBase.LastUpdateTime);
            Assert.Equal(expectedManifestBase.MediaType, actualManifestBase.MediaType);
            Assert.Equal(expectedManifestBase.Os, actualManifestBase.Os);
            Assert.Equal(expectedManifestBase.Tags.Count, actualManifestBase.Tags.Count);
            Assert.Equal(expectedManifestBase.Tags[0], actualManifestBase.Tags[0]);
            Assert.Equal(expectedManifestBase.ChangeableAttributes.DeleteEnabled, actualManifestBase.ChangeableAttributes.DeleteEnabled);
            Assert.Equal(expectedManifestBase.ChangeableAttributes.ListEnabled, actualManifestBase.ChangeableAttributes.ListEnabled);
            Assert.Equal(expectedManifestBase.ChangeableAttributes.ReadEnabled, actualManifestBase.ChangeableAttributes.ReadEnabled);
            Assert.Equal(expectedManifestBase.ChangeableAttributes.WriteEnabled, actualManifestBase.ChangeableAttributes.WriteEnabled);
        }
    }
}
