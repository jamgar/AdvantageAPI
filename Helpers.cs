using System;
using System.Collections.Generic;

namespace Advantage.API
{
  public class Helpers
  {
    private static Random _rand = new Random();

    private static string GetRandom(IList<string> items)
    {
      return items[_rand.Next(items.Count)];
    }
    internal static string MakeUniqueCustomerName(List<string> names)
    {
      var maxNames = bizPrefix.Count * bizSuffix.Count;

      if (names.Count >= maxNames)
      {
        throw new System.InvalidOperationException("Maximum number of unique names exceeded");
      }

      var prefix = GetRandom(bizPrefix);
      var suffix = GetRandom(bizSuffix);
      var bizName = prefix + suffix;

      if (names.Contains(bizName))
      {
        MakeUniqueCustomerName(names);
      }

      return bizName;
    }

    internal static string MakeCustomerEmail(string customerName)
    {
      return $"contact@{customerName.ToLower()}.com";
    }

    internal static string GetRandomState()
    {
      return GetRandom(usStates);
    }

    internal static decimal GetRandomOrderTotal()
    {
      return _rand.Next(100, 5000);
    }

    internal static DateTime GetRandomOrderPlaced()
    {
      var end = DateTime.Now;
      var start = end.AddDays(-90);

      TimeSpan possibleSpan = end - start;
      TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes), 0);

      return start + newSpan;
    }

    internal static DateTime? GetRandomOrderCompleted(DateTime orderPlaced)
    {
      var now = DateTime.Now;
      var minLeadTime = TimeSpan.FromDays(7);
      var timePassed = now - orderPlaced;

      if (timePassed < minLeadTime)
      {
        return null;
      }

      return orderPlaced.AddDays(_rand.Next(7, 14));
    }

    private static readonly List<string> usStates = new List<string>()
    {
      "AK", "AL", "AZ", "AR", "CA", "CO", "DE", "FL", "GA",
      "HI", "ID", "IL", "IN", "KS", "KY", "LA", "ME", "MD",
      "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NJ"
    };

    private static readonly List<string> bizPrefix = new List<string>()
    {
      "Skiptube",
      "Wikibox",
      "Twitterbridge",
      "Vipe",
      "Topdrive",
      "Thoughtblab",
      "Omba",
      "Katz",
      "Riffwire",
      "Yozio",
      "Youtags",
      "Yotz",
      "Oyoba",
      "Trilia",
      "Flashdog",
      "Mita",
      "Tagcat",
      "Abata",
      "Jabbersphere",
      "Quimm",
      "Bubblebox"
    };

    private static readonly List<string> bizSuffix = new List<string>()
    {
      "Yakijo",
      "Edgeblab",
      "Quamba",
      "Edgetag",
      "Nlounge",
      "Twitist",
      "Tambee",
      "Skyble",
      "Linktype",
      "Skaboo",
      "Gigaclub",
      "Voolia",
      "Fadeo",
      "Flashspan",
      "Jabbersphere",
      "Shufflebeat",
      "Kaymbo",
      "Fiveclub",
      "Buzzbean",
      "Ailane"
    };
  }
}