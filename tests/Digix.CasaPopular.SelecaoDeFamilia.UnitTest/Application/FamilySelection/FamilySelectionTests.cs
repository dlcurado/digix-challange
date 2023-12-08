using ApplicationUseCase = Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

namespace Digix.CasaPopular.SelecaoDeFamilia.UnitTest.Application.CalculateScore;

[Collection(nameof(FamilySelectionTestsFixture))]
public class FamilySelectionTests
{
    private readonly FamilySelectionTestsFixture _fixture;
    public FamilySelectionTests(FamilySelectionTestsFixture fixture) => _fixture = fixture;

    [Fact(DisplayName = nameof(ListOfFamilies_OneOfEachScore))]
    [Trait("Application", "Family Selection")]
    public void ListOfFamilies_OneOfEachScore()
    {
        var useCaseCalculateScore = 
            new ApplicationUseCase.CalculatesScore.CalculateScore();
        var useCaseFamilySelection = 
            new ApplicationUseCase.FamilySelection.FamilySelection(useCaseCalculateScore);

        var input = _fixture.GetOneOfEachCenario();
        var output = useCaseFamilySelection.Handle(input);

        Assert.Equal(9, output.Families.Count);
        foreach (var family in output.Families)
        {
            if (family.Income <= 900) {
                if (family.DependentsUnder18 > 0 && family.DependentsUnder18 <= 2)
                {
                    Assert.Equal(7, family.Score);
                }
                else if (family.DependentsUnder18 > 2)
                {
                    Assert.Equal(8, family.Score);
                }
                else
                {
                    Assert.Equal(5, family.Score);
                }
            }
            else if (family.Income > 900 && family.Income <= 1500) 
            {
                if (family.DependentsUnder18 > 0 && family.DependentsUnder18 <= 2)
                {
                    Assert.Equal(5, family.Score);
                }
                else if (family.DependentsUnder18 > 2)
                {
                    Assert.Equal(6, family.Score);
                }
                else
                {
                    Assert.Equal(3, family.Score);
                }
            }
            else
            {
                if (family.DependentsUnder18 > 0 && family.DependentsUnder18 <= 2)
                {
                    Assert.Equal(2, family.Score);
                }
                else if (family.DependentsUnder18 > 2)
                {
                    Assert.Equal(3, family.Score);
                }
                else
                {
                    Assert.Equal(0, family.Score);
                }
            }
        }
    }

    //[Fact(DisplayName = nameof(FamilyWith_IncomeUpTo900_2OrLessElegibleDependents))]
    //[Trait("Application", "Family Score Rules")]
    //public void FamilyWith_IncomeUpTo900_2OrLessElegibleDependents()
    //{
    //    var useCase = new ApplicationUseCase.CalculateScore();

    //    var input = _fixture.GetFamilyWith_IncomeUpTo900_2OrLessElegibleDependents();
    //    var output = useCase.Handle(input);

    //    Assert.Equal(7, output.Score);
    //}

    //[Fact(DisplayName = nameof(FamilyWith_IncomeUpTo900_3OrMoreElegibleDependents))]
    //[Trait("Application", "Family Score Rules")]
    //public void FamilyWith_IncomeUpTo900_3OrMoreElegibleDependents()
    //{
    //    var useCase = new ApplicationUseCase.CalculateScore();

    //    var input = _fixture.GetFamilyWith_IncomeUpTo900_3OrMoreElegibleDependents();
    //    var output = useCase.Handle(input);

    //    Assert.Equal(8, output.Score);
    //}


    //[Fact(DisplayName = nameof(FamilyWith_IncomeFrom901To1500_0Dependents))]
    //[Trait("Application", "Family Score Rules")]
    //public void FamilyWith_IncomeFrom901To1500_0Dependents()
    //{
    //    var useCase = new ApplicationUseCase.CalculateScore();

    //    var input = _fixture.GetFamilyWith_IncomeFrom901To1500_0Dependents();
    //    var output = useCase.Handle(input);

    //    Assert.Equal(3, output.Score);
    //}

    //[Fact(DisplayName = nameof(FamilyWith_IncomeFrom901To1500_2OrLessElegibleDependents))]
    //[Trait("Application", "Family Score Rules")]
    //public void FamilyWith_IncomeFrom901To1500_2OrLessElegibleDependents()
    //{
    //    var useCase = new ApplicationUseCase.CalculateScore();

    //    var input = _fixture.GetFamilyWith_IncomeFrom901To1500_2OrLessElegibleDependents();
    //    var output = useCase.Handle(input);

    //    Assert.Equal(5, output.Score);
    //}

    //[Fact(DisplayName = nameof(FamilyWith_IncomeFrom901To1500_3OrMoreElegibleDependents))]
    //[Trait("Application", "Family Score Rules")]
    //public void FamilyWith_IncomeFrom901To1500_3OrMoreElegibleDependents()
    //{
    //    var useCase = new ApplicationUseCase.CalculateScore();

    //    var input = _fixture.GetFamilyWith_IncomeFrom901To1500_3OrMoreElegibleDependents();
    //    var output = useCase.Handle(input);

    //    Assert.Equal(6, output.Score);
    //}

    //[Fact(DisplayName = nameof(FamilyWith_IncomeMoreThan1500_0Dependents))]
    //[Trait("Application", "Family Score Rules")]
    //public void FamilyWith_IncomeMoreThan1500_0Dependents()
    //{
    //    var useCase = new ApplicationUseCase.CalculateScore();

    //    var input = _fixture.GetFamilyWith_IncomeMoreThan1500_0Dependents();
    //    var output = useCase.Handle(input);

    //    Assert.Equal(0, output.Score);
    //}

    //[Fact(DisplayName = nameof(FamilyWith_IncomeMoreThan1500_2OrLessElegibleDependents))]
    //[Trait("Application", "Family Score Rules")]
    //public void FamilyWith_IncomeMoreThan1500_2OrLessElegibleDependents()
    //{
    //    var useCase = new ApplicationUseCase.CalculateScore();

    //    var input = _fixture.GetFamilyWith_IncomeMoreThan1500_2OrLessElegibleDependents();
    //    var output = useCase.Handle(input);

    //    Assert.Equal(2, output.Score);
    //}

    //[Fact(DisplayName = nameof(FamilyWith_IncomeMoreThan1500_3OrMoreElegibleDependents))]
    //[Trait("Application", "Family Score Rules")]
    //public void FamilyWith_IncomeMoreThan1500_3OrMoreElegibleDependents()
    //{
    //    var useCase = new ApplicationUseCase.CalculateScore();

    //    var input = _fixture.GetFamilyWith_IncomeMoreThan1500_3OrMoreElegibleDependents();
    //    var output = useCase.Handle(input);

    //    Assert.Equal(3, output.Score);
    //}
}
