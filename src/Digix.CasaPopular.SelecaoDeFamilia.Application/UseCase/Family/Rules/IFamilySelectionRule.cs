using Digix.CasaPopular.SelecaoDeFamilia.Application.SeedWork;
using Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.CalculatesScore.Dto;

namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Family.Rules;
public interface IFamilySelectionRule : IRule<CalculateScoreInput, CalculateScoreOutput>
{
}
