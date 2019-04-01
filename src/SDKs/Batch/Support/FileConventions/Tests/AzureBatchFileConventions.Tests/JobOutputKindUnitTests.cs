// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
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
