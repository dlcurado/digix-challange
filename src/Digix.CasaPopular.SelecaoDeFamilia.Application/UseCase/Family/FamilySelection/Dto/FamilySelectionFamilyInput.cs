namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.FamilySelection.Dto;

public class FamilySelectionFamilyInput
{
    public string Responsible { get; internal set; }
    
    public int Income { get; set; }
    
    public List<int> DependentsAge { get; set; }
    
    public FamilySelectionFamilyInput(string responsible, int income, List<int> dependentsAge)
    {
        Responsible = responsible;
        Income = income;
        DependentsAge = dependentsAge;
    }
}