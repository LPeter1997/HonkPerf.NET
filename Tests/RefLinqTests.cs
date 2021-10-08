using HonkPerf.NET.RefLinq;
using System.Collections.Generic;
using Xunit;

namespace Tests;

public class RefLinqTests
{
    [Fact]
    public void Test1()
    {
        var list = new List<int>();
        var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.It();
        var seq = z
            .RefSelect<int, string, IReadOnlyListEnumerator<int>>(c => c.ToString())
            .RefWhere<string, Select<int, string, IReadOnlyListEnumerator<int>>>(c => c.Length > 1)
            .RefSelect<string, int, Where<string, Select<int, string, IReadOnlyListEnumerator<int>>>>(c => int.Parse(c) * 100);

        foreach (var a in seq)
            list.Add(a);

        Assert.Equal(list, new [] { 1000, 2000, 3000, 50200, 234200, 2300 });
    }

    [Fact]
    public void NoMoreCallsThanNeeded()
    {
        var list = new List<int>();
        var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.It();
        var calls1 = 0;
        var calls2 = 0;
        var calls3 = 0;
        var log = new List<string>();
        var seq = z
            .RefSelect<int, string, IReadOnlyListEnumerator<int>>(c => 
                {
                    calls1++;
                    log.Add(c.ToString());
                    return c.ToString();
                })
            .RefWhere<string, Select<int, string, IReadOnlyListEnumerator<int>>>(c => 
                {
                    calls2++;
                    return c.Length > 1;
                })
            .RefSelect<string, int, Where<string, Select<int, string, IReadOnlyListEnumerator<int>>>>(c =>
                {
                    calls3++;
                    return int.Parse(c) * 100;
                });

        foreach (var a in seq)
            // list.Add(int.Parse(a));
            list.Add(a);

        Assert.Equal(9, calls1);
        Assert.Equal(9, calls2);
        Assert.Equal(6, calls3);
    }
}