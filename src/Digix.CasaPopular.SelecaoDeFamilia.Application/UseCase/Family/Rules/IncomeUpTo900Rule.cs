using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.Rules;
public class IncomeUpTo900Rule : IFamilySelectionRule
{
    /// <summary>
    /// Apply +5 points to the elegible family
    /// </summary>
    /// <returns>CalculateScoreOutput that contain:
    /// - Score (Int) applied in this rule
    /// </returns>
    public void Apply(CalculateScoreOutput output)
    {
        output.Score += 5;
    }

    /// <summary>
    /// If family has an income that is up to 900.
    /// </summary>
    /// <param name="input">CalculateScoreInput that contain:
    /// - Income (Float) of the family
    /// - CalculateScoreDependentInput class that contain:
    /// --- Age (Int) of wich member of the family
    /// </param>
    /// <returns>True if the rule is valid for this family</returns>
    public bool Matches(CalculateScoreInput entity)
    {
        return entity.Income >= 0 && entity.Income <= 900;
    }
}
