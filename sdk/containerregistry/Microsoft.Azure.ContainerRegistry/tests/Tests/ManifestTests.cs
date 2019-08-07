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
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Xunit;

    public class ManifestTests
    {
        #region Test Values
        private static readonly AcrManifestAttributes ExpectedAttributesOfProdRepository = new AcrManifestAttributes()
        {
            Registry = "azuresdkunittest.azurecr.io",
            ImageName = "prod/bash",
            ManifestAttributes = new AcrManifestAttributesBase
            {
                Digest = "sha256:dbefd3c583a226ddcef02536cd761d2d86dc7e6f21c53f83957736d6246e9ed8",
                ImageSize = 5964642,
                CreatedTime = "8/1/2019 10:49:11 PM",
                LastUpdateTime = "8/1/2019 10:49:11 PM",
                Architecture = "amd64",
                Os = "linux",
                MediaType = "application/vnd.docker.distribution.manifest.v2+json",
                ConfigMediaType = "application/vnd.docker.container.image.v1+json",
                Tags = new List<string> {
                    "latest"
                },
                ChangeableAttributes = new ChangeableAttributes
                {
                    DeleteEnabled = true,
                    WriteEnabled = true,
                    ListEnabled = true,
                    ReadEnabled = true
                }
            }
        };

        private static readonly Manifest ExpectedV2ManifestProd = new Manifest()
        {
            SchemaVersion = 2,
            MediaType = "application/vnd.docker.distribution.manifest.v2+json",
            Config = new V2Descriptor
            {
                MediaType = "application/vnd.docker.container.image.v1+json",
                Size = 5635,
                Digest = "sha256:16463e0c481e161aabb735437d30b3c9c7391c2747cc564bb927e843b73dcb39"
            },
            Layers = new List<V2Descriptor>
            {
                new V2Descriptor
                {
                    MediaType = "application/vnd.docker.image.rootfs.diff.tar.gzip",
                    Size = 2789742,
                    Digest = "sha256:0503825856099e6adb39c8297af09547f69684b7016b7f3680ed801aa310baaa"
                },
                new V2Descriptor
                {
                    MediaType = "application/vnd.docker.image.rootfs.diff.tar.gzip",
                    Size = 3174556,
                    Digest = "sha256:7bf5420b55e6bbefb64ddb4fbb98ef094866f3a3facda638a155715ab6002d9b"
                },
                new V2Descriptor
                {
                    MediaType = "application/vnd.docker.image.rootfs.diff.tar.gzip",
                    Size = 344,
                    Digest = "sha256:1beb2aaf8cf93eacf658fa7f7f10f89ccec1838d1ac643a273345d4d0bc813a8"
                }
            },
            Architecture = null,
            Name = null,
            Tag = null,
            FsLayers = null,
            History = null,
            Signatures = null
        }; 

        private static readonly Manifest ExpectedV1ManifestProd = new Manifest() {
            SchemaVersion = 1,
            MediaType = null,
            Config = null,
            Layers = null,
            Architecture = "amd64",
            Name = "test/bash",
            Tag = "latest",
            FsLayers = new List<FsLayer>
            {
                new FsLayer
                {
                    BlobSum = "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer
                {
                    BlobSum = "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer
                {
                    BlobSum = "sha256:1beb2aaf8cf93eacf658fa7f7f10f89ccec1838d1ac643a273345d4d0bc813a8"
                },
                new FsLayer
                {
                    BlobSum = "sha256:7bf5420b55e6bbefb64ddb4fbb98ef094866f3a3facda638a155715ab6002d9b"
                },
                new FsLayer
                {
                    BlobSum = "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer
                {
                    BlobSum = "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer
                {
                    BlobSum = "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer
                {
                    BlobSum = "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer
                {
                    BlobSum = "sha256:a3ed95caeb02ffe68cdd9fd84406680ae93d633cb16422d00e8a7c22955b46d4"
                },
                new FsLayer
                {
                    BlobSum = "sha256:0503825856099e6adb39c8297af09547f69684b7016b7f3680ed801aa310baaa"
                }
            },
            History = new List<History>
            {
                new History
                {
                    V1Compatibility = "{\"architecture\":\"amd64\",\"config\":{\"Hostname\":\"\",\"Domainname\":\"\",\"User\":\"\",\"AttachStdin\":false,\"AttachStdout\":false,\"AttachStderr\":false,\"Tty\":false,\"OpenStdin\":false,\"StdinOnce\":false,\"Env\":[\"PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin\",\"_BASH_GPG_KEY=7C0135FB088AAF6C66C650B9BB5869F064EA74AB\",\"_BASH_VERSION=5.0\",\"_BASH_PATCH_LEVEL=0\",\"_BASH_LATEST_PATCH=7\"],\"Cmd\":[\"bash\"],\"ArgsEscaped\":true,\"Image\":\"sha256:38ad2fbc9f9c0a87dfe0a2b19bdca94be45f4663f73fd09fefee492afd2c0144\",\"Volumes\":null,\"WorkingDir\":\"\",\"Entrypoint\":[\"docker-entrypoint.sh\"],\"OnBuild\":null,\"Labels\":null},\"container\":\"4b0546fa49df5dcaed5b663717f442cef71a1b95c0ffb42c8c5ce7231b90c026\",\"container_config\":{\"Hostname\":\"4b0546fa49df\",\"Domainname\":\"\",\"User\":\"\",\"AttachStdin\":false,\"AttachStdout\":false,\"AttachStderr\":false,\"Tty\":false,\"OpenStdin\":false,\"StdinOnce\":false,\"Env\":[\"PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin\",\"_BASH_GPG_KEY=7C0135FB088AAF6C66C650B9BB5869F064EA74AB\",\"_BASH_VERSION=5.0\",\"_BASH_PATCH_LEVEL=0\",\"_BASH_LATEST_PATCH=7\"],\"Cmd\":[\"/bin/sh\",\"-c\",\"#(nop) \",\"CMD [\\\"bash\\\"]\"],\"ArgsEscaped\":true,\"Image\":\"sha256:38ad2fbc9f9c0a87dfe0a2b19bdca94be45f4663f73fd09fefee492afd2c0144\",\"Volumes\":null,\"WorkingDir\":\"\",\"Entrypoint\":[\"docker-entrypoint.sh\"],\"OnBuild\":null,\"Labels\":{}},\"created\":\"2019-07-13T01:16:06.527515902Z\",\"docker_version\":\"18.06.1-ce\",\"id\":\"cdd327e549693fe222fe507b20c7ed5c3a5e4993e0130643e9e58a9412696c4d\",\"os\":\"linux\",\"parent\":\"86618c524a0b974761e4524e869760a53053bfedd45159a51ec197ac61ddb4c4\",\"throwaway\":true}"
                },
                new History
                {
                    V1Compatibility = "{\"id\":\"86618c524a0b974761e4524e869760a53053bfedd45159a51ec197ac61ddb4c4\",\"parent\":\"f86921d5a49faba5ebe9ec176bab3f7c26faf027ea2a890ce4a5293d7659b3c8\",\"created\":\"2019-07-13T01:16:06.319375884Z\",\"container_config\":{\"Cmd\":[\"/bin/sh -c #(nop)  ENTRYPOINT [\\\"docker-entrypoint.sh\\\"]\"]},\"throwaway\":true}"
                },
                new History
                {
                    V1Compatibility = "{\"id\":\"f86921d5a49faba5ebe9ec176bab3f7c26faf027ea2a890ce4a5293d7659b3c8\",\"parent\":\"fdfa36816bb7dce8b1a03d236a964554ac997f8cc5fc3951c3ce80b9ddc94b4d\",\"created\":\"2019-07-13T01:16:06.164128412Z\",\"container_config\":{\"Cmd\":[\"/bin/sh -c #(nop) COPY file:651b3bebeba8be9162c56b3eb561199905235f3e1c7811232b6c9f48ac333651 in /usr/local/bin/ \"]}}"
                },
                new History
                {
                    V1Compatibility = "{\"id\":\"fdfa36816bb7dce8b1a03d236a964554ac997f8cc5fc3951c3ce80b9ddc94b4d\",\"parent\":\"a868f8920a8ecf03f27df4ec46822d4fcc725647672f4a0f05888fadb7979332\",\"created\":\"2019-07-13T01:16:05.928429262Z\",\"container_config\":{\"Cmd\":[\"/bin/sh -c set -eux; \\t\\tapk add --no-cache --virtual .build-deps \\t\\tbison \\t\\tcoreutils \\t\\tdpkg-dev dpkg \\t\\tgcc \\t\\tgnupg \\t\\tlibc-dev \\t\\tmake \\t\\tncurses-dev \\t\\tpatch \\t\\ttar \\t; \\t\\tversion=\\\"$_BASH_VERSION\\\"; \\tif [ \\\"$_BASH_PATCH_LEVEL\\\" -gt 0 ]; then \\t\\tversion=\\\"$version.$_BASH_PATCH_LEVEL\\\"; \\tfi; \\twget -O bash.tar.gz \\\"https://ftp.gnu.org/gnu/bash/bash-$version.tar.gz\\\"; \\twget -O bash.tar.gz.sig \\\"https://ftp.gnu.org/gnu/bash/bash-$version.tar.gz.sig\\\"; \\t\\tif [ \\\"$_BASH_LATEST_PATCH\\\" -gt \\\"$_BASH_PATCH_LEVEL\\\" ]; then \\t\\tmkdir -p bash-patches; \\t\\tfirst=\\\"$(printf '%03d' \\\"$(( _BASH_PATCH_LEVEL + 1 ))\\\")\\\"; \\t\\tlast=\\\"$(printf '%03d' \\\"$_BASH_LATEST_PATCH\\\")\\\"; \\t\\tfor patch in $(seq -w \\\"$first\\\" \\\"$last\\\"); do \\t\\t\\turl=\\\"https://ftp.gnu.org/gnu/bash/bash-$_BASH_VERSION-patches/bash${_BASH_VERSION//./}-$patch\\\"; \\t\\t\\twget -O \\\"bash-patches/$patch\\\" \\\"$url\\\"; \\t\\t\\twget -O \\\"bash-patches/$patch.sig\\\" \\\"$url.sig\\\"; \\t\\tdone; \\tfi; \\t\\texport GNUPGHOME=\\\"$(mktemp -d)\\\"; \\tgpg --batch --keyserver ha.pool.sks-keyservers.net --recv-keys \\\"$_BASH_GPG_KEY\\\"; \\tgpg --batch --verify bash.tar.gz.sig bash.tar.gz; \\tgpgconf --kill all; \\trm bash.tar.gz.sig; \\tif [ -d bash-patches ]; then \\t\\tfor sig in bash-patches/*.sig; do \\t\\t\\tp=\\\"${sig%.sig}\\\"; \\t\\t\\tgpg --batch --verify \\\"$sig\\\" \\\"$p\\\"; \\t\\t\\trm \\\"$sig\\\"; \\t\\tdone; \\tfi; \\trm -rf \\\"$GNUPGHOME\\\"; \\t\\tmkdir -p /usr/src/bash; \\ttar \\t\\t--extract \\t\\t--file=bash.tar.gz \\t\\t--strip-components=1 \\t\\t--directory=/usr/src/bash \\t; \\trm bash.tar.gz; \\t\\tif [ -d bash-patches ]; then \\t\\tfor p in bash-patches/*; do \\t\\t\\tpatch \\t\\t\\t\\t--directory=/usr/src/bash \\t\\t\\t\\t--input=\\\"$(readlink -f \\\"$p\\\")\\\" \\t\\t\\t\\t--strip=0 \\t\\t\\t; \\t\\t\\trm \\\"$p\\\"; \\t\\tdone; \\t\\trmdir bash-patches; \\tfi; \\t\\tcd /usr/src/bash; \\tgnuArch=\\\"$(dpkg-architecture --query DEB_BUILD_GNU_TYPE)\\\"; \\t./configure \\t\\t--build=\\\"$gnuArch\\\" \\t\\t--enable-readline \\t\\t--with-curses \\t\\t--without-bash-malloc \\t|| { \\t\\tcat \\u003e\\u00262 config.log; \\t\\tfalse; \\t}; \\tmake -j \\\"$(nproc)\\\"; \\tmake install; \\tcd /; \\trm -r /usr/src/bash; \\t\\trm -r \\t\\t/usr/local/share/doc/bash/*.html \\t\\t/usr/local/share/info \\t\\t/usr/local/share/locale \\t\\t/usr/local/share/man \\t; \\t\\trunDeps=\\\"$( \\t\\tscanelf --needed --nobanner --format '%n#p' --recursive /usr/local \\t\\t\\t| tr ',' '\\\\n' \\t\\t\\t| sort -u \\t\\t\\t| awk 'system(\\\"[ -e /usr/local/lib/\\\" $1 \\\" ]\\\") == 0 { next } { print \\\"so:\\\" $1 }' \\t)\\\"; \\tapk add --no-cache --virtual .bash-rundeps $runDeps; \\tapk del .build-deps; \\t\\t[ \\\"$(which bash)\\\" = '/usr/local/bin/bash' ]; \\tbash --version; \\t[ \\\"$(bash -c 'echo \\\"${BASH_VERSION%%[^0-9.]*}\\\"')\\\" = \\\"${_BASH_VERSION%%-*}.$_BASH_LATEST_PATCH\\\" ];\"]}}"
                },
                new History
                {
                    V1Compatibility = "{\"id\":\"a868f8920a8ecf03f27df4ec46822d4fcc725647672f4a0f05888fadb7979332\",\"parent\":\"52ea5f441a09314108d53a1fffdbd2432f7a6708b43fea16f1a6cc4371593937\",\"created\":\"2019-07-13T01:15:14.099300075Z\",\"container_config\":{\"Cmd\":[\"/bin/sh -c #(nop)  ENV _BASH_LATEST_PATCH=7\"]},\"throwaway\":true}"
                },
                new History
                {
                    V1Compatibility = "{\"id\":\"52ea5f441a09314108d53a1fffdbd2432f7a6708b43fea16f1a6cc4371593937\",\"parent\":\"b6ebed9f2716cd5a747668c66288c5665403c9e51e9f8d51180bc5c433389052\",\"created\":\"2019-07-13T01:15:13.940455419Z\",\"container_config\":{\"Cmd\":[\"/bin/sh -c #(nop)  ENV _BASH_PATCH_LEVEL=0\"]},\"throwaway\":true}"
                },
                new History
                {
                    V1Compatibility = "{\"id\":\"b6ebed9f2716cd5a747668c66288c5665403c9e51e9f8d51180bc5c433389052\",\"parent\":\"e49db6057936a3300c3e470ebac56e96d2da218d53ed5487459d501c88f4cfaa\",\"created\":\"2019-07-13T01:15:13.745652098Z\",\"container_config\":{\"Cmd\":[\"/bin/sh -c #(nop)  ENV _BASH_VERSION=5.0\"]},\"throwaway\":true}"
                },
                new History
                {
                    V1Compatibility = "{\"id\":\"e49db6057936a3300c3e470ebac56e96d2da218d53ed5487459d501c88f4cfaa\",\"parent\":\"d097d7d1c0e7b077bbfcea46f6da56fa7fba28d72a1479ac785a32eb1e36c333\",\"created\":\"2019-07-13T01:15:13.567669812Z\",\"container_config\":{\"Cmd\":[\"/bin/sh -c #(nop)  ENV _BASH_GPG_KEY=7C0135FB088AAF6C66C650B9BB5869F064EA74AB\"]},\"throwaway\":true}"
                },
                new History
                {
                    V1Compatibility = "{\"id\":\"d097d7d1c0e7b077bbfcea46f6da56fa7fba28d72a1479ac785a32eb1e36c333\",\"parent\":\"97bd3cc8bea9669bf96dd307e91be787820a0de9525e9c16aef7286489969f90\",\"created\":\"2019-07-11T22:20:52.375286404Z\",\"container_config\":{\"Cmd\":[\"/bin/sh -c #(nop)  CMD [\\\"/bin/sh\\\"]\"]},\"throwaway\":true}"
                },
                new History
                {
                    V1Compatibility = "{\"id\":\"97bd3cc8bea9669bf96dd307e91be787820a0de9525e9c16aef7286489969f90\",\"created\":\"2019-07-11T22:20:52.139709355Z\",\"container_config\":{\"Cmd\":[\"/bin/sh -c #(nop) ADD file:0eb5ea35741d23fe39cbac245b3a5d84856ed6384f4ff07d496369ee6d960bad in / \"]}}"
                }
            },
            Signatures = new List<ImageSignature>
            {
                new ImageSignature
                {
                    Header = new JWK
                    {
                        Jwk = new JWKHeader
                        {
                            Crv = "P-256",
                            Kid = "HJSI:F55C:W355:JBDR:IAK6:BKT3:335P:YXV4:DIQZ:4QML:QBL6:J774",
                            Kty = "EC",
                            X = "wc8C3Ty4G5b2cmJNOeWwFkk1VFZX2BqOzEA4QwCWdE8",
                            Y = "-ZBu1SPnQ_em5KKOj5MkVVHIuCgsM5gxPx3vbQ9rnG8"
                        },
                        Alg = "ES256"
                    },
                    Signature = "MYCa2ke2yHiQR2NCFAutMDHVpP2Pi7oWy0oSLk7T0NThYt8qHz0kQqoqL6H0A2xUtRNdyOHK4l622c7JHN4SSg",
                    ProtectedProperty = "eyJmb3JtYXRMZW5ndGgiOjkxOTMsImZvcm1hdFRhaWwiOiJDbjAiLCJ0aW1lIjoiMjAxOS0wOC0wNlQyMToyMToxOVoifQ"
                }
            }
        };

        private static readonly AcrManifestAttributes ExpectedAttributesChangeableRepository = new AcrManifestAttributes()
        {
            Registry = "azuresdkunittestupdateable.azurecr.io",
            ImageName = "doundo/bash",
            ManifestAttributes = new AcrManifestAttributesBase
            {
                Digest = "sha256:dbefd3c583a226ddcef02536cd761d2d86dc7e6f21c53f83957736d6246e9ed8",
                ImageSize = 5964642,
                CreatedTime = "8/6/2019 11:27:35 PM",
                LastUpdateTime = "8/6/2019 11:27:35 PM",
                Architecture = "amd64",
                Os = "linux",
                MediaType = "application/vnd.docker.distribution.manifest.v2+json",
                ConfigMediaType = "application/vnd.docker.container.image.v1+json",
                Tags = new List<string>
                {
                    "latest"
                },
                ChangeableAttributes = new ChangeableAttributes
                {
                    DeleteEnabled = true,
                    WriteEnabled = true,
                    ListEnabled = true,
                    ReadEnabled = true
                }
            }
        };
        #endregion

        [Fact]        
        public async Task GetAcrManifestAttributes()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrManifestAttributes)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var repositoryAttributes = await client.GetAcrManifestAttributesAsync(ACRTestUtil.ProdRepository,
                    "sha256:dbefd3c583a226ddcef02536cd761d2d86dc7e6f21c53f83957736d6246e9ed8");

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
                Assert.Equal(2, manifests.ManifestsAttributes.Count);
                VerifyAcrManifestAttributesBase(ExpectedAttributesOfProdRepository.ManifestAttributes, manifests.ManifestsAttributes[1]);
            }
        }

        [Fact]
        public async Task GetV1Manifest()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetV1Manifest)))
            {
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var manifest = await client.GetManifestAsync(ACRTestUtil.TestRepository, tag);
                verifyManifest(ExpectedV1ManifestProd, manifest);
            }
        }

        [Fact]
        public async Task GetV2Manifest()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetV2Manifest)))
            {
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var manifest = await client.GetManifestAsync(ACRTestUtil.TestRepository, tag, "application/vnd.docker.distribution.manifest.v2+json");
                verifyManifest(ExpectedV2ManifestProd, manifest);
            }
        }

        [Fact]
        public async Task UpdateAcrManifestAttributes()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(UpdateAcrManifestAttributes)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);

                var updateAttributes = new ChangeableAttributes() { DeleteEnabled = true, ListEnabled = true, ReadEnabled = true, WriteEnabled = false };
                var digest = "sha256:dbefd3c583a226ddcef02536cd761d2d86dc7e6f21c53f83957736d6246e9ed8";

                //Update attributes
                await client.UpdateAcrManifestAttributesAsync(ACRTestUtil.changeableRepository, digest, updateAttributes);
                var updatedManifest = await client.GetAcrManifestAttributesAsync(ACRTestUtil.changeableRepository, digest);

                //Check for success
                Assert.False(updatedManifest.ManifestAttributes.ChangeableAttributes.WriteEnabled);

                //Return attibutes to original
                updateAttributes.WriteEnabled = true;
                await client.UpdateAcrManifestAttributesAsync(ACRTestUtil.changeableRepository, digest, updateAttributes);
                updatedManifest = await client.GetAcrManifestAttributesAsync(ACRTestUtil.changeableRepository, digest);
                Assert.Equal(ExpectedAttributesChangeableRepository.ImageName, updatedManifest.ImageName);
                Assert.Equal(ExpectedAttributesChangeableRepository.Registry, updatedManifest.Registry);
                VerifyAcrManifestAttributesBase(ExpectedAttributesChangeableRepository.ManifestAttributes, updatedManifest.ManifestAttributes);
            }
        }

        [Fact]
        public async Task CreateAndDeletecrManifest()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(CreateAndDeletecrManifest)))
            {
                    var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);
                    await client.CreateManifestAsync(ACRTestUtil.changeableRepository, "temporary", ExpectedV2ManifestProd);
                    var newManifest = await client.GetManifestAsync(ACRTestUtil.changeableRepository, "temporary", "application/vnd.docker.distribution.manifest.v2+json");
                    var tag = await client.GetAcrTagAttributesAsync(ACRTestUtil.changeableRepository, "temporary");

                    verifyManifest(ExpectedV2ManifestProd, newManifest);
                    await client.DeleteManifestAsync(ACRTestUtil.changeableRepository, tag.TagAttributes.Digest);
            }
        }

        #region Validation Helpers
        private void VerifyAcrManifestAttributesBase(AcrManifestAttributesBase expectedManifestBase, AcrManifestAttributesBase actualManifestBase)
        {
            Assert.Equal(expectedManifestBase.Architecture, actualManifestBase.Architecture);
            Assert.Equal(expectedManifestBase.Digest, actualManifestBase.Digest);
            Assert.Equal(expectedManifestBase.MediaType, actualManifestBase.MediaType);
            Assert.Equal(expectedManifestBase.Os, actualManifestBase.Os);
            Assert.Equal(expectedManifestBase.Tags.Count, actualManifestBase.Tags.Count);
            Assert.Equal(expectedManifestBase.Tags[0], actualManifestBase.Tags[0]);
            Assert.Equal(expectedManifestBase.ChangeableAttributes.DeleteEnabled, actualManifestBase.ChangeableAttributes.DeleteEnabled);
            Assert.Equal(expectedManifestBase.ChangeableAttributes.ListEnabled, actualManifestBase.ChangeableAttributes.ListEnabled);
            Assert.Equal(expectedManifestBase.ChangeableAttributes.ReadEnabled, actualManifestBase.ChangeableAttributes.ReadEnabled);
            Assert.Equal(expectedManifestBase.ChangeableAttributes.WriteEnabled, actualManifestBase.ChangeableAttributes.WriteEnabled);
        }


        private void verifyManifest(Manifest baseManifest, Manifest actualManifest)
        {
            Assert.Equal(baseManifest.Architecture, actualManifest.Architecture);
            Assert.Equal(baseManifest.MediaType, actualManifest.MediaType);
            Assert.Equal(baseManifest.Name, actualManifest.Name);
            Assert.Equal(baseManifest.SchemaVersion, actualManifest.SchemaVersion);
            Assert.Equal(baseManifest.Tag, actualManifest.Tag);

            //Nested Properties
            if (baseManifest.Config != null && actualManifest.Config != null) {
                Assert.Equal(baseManifest.Config.Digest, actualManifest.Config.Digest);
                Assert.Equal(baseManifest.Config.MediaType, actualManifest.Config.MediaType);
                Assert.Equal(baseManifest.Config.Size, actualManifest.Config.Size);
            }

            if (baseManifest.FsLayers != null && actualManifest.FsLayers != null)
            {
                Assert.Equal(baseManifest.FsLayers.Count, actualManifest.FsLayers.Count);

                for (int i = 0; i < baseManifest.FsLayers.Count; i++) {
                    Assert.Equal(baseManifest.FsLayers[i].BlobSum, actualManifest.FsLayers[i].BlobSum);
                }
            }

            if (baseManifest.Layers != null && actualManifest.Layers != null)
            {
                Assert.Equal(baseManifest.Layers.Count, actualManifest.Layers.Count);
                for (int i = 0; i < baseManifest.Layers.Count; i++)
                {
                    Assert.Equal(baseManifest.Layers[i].Digest, actualManifest.Layers[i].Digest);
                    Assert.Equal(baseManifest.Layers[i].MediaType, actualManifest.Layers[i].MediaType);
                    Assert.Equal(baseManifest.Layers[i].Size, actualManifest.Layers[i].Size);
                }
            }

            if (baseManifest.History != null && actualManifest.History != null)
            {
                Assert.Equal(baseManifest.History.Count, actualManifest.History.Count);
                for (int i = 0; i < baseManifest.History.Count; i++)
                {
                    Assert.Equal(baseManifest.History[i].V1Compatibility, actualManifest.History[i].V1Compatibility);
                }
            }
        }
        #endregion
    }

}
