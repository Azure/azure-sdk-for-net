// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// A factory that builds Azure.AI.FormRecognizer.DocumentAnalysis model types used for mocking.
    /// </summary>
    public static class DocumentAnalysisModelFactory
    {
        /// <summary> Initializes a new instance of AddressValue. </summary>
        /// <param name="houseNumber"> House or building number. </param>
        /// <param name="poBox"> Post office box number. </param>
        /// <param name="road"> Street name. </param>
        /// <param name="city"> Name of city, town, village, etc. </param>
        /// <param name="state"> First-level administrative division. </param>
        /// <param name="postalCode"> Postal code used for mail sorting. </param>
        /// <param name="countryRegion"> Country/region. </param>
        /// <param name="streetAddress"> Street-level address, excluding city, state, countryRegion, and postalCode. </param>
        /// <returns> A new <see cref="DocumentAnalysis.AddressValue"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AddressValue AddressValue(string houseNumber, string poBox, string road, string city, string state, string postalCode, string countryRegion, string streetAddress)
        {
            return new AddressValue(houseNumber, poBox, road, city, state, postalCode, countryRegion, streetAddress, unit: null, cityDistrict: null, stateDistrict: null, suburb: null, house: null, level: null);
        }

        /// <summary> Initializes a new instance of AddressValue. </summary>
        /// <param name="houseNumber"> House or building number. </param>
        /// <param name="poBox"> Post office box number. </param>
        /// <param name="road"> Street name. </param>
        /// <param name="city"> Name of city, town, village, etc. </param>
        /// <param name="state"> First-level administrative division. </param>
        /// <param name="postalCode"> Postal code used for mail sorting. </param>
        /// <param name="countryRegion"> Country/region. </param>
        /// <param name="streetAddress"> Street-level address, excluding city, state, countryRegion, and postalCode. </param>
        /// <param name="unit"> Apartment or office number. </param>
        /// <param name="cityDistrict"> Districts or boroughs within a city, such as Brooklyn in New York City or City of Westminster in London. </param>
        /// <param name="stateDistrict"> Second-level administrative division used in certain locales. </param>
        /// <param name="suburb"> Unofficial neighborhood name, like Chinatown. </param>
        /// <param name="house"> Build name, such as World Trade Center. </param>
        /// <param name="level"> Floor number, such as 3F. </param>
        /// <returns> A new <see cref="DocumentAnalysis.AddressValue"/> instance for mocking. </returns>
        public static AddressValue AddressValue(string houseNumber = null, string poBox = null, string road = null, string city = null, string state = null, string postalCode = null, string countryRegion = null, string streetAddress = null, string unit = null, string cityDistrict = null, string stateDistrict = null, string suburb = null, string house = null, string level = null)
        {
            return new AddressValue(houseNumber, poBox, road, city, state, postalCode, countryRegion, streetAddress, unit, cityDistrict, stateDistrict, suburb, house, level);
        }

        /// <summary> Initializes a new instance of AnalyzedDocument. </summary>
        /// <param name="documentType"> Document type. </param>
        /// <param name="boundingRegions"> Bounding regions covering the document. </param>
        /// <param name="spans"> Location of the document in the reading order concatenated content. </param>
        /// <param name="fields"> Dictionary of named field values. </param>
        /// <param name="confidence"> Confidence of correctly extracting the document. </param>
        /// <returns> A new <see cref="DocumentAnalysis.AnalyzedDocument"/> instance for mocking. </returns>
        public static AnalyzedDocument AnalyzedDocument(string documentType = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, IReadOnlyDictionary<string, DocumentField> fields = null, float confidence = default)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();
            fields ??= new Dictionary<string, DocumentField>();

            return new AnalyzedDocument(documentType, boundingRegions?.ToList(), spans?.ToList(), fields, confidence);
        }

        /// <summary> Initializes a new instance of AnalyzeResult. </summary>
        /// <param name="modelId"> Model ID used to produce this result. </param>
        /// <param name="content"> Concatenate string representation of all textual and visual elements in reading order. </param>
        /// <param name="pages"> Analyzed pages. </param>
        /// <param name="tables"> Extracted tables. </param>
        /// <param name="keyValuePairs"> Extracted key-value pairs. </param>
        /// <param name="styles"> Extracted font styles. </param>
        /// <param name="languages"> Detected languages. </param>
        /// <param name="documents"> Extracted documents. </param>
        /// <returns> A new <see cref="DocumentAnalysis.AnalyzeResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AnalyzeResult AnalyzeResult(string modelId, string content, IEnumerable<DocumentPage> pages, IEnumerable<DocumentTable> tables, IEnumerable<DocumentKeyValuePair> keyValuePairs, IEnumerable<DocumentStyle> styles, IEnumerable<DocumentLanguage> languages, IEnumerable<AnalyzedDocument> documents)
        {
            pages ??= new List<DocumentPage>();
            tables ??= new List<DocumentTable>();
            keyValuePairs ??= new List<DocumentKeyValuePair>();
            styles ??= new List<DocumentStyle>();
            languages ??= new List<DocumentLanguage>();
            documents ??= new List<AnalyzedDocument>();

            return new AnalyzeResult(serviceVersion: default, modelId, StringIndexType.Utf16CodeUnit, content, pages?.ToList(), paragraphs: default, tables?.ToList(), keyValuePairs?.ToList(), styles?.ToList(), languages?.ToList(), documents?.ToList());
        }

        /// <summary> Initializes a new instance of AnalyzeResult. </summary>
        /// <param name="modelId"> Model ID used to produce this result. </param>
        /// <param name="content"> Concatenate string representation of all textual and visual elements in reading order. </param>
        /// <param name="pages"> Analyzed pages. </param>
        /// <param name="tables"> Extracted tables. </param>
        /// <param name="keyValuePairs"> Extracted key-value pairs. </param>
        /// <param name="styles"> Extracted font styles. </param>
        /// <param name="languages"> Detected languages. </param>
        /// <param name="documents"> Extracted documents. </param>
        /// <param name="paragraphs"> Extracted paragraphs. </param>
        /// <param name="serviceVersion"> Service version used to produce this result. </param>
        /// <returns> A new <see cref="DocumentAnalysis.AnalyzeResult"/> instance for mocking. </returns>
        public static AnalyzeResult AnalyzeResult(string modelId = null, string content = null, IEnumerable<DocumentPage> pages = null, IEnumerable<DocumentTable> tables = null, IEnumerable<DocumentKeyValuePair> keyValuePairs = null, IEnumerable<DocumentStyle> styles = null, IEnumerable<DocumentLanguage> languages = null, IEnumerable<AnalyzedDocument> documents = null, IEnumerable<DocumentParagraph> paragraphs = null, string serviceVersion = null)
        {
            pages ??= new List<DocumentPage>();
            tables ??= new List<DocumentTable>();
            keyValuePairs ??= new List<DocumentKeyValuePair>();
            styles ??= new List<DocumentStyle>();
            languages ??= new List<DocumentLanguage>();
            documents ??= new List<AnalyzedDocument>();
            paragraphs ??= new List<DocumentParagraph>();

            return new AnalyzeResult(serviceVersion, modelId, StringIndexType.Utf16CodeUnit, content, pages?.ToList(), paragraphs?.ToList(), tables?.ToList(), keyValuePairs?.ToList(), styles?.ToList(), languages?.ToList(), documents?.ToList());
        }

        /// <summary> Initializes a new instance of BoundingRegion. </summary>
        /// <param name="pageNumber"> 1-based page number of page containing the bounding region. </param>
        /// <param name="boundingPolygon"> Bounding polygon on the page, or the entire page if not specified. </param>
        /// <returns> A new <see cref="DocumentAnalysis.BoundingRegion"/> instance for mocking. </returns>
        public static BoundingRegion BoundingRegion(int pageNumber = default, IReadOnlyList<PointF> boundingPolygon = default)
        {
            return new BoundingRegion(pageNumber, boundingPolygon);
        }

        /// <summary> Initializes a new instance of CurrencyValue. </summary>
        /// <param name="amount"> Currency amount. </param>
        /// <param name="symbol"> Currency symbol label, if any. </param>
        /// <returns> A new <see cref="DocumentAnalysis.CurrencyValue"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CurrencyValue CurrencyValue(double amount, string symbol)
        {
            return new CurrencyValue(amount, symbol, code: null);
        }

        /// <summary> Initializes a new instance of CurrencyValue. </summary>
        /// <param name="amount"> Currency amount. </param>
        /// <param name="symbol"> Currency symbol label, if any. </param>
        /// <param name="code"> Resolved currency code (ISO 4217), if any. </param>
        /// <returns> A new <see cref="DocumentAnalysis.CurrencyValue"/> instance for mocking. </returns>
        public static CurrencyValue CurrencyValue(double amount = default, string symbol = null, string code = null)
        {
            return new CurrencyValue(amount, symbol, code);
        }

        /// <summary> Initializes a new instance of DocumentTypeDetails. </summary>
        /// <param name="description"> Model description. </param>
        /// <param name="buildMode"> Custom model build mode. </param>
        /// <param name="fieldSchema"> Description of the document semantic schema using a JSON Schema style syntax. </param>
        /// <param name="fieldConfidence"> Estimated confidence for each field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentTypeDetails"/> instance for mocking. </returns>
        public static DocumentTypeDetails DocumentTypeDetails(string description = null, DocumentBuildMode? buildMode = null, IReadOnlyDictionary<string, DocumentFieldSchema> fieldSchema = null, IReadOnlyDictionary<string, float> fieldConfidence = null)
        {
            fieldSchema ??= new Dictionary<string, DocumentFieldSchema>();
            fieldConfidence ??= new Dictionary<string, float>();

            return new DocumentTypeDetails(description, buildMode, fieldSchema, fieldConfidence);
        }

        /// <summary> Initializes a new instance of DocumentBarcode. </summary>
        /// <param name="kind"> Barcode kind. </param>
        /// <param name="value"> Barcode value. </param>
        /// <param name="boundingPolygon"> Bounding polygon of the barcode. </param>
        /// <param name="span"> Location of the barcode in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the barcode. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentBarcode"/> instance for mocking. </returns>
        public static DocumentBarcode DocumentBarcode(DocumentBarcodeKind kind = default, string value = null, IReadOnlyList<PointF> boundingPolygon = default, DocumentSpan span = default, float confidence = default)
        {
            return new DocumentBarcode(kind, value, boundingPolygon, span, confidence);
        }

        /// <summary> Initializes a new instance of DocumentClassifierBuildOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document classifier. </param>
        /// <param name="error"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <param name="serviceVersion"> Service version used to create this operation. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentClassifierBuildOperationDetails"/> instance for mocking. </returns>
        public static DocumentClassifierBuildOperationDetails DocumentClassifierBuildOperationDetails(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, Uri resourceLocation = null, IReadOnlyDictionary<string, string> tags = null, ResponseError error = null, DocumentClassifierDetails result = null, string serviceVersion = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentClassifierBuildOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, resourceLocation, serviceVersion, tags, error, result);
        }

        /// <summary> Initializes a new instance of DocumentClassifierDetails. </summary>
        /// <param name="classifierId"> Unique document classifier name. </param>
        /// <param name="description"> Document classifier description. </param>
        /// <param name="createdOn"> Date and time (UTC) when the document classifier was created. </param>
        /// <param name="expiresOn"> Date and time (UTC) when the document classifier will expire. </param>
        /// <param name="serviceVersion"> Service version used to create this document classifier. </param>
        /// <param name="documentTypes"> List of document types to classify against. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentClassifierDetails"/> instance for mocking. </returns>
        public static DocumentClassifierDetails DocumentClassifierDetails(string classifierId = null, string description = null, DateTimeOffset createdOn = default, DateTimeOffset? expiresOn = null, string serviceVersion = null, IReadOnlyDictionary<string, ClassifierDocumentTypeDetails> documentTypes = null)
        {
            documentTypes ??= new Dictionary<string, ClassifierDocumentTypeDetails>();

            return new DocumentClassifierDetails(classifierId, description, createdOn, expiresOn, serviceVersion, documentTypes);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="fieldType"> Data type of the field value. </param>
        /// <param name="value">The value of this <see cref="DocumentField"/>.</param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        public static DocumentField DocumentField(DocumentFieldType fieldType, DocumentFieldValue value, string content, IReadOnlyList<BoundingRegion> boundingRegions, IReadOnlyList<DocumentSpan> spans, float? confidence)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentField(fieldType, value, content, boundingRegions, spans, confidence);
        }

        /// <summary> Initializes a new instance of DocumentFieldSchema. </summary>
        /// <param name="type"> Semantic data type of the field value. </param>
        /// <param name="description"> Field description. </param>
        /// <param name="example"> Example field content. </param>
        /// <param name="items"> Field type schema of each array element. </param>
        /// <param name="properties"> Named sub-fields of the object field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldSchema"/> instance for mocking. </returns>
        public static DocumentFieldSchema DocumentFieldSchema(DocumentFieldType type = default, string description = null, string example = null, DocumentFieldSchema items = null, IReadOnlyDictionary<string, DocumentFieldSchema> properties = null)
        {
            properties ??= new Dictionary<string, DocumentFieldSchema>();

            return new DocumentFieldSchema(type, description, example, items, properties);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithAddressFieldType(AddressValue value)
        {
            return new DocumentFieldValue(DocumentFieldType.Address, valueAddress: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithBooleanFieldType(bool value)
        {
            return new DocumentFieldValue(DocumentFieldType.Boolean, valueBoolean: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithCountryRegionFieldType(string value)
        {
            return new DocumentFieldValue(DocumentFieldType.CountryRegion, valueCountryRegion: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithCurrencyFieldType(CurrencyValue value)
        {
            return new DocumentFieldValue(DocumentFieldType.Currency, valueCurrency: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithDateFieldType(DateTimeOffset value)
        {
            return new DocumentFieldValue(DocumentFieldType.Date, valueDate: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithDictionaryFieldType(IReadOnlyDictionary<string, DocumentField> value)
        {
            return new DocumentFieldValue(DocumentFieldType.Dictionary, valueObject: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithDoubleFieldType(double value)
        {
            return new DocumentFieldValue(DocumentFieldType.Double, valueNumber: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithInt64FieldType(int value)
        {
            return new DocumentFieldValue(DocumentFieldType.Int64, valueInteger: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithListFieldType(IEnumerable<DocumentField> value)
        {
            return new DocumentFieldValue(DocumentFieldType.List, valueArray: value.ToList());
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithPhoneNumberFieldType(string value)
        {
            return new DocumentFieldValue(DocumentFieldType.Date, valuePhoneNumber: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithSelectionMarkFieldType(DocumentSelectionMarkState value)
        {
            return new DocumentFieldValue(value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithSignatureFieldType(DocumentSignatureType value)
        {
            return new DocumentFieldValue(DocumentFieldType.Signature, valueSignature: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithStringFieldType(string value)
        {
            return new DocumentFieldValue(DocumentFieldType.String, valueString: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithTimeFieldType(TimeSpan value)
        {
            return new DocumentFieldValue(DocumentFieldType.Time, valueTime: value);
        }

        /// <summary> Initializes a new instance of DocumentFieldValue. </summary>
        /// <param name="expectedFieldType"> The expected type of the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldValue"/> instance for mocking. </returns>
        public static DocumentFieldValue DocumentFieldValueWithUnknownFieldType(DocumentFieldType expectedFieldType)
        {
            return new DocumentFieldValue(expectedFieldType);
        }

        /// <summary> Initializes a new instance of DocumentFormula. </summary>
        /// <param name="kind"> Formula kind. </param>
        /// <param name="value"> LaTex expression describing the formula. </param>
        /// <param name="boundingPolygon"> Bounding polygon of the formula. </param>
        /// <param name="span"> Location of the formula in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the formula. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFormula"/> instance for mocking. </returns>
        public static DocumentFormula DocumentFormula(DocumentFormulaKind kind = default, string value = null, IReadOnlyList<PointF> boundingPolygon = default, DocumentSpan span = default, float confidence = default)
        {
            return new DocumentFormula(kind, value, boundingPolygon, span, confidence);
        }

        /// <summary> Initializes a new instance of DocumentKeyValueElement. </summary>
        /// <param name="content"> Concatenated content of the key-value element in reading order. </param>
        /// <param name="boundingRegions"> Bounding regions covering the key-value element. </param>
        /// <param name="spans"> Location of the key-value element in the reading order concatenated content. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentKeyValueElement"/> instance for mocking. </returns>
        public static DocumentKeyValueElement DocumentKeyValueElement(string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentKeyValueElement(content, boundingRegions?.ToList(), spans?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentKeyValuePair. </summary>
        /// <param name="key"> Field label of the key-value pair. </param>
        /// <param name="value"> Field value of the key-value pair. </param>
        /// <param name="confidence"> Confidence of correctly extracting the key-value pair. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentKeyValuePair"/> instance for mocking. </returns>
        public static DocumentKeyValuePair DocumentKeyValuePair(DocumentKeyValueElement key, DocumentKeyValueElement value, float confidence)
        {
            return new DocumentKeyValuePair(key, value, confidence);
        }

        /// <summary> Initializes a new instance of DocumentLanguage. </summary>
        /// <param name="locale"> Detected language.  Value may an ISO 639-1 language code (ex. &quot;en&quot;, &quot;fr&quot;) or BCP 47 language tag (ex. &quot;zh-Hans&quot;). </param>
        /// <param name="spans"> Location of the text elements in the concatenated content the language applies to. </param>
        /// <param name="confidence"> Confidence of correctly identifying the language. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentLanguage"/> instance for mocking. </returns>
        public static DocumentLanguage DocumentLanguage(string locale = null, IEnumerable<DocumentSpan> spans = null, float confidence = default)
        {
            spans ??= new List<DocumentSpan>();

            return new DocumentLanguage(locale, spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentLine. </summary>
        /// <param name="content"> Concatenated content of the contained elements in reading order. </param>
        /// <param name="boundingPolygon"> Bounding polygon of the line. </param>
        /// <param name="spans"> Location of the line in the reading order concatenated content. </param>
        /// <param name="words"> The words that compose this line. Returned by the <see cref="DocumentLine.GetWords"/> method. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentLine"/> instance for mocking. </returns>
        public static DocumentLine DocumentLine(string content = null, IReadOnlyList<PointF> boundingPolygon = default, IEnumerable<DocumentSpan> spans = null, IEnumerable<DocumentWord> words = null)
        {
            spans ??= new List<DocumentSpan>();
            words ??= new List<DocumentWord>();

            return new DocumentLine(content, boundingPolygon, spans?.ToList(), words?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentModelBuildOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="error"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelBuildOperationDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentModelBuildOperationDetails DocumentModelBuildOperationDetails(string operationId, DocumentOperationStatus status, int? percentCompleted, DateTimeOffset createdOn, DateTimeOffset lastUpdatedOn, Uri resourceLocation, IReadOnlyDictionary<string, string> tags, ResponseError error, DocumentModelDetails result)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelBuildOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, resourceLocation, serviceVersion: null, tags, error, result);
        }

        /// <summary> Initializes a new instance of DocumentModelBuildOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="error"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <param name="serviceVersion"> Service version used to create this operation. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelBuildOperationDetails"/> instance for mocking. </returns>
        public static DocumentModelBuildOperationDetails DocumentModelBuildOperationDetails(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, Uri resourceLocation = null, IReadOnlyDictionary<string, string> tags = null, ResponseError error = null, DocumentModelDetails result = null, string serviceVersion = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelBuildOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, resourceLocation, serviceVersion, tags, error, result);
        }

        /// <summary> Initializes a new instance of DocumentModelComposeOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="error"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelComposeOperationDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentModelComposeOperationDetails DocumentModelComposeOperationDetails(string operationId, DocumentOperationStatus status, int? percentCompleted, DateTimeOffset createdOn, DateTimeOffset lastUpdatedOn, Uri resourceLocation, IReadOnlyDictionary<string, string> tags, ResponseError error, DocumentModelDetails result)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelComposeOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, resourceLocation, serviceVersion: null, tags, error, result);
        }

        /// <summary> Initializes a new instance of DocumentModelComposeOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="error"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <param name="serviceVersion"> Service version used to create this operation. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelComposeOperationDetails"/> instance for mocking. </returns>
        public static DocumentModelComposeOperationDetails DocumentModelComposeOperationDetails(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, Uri resourceLocation = null, IReadOnlyDictionary<string, string> tags = null, ResponseError error = null, DocumentModelDetails result = null, string serviceVersion = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelComposeOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, resourceLocation, serviceVersion, tags, error, result);
        }

        /// <summary> Initializes a new instance of DocumentModelCopyToOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="error"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelCopyToOperationDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentModelCopyToOperationDetails DocumentModelCopyToOperationDetails(string operationId, DocumentOperationStatus status, int? percentCompleted, DateTimeOffset createdOn, DateTimeOffset lastUpdatedOn, Uri resourceLocation, IReadOnlyDictionary<string, string> tags, ResponseError error, DocumentModelDetails result)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelCopyToOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, resourceLocation, serviceVersion: null, tags, error, result);
        }

        /// <summary> Initializes a new instance of DocumentModelCopyToOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="error"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <param name="serviceVersion"> Service version used to create this operation. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelCopyToOperationDetails"/> instance for mocking. </returns>
        public static DocumentModelCopyToOperationDetails DocumentModelCopyToOperationDetails(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, Uri resourceLocation = null, IReadOnlyDictionary<string, string> tags = null, ResponseError error = null, DocumentModelDetails result = null, string serviceVersion = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelCopyToOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, resourceLocation, serviceVersion, tags, error, result);
        }

        /// <summary> Initializes a new instance of DocumentModelDetails. </summary>
        /// <param name="modelId"> Unique model name. </param>
        /// <param name="description"> Model description. </param>
        /// <param name="createdOn"> Date and time (UTC) when the model was created. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <param name="documentTypes"> Supported document types. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentModelDetails DocumentModelDetails(string modelId, string description, DateTimeOffset createdOn, IReadOnlyDictionary<string, string> tags, IReadOnlyDictionary<string, DocumentTypeDetails> documentTypes)
        {
            tags ??= new Dictionary<string, string>();
            documentTypes ??= new Dictionary<string, DocumentTypeDetails>();

            return new DocumentModelDetails(modelId, description, createdOn, expiresOn: null, serviceVersion: null, tags, documentTypes);
        }

        /// <summary> Initializes a new instance of DocumentModelDetails. </summary>
        /// <param name="modelId"> Unique model name. </param>
        /// <param name="description"> Model description. </param>
        /// <param name="createdOn"> Date and time (UTC) when the model was created. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <param name="documentTypes"> Supported document types. </param>
        /// <param name="expiresOn"> Date and time (UTC) when the model expires. </param>
        /// <param name="serviceVersion"> Service version used to create this document model. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelDetails"/> instance for mocking. </returns>
        public static DocumentModelDetails DocumentModelDetails(string modelId = null, string description = null, DateTimeOffset createdOn = default, IReadOnlyDictionary<string, string> tags = null, IReadOnlyDictionary<string, DocumentTypeDetails> documentTypes = null, DateTimeOffset? expiresOn = null, string serviceVersion = null)
        {
            tags ??= new Dictionary<string, string>();
            documentTypes ??= new Dictionary<string, DocumentTypeDetails>();

            return new DocumentModelDetails(modelId, description, createdOn, expiresOn, serviceVersion, tags, documentTypes);
        }

        /// <summary> Initializes a new instance of DocumentModelSummary. </summary>
        /// <param name="modelId"> Unique model name. </param>
        /// <param name="description"> Model description. </param>
        /// <param name="createdOn"> Date and time (UTC) when the model was created. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelSummary"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentModelSummary DocumentModelSummary(string modelId, string description, DateTimeOffset createdOn, IReadOnlyDictionary<string, string> tags)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelSummary(modelId, description, createdOn, expiresOn: null, serviceVersion: null, tags);
        }

        /// <summary> Initializes a new instance of DocumentModelSummary. </summary>
        /// <param name="modelId"> Unique model name. </param>
        /// <param name="description"> Model description. </param>
        /// <param name="createdOn"> Date and time (UTC) when the model was created. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <param name="expiresOn"> Date and time (UTC) when the model expires. </param>
        /// <param name="serviceVersion"> Service version used to create this document model. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelSummary"/> instance for mocking. </returns>
        public static DocumentModelSummary DocumentModelSummary(string modelId = null, string description = null, DateTimeOffset createdOn = default, IReadOnlyDictionary<string, string> tags = null, DateTimeOffset? expiresOn = null, string serviceVersion = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelSummary(modelId, description, createdOn, expiresOn, serviceVersion, tags);
        }

        /// <summary> Initializes a new instance of DocumentPage. </summary>
        /// <param name="pageNumber"> 1-based page number in the input document. </param>
        /// <param name="angle"> The general orientation of the content in clockwise direction, measured in degrees between (-180, 180]. </param>
        /// <param name="width"> The width of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="height"> The height of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="unit"> The unit used by the width, height, and boundingPolygon properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;. </param>
        /// <param name="spans"> Location of the page in the reading order concatenated content. </param>
        /// <param name="words"> Extracted words from the page. </param>
        /// <param name="selectionMarks"> Extracted selection marks from the page. </param>
        /// <param name="lines"> Extracted lines from the page, potentially containing both textual and visual elements. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentPage"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentPage DocumentPage(int pageNumber, float? angle, float? width, float? height, DocumentPageLengthUnit? unit, IEnumerable<DocumentSpan> spans, IEnumerable<DocumentWord> words, IEnumerable<DocumentSelectionMark> selectionMarks, IEnumerable<DocumentLine> lines)
        {
            spans ??= new List<DocumentSpan>();
            words ??= new List<DocumentWord>();
            selectionMarks ??= new List<DocumentSelectionMark>();
            lines ??= new List<DocumentLine>();

            var barcodes = new List<DocumentBarcode>();
            var formulas = new List<DocumentFormula>();

            return new DocumentPage(pageNumber, angle, width, height, unit, spans?.ToList(), words?.ToList(), selectionMarks?.ToList(), lines?.ToList(), barcodes, formulas);
        }

        /// <summary> Initializes a new instance of DocumentPage. </summary>
        /// <param name="pageNumber"> 1-based page number in the input document. </param>
        /// <param name="angle"> The general orientation of the content in clockwise direction, measured in degrees between (-180, 180]. </param>
        /// <param name="width"> The width of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="height"> The height of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="unit"> The unit used by the width, height, and boundingPolygon properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;. </param>
        /// <param name="spans"> Location of the page in the reading order concatenated content. </param>
        /// <param name="words"> Extracted words from the page. </param>
        /// <param name="selectionMarks"> Extracted selection marks from the page. </param>
        /// <param name="lines"> Extracted lines from the page, potentially containing both textual and visual elements. </param>
        /// <param name="barcodes"> Extracted barcodes from the page. </param>
        /// <param name="formulas"> Extracted formulas from the page. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentPage"/> instance for mocking. </returns>
        public static DocumentPage DocumentPage(int pageNumber = default, float? angle = null, float? width = null, float? height = null, DocumentPageLengthUnit? unit = null, IEnumerable<DocumentSpan> spans = null, IEnumerable<DocumentWord> words = null, IEnumerable<DocumentSelectionMark> selectionMarks = null, IEnumerable<DocumentLine> lines = null, IEnumerable<DocumentBarcode> barcodes = null, IEnumerable<DocumentFormula> formulas = null)
        {
            spans ??= new List<DocumentSpan>();
            words ??= new List<DocumentWord>();
            selectionMarks ??= new List<DocumentSelectionMark>();
            lines ??= new List<DocumentLine>();
            barcodes ??= new List<DocumentBarcode>();
            formulas ??= new List<DocumentFormula>();

            return new DocumentPage(pageNumber, angle, width, height, unit, spans?.ToList(), words?.ToList(), selectionMarks?.ToList(), lines?.ToList(), barcodes?.ToList(), formulas?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentParagraph. </summary>
        /// <param name="role"> Semantic role of the paragraph. </param>
        /// <param name="content"> Concatenated content of the paragraph in reading order. </param>
        /// <param name="boundingRegions"> Bounding regions covering the paragraph. </param>
        /// <param name="spans"> Location of the paragraph in the reading order concatenated content. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentParagraph"/> instance for mocking. </returns>
        public static DocumentParagraph DocumentParagraph(ParagraphRole? role = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentParagraph(role, content, boundingRegions?.ToList(), spans?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentSelectionMark. </summary>
        /// <param name="state"> State of the selection mark. </param>
        /// <param name="boundingPolygon"> Bounding polygon of the selection mark. </param>
        /// <param name="span"> Location of the selection mark in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the selection mark. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentSelectionMark"/> instance for mocking. </returns>
        public static DocumentSelectionMark DocumentSelectionMark(DocumentSelectionMarkState state = default, IReadOnlyList<PointF> boundingPolygon = default, DocumentSpan span = default, float confidence = default)
        {
            return new DocumentSelectionMark(state, boundingPolygon, span, confidence);
        }

        /// <summary> Initializes a new instance of DocumentSpan. </summary>
        /// <param name="offset"> Zero-based index of the content represented by the span. </param>
        /// <param name="length"> Number of characters in the content represented by the span. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentSpan"/> instance for mocking. </returns>
        public static DocumentSpan DocumentSpan(int offset = default, int length = default)
        {
            return new DocumentSpan(offset, length);
        }

        /// <summary> Initializes a new instance of DocumentStyle. </summary>
        /// <param name="isHandwritten"> Is content handwritten?. </param>
        /// <param name="spans"> Location of the text elements in the concatenated content the style applies to. </param>
        /// <param name="confidence"> Confidence of correctly identifying the style. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentStyle"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentStyle DocumentStyle(bool? isHandwritten, IEnumerable<DocumentSpan> spans, float confidence)
        {
            spans ??= new List<DocumentSpan>();

            return new DocumentStyle(isHandwritten, similarFontFamily: null, fontStyle: null, fontWeight: null, color: null, backgroundColor: null, spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentStyle. </summary>
        /// <param name="isHandwritten"> Is content handwritten?. </param>
        /// <param name="spans"> Location of the text elements in the concatenated content the style applies to. </param>
        /// <param name="confidence"> Confidence of correctly identifying the style. </param>
        /// <param name="similarFontFamily"> Visually most similar font from among the set of supported font families, with fallback fonts following CSS convention (ex. &apos;Arial, sans-serif&apos;). </param>
        /// <param name="fontStyle"> Font style. </param>
        /// <param name="fontWeight"> Font weight. </param>
        /// <param name="color"> Foreground color in #rrggbb hexadecimal format. </param>
        /// <param name="backgroundColor"> Background color in #rrggbb hexadecimal format. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentStyle"/> instance for mocking. </returns>
        public static DocumentStyle DocumentStyle(bool? isHandwritten = null, IEnumerable<DocumentSpan> spans = null, float confidence = default, string similarFontFamily = null, DocumentFontStyle? fontStyle = null, DocumentFontWeight? fontWeight = null, string color = null, string backgroundColor = null)
        {
            spans ??= new List<DocumentSpan>();

            return new DocumentStyle(isHandwritten, similarFontFamily, fontStyle, fontWeight, color, backgroundColor, spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentTable. </summary>
        /// <param name="rowCount"> Number of rows in the table. </param>
        /// <param name="columnCount"> Number of columns in the table. </param>
        /// <param name="cells"> Cells contained within the table. </param>
        /// <param name="boundingRegions"> Bounding regions covering the table. </param>
        /// <param name="spans"> Location of the table in the reading order concatenated content. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentTable"/> instance for mocking. </returns>
        public static DocumentTable DocumentTable(int rowCount = default, int columnCount = default, IEnumerable<DocumentTableCell> cells = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null)
        {
            cells ??= new List<DocumentTableCell>();
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentTable(rowCount, columnCount, cells?.ToList(), boundingRegions?.ToList(), spans?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentTableCell. </summary>
        /// <param name="kind"> Table cell kind. </param>
        /// <param name="rowIndex"> Row index of the cell. </param>
        /// <param name="columnIndex"> Column index of the cell. </param>
        /// <param name="rowSpan"> Number of rows spanned by this cell. </param>
        /// <param name="columnSpan"> Number of columns spanned by this cell. </param>
        /// <param name="content"> Concatenated content of the table cell in reading order. </param>
        /// <param name="boundingRegions"> Bounding regions covering the table cell. </param>
        /// <param name="spans"> Location of the table cell in the reading order concatenated content. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentTableCell"/> instance for mocking. </returns>
        public static DocumentTableCell DocumentTableCell(DocumentTableCellKind kind = default, int rowIndex = default, int columnIndex = default, int rowSpan = default, int columnSpan = default, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentTableCell(kind, rowIndex, columnIndex, rowSpan, columnSpan, content, boundingRegions?.ToList(), spans?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentWord. </summary>
        /// <param name="content"> Text content of the word. </param>
        /// <param name="boundingPolygon"> Bounding polygon of the word. </param>
        /// <param name="span"> Location of the word in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the word. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentWord"/> instance for mocking. </returns>
        public static DocumentWord DocumentWord(string content = null, IReadOnlyList<PointF> boundingPolygon = default, DocumentSpan span = default, float confidence = default)
        {
            return new DocumentWord(content, boundingPolygon, span, confidence);
        }

        /// <summary> Initializes a new instance of OperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URI of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <param name="error"> Encountered error. </param>
        /// <returns> A new <see cref="DocumentAnalysis.OperationDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OperationDetails OperationDetails(string operationId, DocumentOperationStatus status, int? percentCompleted, DateTimeOffset createdOn, DateTimeOffset lastUpdatedOn, DocumentOperationKind kind, Uri resourceLocation, IReadOnlyDictionary<string, string> tags, ResponseError error)
        {
            tags ??= new Dictionary<string, string>();

            return new OperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, serviceVersion: null, tags, error);
        }

        /// <summary> Initializes a new instance of OperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URI of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <param name="error"> Encountered error. </param>
        /// <param name="serviceVersion"> Service version used to create this operation. </param>
        /// <returns> A new <see cref="DocumentAnalysis.OperationDetails"/> instance for mocking. </returns>
        public static OperationDetails OperationDetails(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, DocumentOperationKind kind = default, Uri resourceLocation = null, IReadOnlyDictionary<string, string> tags = null, ResponseError error = null, string serviceVersion = null)
        {
            tags ??= new Dictionary<string, string>();

            return new OperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, serviceVersion, tags, error);
        }

        /// <summary> Initializes a new instance of OperationSummary. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URI of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <returns> A new <see cref="DocumentAnalysis.OperationSummary"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OperationSummary OperationSummary(string operationId, DocumentOperationStatus status, int? percentCompleted, DateTimeOffset createdOn, DateTimeOffset lastUpdatedOn, DocumentOperationKind kind, Uri resourceLocation, IReadOnlyDictionary<string, string> tags)
        {
            tags ??= new Dictionary<string, string>();

            return new OperationSummary(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, serviceVersion: null, tags);
        }

        /// <summary> Initializes a new instance of OperationSummary. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URI of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <param name="serviceVersion"> Service version used to create this operation. </param>
        /// <returns> A new <see cref="DocumentAnalysis.OperationSummary"/> instance for mocking. </returns>
        public static OperationSummary OperationSummary(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, DocumentOperationKind kind = default, Uri resourceLocation = null, IReadOnlyDictionary<string, string> tags = null, string serviceVersion = null)
        {
            tags ??= new Dictionary<string, string>();

            return new OperationSummary(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, serviceVersion, tags);
        }

        /// <summary> Initializes a new instance of ResourceDetails. </summary>
        /// <param name="customDocumentModelCount"> Number of custom models in the current resource. </param>
        /// <param name="customDocumentModelLimit"> Maximum number of custom models supported in the current resource. </param>
        /// <returns> A new <see cref="DocumentAnalysis.ResourceDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceDetails ResourceDetails(int customDocumentModelCount, int customDocumentModelLimit)
        {
            return new ResourceDetails(customDocumentModelCount, customDocumentModelLimit, neuralDocumentModelQuota: null);
        }

        /// <summary> Initializes a new instance of ResourceDetails. </summary>
        /// <param name="customDocumentModelCount"> Number of custom models in the current resource. </param>
        /// <param name="customDocumentModelLimit"> Maximum number of custom models supported in the current resource. </param>
        /// <param name="neuralDocumentModelQuota"> Quota used, limit, and next reset date/time for custom neural document models. </param>
        /// <returns> A new <see cref="DocumentAnalysis.ResourceDetails"/> instance for mocking. </returns>
        public static ResourceDetails ResourceDetails(int customDocumentModelCount = default, int customDocumentModelLimit = default, ResourceQuotaDetails neuralDocumentModelQuota = null)
        {
            return new ResourceDetails(customDocumentModelCount, customDocumentModelLimit, neuralDocumentModelQuota);
        }

        /// <summary>
        /// Initializes a new instance of ResourceQuotaDetails.
        /// </summary>
        /// <param name="used"> Amount of the resource quota used. </param>
        /// <param name="quota"> Resource quota limit. </param>
        /// <param name="quotaResetsOn"> Date/time when the resource quota usage will be reset. </param>
        /// <returns> A new <see cref="DocumentAnalysis.ResourceQuotaDetails"/> instance for mocking. </returns>
        public static ResourceQuotaDetails ResourceQuotaDetails(int used = default, int quota = default, DateTimeOffset quotaResetsOn = default)
        {
            return new ResourceQuotaDetails(used, quota, quotaResetsOn);
        }
    }
}
