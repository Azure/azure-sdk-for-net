// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormField
    {
#pragma warning disable CA1801
        internal FormField(KeyValuePair_internal field, ReadResult_internal readResult)
        {
#pragma warning restore CA1801
            //Confidence = field.Confidence;

            //Name = field.Key.Text;
            //NameBoundingBox = new BoundingBox(field.Key.BoundingBox);

            //if (field.Key.Elements != null)
            //{
            //    NameTextElements = ConvertTextReferences(readResult, field.Key.Elements);
            //}

            //Value = field.Value.Text;
            //ValueBoundingBox = new BoundingBox(field.Value.BoundingBox);

            //if (field.Value.Elements != null)
            //{
            //    ValueTextElements = ConvertTextReferences(readResult, field.Value.Elements);
            //}
        }

        internal FormField(string name, FieldValue_internal fieldValue, IReadOnlyList<ReadResult_internal> readResults)
        {
            Confidence = fieldValue.Confidence ?? 1.0f;
            Name = name;
            FieldLabel = null;
            ValueText = new FieldText(fieldValue.Text, new BoundingBox(fieldValue.BoundingBox), null /*fieldValue.Elements  TODO */);
            Value = new FieldValue(fieldValue);
        }

        /// <summary>
        /// Canonical name; uniquely identifies a field within the form.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Text from the form that labels the form field.
        /// </summary>
        public FieldText FieldLabel { get; internal set; }

        /// <summary>
        /// </summary>
        public FieldText ValueText { get; internal set; }

        /// <summary>
        /// </summary>
        public FieldValue Value { get; internal set; }

        /// <summary>
        /// </summary>
        public float Confidence { get; }

        //// TODO: Refactor to move OCR code to a common file, rather than it living in this file.
        //internal static IReadOnlyList<FormTextElement> ConvertTextReferences(ReadResult_internal readResult, ICollection<string> references)
        //{
        //    List<FormTextElement> extractedTexts = new List<FormTextElement>();
        //    foreach (var reference in references)
        //    {
        //        extractedTexts.Add(ResolveTextReference(readResult, reference));
        //    }
        //    return extractedTexts;
        //}

        //internal static IReadOnlyList<FormTextElement> ConvertTextReferences(IList<ReadResult_internal> readResults, ICollection<string> references)
        //{
        //    List<FormTextElement> extractedTexts = new List<FormTextElement>();
        //    foreach (var reference in references)
        //    {
        //        extractedTexts.Add(ResolveTextReference(readResults, reference));
        //    }
        //    return extractedTexts;
        //}

        //private const string SegmentReadResults = "readResults";
        //private const string SegmentLines = "lines";
        //private const string SegmentWords = "words";

        //        private static FormTextElement ResolveTextReference(ReadResult_internal readResult, string reference)
        //        {
        //            // TODO: Add additional validations here.
        //            // https://github.com/Azure/azure-sdk-for-net/issues/10363

        //            // Example: the following should result in LineIndex = 7, WordIndex = 12
        //            // "#/readResults/3/lines/7/words/12"
        //            string[] segments = reference.Split('/');

        //            var lineIndex = int.Parse(segments[4], CultureInfo.InvariantCulture);
        //            var wordIndex = int.Parse(segments[6], CultureInfo.InvariantCulture);

        //            // TODO: Support case where text reference is lines only, without word segment
        //            // https://github.com/Azure/azure-sdk-for-net/issues/10364
        //            return new FormTextElement(readResult.Lines.ToList()[lineIndex].Words.ToList()[wordIndex]);

        //            // Code from Chris Stone below
        //            //if (!string.IsNullOrEmpty(reference) && reference.Length > 2 && reference[0] == '#')
        //            //{
        //            //    // offset by 2 to skip the '#/' prefix
        //            //    var segments = reference.Substring(2).Split('/');

        //            //    // must have an even number of segments
        //            //    if (segments.Length % 2 == 0)
        //            //    {
        //            //        int offset;
        //            //        for (var i = 0; i < segments.Length; i += 2)
        //            //        {
        //            //            // the next segment must be an integer
        //            //            if (int.TryParse(segments[i + 1], out offset))
        //            //            {
        //            //                var segment = segments[i];

        //            //                // We assume we're already on the correct page element
        //            //                //// this is the root page element
        //            //                //if (segment == SegmentReadResults)
        //            //                //{
        //            //                //    readResult = results[offset];
        //            //                //}
        //            //
        //            //                // this is a text element
        //            //                if (readResult != default)
        //            //                {
        //            //                    if (segment == SegmentLines)
        //            //                    {
        //            //                        textElement = new RawExtractedLine(readResult.Lines.ToList()[offset]);
        //            //                    }
        //            //                    else if (segment == SegmentWords && textElement is RawExtractedLine)
        //            //                    {
        //            //                        textElement = (textElement as RawExtractedLine).Words[offset];
        //            //                    }
        //            //                }
        //            //            }
        //            //        }
        //            //    }
        //            //}
        //        }

        //        private static FormTextElement ResolveTextReference(IList<ReadResult_internal> readResults, string reference)
        //        {
        //            // TODO: Add additional validations here.
        //            // https://github.com/Azure/azure-sdk-for-net/issues/10363

        //            // Example: the following should result in LineIndex = 7, WordIndex = 12
        //            // "#/readResults/3/lines/7/words/12"
        //            string[] segments = reference.Split('/');

        //#pragma warning disable CA1305 // Specify IFormatProvider
        //            var pageIndex = int.Parse(segments[2]);
        //            var lineIndex = int.Parse(segments[4]);
        //            var wordIndex = int.Parse(segments[6]);
        //#pragma warning restore CA1305 // Specify IFormatProvider

        //            // TODO: Support case where text reference is lines only, without word segment
        //            // https://github.com/Azure/azure-sdk-for-net/issues/10364
        //            return new WordTextElement(readResults[pageIndex].Lines[lineIndex].Words[wordIndex]);
        //        }
    }
}
