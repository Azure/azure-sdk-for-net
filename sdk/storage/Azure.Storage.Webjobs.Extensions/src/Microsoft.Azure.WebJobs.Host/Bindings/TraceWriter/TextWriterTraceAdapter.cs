// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// This adapter is used bind the function <see cref="TextWriter"/> to both the
    /// <see cref="TraceWriter"/> as well as the function output <see cref="TextWriter"/>.
    /// </summary>
    internal class TextWriterTraceAdapter : TextWriter
    {
        private readonly StringBuilder _text;
        private readonly TraceWriter _traceWriter;

        private TextWriterTraceAdapter(TraceWriter traceWriter)
            : base(CultureInfo.InvariantCulture)
        {
            _text = new StringBuilder();
            _traceWriter = traceWriter;
        }

        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
        public static TextWriter Synchronized(TraceWriter traceWriter)
        {
            return TextWriter.Synchronized(new TextWriterTraceAdapter(traceWriter));
        }

        public override void Write(char value)
        {
            // buffer all output
            _text.Append(value);

            if (IsCurrentNewLine())
            {
                // when we see a newline, flush the output
                // flushing often is very important - we need to ensure that output
                // is flushed to the Dashboard as it is written in the body of
                // long running executing functions.
                _traceWriter.Info(_text.ToString());
                _text.Clear();
            }
        }

        private bool IsCurrentNewLine()
        {
            if (_text.Length < Environment.NewLine.Length)
            {
                return false;
            }

            for (int i = 1; i <= Environment.NewLine.Length; i++)
            {
                if (_text[_text.Length - i] != Environment.NewLine[Environment.NewLine.Length - i])
                {
                    return false;
                }
            }

            return true;
        }

        public override void Flush()
        {
            if (_text.Length > 0)
            {
                // flush any remaining text
                _traceWriter.Info(_text.ToString());
                _text.Clear();
            }

            _traceWriter.Flush();
        }
    }
}