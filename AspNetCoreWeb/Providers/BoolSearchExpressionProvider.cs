using System;
using System.Linq.Expressions;

namespace JqueryDataTables.ServerSide.AspNetCoreWeb.Providers
{
    public class BoolSearchExpressionProvider : ComparableSearchExpressionProvider
    {
        public override ConstantExpression GetValue(string input)
        {
            if (input.ToLower() == "sim" || input.ToLower() == "yes")
                return Expression.Constant(true);

            if (input.ToLower() == "não" || input.ToLower() == "nao" || input.ToLower() == "no")
                return Expression.Constant(false);

            if (!bool.TryParse(input, out var value))
            {
                throw new ArgumentException("Invalid search value.");
            }

            return Expression.Constant(value);
        }
    }
}
