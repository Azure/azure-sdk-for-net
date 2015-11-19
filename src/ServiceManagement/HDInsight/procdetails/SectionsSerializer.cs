// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace ProcDetailsTestApplication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Used to serialize and deserialize a set of sections.
    /// </summary>
    public class SectionsSerializer
    {
        // Separates Sections
        private static readonly Guid SectionDelimiter = new Guid("{77711443-E145-4162-8BA7-0D18D8E1BCE8}");

        // Separates SectionNames from Section Values
        private static readonly Guid SectionPairDelimiter = new Guid("{B6CD66AB-2C80-4009-9569-3D58897285CB}");

        // Separates Key/Value Pairs.
        private static readonly Guid EntryPairDelimiter = new Guid("{59183EB5-F52E-4262-96F4-E8F20C27B2E3}");

        // Separates Elements inside of a Section.
        private static readonly Guid EntryDelimiter = new Guid("{A1350BDC-2AD8-4571-B617-9AEF8650F0E5}");

        // Represents a Tab
        private static readonly Guid TabReplacementSequence = new Guid("{0C5183EA-9C83-4E3D-AE6A-7E958228EE86}");

        // Represents a Character Return
        private static readonly Guid CharacterReturnReplacementSequence = new Guid("{4F54BB4B-AEC1-43AE-B3C0-461B44D4C754}");

        // Represents a Line Feed Character
        private static readonly Guid LinefeedReplacementSequence = new Guid("{42AEA506-8329-4188-BEB6-5D2B6218FED0}");

        /// <summary>
        /// Serializes a Sections object into a string.
        /// </summary>
        /// <param name="sections">
        /// The section objects.
        /// </param>
        /// <returns>
        /// A string representing the sections objects in serialized form.
        /// </returns>
        public string Serialize(Sections sections)
        {
            var encoded = this.ConvertSectionsToString(sections);
            return encoded;
        }

        private string ConvertSectionsToString(Sections sections)
        {
            var encoded = (from s in sections select this.ReplaceString(s.Key) + SectionPairDelimiter + this.ReplaceString(this.ConvertEntriesToString(s.Value))).ToList();
            var result = string.Join(SectionDelimiter.ToString(), encoded);
            return result;
        }

        private string ConvertEntriesToString(Entries entries)
        {
            var encoded = (from e in entries select this.ReplaceString(e.Key) + EntryPairDelimiter + this.ReplaceString(e.Value)).ToArray();
            var result = string.Join(EntryDelimiter.ToString(), encoded);
            return result;
        }

        private Sections ConvertStringToSections(string encoded)
        {
            Sections retval = new Sections();
            string[] sections = encoded.Split(new string[] { SectionDelimiter.ToString() }, StringSplitOptions.None);
            foreach (var section in sections)
            {
                string[] pairs = section.Split(new string[] { SectionPairDelimiter.ToString() }, StringSplitOptions.None);
                retval.Add(pairs[0], this.ConvertStringToEntries(pairs[1]));
            }
            return retval;
        }

        private Entries ConvertStringToEntries(string encoded)
        {
            Entries retval = new Entries();
            var entriesLines = encoded.Split(new string[] { EntryDelimiter.ToString() }, StringSplitOptions.None);
            foreach (var entriesLine in entriesLines)
            {
                if (!string.IsNullOrWhiteSpace(entriesLine))
                {
                    string[] pairs = entriesLine.Split(new string[] { EntryPairDelimiter.ToString() }, StringSplitOptions.None);
                    retval.Add(pairs[0], pairs[1]);
                }
            }
            return retval;
        }

        private string ReplaceString(string input)
        {
            return input.Replace("\t", TabReplacementSequence.ToString())
                        .Replace("\r", CharacterReturnReplacementSequence.ToString())
                        .Replace("\n", LinefeedReplacementSequence.ToString());
        }

        /// <summary>
        /// Deserailizes sections from a provided string.
        /// </summary>
        /// <param name="content">
        /// The string representing the serialized form.
        /// </param>
        /// <returns>
        /// The sections represented by the serialized form.
        /// </returns>
        public Sections Deserialize(string content)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(content);
            builder.Replace(TabReplacementSequence.ToString(), "\t");
            builder.Replace(CharacterReturnReplacementSequence.ToString(), "\r");
            builder.Replace(LinefeedReplacementSequence.ToString(), "\n");
            content = builder.ToString();
            return this.ConvertStringToSections(content);
        }
    }
}
