using sturdy_couscous.Models.Helpers;
using sturdy_cousous.Engine;

namespace sturdy_couscous.Tests;

public class RuleEngineTests
{
    [Theory]
    [InlineData(2024,03,25, true)]
    [InlineData(2024, 03, 24, false)]
    public void ShouldCreateIsMonday(int year, int month, int day, bool expectedResult)
    {
        var context = new DeploymentContext {
            Date = new DateTime(year, month, day),
            ParamString1 = "TOTO"
        };

        var pattern = "ctx.Date.DayOfWeek == DayOfWeek.Monday";
        var lambda = RuleEngine.CreateExpression(pattern);
        var isMonday = RuleEngine.CompileExpression(lambda);
        Assert.Equal(expectedResult, isMonday(context));
    }

    [Theory]
    [InlineData(2024, 03, 25, "TOTO", true)]
    [InlineData(2024, 03, 24, "TOTO", false)]
    [InlineData(2024, 03, 25, "TATO", false)]
    public void ShouldCreateIsMondayIfInputToto(int year, int month, int day, string input, bool expectedResult)
    {
        var context = new DeploymentContext
        {
            Date = new DateTime(year, month, day),
            ParamString1 = input
        };

        var pattern = "ctx.Date.DayOfWeek == DayOfWeek.Monday && ctx.ParamString1 == \"TOTO\"";
        var lambda = RuleEngine.CreateExpression(pattern);
        var isMonday = RuleEngine.CompileExpression(lambda);
        Assert.Equal(expectedResult, isMonday(context));
    } 
}
