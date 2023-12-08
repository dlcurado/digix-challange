using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.Rules;
public class IncomeFrom901To1500 : IFamilySelectionRule
{
    /// <summary>
    /// Apply +3 points to the elegible family
    /// </summary>
    /// <returns>CalculateScoreOutput that contain:
    /// - Score (Int) applied in this rule
    /// </returns>
    public void Apply(CalculateScoreOutput output)
    {
        output.Score += 3;
    }

    /// <summary>
    /// If family has an income that more than 900 up to 1500.
    /// </summary>
    /// <param name="input">CalculateScoreInput that contain:
    /// - Income (Float) of the family
    /// - CalculateScoreDependentInput class that contain:
    /// --- Age (Int) of wich member of the family
    /// </param>
    /// <returns>True if the rule is valid for this family</returns>

    public bool Matches(CalculateScoreInput input)
    {
        return input.Income > 900 && input.Income <= 1500;
    }
}
