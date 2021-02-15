// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a field recognized in an input form.
    /// </summary>
    public class FormField
    {
        internal FormField(string name, int pageNumber, KeyValuePair field, IReadOnlyList<ReadResult> readResults)
        {
            Confidence = field.Confidence;
            Name = name;

            FieldBoundingBox labelBoundingBox = field.Key.BoundingBox == null ? default : new FieldBoundingBox(field.Key.BoundingBox);
            IReadOnlyList<FormElement> labelFormElement = field.Key.Elements != null
                ? ConvertTextReferences(field.Key.Elements, readResults)
                : new List<FormElement>();
            LabelData = new FieldData(labelBoundingBox, pageNumber, field.Key.Text, labelFormElement);

            FieldBoundingBox valueBoundingBox = field.Value.BoundingBox == null ? default : new FieldBoundingBox(field.Value.BoundingBox);
            IReadOnlyList<FormElement> valueFormElement = field.Value.Elements != null
                ? ConvertTextReferences(field.Value.Elements, readResults)
                : new List<FormElement>();
            ValueData = new FieldData(valueBoundingBox, pageNumber, field.Value.Text, valueFormElement);

            Value = new FieldValue(new FieldValue_internal(field.Value.Text), readResults);
        }

        internal FormField(string name, FieldValue_internal fieldValue, IReadOnlyList<ReadResult> readResults)
        {
            Confidence = fieldValue.Confidence ?? Constants.DefaultConfidenceValue;
            Name = name;
            LabelData = null;

            // Bounding box, page and text are not returned by the service in two scenarios:
            //   - When this field is global and not associated with a specific page (e.g. ReceiptType).
            //   - When this field is a collection, such as a list or dictionary.
            //
            // In these scenarios we do not set a ValueData.

            if (fieldValue.BoundingBox.Count == 0 && fieldValue.Page == null && fieldValue.Text == null)
            {
                ValueData = null;
            }
            else
            {
                IReadOnlyList<FormElement> fieldElements = ConvertTextReferences(fieldValue.Elements, readResults);

                FieldBoundingBox boundingBox = new FieldBoundingBox(fieldValue.BoundingBox);

                ValueData = new FieldData(boundingBox, fieldValue.Page.Value, fieldValue.Text, fieldElements);
            }

            Value = new FieldValue(fieldValue, readResults);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormField"/> class.
        /// </summary>
        /// <param name="name">Canonical name; uniquely identifies a field within the form.</param>
        /// <param name="labelData">Contains the text, bounding box and content of the label of the field in the form.</param>
        /// <param name="valueData">Contains the text, bounding box and content of the value of the field in the form.</param>
        /// <param name="value">The strongly-typed value of this field.</param>
        /// <param name="confidence">Measures the degree of certainty of the recognition result.</param>
        internal FormField(string name, FieldData labelData, FieldData valueData, FieldValue value, float confidence)
        {
            Name = name;
            LabelData = labelData;
            ValueData = valueData;
            Value = value;
            Confidence = confidence;
        }

        /// <summary>
        /// Canonical name; uniquely identifies a field within the form.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Contains the text, bounding box and content of the label of the field in the form.
        /// </summary>
        public FieldData LabelData { get; }

        /// <summary>
        /// Contains the text, bounding box and content of the value of the field in the form.
        /// </summary>
        public FieldData ValueData { get; }

        /// <summary>
        /// The strongly-typed value of this <see cref="FormField"/>.
        /// </summary>
        public FieldValue Value { get; }

        /// <summary>
        /// Measures the degree of certainty of the recognition result. Value is between [0.0, 1.0].
        /// </summary>
        public float Confidence { get; }

        internal static IReadOnlyList<FormElement> ConvertTextReferences(IReadOnlyList<string> references, IReadOnlyList<ReadResult> readResults)
        {
            List<FormElement> FormElement = new List<FormElement>();
            foreach (var reference in references)
            {
                FormElement.Add(ResolveTextReference(readResults, reference));
            }
            return FormElement;
        }

        private static Regex _wordRegex = new Regex(@"/readResults/(?<pageIndex>\d*)/lines/(?<lineIndex>\d*)/words/(?<wordIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));
        private static Regex _lineRegex = new Regex(@"/readResults/(?<pageIndex>\d*)/lines/(?<lineIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));
        private static Regex _selectionMarkRegex = new Regex(@"/readResults/(?<pageIndex>\d*)/selectionMarks/(?<selectionMarkIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        private static FormElement ResolveTextReference(IReadOnlyList<ReadResult> readResults, string reference)
        {
            // Example: the following should result in PageIndex = 3, LineIndex = 7, WordIndex = 12
            // "#/analyzeResult/readResults/3/lines/7/words/12" from DocumentResult
            // "#/readResults/3/lines/7/words/12" from PageResult

            // Word Reference
            var wordMatch = _wordRegex.Match(reference);
            if (wordMatch.Success && wordMatch.Groups.Count == 4)
            {
                int pageIndex = int.Parse(wordMatch.Groups["pageIndex"].Value, CultureInfo.InvariantCulture);
                int lineIndex = int.Parse(wordMatch.Groups["lineIndex"].Value, CultureInfo.InvariantCulture);
                int wordIndex = int.Parse(wordMatch.Groups["wordIndex"].Value, CultureInfo.InvariantCulture);

                return new FormWord(readResults[pageIndex].Lines[lineIndex].Words[wordIndex], pageIndex + 1);
            }

            // Line Reference
            var lineMatch = _lineRegex.Match(reference);
            if (lineMatch.Success && lineMatch.Groups.Count == 3)
            {
                int pageIndex = int.Parse(lineMatch.Groups["pageIndex"].Value, CultureInfo.InvariantCulture);
                int lineIndex = int.Parse(lineMatch.Groups["lineIndex"].Value, CultureInfo.InvariantCulture);

                return new FormLine(readResults[pageIndex].Lines[lineIndex], pageIndex + 1);
            }

            // Selection Mark Reference
            var selectionMarkMatch = _selectionMarkRegex.Match(reference);
            if (selectionMarkMatch.Success && selectionMarkMatch.Groups.Count == 3)
            {
                int pageIndex = int.Parse(selectionMarkMatch.Groups["pageIndex"].Value, CultureInfo.InvariantCulture);
                int selectionMark = int.Parse(selectionMarkMatch.Groups["selectionMarkIndex"].Value, CultureInfo.InvariantCulture);

                return new FormSelectionMark(readResults[pageIndex].SelectionMarks[selectionMark], pageIndex + 1);
            }

            throw new InvalidOperationException($"Failed to parse element reference: {reference}");
        }
    }
}
