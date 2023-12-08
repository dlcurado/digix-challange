using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.Rules;
public class ValidDependentsUpTo2 : IFamilySelectionRule
{
    /// <summary>
    /// Apply +2 points to the elegible family
    /// </summary>
    /// <returns>CalculateScoreOutput that contain:
    /// - Score (Int) applied in this rule
    /// </returns>
    public void Apply(CalculateScoreOutput output)
    {
        output.Score += 2;
    }

    /// <summary>
    /// If family contain up to 2 dependents that have less than 18 years old.
    /// </summary>
    /// <param name="input">CalculateScoreInput that contain:
    /// - Income (Float) of the family
    /// - CalculateScoreDependentInput class that contain:
    /// --- Age (Int) of wich member of the family
    /// </param>
    /// <returns>True if the rule is valid for this family</returns>
    public bool Matches(CalculateScoreInput input)
    {
        return input.Dependents != null && 
            input.Dependents.Where((dependent) => dependent.Age < 18).Count() <= 2;
    }
}
