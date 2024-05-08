// ReSharper disable UnusedMemberInSuper.Global

using System.Collections.Immutable;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Bogus;
using Bogus.DataSets;
using Interview.Test.Internal;
using Database = Bogus.DataSets.Database;

namespace Interview.Test;

public interface IDataFactory : IFactories
{
    T Create<T>();
    T Create<T>(Func<T, T> customization);
    T Create<T>(Action<T> customization) where T : class;
    T[] CreateMany<T>(int count, Func<T, T>? customization = default);
}

public interface IFactories
{
    Address Address { get; }
    Commerce Commerce { get; }
    Company Company { get; }
    Database Database { get; }
    Date Date { get; }
    Finance Finance { get; }
    Images Images { get; }
    Internet Internet { get; }
    Lorem Lorem { get; }
    Music Music { get; }
    Name Name { get; }
    PhoneNumbers Phone { get; }
    Rant Rant { get; }
    Bogus.DataSets.System System { get; }
    Vehicle Vehicle { get; }
}

public class DefaultDataFactory : IDataFactory
{
    private readonly IFixture _fixture;
    private readonly Faker _faker = new();
    private Config? Customizations { get; }

    public delegate void Config(IFixture fixture, IFactories factories);

    public DefaultDataFactory(Config? customizations = default, bool useTracingBehavior = false)
    {
        Customizations = (fixture, factories) =>
        {
            fixture.Register(() => ImmutableHashSet<Guid>.Empty);
            fixture.Register(() => ImmutableList<Guid>.Empty);
            customizations?.Invoke(fixture, factories);
        };

        _fixture = new Fixture().Customize(new CompositeCustomization(
            new AutoNSubstituteCustomization(),
            new UserCustomizations(this),
            new DisposableTrackingCustomization()
        ));

        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));

        if (useTracingBehavior)
            _fixture.Behaviors.Add(new TracingBehavior());

        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    public T Create<T>() => _fixture.Create<T>();
    public T Create<T>(Func<T, T> customization) => Create<T>().Then(customization);
    public T Create<T>(Action<T> customization) where T : class => Create<T>().Then(customization);

    public T[] CreateMany<T>(int count, Func<T, T>? customization = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(count);

        return _fixture.CreateMany<T>(count).Aggregate(
            seed: ImmutableList.Create<T>(),
            func: (list, instance) => list.Add(customization is null ? instance : customization.Invoke(instance))
        ).ToArray();
    }

    public Address Address => _faker.Address;
    public Commerce Commerce => _faker.Commerce;
    public Company Company => _faker.Company;
    public Database Database => _faker.Database;
    public Date Date => _faker.Date;
    public Finance Finance => _faker.Finance;
    public Images Images => _faker.Image;
    public Internet Internet => _faker.Internet;
    public Lorem Lorem => _faker.Lorem;
    public Music Music => _faker.Music;
    public Name Name => _faker.Name;
    public PhoneNumbers Phone => _faker.Phone;
    public Rant Rant => _faker.Rant;
    public Bogus.DataSets.System System => _faker.System;
    public Vehicle Vehicle => _faker.Vehicle;

    class UserCustomizations(DefaultDataFactory context) : ICustomization
    {
        public void Customize(IFixture fixture) => context.Customizations?.Invoke(fixture, context);
    }
}
