using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.FamilySelection.Dto;

namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.FamilySelection;
public class FamilySelection : IFamilySelection
{
    private ICalculateScore UseCaseCalculateScore { get; }

    public FamilySelection(ICalculateScore useCaseCalculateScore)
    {
        UseCaseCalculateScore = useCaseCalculateScore;
    }

    
    /// <summary>
    /// Method that handle the list of family and score each one
    /// </summary>
    /// <param name="input">FamilySelectionInput that contain:
    /// 
    /// </param>
    /// <returns>FamilySelectionOutput that contain:
    /// - Score (Int) that is the total family
    /// </returns>
    public FamilySelectionOutput Handle(FamilySelectionInput input)
    {
        var returnOutput = new FamilySelectionOutput();
        returnOutput.Families = new List<FamilySelectionFamilyOutput>();

        foreach (var family in input.Families)
        {
            List<CalculateScoreDependentInput>? dependents = null;
            if(family.DependentsAge != null)
            {
                dependents = [];
                foreach (var dependentAge in family.DependentsAge)
                {
                    dependents.Add(new CalculateScoreDependentInput(dependentAge));
                }
            }

            var calculateScoreInput = new CalculateScoreInput(
                family.Income,
                dependents != null ? dependents.ToArray() : null!
                );

            var familyScore = UseCaseCalculateScore.Handle(calculateScoreInput);

            returnOutput.Families.Add(new FamilySelectionFamilyOutput(
                family.Responsible,
                family.Income,
                family.DependentsAge != null ? family.DependentsAge.Where(age => age < 18).Count() : 0,
                familyScore.Score
            ));
        }
        return returnOutput;
    }
}
