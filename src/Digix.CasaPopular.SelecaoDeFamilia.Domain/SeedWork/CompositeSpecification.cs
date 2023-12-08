namespace Digix.CasaPopular.SelecaoDeFamilia.Domain.SeedWork;
public abstract class CompositeSpecification<T> : ISpecification<T>
{
    public abstract bool IsSatisfiedBy(T entity);
    public ISpecification<T> And(ISpecification<T> other) =>
        new AndSpecification<T>(this, other);
    public ISpecification<T> AndNot(ISpecification<T> other) =>
        new AndNotSpecification<T>(this, other);
    public ISpecification<T> Or(ISpecification<T> other) =>
        new OrSpecification<T>(this, other);
    public ISpecification<T> OrNot(ISpecification<T> other) =>
        new OrNotSpecification<T>(this, other);
    public ISpecification<T> Not() =>
        new NotSpecification<T>(this);
}


internal class AndSpecification<T> : CompositeSpecification<T>
{
    ISpecification<T> _leftSpecification;
    ISpecification<T> _rightSpecification;

    public AndSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
    {
        _leftSpecification = leftSpecification;
        _rightSpecification = rightSpecification;
    }

    public override bool IsSatisfiedBy(T entity) =>
        _leftSpecification.IsSatisfiedBy(entity) &&
        _rightSpecification.IsSatisfiedBy(entity);
}

internal class AndNotSpecification<T> : CompositeSpecification<T>
{
    ISpecification<T> _leftSpecification;
    ISpecification<T> _rightSpecification;

    public AndNotSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
    {
        _leftSpecification = leftSpecification;
        _rightSpecification = rightSpecification;
    }

    public override bool IsSatisfiedBy(T entity) =>
        _leftSpecification.IsSatisfiedBy(entity) &&
        !_rightSpecification.IsSatisfiedBy(entity);
}

internal class OrSpecification<T> : CompositeSpecification<T>
{
    ISpecification<T> _leftSpecification;
    ISpecification<T> _rightSpecification;

    public OrSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
    {
        _leftSpecification = leftSpecification;
        _rightSpecification = rightSpecification;
    }

    public override bool IsSatisfiedBy(T entity) =>
        _leftSpecification.IsSatisfiedBy(entity) ||
        _rightSpecification.IsSatisfiedBy(entity);
}

internal class OrNotSpecification<T> : CompositeSpecification<T>
{
    ISpecification<T> _leftSpecification;
    ISpecification<T> _rightSpecification;

    public OrNotSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
    {
        _leftSpecification = leftSpecification;
        _rightSpecification = rightSpecification;
    }

    public override bool IsSatisfiedBy(T entity) =>
        _leftSpecification.IsSatisfiedBy(entity) ||
        !_rightSpecification.IsSatisfiedBy(entity);
}

internal class NotSpecification<T> : CompositeSpecification<T>
{
    ISpecification<T> _specification;

    public NotSpecification(ISpecification<T> specification) =>
        _specification = specification;
    public override bool IsSatisfiedBy(T entity) =>
        _specification.IsSatisfiedBy(entity);
}