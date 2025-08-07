// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security;
using System.Text;

namespace Azure.Provisioning.Generator;

/// <summary>
/// IndentWriter provides helpful features for writing blocks of indented
/// text (like source code, JSON, etc.).
/// </summary>
public partial class IndentWriter
{
    /// <summary>
    /// The buffer where text is written.  It is obtained by the user via
    /// IndentWriter.ToString().
    /// </summary>
    private readonly StringBuilder _writer = new();

    /// <summary>
    /// Whether or not the last character written was a newline character
    /// (which means the next line written should automatically add the
    /// current indent depth).
    /// </summary>        
    private bool _isNewline = true;

    /// <summary>
    /// Gets or sets the text used as each indent character (i.e., could be
    /// a single tab character or four space characters).  The default value
    /// is four space characters.
    /// </summary>
    public string IndentText { get; set; } = "    ";

    /// <summary>
    /// Gets the depth of the current indent level.
    /// </summary>
    public uint Indent { get; private set; }

    /// <summary>
    /// Initializes a new instance of the IndentWriter class.
    /// </summary>
    public IndentWriter() { }

    /// <summary>
    /// Gets the text that has been written thus far.
    /// </summary>
    /// <returns>The text written thus far.</returns>
    public override string ToString() => _writer.ToString();

    /// <summary>
    /// Pushes the scope a level deeper.
    /// </summary>
    public void PushScope() => Indent++;

    /// <summary>
    /// Pops the scope a level.
    /// </summary>
    public void PopScope()
    {
        if (Indent == 0)
        {
            throw new InvalidOperationException("Cannot pop scope any further!");
        }
        Indent--;
    }

    /// <summary>
    /// Writes an indent if needed.  This is used before each write
    /// operation to ensure we're always indenting.  We don't need to indent
    /// for a series of calls like Write("Foo"); Write("Bar"); but would
    /// indent between a series like WriteLine("Foo"); Write("Bar");
    /// </summary>
    private void WriteIndentIfNeeded()
    {
        // If we had just written a full line
        if (_isNewline)
        {
            // Then we'll write out the current indent depth before anything
            // else is written
            _isNewline = false;
            for (uint i = 0; i < Indent; i++)
            {
                _writer.Append(IndentText);
            }
        }
    }

    /// <summary>
    /// Write the text representation of the given values with indentation
    /// as appropriate.
    /// </summary>
    /// <param name='format'>Format string.</param>
    /// <param name='args'>Optional arguments to the format string.</param>
    public void Write(string? format, params object?[] args)
    {
        WriteIndentIfNeeded();

        // Only use AppendFormat if we have args so that we don't have to
        // escape curly brace literals used on their own.
        if (args != null && args.Length > 0)
        {
            _writer.AppendFormat(format ?? throw new ArgumentNullException(nameof(format)), args);
        }
        else if (format is not null)
        {
            _writer.Append(format);
        }
    }

    /// <summary>
    /// Write the text representation of the given values followed by a
    /// newline, with indentation as appropriate.  This will force the next
    /// Write call to indent before anything else is written.
    /// </summary>
    /// <param name='format'>Format string.</param>
    /// <param name='args'>Optional arguments to the format string.</param>
    public void WriteLine(string? format, params object[] args)
    {
        if (format is not null)
        {
            Write(format, args);
        }
        _writer.AppendLine();

        // Track that we just wrote a line so the next write operation will
        // indent first
        _isNewline = true;
    }

    /// <summary>
    /// Write a newline (which will force the next write operation to indent
    /// before anything else is written).
    /// </summary>
    public void WriteLine() => WriteLine(null);

    /// <summary>
    /// Write one or more lines of text with word wrapping.
    /// </summary>
    /// <param name="text">The text to wrap.</param>
    /// <param name="prefix">A prefix to use for each line.</param>
    /// <param name="width">The maximum width available.</param>
    /// <param name="escapeXml">Whether or not to escape any XML in the text.</param>
    public void WriteWrapped(string text, string prefix = "/// ", int width = 80, bool escapeXml = true)
    {
        if (escapeXml)
        {
            text = SecurityElement.Escape(text);
        }

        int available = width - (int)Indent * IndentText.Length - prefix.Length;
        foreach (string line in text.WordWrap(available))
        {
            Write(prefix);
            WriteLine(line);
        }
    }

