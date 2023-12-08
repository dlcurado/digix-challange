using Bogus;
using DomainEntity = Digix.CasaPopular.SelecaoDeFamilia.Domain.Entity;
using Digix.CasaPopular.SelecaoDeFamilia.Domain.Exceptions;

namespace Digix.CasaPopular.SelecaoDeFamilia.UnitTest.Domain;
public class PeopleCreationTests
{
    private Faker _faker = new Faker();

    [Fact(DisplayName = nameof(PersonCreation))]
    [Trait("Domain", "People - Aggregates")]
    public void PersonCreation()
    {
        var validData = new
        {
            Name = _faker.Person.FullName,
            Age = 32
        };

        // Pessoa - Nome, idade
        var pessoa = new DomainEntity.Person(validData.Name, validData.Age);

        Assert.NotNull(pessoa);
        Assert.Equal(validData.Name, pessoa.Name);
        Assert.Equal(validData.Age, pessoa.Age);
        Assert.NotEqual(default, pessoa.Id);
    }

    [Theory(DisplayName = nameof(CreatePersonShouldThrowExceptionWhenNameIsNullOrEmpty))]
    [Trait("Domain", "People - Aggregates")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void CreatePersonShouldThrowExceptionWhenNameIsNullOrEmpty(string name)
    {
        Action action = () => new DomainEntity.Person(name, 32);
        var execption = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("The name cannot be null or blank", execption.Message);
    }

    [Theory(DisplayName = nameof(CreatePersonShouldThrowExceptionWhenAngeIsLessThanZero))]
    [Trait("Domain", "People - Aggregates")]
    [InlineData(-10)]
    [InlineData(-1)]
    public void CreatePersonShouldThrowExceptionWhenAngeIsLessThanZero(int idade)
    {
        Action action = () => new DomainEntity.Person(_faker.Person.FullName, idade);
        var execption = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Age cannot be less than zero", execption.Message);
    }
}
