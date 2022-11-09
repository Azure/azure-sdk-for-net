// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure.AI.FormRecognizer.Training;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A factory that builds Azure.AI.FormRecognizer model types used for mocking.
    /// </summary>
    [CodeGenType("FormRecognizerModelFactory")]
    public static partial class FormRecognizerModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Training.AccountProperties"/> class.
        /// </summary>
        /// <param name="customModelCount">The current count of trained custom models.</param>
        /// <param name="customModelLimit">The maximum number of models that can be trained for this account.</param>
        /// <returns>A new <see cref="Training.AccountProperties"/> instance for mocking.</returns>
        public static FormRecognizer.Training.AccountProperties AccountProperties(int customModelCount, int customModelLimit) =>
            new FormRecognizer.Training.AccountProperties(customModelCount, customModelLimit);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FieldBoundingBox"/> structure.
        /// </summary>
        /// <param name="points">The sequence of points defining this <see cref="FormRecognizer.Models.FieldBoundingBox"/>.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FieldBoundingBox"/> instance for mocking.</returns>
        public static FieldBoundingBox FieldBoundingBox(IReadOnlyList<PointF> points) =>
            new FieldBoundingBox(points);

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.CustomFormModel"/> class.
        /// </summary>
        /// <param name="modelId">The unique identifier of this model.</param>
        /// <param name="status">A status indicating this model's readiness for use.</param>
        /// <param name="trainingStartedOn">The date and time (UTC) when model training was started.</param>
        /// <param name="trainingCompletedOn">The date and time (UTC) when model training completed.</param>
        /// <param name="submodels">A list of submodels that are part of this model, each of which can recognize and extract fields from a different type of form.</param>
        /// <param name="trainingDocuments">A list of meta-data about each of the documents used to train the model.</param>
        /// <param name="errors">A list of errors occurred during the training operation.</param>
        /// <returns>A new <see cref="Training.CustomFormModel"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CustomFormModel CustomFormModel(string modelId, CustomFormModelStatus status, DateTimeOffset trainingStartedOn, DateTimeOffset trainingCompletedOn, IReadOnlyList<CustomFormSubmodel> submodels, IReadOnlyList<TrainingDocumentInfo> trainingDocuments, IReadOnlyList<FormRecognizerError> errors) =>
            CustomFormModel(modelId, status, trainingStartedOn, trainingCompletedOn, submodels, trainingDocuments, errors, default, default);

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.CustomFormModel"/> class.
        /// </summary>
        /// <param name="modelId">The unique identifier of this model.</param>
        /// <param name="status">A status indicating this model's readiness for use.</param>
        /// <param name="trainingStartedOn">The date and time (UTC) when model training was started.</param>
        /// <param name="trainingCompletedOn">The date and time (UTC) when model training completed.</param>
        /// <param name="submodels">A list of submodels that are part of this model, each of which can recognize and extract fields from a different type of form.</param>
        /// <param name="trainingDocuments">A list of meta-data about each of the documents used to train the model.</param>
        /// <param name="errors">A list of errors occurred during the training operation.</param>
        /// <param name="modelName">An optional, user-defined name to associate with your model.</param>
        /// <param name="properties">Model properties, like for example, if a model is composed.</param>
        /// <returns>A new <see cref="Training.CustomFormModel"/> instance for mocking.</returns>
        public static CustomFormModel CustomFormModel(
            string modelId,
            CustomFormModelStatus status,
            DateTimeOffset trainingStartedOn,
            DateTimeOffset trainingCompletedOn,
            IReadOnlyList<CustomFormSubmodel> submodels,
            IReadOnlyList<TrainingDocumentInfo> trainingDocuments,
            IReadOnlyList<FormRecognizerError> errors,
            string modelName,
            CustomFormModelProperties properties)
        {
            submodels = submodels?.ToList();
            trainingDocuments = trainingDocuments?.ToList();
            errors = errors?.ToList();

            return new CustomFormModel(modelId, status, trainingStartedOn, trainingCompletedOn, submodels, trainingDocuments, errors, modelName, properties);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.CustomFormModelField"/> class.
        /// </summary>
        /// <param name="name">Canonical name; uniquely identifies a field within the form.</param>
        /// <param name="label">The label of this field on the form.</param>
        /// <param name="accuracy">The estimated recognition accuracy for this field.</param>
        /// <returns>A new <see cref="Training.CustomFormModelField"/> instance for mocking.</returns>
        public static CustomFormModelField CustomFormModelField(string name, string label, float? accuracy) =>
            new CustomFormModelField(name, label, accuracy);

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.CustomFormModelInfo"/> class.
        /// </summary>
        /// <param name="modelId">The unique identifier of the model.</param>
        /// <param name="trainingStartedOn">The date and time (UTC) when model training was started.</param>
        /// <param name="trainingCompletedOn">The date and time (UTC) when model training completed.</param>
        /// <param name="status">The status of the model.</param>
        /// <returns>A new <see cref="Training.CustomFormModelInfo"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CustomFormModelInfo CustomFormModelInfo(string modelId, DateTimeOffset trainingStartedOn, DateTimeOffset trainingCompletedOn, CustomFormModelStatus status) =>
            CustomFormModelInfo(modelId, trainingStartedOn, trainingCompletedOn, status, default, default);

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.CustomFormModelInfo"/> class.
        /// </summary>
        /// <param name="modelId">The unique identifier of the model.</param>
        /// <param name="trainingStartedOn">The date and time (UTC) when model training was started.</param>
        /// <param name="trainingCompletedOn">The date and time (UTC) when model training completed.</param>
        /// <param name="status">The status of the model.</param>
        /// <param name="modelName">An optional, user-defined name to associate with your model.</param>
        /// <param name="properties">Model properties, like for example, if a model is composed.</param>
        /// <returns>A new <see cref="Training.CustomFormModelInfo"/> instance for mocking.</returns>
        public static CustomFormModelInfo CustomFormModelInfo(string modelId, DateTimeOffset trainingStartedOn, DateTimeOffset trainingCompletedOn, CustomFormModelStatus status, string modelName, CustomFormModelProperties properties) =>
            new CustomFormModelInfo(modelId, status, trainingStartedOn, trainingCompletedOn, modelName, properties);

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.CustomFormModelProperties"/> class.
        /// </summary>
        /// <param name="isComposedModel">Indicates if the model is a composed model.</param>
        /// <returns>A new <see cref="Training.CustomFormModelProperties"/> instance for mocking.</returns>
        public static CustomFormModelProperties CustomFormModelProperties(bool isComposedModel) =>
            new CustomFormModelProperties(isComposedModel);

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.CustomFormSubmodel"/> class.
        /// </summary>
        /// <param name="formType">The type of form this submodel recognizes.</param>
        /// <param name="accuracy">The mean of the accuracies of this model's <see cref="Training.CustomFormModelField"/> instances.</param>
        /// <param name="fields">A dictionary of the fields that this submodel will recognize from the input document.</param>
        /// <returns>A new <see cref="Training.CustomFormSubmodel"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CustomFormSubmodel CustomFormSubmodel(string formType, float? accuracy, IReadOnlyDictionary<string, CustomFormModelField> fields) =>
            CustomFormSubmodel(formType, accuracy, fields, default);

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.CustomFormSubmodel"/> class.
        /// </summary>
        /// <param name="formType">The type of form this submodel recognizes.</param>
        /// <param name="accuracy">The mean of the accuracies of this model's <see cref="Training.CustomFormModelField"/> instances.</param>
        /// <param name="fields">A dictionary of the fields that this submodel will recognize from the input document.</param>
        /// <param name="modelId">he unique identifier of the submodel.</param>
        /// <returns>A new <see cref="Training.CustomFormSubmodel"/> instance for mocking.</returns>
        public static CustomFormSubmodel CustomFormSubmodel(string formType, float? accuracy, IReadOnlyDictionary<string, CustomFormModelField> fields, string modelId)
        {
            fields = fields?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return new CustomFormSubmodel(formType, accuracy, fields, modelId);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FieldData"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the text of this element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of this form element.</param>
        /// <param name="fieldElements">A list of references to the field elements constituting this data.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FieldData"/> instance for mocking.</returns>
        public static FieldData FieldData(FieldBoundingBox boundingBox, int pageNumber, string text, IReadOnlyList<FormElement> fieldElements)
        {
            fieldElements = fieldElements?.ToList();

            return new FieldData(boundingBox, pageNumber, text, fieldElements);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithStringValueType(string value) =>
            new FieldValue(value, FieldValueType.String);

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithInt64ValueType(long value) =>
            new FieldValue(value);

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithFloatValueType(float value) =>
            new FieldValue(value);

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithDateValueType(DateTime value) =>
            new FieldValue(value);

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithTimeValueType(TimeSpan value) =>
            new FieldValue(value);

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithPhoneNumberValueType(string value) =>
            new FieldValue(value, FieldValueType.PhoneNumber);

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithListValueType(IReadOnlyList<FormField> value)
        {
            value = value?.ToList();

            return new FieldValue(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithDictionaryValueType(IReadOnlyDictionary<string, FormField> value)
        {
            value = value?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return new FieldValue(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithSelectionMarkValueType(SelectionMarkState value) =>
            new FieldValue(value);

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValue"/> structure.
        /// </summary>
        /// <param name="value">The actual field value.</param>
        /// <returns>A new <see cref="FieldValue"/> instance for mocking.</returns>
        public static FieldValue FieldValueWithCountryRegionValueType(string value) =>
            new FieldValue(value, FieldValueType.CountryRegion);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormField"/> class.
        /// </summary>
        /// <param name="name">Canonical name; uniquely identifies a field within the form.</param>
        /// <param name="labelData">Contains the text, bounding box and content of the label of the field in the form.</param>
        /// <param name="valueData">Contains the text, bounding box and content of the value of the field in the form.</param>
        /// <param name="value">The strongly-typed value of this field.</param>
        /// <param name="confidence">Measures the degree of certainty of the recognition result.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormField"/> instance for mocking.</returns>
        public static FormField FormField(string name, FieldData labelData, FieldData valueData, FieldValue value, float confidence) =>
            new FormField(name, labelData, valueData, value, confidence);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormLine"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the text of this element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of this form element.</param>
        /// <param name="words">A list of the words that make up the line.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormLine"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FormLine FormLine(FieldBoundingBox boundingBox, int pageNumber, string text, IReadOnlyList<FormWord> words) =>
            FormLine(boundingBox, pageNumber, text, words, default);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormLine"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the text of this element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of this form element.</param>
        /// <param name="words">A list of the words that make up the line.</param>
        /// <param name="appearance">An object representing the appearance of the text line.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormLine"/> instance for mocking.</returns>
        public static FormLine FormLine(FieldBoundingBox boundingBox, int pageNumber, string text, IReadOnlyList<FormWord> words, TextAppearance appearance)
        {
            words = words?.ToList();

            return new FormLine(boundingBox, pageNumber, text, words, appearance);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormPage"/> class.
        /// </summary>
        /// <param name="pageNumber">The 1-based page number in the input document.</param>
        /// <param name="width">The width of the image/PDF in pixels/inches, respectively.</param>
        /// <param name="height">The height of the image/PDF in pixels/inches, respectively.</param>
        /// <param name="textAngle">The general orientation of the text in clockwise direction, measured in degrees between (-180, 180].</param>
        /// <param name="unit">The unit used by the width, height and <see cref="FieldBoundingBox"/> properties. For images, the unit is pixel. For PDF, the unit is inch.</param>
        /// <param name="lines">A list of recognized lines of text.</param>
        /// <param name="tables">A list of recognized tables contained in this page.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormPage"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FormPage FormPage(int pageNumber, float width, float height, float textAngle, LengthUnit unit, IReadOnlyList<FormLine> lines, IReadOnlyList<FormTable> tables) =>
            FormPage(pageNumber, width, height, textAngle, unit, lines, tables, default);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormPage"/> class.
        /// </summary>
        /// <param name="pageNumber">The 1-based page number in the input document.</param>
        /// <param name="width">The width of the image/PDF in pixels/inches, respectively.</param>
        /// <param name="height">The height of the image/PDF in pixels/inches, respectively.</param>
        /// <param name="textAngle">The general orientation of the text in clockwise direction, measured in degrees between (-180, 180].</param>
        /// <param name="unit">The unit used by the width, height and <see cref="FieldBoundingBox"/> properties. For images, the unit is pixel. For PDF, the unit is inch.</param>
        /// <param name="lines">A list of recognized lines of text.</param>
        /// <param name="tables">A list of recognized tables contained in this page.</param>
        /// <param name="selectionMarks">A list of recognized selection marks contained in this page.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormPage"/> instance for mocking.</returns>
        public static FormPage FormPage(int pageNumber, float width, float height, float textAngle, LengthUnit unit, IReadOnlyList<FormLine> lines, IReadOnlyList<FormTable> tables, IReadOnlyList<FormSelectionMark> selectionMarks)
        {
            lines = lines?.ToList();
            tables = tables?.ToList();
            selectionMarks = selectionMarks?.ToList();

            return new FormPage(pageNumber, width, height, textAngle, unit, lines, tables, selectionMarks);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormPageCollection"/> class.
        /// This class is a read-only wrapper around the specified list.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormPageCollection"/> instance for mocking.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
        public static FormPageCollection FormPageCollection(IList<FormPage> list) =>
            new FormPageCollection(list);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormPageRange"/> structure.
        /// </summary>
        /// <param name="firstPageNumber">The first page number of the range.</param>
        /// <param name="lastPageNumber">The last page number of the range.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormPageRange"/> instance for mocking.</returns>
        public static FormPageRange FormPageRange(int firstPageNumber, int lastPageNumber) =>
            new FormPageRange(firstPageNumber, lastPageNumber);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormRecognizerError"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The error message.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormRecognizerError"/> instance for mocking.</returns>
        public static FormRecognizerError FormRecognizerError(string errorCode, string message) =>
            new FormRecognizerError(errorCode, message);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormSelectionMark"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of selection mark value.</param>
        /// <param name="confidence">Measures the degree of certainty of the recognition result.</param>
        /// <param name="state">Selection mark state value.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormSelectionMark"/> instance for mocking.</returns>
        public static FormSelectionMark FormSelectionMark(FieldBoundingBox boundingBox, int pageNumber, string text, float confidence, SelectionMarkState state) =>
            new FormSelectionMark(boundingBox, pageNumber, text, confidence, state);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormTable"/> class.
        /// </summary>
        /// <param name="pageNumber">The 1-based number of the page in which this table is present.</param>
        /// <param name="columnCount">The number of columns in this table.</param>
        /// <param name="rowCount">The number of rows in this table.</param>
        /// <param name="cells">A list of cells contained in this table.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormTable"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FormTable FormTable(int pageNumber, int columnCount, int rowCount, IReadOnlyList<FormTableCell> cells) =>
            FormTable(pageNumber, columnCount, rowCount, cells, default);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormTable"/> class.
        /// </summary>
        /// <param name="pageNumber">The 1-based number of the page in which this table is present.</param>
        /// <param name="columnCount">The number of columns in this table.</param>
        /// <param name="rowCount">The number of rows in this table.</param>
        /// <param name="cells">A list of cells contained in this table.</param>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the table.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormTable"/> instance for mocking.</returns>
        public static FormTable FormTable(int pageNumber, int columnCount, int rowCount, IReadOnlyList<FormTableCell> cells, FieldBoundingBox boundingBox)
        {
            cells = cells?.ToList();

            return new FormTable(pageNumber, columnCount, rowCount, cells, boundingBox);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormTableCell"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the text of this element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of this form element.</param>
        /// <param name="columnIndex">The column index of the cell.</param>
        /// <param name="rowIndex">The row index of the cell.</param>
        /// <param name="columnSpan">The number of columns spanned by this cell.</param>
        /// <param name="rowSpan">The number of rows spanned by this cell.</param>
        /// <param name="isHeader"><c>true</c> if this cell is a header cell. Otherwise, <c>false</c>.</param>
        /// <param name="isFooter"><c>true</c> if this cell is a footer cell. Otherwise, <c>false</c>.</param>
        /// <param name="confidence">Measures the degree of certainty of the recognition result.</param>
        /// <param name="fieldElements">A list of references to the field elements constituting this cell.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormTableCell"/> instance for mocking.</returns>
        public static FormTableCell FormTableCell(FieldBoundingBox boundingBox, int pageNumber, string text, int columnIndex, int rowIndex, int columnSpan, int rowSpan, bool isHeader, bool isFooter, float confidence, IReadOnlyList<FormElement> fieldElements)
        {
            fieldElements = fieldElements?.ToList();

            return new FormTableCell(boundingBox, pageNumber, text, columnIndex, rowIndex, columnSpan, rowSpan, isHeader, isFooter, confidence, fieldElements);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormWord"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the text of this element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of this form element.</param>
        /// <param name="confidence">Measures the degree of certainty of the recognition result.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormWord"/> instance for mocking.</returns>
        public static FormWord FormWord(FieldBoundingBox boundingBox, int pageNumber, string text, float confidence) =>
            new FormWord(boundingBox, pageNumber, text, confidence);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.RecognizedForm"/> class.
        /// </summary>
        /// <param name="formType">The type of form the model identified the submitted form to be.</param>
        /// <param name="pageRange">The range of pages this form spans.</param>
        /// <param name="fields">A dictionary of the fields recognized from the input document.</param>
        /// <param name="pages">A list of pages describing the recognized form elements present in the input document.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.RecognizedForm"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RecognizedForm RecognizedForm(string formType, FormPageRange pageRange, IReadOnlyDictionary<string, FormField> fields, IReadOnlyList<FormPage> pages) =>
            RecognizedForm(formType, pageRange, fields, pages, default, default);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.RecognizedForm"/> class.
        /// </summary>
        /// <param name="formType">The type of form the model identified the submitted form to be.</param>
        /// <param name="pageRange">The range of pages this form spans.</param>
        /// <param name="fields">A dictionary of the fields recognized from the input document.</param>
        /// <param name="pages">A list of pages describing the recognized form elements present in the input document.</param>
        /// <param name="modelId">Model identifier of model used to analyze form if not using a prebuilt model.</param>
        /// <param name="formTypeConfidence">Confidence on the type of form the labeled model identified the submitted form to be.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.RecognizedForm"/> instance for mocking.</returns>
        public static RecognizedForm RecognizedForm(string formType, FormPageRange pageRange, IReadOnlyDictionary<string, FormField> fields, IReadOnlyList<FormPage> pages, string modelId, float? formTypeConfidence)
        {
            fields = fields?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            pages = pages?.ToList();

            return new RecognizedForm(formType, pageRange, fields, pages, modelId, formTypeConfidence);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.RecognizedFormCollection"/> class.
        /// This class is a read-only wrapper around the specified list.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.RecognizedFormCollection"/> instance for mocking.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
        public static RecognizedFormCollection RecognizedFormCollection(IList<RecognizedForm> list) =>
            new RecognizedFormCollection(list);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.TextAppearance"/> class.
        /// </summary>
        /// <param name="styleName">The text line style name.</param>
        /// <param name="styleConfidence">Measures the degree of certainty of the recognition result.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.TextAppearance"/> instance for mocking.</returns>
        public static TextAppearance TextAppearance(TextStyleName styleName, float styleConfidence) =>
            new TextAppearance(styleName, styleConfidence);

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.TrainingDocumentInfo"/> class.
        /// </summary>
        /// <param name="name">Training document name.</param>
        /// <param name="pageCount">Total number of pages trained.</param>
        /// <param name="errors">List of errors.</param>
        /// <param name="status">Status of the training operation.</param>
        /// <returns>A new <see cref="Training.TrainingDocumentInfo"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TrainingDocumentInfo TrainingDocumentInfo(string name, int pageCount, IEnumerable<FormRecognizerError> errors, TrainingStatus status) =>
            TrainingDocumentInfo(name, pageCount, errors?.ToList(), status, default);

        /// <summary>
        /// Initializes a new instance of the <see cref="Training.TrainingDocumentInfo"/> class.
        /// </summary>
        /// <param name="name">Training document name.</param>
        /// <param name="pageCount">Total number of pages trained.</param>
        /// <param name="errors">List of errors.</param>
        /// <param name="status">Status of the training operation.</param>
        /// <param name="modelId">The unique identifier of the model.</param>
        /// <returns>A new <see cref="Training.TrainingDocumentInfo"/> instance for mocking.</returns>
        public static TrainingDocumentInfo TrainingDocumentInfo(string name, int pageCount, IEnumerable<FormRecognizerError> errors, TrainingStatus status, string modelId)
        {
            return new TrainingDocumentInfo(name, pageCount, errors?.ToList(), status, modelId);
        }

        #region generated methods
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
        internal static AddressValue AddressValue(string houseNumber = null, string poBox = null, string road = null, string city = null, string state = null, string postalCode = null, string countryRegion = null, string streetAddress = null)
        {
            return new AddressValue(houseNumber, poBox, road, city, state, postalCode, countryRegion, streetAddress);
        }

        /// <summary> Initializes a new instance of BoundingRegion. </summary>
        /// <param name="pageNumber"> 1-based page number of page containing the bounding region. </param>
        /// <param name="polygon"> Bounding polygon on the page, or the entire page if not specified. </param>
        /// <returns> A new <see cref="DocumentAnalysis.BoundingRegion"/> instance for mocking. </returns>
        internal static BoundingRegion BoundingRegion(int pageNumber = default, IEnumerable<float> polygon = null)
        {
            polygon ??= new List<float>();

            return new BoundingRegion(pageNumber, polygon?.ToList());
        }

        /// <summary> Initializes new instance of CustomFormModelInfo class. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="status"> Status of the model. </param>
        /// <param name="trainingStartedOn"> Date and time (UTC) when the model was created. </param>
        /// <param name="trainingCompletedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="modelName"> Optional user defined model name (max length: 1024). </param>
        /// <param name="properties"> Optional model attributes. </param>
        /// <returns> A new <see cref="Training.CustomFormModelInfo"/> instance for mocking. </returns>
        internal static CustomFormModelInfo CustomFormModelInfo(string modelId = default, CustomFormModelStatus status = default, DateTimeOffset trainingStartedOn = default, DateTimeOffset trainingCompletedOn = default, string modelName = default, CustomFormModelProperties properties = default)
        {
            return new CustomFormModelInfo(modelId, status, trainingStartedOn, trainingCompletedOn, modelName, properties);
        }

        /// <summary> Initializes new instance of TrainingDocumentInfo class. </summary>
        /// <param name="name"> Training document name. </param>
        /// <param name="pageCount"> Total number of pages trained. </param>
        /// <param name="errors"> List of errors. </param>
        /// <param name="status"> Status of the training operation. </param>
        /// <returns> A new <see cref="Training.TrainingDocumentInfo"/> instance for mocking. </returns>
        internal static TrainingDocumentInfo TrainingDocumentInfo(string name = default, int pageCount = default, IReadOnlyList<FormRecognizerError> errors = default, TrainingStatus status = default)
        {
            errors ??= new List<FormRecognizerError>();
            return new TrainingDocumentInfo(name, pageCount, errors, status);
        }

        /// <summary> Initializes new instance of CustomFormModelField class. </summary>
        /// <param name="name"> Training field name. </param>
        /// <param name="accuracy"> Estimated extraction accuracy for this field. </param>
        /// <returns> A new <see cref="Training.CustomFormModelField"/> instance for mocking. </returns>
        internal static CustomFormModelField CustomFormModelField(string name = default, float? accuracy = default)
        {
            return new CustomFormModelField(name, accuracy);
        }

        /// <summary> Initializes a new instance of CurrencyValue. </summary>
        /// <param name="amount"> Currency amount. </param>
        /// <param name="currencySymbol"> Currency symbol label, if any. </param>
        /// <returns> A new <see cref="DocumentAnalysis.CurrencyValue"/> instance for mocking. </returns>
        internal static CurrencyValue CurrencyValue(double amount = default, string currencySymbol = null)
        {
            return new CurrencyValue(amount, currencySymbol);
        }

        /// <summary> Initializes a new instance of DocumentLanguage. </summary>
        /// <param name="locale"> Detected language.  Value may an ISO 639-1 language code (ex. &quot;en&quot;, &quot;fr&quot;) or BCP 47 language tag (ex. &quot;zh-Hans&quot;). </param>
        /// <param name="spans"> Location of the text elements in the concatenated content the language applies to. </param>
        /// <param name="confidence"> Confidence of correctly identifying the language. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentLanguage"/> instance for mocking. </returns>
        internal static DocumentLanguage DocumentLanguage(string locale = null, IEnumerable<DocumentSpan> spans = null, float confidence = default)
        {
            spans ??= new List<DocumentSpan>();

            return new DocumentLanguage(locale, spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentParagraph. </summary>
        /// <param name="role"> Semantic role of the paragraph. </param>
        /// <param name="content"> Concatenated content of the paragraph in reading order. </param>
        /// <param name="boundingRegions"> Bounding regions covering the paragraph. </param>
        /// <param name="spans"> Location of the paragraph in the reading order concatenated content. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentParagraph"/> instance for mocking. </returns>
        internal static DocumentParagraph DocumentParagraph(ParagraphRole? role = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentParagraph(role, content, boundingRegions?.ToList(), spans?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentSpan. </summary>
        /// <param name="offset"> Zero-based index of the content represented by the span. </param>
        /// <param name="length"> Number of characters in the content represented by the span. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentSpan"/> instance for mocking. </returns>
        internal static DocumentSpan DocumentSpan(int offset = default, int length = default)
        {
            return new DocumentSpan(offset, length);
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
        internal static DocumentTableCell DocumentTableCell(DocumentTableCellKind? kind = null, int rowIndex = default, int columnIndex = default, int? rowSpan = null, int? columnSpan = null, string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentTableCell(kind, rowIndex, columnIndex, rowSpan, columnSpan, content, boundingRegions?.ToList(), spans?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentKeyValuePair. </summary>
        /// <param name="key"> Field label of the key-value pair. </param>
        /// <param name="value"> Field value of the key-value pair. </param>
        /// <param name="confidence"> Confidence of correctly extracting the key-value pair. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentKeyValuePair"/> instance for mocking. </returns>
        internal static DocumentKeyValuePair DocumentKeyValuePair(DocumentKeyValueElement key = null, DocumentKeyValueElement value = null, float confidence = default)
        {
            return new DocumentKeyValuePair(key, value, confidence);
        }

        /// <summary> Initializes a new instance of DocumentKeyValueElement. </summary>
        /// <param name="content"> Concatenated content of the key-value element in reading order. </param>
        /// <param name="boundingRegions"> Bounding regions covering the key-value element. </param>
        /// <param name="spans"> Location of the key-value element in the reading order concatenated content. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentKeyValueElement"/> instance for mocking. </returns>
        internal static DocumentKeyValueElement DocumentKeyValueElement(string content = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentKeyValueElement(content, boundingRegions?.ToList(), spans?.ToList());
        }

        /// <summary> Initializes a new instance of AnalyzedDocument. </summary>
        /// <param name="documentType"> Document type. </param>
        /// <param name="boundingRegions"> Bounding regions covering the document. </param>
        /// <param name="spans"> Location of the document in the reading order concatenated content. </param>
        /// <param name="fields"> Dictionary of named field values. </param>
        /// <param name="confidence"> Confidence of correctly extracting the document. </param>
        /// <returns> A new <see cref="DocumentAnalysis.AnalyzedDocument"/> instance for mocking. </returns>
        internal static AnalyzedDocument AnalyzedDocument(string documentType = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null, IReadOnlyDictionary<string, DocumentField> fields = null, float confidence = default)
        {
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();
            fields ??= new Dictionary<string, DocumentField>();

            return new AnalyzedDocument(documentType, boundingRegions?.ToList(), spans?.ToList(), fields, confidence);
        }

        /// <summary> Initializes a new instance of DocumentStyle. </summary>
        /// <param name="isHandwritten"> Is content handwritten?. </param>
        /// <param name="spans"> Location of the text elements in the concatenated content the style applies to. </param>
        /// <param name="confidence"> Confidence of correctly identifying the style. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentStyle"/> instance for mocking. </returns>
        internal static DocumentStyle DocumentStyle(bool? isHandwritten = null, IEnumerable<DocumentSpan> spans = null, float confidence = default)
        {
            spans ??= new List<DocumentSpan>();

            return new DocumentStyle(isHandwritten, spans?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of DocumentModelBuildOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="apiVersion"> API version used to create this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="jsonError"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelBuildOperationDetails"/> instance for mocking. </returns>
        internal static DocumentModelBuildOperationDetails DocumentModelBuildOperationDetails(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, DocumentOperationKind kind = default, Uri resourceLocation = null, string apiVersion = null, IReadOnlyDictionary<string, string> tags = null, JsonElement jsonError = default, DocumentModelDetails result = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelBuildOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, apiVersion, tags, jsonError, result);
        }

        /// <summary> Initializes a new instance of DocumentModelComposeOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="apiVersion"> API version used to create this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="jsonError"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelComposeOperationDetails"/> instance for mocking. </returns>
        internal static DocumentModelComposeOperationDetails DocumentModelComposeOperationDetails(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, DocumentOperationKind kind = default, Uri resourceLocation = null, string apiVersion = null, IReadOnlyDictionary<string, string> tags = null, JsonElement jsonError = default, DocumentModelDetails result = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelComposeOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, apiVersion, tags, jsonError, result);
        }

        /// <summary> Initializes a new instance of DocumentModelCopyToOperationDetails. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="apiVersion"> API version used to create this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="jsonError"> Encountered error. </param>
        /// <param name="result"> Operation result upon success. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelCopyToOperationDetails"/> instance for mocking. </returns>
        internal static DocumentModelCopyToOperationDetails DocumentModelCopyToOperationDetails(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, DocumentOperationKind kind = default, Uri resourceLocation = null, string apiVersion = null, IReadOnlyDictionary<string, string> tags = null, JsonElement jsonError = default, DocumentModelDetails result = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelCopyToOperationDetails(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, apiVersion, tags, jsonError, result);
        }

        /// <summary> Initializes a new instance of DocumentModelDetails. </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="description"> Document model description. </param>
        /// <param name="createdOn"> Date and time (UTC) when the document model was created. </param>
        /// <param name="apiVersion"> API version used to create this document model. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the document model. </param>
        /// <param name="docTypes"> Supported document types. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelDetails"/> instance for mocking. </returns>
        internal static DocumentModelDetails DocumentModelDetails(string modelId = null, string description = null, DateTimeOffset createdOn = default, string apiVersion = null, IReadOnlyDictionary<string, string> tags = null, IReadOnlyDictionary<string, DocumentTypeDetails> docTypes = null)
        {
            tags ??= new Dictionary<string, string>();
            docTypes ??= new Dictionary<string, DocumentTypeDetails>();

            return new DocumentModelDetails(modelId, description, createdOn, apiVersion, tags, docTypes);
        }

        /// <summary> Initializes a new instance of DocumentModelSummary. </summary>
        /// <param name="modelId"> Unique model name. </param>
        /// <param name="description"> Model description. </param>
        /// <param name="createdOn"> Date and time (UTC) when the model was created. </param>
        /// <param name="apiVersion"> API version used to create this model. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentModelSummary"/> instance for mocking. </returns>
        internal static DocumentModelSummary DocumentModelSummary(string modelId = null, string description = null, DateTimeOffset createdOn = default, string apiVersion = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DocumentModelSummary(modelId, description, createdOn, apiVersion, tags);
        }

        /// <summary> Initializes a new instance of OperationSummary. </summary>
        /// <param name="operationId"> Operation ID. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentCompleted"> Operation progress (0-100). </param>
        /// <param name="createdOn"> Date and time (UTC) when the operation was created. </param>
        /// <param name="lastUpdatedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="kind"> Type of operation. </param>
        /// <param name="resourceLocation"> URL of the resource targeted by this operation. </param>
        /// <param name="apiVersion"> API version used to create this operation. </param>
        /// <param name="tags"> List of key-value tag attributes associated with the model. </param>
        /// <returns> A new <see cref="DocumentAnalysis.OperationSummary"/> instance for mocking. </returns>
        internal static OperationSummary OperationSummary(string operationId = null, DocumentOperationStatus status = default, int? percentCompleted = null, DateTimeOffset createdOn = default, DateTimeOffset lastUpdatedOn = default, DocumentOperationKind kind = default, Uri resourceLocation = null, string apiVersion = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new OperationSummary(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, apiVersion, tags);
        }

        /// <summary> Initializes a new instance of DocumentFieldSchema. </summary>
        /// <param name="type"> Semantic data type of the field value. </param>
        /// <param name="description"> Field description. </param>
        /// <param name="example"> Example field content. </param>
        /// <param name="items"> Field type schema of each array element. </param>
        /// <param name="properties"> Named sub-fields of the object field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentFieldSchema"/> instance for mocking. </returns>
        internal static DocumentFieldSchema DocumentFieldSchema(DocumentFieldType type = default, string description = null, string example = null, DocumentFieldSchema items = null, IReadOnlyDictionary<string, DocumentFieldSchema> properties = null)
        {
            properties ??= new Dictionary<string, DocumentFieldSchema>();

            return new DocumentFieldSchema(type, description, example, items, properties);
        }

        /// <summary> Initializes a new instance of DocumentLine. </summary>
        /// <param name="content"> Concatenated content of the contained elements in reading order. </param>
        /// <param name="polygon"> Bounding polygon of the line. </param>
        /// <param name="spans"> Location of the line in the reading order concatenated content. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentLine"/> instance for mocking. </returns>
        internal static DocumentLine DocumentLine(string content = null, IEnumerable<float> polygon = null, IEnumerable<DocumentSpan> spans = null)
        {
            polygon ??= new List<float>();
            spans ??= new List<DocumentSpan>();

            return new DocumentLine(content, polygon?.ToList(), spans?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentTable. </summary>
        /// <param name="rowCount"> Number of rows in the table. </param>
        /// <param name="columnCount"> Number of columns in the table. </param>
        /// <param name="cells"> Cells contained within the table. </param>
        /// <param name="boundingRegions"> Bounding regions covering the table. </param>
        /// <param name="spans"> Location of the table in the reading order concatenated content. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentTable"/> instance for mocking. </returns>
        internal static DocumentTable DocumentTable(int rowCount = default, int columnCount = default, IEnumerable<DocumentTableCell> cells = null, IEnumerable<BoundingRegion> boundingRegions = null, IEnumerable<DocumentSpan> spans = null)
        {
            cells ??= new List<DocumentTableCell>();
            boundingRegions ??= new List<BoundingRegion>();
            spans ??= new List<DocumentSpan>();

            return new DocumentTable(rowCount, columnCount, cells?.ToList(), boundingRegions?.ToList(), spans?.ToList());
        }

        /// <summary> Initializes a new instance of DocumentWord. </summary>
        /// <param name="content"> Text content of the word. </param>
        /// <param name="polygon"> Bounding polygon of the word. </param>
        /// <param name="span"> Location of the word in the reading order concatenated content. </param>
        /// <param name="confidence"> Confidence of correctly extracting the word. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentWord"/> instance for mocking. </returns>
        internal static DocumentWord DocumentWord(string content = null, IEnumerable<float> polygon = null, DocumentSpan span = default, float confidence = default)
        {
            polygon ??= new List<float>();

            return new DocumentWord(content, polygon?.ToList(), span, confidence);
        }

        /// <summary> Initializes a new instance of DocumentTypeDetails. </summary>
        /// <param name="description"> Model description. </param>
        /// <param name="buildMode"> Custom model build mode. </param>
        /// <param name="fieldSchema"> Description of the document semantic schema using a JSON Schema style syntax. </param>
        /// <param name="fieldConfidence"> Estimated confidence for each field. </param>
        /// <returns> A new <see cref="DocumentAnalysis.DocumentTypeDetails"/> instance for mocking. </returns>
        internal static DocumentTypeDetails DocumentTypeDetails(string description = null, DocumentBuildMode? buildMode = null, IReadOnlyDictionary<string, DocumentFieldSchema> fieldSchema = null, IReadOnlyDictionary<string, float> fieldConfidence = null)
        {
            fieldSchema ??= new Dictionary<string, DocumentFieldSchema>();
            fieldConfidence ??= new Dictionary<string, float>();

            return new DocumentTypeDetails(description, buildMode, fieldSchema, fieldConfidence);
        }

        /// <summary> Initializes a new instance of ResourceDetails. </summary>
        /// <param name="customDocumentModelCount"> Number of custom models in the current resource. </param>
        /// <param name="customDocumentModelLimit"> Maximum number of custom models supported in the current resource. </param>
        /// <returns> A new <see cref="DocumentAnalysis.ResourceDetails"/> instance for mocking. </returns>
        internal static ResourceDetails ResourceDetails(int customDocumentModelCount = default, int customDocumentModelLimit = default)
        {
            return new ResourceDetails(customDocumentModelCount, customDocumentModelLimit);
        }

        #endregion
    }
}
