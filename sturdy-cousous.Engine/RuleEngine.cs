using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Parser;
using System.Linq.Expressions;
using sturdy_couscous.Models.Helpers;

namespace sturdy_cousous.Engine;
public class RuleEngine
{
    public static Expression<Func<DeploymentContext, bool>> CreateExpression(string pattern)
    {
        var symbols = new[] { ExpressionHelper.ctx };
        Expression body = new ExpressionParser(
            symbols, pattern, null, new ParsingConfig()).Parse(typeof(bool));
        var response=  Expression.Lambda<Func<DeploymentContext, bool>>(body, symbols);

        return response;
    }

    public static Func<DeploymentContext, bool> CompileExpression(Expression<Func<DeploymentContext, bool>> lambdaExpression)
    {
        return lambdaExpression.Compile();
    }
}

