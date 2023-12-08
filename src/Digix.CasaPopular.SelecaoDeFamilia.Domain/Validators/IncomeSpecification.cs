
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Entity;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Exceptions;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.SeedWork;

namespace Digix.CasaPopular.SelecaoDeFamilia.Domain.Validators;
public class IncomeSpecification : CompositeSpecification<Family>
{
    public override bool IsSatisfiedBy(Family family)
    {
        if (family.Income < 0)
            throw new EntityValidationException($"Income cannot be less than zero");

        return true;
    }
}
