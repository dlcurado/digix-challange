using Bogus;
using Bogus.DataSets;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.FamilySelection.Dto;

namespace Digix.CasaPopular.SelecaoDeFamilia.UnitTest.Application.CalculateScore;

[CollectionDefinition(nameof(FamilySelectionTestsFixture))]
public class FamilySelectionTestsFixtureCollection
    : ICollectionFixture<FamilySelectionTestsFixture>
{

}

// Class to generate tests cenarios for families
public class FamilySelectionTestsFixture
{
    private Faker _faker = new Faker();
    internal FamilySelectionInput GetOneOfEachCenario()
    {
        FamilySelectionInput returnInput = new FamilySelectionInput();
        returnInput.Families = [
            this.GetFamilyWith_IncomeFrom901To1500_0Dependents(),
            this.GetFamilyWith_IncomeFrom901To1500_2OrLessElegibleDependents(),
            this.GetFamilyWith_IncomeFrom901To1500_3OrMoreElegibleDependents(),
            this.GetFamilyWith_IncomeMoreThan1500_0Dependents(),
            this.GetFamilyWith_IncomeMoreThan1500_2OrLessElegibleDependents(),
            this.GetFamilyWith_IncomeMoreThan1500_3OrMoreElegibleDependents(),
            this.GetFamilyWith_IncomeUpTo900_0Dependents(),
            this.GetFamilyWith_IncomeUpTo900_2OrLessElegibleDependents(),
            this.GetFamilyWith_IncomeUpTo900_3OrMoreElegibleDependents()
            ];
        return returnInput;
    }

    /// <summary>
    /// Get a family that has:
    /// - Income less than 900 
    /// - No denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    private FamilySelectionFamilyInput GetFamilyWith_IncomeUpTo900_0Dependents()
    {
        return new FamilySelectionFamilyInput(
            _faker.Person.FullName,
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
    private FamilySelectionFamilyInput GetFamilyWith_IncomeUpTo900_2OrLessElegibleDependents()
    {
        List<int> dependents = Get2OrLessElegibleDependents();

        return new FamilySelectionFamilyInput(
            _faker.Person.FullName,
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
    private FamilySelectionFamilyInput GetFamilyWith_IncomeUpTo900_3OrMoreElegibleDependents()
    {
        List<int> dependents = Get3OrMoreElegibleDependents();


        return new FamilySelectionFamilyInput(
            _faker.Person.FullName,
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
    private FamilySelectionFamilyInput GetFamilyWith_IncomeFrom901To1500_0Dependents()
    {
        return new FamilySelectionFamilyInput(
            _faker.Person.FullName,
            GetIncomeFrom901UpTo1500(),
            null
        );
    }

    /// <summary>
    /// Get a family that has:
    /// - Income more than 900 and less than 1500
    /// - 2 eligible denpendets
    /// </summary>
    /// <returns>CalculateScoreInput to calculate Score</returns>
    private FamilySelectionFamilyInput GetFamilyWith_IncomeFrom901To1500_2OrLessElegibleDependents()
    {
        List<int> dependents = Get2OrLessElegibleDependents();

        return new FamilySelectionFamilyInput(
            _faker.Person.FullName,
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
    private FamilySelectionFamilyInput GetFamilyWith_IncomeFrom901To1500_3OrMoreElegibleDependents()
    {
        List<int> dependents = Get3OrMoreElegibleDependents();


        return new FamilySelectionFamilyInput(
            _faker.Person.FullName,
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
    private FamilySelectionFamilyInput GetFamilyWith_IncomeMoreThan1500_0Dependents()
    {
        return new FamilySelectionFamilyInput(
            _faker.Person.FullName,
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
    private FamilySelectionFamilyInput GetFamilyWith_IncomeMoreThan1500_2OrLessElegibleDependents()
    {
        List<int> dependents = Get2OrLessElegibleDependents();

        return new FamilySelectionFamilyInput(
            _faker.Person.FullName,
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
    private FamilySelectionFamilyInput GetFamilyWith_IncomeMoreThan1500_3OrMoreElegibleDependents()
    {
        List<int> dependents = Get3OrMoreElegibleDependents();

        return new FamilySelectionFamilyInput(
            _faker.Person.FullName,
            GetIncomeMoreThan1500(),
            [.. dependents]
        );
    }

    private static List<int> Get3OrMoreElegibleDependents()
    {
        List<int> dependentsAge = [];
        // Creating more than 3 dependents (until 10)
        for (int i = 0; i < new Random().Next(3, 10); i++)
        {
            dependentsAge.Add(
                // Creating random ages until 17
                new Random().Next(0, 40)
            );
        }

        // Ensuring that the family has at least 3 eligible dependents
        var dependentIndex = 0;
        while (dependentsAge.Where(age => age < 18).Count() < 3)
        {
            if (dependentsAge[dependentIndex] > 17)
                dependentsAge[dependentIndex] = new Random().Next(0, 17);
            dependentIndex++;
        }

        return dependentsAge;
    }

    private static List<int> Get2OrLessElegibleDependents()
    {
        List<int> dependents = [];
        // Creating only two dependents
        for (int i = 0; i < 2; i++)
        {
            dependents.Add(
                // Creating random ages until 17
                new Random().Next(0, 17)
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
