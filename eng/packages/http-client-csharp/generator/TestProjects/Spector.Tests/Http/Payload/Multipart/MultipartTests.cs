// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure;
using Azure.Core;
using Payload.MultiPart;
using Payload.MultiPart._FormData;
using Payload.MultiPart._FormData.File;
using Payload.MultiPart._FormData.HttpParts;
using Payload.MultiPart._FormData.HttpParts.ContentType;
using Payload.MultiPart._FormData.HttpParts.NonString;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using File = System.IO.File;

namespace TestProjects.Spector.Tests.Http.Payload.Multipart
{
#pragma warning disable SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    internal class MultipartTests : SpectorTestBase
    {
        private static readonly string SamplePngPath = Path.Combine(SpectorServer.GetSpecDirectory(), "assets", "image.png");
        private static readonly string SampleJpgPath = Path.Combine(SpectorServer.GetSpecDirectory(), "assets", "image.jpg");

        private static void Assert204(Response response) => Assert.AreEqual(204, response.Status);
        private static FormData GetFormData(Uri host) => new MultiPartClient(host, null).GetFormDataClient();
        private static FormDataFile GetFormDataFile(Uri host) => GetFormData(host).GetFormDataFileClient();
        private static FormDataHttpParts GetFormDataHttpParts(Uri host) => GetFormData(host).GetFormDataHttpPartsClient();
        private static FormDataHttpPartsContentType GetFormDataHttpPartsContentType(Uri host) => GetFormDataHttpParts(host).GetFormDataHttpPartsContentTypeClient();
        private static FormDataHttpPartsNonString GetFormDataHttpPartsNonString(Uri host) => GetFormDataHttpParts(host).GetFormDataHttpPartsNonStringClient();

        [SpectorTest]
        public Task BasicProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            content.Add("id", "123", "text/plain");
            await using var stream = File.OpenRead(SampleJpgPath);
            content.Add("profileImage", new FileBinaryContent(stream) { Filename = "profileImage.jpg" });

            Assert204(await GetFormData(host).BasicAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task BasicConvFromPath() => Test(async (host) =>
        {
            var request = new MultiPartRequest("123", SampleJpgPath);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).BasicAsync(request));
        });

