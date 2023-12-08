using ApplicationUseCase = Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

namespace Digix.CasaPopular.SelecaoDeFamilia.UnitTest.Application.CalculateScore;

[Collection(nameof(FamilyScoreTestsFixture))]
public class FamilyScoreTests
{
    private readonly FamilyScoreTestsFixture _fixture;
    public FamilyScoreTests(FamilyScoreTestsFixture fixture) => _fixture = fixture;

    [Fact(DisplayName = nameof(FamilyWith_IncomeUpTo900_0Dependents))]
    [Trait("Application", "Family Score Rules")]
    public void FamilyWith_IncomeUpTo900_0Dependents()
    {
        var useCase = new ApplicationUseCase.CalculateScore();

        var input = _fixture.GetFamilyWith_IncomeUpTo900_0Dependents();
        var output = useCase.Handle(input);

        Assert.Equal(5, output.Score);
    }

    [Fact(DisplayName = nameof(FamilyWith_IncomeUpTo900_2OrLessElegibleDependents))]
    [Trait("Application", "Family Score Rules")]
    public void FamilyWith_IncomeUpTo900_2OrLessElegibleDependents()
    {
        var useCase = new ApplicationUseCase.CalculateScore();

        var input = _fixture.GetFamilyWith_IncomeUpTo900_2OrLessElegibleDependents();
        var output = useCase.Handle(input);

        Assert.Equal(7, output.Score);
    }

    [Fact(DisplayName = nameof(FamilyWith_IncomeUpTo900_3OrMoreElegibleDependents))]
    [Trait("Application", "Family Score Rules")]
    public void FamilyWith_IncomeUpTo900_3OrMoreElegibleDependents()
    {
        var useCase = new ApplicationUseCase.CalculateScore();

        var input = _fixture.GetFamilyWith_IncomeUpTo900_3OrMoreElegibleDependents();
        var output = useCase.Handle(input);

        Assert.Equal(8, output.Score);
    }


    [Fact(DisplayName = nameof(FamilyWith_IncomeFrom901To1500_0Dependents))]
    [Trait("Application", "Family Score Rules")]
    public void FamilyWith_IncomeFrom901To1500_0Dependents()
    {
        var useCase = new ApplicationUseCase.CalculateScore();

        var input = _fixture.GetFamilyWith_IncomeFrom901To1500_0Dependents();
        var output = useCase.Handle(input);

        Assert.Equal(3, output.Score);
    }

    [Fact(DisplayName = nameof(FamilyWith_IncomeFrom901To1500_2OrLessElegibleDependents))]
    [Trait("Application", "Family Score Rules")]
    public void FamilyWith_IncomeFrom901To1500_2OrLessElegibleDependents()
    {
        var useCase = new ApplicationUseCase.CalculateScore();

        var input = _fixture.GetFamilyWith_IncomeFrom901To1500_2OrLessElegibleDependents();
        var output = useCase.Handle(input);

        Assert.Equal(5, output.Score);
    }

    [Fact(DisplayName = nameof(FamilyWith_IncomeFrom901To1500_3OrMoreElegibleDependents))]
    [Trait("Application", "Family Score Rules")]
    public void FamilyWith_IncomeFrom901To1500_3OrMoreElegibleDependents()
    {
        var useCase = new ApplicationUseCase.CalculateScore();

        var input = _fixture.GetFamilyWith_IncomeFrom901To1500_3OrMoreElegibleDependents();
        var output = useCase.Handle(input);

        Assert.Equal(6, output.Score);
    }

    [Fact(DisplayName = nameof(FamilyWith_IncomeMoreThan1500_0Dependents))]
    [Trait("Application", "Family Score Rules")]
    public void FamilyWith_IncomeMoreThan1500_0Dependents()
    {
        var useCase = new ApplicationUseCase.CalculateScore();

        var input = _fixture.GetFamilyWith_IncomeMoreThan1500_0Dependents();
        var output = useCase.Handle(input);

        Assert.Equal(0, output.Score);
    }

    [Fact(DisplayName = nameof(FamilyWith_IncomeMoreThan1500_2OrLessElegibleDependents))]
    [Trait("Application", "Family Score Rules")]
    public void FamilyWith_IncomeMoreThan1500_2OrLessElegibleDependents()
    {
        var useCase = new ApplicationUseCase.CalculateScore();

        var input = _fixture.GetFamilyWith_IncomeMoreThan1500_2OrLessElegibleDependents();
        var output = useCase.Handle(input);

        Assert.Equal(2, output.Score);
    }

    [Fact(DisplayName = nameof(FamilyWith_IncomeMoreThan1500_3OrMoreElegibleDependents))]
    [Trait("Application", "Family Score Rules")]
    public void FamilyWith_IncomeMoreThan1500_3OrMoreElegibleDependents()
    {
        var useCase = new ApplicationUseCase.CalculateScore();

        var input = _fixture.GetFamilyWith_IncomeMoreThan1500_3OrMoreElegibleDependents();
        var output = useCase.Handle(input);

        Assert.Equal(3, output.Score);
    }
}
