// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    public readonly partial struct LexicalNormalizerName
    {
#pragma warning disable CA1034 // Nested types should not be visible
        /// <summary>
        /// The values of all declared <see cref="LexicalNormalizerName"/> properties as string constants.
        /// These can be used in <see cref="SimpleFieldAttribute"/>, <see cref="SearchableFieldAttribute"/> and anywhere else constants are required.
        /// </summary>
        public static class Values
        {
            /// <summary> Converts alphabetic, numeric, and symbolic Unicode characters which are not in the first 127 ASCII characters (the &quot;Basic Latin&quot; Unicode block) into their ASCII equivalents, if such equivalents exist. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/ASCIIFoldingFilter.html. </summary>
            public const string AsciiFolding = LexicalNormalizerName.AsciiFoldingValue;
            /// <summary> Removes elisions. For example, &quot;l&apos;avion&quot; (the plane) will be converted to &quot;avion&quot; (plane). See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/util/ElisionFilter.html. </summary>
            public const string Elision = LexicalNormalizerName.ElisionValue;
            /// <summary> Normalizes token text to lowercase. See https://lucene.apache.org/core/6_6_1/analyzers-common/org/apache/lucene/analysis/core/LowerCaseFilter.html. </summary>
            public const string Lowercase = LexicalNormalizerName.LowercaseValue;
            /// <summary> Standard normalizer, which consists of lowercase and asciifolding. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/reverse/ReverseStringFilter.html. </summary>
            public const string Standard = LexicalNormalizerName.StandardValue;
            /// <summary> Normalizes token text to uppercase. See https://lucene.apache.org/core/6_6_1/analyzers-common/org/apache/lucene/analysis/core/UpperCaseFilter.html. </summary>
            public const string Uppercase = LexicalNormalizerName.UppercaseValue;
        }
#pragma warning restore CA1034 // Nested types should not be visible
    }
}
