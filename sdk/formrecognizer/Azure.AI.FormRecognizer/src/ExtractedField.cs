// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedField
    {
        internal ExtractedField(KeyValuePair_internal field, ReadResult_internal readResult)
        {
            // Unsupervised
            Confidence = field.Confidence;
            Label = field.Key.Text;

            LabelBoundingBox = field.Key.BoundingBox == null ? null : new BoundingBox(field.Key.BoundingBox);
            if (field.Key.Elements != null)
            {
                LabelRawExtractedItems = ConvertTextReferences(readResult, field.Key.Elements);
            }

            Value = field.Value.Text;
            ValueBoundingBox = new BoundingBox(field.Value.BoundingBox);

            if (field.Value.Elements != null)
            {
                ValueRawExtractedItems = ConvertTextReferences(readResult, field.Value.Elements);
            }
        }

        internal ExtractedField(KeyValuePair<string, FieldValue_internal> field)
        {
            // Supervised
            Confidence = field.Value.Confidence;
            Label = field.Key;
            Value = field.Value.Text;
            ValueBoundingBox = new BoundingBox(field.Value.BoundingBox);
        }

        // TODO: Why can this be nullable on FieldValue.Confidence?
        // https://github.com/Azure/azure-sdk-for-net/issues/10378
        public float? Confidence { get; internal set; }
        public string Label { get; internal set; }

        // TODO: Make this nullable to indicate that this is an optional field.
        // https://github.com/Azure/azure-sdk-for-net/issues/10361
        // Not currently supported for Track2 libraries.
        public BoundingBox LabelBoundingBox { get; internal set; }

        public string Value { get; internal set; }
        public BoundingBox ValueBoundingBox { get; internal set; }

        public IReadOnlyList<RawExtractedItem> LabelRawExtractedItems { get; internal set; }
        public IReadOnlyList<RawExtractedItem> ValueRawExtractedItems { get; internal set; }

        // TODO: Refactor to move OCR code to a common file, rather than it living in this file.
        internal static IReadOnlyList<RawExtractedItem> ConvertTextReferences(ReadResult_internal readResult, ICollection<string> references)
        {
            List<RawExtractedItem> extractedTexts = new List<RawExtractedItem>();
            foreach (var reference in references)
            {
                extractedTexts.Add(ResolveTextReference(readResult, reference));
            }
            return extractedTexts;
        }

        //private const string SegmentReadResults = "readResults";
        //private const string SegmentLines = "lines";
        //private const string SegmentWords = "words";

        private static RawExtractedItem ResolveTextReference(ReadResult_internal readResult, string reference)
        {
            // TODO: Add additional validations here.
            // https://github.com/Azure/azure-sdk-for-net/issues/10363

            // Example: the following should result in LineIndex = 7, WordIndex = 12
            // "#/readResults/3/lines/7/words/12"
            string[] segments = reference.Split('/');

#pragma warning disable CA1305 // Specify IFormatProvider
            var lineIndex = int.Parse(segments[4]);
            var wordIndex = int.Parse(segments[6]);
#pragma warning restore CA1305 // Specify IFormatProvider

            // TODO: Support case where text reference is lines only, without word segment
            // https://github.com/Azure/azure-sdk-for-net/issues/10364
            return new RawExtractedWord(readResult.Lines.ToList()[lineIndex].Words.ToList()[wordIndex]);

            // Code from Chris Stone below
            //if (!string.IsNullOrEmpty(reference) && reference.Length > 2 && reference[0] == '#')
            //{
            //    // offset by 2 to skip the '#/' prefix
            //    var segments = reference.Substring(2).Split('/');

            //    // must have an even number of segments
            //    if (segments.Length % 2 == 0)
            //    {
            //        int offset;
            //        for (var i = 0; i < segments.Length; i += 2)
            //        {
            //            // the next segment must be an integer
            //            if (int.TryParse(segments[i + 1], out offset))
            //            {
            //                var segment = segments[i];

            //                // We assume we're already on the correct page element
            //                //// this is the root page element
            //                //if (segment == SegmentReadResults)
            //                //{
            //                //    readResult = results[offset];
            //                //}
            //
            //                // this is a text element
            //                if (readResult != default)
            //                {
            //                    if (segment == SegmentLines)
            //                    {
            //                        textElement = new RawExtractedLine(readResult.Lines.ToList()[offset]);
            //                    }
            //                    else if (segment == SegmentWords && textElement is RawExtractedLine)
            //                    {
            //                        textElement = (textElement as RawExtractedLine).Words[offset];
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}
