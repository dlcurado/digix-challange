
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Entity;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Exceptions;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.SeedWork;

namespace Digix.CasaPopular.SelecaoDeFamilia.Domain.Validators;
public class NameSpecification : CompositeSpecification<Person>
{
    public override bool IsSatisfiedBy(Person person)
    {
        if (string.IsNullOrWhiteSpace(person.Name))
            throw new EntityValidationException("The name cannot be null or blank");
        
        return true;
    }
}
