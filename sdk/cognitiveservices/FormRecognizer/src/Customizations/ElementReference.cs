using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.CognitiveServices.FormRecognizer.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class ElementReference {
        private string _resolvedRefProperty = null;
        private int _pageIndex;
        private int _lineIndex;
        private int _wordIndex;

        /// <summary>
        /// Number of the page containing the element.
        /// </summary>
        public int Page { get { Resolve(); return _pageIndex + 1; } }

        /// <summary>
        /// Index of the page containing the element (0-indexed).
        /// </summary>
        public int PageIndex { get { Resolve(); return _pageIndex; } }

        /// <summary>
        /// Index of the line within the page containing the element (0-indexed).
        /// </summary>
        public int LineIndex { get { Resolve(); return _lineIndex; } }

        /// <summary>
        /// Index of the word within the line containing the element (0-indexed).
        /// </summary>
        public int WordIndex { get { Resolve(); return _wordIndex; } }

        /// <summary>
        /// Returns the word referenced by the JSON pointer element reference.
        /// </summary>
        public Word ResolveWord(ReadReceiptResult result)
        {
            try
            {
                return result.RecognitionResults[PageIndex].Lines[LineIndex].Words[WordIndex];
            }
            catch (Exception e)
            {
                //throw new ArgumentException("Invalid element reference.");
                throw new ArgumentException("Invalid element reference, {0}", e);
            }
        }

        private void Resolve()
        {
            if (_resolvedRefProperty != RefProperty)
            {
                var match = Regex.Match(RefProperty, @"^#/recognitionResults/(\d+)/lines/(\d+)/words/(\d+)$");
                if (!match.Success)
                {
                    throw new ArgumentException("Invalid element reference.");
                }                    
                _pageIndex = int.Parse(match.Groups[1].Value);
                _lineIndex = int.Parse(match.Groups[2].Value);
                _wordIndex = int.Parse(match.Groups[3].Value);
                _resolvedRefProperty = RefProperty;
            }
        }
    }
}