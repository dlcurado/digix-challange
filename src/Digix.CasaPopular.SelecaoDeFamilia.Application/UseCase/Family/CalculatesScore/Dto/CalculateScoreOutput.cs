namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

public class CalculateScoreOutput
{
    public int Score { get; set; }

    public CalculateScoreOutput(int score)
    {
        Score = score;
    }
}