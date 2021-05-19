// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Azure.AI.FormRecognizer.Training;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A factory that builds Azure.AI.FormRecognizer model types used for mocking.
    /// </summary>
    public static class FormRecognizerModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Training.AccountProperties"/> class.
        /// </summary>
        /// <param name="customModelCount">The current count of trained custom models.</param>
        /// <param name="customModelLimit">The maximum number of models that can be trained for this account.</param>
        /// <returns>A new <see cref="Training.AccountProperties"/> instance for mocking.</returns>
        public static AccountProperties AccountProperties(int customModelCount, int customModelLimit) =>
            new AccountProperties(customModelCount, customModelLimit);

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
        public static CustomFormModel CustomFormModel(string modelId, CustomFormModelStatus status, DateTimeOffset trainingStartedOn, DateTimeOffset trainingCompletedOn, IReadOnlyList<CustomFormSubmodel> submodels, IReadOnlyList<TrainingDocumentInfo> trainingDocuments, IReadOnlyList<FormRecognizerError> errors)
        {
            submodels = submodels?.ToList();
            trainingDocuments = trainingDocuments?.ToList();
            errors = errors?.ToList();

            return new CustomFormModel(modelId, status, trainingStartedOn, trainingCompletedOn, submodels, trainingDocuments, errors, default, default);
        }

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
            new CustomFormModelInfo(modelId, status, trainingStartedOn, trainingCompletedOn, default, default);

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
        public static CustomFormSubmodel CustomFormSubmodel(string formType, float? accuracy, IReadOnlyDictionary<string, CustomFormModelField> fields)
        {
            fields = fields?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return new CustomFormSubmodel(formType, accuracy, fields, default);
        }

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
            new FieldValue(value, isPhoneNumber: false);

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
            new FieldValue(value, isPhoneNumber: true);

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
        public static FormLine FormLine(FieldBoundingBox boundingBox, int pageNumber, string text, IReadOnlyList<FormWord> words)
        {
            words = words?.ToList();

            return new FormLine(boundingBox, pageNumber, text, words);
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
        public static FormPage FormPage(int pageNumber, float width, float height, float textAngle, LengthUnit unit, IReadOnlyList<FormLine> lines, IReadOnlyList<FormTable> tables)
        {
            lines = lines?.ToList();
            tables = tables?.ToList();

            return new FormPage(pageNumber, width, height, textAngle, unit, lines, tables, default);
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
        /// Initializes a new instance of the <see cref="FormRecognizer.Models.FormTable"/> class.
        /// </summary>
        /// <param name="pageNumber">The 1-based number of the page in which this table is present.</param>
        /// <param name="columnCount">The number of columns in this table.</param>
        /// <param name="rowCount">The number of rows in this table.</param>
        /// <param name="cells">A list of cells contained in this table.</param>
        /// <returns>A new <see cref="FormRecognizer.Models.FormTable"/> instance for mocking.</returns>
        public static FormTable FormTable(int pageNumber, int columnCount, int rowCount, IReadOnlyList<FormTableCell> cells)
        {
            cells = cells?.ToList();

            return new FormTable(pageNumber, columnCount, rowCount, cells);
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
        public static RecognizedForm RecognizedForm(string formType, FormPageRange pageRange, IReadOnlyDictionary<string, FormField> fields, IReadOnlyList<FormPage> pages)
        {
            fields = fields?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            pages = pages?.ToList();

            return new RecognizedForm(formType, pageRange, fields, pages, default, default);
        }

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
        /// Initializes a new instance of the <see cref="Training.TrainingDocumentInfo"/> class.
        /// </summary>
        /// <param name="name">Training document name.</param>
        /// <param name="pageCount">Total number of pages trained.</param>
        /// <param name="errors">List of errors.</param>
        /// <param name="status">Status of the training operation.</param>
        /// <returns>A new <see cref="Training.TrainingDocumentInfo"/> instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TrainingDocumentInfo TrainingDocumentInfo(string name, int pageCount, IEnumerable<FormRecognizerError> errors, TrainingStatus status)
        {
            return new TrainingDocumentInfo(name, pageCount, errors?.ToList(), status, default);
        }

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
    }
}
