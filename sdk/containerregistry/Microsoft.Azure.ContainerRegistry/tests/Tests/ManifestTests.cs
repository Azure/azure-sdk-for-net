// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class ManifestTests
    {
        private static readonly AcrManifestAttributes ExpectedAttributesOfProdRepository = new AcrManifestAttributes()
        {
            ImageName = ACRTestUtil.ProdRepository,
            Registry = ACRTestUtil.ManagedTestRegistryFullName,
            ManifestAttributes = new AcrManifestAttributesBase()
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

        private static readonly Manifest ExpectedV2ManifestProd = new Manifest()
        {
            Architecture = null,
            Config = new V2Descriptor() {
                Digest = "sha256:16463e0c481e161aabb735437d30b3c9c7391c2747cc564bb927e843b73dcb39",
                MediaType = "application/vnd.docker.container.image.v1+json"
            },
            FsLayers = null,
            History = null,
            Layers = new V2Descriptor[] {
                new V2Descriptor() {
                    Digest = "sha256:0503825856099e6adb39c8297af09547f69684b7016b7f3680ed801aa310baaa",
                    MediaType = "application/vnd.docker.image.rootfs.diff.tar.gzip"
                },
                new V2Descriptor() {
                    Digest = "sha256:7bf5420b55e6bbefb64ddb4fbb98ef094866f3a3facda638a155715ab6002d9b",
                    MediaType = "application/vnd.docker.image.rootfs.diff.tar.gzip"
                },
                new V2Descriptor() {
                    Digest = "sha256:1beb2aaf8cf93eacf658fa7f7f10f89ccec1838d1ac643a273345d4d0bc813a8",
                    MediaType = "application/vnd.docker.image.rootfs.diff.tar.gzip"
                }
            },
            MediaType = "application/vnd.docker.distribution.manifest.v2+json",
            SchemaVersion = 2,
            Name = null,
            Tag = null,
            Signatures = null
        };

        private static readonly Manifest ExpectedV1ManifestProd = new Manifest()
        {
            Config = null,
            Architecture = "amd64",
            FsLayers = new FsLayer[] {
                new FsLayer () {
                    BlobSum = "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer () {
                    BlobSum = "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer () {
                    BlobSum = "sha256:1beb2aaf8cf93eacf658fa7f7f10f89ccec1838d1ac643a273345d4d0bc813a8"
                },
                new FsLayer () {
                    BlobSum = "sha256:7bf5420b55e6bbefb64ddb4fbb98ef094866f3a3facda638a155715ab6002d9b"
                },
                new FsLayer () {
                    BlobSum =  "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer () {
                    BlobSum =  "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer () {
                    BlobSum =  "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer () {
                    BlobSum =  "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer () {
                    BlobSum =  "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer () {
                    BlobSum = "sha256:0503825856099e6adb39c8297af09547f69684b7016b7f3680ed801aa310baaa"
                }
            },
            MediaType = "application/vnd.docker.distribution.manifest.v2+json",
            SchemaVersion = 2,
            Name = null,
            Tag = null,
            Signatures = null
        };


        [Fact]        
        public async Task GetAcrManifestAttributes()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrManifestAttributes)))
            {                
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var repositoryAttributes = await client.GetAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, 
                    "sha256:eabe547f78d4c18c708dd97ec3166cf7464cc651f1cbb67e70d407405b7ad7b6");

                Assert.Equal(ExpectedAttributesOfProdRepository.ImageName, repositoryAttributes.ImageName);
                Assert.Equal(ExpectedAttributesOfProdRepository.Registry, repositoryAttributes.Registry);
                VerifyAcrManifestAttributesBase(ExpectedAttributesOfProdRepository.ManifestAttributes, repositoryAttributes.ManifestAttributes);
            }            
        }
        
        [Fact]
        public async Task GetAcrManifests()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrManifests)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var manifests = await client.GetAcrManifestsAsync(ACRTestUtil.ProdRepository);

                Assert.Equal(ExpectedAttributesOfProdRepository.ImageName, manifests.ImageName);
                Assert.Equal(ExpectedAttributesOfProdRepository.Registry, manifests.Registry);
                Assert.Equal(1, manifests.ManifestsAttributes.Count);
                VerifyAcrManifestAttributesBase(ExpectedAttributesOfProdRepository.ManifestAttributes, manifests.ManifestsAttributes[0]);
            }
        }

        [Fact]
        public async Task GetManifest()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetManifest)))
            {
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var manifest = await client.GetManifestAsync(ACRTestUtil.TestRepository, tag);

                Assert.Equal(1, manifest.SchemaVersion);
                Assert.Equal(ACRTestUtil.TestRepository, manifest.Name);
                Assert.Equal(tag, manifest.Tag);
                Assert.Equal("amd64", manifest.Architecture);
                Assert.Equal(10, manifest.FsLayers.Count);
                Assert.Equal(1, manifest.Signatures.Count);
                var signature = manifest.Signatures[0];
                Assert.NotEqual(string.Empty, signature.Signature);
                Assert.Equal("P-256", signature.Header.Jwk.Crv);
                Assert.NotEqual(string.Empty, signature.Header.Jwk.Kid);
                Assert.Equal("EC", signature.Header.Jwk.Kty);
                Assert.NotEqual(string.Empty, signature.Header.Jwk.X);
                Assert.NotEqual(string.Empty, signature.Header.Jwk.Y);
            }
        }

        [Fact]
        public async Task UpdateAcrManifestAttributes()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(UpdateAcrManifestAttributes)))
            {
                var updateAttributes = new ChangeableAttributes() { DeleteEnabled = true, ListEnabled = true, ReadEnabled = true, WriteEnabled = false };
                var digest = "sha256:eabe547f78d4c18c708dd97ec3166cf7464cc651f1cbb67e70d407405b7ad7b6";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                await client.UpdateAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, digest, updateAttributes);
                var updatedManifest = await client.GetAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, digest);
                Assert.False(updatedManifest.ManifestAttributes.ChangeableAttributes.WriteEnabled);

                updateAttributes.WriteEnabled = true;
                await client.UpdateAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, digest, updateAttributes);
                updatedManifest = await client.GetAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, digest);
                Assert.Equal(ExpectedAttributesOfProdRepository.ImageName, updatedManifest.ImageName);
                Assert.Equal(ExpectedAttributesOfProdRepository.Registry, updatedManifest.Registry);
                VerifyAcrManifestAttributesBase(ExpectedAttributesOfProdRepository.ManifestAttributes, updatedManifest.ManifestAttributes);
            }
        }


        [Fact]
        public async Task CreateAcrManifest()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(CreateAcrManifest)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                await client.CreateManifestAsync(ACRTestUtil.ProdRepository, "brandnew", manifest);
                var newManifest = await client.GetAcrManifestAttributesAsync(ACRTestUtil.ProdRepository, "brandnew");

                Assert.Equal(ExpectedAttributesOfProdRepository.Registry, newManifest.Registry);
                Assert.Equal(ExpectedAttributesOfProdRepository.ImageName, newManifest.ImageName);
                VerifyAcrManifestAttributesBase(ExpectedAttributesOfProdRepository.ManifestAttributes, newManifest.ManifestAttributes);

            }
        }

        [Fact]
        public async Task DeleteAcrManifest()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(DeleteAcrManifest)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                await client.DeleteManifestAsync(ACRTestUtil.ProdRepository, "deleteable");
                await Assert.ThrowsAsync<AcrErrorsException>(() => client.GetManifestAsync(ACRTestUtil.TestRepository, "deleteable"));
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
