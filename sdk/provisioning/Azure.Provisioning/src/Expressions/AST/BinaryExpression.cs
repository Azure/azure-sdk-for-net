// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

public enum BinaryBicepOperator { And, Or, Coalesce, Equal, EqualIgnoreCase, NotEqual, NotEqualIgnoreCase, Greater, GreaterOrEqual, Less, LessOrEqual, Add, Subtract, Multiply, Divide, Modulo }

public class BinaryExpression(BicepExpression left, BinaryBicepOperator op, BicepExpression right) : BicepExpression
{
    public BicepExpression Left { get; } = left;
    public BinaryBicepOperator Operator { get; } = op;
    public BicepExpression Right { get; } = right;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append('(').Append(Left).Append(' ')
   .Append(
       Operator switch
      {
      BinaryBicepOperator.And => "&&",
            BinaryBicepOperator.Or => "||",
     BinaryBicepOperator.Coalesce => "??",
     BinaryBicepOperator.Equal => "==",
     BinaryBicepOperator.EqualIgnoreCase => "=~",
   BinaryBicepOperator.NotEqual => "!=",
       BinaryBicepOperator.NotEqualIgnoreCase => "!~",
  BinaryBicepOperator.Greater => ">",
     BinaryBicepOperator.GreaterOrEqual => ">=",
   BinaryBicepOperator.Less => "<",
     BinaryBicepOperator.LessOrEqual => "<=",
   BinaryBicepOperator.Add => "+",
    BinaryBicepOperator.Subtract => "-",
 BinaryBicepOperator.Multiply => "*",
    BinaryBicepOperator.Divide => "/",
       BinaryBicepOperator.Modulo => "%",
_ => throw new NotImplementedException($"Unknown {nameof(BinaryBicepOperator)} value {Operator}"),
     })
      .Append(' ').Append(Right).Append(')');
}
