// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.Tables.Models;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class TableErrorCodeTests
    {
        [Test]
        public void EqualityOperator_TableErrorCodeToString_ReturnsCorrectResult()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string matchingString = "EntityNotFound";
            string nonMatchingString = "TableNotFound";

            // Act & Assert
            Assert.IsTrue(errorCode == matchingString);
            Assert.IsFalse(errorCode == nonMatchingString);
        }

        [Test]
        public void EqualityOperator_TableErrorCodeToNullString_ReturnsFalse()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string nullString = null;

            // Act & Assert
            Assert.IsFalse(errorCode == nullString);
        }

        [Test]
        public void InequalityOperator_TableErrorCodeToString_ReturnsCorrectResult()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string matchingString = "EntityNotFound";
            string nonMatchingString = "TableNotFound";

            // Act & Assert
            Assert.IsTrue(errorCode == matchingString);
            Assert.IsTrue(errorCode != nonMatchingString);
        }

        [Test]
        public void InequalityOperator_TableErrorCodeToNullString_ReturnsTrue()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string nullString = null;

            // Act & Assert
            Assert.IsTrue(errorCode != nullString);
        }

        [Test]
        public void EqualityOperator_StringToTableErrorCode_ReturnsCorrectResult()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string matchingString = "EntityNotFound";
            string nonMatchingString = "TableNotFound";

            // Act & Assert
            Assert.IsTrue(matchingString == errorCode);
            Assert.IsFalse(nonMatchingString == errorCode);
        }

        [Test]
        public void EqualityOperator_NullStringToTableErrorCode_ReturnsFalse()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string nullString = null;

            // Act & Assert
            Assert.IsFalse(nullString == errorCode);
        }

        [Test]
        public void InequalityOperator_StringToTableErrorCode_ReturnsCorrectResult()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string matchingString = "EntityNotFound";
            string nonMatchingString = "TableNotFound";

            // Act & Assert
            Assert.IsTrue(matchingString == errorCode);
            Assert.IsTrue(nonMatchingString != errorCode);
        }

        [Test]
        public void InequalityOperator_NullStringToTableErrorCode_ReturnsTrue()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string nullString = null;

            // Act & Assert
            Assert.IsTrue(nullString != errorCode);
        }

        [Test]
        public void EqualityOperators_WithVariousErrorCodes_WorkCorrectly()
        {
            // Arrange & Act & Assert
            Assert.IsTrue(TableErrorCode.TableAlreadyExists == "TableAlreadyExists");
            Assert.IsTrue("TableAlreadyExists" == TableErrorCode.TableAlreadyExists);
            Assert.IsTrue(TableErrorCode.OperationTimedOut == "OperationTimedOut");
            Assert.IsTrue("OperationTimedOut" == TableErrorCode.OperationTimedOut);
            Assert.IsTrue(TableErrorCode.Forbidden == "Forbidden");
            Assert.IsTrue("Forbidden" == TableErrorCode.Forbidden);
            Assert.IsFalse(TableErrorCode.TableAlreadyExists == "EntityNotFound");
            Assert.IsFalse("EntityNotFound" == TableErrorCode.TableAlreadyExists);
        }

        [Test]
        public void InequalityOperators_WithVariousErrorCodes_WorkCorrectly()
        {
            // Arrange & Act & Assert
            Assert.IsTrue(TableErrorCode.TableAlreadyExists == "TableAlreadyExists");
            Assert.IsTrue("TableAlreadyExists" == TableErrorCode.TableAlreadyExists);
            Assert.IsFalse(TableErrorCode.OperationTimedOut != "OperationTimedOut");
            Assert.IsFalse("OperationTimedOut" != TableErrorCode.OperationTimedOut);
            Assert.IsTrue(TableErrorCode.TableAlreadyExists != "EntityNotFound");
            Assert.IsTrue("EntityNotFound" != TableErrorCode.TableAlreadyExists);
        }

        [Test]
        public void StringOperators_DoNotThrowOnNullValues()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string nullString = null;

            // Act & Assert - These should not throw exceptions
            Assert.DoesNotThrow(() =>
            {
                var result1 = errorCode == nullString;
                var result2 = errorCode != nullString;
                var result3 = nullString == errorCode;
                var result4 = nullString != errorCode;
            });
        }
    }
}
