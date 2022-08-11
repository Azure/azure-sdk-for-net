using NJsonSchema.Validation;

namespace WebJobs.Extensions.AuthenticationEvents.Tests.Schema
{
    /// <summary>Test Data for Validation Error.</summary>
    public class ValidationErrorTestData
    {
        /// <summary>Gets the error path.</summary>
        /// <value>The error path.</value>
        public string Path { get; }

        /// <summary>Gets the optional error kind.</summary>
        /// <value>The error kind.</value>
        public ValidationErrorKind? Kind { get; }

        /// <summary>Gets a value indicating whether to allow partial matching for validation error path.</summary>
        /// <value>True, if allowed to do partial path matching.</value>
        public bool AllowPartialPathMatch { get; }

        /// <summary>
        /// Gets a value indicating whether we want to treat the error as exclude.
        /// If this value is true, the user is indicating that an actual error with given parameters
        /// should not happen during the validation.
        /// </summary>
        /// <value>True if exclude mode is on.</value>
        public bool IsExcludeMode { get; }

        /// <summary>Initializes a new instance of the <see cref="ValidationErrorTestData" /> class.</summary>
        /// <param name="path">The validation error path.</param>
        /// <param name="kind">The optional validation error kind.</param>
        /// <param name="allowPathPartialMatch">if set to true, allow path partial match.</param>
        /// <param name="isExcludeMode">if set to true, exclude mode is on.</param>
        public ValidationErrorTestData(
            string path,
            ValidationErrorKind? kind = null,
            bool allowPathPartialMatch = false,
            bool isExcludeMode = false)
        {
            this.Path = path;
            this.Kind = kind;
            this.AllowPartialPathMatch = allowPathPartialMatch;
            this.IsExcludeMode = isExcludeMode;
        }
    }
}
