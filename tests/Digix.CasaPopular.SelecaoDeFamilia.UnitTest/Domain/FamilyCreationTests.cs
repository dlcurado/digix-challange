using Bogus;
using DomainEntity = Digix.CasaPopular.SelecaoDeFamilia.Domain.Entity;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Exceptions;

namespace Digix.CasaPopular.SelecaoDeFamilia.UnitTest.Domain;

public class FamilyCreationTests
{
    private Faker _faker = new Faker();
    private DomainEntity.Person responsible;
    private DomainEntity.Person dependent1;
    private DomainEntity.Person dependent2;
    private DomainEntity.Person dependent3;
    public FamilyCreationTests()
    {
        responsible = new DomainEntity.Person(_faker.Person.FullName, 32);
        dependent1 = new DomainEntity.Person(_faker.Person.FullName, 2);
        dependent2 = new DomainEntity.Person(_faker.Person.FullName, 6);
        dependent3 = new DomainEntity.Person(_faker.Person.FullName, 21);
    }


    [Fact(DisplayName = nameof(FamilyCreation))]
    [Trait("Domain", "Family - Aggregates")]
    public void FamilyCreation()
    {
        var dependents = new DomainEntity.Person[] { dependent1, dependent2, dependent3 };

        var family = new DomainEntity.Family(responsible, dependents, 100);

        Assert.NotNull(family);
        Assert.Equal(responsible.Name, family.Responsible.Name);
        Assert.Equal(responsible.Age, family.Responsible.Age);

        Assert.Equal(3, family.Dependents.Length);
    }


    [Fact(DisplayName = nameof(FamilyCreationShouldThrowExceptionWhenIncomeIsNegative))]
    [Trait("Domain", "Family - Aggregates")]
    public void FamilyCreationShouldThrowExceptionWhenIncomeIsNegative()
    {
        var dependentes = new DomainEntity.Person[] { dependent1, dependent2, dependent3 };

        Action action = () => new DomainEntity.Family(responsible, dependentes, -1);
        var execption = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Income cannot be less than zero", execption.Message);
    }
}