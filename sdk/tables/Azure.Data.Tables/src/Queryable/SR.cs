// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables.Queryable
{
    internal class SR
    {
        // Table IQueryable Exception messages
        public const string ALinqCouldNotConvert = "Could not convert constant {0} expression to string.";
        public const string ALinqMethodNotSupported = "The method '{0}' is not supported.";
        public const string ALinqUnaryNotSupported = "The unary operator '{0}' is not supported.";
        public const string ALinqBinaryNotSupported = "The binary operator '{0}' is not supported.";
        public const string ALinqConstantNotSupported = "The constant for '{0}' is not supported.";
        public const string ALinqTypeBinaryNotSupported = "An operation between an expression and a type is not supported.";
        public const string ALinqConditionalNotSupported = "The conditional expression is not supported.";
        public const string ALinqParameterNotSupported = "The parameter expression is not supported.";
        public const string ALinqMemberAccessNotSupported = "The member access of '{0}' is not supported.";
        public const string ALinqLambdaNotSupported = "Lambda Expressions not supported.";
        public const string ALinqNewNotSupported = "New Expressions not supported.";
        public const string ALinqMemberInitNotSupported = "Member Init Expressions not supported.";
        public const string ALinqListInitNotSupported = "List Init Expressions not supported.";
        public const string ALinqNewArrayNotSupported = "New Array Expressions not supported.";
        public const string ALinqInvocationNotSupported = "Invocation Expressions not supported.";
        public const string ALinqUnsupportedExpression = "The expression type {0} is not supported.";
        public const string ALinqCanOnlyProjectTheLeaf = "Can only project the last entity type in the query being translated.";
        public const string ALinqCantCastToUnsupportedPrimitive = "Can't cast to unsupported type '{0}'";
        public const string ALinqCantTranslateExpression = "The expression {0} is not supported.";
        public const string ALinqCantNavigateWithoutKeyPredicate = "Navigation properties can only be selected from a single resource. Specify a key predicate to restrict the entity set to a single instance.";
        public const string ALinqCantReferToPublicField = "Referencing public field '{0}' not supported in query option expression.  Use public property instead.";
        public const string ALinqCannotConstructKnownEntityTypes = "Construction of entity type instances must use object initializer with default constructor.";
        public const string ALinqCannotCreateConstantEntity = "Referencing of local entity type instances not supported when projecting results.";
        public const string ALinqExpressionNotSupportedInProjectionToEntity = "Initializing instances of the entity type {0} with the expression {1} is not supported.";
        public const string ALinqExpressionNotSupportedInProjection = "Constructing or initializing instances of the type {0} with the expression {1} is not supported.";
        public const string ALinqProjectionMemberAssignmentMismatch = "Cannot initialize an instance of entity type '{0}' because '{1}' and '{2}' do not refer to the same source entity.";
        public const string ALinqPropertyNamesMustMatchInProjections = "Cannot assign the value from the {0} property to the {1} property.  When projecting results into a entity type, the property names of the source type and the target type must match for the properties being projected.";
        public const string ALinqQueryOptionOutOfOrder = "The {0} query option cannot be specified after the {1} query option.";
        public const string ALinqQueryOptionsOnlyAllowedOnLeafNodes = "Can only specify query options (orderby, where, take, skip) after last navigation.";
        public const string IQueryableExtensionObjectMustBeTableQuery = "Query must be a TableQuery<T>";
    }
}
