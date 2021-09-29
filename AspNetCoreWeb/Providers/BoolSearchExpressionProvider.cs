using System;
using System.Linq.Expressions;

namespace JqueryDataTables.ServerSide.AspNetCoreWeb.Providers
{
    public class BoolSearchExpressionProvider : ComparableSearchExpressionProvider
    {
        public override ConstantExpression GetValue(string input)
        {
            if (input.ToLower() == "sim" || input.ToLower() == "yes" || input.ToLower() == "1")
                return Expression.Constant(true);

            if (input.ToLower() == "não" || input.ToLower() == "nao" || input.ToLower() == "no" || input.ToLower() == "0")
                return Expression.Constant(false);

            if (!bool.TryParse(input, out var value))
            {
                return Expression.Constant(false);
            }

            return Expression.Constant(value);
        }
    }
}
