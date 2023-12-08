using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

namespace Digix.CasaPopular.SelecaoDeFamilia.UnitTest.Application.CalculateScore;

[CollectionDefinition(nameof(FamilyScoreTestsFixture))]
public class FamilyScoreTestsFixtureCollection
    : ICollectionFixture<FamilyScoreTestsFixture>
{

}

// Class to generate tests cenarios for families
public class FamilyScoreTestsFixture
{
    /// <summary>
    /// Get a family that has:
    /// - Income less than 900 
    /// - No denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    public CalculateScoreInput GetFamilyWith_IncomeUpTo900_0Dependents()
    {
        return new CalculateScoreInput(
            GetIncomeUpTo900(),
            null!
        );
    }

    

    /// <summary>
    /// Get a family that has:
    /// - Income less than 900 
    /// - 2 eligible denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    public CalculateScoreInput GetFamilyWith_IncomeUpTo900_2OrLessElegibleDependents()
    {
        List<CalculateScoreDependentInput> dependents = Get2OrLessElegibleDependents();

        return new CalculateScoreInput(
            GetIncomeUpTo900(),
            [.. dependents]
        );
    }

    


    /// <summary>
    /// Get a family that has:
    /// - Income less than 900 
    /// - 3 or more eligible denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    internal CalculateScoreInput GetFamilyWith_IncomeUpTo900_3OrMoreElegibleDependents()
    {
        List<CalculateScoreDependentInput> dependents = Get3OrMoreElegibleDependents();


        return new CalculateScoreInput(
            GetIncomeUpTo900(),
            [.. dependents]
        );
    }


    /// <summary>
    /// Get a family that has:
    /// - Income more than 1500 and less than 1500
    /// - No denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    internal CalculateScoreInput GetFamilyWith_IncomeFrom901To1500_0Dependents()
    {
        return new CalculateScoreInput(
            GetIncomeFrom901UpTo1500(),
            null!
        );
    }

    /// <summary>
    /// Get a family that has:
    /// - Income more than 900 and less than 1500
    /// - 2 eligible denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    internal CalculateScoreInput GetFamilyWith_IncomeFrom901To1500_2OrLessElegibleDependents()
    {
        List<CalculateScoreDependentInput> dependents = Get2OrLessElegibleDependents();

        return new CalculateScoreInput(
            GetIncomeFrom901UpTo1500(),
            [.. dependents]
        );
    }

    

    /// <summary>
    /// Get a family that has:
    /// - Income more than 900 and less than 1500
    /// - 3 or more eligible denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    internal CalculateScoreInput GetFamilyWith_IncomeFrom901To1500_3OrMoreElegibleDependents()
    {
        List<CalculateScoreDependentInput> dependents = Get3OrMoreElegibleDependents();


        return new CalculateScoreInput(
            GetIncomeFrom901UpTo1500(),
            [.. dependents]
        );
    }


    /// <summary>
    /// Get a family that has:
    /// - Income more than 1500
    /// - No denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    internal CalculateScoreInput GetFamilyWith_IncomeMoreThan1500_0Dependents()
    {
        return new CalculateScoreInput(
            GetIncomeMoreThan1500(),
            null!
        );
    }

    

    /// <summary>
    /// Get a family that has:
    /// - Income more than 1500
    /// - 2 eligible denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    internal CalculateScoreInput GetFamilyWith_IncomeMoreThan1500_2OrLessElegibleDependents()
    {
        List<CalculateScoreDependentInput> dependents = Get2OrLessElegibleDependents();

        return new CalculateScoreInput(
            GetIncomeMoreThan1500(),
            [.. dependents]
        );
    }

    /// <summary>
    /// Get a family that has:
    /// - Income more than 1500
    /// - 3 or more eligible denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    internal CalculateScoreInput GetFamilyWith_IncomeMoreThan1500_3OrMoreElegibleDependents()
    {
        List<CalculateScoreDependentInput> dependents = Get3OrMoreElegibleDependents();

        return new CalculateScoreInput(
            GetIncomeMoreThan1500(),
            [.. dependents]
        );
    }

    private static List<CalculateScoreDependentInput> Get3OrMoreElegibleDependents()
    {
        List<CalculateScoreDependentInput> dependents = [];
        // Creating more than 3 dependents (until 10)
        for (int i = 0; i < new Random().Next(3, 10); i++)
        {
            dependents.Add(
                new CalculateScoreDependentInput(
                    // Creating random ages until 17
                    new Random().Next(0, 40)
                )
            );
        }

        // Ensuring that the family has at least 3 eligible dependents
        var dependentIndex = 0;
        while (dependents.Where(dependent => dependent.Age < 18).Count() < 3)
        {
            if (dependents[dependentIndex].Age > 17)
                dependents[dependentIndex].Age = new Random().Next(0, 17);
            dependentIndex++;
        }

        return dependents;
    }

    private static List<CalculateScoreDependentInput> Get2OrLessElegibleDependents()
    {
        List<CalculateScoreDependentInput> dependents = [];
        // Creating only two dependents
        for (int i = 0; i < 2; i++)
        {
            dependents.Add(
                new CalculateScoreDependentInput(
                    // Creating random ages until 17
                    new Random().Next(0, 17)
                )
            );
        }

        return dependents;
    }

    private static int GetIncomeUpTo900()
    {
        return new Random().Next(0, 900);
    }

    private static int GetIncomeFrom901UpTo1500()
    {
        return new Random().Next(901, 1500);
    }

    private static int GetIncomeMoreThan1500()
    {
        return new Random().Next(1500, 1000000000);
    }
}
