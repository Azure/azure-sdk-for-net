namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using static Microsoft.Azure.ContainerRegistry.ContainerRegistryCredentials;

    public class BlobTests
    {
        string ProdConfigBlob = "{\"architecture\":\"amd64\",\"config\":{\"Hostname\":\"\",\"Domainname\":\"\",\"User\":\"\",\"AttachStdin\":false,\"AttachStdout\":false,\"AttachStderr\":false,\"Tty\":false,\"OpenStdin\":false,\"StdinOnce\":false,\"Env\":[\"PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin\",\"_BASH_GPG_KEY=7C0135FB088AAF6C66C650B9BB5869F064EA74AB\",\"_BASH_VERSION=5.0\",\"_BASH_PATCH_LEVEL=0\",\"_BASH_LATEST_PATCH=7\"],\"Cmd\":[\"bash\"],\"ArgsEscaped\":true,\"Image\":\"sha256:38ad2fbc9f9c0a87dfe0a2b19bdca94be45f4663f73fd09fefee492afd2c0144\",\"Volumes\":null,\"WorkingDir\":\"\",\"Entrypoint\":[\"docker-entrypoint.sh\"],\"OnBuild\":null,\"Labels\":null},\"container\":\"4b0546fa49df5dcaed5b663717f442cef71a1b95c0ffb42c8c5ce7231b90c026\",\"container_config\":{\"Hostname\":\"4b0546fa49df\",\"Domainname\":\"\",\"User\":\"\",\"AttachStdin\":false,\"AttachStdout\":false,\"AttachStderr\":false,\"Tty\":false,\"OpenStdin\":false,\"StdinOnce\":false,\"Env\":[\"PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin\",\"_BASH_GPG_KEY=7C0135FB088AAF6C66C650B9BB5869F064EA74AB\",\"_BASH_VERSION=5.0\",\"_BASH_PATCH_LEVEL=0\",\"_BASH_LATEST_PATCH=7\"],\"Cmd\":[\"/bin/sh\",\"-c\",\"#(nop) \",\"CMD [\\\"bash\\\"]\"],\"ArgsEscaped\":true,\"Image\":\"sha256:38ad2fbc9f9c0a87dfe0a2b19bdca94be45f4663f73fd09fefee492afd2c0144\",\"Volumes\":null,\"WorkingDir\":\"\",\"Entrypoint\":[\"docker-entrypoint.sh\"],\"OnBuild\":null,\"Labels\":{}},\"created\":\"2019-07-13T01:16:06.527515902Z\",\"docker_version\":\"18.06.1-ce\",\"history\":[{\"created\":\"2019-07-11T22:20:52.139709355Z\",\"created_by\":\"/bin/sh -c #(nop) ADD file:0eb5ea35741d23fe39cbac245b3a5d84856ed6384f4ff07d496369ee6d960bad in / \"},{\"created\":\"2019-07-11T22:20:52.375286404Z\",\"created_by\":\"/bin/sh -c #(nop)  CMD [\\\"/bin/sh\\\"]\",\"empty_layer\":true},{\"created\":\"2019-07-13T01:15:13.567669812Z\",\"created_by\":\"/bin/sh -c #(nop)  ENV _BASH_GPG_KEY=7C0135FB088AAF6C66C650B9BB5869F064EA74AB\",\"empty_layer\":true},{\"created\":\"2019-07-13T01:15:13.745652098Z\",\"created_by\":\"/bin/sh -c #(nop)  ENV _BASH_VERSION=5.0\",\"empty_layer\":true},{\"created\":\"2019-07-13T01:15:13.940455419Z\",\"created_by\":\"/bin/sh -c #(nop)  ENV _BASH_PATCH_LEVEL=0\",\"empty_layer\":true},{\"created\":\"2019-07-13T01:15:14.099300075Z\",\"created_by\":\"/bin/sh -c #(nop)  ENV _BASH_LATEST_PATCH=7\",\"empty_layer\":true},{\"created\":\"2019-07-13T01:16:05.928429262Z\",\"created_by\":\"/bin/sh -c set -eux; \\t\\tapk add --no-cache --virtual .build-deps \\t\\tbison \\t\\tcoreutils \\t\\tdpkg-dev dpkg \\t\\tgcc \\t\\tgnupg \\t\\tlibc-dev \\t\\tmake \\t\\tncurses-dev \\t\\tpatch \\t\\ttar \\t; \\t\\tversion=\\\"$_BASH_VERSION\\\"; \\tif [ \\\"$_BASH_PATCH_LEVEL\\\" -gt 0 ]; then \\t\\tversion=\\\"$version.$_BASH_PATCH_LEVEL\\\"; \\tfi; \\twget -O bash.tar.gz \\\"https://ftp.gnu.org/gnu/bash/bash-$version.tar.gz\\\"; \\twget -O bash.tar.gz.sig \\\"https://ftp.gnu.org/gnu/bash/bash-$version.tar.gz.sig\\\"; \\t\\tif [ \\\"$_BASH_LATEST_PATCH\\\" -gt \\\"$_BASH_PATCH_LEVEL\\\" ]; then \\t\\tmkdir -p bash-patches; \\t\\tfirst=\\\"$(printf '%03d' \\\"$(( _BASH_PATCH_LEVEL + 1 ))\\\")\\\"; \\t\\tlast=\\\"$(printf '%03d' \\\"$_BASH_LATEST_PATCH\\\")\\\"; \\t\\tfor patch in $(seq -w \\\"$first\\\" \\\"$last\\\"); do \\t\\t\\turl=\\\"https://ftp.gnu.org/gnu/bash/bash-$_BASH_VERSION-patches/bash${_BASH_VERSION//./}-$patch\\\"; \\t\\t\\twget -O \\\"bash-patches/$patch\\\" \\\"$url\\\"; \\t\\t\\twget -O \\\"bash-patches/$patch.sig\\\" \\\"$url.sig\\\"; \\t\\tdone; \\tfi; \\t\\texport GNUPGHOME=\\\"$(mktemp -d)\\\"; \\tgpg --batch --keyserver ha.pool.sks-keyservers.net --recv-keys \\\"$_BASH_GPG_KEY\\\"; \\tgpg --batch --verify bash.tar.gz.sig bash.tar.gz; \\tgpgconf --kill all; \\trm bash.tar.gz.sig; \\tif [ -d bash-patches ]; then \\t\\tfor sig in bash-patches/*.sig; do \\t\\t\\tp=\\\"${sig%.sig}\\\"; \\t\\t\\tgpg --batch --verify \\\"$sig\\\" \\\"$p\\\"; \\t\\t\\trm \\\"$sig\\\"; \\t\\tdone; \\tfi; \\trm -rf \\\"$GNUPGHOME\\\"; \\t\\tmkdir -p /usr/src/bash; \\ttar \\t\\t--extract \\t\\t--file=bash.tar.gz \\t\\t--strip-components=1 \\t\\t--directory=/usr/src/bash \\t; \\trm bash.tar.gz; \\t\\tif [ -d bash-patches ]; then \\t\\tfor p in bash-patches/*; do \\t\\t\\tpatch \\t\\t\\t\\t--directory=/usr/src/bash \\t\\t\\t\\t--input=\\\"$(readlink -f \\\"$p\\\")\\\" \\t\\t\\t\\t--strip=0 \\t\\t\\t; \\t\\t\\trm \\\"$p\\\"; \\t\\tdone; \\t\\trmdir bash-patches; \\tfi; \\t\\tcd /usr/src/bash; \\tgnuArch=\\\"$(dpkg-architecture --query DEB_BUILD_GNU_TYPE)\\\"; \\t./configure \\t\\t--build=\\\"$gnuArch\\\" \\t\\t--enable-readline \\t\\t--with-curses \\t\\t--without-bash-malloc \\t|| { \\t\\tcat \\u003e\\u00262 config.log; \\t\\tfalse; \\t}; \\tmake -j \\\"$(nproc)\\\"; \\tmake install; \\tcd /; \\trm -r /usr/src/bash; \\t\\trm -r \\t\\t/usr/local/share/doc/bash/*.html \\t\\t/usr/local/share/info \\t\\t/usr/local/share/locale \\t\\t/usr/local/share/man \\t; \\t\\trunDeps=\\\"$( \\t\\tscanelf --needed --nobanner --format '%n#p' --recursive /usr/local \\t\\t\\t| tr ',' '\\\\n' \\t\\t\\t| sort -u \\t\\t\\t| awk 'system(\\\"[ -e /usr/local/lib/\\\" $1 \\\" ]\\\") == 0 { next } { print \\\"so:\\\" $1 }' \\t)\\\"; \\tapk add --no-cache --virtual .bash-rundeps $runDeps; \\tapk del .build-deps; \\t\\t[ \\\"$(which bash)\\\" = '/usr/local/bin/bash' ]; \\tbash --version; \\t[ \\\"$(bash -c 'echo \\\"${BASH_VERSION%%[^0-9.]*}\\\"')\\\" = \\\"${_BASH_VERSION%%-*}.$_BASH_LATEST_PATCH\\\" ];\"},{\"created\":\"2019-07-13T01:16:06.164128412Z\",\"created_by\":\"/bin/sh -c #(nop) COPY file:651b3bebeba8be9162c56b3eb561199905235f3e1c7811232b6c9f48ac333651 in /usr/local/bin/ \"},{\"created\":\"2019-07-13T01:16:06.319375884Z\",\"created_by\":\"/bin/sh -c #(nop)  ENTRYPOINT [\\\"docker-entrypoint.sh\\\"]\",\"empty_layer\":true},{\"created\":\"2019-07-13T01:16:06.527515902Z\",\"created_by\":\"/bin/sh -c #(nop)  CMD [\\\"bash\\\"]\",\"empty_layer\":true}],\"os\":\"linux\",\"rootfs\":{\"type\":\"layers\",\"diff_ids\":[\"sha256:1bfeebd65323b8ddf5bd6a51cc7097b72788bc982e9ab3280d53d3c613adffa7\",\"sha256:483c980ac6abf63fc4d7262b17a1954d62266dac3029b5be384d03b39229803e\",\"sha256:5f5f93a93305210a96cc417f579d70a496bbf0db8e80ea1e9436682c379f25d9\"]}}";
        string ProdConfigBlobDigest = "sha256:16463e0c481e161aabb735437d30b3c9c7391c2747cc564bb927e843b73dcb39";

        [Fact]
        public async Task GetBlob()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetBlob)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                Stream blob = await client.Blob.GetAsync(ACRTestUtil.ProdRepository, ProdConfigBlobDigest);
                StreamReader reader = new StreamReader(blob, Encoding.UTF8);
                string originalBlob = reader.ReadToEnd();
                Assert.Equal(ProdConfigBlob, originalBlob);
            }
        }

        [Fact]
        public async Task CheckBlob()
        {
            using (var context = MockContext.Start(GetType(), nameof(CheckBlob)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var blob = await client.Blob.CheckAsync(ACRTestUtil.ProdRepository, ProdConfigBlobDigest);
                Assert.Equal(blob.DockerContentDigest, ProdConfigBlobDigest);
                Assert.Equal(5635, blob.ContentLength);
            }
        }

        [Fact]
        public async Task DeleteBlob()
        {
            using (var context = MockContext.Start(GetType(), nameof(DeleteBlob)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);
                string digest = await UploadLayer(GenerateStreamFromString("Testdata"), client, ACRTestUtil.BlobTestRepository);
                await client.Blob.DeleteAsync(ACRTestUtil.BlobTestRepository, digest);
                // Should not find layer
                Assert.Throws<AcrErrorsException>(() => { client.Blob.CheckAsync(ACRTestUtil.BlobTestRepository, digest).GetAwaiter().GetResult(); }); // Should error
            }
        }

        [Fact]
        public async Task UploadLayerNext()
        {
            using (var context = MockContext.Start(GetType(), nameof(UploadLayerNext)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                string digest = await UploadLayer(GenerateStreamFromString("SomethingElse"), client, ACRTestUtil.BlobTestRepository);
                var blob = await client.Blob.GetAsync(ACRTestUtil.BlobTestRepository, digest);
                StreamReader reader = new StreamReader(blob, Encoding.UTF8);
                Assert.Equal("SomethingElse", reader.ReadToEnd());
            }
        }

        [Fact]
        public async Task CancelBlobUpload()
        {
            using (var context = MockContext.Start(GetType(), nameof(CancelBlobUpload)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);
                var uploadInfo = await client.Blob.StartUploadAsync(ACRTestUtil.changeableRepository);
                await client.Blob.CancelUploadAsync(uploadInfo.Location);
            }
        }

        [Fact]
        public async Task GetBlobStatus()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetBlobStatus)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var uploadInfo = await client.Blob.StartUploadAsync(ACRTestUtil.BlobTestRepository);
                var status = await client.Blob.GetStatusAsync(uploadInfo.Location.Substring(1));
                Assert.Equal(uploadInfo.DockerUploadUUID, status.DockerUploadUUID);
                Assert.Equal("0-0", status.Range);
                await client.Blob.CancelUploadAsync(uploadInfo.Location);
            }
        }

        [Fact]
        public async Task GetBlobChunk()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetBlobChunk)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                Stream blob = await client.Blob.GetChunkAsync(ACRTestUtil.ProdRepository, ProdConfigBlobDigest, "bytes=0-299");
                StreamReader reader = new StreamReader(blob, Encoding.UTF8);
                string originalBlob = reader.ReadToEnd();
                Assert.Equal(ProdConfigBlob.Substring(0, 300), originalBlob);
            }
        }

        [Fact]
        public async Task MountBlob()
        {
            using (var context = MockContext.Start(GetType(), nameof(MountBlob)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);
                var res = await client.Blob.MountAsync("somethingnew", "doundo/bash", "sha256:16463e0c481e161aabb735437d30b3c9c7391c2747cc564bb927e843b73dcb39");
                Stream blob = await client.Blob.GetAsync("somethingnew", "sha256:16463e0c481e161aabb735437d30b3c9c7391c2747cc564bb927e843b73dcb39");
                StreamReader reader = new StreamReader(blob, Encoding.UTF8);
                string originalBlob = reader.ReadToEnd();
                Assert.Equal(ProdConfigBlob, originalBlob);
            }
        }

        [Fact]
        public async Task CheckBlobChunk()
        {
            using (var context = MockContext.Start(GetType(), nameof(CheckBlobChunk)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var blobData = await client.Blob.CheckChunkAsync(ACRTestUtil.ProdRepository, ProdConfigBlobDigest, "bytes=0-300");
                //Range is actually ignored in this request. Ends up working quite similarly to CheckBlob
                Assert.Equal(5635, blobData.ContentLength);
            }
        }

        /// <summary>
        /// This test should be run only live.
        /// HTTP calls made by the clients in <see cref="ContainerRegistryRefreshToken"> and <see cref="ContainerRegistryAccessToken">
        /// aren't being mocked by the test framework. This leads to issues when trying to refresh AADTokens during "playback" as these
        /// clients' requests are always "live".
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "Should be run only live")]
        public async Task GetBlobOAuth()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetBlobOAuth)))
            {
                LoginMode loginMode = LoginMode.TokenAuth; // use oauth - exchange username and password for a refreshtoken
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry, loginMode);
                Stream blob = await client.Blob.GetAsync(ACRTestUtil.ProdRepository, ProdConfigBlobDigest);
                StreamReader reader = new StreamReader(blob, Encoding.UTF8);
                string originalBlob = reader.ReadToEnd();
                Assert.Equal(ProdConfigBlob, originalBlob);
            }
        }

        /// <summary>
        /// This test should be run only live.
        /// HTTP calls made by the clients in <see cref="ContainerRegistryRefreshToken"> and <see cref="ContainerRegistryAccessToken">
        /// aren't being mocked by the test framework. This leads to issues when trying to refresh AADTokens during "playback" as these
        /// clients' requests are always "live".
        /// </summary>
        /// <returns></returns>
        [Fact(Skip="Should be run only live")]
        public async Task GetBlobAAD()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetBlobAAD)))
            {
                LoginMode loginMode = LoginMode.TokenAad; // use AAD
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry, loginMode);
                Stream blob = await client.Blob.GetAsync(ACRTestUtil.ProdRepository, ProdConfigBlobDigest);
                StreamReader reader = new StreamReader(blob, Encoding.UTF8);
                string originalBlob = reader.ReadToEnd();
                Assert.Equal(ProdConfigBlob, originalBlob);
            }
        }

        #region Helpers
        private async Task<string> UploadLayer(Stream blob, AzureContainerRegistryClient client, string repository)
        {
            // Make copy to obtain the ability to rewind the stream
            Stream cpy = new MemoryStream();
            blob.CopyTo(cpy);
            cpy.Position = 0;

            string digest = ComputeDigest(cpy);
            cpy.Position = 0;

            var uploadInfo = await client.Blob.StartUploadAsync(repository);
            var uploadedLayer = await client.Blob.UploadAsync(cpy, uploadInfo.Location);
            var uploadedLayerEnd = await client.Blob.EndUploadAsync(digest, uploadedLayer.Location);
            return uploadedLayerEnd.DockerContentDigest;
        }

        private static string ComputeDigest(Stream s)
        {
            s.Position = 0;
            StringBuilder sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                byte[] result = hash.ComputeHash(s);

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return "sha256:" + sb.ToString();

        }

        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        #endregion
    }
}
