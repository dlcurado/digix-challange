using Digix.CasaPopular.SelecaoDeFamilia.Domain.Entity;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Exceptions;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.SeedWork;

namespace Digix.CasaPopular.SelecaoDeFamilia.Domain.Validators;
public class AgeSpecification : CompositeSpecification<Person>
{
    public override bool IsSatisfiedBy(Person pessoa)
    {
        if (pessoa.Age < 0)
            throw new EntityValidationException("Age cannot be less than zero");
        return true;
    }
}
