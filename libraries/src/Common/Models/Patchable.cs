using System;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure
{
    public class Patchable<T>
    {
        private bool _isIncluded;
        private PatchOperation _operation;

        public static implicit operator Patchable<T>(T value)
        {
            return new Patchable<T>().Set(value);
        }

        public static implicit operator T(Patchable<T> patchable)
        {
            return patchable.Value;
        }

        public Patchable<T> Set(T value)
        {
            _isIncluded = true;
            _operation = new PatchOperation("SET", value);
            return this;
        }

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

        public bool IsIncluded
        {
            get { return _isIncluded; }
        }

        public override string ToString()
        {
            if (!_isIncluded)
                return "SKIP";
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