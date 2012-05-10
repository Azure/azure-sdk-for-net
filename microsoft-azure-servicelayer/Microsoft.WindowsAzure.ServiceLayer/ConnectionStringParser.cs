//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Helper methods for parsing connection strings.
    /// </summary>
    /// <remarks>The rules for formatting connection strings are defined here:
    /// http://www.connectionstrings.com/articles/show/important-rules-for-connection-strings</remarks>
    internal class ConnectionStringParser
    {
        /// <summary>
        /// State of the parser.
        /// </summary>
        private enum ParserState
        {
            ExpectKey,                  // Key name is expected.
            ExpectAssignment,           // Assignment is expected.
            ExpectValue,                // Key value is expected.
            ExpectSeparator,            // Separator or end of text is expected.
        }

        private string _argumentName;                       // Name of the argument.
        private string _value;                              // Value being parsed.
        private int _pos;                                   // Current position.
        private ParserState _state;                         // Current state.

        /// <summary>
        /// Parses the connection string into a collection of key/value pairs.
        /// </summary>
        /// <param name="argumentName">Name of the argument to be used in
        /// error messages.</param>
        /// <param name="connectionString">Connection string.</param>
        /// <returns>Parsed connection string.</returns>
        internal static IEnumerable<KeyValuePair<string, string>> Parse(string argumentName, string connectionString)
        {
            ConnectionStringParser parser = new ConnectionStringParser(argumentName, connectionString);
            return parser.Parse();
        }

        /// <summary>
        /// Initializes the object.
        /// </summary>
        /// <param name="argumentName">Name of the argument for error messages.</param>
        /// <param name="value">Value to parse.</param>
        private ConnectionStringParser(string argumentName, string value)
        {
            Debug.Assert(!string.IsNullOrEmpty(argumentName));
            Debug.Assert(value != null);

            _argumentName = argumentName;
            _value = value;
            _pos = 0;
            _state = ParserState.ExpectKey;
        }

        /// <summary>
        /// Parses the string.
        /// </summary>
        /// <returns>A collection of key=value pairs.</returns>
        private IEnumerable<KeyValuePair<string, string>> Parse()
        {
            Debug.Assert(_pos == 0);
            Debug.Assert(_state == ParserState.ExpectKey);
            string key = null;
            string value = null;

            for (;;)
            {
                SkipWhitespaces();

                if (_pos == _value.Length && _state != ParserState.ExpectValue)
                {
                    // Not stopping after the end has been reached and a value is expected
                    // results in creating an empty value, which we expect.
                    break;
                }

                switch (_state)
                {
                    case ParserState.ExpectKey:
                        Debug.Assert(key == null);
                        Debug.Assert(value == null);
                        key = ExtractKey();
                        _state = ParserState.ExpectAssignment;
                        break;

                    case ParserState.ExpectAssignment:
                        Debug.Assert(!string.IsNullOrEmpty(key));
                        Debug.Assert(value == null);
                        SkipOperator('=');
                        _state = ParserState.ExpectValue;
                        break;

                    case ParserState.ExpectValue:
                        Debug.Assert(!string.IsNullOrEmpty(key));
                        Debug.Assert(value == null);
                        value = ExtractValue();
                        _state = ParserState.ExpectSeparator;
                        yield return new KeyValuePair<string, string>(key, value);
                        key = null;
                        value = null;
                        break;

                    default:
                        Debug.Assert(_state == ParserState.ExpectSeparator);
                        SkipOperator(';');
                        _state = ParserState.ExpectKey;
                        break;
                }
            }
            // We should never end in the "expect value" state because missing values are
            // treated as empty strings.
            Debug.Assert(_state != ParserState.ExpectValue);

            // Must end parsing in the valid state (expected key or separator)
            if (_state == ParserState.ExpectAssignment)
            {
                throw CreateException(_pos, Resources.ErrorConnectionStringMissingCharacter, "=");
            }
            Debug.Assert(_state == ParserState.ExpectKey || _state == ParserState.ExpectSeparator);
        }

        /// <summary>
        /// Generates an invalid connection string exception with the detailed 
        /// error message.
        /// </summary>
        /// <param name="position">Position of the error.</param>
        /// <param name="errorString">Short error formatting string.</param>
        /// <param name="args">Optional arguments for the error string.</param>
        /// <returns>Exception with the requested message.</returns>
        private Exception CreateException(int position, string errorString, params object[] args)
        {
            Debug.Assert(position >= 0);
            Debug.Assert(position <= _value.Length);

            // Create a short error message.
            errorString = string.Format(CultureInfo.CurrentUICulture, errorString, args);

            // Add position.
            errorString = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorParsingConnectionString, errorString, _pos);

            // Create final error message.
            errorString = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorInvalidConnectionString, _argumentName, errorString);

            return new ArgumentException(errorString);
        }

        /// <summary>
        /// Skips whitespaces at the current position.
        /// </summary>
        private void SkipWhitespaces()
        {
            while (_pos < _value.Length && char.IsWhiteSpace(_value[_pos]))
            {
                _pos++;
            }
        }

        /// <summary>
        /// Extracts key at the current position.
        /// </summary>
        /// <returns>Key.</returns>
        private string ExtractKey()
        {
            Debug.Assert(_state == ParserState.ExpectKey);
            Debug.Assert(_pos < _value.Length);

            string key = null;
            int firstPos = _pos;
            char ch = _value[_pos++];

            if (ch == '"' || ch == '\'')
            {
                key = ExtractString(ch);
            }
            else if (ch == ';' || ch == '=')
            {
                // Key name was expected.
                throw CreateException(firstPos, Resources.ErrorConnectionStringMissingKey);
            }
            else
            {
                while (_pos < _value.Length)
                {
                    ch = _value[_pos];
                    if (ch == '=')
                    {
                        break;
                    }
                    _pos++;
                }
                key = _value.Substring(firstPos, _pos - firstPos).TrimEnd();
            }

            if (key.Length == 0)
            {
                // Empty key name.
                throw CreateException(firstPos, Resources.ErrorConnectionStringEmptyKey);
            }

            return key;
        }

        /// <summary>
        /// Extracts the string until the given quotation mark.
        /// </summary>
        /// <param name="quote">Quotation mark terminating the string.</param>
        /// <returns>String.</returns>
        private string ExtractString(char quote)
        {
            int firstPos = _pos;
            while (_pos < _value.Length && _value[_pos] != quote)
            {
                _pos++;
            }

            if (_pos == _value.Length)
            {
                // Runaway string.
                throw CreateException(_pos, Resources.ErrorConnectionStringMissingCharacter, quote);
            }

            return _value.Substring(firstPos, _pos++ - firstPos);
        }

        /// <summary>
        /// Skips specified operator.
        /// </summary>
        /// <param name="operatorChar">Operator character.</param>
        private void SkipOperator(char operatorChar)
        {
            Debug.Assert(_pos < _value.Length);
            if (_value[_pos] != operatorChar)
            {
                // Character was expected.
                throw CreateException(_pos, Resources.ErrorConnectionStringMissingCharacter, operatorChar);
            }
            _pos++;
        }

        /// <summary>
        /// Extracts key's value.
        /// </summary>
        /// <returns>Key's value.</returns>
        private string ExtractValue()
        {
            Debug.Assert(_state == ParserState.ExpectValue);
            string value = string.Empty;

            if (_pos < _value.Length)
            {
                char ch = _value[_pos];

                if (ch == '\'' || ch == '"')
                {
                    _pos++;
                    value = ExtractString(ch);
                }
                else 
                {
                    int firstPos = _pos;
                    bool isFound = false;

                    while (_pos < _value.Length && !isFound)
                    {
                        ch = _value[_pos];

                        switch (ch)
                        {
                            case ';':
                                isFound = true;
                                break;

                            default:
                                _pos++;
                                break;
                        }
                    }

                    value = _value.Substring(firstPos, _pos - firstPos).TrimEnd();
                }
            }
            return value;
        }
    }
}
