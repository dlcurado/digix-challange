namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

public class CalculateScoreInput
{
    public float Income { get; private set; }
    public CalculateScoreDependentInput[] Dependents { get; private set; }

    public CalculateScoreInput(float income, CalculateScoreDependentInput[] dependents = null!)
    {
        Income = income;
        Dependents = dependents;
    }
}