        [SpectorTest]
        public Task BasicConvFromStream() => Test(async (host) =>
        {
            await using var stream = File.OpenRead(SampleJpgPath);
            var request = new MultiPartRequest("123", stream);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).BasicAsync(request));
        });

        [SpectorTest]
        public Task BasicConvFromBinaryData() => Test(async (host) =>
        {
            var request = new MultiPartRequest("123", BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).BasicAsync(request));
        });

        [SpectorTest]
        public Task BasicConvFromFileBinaryContent() => Test(async (host) =>
        {
            var request = new MultiPartRequest("123", new FileBinaryContent(SampleJpgPath) { Filename = "profileImage.jpg" });
            Assert204(await GetFormData(host).BasicAsync(request));
        });

        [SpectorTest]
        public Task WithWireNameProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            content.Add("id", "123", "text/plain");
            await using var stream = File.OpenRead(SampleJpgPath);
            content.Add("profileImage", new FileBinaryContent(stream) { Filename = "profileImage.jpg" });

            Assert204(await GetFormData(host).WithWireNameAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task WithWireNameConvFromPath() => Test(async (host) =>
        {
            var request = new MultiPartRequestWithWireName("123", SampleJpgPath);
            request.Image.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).WithWireNameAsync(request));
        });

        [SpectorTest]
        public Task WithWireNameConvFromStream() => Test(async (host) =>
        {
            await using var stream = File.OpenRead(SampleJpgPath);
            var request = new MultiPartRequestWithWireName("123", stream);
            request.Image.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).WithWireNameAsync(request));
        });

        [SpectorTest]
        public Task WithWireNameConvFromBinaryData() => Test(async (host) =>
        {
            var request = new MultiPartRequestWithWireName("123", BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            request.Image.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).WithWireNameAsync(request));
        });

        [SpectorTest]
        public Task WithWireNameConvFromFileBinaryContent() => Test(async (host) =>
        {
            var request = new MultiPartRequestWithWireName("123", new FileBinaryContent(SampleJpgPath) { Filename = "profileImage.jpg" });
            Assert204(await GetFormData(host).WithWireNameAsync(request));
        });

        // Spec: send 3 times — id only, profileImage only, both.

        [SpectorTest]
        public Task OptionalPartsProtocol() => Test(async (host) =>
        {
            using (MultiPartFormContent idOnly = new())
            {
                idOnly.Add("id", "123", "text/plain");
                Assert204(await GetFormData(host).OptionalPartsAsync(RequestContent.Create(idOnly), idOnly.MediaType));
            }

            using (MultiPartFormContent imageOnly = new())
            {
                await using var stream1 = File.OpenRead(SampleJpgPath);
                imageOnly.Add("profileImage", new FileBinaryContent(stream1) { Filename = "profileImage.jpg" });
                Assert204(await GetFormData(host).OptionalPartsAsync(RequestContent.Create(imageOnly), imageOnly.MediaType));
            }

            using (MultiPartFormContent both = new())
            {
                both.Add("id", "123", "text/plain");
                await using var stream2 = File.OpenRead(SampleJpgPath);
                both.Add("profileImage", new FileBinaryContent(stream2) { Filename = "profileImage.jpg" });
                Assert204(await GetFormData(host).OptionalPartsAsync(RequestContent.Create(both), both.MediaType));
            }
        });

        [SpectorTest]
        public Task OptionalPartsConvDefault() => Test(async (host) =>
        {
            // id only
            var idOnly = new MultiPartOptionalRequest { Id = "123" };
            Assert204(await GetFormData(host).OptionalPartsAsync(idOnly));

            // image only
            var imageOnly = new MultiPartOptionalRequest
            {
                ProfileImage = new FileBinaryContent(SampleJpgPath) { Filename = "profileImage.jpg" },
            };
            Assert204(await GetFormData(host).OptionalPartsAsync(imageOnly));

            // both
            var both = new MultiPartOptionalRequest
            {
                Id = "123",
                ProfileImage = new FileBinaryContent(SampleJpgPath) { Filename = "profileImage.jpg" },
            };
            Assert204(await GetFormData(host).OptionalPartsAsync(both));
        });

        [SpectorTest]
        public Task FileArrayAndBasicProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            content.Add("id", "123", "text/plain");
            content.Add("address", new Address("X"));
            await using var jpg = File.OpenRead(SampleJpgPath);
            content.Add("profileImage", new FileBinaryContent(jpg) { Filename = "profileImage.jpg" });
            await using var png1 = File.OpenRead(SamplePngPath);
            await using var png2 = File.OpenRead(SamplePngPath);
            content.Add("pictures", new FileBinaryContent(png1) { Filename = "pictures1.png" });
            content.Add("pictures", new FileBinaryContent(png2) { Filename = "pictures2.png" });

            Assert204(await GetFormData(host).FileArrayAndBasicAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task FileArrayAndBasicConvFromPath() => Test(async (host) =>
        {
            var pictures = new[]
            {
                new FileBinaryContent(SamplePngPath) { Filename = "pictures1.png" },
                new FileBinaryContent(SamplePngPath) { Filename = "pictures2.png" },
            };
            var request = new ComplexPartsRequest("123", new Address("X"), SampleJpgPath, pictures);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).FileArrayAndBasicAsync(request));
        });

        [SpectorTest]
        public Task FileArrayAndBasicConvFromStream() => Test(async (host) =>
        {
            await using var jpg = File.OpenRead(SampleJpgPath);
            var pictures = new[]
            {
                new FileBinaryContent(SamplePngPath) { Filename = "pictures1.png" },
                new FileBinaryContent(SamplePngPath) { Filename = "pictures2.png" },
            };
            var request = new ComplexPartsRequest("123", new Address("X"), jpg, pictures);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).FileArrayAndBasicAsync(request));
        });

        [SpectorTest]
        public Task FileArrayAndBasicConvFromBinaryData() => Test(async (host) =>
        {
            var pictures = new[]
            {
                new FileBinaryContent(SamplePngPath) { Filename = "pictures1.png" },
                new FileBinaryContent(SamplePngPath) { Filename = "pictures2.png" },
            };
            var request = new ComplexPartsRequest("123", new Address("X"), BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)), pictures);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).FileArrayAndBasicAsync(request));
        });

        [SpectorTest]
        public Task FileArrayAndBasicConvFromFileBinaryContent() => Test(async (host) =>
        {
            var pictures = new[]
            {
                new FileBinaryContent(SamplePngPath) { Filename = "pictures1.png" },
                new FileBinaryContent(SamplePngPath) { Filename = "pictures2.png" },
            };
            var request = new ComplexPartsRequest(
                "123",
                new Address("X"),
                new FileBinaryContent(SampleJpgPath) { Filename = "profileImage.jpg" },
                pictures);
            Assert204(await GetFormData(host).FileArrayAndBasicAsync(request));
        });

        [SpectorTest]
        public Task JsonPartProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            content.Add("address", new Address("X"));
            await using var stream = File.OpenRead(SampleJpgPath);
            content.Add("profileImage", new FileBinaryContent(stream) { Filename = "profileImage.jpg" });

            Assert204(await GetFormData(host).JsonPartAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task JsonPartConvFromPath() => Test(async (host) =>
        {
            var request = new JsonPartRequest(new Address("X"), SampleJpgPath);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).JsonPartAsync(request));
        });

        [SpectorTest]
        public Task JsonPartConvFromStream() => Test(async (host) =>
        {
            await using var stream = File.OpenRead(SampleJpgPath);
            var request = new JsonPartRequest(new Address("X"), stream);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).JsonPartAsync(request));
        });

        [SpectorTest]
        public Task JsonPartConvFromBinaryData() => Test(async (host) =>
        {
            var request = new JsonPartRequest(new Address("X"), BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).JsonPartAsync(request));
        });

        [SpectorTest]
        public Task JsonPartConvFromFileBinaryContent() => Test(async (host) =>
        {
            var request = new JsonPartRequest(new Address("X"), new FileBinaryContent(SampleJpgPath) { Filename = "profileImage.jpg" });
            Assert204(await GetFormData(host).JsonPartAsync(request));
        });

        [SpectorTest]
        public Task BinaryArrayPartsProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            content.Add("id", "123", "text/plain");
            await using var png1 = File.OpenRead(SamplePngPath);
            await using var png2 = File.OpenRead(SamplePngPath);
            content.Add("pictures", new FileBinaryContent(png1) { Filename = "pictures1.png" });
            content.Add("pictures", new FileBinaryContent(png2) { Filename = "pictures2.png" });

            Assert204(await GetFormData(host).BinaryArrayPartsAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task BinaryArrayPartsConvFromFileBinaryContent() => Test(async (host) =>
        {
            var pictures = new[]
            {
                new FileBinaryContent(SamplePngPath) { Filename = "pictures1.png" },
                new FileBinaryContent(SamplePngPath) { Filename = "pictures2.png" },
            };
            var request = new BinaryArrayPartsRequest("123", pictures);
            Assert204(await GetFormData(host).BinaryArrayPartsAsync(request));
        });

        // Spec: send twice — only profileImage, then profileImage + picture.

        [SpectorTest]
        public Task MultiBinaryPartsProtocol() => Test(async (host) =>
        {
            using (MultiPartFormContent only = new())
            {
                await using var jpg = File.OpenRead(SampleJpgPath);
                only.Add("profileImage", new FileBinaryContent(jpg) { Filename = "profileImage.jpg" });
                Assert204(await GetFormData(host).MultiBinaryPartsAsync(RequestContent.Create(only), only.MediaType));
            }

            using (MultiPartFormContent both = new())
            {
                await using var jpg = File.OpenRead(SampleJpgPath);
                await using var png = File.OpenRead(SamplePngPath);
                both.Add("profileImage", new FileBinaryContent(jpg) { Filename = "profileImage.jpg" });
                both.Add("picture", new FileBinaryContent(png) { Filename = "picture.png" });
                Assert204(await GetFormData(host).MultiBinaryPartsAsync(RequestContent.Create(both), both.MediaType));
            }
        });

        [SpectorTest]
        public Task MultiBinaryPartsConvFromPath() => Test(async (host) =>
        {
            var only = new MultiBinaryPartsRequest(SampleJpgPath);
            only.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).MultiBinaryPartsAsync(only));

            var both = new MultiBinaryPartsRequest(SampleJpgPath)
            {
                Picture = new FileBinaryContent(SamplePngPath) { Filename = "picture.png" },
            };
            both.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).MultiBinaryPartsAsync(both));
        });

        [SpectorTest]
        public Task MultiBinaryPartsConvFromStream() => Test(async (host) =>
        {
            await using var jpg = File.OpenRead(SampleJpgPath);
            var request = new MultiBinaryPartsRequest(jpg);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).MultiBinaryPartsAsync(request));
        });

        [SpectorTest]
        public Task MultiBinaryPartsConvFromBinaryData() => Test(async (host) =>
        {
            var request = new MultiBinaryPartsRequest(BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).MultiBinaryPartsAsync(request));
        });

        [SpectorTest]
        public Task MultiBinaryPartsConvFromFileBinaryContent() => Test(async (host) =>
        {
            var request = new MultiBinaryPartsRequest(new FileBinaryContent(SampleJpgPath) { Filename = "profileImage.jpg" });
            Assert204(await GetFormData(host).MultiBinaryPartsAsync(request));
        });

        // Spec: filename = "hello.jpg", content-type = "image/jpg".

        [SpectorTest]
        public Task CheckFileNameAndContentTypeProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            content.Add("id", "123", "text/plain");
            await using var stream = File.OpenRead(SampleJpgPath);
            content.Add("profileImage", new FileBinaryContent(stream, "image/jpg") { Filename = "hello.jpg" });

            Assert204(await GetFormData(host).CheckFileNameAndContentTypeAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task CheckFileNameAndContentTypeConv() => Test(async (host) =>
        {
            var request = new MultiPartRequest("123", new FileBinaryContent(SampleJpgPath, "image/jpg") { Filename = "hello.jpg" });
            Assert204(await GetFormData(host).CheckFileNameAndContentTypeAsync(request));
        });

        [SpectorTest]
        public Task AnonymousModelProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            await using var stream = File.OpenRead(SampleJpgPath);
            content.Add("profileImage", new FileBinaryContent(stream) { Filename = "profileImage.jpg" });

            Assert204(await GetFormData(host).AnonymousModelAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task AnonymousModelConvFromPath() => Test(async (host) =>
        {
            var request = new AnonymousModelRequest(SampleJpgPath);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).AnonymousModelAsync(request));
        });

        [SpectorTest]
        public Task AnonymousModelConvFromStream() => Test(async (host) =>
        {
            await using var stream = File.OpenRead(SampleJpgPath);
            var request = new AnonymousModelRequest(stream);
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).AnonymousModelAsync(request));
        });

        [SpectorTest]
        public Task AnonymousModelConvFromBinaryData() => Test(async (host) =>
        {
            var request = new AnonymousModelRequest(BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            request.ProfileImage.Filename = "profileImage.jpg";
            Assert204(await GetFormData(host).AnonymousModelAsync(request));
        });

        [SpectorTest]
        public Task AnonymousModelConvFromFileBinaryContent() => Test(async (host) =>
        {
            var request = new AnonymousModelRequest(new FileBinaryContent(SampleJpgPath) { Filename = "profileImage.jpg" });
            Assert204(await GetFormData(host).AnonymousModelAsync(request));
        });

        [SpectorTest]
        public Task JsonArrayAndFileArrayProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            content.Add("id", "123", "text/plain");
            content.Add("address", new Address("X"));

            await using var jpg = File.OpenRead(SampleJpgPath);
            content.Add("profileImage", new FileBinaryContent(jpg) { Filename = "profileImage.jpg" });

            BinaryData previousAddresses = ModelReaderWriter.Write(
                new List<Address> { new Address("Y"), new Address("Z") },
                new ModelReaderWriterOptions("W"),
                PayloadMultiPartContext.Default);
            content.Add("previousAddresses", previousAddresses);

            await using var png1 = File.OpenRead(SamplePngPath);
            await using var png2 = File.OpenRead(SamplePngPath);
            content.Add("pictures", new FileBinaryContent(png1) { Filename = "pictures1.png" });
            content.Add("pictures", new FileBinaryContent(png2) { Filename = "pictures2.png" });

            Assert204(await GetFormDataHttpParts(host).JsonArrayAndFileArrayAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task JsonArrayAndFileArrayConvFromPath() => Test(async (host) =>
        {
            var pictures = new[]
            {
                new FileBinaryContent(SamplePngPath, "application/octet-stream") { Filename = "pictures1.png" },
                new FileBinaryContent(SamplePngPath, "application/octet-stream") { Filename = "pictures2.png" },
            };
            var request = new ComplexHttpPartsModelRequest(
                "123",
                new Address("X"),
                profileImageFilename: "profileImage.jpg",
                profileImageContentType: "application/octet-stream",
                profileImagePath: SampleJpgPath,
                previousAddresses: new[] { new Address("Y"), new Address("Z") },
                pictures: pictures);
            Assert204(await GetFormDataHttpParts(host).JsonArrayAndFileArrayAsync(request));
        });

        [SpectorTest]
        public Task JsonArrayAndFileArrayConvFromStream() => Test(async (host) =>
        {
            await using var jpg = File.OpenRead(SampleJpgPath);
            var pictures = new[]
            {
                new FileBinaryContent(SamplePngPath, "application/octet-stream") { Filename = "pictures1.png" },
                new FileBinaryContent(SamplePngPath, "application/octet-stream") { Filename = "pictures2.png" },
            };
            var request = new ComplexHttpPartsModelRequest(
                "123",
                new Address("X"),
                profileImageFilename: "profileImage.jpg",
                profileImageContentType: "application/octet-stream",
                profileImage: jpg,
                previousAddresses: new[] { new Address("Y"), new Address("Z") },
                pictures: pictures);
            Assert204(await GetFormDataHttpParts(host).JsonArrayAndFileArrayAsync(request));
        });

        [SpectorTest]
        public Task JsonArrayAndFileArrayConvFromBinaryData() => Test(async (host) =>
        {
            var pictures = new[]
            {
                new FileBinaryContent(SamplePngPath, "application/octet-stream") { Filename = "pictures1.png" },
                new FileBinaryContent(SamplePngPath, "application/octet-stream") { Filename = "pictures2.png" },
            };
            var request = new ComplexHttpPartsModelRequest(
                "123",
                new Address("X"),
                profileImageFilename: "profileImage.jpg",
                profileImageContentType: "application/octet-stream",
                profileImage: BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)),
                previousAddresses: new[] { new Address("Y"), new Address("Z") },
                pictures: pictures);
            Assert204(await GetFormDataHttpParts(host).JsonArrayAndFileArrayAsync(request));
        });

        // (model: FileWithHttpPartSpecificContentTypeRequest, 3 ctors)

        [SpectorTest]
        public Task ImageJpegContentTypeProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            await using var stream = File.OpenRead(SampleJpgPath);
            content.Add("profileImage", new FileBinaryContent(stream, "image/jpg") { Filename = "hello.jpg" });

            Assert204(await GetFormDataHttpPartsContentType(host).ImageJpegContentTypeAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task ImageJpegContentTypeConvFromPath() => Test(async (host) =>
        {
            var request = new FileWithHttpPartSpecificContentTypeRequest("hello.jpg", SampleJpgPath);
            Assert204(await GetFormDataHttpPartsContentType(host).ImageJpegContentTypeAsync(request));
        });

        [SpectorTest]
        public Task ImageJpegContentTypeConvFromStream() => Test(async (host) =>
        {
            await using var stream = File.OpenRead(SampleJpgPath);
            var request = new FileWithHttpPartSpecificContentTypeRequest("hello.jpg", stream);
            Assert204(await GetFormDataHttpPartsContentType(host).ImageJpegContentTypeAsync(request));
        });

        [SpectorTest]
        public Task ImageJpegContentTypeConvFromBinaryData() => Test(async (host) =>
        {
            var request = new FileWithHttpPartSpecificContentTypeRequest("hello.jpg", BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            Assert204(await GetFormDataHttpPartsContentType(host).ImageJpegContentTypeAsync(request));
        });

        // (model: FileWithHttpPartRequiredContentTypeRequest, 3 ctors)

        [SpectorTest]
        public Task RequiredContentTypeProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            await using var stream = File.OpenRead(SampleJpgPath);
            content.Add("profileImage", new FileBinaryContent(stream, "application/octet-stream") { Filename = "hello.jpg" });

            Assert204(await GetFormDataHttpPartsContentType(host).RequiredContentTypeAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task RequiredContentTypeConvFromPath() => Test(async (host) =>
        {
            var request = new FileWithHttpPartRequiredContentTypeRequest("hello.jpg", "application/octet-stream", SampleJpgPath);
            Assert204(await GetFormDataHttpPartsContentType(host).RequiredContentTypeAsync(request));
        });

        [SpectorTest]
        public Task RequiredContentTypeConvFromStream() => Test(async (host) =>
        {
            await using var stream = File.OpenRead(SampleJpgPath);
            var request = new FileWithHttpPartRequiredContentTypeRequest("hello.jpg", "application/octet-stream", stream);
            Assert204(await GetFormDataHttpPartsContentType(host).RequiredContentTypeAsync(request));
        });

        [SpectorTest]
        public Task RequiredContentTypeConvFromBinaryData() => Test(async (host) =>
        {
            var request = new FileWithHttpPartRequiredContentTypeRequest("hello.jpg", "application/octet-stream", BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            Assert204(await GetFormDataHttpPartsContentType(host).RequiredContentTypeAsync(request));
        });

        // (model: FileWithHttpPartOptionalContentTypeRequest, 3 ctors)
        // Spec: send twice — once without content-type, once with "application/octet-stream".
        // The model always sends "application/octet-stream"; the no-content-type send is exercised in the protocol test.

        [SpectorTest]
        public Task OptionalContentTypeProtocol() => Test(async (host) =>
        {
            using (MultiPartFormContent withoutContentType = new())
            {
                await using var stream = File.OpenRead(SampleJpgPath);
                withoutContentType.Add("profileImage", new FileBinaryContent(stream, mediaType: null) { Filename = "hello.jpg" });
                Assert204(await GetFormDataHttpPartsContentType(host).OptionalContentTypeAsync(RequestContent.Create(withoutContentType), withoutContentType.MediaType));
            }

            using (MultiPartFormContent withContentType = new())
            {
                await using var stream = File.OpenRead(SampleJpgPath);
                withContentType.Add("profileImage", new FileBinaryContent(stream, "application/octet-stream") { Filename = "hello.jpg" });
                Assert204(await GetFormDataHttpPartsContentType(host).OptionalContentTypeAsync(RequestContent.Create(withContentType), withContentType.MediaType));
            }
        });

        [SpectorTest]
        public Task OptionalContentTypeConvFromPath() => Test(async (host) =>
        {
            var request = new FileWithHttpPartOptionalContentTypeRequest("hello.jpg", SampleJpgPath);
            Assert204(await GetFormDataHttpPartsContentType(host).OptionalContentTypeAsync(request));
        });

        [SpectorTest]
        public Task OptionalContentTypeConvFromStream() => Test(async (host) =>
        {
            await using var stream = File.OpenRead(SampleJpgPath);
            var request = new FileWithHttpPartOptionalContentTypeRequest("hello.jpg", stream);
            Assert204(await GetFormDataHttpPartsContentType(host).OptionalContentTypeAsync(request));
        });

        [SpectorTest]
        public Task OptionalContentTypeConvFromBinaryData() => Test(async (host) =>
        {
            var request = new FileWithHttpPartOptionalContentTypeRequest("hello.jpg", BinaryData.FromBytes(File.ReadAllBytes(SampleJpgPath)));
            Assert204(await GetFormDataHttpPartsContentType(host).OptionalContentTypeAsync(request));
        });

        [SpectorTest]
        public Task FloatProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            content.Add("temperature", 0.5);
            Assert204(await GetFormDataHttpPartsNonString(host).FloatAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task FloatConv() => Test(async (host) =>
        {
            Assert204(await GetFormDataHttpPartsNonString(host).FloatAsync(new FloatRequest(0.5)));
        });

        // (model: UploadFileSpecificContentTypeRequest, 3 ctors)

        [SpectorTest]
        public Task UploadFileSpecificContentTypeProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            await using var stream = File.OpenRead(SamplePngPath);
            content.Add("file", new FileBinaryContent(stream, "image/png") { Filename = "image.png" });

            Assert204(await GetFormDataFile(host).UploadFileSpecificContentTypeAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task UploadFileSpecificContentTypeConvFromPath() => Test(async (host) =>
        {
            var request = new UploadFileSpecificContentTypeRequest(SamplePngPath);
            request.File.Filename = "image.png";
            Assert204(await GetFormDataFile(host).UploadFileSpecificContentTypeAsync(request));
        });

        [SpectorTest]
        public Task UploadFileSpecificContentTypeConvFromStream() => Test(async (host) =>
        {
            await using var stream = File.OpenRead(SamplePngPath);
            var request = new UploadFileSpecificContentTypeRequest(stream);
            request.File.Filename = "image.png";
            Assert204(await GetFormDataFile(host).UploadFileSpecificContentTypeAsync(request));
        });

        [SpectorTest]
        public Task UploadFileSpecificContentTypeConvFromBinaryData() => Test(async (host) =>
        {
            var request = new UploadFileSpecificContentTypeRequest(BinaryData.FromBytes(File.ReadAllBytes(SamplePngPath)));
            request.File.Filename = "image.png";
            Assert204(await GetFormDataFile(host).UploadFileSpecificContentTypeAsync(request));
        });

        // (model: UploadFileRequiredFilenameRequest, 3 ctors)

        [SpectorTest]
        public Task UploadFileRequiredFilenameProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            await using var stream = File.OpenRead(SamplePngPath);
            content.Add("file", new FileBinaryContent(stream, "image/png") { Filename = "image.png" });

            Assert204(await GetFormDataFile(host).UploadFileRequiredFilenameAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task UploadFileRequiredFilenameConvFromPath() => Test(async (host) =>
        {
            var request = new UploadFileRequiredFilenameRequest("image.png", SamplePngPath);
            Assert204(await GetFormDataFile(host).UploadFileRequiredFilenameAsync(request));
        });

        [SpectorTest]
        public Task UploadFileRequiredFilenameConvFromStream() => Test(async (host) =>
        {
            await using var stream = File.OpenRead(SamplePngPath);
            var request = new UploadFileRequiredFilenameRequest("image.png", stream);
            Assert204(await GetFormDataFile(host).UploadFileRequiredFilenameAsync(request));
        });

        [SpectorTest]
        public Task UploadFileRequiredFilenameConvFromBinaryData() => Test(async (host) =>
        {
            var request = new UploadFileRequiredFilenameRequest("image.png", BinaryData.FromBytes(File.ReadAllBytes(SamplePngPath)));
            Assert204(await GetFormDataFile(host).UploadFileRequiredFilenameAsync(request));
        });

        [SpectorTest]
        public Task UploadFileArrayProtocol() => Test(async (host) =>
        {
            using MultiPartFormContent content = new();
            await using var png1 = File.OpenRead(SamplePngPath);
            await using var png2 = File.OpenRead(SamplePngPath);
            content.Add("files", new FileBinaryContent(png1, "image/png") { Filename = "image1.png" });
            content.Add("files", new FileBinaryContent(png2, "image/png") { Filename = "image2.png" });

            Assert204(await GetFormDataFile(host).UploadFileArrayAsync(RequestContent.Create(content), content.MediaType));
        });

        [SpectorTest]
        public Task UploadFileArrayConv() => Test(async (host) =>
        {
            var files = new[]
            {
                new FileBinaryContent(SamplePngPath, "image/png") { Filename = "image1.png" },
                new FileBinaryContent(SamplePngPath, "image/png") { Filename = "image2.png" },
            };
            Assert204(await GetFormDataFile(host).UploadFileArrayAsync(new UploadFileArrayRequest(files)));
        });
    }
#pragma warning restore SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
}
