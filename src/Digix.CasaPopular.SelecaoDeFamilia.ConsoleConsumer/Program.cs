// See https://aka.ms/new-console-template for more information
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.FamilySelection;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.FamilySelection.Dto;

var useCaseCalculateScore = new CalculateScore();
var useCase = new FamilySelection(useCaseCalculateScore);

var input = new FamilySelectionInput();
input.Families = [
    new FamilySelectionFamilyInput("Responsavel 1", 100, null),
    new FamilySelectionFamilyInput("Responsavel 2", 200, [0]),
    new FamilySelectionFamilyInput("Responsavel 3", 300, [10, 12]),
    new FamilySelectionFamilyInput("Responsavel 4", 400, [8, 10, 12, 18]),
    new FamilySelectionFamilyInput("Responsavel 5", 901, null),
    new FamilySelectionFamilyInput("Responsavel 6", 1200, [0]),
    new FamilySelectionFamilyInput("Responsavel 7", 1300, [10, 12]),
    new FamilySelectionFamilyInput("Responsavel 8", 1400, [8, 10, 12, 18]),
    new FamilySelectionFamilyInput("Responsavel 9", 2100, null),
    new FamilySelectionFamilyInput("Responsavel 10", 2200, [0]),
    new FamilySelectionFamilyInput("Responsavel 11", 2300, [10, 12]),
    new FamilySelectionFamilyInput("Responsavel 12", 2400, [8, 10, 12, 18]),
];
var output = useCase.Handle(input);

foreach (var family in output.Families)
    Console.WriteLine($"A familia de { family.Responsible } tem { family.DependentsUnder18 } dependentes elegíveis e sua renda é de { family.Income } = { family.Score } pontos");
