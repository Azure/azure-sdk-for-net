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
        internal FormField(string name, int pageNumber, KeyValuePair_internal field, IReadOnlyList<ReadResult_internal> readResults)
        {
            Confidence = field.Confidence;
            Name = name;

            BoundingBox labelBoundingBox = field.Key.BoundingBox == null ? default : new BoundingBox(field.Key.BoundingBox);
            IReadOnlyList<FormContent> labelFormContent = default;
            if (field.Key.Elements != null)
            {
                labelFormContent = ConvertTextReferences(field.Key.Elements, readResults);
            }
            LabelText = new FieldText(field.Key.Text, pageNumber, labelBoundingBox, labelFormContent);

            BoundingBox valueBoundingBox = field.Value.BoundingBox == null ? default : new BoundingBox(field.Value.BoundingBox);
            IReadOnlyList<FormContent> valueFormContent = default;
            if (field.Value.Elements != null)
            {
                valueFormContent = ConvertTextReferences(field.Value.Elements, readResults);
            }
            ValueText = new FieldText(field.Value.Text, pageNumber, valueBoundingBox, valueFormContent);

            Value = new FieldValue(new FieldValue_internal(field.Value.Text), readResults);
        }

        internal FormField(string name, FieldValue_internal fieldValue, IReadOnlyList<ReadResult_internal> readResults)
        {
            Confidence = fieldValue.Confidence ?? Constants.DefaultConfidenceValue;
            Name = name;
            LabelText = null;

            IReadOnlyList<FormContent> formContent = default;
            if (fieldValue.Elements != null)
            {
                formContent = ConvertTextReferences(fieldValue.Elements, readResults);
            }

            // TODO: FormEnum<T> ?
            BoundingBox boundingBox = fieldValue.BoundingBox == null ? default : new BoundingBox(fieldValue.BoundingBox);

            ValueText = new FieldText(fieldValue.Text, fieldValue.Page ?? 0, boundingBox, formContent);
            Value = new FieldValue(fieldValue, readResults);
        }

        /// <summary>
        /// Canonical name; uniquely identifies a field within the form.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Contains the text, bounding box and content of the label of the field in the form.
        /// </summary>
        public FieldText LabelText { get; internal set; }

        /// <summary>
        /// Contains the text, bounding box and content of the value of the field in the form.
        /// </summary>
        public FieldText ValueText { get; internal set; }

        /// <summary>
        /// The strongly-typed value of this <see cref="FormField"/>.
        /// </summary>
        public FieldValue Value { get; internal set; }

        /// <summary>
        /// Measures the degree of certainty of the recognition result. Value is between [0.0, 1.0].
        /// </summary>
        public float Confidence { get; }

        internal static IReadOnlyList<FormContent> ConvertTextReferences(IReadOnlyList<string> references, IReadOnlyList<ReadResult_internal> readResults)
        {
            List<FormContent> formContent = new List<FormContent>();
            foreach (var reference in references)
            {
                formContent.Add(ResolveTextReference(readResults, reference));
            }
            return formContent;
        }

        private static Regex _wordRegex = new Regex(@"/readResults/(?<pageIndex>\d*)/lines/(?<lineIndex>\d*)/words/(?<wordIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));
        private static Regex _lineRegex = new Regex(@"/readResults/(?<pageIndex>\d*)/lines/(?<lineIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        private static FormContent ResolveTextReference(IReadOnlyList<ReadResult_internal> readResults, string reference)
        {
            // TODO: Add additional validations here.
            // https://github.com/Azure/azure-sdk-for-net/issues/10363

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

            throw new InvalidOperationException($"Failed to parse element reference: {reference}");
        }
    }
}
