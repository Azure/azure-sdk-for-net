using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Conventions.Files.UnitTests
{
    public class TaskOutputKindUnitTests
    {
        private static readonly TaskOutputKind NullKind = null;  // strongly typed to induce use of overloads

        [Fact]
        public void TaskOutputStringisesToTaskOutput()
        {
            Assert.Equal("TaskOutput", TaskOutputKind.TaskOutput.ToString());
        }

        [Fact]
        public void TaskPreviewStringisesToTaskPreview()
        {
            Assert.Equal("TaskPreview", TaskOutputKind.TaskPreview.ToString());
        }

        [Fact]
        public void TaskLogStringisesToTaskLog()
        {
            Assert.Equal("TaskLog", TaskOutputKind.TaskLog.ToString());
        }

        [Fact]
        public void TaskIntermediateStringisesToTaskIntermediate()
        {
            Assert.Equal("TaskIntermediate", TaskOutputKind.TaskIntermediate.ToString());
        }

        [Fact]
        public void CustomTaskOutputKindStringisesToItsText()
        {
            Assert.Equal("alice", TaskOutputKind.Custom("alice").ToString());
        }

        [Fact]
        public void TwoTaskOutputKindsWithTheSameTextAreEqual_UsingStrongTypedEqualsMethod()
        {
            var kind1 = TaskOutputKind.Custom("alice");
            var kind2 = TaskOutputKind.Custom("alice");
            Assert.True(kind1.Equals(kind2));
        }

        [Fact]
        public void TwoTaskOutputKindsWithDifferentlyCasedTextAreNotEqual_UsingStrongTypedEqualsMethod()
        {
            var kind1 = TaskOutputKind.Custom("alice");
            var kind2 = TaskOutputKind.Custom("Alice");
            Assert.False(kind1.Equals(kind2));
        }

        [Fact]
        public void ATaskOutputKindIsNotEqualToNull_UsingStrongTypedEqualsMethod()
        {
            var kind = TaskOutputKind.Custom("alice");
            Assert.False(kind.Equals(NullKind));
        }

        [Fact]
        public void TwoTaskOutputKindsWithTheSameTextAreEqual_UsingWeakTypedEqualsMethod()
        {
            object kind1 = TaskOutputKind.Custom("alice");
            object kind2 = TaskOutputKind.Custom("alice");
            Assert.True(kind1.Equals(kind2));
        }

        [Fact]
        public void TwoTaskOutputKindsWithDifferentlyCasedTextAreNotEqual_UsingWeakTypedEqualsMethod()
        {
            object kind1 = TaskOutputKind.Custom("alice");
            object kind2 = TaskOutputKind.Custom("Alice");
            Assert.False(kind1.Equals(kind2));
        }

        [Fact]
        public void ATaskOutputKindIsNotEqualToNull_UsingWeakTypedEqualsMethod()
        {
            object kind = TaskOutputKind.Custom("alice");
            Assert.False(kind.Equals(null));
        }

        [Fact]
        public void TwoTaskOutputKindsWithTheSameTextAreEqual_UsingEqualityOperator()
        {
            var kind1 = TaskOutputKind.Custom("alice");
            var kind2 = TaskOutputKind.Custom("alice");
            Assert.True(kind1 == kind2);
        }

        [Fact]
        public void TwoTaskOutputKindsWithDifferentlyCasedTextAreNotEqual_UsingEqualityOperator()
        {
            var kind1 = TaskOutputKind.Custom("alice");
            var kind2 = TaskOutputKind.Custom("Alice");
            Assert.False(kind1 == kind2);
        }

        [Fact]
        public void ATaskOutputKindIsNotEqualToNull_UsingEqualityOperator()
        {
            var kind = TaskOutputKind.Custom("alice");
            Assert.False(kind == NullKind);
        }

        [Fact]
        public void NullIsNotEqualToATaskOutputKind_UsingEqualityOperator()
        {
            var kind = TaskOutputKind.Custom("alice");
            Assert.False(NullKind == kind);
        }

        [Fact]
        public void TwoTaskOutputKindsWithTheSameTextAreEqual_UsingInequalityOperator()
        {
            var kind1 = TaskOutputKind.Custom("alice");
            var kind2 = TaskOutputKind.Custom("alice");
            Assert.False(kind1 != kind2);
        }

        [Fact]
        public void TwoTaskOutputKindsWithDifferentlyCasedTextAreNotEqual_UsingInequalityOperator()
        {
            var kind1 = TaskOutputKind.Custom("alice");
            var kind2 = TaskOutputKind.Custom("Alice");
            Assert.True(kind1 != kind2);
        }

        [Fact]
        public void ATaskOutputKindIsNotEqualToNull_UsingInequalityOperator()
        {
            var kind = TaskOutputKind.Custom("alice");
            Assert.True(kind != NullKind);
        }

        [Fact]
        public void NullIsNotEqualToATaskOutputKind_UsingInequalityOperator()
        {
            var kind = TaskOutputKind.Custom("alice");
            Assert.True(NullKind != kind);
        }

        [Fact]
        public void CannotCreateATaskOutputKindWithNullText()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => TaskOutputKind.Custom(null));
            Assert.Equal("text", ex.ParamName);
        }

        [Fact]
        public void CannotCreateATaskOutputKindWithEmptyText()
        {
            var ex = Assert.Throws<ArgumentException>(() => TaskOutputKind.Custom(""));
            Assert.Equal("text", ex.ParamName);
        }
    }
}
