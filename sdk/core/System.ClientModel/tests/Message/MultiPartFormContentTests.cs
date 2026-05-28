// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.ClientModel.Primitives;
using ClientModel.Tests.Internal;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Message;

#pragma warning disable SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates.

internal class MultiPartFormContentTests : SyncAsyncTestBase
{
    private string _testDirectory = null!;

    public MultiPartFormContentTests(bool isAsync) : base(isAsync)
    {
    }

    [SetUp]
    public void CreateTestDirectory()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), $"scm-mpfc-{Guid.NewGuid():N}");
        Directory.CreateDirectory(_testDirectory);
    }

    [TearDown]
    public void DeleteTestDirectory()
    {
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, recursive: true);
        }
    }

    [Test]
    public void Ctor_Default_GeneratesBoundary()
    {
        using MultiPartFormContent content = new();

        string boundary = GetBoundary(content);
        Assert.IsTrue(Guid.TryParseExact(boundary, "D", out _),
            $"Expected default boundary to be a GUID in 'D' format, but got '{boundary}'.");
        StringAssert.StartsWith("multipart/form-data", content.MediaType);
    }

    [Test]
    public void Ctor_Default_GeneratesUniqueBoundaries()
    {
        HashSet<string> boundaries = new();
        for (int i = 0; i < 32; i++)
        {
            using MultiPartFormContent content = new();
            Assert.IsTrue(boundaries.Add(GetBoundary(content)));
        }
    }

    [Test]
    public void Ctor_Default_BoundaryUsesRfc2046Chars()
    {
        const string Rfc2046BoundaryChars = "0123456789ABCDEFabcdefghijklmnopqrstuvwxyzGHIJKLMNOPQRSTUVWXYZ'()+_,-./:=? ";
        for (int i = 0; i < 16; i++)
        {
            using MultiPartFormContent content = new();
            string boundary = GetBoundary(content);
            Assert.IsTrue(boundary.Length >= 1 && boundary.Length <= 70,
                $"Boundary length {boundary.Length} outside RFC 2046 1-70 char range.");
            Assert.AreNotEqual(' ', boundary[boundary.Length - 1],
                "Boundary must not end with SPACE per RFC 2046.");
            foreach (char c in boundary)
            {
                Assert.IsTrue(
                    Rfc2046BoundaryChars.IndexOf(c) >= 0,
                    $"Boundary character '{c}' not in RFC 2046 bchars alphabet.");
            }
        }
    }

    [Test]
    [Timeout(5_000)]
    public void Ctor_Default_GeneratesUniqueBoundaries_Concurrently()
    {
        const int threadCount = 4;
        const int perThread = 32;

        using Barrier startGate = new(threadCount);
        ConcurrentBag<string> boundaries = new();
        Task[] workers = new Task[threadCount];

        for (int t = 0; t < threadCount; t++)
        {
            workers[t] = Task.Run(() =>
            {
                // Maximize the contention window by making every worker start
                // its loop at the same instant.
                startGate.SignalAndWait();
                for (int i = 0; i < perThread; i++)
                {
                    using MultiPartFormContent content = new();
                    boundaries.Add(GetBoundary(content));
                }
            });
        }

        Task.WaitAll(workers);

        Assert.AreEqual(threadCount * perThread, boundaries.Count);

        HashSet<string> unique = new();
        foreach (string boundary in boundaries)
        {
            Assert.IsTrue(Guid.TryParseExact(boundary, "D", out _),
                $"Expected default boundary to be a GUID in 'D' format, but got '{boundary}'.");
            Assert.IsTrue(unique.Add(boundary), $"Duplicate boundary generated under concurrency: {boundary}");
        }
    }

    [Test]
    public void Add_File_Throws_WhenNameNull()
    {
        using MultiPartFormContent content = new();
        using FileBinaryContent file = new(BinaryData.FromBytes(new byte[] { 1 }));

        Assert.Throws<ArgumentNullException>(() => content.Add(null!, file));
    }

    [Test]
    public void Add_File_Throws_WhenNameEmpty()
    {
        using MultiPartFormContent content = new();
        using FileBinaryContent file = new(BinaryData.FromBytes(new byte[] { 1 }));

        Assert.Throws<ArgumentException>(() => content.Add(string.Empty, file));
    }

    [Test]
    public void Add_File_Throws_WhenFileContentNull()
    {
        using MultiPartFormContent content = new();

        Assert.Throws<ArgumentNullException>(() => content.Add("file", (FileBinaryContent)null!));
    }

    [Test]
    public async Task Add_File_ProducesPartWithMediaTypeAndFilename()
    {
        byte[] bytes = CreateBytes(64);
        string path = CreateTempFile(bytes);

        using MultiPartFormContent content = new();
        using FileBinaryContent file = new(path, "image/png");
        content.Add("upload", file);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("upload", part.Name);
        Assert.AreEqual(Path.GetFileName(path), part.FileName);
        Assert.AreEqual("image/png", part.ContentType?.MediaType);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public async Task Add_File_FromBinaryData_HasNoFilename()
    {
        byte[] bytes = CreateBytes(16);
        using MultiPartFormContent content = new();
        using FileBinaryContent file = new(BinaryData.FromBytes(bytes), "application/octet-stream");

        content.Add("blob", file);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("blob", part.Name);
        Assert.IsNull(part.FileName);
        Assert.AreEqual("application/octet-stream", part.ContentType?.MediaType);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public async Task Add_File_NoMediaType_OmitsContentTypeHeader()
    {
        byte[] bytes = CreateBytes(16);
        using MultiPartFormContent content = new();
        using FileBinaryContent file = new(BinaryData.FromBytes(bytes), mediaType: null);

        content.Add("blob", file);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("blob", part.Name);
        Assert.IsNull(part.ContentType);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public void Add_File_TransfersOwnership_DisposingMultipartDisposesFile()
    {
        MemoryStream source = new(CreateBytes(8));
        FileBinaryContent file = new(source);

        MultiPartFormContent content = new();
        content.Add("file", file);

        content.Dispose();

        // Underlying stream is disposed when the multipart is disposed.
        Assert.Throws<ObjectDisposedException>(() => _ = source.Length);
    }

    [Test]
    public void Add_Model_Throws_WhenNameNull()
    {
        using MultiPartFormContent content = new();
        MockPersistableModel model = new(1, "v");

        Assert.Throws<ArgumentNullException>(() => content.Add<MockPersistableModel>(null!, model));
    }

    [Test]
    public void Add_Model_Throws_WhenNameEmpty()
    {
        using MultiPartFormContent content = new();
        MockPersistableModel model = new(1, "v");

        Assert.Throws<ArgumentException>(() => content.Add<MockPersistableModel>(string.Empty, model));
    }

    [Test]
    public void Add_Model_Throws_WhenModelNull()
    {
        using MultiPartFormContent content = new();

        Assert.Throws<ArgumentNullException>(
            () => content.Add<MockPersistableModel>("model", null!));
    }

    [Test]
    public void Add_Model_Full_Throws_WhenMediaTypeEmpty()
    {
        using MultiPartFormContent content = new();
        MockPersistableModel model = new(1, "v");

        Assert.Throws<ArgumentException>(
            () => content.Add("m", model, EmptyTestContext.Instance, ModelReaderWriterOptions.Json, mediaType: string.Empty));
    }

    [Test]
    public async Task Add_Model_DefaultsToApplicationJson()
    {
        using MultiPartFormContent content = new();
        MockPersistableModel model = new(42, "hello");
        content.Add("model", model);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("model", part.Name);
        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual(model.SerializedValue, Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public void Add_BinaryData_Throws_WhenNameNull()
    {
        using MultiPartFormContent content = new();
        BinaryData data = BinaryData.FromBytes(new byte[] { 1 });

        Assert.Throws<ArgumentNullException>(() => content.Add(null!, data));
    }

    [Test]
    public void Add_BinaryData_Throws_WhenNameEmpty()
    {
        using MultiPartFormContent content = new();
        BinaryData data = BinaryData.FromBytes(new byte[] { 1 });

        Assert.Throws<ArgumentException>(() => content.Add(string.Empty, data));
    }

    [Test]
    public void Add_BinaryData_Throws_WhenContentNull()
    {
        using MultiPartFormContent content = new();

        Assert.Throws<ArgumentNullException>(() => content.Add("blob", (BinaryData)null!));
    }

    [Test]
    public async Task Add_BinaryData_UsesMediaTypeFromBinaryData()
    {
        byte[] bytes = CreateBytes(32);
        BinaryData data = BinaryData.FromBytes(bytes).WithMediaType("application/x-binary");

        using MultiPartFormContent content = new();
        content.Add("blob", data);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("blob", part.Name);
        Assert.AreEqual("application/x-binary", part.ContentType?.MediaType);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public async Task Add_BinaryData_NoMediaType_OmitsContentTypeHeader()
    {
        byte[] bytes = CreateBytes(32);
        BinaryData data = BinaryData.FromBytes(bytes);
        Assert.IsNull(data.MediaType);

        using MultiPartFormContent content = new();
        content.Add("blob", data);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.IsNull(part.ContentType);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public void Add_Bytes_Throws_WhenNameNull()
    {
        using MultiPartFormContent content = new();

        Assert.Throws<ArgumentNullException>(() => content.Add(null!, new byte[] { 1 }));
    }

    [Test]
    public void Add_Bytes_Throws_WhenNameEmpty()
    {
        using MultiPartFormContent content = new();

        Assert.Throws<ArgumentException>(() => content.Add(string.Empty, new byte[] { 1 }));
    }

    [Test]
    public void Add_Bytes_Throws_WhenContentNull()
    {
        using MultiPartFormContent content = new();

        Assert.Throws<ArgumentNullException>(() => content.Add("blob", (byte[])null!));
    }

    [Test]
    public async Task Add_Bytes_DefaultsToOctetStream()
    {
        byte[] bytes = CreateBytes(48);

        using MultiPartFormContent content = new();
        content.Add("blob", bytes);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/octet-stream", part.ContentType?.MediaType);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public async Task Add_Bytes_HonorsCustomMediaType()
    {
        byte[] bytes = { 0xFF, 0xD8, 0xFF };

        using MultiPartFormContent content = new();
        content.Add("blob", bytes, "image/jpeg");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("image/jpeg", part.ContentType?.MediaType);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public void Add_String_Throws_WhenNameNull()
    {
        using MultiPartFormContent content = new();

        Assert.Throws<ArgumentNullException>(() => content.Add(null!, "value"));
    }

    [Test]
    public void Add_String_Throws_WhenNameEmpty()
    {
        using MultiPartFormContent content = new();

        Assert.Throws<ArgumentException>(() => content.Add(string.Empty, "value"));
    }

    [Test]
    public void Add_String_Throws_WhenContentNull()
    {
        using MultiPartFormContent content = new();

        Assert.Throws<ArgumentNullException>(() => content.Add("k", (string)null!));
    }

    [Test]
    public async Task Add_String_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("greeting", "hello \"world\"", "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("\"hello \\u0022world\\u0022\"", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_String_TextPlain_WritesValueVerbatim()
    {
        using MultiPartFormContent content = new();
        content.Add("greeting", "hello \"world\"", "text/plain");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("hello \"world\"", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_String_NullMediaType_FallsBackToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("greeting", "verbatim", mediaType: null);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("verbatim", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_String_EmptyContent_IsAllowed()
    {
        using MultiPartFormContent content = new();
        content.Add("greeting", string.Empty);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual(string.Empty, Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Int_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 42);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("42", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Int_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 42, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("42", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Int_TextPlain_UsesInvariantCulture()
    {
        using MultiPartFormContent content = new();
        content.Add("n", -1234, mediaType: "text/plain");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("-1234", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Long_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", long.MaxValue);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("9223372036854775807", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Long_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", long.MaxValue, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("9223372036854775807", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Float_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 1.5f);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual(1.5f, float.Parse(Encoding.UTF8.GetString(part.Body), CultureInfo.InvariantCulture));
    }

    [Test]
    public async Task Add_Float_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 1.5f, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual(1.5f, float.Parse(Encoding.UTF8.GetString(part.Body), CultureInfo.InvariantCulture));
    }

    [Test]
    public async Task Add_Double_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 2.5d);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("2.5", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Double_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 2.5d, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("2.5", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Float_TextPlain_UsesInvariantCulture()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 1.5f, mediaType: "text/plain");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        // Round-trip parses to the original value.
        Assert.AreEqual(1.5f, float.Parse(Encoding.UTF8.GetString(part.Body), CultureInfo.InvariantCulture));
    }

    [Test]
    public async Task Add_Double_TextPlain_UsesInvariantCulture()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 1.5d, mediaType: "text/plain");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("1.5", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Decimal_TextPlain_UsesInvariantCulture()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 1234.5m, mediaType: "text/plain");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("1234.5", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Decimal_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 0.1m);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("0.1", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Decimal_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 0.1m, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("0.1", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Bool_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", true);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("true", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Bool_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", false, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("false", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Byte_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", (byte)200);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("200", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Byte_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", (byte)200, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("200", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_SByte_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", (sbyte)-100);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("-100", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_SByte_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", (sbyte)-100, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("-100", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Char_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 'A');

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("A", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Char_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 'A', mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("\"A\"", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Short_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", (short)-32000);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("-32000", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Short_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", (short)-32000, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("-32000", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_UShort_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", (ushort)60000);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("60000", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_UShort_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", (ushort)60000, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("60000", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_UInt_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 4000000000u);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("4000000000", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_UInt_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 4000000000u, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("4000000000", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_ULong_DefaultsToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", ulong.MaxValue);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("18446744073709551615", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_ULong_ApplicationJson_JsonEncodesValue()
    {
        using MultiPartFormContent content = new();
        content.Add("n", ulong.MaxValue, mediaType: "application/json");

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual("18446744073709551615", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task Add_Numeric_NullMediaType_FallsBackToTextPlain()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 7, mediaType: null);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("7", Encoding.UTF8.GetString(part.Body));
    }

    [TestCase(null, typeof(ArgumentNullException))]
    [TestCase("", typeof(ArgumentException))]
    public void Add_Numeric_Throws_WhenNameInvalid(string? name, Type expected)
    {
        using MultiPartFormContent content = new();

        Assert.Throws(expected, () => content.Add(name!, true));
        Assert.Throws(expected, () => content.Add(name!, (byte)1));
        Assert.Throws(expected, () => content.Add(name!, (sbyte)1));
        Assert.Throws(expected, () => content.Add(name!, 'a'));
        Assert.Throws(expected, () => content.Add(name!, (short)1));
        Assert.Throws(expected, () => content.Add(name!, (ushort)1));
        Assert.Throws(expected, () => content.Add(name!, 1));
        Assert.Throws(expected, () => content.Add(name!, 1u));
        Assert.Throws(expected, () => content.Add(name!, 1L));
        Assert.Throws(expected, () => content.Add(name!, 1uL));
        Assert.Throws(expected, () => content.Add(name!, 1f));
        Assert.Throws(expected, () => content.Add(name!, 1d));
        Assert.Throws(expected, () => content.Add(name!, 1m));
    }

    [Test]
    public void WriteTo_Throws_WhenStreamIsNull()
    {
        using MultiPartFormContent content = new();
        Assert.Throws<ArgumentNullException>(() => content.WriteTo(null!));
    }

    [Test]
    public void WriteToAsync_Throws_WhenStreamIsNull()
    {
        using MultiPartFormContent content = new();
        Assert.ThrowsAsync<ArgumentNullException>(() => content.WriteToAsync(null!));
    }

    [Test]
    public async Task WriteTo_PreservesPartOrderAndStructure()
    {
        using MultiPartFormContent content = new();
        content.Add("first", "a", "text/plain");
        content.Add("second", new byte[] { 0xAB, 0xCD }, "application/octet-stream");
        content.Add("third", 42);

        ParsedMultipart parsed = await ParseAsync(content);

        Assert.AreEqual(3, parsed.Parts.Count);
        Assert.AreEqual("first", parsed.Parts[0].Name);
        Assert.AreEqual("second", parsed.Parts[1].Name);
        Assert.AreEqual("third", parsed.Parts[2].Name);

        Assert.AreEqual("a", Encoding.UTF8.GetString(parsed.Parts[0].Body));
        Assert.AreEqual(new byte[] { 0xAB, 0xCD }, parsed.Parts[1].Body);
        Assert.AreEqual("42", Encoding.UTF8.GetString(parsed.Parts[2].Body));
    }

    [Test]
    public async Task WriteTo_AllowsDuplicatePartNames()
    {
        // multipart/form-data permits multiple parts sharing a name (e.g. multi-file uploads).
        using MultiPartFormContent content = new();
        content.Add("file", new byte[] { 1 }, "application/octet-stream");
        content.Add("file", new byte[] { 2 }, "application/octet-stream");

        ParsedMultipart parsed = await ParseAsync(content);

        Assert.AreEqual(2, parsed.Parts.Count);
        Assert.AreEqual("file", parsed.Parts[0].Name);
        Assert.AreEqual("file", parsed.Parts[1].Name);
        Assert.AreEqual(new byte[] { 1 }, parsed.Parts[0].Body);
        Assert.AreEqual(new byte[] { 2 }, parsed.Parts[1].Body);
    }

    [Test]
    public async Task WriteTo_FileArray_ProducesOnePartPerFile()
    {
        // Multi-file upload: an array of files is represented as repeated
        // parts sharing the same form field name.
        byte[] bytes1 = CreateBytes(64, seed: 1);
        byte[] bytes2 = CreateBytes(64, seed: 2);
        byte[] bytes3 = CreateBytes(64, seed: 3);
        string path1 = CreateTempFile(bytes1);
        string path2 = CreateTempFile(bytes2);
        string path3 = CreateTempFile(bytes3);

        using FileBinaryContent file1 = new(path1, "image/png");
        using FileBinaryContent file2 = new(path2, "image/jpeg");
        using FileBinaryContent file3 = new(BinaryData.FromBytes(bytes3), "application/octet-stream");

        using MultiPartFormContent content = new();
        foreach (FileBinaryContent file in new[] { file1, file2, file3 })
        {
            content.Add("files", file);
        }

        ParsedMultipart parsed = await ParseAsync(content);

        Assert.AreEqual(3, parsed.Parts.Count);
        Assert.IsTrue(parsed.Parts.All(p => p.Name == "files"));

        Assert.AreEqual("image/png", parsed.Parts[0].ContentType?.MediaType);
        Assert.AreEqual(Path.GetFileName(path1), parsed.Parts[0].FileName);
        Assert.AreEqual(bytes1, parsed.Parts[0].Body);

        Assert.AreEqual("image/jpeg", parsed.Parts[1].ContentType?.MediaType);
        Assert.AreEqual(Path.GetFileName(path2), parsed.Parts[1].FileName);
        Assert.AreEqual(bytes2, parsed.Parts[1].Body);

        // BinaryData-backed file has no Filename.
        Assert.AreEqual("application/octet-stream", parsed.Parts[2].ContentType?.MediaType);
        Assert.IsNull(parsed.Parts[2].FileName);
        Assert.AreEqual(bytes3, parsed.Parts[2].Body);
    }

    [Test]
    public async Task WriteTo_ModelArray_ProducesOnePartPerModel()
    {
        // Batch submission: an array of models is represented as repeated
        // parts sharing the same form field name.
        MockPersistableModel[] models =
        {
            new(1, "first"),
            new(2, "second"),
            new(3, "third"),
        };

        using MultiPartFormContent content = new();
        foreach (MockPersistableModel model in models)
        {
            content.Add("items", model);
        }

        ParsedMultipart parsed = await ParseAsync(content);

        Assert.AreEqual(3, parsed.Parts.Count);
        for (int i = 0; i < models.Length; i++)
        {
            ParsedPart part = parsed.Parts[i];
            Assert.AreEqual("items", part.Name);
            Assert.AreEqual("application/json", part.ContentType?.MediaType);
            Assert.AreEqual(models[i].SerializedValue, Encoding.UTF8.GetString(part.Body));
        }
    }

    [Test]
    public async Task Add_JsonModelList_ProducesSingleJsonArrayPart()
    {
        // A model that is itself a collection (JsonModelList<T>) is added as
        // a single part. The serialized body is a JSON array containing each
        // item's JSON representation.
        JsonModelList<JsonItem> list = new()
        {
            new() { Id = 1, Name = "first" },
            new() { Id = 2, Name = "second" },
            new() { Id = 3, Name = "third" },
        };

        using MultiPartFormContent content = new();
        content.Add("items", list);

        ParsedPart part = (await ParseAsync(content)).Parts.Single();

        Assert.AreEqual("items", part.Name);
        Assert.AreEqual("application/json", part.ContentType?.MediaType);

        const string expected =
            "[" +
            "{\"id\":1,\"name\":\"first\"}," +
            "{\"id\":2,\"name\":\"second\"}," +
            "{\"id\":3,\"name\":\"third\"}" +
            "]";
        Assert.AreEqual(expected, Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public async Task WriteTo_MixedArrays_PreserveInterleavedOrder()
    {
        // Two arrays under different names interleaved with each other —
        // verifies insertion order is preserved across the whole payload,
        // not just within a single name.
        byte[] fileBytesA = CreateBytes(16, seed: 7);
        byte[] fileBytesB = CreateBytes(16, seed: 8);

        using FileBinaryContent fileA = new(BinaryData.FromBytes(fileBytesA), "application/octet-stream");
        using FileBinaryContent fileB = new(BinaryData.FromBytes(fileBytesB), "application/octet-stream");
        MockPersistableModel modelA = new(10, "a");
        MockPersistableModel modelB = new(20, "b");

        using MultiPartFormContent content = new();
        content.Add("files", fileA);
        content.Add("models", modelA);
        content.Add("files", fileB);
        content.Add("models", modelB);

        ParsedMultipart parsed = await ParseAsync(content);

        Assert.AreEqual(4, parsed.Parts.Count);
        Assert.AreEqual("files", parsed.Parts[0].Name);
        Assert.AreEqual("models", parsed.Parts[1].Name);
        Assert.AreEqual("files", parsed.Parts[2].Name);
        Assert.AreEqual("models", parsed.Parts[3].Name);

        Assert.AreEqual(fileBytesA, parsed.Parts[0].Body);
        Assert.AreEqual(modelA.SerializedValue, Encoding.UTF8.GetString(parsed.Parts[1].Body));
        Assert.AreEqual(fileBytesB, parsed.Parts[2].Body);
        Assert.AreEqual(modelB.SerializedValue, Encoding.UTF8.GetString(parsed.Parts[3].Body));
    }

    [Test]
    public async Task WriteTo_BodyUsesBoundaryFromMediaType()
    {
        using MultiPartFormContent content = new();
        content.Add("k", "v", "text/plain");

        string boundary = GetBoundary(content);
        byte[] bytes = await WriteToBytesAsync(content);
        string body = Encoding.UTF8.GetString(bytes);

        StringAssert.StartsWith($"--{boundary}\r\n", body);
        StringAssert.EndsWith($"--{boundary}--\r\n", body);
    }

    [Test]
    public async Task WriteTo_CanBeCalledMultipleTimes()
    {
        using MultiPartFormContent content = new();
        content.Add("k", "value", "text/plain");
        content.Add("n", 7);

        byte[] first = await WriteToBytesAsync(content);
        byte[] second = await WriteToBytesAsync(content);

        Assert.AreEqual(first, second);
    }

    [Test]
    public async Task WriteTo_FilePart_IsRereadable()
    {
        // Buffered (BinaryData-backed) file part.
        byte[] bytes = CreateBytes(64);

        using MultiPartFormContent content = new();
        using FileBinaryContent file = new(BinaryData.FromBytes(bytes), "application/octet-stream");
        content.Add("file", file);

        byte[] first = await WriteToBytesAsync(content);
        byte[] second = await WriteToBytesAsync(content);

        Assert.AreEqual(first, second);
    }

    [Test]
    public async Task WriteTo_FilePart_FromPath_IsRereadable()
    {
        byte[] bytes = CreateBytes(128);
        string path = CreateTempFile(bytes);

        using MultiPartFormContent content = new();
        using FileBinaryContent file = new(path);
        content.Add("file", file);

        byte[] first = await WriteToBytesAsync(content);
        byte[] second = await WriteToBytesAsync(content);

        Assert.AreEqual(first, second);
    }

    [Test]
    public async Task WriteTo_EmittedPartIsValidJson()
    {
        using MultiPartFormContent content = new();
        content.Add("greeting", "hi", "application/json");
        content.Add("count", 3, mediaType: "application/json");

        ParsedMultipart parsed = await ParseAsync(content);

        // Both parts are application/json and round-trip through Utf8JsonReader.
        foreach (ParsedPart part in parsed.Parts)
        {
            Assert.AreEqual("application/json", part.ContentType?.MediaType);
            Utf8JsonReader reader = new(part.Body);
            Assert.IsTrue(reader.Read());
            Assert.IsFalse(reader.Read()); // single token only
        }
    }

    [Test]
    public async Task TryComputeLength_MatchesWrittenByteCount()
    {
        using MultiPartFormContent content = new();
        content.Add("k", "value", "text/plain");
        content.Add("n", 12345);

        Assert.IsTrue(content.TryComputeLength(out long length));
        byte[] bytes = await WriteToBytesAsync(content);
        Assert.AreEqual(bytes.Length, length);
    }

    [Test]
    public void TryComputeLength_Empty_ReturnsTrue()
    {
        using MultiPartFormContent content = new();

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.GreaterOrEqual(length, 0);
    }

    [Test]
    public void Dispose_IsIdempotent()
    {
        MultiPartFormContent content = new();
        content.Add("k", "v", "text/plain");

        Assert.DoesNotThrow(() => content.Dispose());
        Assert.DoesNotThrow(() => content.Dispose());
    }

    [Test]
    public void Operations_AfterDispose_Throw()
    {
        MultiPartFormContent content = new();
        content.Add("k", "v", "text/plain");
        content.Dispose();

        using MemoryStream destination = new();

        ObjectDisposedException writeEx =
            Assert.Throws<ObjectDisposedException>(() => content.WriteTo(destination))!;
        Assert.AreEqual(nameof(MultiPartFormContent), writeEx.ObjectName);

        ObjectDisposedException writeAsyncEx =
            Assert.ThrowsAsync<ObjectDisposedException>(() => content.WriteToAsync(destination))!;
        Assert.AreEqual(nameof(MultiPartFormContent), writeAsyncEx.ObjectName);
    }

    [Test]
    public void Add_AfterDispose_Throws()
    {
        MultiPartFormContent content = new();
        content.Dispose();

        Assert.Throws<ObjectDisposedException>(() => content.Add("k", "v"));
        Assert.Throws<ObjectDisposedException>(() => content.Add("k", new byte[] { 1 }));
        Assert.Throws<ObjectDisposedException>(() => content.Add("k", BinaryData.FromBytes(new byte[] { 1 })));
        Assert.Throws<ObjectDisposedException>(() => content.Add("k", 1));
        Assert.Throws<ObjectDisposedException>(() => content.Add("k", 1L));
        Assert.Throws<ObjectDisposedException>(() => content.Add("k", 1f));
        Assert.Throws<ObjectDisposedException>(() => content.Add("k", 1d));
        Assert.Throws<ObjectDisposedException>(() => content.Add("k", 1m));

        using FileBinaryContent file = new(BinaryData.FromBytes(new byte[] { 1 }));
        Assert.Throws<ObjectDisposedException>(() => content.Add("k", file));

        Assert.Throws<ObjectDisposedException>(
            () => content.Add<MockPersistableModel>("k", new MockPersistableModel(1, "x")));
    }

    [Test]
    public void Dispose_DisposesContainedFileParts()
    {
        // The multipart owns each added file part; disposing the multipart
        // disposes the contained FileBinaryContent (and its underlying source).
        MemoryStream source = new(CreateBytes(8));
        FileBinaryContent file = new(source);

        MultiPartFormContent content = new();
        content.Add("file", file);
        content.Dispose();

        Assert.Throws<ObjectDisposedException>(() => _ = source.Length);
    }

    [Test]
    public async Task EndToEnd_AllAddOverloads_ProducesExpectedPayload()
    {
        // Exercise every public Add overload, then validate the entire
        // serialized payload byte-for-byte (per-part headers, per-part body,
        // structural skeleton, and total length).
        byte[] fileBytes = CreateBytes(64, seed: 1);
        string filePath = CreateTempFile(fileBytes);
        byte[] binaryDataBytes = CreateBytes(32, seed: 2);
        byte[] rawBytes = CreateBytes(48, seed: 3);
        MockPersistableModel model = new(123, "abcde");
        byte[] modelBytes = Encoding.UTF8.GetBytes(model.SerializedValue);

        using FileBinaryContent file = new(filePath, "image/png");
        using MultiPartFormContent content = new();

        string boundary = GetBoundary(content);
        Assert.IsTrue(Guid.TryParseExact(boundary, "D", out _),
            $"Expected default boundary to be a GUID in 'D' format, but got '{boundary}'.");

        content.Add("filePart", file);
        content.Add("modelFull", model, EmptyTestContext.Instance, ModelReaderWriterOptions.Json, mediaType: "application/json");
        content.Add("modelConv", model);
        content.Add("blob", BinaryData.FromBytes(binaryDataBytes).WithMediaType("application/x-binary"));
        content.Add("bytesDefault", rawBytes);
        content.Add("bytesCustom", rawBytes, "image/jpeg");
        content.Add("textJson", "json-string", "application/json");
        content.Add("textPlain", "plain-string");
        content.Add("intPart", 123);
        content.Add("longPart", 4567890123L);
        content.Add("floatPart", 1.5f);
        content.Add("doublePart", 2.5d);
        content.Add("decimalPart", 3.5m);

        ParsedMultipart parsed = await ParseAsync(content);

        Assert.AreEqual(boundary, parsed.Boundary);
        Assert.AreEqual(13, parsed.Parts.Count);

        AssertPart(parsed.Parts[0], "filePart", "image/png", fileBytes, fileName: Path.GetFileName(filePath));
        AssertPart(parsed.Parts[1], "modelFull", "application/json", modelBytes);
        AssertPart(parsed.Parts[2], "modelConv", "application/json", modelBytes);
        AssertPart(parsed.Parts[3], "blob", "application/x-binary", binaryDataBytes);
        AssertPart(parsed.Parts[4], "bytesDefault", "application/octet-stream", rawBytes);
        AssertPart(parsed.Parts[5], "bytesCustom", "image/jpeg", rawBytes);
        AssertPart(parsed.Parts[6], "textJson", "application/json", Encoding.UTF8.GetBytes("\"json-string\""));
        AssertPart(parsed.Parts[7], "textPlain", "text/plain", Encoding.UTF8.GetBytes("plain-string"));
        AssertPart(parsed.Parts[8], "intPart", "text/plain", Encoding.UTF8.GetBytes("123"));
        AssertPart(parsed.Parts[9], "longPart", "text/plain", Encoding.UTF8.GetBytes("4567890123"));
        AssertPart(parsed.Parts[10], "floatPart", "text/plain", Encoding.UTF8.GetBytes("1.5"));
        AssertPart(parsed.Parts[11], "doublePart", "text/plain", Encoding.UTF8.GetBytes("2.5"));
        AssertPart(parsed.Parts[12], "decimalPart", "text/plain", Encoding.UTF8.GetBytes("3.5"));

        // Skeleton: starts with "--boundary\r\n" and ends with "\r\n--boundary--\r\n".
        // Exactly (parts + 1) "--boundary" markers — one opening per part plus the close.
        byte[] payload = await WriteToBytesAsync(content);
        string body = Encoding.UTF8.GetString(payload);

        StringAssert.StartsWith($"--{boundary}\r\n", body);
        StringAssert.EndsWith($"\r\n--{boundary}--\r\n", body);
        Assert.AreEqual(parsed.Parts.Count + 1, CountOccurrences(body, $"--{boundary}"));

        // TryComputeLength must equal the actual written payload length.
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(payload.Length, length);

        // Re-writing produces identical bytes (no per-call state).
        Assert.AreEqual(payload, await WriteToBytesAsync(content));
    }

    [Test]
    public void CanGetLengthFromBinaryDataPart()
    {
        byte[] bytes = CreateBytes(32);
        BinaryData data = BinaryData.FromBytes(bytes).WithMediaType("application/x-binary");

        using MultiPartFormContent content = new();
        content.Add("blob", data);

        StringAssert.StartsWith("multipart/form-data", content.MediaType);
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.Greater(length, bytes.Length); // payload includes headers and boundary delimiters
    }

    [Test]
    public async Task CanWriteToStreamFromBinaryDataPart()
    {
        byte[] bytes = CreateBytes(32);
        BinaryData data = BinaryData.FromBytes(bytes).WithMediaType("application/x-binary");

        using MultiPartFormContent content = new();
        content.Add("blob", data);

        MemoryStream stream = new();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(length, stream.Position);

        ParsedPart part = ParseParts(stream.ToArray(), GetBoundary(content)).Single();
        Assert.AreEqual("application/x-binary", part.ContentType?.MediaType);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public void CanGetLengthFromModelPart()
    {
        MockPersistableModel model = new(404, "abcde");

        using MultiPartFormContent content = new();
        content.Add("model", model);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.Greater(length, model.SerializedValue.Length);
    }

    [Test]
    public async Task CanWriteToStreamFromModelPart()
    {
        MockPersistableModel model = new(404, "abcde");

        using MultiPartFormContent content = new();
        content.Add("model", model);

        MemoryStream stream = new();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(length, stream.Position);

        ParsedPart part = ParseParts(stream.ToArray(), GetBoundary(content)).Single();
        Assert.AreEqual("application/json", part.ContentType?.MediaType);
        Assert.AreEqual(model.SerializedValue, Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public void CanGetLengthFromBytesPart()
    {
        byte[] bytes = CreateBytes(48);

        using MultiPartFormContent content = new();
        content.Add("blob", bytes);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.Greater(length, bytes.Length);
    }

    [Test]
    public async Task CanWriteToStreamFromBytesPart()
    {
        byte[] bytes = CreateBytes(48);

        using MultiPartFormContent content = new();
        content.Add("blob", bytes);

        MemoryStream stream = new();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(length, stream.Position);

        ParsedPart part = ParseParts(stream.ToArray(), GetBoundary(content)).Single();
        Assert.AreEqual("application/octet-stream", part.ContentType?.MediaType);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public void CanGetLengthFromStringPart()
    {
        using MultiPartFormContent content = new();
        content.Add("greeting", "hello");

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.Greater(length, "hello".Length);
    }

    [Test]
    public async Task CanWriteToStreamFromStringPart()
    {
        using MultiPartFormContent content = new();
        content.Add("greeting", "hello", "text/plain");

        MemoryStream stream = new();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(length, stream.Position);

        ParsedPart part = ParseParts(stream.ToArray(), GetBoundary(content)).Single();
        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("hello", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public void CanGetLengthFromIntPart()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 42);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.Greater(length, 0);
    }

    [Test]
    public async Task CanWriteToStreamFromIntPart()
    {
        using MultiPartFormContent content = new();
        content.Add("n", 42);

        MemoryStream stream = new();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(length, stream.Position);

        ParsedPart part = ParseParts(stream.ToArray(), GetBoundary(content)).Single();
        Assert.AreEqual("text/plain", part.ContentType?.MediaType);
        Assert.AreEqual("42", Encoding.UTF8.GetString(part.Body));
    }

    [Test]
    public void CanGetLengthFromFilePart()
    {
        byte[] bytes = CreateBytes(128);
        string path = CreateTempFile(bytes);

        using MultiPartFormContent content = new();
        using FileBinaryContent file = new(path, "image/png");
        content.Add("upload", file);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.Greater(length, bytes.Length);
    }

    [Test]
    public async Task CanWriteToStreamFromFilePart()
    {
        byte[] bytes = CreateBytes(128);
        string path = CreateTempFile(bytes);

        using MultiPartFormContent content = new();
        using FileBinaryContent file = new(path, "image/png");
        content.Add("upload", file);

        MemoryStream stream = new();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(length, stream.Position);

        ParsedPart part = ParseParts(stream.ToArray(), GetBoundary(content)).Single();
        Assert.AreEqual("image/png", part.ContentType?.MediaType);
        Assert.AreEqual(Path.GetFileName(path), part.FileName);
        Assert.AreEqual(bytes, part.Body);
    }

    [Test]
    public void MultiPartFormContentWriteToCanBeCancelled()
    {
        // A pre-canceled token must be observed at WriteTo entry on every
        // TFM. The underlying BCL MultipartContent does not throw for
        // fully-buffered parts on the sync path, and on netstandard2.0 the
        // token cannot be passed to the BCL at all.
        using MultiPartFormContent content = new();
        content.Add("k", "value", "text/plain");

        using MemoryStream destination = new();
        CancellationTokenSource cts = new();
        cts.Cancel();

        Assert.Throws<OperationCanceledException>(() => content.WriteTo(destination, cts.Token));
    }

    [Test]
    public void MultiPartFormContentWriteToAsyncCanBeCancelled()
    {
        using MultiPartFormContent content = new();
        content.Add("k", "value", "text/plain");

        using MemoryStream destination = new();
        CancellationTokenSource cts = new();
        cts.Cancel();

        Assert.ThrowsAsync<OperationCanceledException>(() => content.WriteToAsync(destination, cts.Token));
    }

    [Test]
    [Timeout(60_000)]
    public async Task WriteTo_LargePayload_RoundTripsAndComputesLength()
    {
        const int largeFileSize = 10 * 1024 * 1024; // 10 MB
        const int largeBytesSize = 5 * 1024 * 1024; // 5 MB
        const int largeBinaryDataSize = 5 * 1024 * 1024; // 5 MB

        byte[] fileBytes = CreateBytes(largeFileSize, seed: 11);
        byte[] rawBytes = CreateBytes(largeBytesSize, seed: 22);
        byte[] binaryBytes = CreateBytes(largeBinaryDataSize, seed: 33);

        string filePath = CreateTempFile(fileBytes);
        string fileHash = Sha256(fileBytes);
        string rawHash = Sha256(rawBytes);
        string binaryHash = Sha256(binaryBytes);

        using FileBinaryContent file = new(filePath, "application/octet-stream");
        using MultiPartFormContent content = new();
        content.Add("file", file);
        content.Add("blob", BinaryData.FromBytes(binaryBytes).WithMediaType("application/x-binary"));
        content.Add("bytes", rawBytes);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.GreaterOrEqual(length, (long)(largeFileSize + largeBytesSize + largeBinaryDataSize));

        using MemoryStream destination = new(capacity: (int)length);
        await content.WriteToSyncOrAsync(destination, CancellationToken.None, IsAsync);

        Assert.AreEqual(length, destination.Position);

        string boundary = GetBoundary(content);
        ParsedMultipart parsed = new(boundary, ParseParts(destination.ToArray(), boundary));
        Assert.AreEqual(3, parsed.Parts.Count);

        Assert.AreEqual("file", parsed.Parts[0].Name);
        Assert.AreEqual(Path.GetFileName(filePath), parsed.Parts[0].FileName);
        Assert.AreEqual(fileBytes.Length, parsed.Parts[0].Body.Length);
        Assert.AreEqual(fileHash, Sha256(parsed.Parts[0].Body));

        Assert.AreEqual("blob", parsed.Parts[1].Name);
        Assert.AreEqual(binaryBytes.Length, parsed.Parts[1].Body.Length);
        Assert.AreEqual(binaryHash, Sha256(parsed.Parts[1].Body));

        Assert.AreEqual("bytes", parsed.Parts[2].Name);
        Assert.AreEqual(rawBytes.Length, parsed.Parts[2].Body.Length);
        Assert.AreEqual(rawHash, Sha256(parsed.Parts[2].Body));

        // Re-write produces the same bytes
        using MemoryStream second = new(capacity: (int)length);
        await content.WriteToSyncOrAsync(second, CancellationToken.None, IsAsync);
        Assert.AreEqual(destination.Length, second.Length);
        Assert.AreEqual(Sha256(destination.ToArray()), Sha256(second.ToArray()));
    }

    private static string Sha256(byte[] bytes)
    {
        using System.Security.Cryptography.SHA256 sha = System.Security.Cryptography.SHA256.Create();
        return Convert.ToBase64String(sha.ComputeHash(bytes));
    }

    private static int CountOccurrences(string haystack, string needle)
    {
        int count = 0;
        int idx = 0;
        while ((idx = haystack.IndexOf(needle, idx, StringComparison.Ordinal)) >= 0)
        {
            count++;
            idx += needle.Length;
        }
        return count;
    }

    private static void AssertPart(
        ParsedPart part,
        string expectedName,
        string? expectedMediaType,
        byte[] expectedBody,
        string? fileName = null)
    {
        Assert.AreEqual(expectedName, part.Name);
        Assert.AreEqual(expectedMediaType, part.ContentType?.MediaType);
        Assert.AreEqual(fileName, part.FileName);
        Assert.AreEqual(expectedBody, part.Body);
    }

    private static byte[] CreateBytes(int size, int seed = 100)
    {
        byte[] bytes = new byte[size];
        new Random(seed).NextBytes(bytes);
        return bytes;
    }

    private string CreateTempFile(byte[] bytes)
    {
        string path = Path.Combine(_testDirectory, $"{Guid.NewGuid():N}.bin");
        File.WriteAllBytes(path, bytes);
        return path;
    }

    private static string GetBoundary(MultiPartFormContent content)
    {
        Assert.IsNotNull(content.MediaType);
        MediaTypeHeaderValue parsed = MediaTypeHeaderValue.Parse(content.MediaType!);
        NameValueHeaderValue boundary = parsed.Parameters.Single(p => p.Name == "boundary");
        return boundary.Value!.Trim('"');
    }

    private async Task<byte[]> WriteToBytesAsync(MultiPartFormContent content)
    {
        using MemoryStream destination = new();
        await content.WriteToSyncOrAsync(destination, CancellationToken.None, IsAsync);
        return destination.ToArray();
    }

    private async Task<ParsedMultipart> ParseAsync(MultiPartFormContent content)
    {
        string boundary = GetBoundary(content);
        byte[] bytes = await WriteToBytesAsync(content);
        return new ParsedMultipart(boundary, ParseParts(bytes, boundary));
    }

    private static IReadOnlyList<ParsedPart> ParseParts(byte[] bytes, string boundary)
    {
        byte[] marker = Encoding.ASCII.GetBytes("--" + boundary);
        List<int> positions = new();
        for (int i = 0; i <= bytes.Length - marker.Length; i++)
        {
            if (BytesEqual(bytes, i, marker, 0, marker.Length))
            {
                positions.Add(i);
            }
        }

        Assert.GreaterOrEqual(positions.Count, 2, "Multipart payload should have at least open and close delimiters.");

        List<ParsedPart> parts = new();
        // Pairs of (open, next-open-or-close); each pair brackets one part.
        for (int idx = 0; idx < positions.Count - 1; idx++)
        {
            int openMarker = positions[idx];
            int nextMarker = positions[idx + 1];

            // Open: "--<boundary>\r\n" — payload starts after "\r\n".
            int payloadStart = openMarker + marker.Length + 2;
            // Close-of-this-part: "\r\n--<boundary>" — strip the leading "\r\n".
            int payloadEnd = nextMarker - 2;

            if (payloadStart >= payloadEnd)
            {
                continue;
            }

            // Headers are ASCII separated from body by "\r\n\r\n".
            byte[] headerDelimiter = { (byte)'\r', (byte)'\n', (byte)'\r', (byte)'\n' };
            int delimiterIndex = IndexOf(bytes, payloadStart, payloadEnd, headerDelimiter);
            if (delimiterIndex < 0)
            {
                continue;
            }

            string headersBlob = Encoding.ASCII.GetString(bytes, payloadStart, delimiterIndex - payloadStart);
            int bodyStart = delimiterIndex + headerDelimiter.Length;
            int bodyLength = payloadEnd - bodyStart;
            byte[] body = new byte[bodyLength];
            Array.Copy(bytes, bodyStart, body, 0, bodyLength);

            ContentDispositionHeaderValue? disposition = null;
            MediaTypeHeaderValue? contentType = null;
            foreach (string line in headersBlob.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                int colon = line.IndexOf(':');
                if (colon < 0)
                {
                    continue;
                }

                string name = line.Substring(0, colon).Trim();
                string value = line.Substring(colon + 1).Trim();

                if (string.Equals(name, "Content-Disposition", StringComparison.OrdinalIgnoreCase))
                {
                    disposition = ContentDispositionHeaderValue.Parse(value);
                }
                else if (string.Equals(name, "Content-Type", StringComparison.OrdinalIgnoreCase))
                {
                    contentType = MediaTypeHeaderValue.Parse(value);
                }
            }

            Assert.IsNotNull(disposition, "Each part must have a Content-Disposition header.");
            parts.Add(new ParsedPart(disposition!, contentType, body));
        }

        return parts;
    }

    private static bool BytesEqual(byte[] a, int aOffset, byte[] b, int bOffset, int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (a[aOffset + i] != b[bOffset + i])
            {
                return false;
            }
        }
        return true;
    }

    private static int IndexOf(byte[] haystack, int start, int end, byte[] needle)
    {
        for (int i = start; i <= end - needle.Length; i++)
        {
            if (BytesEqual(haystack, i, needle, 0, needle.Length))
            {
                return i;
            }
        }
        return -1;
    }

    private sealed class ParsedMultipart
    {
        public ParsedMultipart(string boundary, IReadOnlyList<ParsedPart> parts)
        {
            Boundary = boundary;
            Parts = parts;
        }

        public string Boundary { get; }
        public IReadOnlyList<ParsedPart> Parts { get; }
    }

    private sealed class ParsedPart
    {
        public ParsedPart(ContentDispositionHeaderValue disposition, MediaTypeHeaderValue? contentType, byte[] body)
        {
            ContentDisposition = disposition;
            ContentType = contentType;
            Body = body;
        }

        public ContentDispositionHeaderValue ContentDisposition { get; }
        public MediaTypeHeaderValue? ContentType { get; }
        public byte[] Body { get; }

        public string? Name => ContentDisposition.Name?.Trim('"');
        public string? FileName => ContentDisposition.FileName?.Trim('"');
    }

    // Minimal IJsonModel implementation for use with JsonModelList<T>.
    private sealed class JsonItem : IJsonModel<JsonItem>
    {
        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;

        JsonItem IJsonModel<JsonItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException();

        JsonItem IPersistableModel<JsonItem>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException();

        string IPersistableModel<JsonItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<JsonItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("id", Id);
            writer.WriteString("name", Name);
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<JsonItem>.Write(ModelReaderWriterOptions options)
        {
            using MemoryStream stream = new();
            using (Utf8JsonWriter writer = new(stream))
            {
                ((IJsonModel<JsonItem>)this).Write(writer, options);
            }
            return BinaryData.FromBytes(stream.ToArray());
        }
    }

    private sealed class EmptyTestContext : ModelReaderWriterContext
    {
        public static readonly EmptyTestContext Instance = new();

        private EmptyTestContext() { }
    }
}

#pragma warning restore SCME0004
