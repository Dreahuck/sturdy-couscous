using System;
using System.Linq.Expressions;
using sturdy_couscous.Models.Helpers;

namespace sturdy_cousous.Engine
{
	public class ExpressionHelper
	{
		private static readonly string _ctxName = "ctx";
		public static ParameterExpression ctx = Expression.Parameter(typeof(DeploymentContext), _ctxName);
	}
}

