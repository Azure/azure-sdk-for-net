// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// A factory that builds Azure.AI.FormRecognizer.DocumentAnalysis model types used for mocking.
    /// </summary>
    public static class DocumentAnalysisModelFactory
    {
        /// <summary> Initializes a new instance of AccountProperties. </summary>
        /// <param name="documentModelCount"> Number of custom models in the current resource. </param>
        /// <param name="documentModelLimit"> Maximum number of custom models supported in the current resource. </param>
        /// <returns> A new <see cref="DocumentAnalysis.AccountProperties"/> instance for mocking. </returns>
        public static AccountProperties AccountProperties(int documentModelCount = default, int documentModelLimit = default)
        {
            return new AccountProperties(documentModelCount, documentModelLimit);
        }

        /// <summary> Initializes a new instance of AnalyzedDocument. </summary>
        /// <param name="docType"> Document type. </param>
        /// <param name="boundingRegions"> Bounding regions covering the document. </param>
        /// <param name="spans"> Location of the document in the reading order concatenated content. </param>
        /// <param name="fields"> Dictionary of named field values. </param>
        /// <param name="confidence"> Confidence of correctly extracting the document. </param>
        /// <returns> A new <see cref="DocumentAnalysis.AnalyzedDocument"/> instance for mocking. </returns>
        public static AnalyzedDocument AnalyzedDocument(string docType = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, IReadOnlyDictionary<string, DocumentField> fields = null, float confidence = default)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();
            fields ??= new Dictionary<string, DocumentField>();

            return new AnalyzedDocument(docType, boundingRegions?.ToList(), spans?.ToList(), fields, confidence);
        }

        /// <summary> Initializes a new instance of AnalyzeResult. </summary>
        /// <param name="modelId"> Model ID used to produce this result. </param>
        /// <param name="content"> Concatenate string representation of all textual and visual elements in reading order. </param>
        /// <param name="pages"> Analyzed pages. </param>
        /// <param name="tables"> Extracted tables. </param>
        /// <param name="keyValuePairs"> Extracted key-value pairs. </param>
        /// <param name="entities"> Extracted entities. </param>
        /// <param name="styles"> Extracted font styles. </param>
        /// <param name="languages"> Detected languages. </param>
        /// <param name="documents"> Extracted documents. </param>
        /// <returns> A new <see cref="DocumentAnalysis.AnalyzeResult"/> instance for mocking. </returns>
        public static AnalyzeResult AnalyzeResult(string modelId = null, string content = null, IEnumerable<DocumentPage> pages = null, IEnumerable<DocumentTable> tables = null, IEnumerable<DocumentKeyValuePair> keyValuePairs = null, IEnumerable<DocumentEntity> entities = null, IEnumerable<DocumentStyle> styles = null, IEnumerable<DocumentLanguage> languages = null, IEnumerable<AnalyzedDocument> documents = null)
        {
            pages ??= new List<DocumentPage>();
            tables ??= new List<DocumentTable>();
            keyValuePairs ??= new List<DocumentKeyValuePair>();
            entities ??= new List<DocumentEntity>();
            styles ??= new List<DocumentStyle>();
            languages ??= new List<DocumentLanguage>();
            documents ??= new List<AnalyzedDocument>();

            return new AnalyzeResult(apiVersion: default, modelId, StringIndexType.Utf16CodeUnit, content, pages?.ToList(), tables?.ToList(), keyValuePairs?.ToList(), entities?.ToList(), styles?.ToList(), languages?.ToList(), documents?.ToList());
        }

        /// <summary> Initializes a new instance of BoundingRegion. </summary>
        /// <param name="points"> The sequence of points defining this Bounding Box. </param>
        /// <returns> A new <see cref="DocumentAnalysis.BoundingBox"/> instance for mocking. </returns>
        public static BoundingBox BoundingBox(IEnumerable<PointF> points = null)
        {
            points ??= new List<PointF>();

            return new BoundingBox(points?.ToList());
        }

        /// <summary> Initializes a new instance of BoundingRegion. </summary>
        /// <param name="pageNumber"> 1-based page number of page containing the bounding region. </param>
        /// <param name="boundingBox"> Bounding box on the page, or the entire page if not specified. </param>
        /// <returns> A new <see cref="DocumentAnalysis.BoundingRegion"/> instance for mocking. </returns>
        public static BoundingRegion BoundingRegion(int pageNumber = default, BoundingBox boundingBox = default)
        {
            return new BoundingRegion(pageNumber, boundingBox);
        }

        /// <summary> Initializes a new instance of CopyAuthorization. </summary>
        /// <param name="targetResourceRegion"> Location of the target Azure resource where the model should be copied to. </param>
        /// <param name="targetModelId"> Identifier of the target model. </param>
        /// <param name="targetModelLocation"> URL of the copied model in the target account. </param>
        /// <param name="expirationDateTime"> Date/time when the access token expires. </param>
        /// <returns> A new <see cref="DocumentAnalysis.CopyAuthorization"/> instance for mocking. </returns>
        public static CopyAuthorization CopyAuthorization(string targetResourceRegion = null, string targetModelId = null, string targetModelLocation = null, DateTimeOffset expirationDateTime = default)
        {
            return new CopyAuthorization(targetResourceRegion, targetModelId, targetModelLocation, expirationDateTime);
        }

        /// <summary> Initializes a new instance of CurrencyValue. </summary>
        /// <param name="amount"> Currency amount. </param>
        /// <param name="symbol"> Currency symbol label, if any. </param>
        /// <returns> A new <see cref="DocumentAnalysis.CurrencyValue"/> instance for mocking. </returns>
        public static CurrencyValue CurrencyValue(double amount = default, string symbol = null)
        {
            return new CurrencyValue(amount, symbol);
        }

        /// <summary> Initializes a new instance of DocTypeInfo. </summary>
        /// <param name="description"> Model description. </param>
        /// <param name="buildMode"> Custom model build mode. </param>
        /// <param name="fieldSchema"> Description of the document semantic schema using a JSON Schema style syntax. </param>
        /// <param name="fieldConfidence"> Estimated confidence for each field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocTypeInfo"/> instance for mocking. </returns>
        public static DocTypeInfo DocTypeInfo(string description = null, DocumentBuildMode? buildMode = null, IReadOnlyDictionary<string, DocumentFieldSchema> fieldSchema = null, IReadOnlyDictionary<string, float> fieldConfidence = null)
        {
            fieldSchema ??= new Dictionary<string, DocumentFieldSchema>();
            fieldConfidence ??= new Dictionary<string, float>();

            return new DocTypeInfo(description, buildMode, fieldSchema, fieldConfidence);
        }

        /// <summary> Initializes a new instance of DocumentEntity. </summary>
        /// <param name="category"> Entity type. </param>
        /// <param name="subCategory"> Entity sub type. </param>
        /// <param name="content"> Entity content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the entity. </param>
        /// <param name="spans"> Location of the entity in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the entity. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentEntity"/> instance for mocking. </returns>
        public static DocumentEntity DocumentEntity(string category = null, string subCategory = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float confidence = default)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentEntity(category, subCategory, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
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

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithCountryRegionFieldType(string value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();
            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.CountryRegion, null, null, null, null, null, null, null, null, valueCountryRegion: value, valueArray, valueObject, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithCurrencyFieldType(CurrencyValue? value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();
            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.Currency, null, null, null, null, null, null, null, null, null, valueArray, valueObject, valueCurrency: value, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithDateFieldType(DateTime? value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();
            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.Date, null, valueDate: value, null, null, null, null, null, null, null, valueArray, valueObject, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithDictionaryFieldType(IReadOnlyDictionary<string, DocumentField> value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            value ??= new Dictionary<string, DocumentField>();
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();

            return new DocumentField(DocumentFieldType.Dictionary, null, null, null, null, null, null, null, null, null, valueArray, valueObject: value, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithDoubleFieldType(double? value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();
            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.Double, null, null, null, null, valueNumber: value, null, null, null, null, valueArray, valueObject, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithInt64FieldType(int? value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();
            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.Int64, null, null, null, null, null, valueInteger: value, null, null, null, valueArray, valueObject, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithListFieldType(IEnumerable<DocumentField> value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            value ??= new List<DocumentField>();
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.List, null, null, null, null, null, null, null, null, null, valueArray: value?.ToList(), valueObject, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithPhoneNumberFieldType(string value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();
            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.PhoneNumber, null, null, null, valuePhoneNumber: value, null, null, null, null, null, valueArray, valueObject, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithSelectionMarkFieldType(SelectionMarkState? value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentField(value, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithSignatureFieldType(DocumentSignatureType? value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();
            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.Signature, null, null, null, null, null, null, null, valueSignature: value, null, valueArray, valueObject, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithStringFieldType(string value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();
            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.String, valueString: value, null, null, null, null, null, null, null, null, valueArray, valueObject, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentField. </summary>
        /// <param name="value"> The value of the field. </param>
        /// <param name="content"> Field content. </param>
        /// <param name="boundingRegions"> Bounding regions covering the field. </param>
        /// <param name="spans"> Location of the field in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentField"/> instance for mocking. </returns>
        public static DocumentField DocumentFieldWithTimeFieldType(TimeSpan? value = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, float? confidence = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            var valueArray = new List<DocumentField>();
            var valueObject = new Dictionary<string, DocumentField>();

            return new DocumentField(DocumentFieldType.Time, null, null, valueTime: value, null, null, null, null, null, null, valueArray, valueObject, null, content, boundingRegions?.ToList(), spans?.ToList(), confidence);
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
        public static DocumentKeyValuePair DocumentKeyValuePair(DocumentKeyValueElement key = null, DocumentKeyValueElement value = null, float confidence = default)
        {
            return new DocumentKeyValuePair(key, value, confidence);
        }

        /// <summary> Initializes a new instance of DocumentLanguage. </summary>
        /// <param name="languageCode"> Detected language.  Value may an ISO 639-1 language code (ex. &quot;en&quot;, &quot;fr&quot;) or BCP 47 language tag (ex. &quot;zh-Hans&quot;). </param>
        /// <param name="spans"> Location of the text elements in the concatenated content the language applies to. </param>
        /// <param name="confidence"> Confidence of correctly identifying the language. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentLanguage"/> instance for mocking. </returns>
        public static DocumentLanguage DocumentLanguage(string languageCode = null, IEnumerable<DocumentSpan> spans = null, float confidence = default)
        {
            spans ??= new List<DocumentSpan>();

            return new DocumentLanguage(languageCode, spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentLine. </summary>
        /// <param name="content"> Concatenated content of the contained elements in reading order. </param>
        /// <param name="boundingBox"> Bounding box of the line. </param>
        /// <param name="spans"> Location of the line in the reading order concatenated content. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentLine"/> instance for mocking. </returns>
        public static DocumentLine DocumentLine(string content = null, BoundingBox boundingBox = default, IEnumerable<DocumentSpan> spans = null)
        {
            spans ??= new List<DocumentSpan>();

            return new DocumentLine(content, boundingBox, spans?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentModel. </summary>
        /// <param name="modelId"> Unique model name. </param>
        /// <param name="description"> Model description. </param>
        /// <param name="createdOn"> Date and time (UTC) when the model was created. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <param name="docTypes"> Supported document types. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModel"/> instance for mocking. </returns>
        public static DocumentModel DocumentModel(string modelId = null, string description = null, DateTimeOffset createdOn = default, IReadOnlyDictionary<string, string> tags = null, IReadOnlyDictionary<string, DocTypeInfo> docTypes = null)
        {
            tags ??= new Dictionary<string, string>();
            docTypes ??= new Dictionary<string, DocTypeInfo>();

            return new DocumentModel(modelId, description, createdOn, apiVersion: null, tags, docTypes);
        }

        /// <summary> Initializes a new instance of DocumentModelInfo. </summary>
        /// <param name="modelId"> Unique model name. </param>
        /// <param name="description"> Model description. </param>
        /// <param name="createdOn"> Date and time (UTC) when the model was created. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelInfo"/> instance for mocking. </returns>
        public static DocumentModelInfo DocumentModelInfo(string modelId = null, string description = null, DateTimeOffset createdOn = default, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelInfo(modelId, description, createdOn, apiVersion: null, tags);
        }

        /// <summary> Initializes a new instance of DocumentPage. </summary>
        /// <param name="pageNumber"> 1-based page number in the input document. </param>
        /// <param name="angle"> The general orientation of the content in clockwise direction, measured in degrees between (-180, 180]. </param>
        /// <param name="width"> The width of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="height"> The height of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="unit"> The unit used by the width, height, and boundingBox properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;. </param>
        /// <param name="spans"> Location of the page in the reading order concatenated content. </param>
        /// <param name="words"> Extracted words from the page. </param>
        /// <param name="selectionMarks"> Extracted selection marks from the page. </param>
        /// <param name="lines"> Extracted lines from the page, potentially containing both textual and visual elements. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentPage"/> instance for mocking. </returns>
        public static DocumentPage DocumentPage(int pageNumber = default, float angle = default, float width = default, float height = default, LengthUnit unit = default, IEnumerable<DocumentSpan> spans = null, IEnumerable<DocumentWord> words = null, IEnumerable<DocumentSelectionMark> selectionMarks = null, IEnumerable<DocumentLine> lines = null)
        {
            spans ??= new List<DocumentSpan>();
            words ??= new List<DocumentWord>();
            selectionMarks ??= new List<DocumentSelectionMark>();
            lines ??= new List<DocumentLine>();

            return new DocumentPage(pageNumber, angle, width, height, unit, spans?.ToList(), words?.ToList(), selectionMarks?.ToList(), lines?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentSelectionMark. </summary>
        /// <param name="state"> State of the selection mark. </param>
        /// <param name="boundingBox"> Bounding box of the selection mark. </param>
        /// <param name="span"> Location of the selection mark in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the selection mark. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentSelectionMark"/> instance for mocking. </returns>
        public static DocumentSelectionMark DocumentSelectionMark(SelectionMarkState state = default, BoundingBox boundingBox = default, DocumentSpan span = default, float confidence = default)
        {
            return new DocumentSelectionMark(state, boundingBox, span, confidence);
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
        public static DocumentStyle DocumentStyle(bool? isHandwritten = null, IEnumerable<DocumentSpan> spans = null, float confidence = default)
        {
            spans ??= new List<DocumentSpan>();

            return new DocumentStyle(isHandwritten, spans?.ToList(), confidence);
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
        /// <param name="boundingBox"> Bounding box of the word. </param>
        /// <param name="span"> Location of the word in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the word. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentWord"/> instance for mocking. </returns>
        public static DocumentWord DocumentWord(string content = null, BoundingBox boundingBox = default, DocumentSpan span = default, float confidence = default)
        {
            return new DocumentWord(content, boundingBox, span, confidence);
        }

        /// <summary> Initializes a new instance of ModelOperation. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <param name="error"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <returns> A new <see cref="DocumentAnalysis.ModelOperation"/> instance for mocking. </returns>
        public static ModelOperation ModelOperation(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, DocumentOperationKind kind = default, string resourceLocation = null, IReadOnlyDictionary<string, string> tags = null, ResponseError error = null, DocumentModel result = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ModelOperation(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, apiVersion: null, tags, error, result);
        }

        /// <summary> Initializes a new instance of ModelOperationInfo. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <returns> A new <see cref="DocumentAnalysis.ModelOperationInfo"/> instance for mocking. </returns>
        public static ModelOperationInfo ModelOperationInfo(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, DocumentOperationKind kind = default, string resourceLocation = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ModelOperationInfo(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, apiVersion: null, tags);
        }
    }
}
