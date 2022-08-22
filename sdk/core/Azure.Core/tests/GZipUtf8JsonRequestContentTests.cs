// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class GZipUtf8JsonRequestContentTests
    {
        [Test]
        public void GZipRequestContent_DirectWrite()
        {
            GZipUtf8JsonRequestContent gzContent = new GZipUtf8JsonRequestContent();
            gzContent.JsonWriter.WriteStartObject();
            Enumerable.Range(1, 100).ToList().ForEach(i =>
            {
                gzContent.JsonWriter.WritePropertyName("FooProp" + i);
                gzContent.JsonWriter.WriteStringValue(Guid.NewGuid().ToString());
            });
            gzContent.JsonWriter.WriteEndObject();

            string deserialized = UncompressAndDeserialize(gzContent);
            Assert.IsNotEmpty(deserialized);

            deserialized = UncompressAndDeserialize(gzContent);
            Assert.IsNotEmpty(deserialized);
        }

        [Test]
        public void GZipRequestContent_BufferCopy()
        {
            object payload = GetObj();
            RequestContent rc = RequestContent.Create(payload);
            GZipUtf8JsonRequestContent gzContent = new GZipUtf8JsonRequestContent(rc);

            string deserialized = UncompressAndDeserialize(gzContent);
            Assert.IsNotEmpty(deserialized);

            deserialized = UncompressAndDeserialize(gzContent);
            Assert.IsNotEmpty(deserialized);
        }

        [Test]
        public void GZipRequestContent_BufferCopy_TryComputeLength()
        {
            object payload = GetObj();
            RequestContent rc = RequestContent.Create(payload);
            GZipUtf8JsonRequestContent gzContent = new GZipUtf8JsonRequestContent(rc);
            long length = 0;
            gzContent.TryComputeLength(out length);
            Assert.Greater(length, 10);

            string deserialized = UncompressAndDeserialize(gzContent);
            Assert.IsNotEmpty(deserialized);

            deserialized = UncompressAndDeserialize(gzContent);
            Assert.IsNotEmpty(deserialized);
        }

        [Test]
        public void GZipRequestContent_DirectWriteAndComputeLength()
        {
            long length = 0;
            GZipUtf8JsonRequestContent gzContent = new GZipUtf8JsonRequestContent();
            gzContent.TryComputeLength(out length);
            Assert.AreEqual(0, length);
            gzContent.JsonWriter.WriteStartObject();
            Enumerable.Range(1, 100).ToList().ForEach(i =>
            {
                gzContent.JsonWriter.WritePropertyName("FooProp" + i);
                gzContent.JsonWriter.WriteStringValue(Guid.NewGuid().ToString());
            });
            gzContent.JsonWriter.WriteEndObject();
            gzContent.TryComputeLength(out length);
            Assert.Greater(length, 1000);
            string deserialized = UncompressAndDeserialize(gzContent);
            Assert.IsNotEmpty(deserialized);

            gzContent.TryComputeLength(out length);
            Assert.Greater(length, 1000);
            deserialized = UncompressAndDeserialize(gzContent);
            Assert.IsNotEmpty(deserialized);
        }

        private static string UncompressAndDeserialize(RequestContent gzContent)
        {
            var memStream = new MemoryStream();
            gzContent.WriteTo(memStream, default);
            memStream.Position = 0;
            var ds = new MemoryStream();
            var dgz = new GZipStream(memStream, CompressionMode.Decompress);
            dgz.CopyTo(ds);
            ds.Flush();
            ds.Position = 0;
            var dsr = new StreamReader(ds);
            return dsr.ReadToEnd();
        }

        private object GetObj()
        {
            return new { FooProp1 = "d834b7ce-1278-4ad3-b8c3-d1f18744c1f1", FooProp2 = "a8358281-7241-4594-952e-5fe810383a16", FooProp3 = "a8ba30fd-3048-4ebd-b6a9-db5f880726e9", FooProp4 = "11d97f04-aa17-4a79-bcc0-5f7d8867c585", FooProp5 = "a32ef731-1d21-417e-989f-ed12cdae6993", FooProp6 = "f9a9bdb4-0f0b-4c0f-9331-5a3dd4974115", FooProp7 = "5e482488-8f8d-414c-a027-101d3fec5ded", FooProp8 = "dca3f5fb-162a-4143-9ec6-1a3bacc3bf50", FooProp9 = "d88ce0d9-e346-4dd4-8428-008a012bec4e", FooProp10 = "a1874b81-7a59-49f2-9777-73b4546d3c15", FooProp11 = "3b241d89-307f-4318-8a8d-d34c4836af8c", FooProp12 = "d88a91d4-c323-43d6-bef9-e8b49a7c7f94", FooProp13 = "eefc1ffb-cbb2-4a64-b2ca-05385f1afd02", FooProp14 = "c28133d4-74b3-477a-b56a-1ac6de5685da", FooProp15 = "fd05e169-142e-45ed-b893-2bd4d7501f1d", FooProp16 = "042762c8-5773-4008-a9ac-5fa3d7dc260a", FooProp17 = "9433df3a-695a-4000-ab06-0d45616a47a8", FooProp18 = "70c49e79-0bf9-4fb0-b656-ba72f5867ead", FooProp19 = "73f5cfa9-bdf6-4b89-862e-5b689c431209", FooProp20 = "8b70a2e4-2602-42d5-bf75-b6a59196085d", FooProp21 = "2a56d4a1-9561-4d89-a8f2-af4088b84ead", FooProp22 = "25472611-c4a4-4c64-8c80-b09d6961d2b2", FooProp23 = "47744555-7402-4031-8f9b-7569bf40a428", FooProp24 = "84e3255e-cbd5-4cb2-8f60-c5c0c5b5c017", FooProp25 = "2a602e92-9459-41ec-9058-dd05b66d7f9f", FooProp26 = "8ba8c5d9-6b91-48d9-bc3d-4f13c73556a8", FooProp27 = "b7738e33-14a1-413d-bd8a-b4a8910b0dc6", FooProp28 = "7f4bcfdb-d1e3-4e91-a148-5d69f2ab761a", FooProp29 = "d11a5379-c5d6-46d9-8a7c-02a310f7ff4a", FooProp30 = "6c299e81-d83c-461b-a648-8278c8ee8d3b", FooProp31 = "2c08e2bb-1aea-415d-b069-07477962f109", FooProp32 = "5be6a52a-0875-42c4-bd73-0e5d83d8759d", FooProp33 = "73e3b1ce-8e6a-4e28-bd35-e2932242c0b6", FooProp34 = "0150d32c-9c8e-43b9-bb46-545499d95222", FooProp35 = "f526c453-bfe7-4a57-add5-9585aabab36d", FooProp36 = "638434d4-fd11-4be7-a6e6-b7b6616b4acc", FooProp37 = "b9eed1d2-1963-40a1-8314-2f3893799c6a", FooProp38 = "cfb59d40-4e30-44e4-a282-b2be95ea8c11", FooProp39 = "3ee4d713-a8a7-4268-929d-aa021ce652b6", FooProp40 = "b507eb4e-a7a6-4e98-b2c2-acbb2bd0e756", FooProp41 = "7019cc82-e674-4d95-8f9e-08517519884f", FooProp42 = "14d916ef-dee8-4b01-8b93-7beb6dd8d0f0", FooProp43 = "328f4e3f-57b7-492e-9efe-7ea8c158847d", FooProp44 = "ad9147c7-22c4-4405-9c5b-fe27a2b0e750", FooProp45 = "c456d375-ab9e-492a-a168-fdb9cd8efa3a", FooProp46 = "2ccaf1cf-ab1b-43a6-bc52-ef03711b50ec", FooProp47 = "94ccebcd-8c81-41eb-8d76-9376f96f3487", FooProp48 = "d71515ab-5bad-40ed-83e4-4365e6654879", FooProp49 = "649fd982-60e4-40bd-9c16-3afd7d4471e8", FooProp50 = "1b4a620c-a405-424e-8956-f017529385af", FooProp51 = "44cfbbb8-3b1e-42ff-87a9-3beb8341b73c", FooProp52 = "fa48f630-0bcb-4ecc-b428-4029f223902e", FooProp53 = "fb646cd1-6825-4929-acd6-61b3f6fa7cb7", FooProp54 = "a4b3dda9-d7a1-4fb9-b50e-1cddf84f3b95", FooProp55 = "ef838dfe-be52-4f36-82e3-9c05501b132b", FooProp56 = "6652bf63-7470-424d-be91-e9bfde5227ae", FooProp57 = "16cec535-1007-4823-ad12-b2a858e9f7c6", FooProp58 = "63c9b784-d2c5-4f96-9452-655da3ecf476", FooProp59 = "adfa1092-93e2-4797-bcb1-c813a2b81e12", FooProp60 = "b7cae458-a4b4-40da-a322-15f1fbd77685", FooProp61 = "eda7e4d8-2c67-4b7a-b8b4-37ad7b542074", FooProp62 = "c721d0d2-6f83-4222-ac2a-868f6ad533d7", FooProp63 = "503d3cc9-217b-47dd-a8ff-f3c815bd6320", FooProp64 = "989756f3-d6cb-42bb-a04b-ac1ce806d4af", FooProp65 = "ec419e6c-a152-443b-b9fe-9eda85d57430", FooProp66 = "721a7228-4d1d-463b-a06f-3f80bf98e686", FooProp67 = "8f85a558-9fd7-4314-b05c-8cc254a7e858", FooProp68 = "46514db6-3ed7-4df5-b1f3-8a4a39f0a842", FooProp69 = "76545ae5-a118-4b11-9f34-db0b2baa94a3", FooProp70 = "3709db6e-fccd-47a4-a3d0-af0222e5ed46", FooProp71 = "b626a288-9b56-4eb2-93ce-551cbb13478f", FooProp72 = "1d82012e-0315-48cc-8c98-59798b07780f", FooProp73 = "1876a39c-10c3-4ec5-b562-225294c37563", FooProp74 = "8960bb87-9625-4812-ab3b-c250c0f3d547", FooProp75 = "c9f19c90-b5c0-4ab4-bfaf-322179ff2d4e", FooProp76 = "865f06dc-dfaf-4773-9ebd-9478801b3846", FooProp77 = "79c3a89e-b25e-4154-8dc7-eb1d2ccb5d76", FooProp78 = "10c015a3-53ba-42fa-b612-c2895221ef8c", FooProp79 = "8d49f333-54ee-4928-bc01-a200bf278b82", FooProp80 = "17b20da8-4c55-405b-b1ff-36f41075a5c4", FooProp81 = "6b42a594-0d06-486c-89e3-6f55cfbf9c67", FooProp82 = "18128405-1ec9-4ba2-b6f8-353b8939e2a6", FooProp83 = "9b4988f8-572c-4359-acc8-843953d32169", FooProp84 = "80e3de57-0dd6-4a66-bd3f-25aa1ad5007a", FooProp85 = "6302ab4e-f6da-4efc-8d30-459c8535993c", FooProp86 = "027eb872-94ce-4685-b722-f53d0f6ddc82", FooProp87 = "1595f2fe-d5df-440a-a68b-8c3e3ce1e353", FooProp88 = "292628c6-6887-4734-b526-133a6c2badf7", FooProp89 = "8bd0b190-f970-4da9-b306-9dc4193f3785", FooProp90 = "841e0081-e144-440e-b5b0-f7294e938494", FooProp91 = "3fcb86e6-b30c-4ca5-94aa-92f3366c35d9", FooProp92 = "d24bcfae-9877-40c4-a779-be4ed78037cb", FooProp93 = "505a1610-7ef4-4429-88a4-48b127f1ca11", FooProp94 = "4e2abc7b-99f4-4692-a6b8-e9031fa77856", FooProp95 = "3e259538-b49b-45b6-bbde-96e250071237", FooProp96 = "6af07e10-d33a-46f7-a8e7-00b16cc740a9", FooProp97 = "a2551203-6914-490c-8ffe-0a90211063a3", FooProp98 = "6cd366d8-67c4-48be-b3c0-41851c91aa55", FooProp99 = "733764e6-8786-494b-9733-9f0e8eca1900" };
        }
    }
}
