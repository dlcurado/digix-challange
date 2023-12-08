using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.Rules;

namespace Digix.CasaPopular.SelecaoDeFamilia.UnitTest.Application.Rules;
public class RulesTests
{
    [Fact(DisplayName = nameof(IncomeFrom901To1500_InsideTheRange_Return5))]
    [Trait("Application", "Score Rules")]
    public void IncomeFrom901To1500_InsideTheRange_Return5()
    {
        var rule = new IncomeFrom901To1500();

        var input = new CalculateScoreInput(901);
        var output = new CalculateScoreOutput(0);

        if (rule.Matches(input))
            rule.Apply(output);

        Assert.Equal(3, output.Score);
    }

    [Fact(DisplayName = nameof(IncomeFrom901To1500_OutOfRange_Return0))]
    [Trait("Application", "Score Rules")]
    public void IncomeFrom901To1500_OutOfRange_Return0()
    {
        var rule = new IncomeFrom901To1500();

        var input = new CalculateScoreInput(900);
        var output = new CalculateScoreOutput(0);

        if (rule.Matches(input))
            rule.Apply(output);

        Assert.Equal(0, output.Score);
    }

    [Fact(DisplayName = nameof(IncomeUpTo900_InsideTheRange_Return5))]
    [Trait("Application", "Score Rules")]
    public void IncomeUpTo900_InsideTheRange_Return5()
    {
        var rule = new IncomeUpTo900Rule();

        var input = new CalculateScoreInput(900);
        var output = new CalculateScoreOutput(0);

        if (rule.Matches(input))
            rule.Apply(output);

        Assert.Equal(5, output.Score);
    }

    [Fact(DisplayName = nameof(IncomeUpTo900_OutOfRange_Return0))]
    [Trait("Application", "Score Rules")]
    public void IncomeUpTo900_OutOfRange_Return0()
    {
        var rule = new IncomeUpTo900Rule();

        var input = new CalculateScoreInput(901);
        var output = new CalculateScoreOutput(0);

        if (rule.Matches(input))
            rule.Apply(output);

        Assert.Equal(0, output.Score);
    }

    [Fact(DisplayName = nameof(ValidDependentsUpTo2_InsideTheRange_Return2))]
    [Trait("Application", "Score Rules")]
    public void ValidDependentsUpTo2_InsideTheRange_Return2()
    {
        var rule = new ValidDependentsUpTo2();

        var input = new CalculateScoreInput(
            0,
            [
                new CalculateScoreDependentInput(10)
            ]
        );
        var output = new CalculateScoreOutput(0);

        if (rule.Matches(input))
            rule.Apply(output);

        Assert.Equal(2, output.Score);
    }

    [Fact(DisplayName = nameof(ValidDependentsUpTo2_OutOfRange_Return0))]
    [Trait("Application", "Score Rules")]
    public void ValidDependentsUpTo2_OutOfRange_Return0()
    {
        var rule = new ValidDependentsUpTo2();

        var input = new CalculateScoreInput(
            0,
            [
                new CalculateScoreDependentInput(18)
            ]
        );
        var output = new CalculateScoreOutput(0);

        if (rule.Matches(input))
            rule.Apply(output);

        Assert.Equal(2, output.Score);
    }

    [Fact(DisplayName = nameof(ValidDependentsMoreThan2_InsideTheRange_Return2))]
    [Trait("Application", "Score Rules")]
    public void ValidDependentsMoreThan2_InsideTheRange_Return2()
    {
        var rule = new ValidDependentsMoreThan2();

        var input = new CalculateScoreInput(
            0,
            [
                new CalculateScoreDependentInput(8),
                new CalculateScoreDependentInput(10),
                new CalculateScoreDependentInput(17)
            ]
        );
        var output = new CalculateScoreOutput(0);

        if (rule.Matches(input))
            rule.Apply(output);

        Assert.Equal(3, output.Score);
    }

    [Fact(DisplayName = nameof(ValidDependentsMoreThan2_OutOfRange_Return0))]
    [Trait("Application", "Score Rules")]
    public void ValidDependentsMoreThan2_OutOfRange_Return0()
    {
        var rule = new ValidDependentsUpTo2();

        var input = new CalculateScoreInput(
            0,
            [
                new CalculateScoreDependentInput(18),
                new CalculateScoreDependentInput(19),
                new CalculateScoreDependentInput(17)
            ]
        );
        var output = new CalculateScoreOutput(0);

        if (rule.Matches(input))
            rule.Apply(output);

        Assert.Equal(2, output.Score);
    }
}
