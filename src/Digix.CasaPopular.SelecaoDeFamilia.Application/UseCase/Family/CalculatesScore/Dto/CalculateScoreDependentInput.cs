namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

public class CalculateScoreDependentInput
{
    public int Age { get; set; }

    public CalculateScoreDependentInput(int age)
    {
        Age = age;
    }
}