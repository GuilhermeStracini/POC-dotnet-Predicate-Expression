using System;
using System.Linq.Expressions;

namespace PredicateTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test.Resolve<Teste>(t =>
                t.IsActive && t.Name == "Test" && t.Document == "1" ||
                t.Name == "or" && t.Document == "2" ||
                t.Document == "3" ||
                !t.IsActive);

        }


    }


    public interface IEntity { }

    public class Teste : IEntity
    {
        public bool IsActive { get; set; }

        public string Document { get; set; }

        public string Name { get; set; }
    }

    public static class Test
    {
        public static void Resolve<T>(Expression<Func<T, bool>> predicate) where T : class, IEntity, new()
        {
            var param = (ParameterExpression)predicate.Parameters[0];
            var operation = (BinaryExpression)predicate.Body;
            var left = (ParameterExpression)operation.Left;
            var right = (ConstantExpression)operation.Right;

            Console.WriteLine("Decomposed expression: {0} => {1} {2} {3}",
                param.Name, left.Name, operation.NodeType, right.Value);
        }
    }
}

