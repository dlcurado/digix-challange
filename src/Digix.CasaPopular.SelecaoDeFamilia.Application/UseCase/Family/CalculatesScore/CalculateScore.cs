using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.Rules;

namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore;
public class CalculateScore : ICalculateScore
{
    // List tha will contain all Rules that implement IFamilySelectionRule interfaces
    // to be applied when score is calculated
    private List<IFamilySelectionRule> regrasSelecao;

    /// <summary>
    /// Constructor os UseCase to Calculate Score
    /// PS: At this point we don`t need Repository or Unit Of Work because we still not
    /// working to persist the infos
    /// </summary>
    public CalculateScore()
    {
        // Getting all implementations of IFamilySelectionRule to apply when
        // calculate the family score
        regrasSelecao = new List<IFamilySelectionRule>();
        List<Type> types = new List<Type>();
        foreach (Type rule in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
            .Where(rule => rule.GetInterfaces().Contains(typeof(IFamilySelectionRule))))
        {
            types.Add(rule);
            regrasSelecao.Add((IFamilySelectionRule)Activator.CreateInstance(rule)!);
        }
    }

    /// <summary>
    /// Method that handle the rules of family score calculation
    /// </summary>
    /// <param name="input">CalculateScoreInput that contain:
    /// - Income (Float) of the family
    /// - CalculateScoreDependentInput class that contain:
    /// --- Age (Int) of wich member of the family
    /// </param>
    /// <returns>CalculateScoreOutput that contain:
    /// - Score (Int) that is the total family
    /// </returns>
    public CalculateScoreOutput Handle(CalculateScoreInput input)
    {
        var output = new CalculateScoreOutput(0);
        // For each rules finded in reflection that match the condition implemented
        foreach (var regra in regrasSelecao.Where(regra => regra.Matches(input)))
        {
            // Apply the score calculation
            regra.Apply(output);
        }

        return output;
    }
}