    /// <summary>
    /// Increase the indent level after writing the text representation of
    /// the given values to the current line.  This would be used like:
    ///     myIndentWriter.PushScope("{");
    ///     /* Write indented lines here */
    ///     myIndentWriter.PopScope("}");
    /// </summary>
    /// <param name='format'>Format string.</param>
    /// <param name='args'>Optional arguments to the format string.</param>
    public void PushScope(string? format, params object[] args)
    {
        WriteLine(format, args);
        PushScope();
    }

    /// <summary>
    /// Decrease the indent level after writing the text representation of
    /// the given values to the current line.  This would be used like:
    ///     myIndentWriter.PushScope("{");
    ///     /* Write indented lines here */
    ///     myIndentWriter.PopScope("}");
    /// </summary>
    /// <param name='format'>Format string.</param>
    /// <param name='args'>Optional arguments to the format string.</param>
    public void PopScope(string? format, params object[] args)
    {
        PopScope();

        // Force the format string to be written on a new line, but don't
        // add an extra one if we just wrote a newline.
        if (!_isNewline)
        {
            WriteLine();
        }

        WriteLine(format, args);
    }

    /// <summary>
    /// Create a writer scope that will indent until the scope is disposed.
    /// This is used like:
    ///     using (myIndentWriter.Scope())
    ///     {
    ///         /* Write indented lines here */
    ///     }
    ///     /* Back to normal here */
    /// </summary>
    public IDisposable Scope() => new WriterScope(this);

    /// <summary>
    /// Create a writer scope that will indent until the scope is disposed
    /// and starts/ends the scope with the given text.  This is used like:
    ///     using (myIndentWriter.Scope("{", "}"))
    ///     {
    ///         /* Write indented lines here */
    ///     }
    ///     /* Back to normal here */
    /// </summary>
    /// <param name='start'>Text starting the scope.</param>
    /// <param name='end'>Text ending the scope.</param>
    public IDisposable Scope(string start, string end) => new WriterScope(this, start, end);

    /// <summary>
    /// The WriterScope class allows us to create an indentation block via a
    /// C# using statement.  It will typically be used via something like
    ///     using (myIndentWriter.Scope("{", "}"))
    ///     {
    ///         /* Indented writing here */
    ///     }
    ///     /* No longer indented from here on... */
    /// </summary>        
    private class WriterScope : IDisposable
    {
        /// <summary>
        /// The IndentWriter that contains this scope.
        /// </summary>
        private IndentWriter? _writer;

        /// <summary>
        /// An optional string to write upon closing the scope.
        /// </summary>
        private readonly string? _scopeEnd;

        /// <summary>
        /// Initializes a new instance of the WriterScope class.
        /// </summary>
        /// <param name='writer'>
        /// The IndentWriter containing the scope.
        /// </param>
        public WriterScope(IndentWriter writer)
        {
            _writer = writer;
            _writer.PushScope();
        }

        /// <summary>
        /// Initializes a new instance of the WriterScope class.
        /// </summary>
        /// <param name='writer'>
        /// The IndentWriter containing the scope.
        /// </param>
        /// <param name='scopeStart'>Text starting the scope.</param>
        /// <param name='scopeEnd'>Text ending the scope.</param>
        public WriterScope(IndentWriter writer, string scopeStart, string scopeEnd)
        {
            _writer = writer;
            _writer.PushScope(scopeStart);
            _scopeEnd = scopeEnd;
        }

        /// <summary>
        /// Close the scope.
        /// </summary>
        public void Dispose()
        {
            if (_writer is not null)
            {
                // Close the scope with the desired text if given
                if (_scopeEnd is not null)
                {
                    _writer.PopScope(_scopeEnd);
                }
                else
                {
                    _writer.PopScope();
                }

                // Prevent multiple disposals
                _writer = null;
            }
        }
    }

    /// <summary>
    /// Incredibly simple class to make fenceposting (i.e., performing an
    /// operation between every element in a sequence but not before or after)
    /// easy and consistent.  
    /// </summary>
    public class Fenceposter
    {
        /// <summary>
        /// Flag indicating whether a separator is required.  It starts false,
        /// but will be permanently flipped to true after the first time the
        /// RequiresSeparator property is accessed.
        /// </summary>
        private bool _requiresSeparator = false;

        /// <summary>
        /// Gets a value indicating whether a separator is required.  This will
        /// always be false the first time it is called after a new Fenceposter
        /// is constructed and true every time after.
        /// </summary>
        public bool RequiresSeparator
        {
            get
            {
                if (_requiresSeparator)
                {
                    return true;
                }
                else
                {
                    _requiresSeparator = true;
                    return false;
                }
            }
        }
    }
}
