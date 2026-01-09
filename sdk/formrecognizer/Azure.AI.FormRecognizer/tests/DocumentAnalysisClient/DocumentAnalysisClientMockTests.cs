// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

using TestFile = Azure.AI.FormRecognizer.Tests.TestFile;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of mock tests for the <see cref="DocumentAnalysisClient"/> class.
    /// </summary>
    public class DocumentAnalysisClientMockTests : ClientTestBase
    {
        private const string FakeGuid = "00000000000000000000000000000000";

        private const string OperationId = "00000000000000000000000000000000/analyzeResults/00000000000000000000000000000000?api-version=2021-09-30-preview";

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClientMockTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DocumentAnalysisClientMockTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a fake <see cref="DocumentAnalysisClient" /> and instruments it to make use of the Azure Core
        /// Test Framework functionalities.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The instrumented <see cref="DocumentAnalysisClient" />.</returns>
        private DocumentAnalysisClient CreateInstrumentedClient(DocumentAnalysisClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new DocumentAnalysisClientOptions();

            var client = new DocumentAnalysisClient(fakeEndpoint, fakeCredential, options);
            return InstrumentClient(client);
        }

        #region Analyze Document

        [Test]
        public async Task AnalyzeDocumentSendsContentType()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream);

            var request = mockTransport.Requests.Single();

            Assert.Multiple(() =>
            {
                Assert.That(request.Headers.TryGetValue("Content-Type", out var contentType), Is.True);
                Assert.That(contentType, Is.EqualTo("application/octet-stream"));
            });
        }

        [Test]
        [TestCase("")]
        [TestCase("en-US")]
        public async Task AnalyzeDocumentSendsUserSpecifiedLocale(string locale)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            var analyzeOptions = new AnalyzeDocumentOptions { Locale = locale };
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"locale={locale}";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        [TestCase("")]
        [TestCase("en-US")]
        public async Task AnalyzeDocumentFromUriSendsUserSpecifiedLocale(string locale)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var uri = new Uri("https://fakeuri.com/");
            var analyzeOptions = new AnalyzeDocumentOptions { Locale = locale };
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, uri, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"locale={locale}";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        [TestCase("1")]
        [TestCase("1-2")]
        public async Task AnalyzeDocumentSendsOnePageArgument(string pages)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            var analyzeOptions = new AnalyzeDocumentOptions { Pages = { pages } };
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"pages={pages}";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        [TestCase("1")]
        [TestCase("1-2")]
        public async Task AnalyzeDocumentFromUriSendsOnePageArgument(string pages)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var uri = new Uri("https://fakeuri.com/");
            var analyzeOptions = new AnalyzeDocumentOptions { Pages = { pages } };
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, uri, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"pages={pages}";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        [TestCase("1", "3")]
        [TestCase("1-2", "3")]
        public async Task AnalyzeDocumentSendsMultiplePageArgument(string page1, string page2)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            var analyzeOptions = new AnalyzeDocumentOptions { Pages = { page1, page2 } };
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"pages={page1}%2C{page2}";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        [TestCase("1", "3")]
        [TestCase("1-2", "3")]
        public async Task AnalyzeDocumentFromUriSendsMultiplePageArgument(string page1, string page2)
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var uri = new Uri("https://fakeuri.com/");
            var analyzeOptions = new AnalyzeDocumentOptions { Pages = { page1, page2 } };
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, uri, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"pages={page1}%2C{page2}";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        public async Task AnalyzeDocumentSendsSingleFeature()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            var analyzeOptions = new AnalyzeDocumentOptions { Features = { DocumentAnalysisFeature.Formulas } };
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"features=formulas";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        public async Task AnalyzeDocumentFromUriSendsSingleFeature()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var uri = new Uri("https://fakeuri.com/");
            var analyzeOptions = new AnalyzeDocumentOptions { Features = { DocumentAnalysisFeature.Formulas } };
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, uri, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"features=formulas";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        public async Task AnalyzeDocumentSendsMultipleFeatures()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            using var stream = DocumentAnalysisTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            var analyzeOptions = new AnalyzeDocumentOptions { Features = { DocumentAnalysisFeature.Formulas, DocumentAnalysisFeature.FontStyling } };
            await client.AnalyzeDocumentAsync(WaitUntil.Started, FakeGuid, stream, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"features=formulas%2CstyleFont";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        public async Task AnalyzeDocumentFromUriSendsMultipleFeatures()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var uri = new Uri("https://fakeuri.com/");
            var analyzeOptions = new AnalyzeDocumentOptions { Features = { DocumentAnalysisFeature.Formulas, DocumentAnalysisFeature.FontStyling } };
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, uri, analyzeOptions);

            var requestUriQuery = mockTransport.Requests.Single().Uri.Query;
            var expectedSubstring = $"features=formulas%2CstyleFont";

            Assert.That(requestUriQuery, Does.Contain(expectedSubstring));
        }

        [Test]
        public async Task AnalyzeDocumentFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, new Uri(encodedUriString));
            await client.AnalyzeDocumentFromUriAsync(WaitUntil.Started, FakeGuid, new Uri(decodedUriString));

            Assert.That(mockTransport.Requests, Has.Count.EqualTo(2));

            foreach (var request in mockTransport.Requests)
            {
                var requestBody = GetString(request.Content);

                Assert.That(requestBody, Does.Contain(encodedUriString));
                Assert.That(requestBody.Contains(decodedUriString), Is.False);
            }
        }

        [Test]
        public async Task ClassifyDocumentFromUriEncodesBlankSpaces()
        {
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader(new HttpHeader(Constants.OperationLocationHeader, OperationId));

            var mockTransport = new MockTransport(new[] { mockResponse, mockResponse });
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateInstrumentedClient(options);

            var encodedUriString = "https://fakeuri.com/blank%20space";
            var decodedUriString = "https://fakeuri.com/blank space";

            await client.ClassifyDocumentFromUriAsync(WaitUntil.Started, FakeGuid, new Uri(encodedUriString));
            await client.ClassifyDocumentFromUriAsync(WaitUntil.Started, FakeGuid, new Uri(decodedUriString));

            Assert.That(mockTransport.Requests, Has.Count.EqualTo(2));

            foreach (var request in mockTransport.Requests)
            {
                var requestBody = GetString(request.Content);

                Assert.That(requestBody, Does.Contain(encodedUriString));
                Assert.That(requestBody.Contains(decodedUriString), Is.False);
            }
        }

        [Test]
        public async Task AnalyzeDocumentCanParseDocumentFieldWithBooleanValue()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "status": "succeeded",
                    "analyzeResult": {
                        "documents": [
                            {
                                "fields": {
                                    "booleanField": {
                                        "type": "boolean",
                                        "valueBoolean": true
                                    }
                                }
                            }
                        ]
                    }
                }
                """));

            var mockResponse = new MockResponse(200) { ContentStream = stream };
            var mockTransport = new MockTransport(mockResponse);
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentAnalysisClient(options);
            var operation = new AnalyzeDocumentOperation(OperationId, client);

            await operation.UpdateStatusAsync();

            var result = operation.Value;
            var field = result.Documents[0].Fields["booleanField"];

            Assert.Multiple(() =>
            {
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Boolean));
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.Boolean));
            });

            var fieldValue = field.Value.AsBoolean();

            Assert.That(fieldValue, Is.True);
        }

        [Test]
        public async Task AnalyzeDocumentCanParseDocumentFieldWithAddressValueAndV410Properties()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "status": "succeeded",
                    "analyzeResult": {
                        "documents": [
                            {
                                "fields": {
                                    "addressField": {
                                        "type": "address",
                                        "valueAddress": {
                                            "unit": "unitValue",
                                            "cityDistrict": "cityDistrictValue",
                                            "stateDistrict": "stateDistrictValue",
                                            "suburb": "suburbValue",
                                            "house": "houseValue",
                                            "level": "levelValue"
                                        }
                                    }
                                }
                            }
                        ]
                    }
                }
                """));

            var mockResponse = new MockResponse(200) { ContentStream = stream };
            var mockTransport = new MockTransport(mockResponse);
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentAnalysisClient(options);
            var operation = new AnalyzeDocumentOperation(OperationId, client);

            await operation.UpdateStatusAsync();

            var result = operation.Value;
            var field = result.Documents[0].Fields["addressField"];

            Assert.Multiple(() =>
            {
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Address));
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.Address));
            });

            var fieldValue = field.Value.AsAddress();

            Assert.Multiple(() =>
            {
                Assert.That(fieldValue.Unit, Is.EqualTo("unitValue"));
                Assert.That(fieldValue.CityDistrict, Is.EqualTo("cityDistrictValue"));
                Assert.That(fieldValue.StateDistrict, Is.EqualTo("stateDistrictValue"));
                Assert.That(fieldValue.Suburb, Is.EqualTo("suburbValue"));
                Assert.That(fieldValue.House, Is.EqualTo("houseValue"));
                Assert.That(fieldValue.Level, Is.EqualTo("levelValue"));
            });
        }

        [Test]
        public async Task AnalyzeDocumentCanParseDocumentStyleWithV410Properties()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "status": "succeeded",
                    "analyzeResult": {
                        "styles": [
                            {
                                "similarFontFamily": "similarFontFamilyValue",
                                "fontStyle": "italic",
                                "fontWeight": "bold",
                                "color": "colorValue",
                                "backgroundColor": "backgroundColorValue"
                            }
                        ]
                    }
                }
                """));

            var mockResponse = new MockResponse(200) { ContentStream = stream };
            var mockTransport = new MockTransport(mockResponse);
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentAnalysisClient(options);
            var operation = new AnalyzeDocumentOperation(OperationId, client);

            await operation.UpdateStatusAsync();

            var result = operation.Value;
            var style = result.Styles[0];

            Assert.Multiple(() =>
            {
                Assert.That(style.SimilarFontFamily, Is.EqualTo("similarFontFamilyValue"));
                Assert.That(style.FontStyle, Is.EqualTo(DocumentFontStyle.Italic));
                Assert.That(style.FontWeight, Is.EqualTo(DocumentFontWeight.Bold));
                Assert.That(style.Color, Is.EqualTo("colorValue"));
                Assert.That(style.BackgroundColor, Is.EqualTo("backgroundColorValue"));
            });
        }

        [Test]
        public async Task AnalyzeDocumentCanParseDocumentBarcode()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "status": "succeeded",
                    "analyzeResult": {
                        "pages": [
                            {
                                "barcodes": [
                                    {
                                        "kind": "QRCode",
                                        "value": "barcodeValue",
                                        "polygon": [1, 2, 3, 4, 5, 6, 7, 8],
                                        "span": {
                                            "offset": 10,
                                            "length": 12
                                        },
                                        "confidence": 0.75
                                    }
                                ]
                            }
                        ]
                    }
                }
                """));

            var mockResponse = new MockResponse(200) { ContentStream = stream };
            var mockTransport = new MockTransport(mockResponse);
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentAnalysisClient(options);
            var operation = new AnalyzeDocumentOperation(OperationId, client);

            await operation.UpdateStatusAsync();

            var result = operation.Value;
            var barcode = result.Pages[0].Barcodes[0];
            var expectedPolygon = new PointF[] { new(1, 2), new(3, 4), new(5, 6), new(7, 8) };

            Assert.Multiple(() =>
            {
                Assert.That(barcode.Kind, Is.EqualTo(DocumentBarcodeKind.QrCode));
                Assert.That(barcode.Value, Is.EqualTo("barcodeValue"));
            });
            Assert.That(barcode.BoundingPolygon, Is.EqualTo(expectedPolygon).AsCollection);
            Assert.Multiple(() =>
            {
                Assert.That(barcode.Span.Index, Is.EqualTo(10));
                Assert.That(barcode.Span.Length, Is.EqualTo(12));
                Assert.That(barcode.Confidence, Is.EqualTo(0.75f));
            });
        }

        [Test]
        public async Task AnalyzeDocumentCanParseDocumentFormula()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "status": "succeeded",
                    "analyzeResult": {
                        "pages": [
                            {
                                "formulas": [
                                    {
                                        "kind": "display",
                                        "value": "formulaValue",
                                        "polygon": [1, 2, 3, 4, 5, 6, 7, 8],
                                        "span": {
                                            "offset": 10,
                                            "length": 12
                                        },
                                        "confidence": 0.75
                                    }
                                ]
                            }
                        ]
                    }
                }
                """));

            var mockResponse = new MockResponse(200) { ContentStream = stream };
            var mockTransport = new MockTransport(mockResponse);
            var options = new DocumentAnalysisClientOptions() { Transport = mockTransport };
            var client = CreateDocumentAnalysisClient(options);
            var operation = new AnalyzeDocumentOperation(OperationId, client);

            await operation.UpdateStatusAsync();

            var result = operation.Value;
            var formula = result.Pages[0].Formulas[0];
            var expectedPolygon = new PointF[] { new(1, 2), new(3, 4), new(5, 6), new(7, 8) };

            Assert.Multiple(() =>
            {
                Assert.That(formula.Kind, Is.EqualTo(DocumentFormulaKind.Display));
                Assert.That(formula.Value, Is.EqualTo("formulaValue"));
            });
            Assert.That(formula.BoundingPolygon, Is.EqualTo(expectedPolygon).AsCollection);
            Assert.Multiple(() =>
            {
                Assert.That(formula.Span.Index, Is.EqualTo(10));
                Assert.That(formula.Span.Length, Is.EqualTo(12));
                Assert.That(formula.Confidence, Is.EqualTo(0.75f));
            });
        }

        #endregion

        /// <summary>
        /// Creates a fake <see cref="DocumentAnalysisClient" /> with the specified set of options.
        /// </summary>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <returns>The fake <see cref="DocumentAnalysisClient" />.</returns>
        private DocumentAnalysisClient CreateDocumentAnalysisClient(DocumentAnalysisClientOptions options = default)
        {
            var fakeEndpoint = new Uri("http://localhost");
            var fakeCredential = new AzureKeyCredential("fakeKey");
            options ??= new DocumentAnalysisClientOptions();

            return new DocumentAnalysisClient(fakeEndpoint, fakeCredential, options);
        }

        private static string GetString(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
