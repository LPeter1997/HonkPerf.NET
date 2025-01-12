﻿using System;

namespace Tests.ExtensionsFunctionalTests;

public class MaxTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 1, 7, 3, 4, 5, 1, 1 }
            .ToRefLinq()
            .Max();
        Assert.Equal(7, seq);
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { 2.4, 6.7, -2.4 }
            .ToRefLinq()
            .Max();
        Assert.Equal(6.7, seq);
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new float [] { }
            .ToRefLinq();
        Assert.Throws<InvalidOperationException>(() => seq.Max());
    }

    [Fact]
    public void Test4()
    {
        var seq =
            new float[] { 1.0f }
            .ToRefLinq()
            .Max();
        Assert.Equal(1.0f, seq);
    }
}