
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Exceptions;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Validators;

namespace Digix.CasaPopular.SelecaoDeFamilia.Domain.Entity;
public class Family
{
    public Person Responsible { get; private set; }
    public Person[] Dependents { get; private set; }
    public float Income { get; private set; }
    
    public Family(Person responsible, Person[] dependents, float income)
    {
        Responsible = responsible;
        Dependents = dependents;
        Income = income;

        Validate();
    }

    private void Validate()
    {
        var rendaValidation = new IncomeSpecification();
        rendaValidation.IsSatisfiedBy(this);
    }
}
