//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// JSON formatter for PATCH syntax.
    /// </summary>
    /// <typeparam name="T">Value to patch.</typeparam>
    public class Patchable<T>
    {
        private bool _isIncluded;
        private PatchOperation _operation;

        /// <summary>
        /// Implicit operator that converts T to Patchable T.
        /// </summary>
        /// <param name="value">Object to convert.</param>
        /// <returns>Converted object.</returns>
        public static implicit operator Patchable<T>(T value)
        {
            return new Patchable<T>().Set(value);
        }

        /// <summary>
        /// Implicit operator that converts Patchable T to T.
        /// </summary>
        /// <param name="patchable">Object to convert.</param>
        /// <returns>Converted object.</returns>
        public static implicit operator T(Patchable<T> patchable)
        {
            return patchable.Value;
        }

        /// <summary>
        /// Sets operation to SET and returns instance of the object.
        /// </summary>
        /// <param name="value">Value to patch.</param>
        /// <returns>Instance of the object.</returns>
        public Patchable<T> Set(T value)
        {
            _isIncluded = true;
            _operation = new PatchOperation("SET", value);
            return this;
        }

        /// <summary>
        /// Gets the patch value.
        /// </summary>
        public T Value
        {
            get
            {
                if (!IsIncluded)
                {
                    throw new InvalidOperationException("Value is not set.");
                }
                return (T)_operation.Values[0];
            }
        }

        /// <summary>
        /// Gets a value indicating whether the value is set.
        /// </summary>
        public bool IsIncluded
        {
            get { return _isIncluded; }
        }

        /// <summary>
        /// Returns formatted PATCH script.
        /// </summary>
        /// <returns>Formatted PATCH script.</returns>
        public override string ToString()
        {
            if (!_isIncluded)
            {
                return "SKIP";
            }
            return _operation.ToString();
        }
        
        private struct PatchOperation
        {
            private readonly string _command;
            private readonly object[] _values;

            public PatchOperation(string command, params object[] values)
            {
                if (command != "SET")
                {
                    throw new NotImplementedException("only SET operation is currently implemented");
                }
                if (values.Length  != 1)
                {
                    throw new ArgumentOutOfRangeException("values", "SET operation should include a single value");
                }
                _command = command;
                _values = values;
            }

            public string Command
            {
                get { return _command; }
            }

            public object[] Values
            {
                get { return _values; }
            }

            public override string ToString()
            {
                var result = new StringBuilder("\"" + Command + "\"");
                var args = string.Join(", ", Values.Select(v => v == null ? "null" : v.ToString()));
                if (args.Length > 0)
                {
                    result.Append(": ").Append(args);
                }

                return result.ToString();
            }
        }
    }
}