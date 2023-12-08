namespace Digix.CasaPopular.SelecaoDeFamilia.Application.SeedWork;
public interface IRule<TValidate, TUpdate>
{
    bool Matches(TValidate input);
    void Apply(TUpdate output);
}
