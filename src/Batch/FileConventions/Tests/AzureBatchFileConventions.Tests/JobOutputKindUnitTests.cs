using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Conventions.Files.UnitTests
{
    public class JobOutputKindUnitTests
    {
        private static readonly JobOutputKind NullKind = null;  // strongly typed to induce use of overloads

        [Fact]
        public void JobOutputStringisesToJobOutput()
        {
            Assert.Equal("JobOutput", JobOutputKind.JobOutput.ToString());
        }

        [Fact]
        public void JobPreviewStringisesToJobPreview()
        {
            Assert.Equal("JobPreview", JobOutputKind.JobPreview.ToString());
        }

        [Fact]
        public void CustomJobOutputKindStringisesToItsText()
        {
            Assert.Equal("bob", JobOutputKind.Custom("bob").ToString());
        }

        [Fact]
        public void TwoJobOutputKindsWithTheSameTextAreEqual_UsingStrongTypedEqualsMethod()
        {
            var kind1 = JobOutputKind.Custom("bob");
            var kind2 = JobOutputKind.Custom("bob");
            Assert.True(kind1.Equals(kind2));
        }

        [Fact]
        public void TwoJobOutputKindsWithDifferentlyCasedTextAreNotEqual_UsingStrongTypedEqualsMethod()
        {
            var kind1 = JobOutputKind.Custom("bob");
            var kind2 = JobOutputKind.Custom("Bob");
            Assert.False(kind1.Equals(kind2));
        }

        [Fact]
        public void AJobOutputKindIsNotEqualToNull_UsingStrongTypedEqualsMethod()
        {
            var kind = JobOutputKind.Custom("bob");
            Assert.False(kind.Equals(NullKind));
        }

        [Fact]
        public void TwoJobOutputKindsWithTheSameTextAreEqual_UsingWeakTypedEqualsMethod()
        {
            object kind1 = JobOutputKind.Custom("bob");
            object kind2 = JobOutputKind.Custom("bob");
            Assert.True(kind1.Equals(kind2));
        }

        [Fact]
        public void TwoJobOutputKindsWithDifferentlyCasedTextAreNotEqual_UsingWeakTypedEqualsMethod()
        {
            object kind1 = JobOutputKind.Custom("bob");
            object kind2 = JobOutputKind.Custom("Bob");
            Assert.False(kind1.Equals(kind2));
        }

        [Fact]
        public void AJobOutputKindIsNotEqualToNull_UsingWeakTypedEqualsMethod()
        {
            object kind = JobOutputKind.Custom("bob");
            Assert.False(kind.Equals(null));
        }

        [Fact]
        public void TwoJobOutputKindsWithTheSameTextAreEqual_UsingEqualityOperator()
        {
            var kind1 = JobOutputKind.Custom("bob");
            var kind2 = JobOutputKind.Custom("bob");
            Assert.True(kind1 == kind2);
        }

        [Fact]
        public void TwoJobOutputKindsWithDifferentlyCasedTextAreNotEqual_UsingEqualityOperator()
        {
            var kind1 = JobOutputKind.Custom("bob");
            var kind2 = JobOutputKind.Custom("Bob");
            Assert.False(kind1 == kind2);
        }

        [Fact]
        public void AJobOutputKindIsNotEqualToNull_UsingEqualityOperator()
        {
            var kind = JobOutputKind.Custom("bob");
            Assert.False(kind == NullKind);
        }

        [Fact]
        public void NullIsNotEqualToAJobOutputKind_UsingEqualityOperator()
        {
            var kind = JobOutputKind.Custom("bob");
            Assert.False(NullKind == kind);
        }

        [Fact]
        public void TwoJobOutputKindsWithTheSameTextAreEqual_UsingInequalityOperator()
        {
            var kind1 = JobOutputKind.Custom("bob");
            var kind2 = JobOutputKind.Custom("bob");
            Assert.False(kind1 != kind2);
        }

        [Fact]
        public void TwoJobOutputKindsWithDifferentlyCasedTextAreNotEqual_UsingInequalityOperator()
        {
            var kind1 = JobOutputKind.Custom("bob");
            var kind2 = JobOutputKind.Custom("Bob");
            Assert.True(kind1 != kind2);
        }

        [Fact]
        public void AJobOutputKindIsNotEqualToNull_UsingInequalityOperator()
        {
            var kind = JobOutputKind.Custom("bob");
            Assert.True(kind != NullKind);
        }

        [Fact]
        public void NullIsNotEqualToAJobOutputKind_UsingInequalityOperator()
        {
            var kind = JobOutputKind.Custom("bob");
            Assert.True(NullKind != kind);
        }

        [Fact]
        public void CannotCreateAJobOutputKindWithNullText()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => JobOutputKind.Custom(null));
            Assert.Equal("text", ex.ParamName);
        }

        [Fact]
        public void CannotCreateAJobOutputKindWithEmptyText()
        {
            var ex = Assert.Throws<ArgumentException>(() => JobOutputKind.Custom(""));
            Assert.Equal("text", ex.ParamName);
        }
    }
}
