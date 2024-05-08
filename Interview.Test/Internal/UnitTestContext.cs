using System.Diagnostics.CodeAnalysis;
using AutoFixture;
using Bogus.DataSets;
using Database = Bogus.DataSets.Database;

namespace Interview.Test;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
public abstract class UnitTestContext
{
    #region Internal

    private readonly DefaultDataFactory _testFactory;
    protected UnitTestContext() => _testFactory = new DefaultDataFactory(CustomizeFactories);

    //@formatter:off
    public virtual void Dispose() { }
    protected virtual void CustomizeFactories(IFixture fixture, IFactories factories) { }
    //@formatter:on

    #region IDataFactory

    public T Create<T>() => _testFactory.Create<T>();
    public T Create<T>(Func<T, T> customization) => _testFactory.Create(customization);
    public T Create<T>(Action<T> customization) where T : class => _testFactory.Create(customization);

    public T[] CreateMany<T>(int count, Func<T, T>? customization = default) =>
        _testFactory.CreateMany(count, customization);

    public Address Address => _testFactory.Address;
    public Commerce Commerce => _testFactory.Commerce;
    public Company Company => _testFactory.Company;
    public Database Database => _testFactory.Database;
    public Date Date => _testFactory.Date;
    public Finance Finance => _testFactory.Finance;
    public Images Images => _testFactory.Images;
    public Internet Internet => _testFactory.Internet;
    public Lorem Lorem => _testFactory.Lorem;
    public Music Music => _testFactory.Music;
    public Name Name => _testFactory.Name;
    public PhoneNumbers Phone => _testFactory.Phone;
    public Rant Rant => _testFactory.Rant;
    public Bogus.DataSets.System System => _testFactory.System;
    public Vehicle Vehicle => _testFactory.Vehicle;

    #endregion

    #endregion
}