﻿namespace Tests.ExtensionsFunctionalTests;

public class FirstOrDefaultTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 2, 3, 4 }
            .ToRefLinq()
            .FirstOrDefault();
        Assert.Equal(2, seq);
    }
    [Fact]
    public void Test3()
    {
        var seq =
            new int[] { }
            .ToRefLinq()
            .FirstOrDefault();
        Assert.Equal(0, seq);
    }
}