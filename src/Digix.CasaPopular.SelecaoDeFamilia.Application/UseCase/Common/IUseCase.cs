namespace Digix.CasaPopular.SelecaoDeFamilia.Application.UseCase.Common;
public interface IUseCase<TInput, TOutput>
{
    public TOutput Handle(TInput input);
}
