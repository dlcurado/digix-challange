namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.FamilySelection.Dto;

public class FamilySelectionFamilyOutput
{
    public string Responsible { get; set; }

    public int Income { get; set; }

    public int DependentsUnder18 { get; set; }
    
    public int Score { get; set; }

    public FamilySelectionFamilyOutput(string responsible, int income, int dependentsUnder18, int score)
    {
        Responsible = responsible;
        Income = income;
        DependentsUnder18 = dependentsUnder18;
        Score = score;
    }
}