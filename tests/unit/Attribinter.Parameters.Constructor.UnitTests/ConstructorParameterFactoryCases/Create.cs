﻿namespace Attribinter.Parameters.ConstructorParameterFactoryCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private IConstructorParameter Target(IParameterSymbol symbol) => Fixture.Sut.Create(symbol);

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void NullSymbol_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidSymbol_ReturnsConstructorParameter()
    {
        var result = Target(Mock.Of<IParameterSymbol>());

        Assert.NotNull(result);
    }
}
