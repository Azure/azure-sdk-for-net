namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Azure.Management.ContainerRegistry;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class ScopeTests
    {
        [Fact]
        public async Task CreateAndGetManifest()
        {
            using (var context = MockContext.Start(GetType(), nameof(CreateAndGetManifest)))
            {
                var tag = "test-put";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);
                await client.Manifests.CreateAsync(ACRTestUtil.changeableRepository, tag, ExpectedV2ManifestProd);

                var newManifest = (V2Manifest)await client.Manifests.GetAsync(ACRTestUtil.changeableRepository, tag, ACRTestUtil.MediatypeV2Manifest);
                var tagAttributes = await client.Tag.GetAttributesAsync(ACRTestUtil.changeableRepository, tag);

                VerifyManifest(ExpectedV2ManifestProd, newManifest);
                await client.Manifests.DeleteAsync(ACRTestUtil.changeableRepository, tagAttributes.Attributes.Digest);
            }
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public async Task MoreScopeTests(string headerValue, string expectedScope)
        {
            using (var context = MockContext.Start(GetType(), nameof(MoreScopeTests)))
            {
                var _httpRequest = new HttpRequestMessage();
                _httpRequest.Headers.Add("Www-Authenticate", headerValue);

                var client = await ACRTestUtil.GetCredentialsAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);
                string actualScope = client.GetScopeFromHeaders(_httpRequest.Headers);
                Assert.Equal(expectedScope, actualScope);
            }
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "Bearer realm=\"https://myregistry.azurecr-test.io/oauth2/token\",service=\"myregistry.azurecr-test.io\",scope=\"foo:bar:baz,abc\",Basic xyz=123", "foo:bar:baz,abc"};
            yield return new object[] { "Bearer realm=\"https://myregistry.azurecr-test.io/oauth2/token\",service=\"myregistry.azurecr-test.io\",scope=\"foo:bar:baz,abc\", Basic xyz=123", "foo:bar:baz,abc"};
            yield return new object[] { "Bearer realm=\"https://myregistry.azurecr-test.io/oauth2/token\",service=\"myregistry.azurecr-test.io\",scope=\"foo:bar:baz,abc\"", "foo:bar:baz,abc" };
            yield return new object[] { "Bearer realm=\"https://myregistry.azurecr-test.io/oauth2/token\",service=\"myregistry.azurecr-test.io\",scope=\"foo:bar:baz\"", "foo:bar:baz" };
        }

        private static readonly V2Manifest ExpectedV2ManifestProd = new V2Manifest()
        {
            SchemaVersion = 2,
            MediaType = ACRTestUtil.MediatypeV2Manifest,
            Config = new Descriptor
            {
                MediaType = ACRTestUtil.MediatypeV1Manifest,
                Size = 5635,
                Digest = "sha256:16463e0c481e161aabb735437d30b3c9c7391c2747cc564bb927e843b73dcb39"
            },
            Layers = new List<Descriptor>
            {
                new Descriptor
                {
                    MediaType = "application/vnd.docker.image.rootfs.diff.tar.gzip",
                    Size = 2789742,
                    Digest = "sha256:0503825856099e6adb39c8297af09547f69684b7016b7f3680ed801aa310baaa"
                },
                new Descriptor
                {
                    MediaType = "application/vnd.docker.image.rootfs.diff.tar.gzip",
                    Size = 3174556,
                    Digest = "sha256:7bf5420b55e6bbefb64ddb4fbb98ef094866f3a3facda638a155715ab6002d9b"
                },
                new Descriptor
                {
                    MediaType = "application/vnd.docker.image.rootfs.diff.tar.gzip",
                    Size = 344,
                    Digest = "sha256:1beb2aaf8cf93eacf658fa7f7f10f89ccec1838d1ac643a273345d4d0bc813a8"
                }
            }
        };

        private void VerifyManifest(Manifest baseManifest, Manifest actualManifest)
        {
            Assert.Equal(baseManifest.GetType(), actualManifest.GetType());
            Assert.Equal(baseManifest.SchemaVersion, actualManifest.SchemaVersion);

            if (baseManifest is V2Manifest)
            {
                var baseManifestV2 = (V2Manifest)baseManifest;
                var actualManifestV2 = (V2Manifest)baseManifest;
                Assert.Equal(baseManifestV2.Layers.Count, actualManifestV2.Layers.Count);
                for (int i = 0; i < baseManifestV2.Layers.Count; i++)
                {
                    Assert.Equal(baseManifestV2.Layers[i].Digest, actualManifestV2.Layers[i].Digest);
                    Assert.Equal(baseManifestV2.Layers[i].MediaType, actualManifestV2.Layers[i].MediaType);
                    Assert.Equal(baseManifestV2.Layers[i].Size, actualManifestV2.Layers[i].Size);
                }
                Assert.Equal(baseManifestV2.Config.Digest, actualManifestV2.Config.Digest);
                Assert.Equal(baseManifestV2.Config.MediaType, actualManifestV2.Config.MediaType);
                Assert.Equal(baseManifestV2.Config.Size, actualManifestV2.Config.Size);
            }
        }

    }

}
