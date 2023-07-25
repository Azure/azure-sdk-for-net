// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The possible Dtmf Tones.
    /// </summary>
    [CodeGenModel("Tone", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    [JsonConverter(typeof(EquatableEnumJsonConverter<DtmfTone>))]
    public readonly partial struct DtmfTone
    {
        /// <summary>
        /// The Dtmf Tone in character format.
        /// </summary>
        public char ToChar()
        {
            string originalValue = ToString();
            return ConvertToChar(originalValue);
        }

        /// <summary>
        /// Convert the tone from string to char digit like "1", "2", "#".
        /// </summary>
        private static char ConvertToChar(string value)
        {
            char charValue = ' ';
            switch (value)
            {
                case "zero":
                    charValue = '0';
                    break;
                case "one":
                    charValue = '1';
                    break;
                case "two":
                    charValue = '2';
                    break;
                case "three":
                    charValue = '3';
                    break;
                case "four":
                    charValue = '4';
                    break;
                case "five":
                    charValue = '5';
                    break;
                case "six":
                    charValue = '6';
                    break;
                case "seven":
                    charValue = '7';
                    break;
                case "eight":
                    charValue = '8';
                    break;
                case "nine":
                    charValue = '9';
                    break;
                case "a":
                    charValue = 'a';
                    break;
                case "b":
                    charValue = 'b';
                    break;
                case "c":
                    charValue = 'c';
                    break;
                case "d":
                    charValue = 'd';
                    break;
                case "pound":
                    charValue = '#';
                    break;
                case "asterisk":
                    charValue = '*';
                    break;
                default:
                    break;
            }
            return charValue;
        }
    }
}
