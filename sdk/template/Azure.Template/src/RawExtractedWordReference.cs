// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Azure.AI.FormRecognizer
//{
//    internal readonly struct RawExtractedWordReference
//    {
//        internal RawExtractedWordReference(string reference)
//        {
//            // TODO: Add additional validations here.

//            // Example: the following should result in LineIndex = 7, WordIndex = 12
//            // "#/readResults/3/lines/7/words/12"
//            string[] segments = reference.Split('/');

//#pragma warning disable CA1305 // Specify IFormatProvider
//            LineIndex = int.Parse(segments[4]);
//            WordIndex = int.Parse(segments[6]);
//#pragma warning restore CA1305 // Specify IFormatProvider
//        }

//        public int LineIndex { get; }
//        public int WordIndex { get; }

//        // TODO: Remove
//        public override string ToString()
//        {
//            return $"({LineIndex}, {WordIndex})";
//            //return $"{ReferenceString}";
//        }
//    }
//}
