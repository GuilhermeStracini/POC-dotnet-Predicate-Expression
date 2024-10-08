using System;
using System.Linq.Expressions;

namespace POCPredicate;

public static class Test
{
    public static void Resolve<T>(Expression<Func<T, bool>> predicate)
        where T : class, IEntity, new()
    {
        var param = predicate.Parameters[0];
        var operation = (BinaryExpression)predicate.Body;
        var left = (ParameterExpression)operation.Left;
        var right = (ConstantExpression)operation.Right;

        Console.WriteLine(
            "Decomposed expression: {0} => {1} {2} {3}",
            param.Name,
            left.Name,
            operation.NodeType,
            right.Value
        );
    }
}
