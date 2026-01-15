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
            Assert.That(errorCode == matchingString, Is.True);
            Assert.That(errorCode == nonMatchingString, Is.False);
        }

        [Test]
        public void EqualityOperator_TableErrorCodeToNullString_ReturnsFalse()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string nullString = null;

            // Act & Assert
            Assert.That(errorCode == nullString, Is.False);
        }

        [Test]
        public void InequalityOperator_TableErrorCodeToString_ReturnsCorrectResult()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string matchingString = "EntityNotFound";
            string nonMatchingString = "TableNotFound";

            // Act & Assert
            Assert.That(errorCode == matchingString, Is.True);
            Assert.That(errorCode != nonMatchingString, Is.True);
        }

        [Test]
        public void InequalityOperator_TableErrorCodeToNullString_ReturnsTrue()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string nullString = null;

            // Act & Assert
            Assert.That(errorCode != nullString, Is.True);
        }

        [Test]
        public void EqualityOperator_StringToTableErrorCode_ReturnsCorrectResult()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string matchingString = "EntityNotFound";
            string nonMatchingString = "TableNotFound";

            // Act & Assert
            Assert.That(matchingString == errorCode, Is.True);
            Assert.That(nonMatchingString == errorCode, Is.False);
        }

        [Test]
        public void EqualityOperator_NullStringToTableErrorCode_ReturnsFalse()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string nullString = null;

            // Act & Assert
            Assert.That(nullString == errorCode, Is.False);
        }

        [Test]
        public void InequalityOperator_StringToTableErrorCode_ReturnsCorrectResult()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string matchingString = "EntityNotFound";
            string nonMatchingString = "TableNotFound";

            // Act & Assert
            Assert.That(matchingString == errorCode, Is.True);
            Assert.That(nonMatchingString != errorCode, Is.True);
        }

        [Test]
        public void InequalityOperator_NullStringToTableErrorCode_ReturnsTrue()
        {
            // Arrange
            var errorCode = TableErrorCode.EntityNotFound;
            string nullString = null;

            // Act & Assert
            Assert.That(nullString != errorCode, Is.True);
        }

        [Test]
        public void EqualityOperators_WithVariousErrorCodes_WorkCorrectly()
        {
            // Arrange & Act & Assert
            Assert.That(TableErrorCode.TableAlreadyExists == "TableAlreadyExists", Is.True);
            Assert.That("TableAlreadyExists" == TableErrorCode.TableAlreadyExists, Is.True);
            Assert.That(TableErrorCode.OperationTimedOut == "OperationTimedOut", Is.True);
            Assert.That("OperationTimedOut" == TableErrorCode.OperationTimedOut, Is.True);
            Assert.That(TableErrorCode.Forbidden == "Forbidden", Is.True);
            Assert.That("Forbidden" == TableErrorCode.Forbidden, Is.True);
            Assert.That(TableErrorCode.TableAlreadyExists == "EntityNotFound", Is.False);
            Assert.That("EntityNotFound" == TableErrorCode.TableAlreadyExists, Is.False);
        }

        [Test]
        public void InequalityOperators_WithVariousErrorCodes_WorkCorrectly()
        {
            // Arrange & Act & Assert
            Assert.That(TableErrorCode.TableAlreadyExists == "TableAlreadyExists", Is.True);
            Assert.That("TableAlreadyExists" == TableErrorCode.TableAlreadyExists, Is.True);
            Assert.That(TableErrorCode.OperationTimedOut != "OperationTimedOut", Is.False);
            Assert.That("OperationTimedOut" != TableErrorCode.OperationTimedOut, Is.False);
            Assert.That(TableErrorCode.TableAlreadyExists != "EntityNotFound", Is.True);
            Assert.That("EntityNotFound" != TableErrorCode.TableAlreadyExists, Is.True);
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
