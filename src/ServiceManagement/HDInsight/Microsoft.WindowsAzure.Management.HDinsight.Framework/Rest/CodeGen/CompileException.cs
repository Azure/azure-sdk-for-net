namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CodeGen
{
    using System;
    using System.CodeDom.Compiler;

    /// <summary>
    /// Thrown when dynamic compilation fails.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "Not serialized"), 
    System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "Not serialized")]
    public class CompileException : Exception
    {
        /// <summary>
        /// The _results.
        /// </summary>
        private readonly CompilerResults _results;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompileException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="results">
        /// The results.
        /// </param>
        public CompileException(string message, CompilerResults results)
            : base(message)
        {
            this._results = results;
        }

        /// <summary>
        /// Gets the compiler results.
        /// </summary>
        /// <value>The results.</value>
        public CompilerResults Results
        {
            get { return this._results; }
        }
    }
}
