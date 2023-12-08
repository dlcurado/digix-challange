using Digix.CasaPopular.SelecaoDeFamilia.Domain.Exceptions;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Validators;
using System.Xml.Linq;

namespace Digix.CasaPopular.SelecaoDeFamilia.Domain.Entity;
public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age) {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;

        Validate();
    }

    private void Validate()
    {
        var nameValidation = new NameSpecification();
        var ageValidation = new AgeSpecification();
        nameValidation.And(ageValidation).IsSatisfiedBy(this);
    }
}
