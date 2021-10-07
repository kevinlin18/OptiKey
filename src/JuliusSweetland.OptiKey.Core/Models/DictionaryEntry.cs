// Copyright (c) 2020 OPTIKEY LTD (UK company number 11854839) - All Rights Reserved
using System.Diagnostics;

namespace JuliusSweetland.OptiKey.Models
{
    [DebuggerDisplay("'{Entry}' used {UsageCount}")]
    public class DictionaryEntry
    {
        public DictionaryEntry(string entry, string entryValue, int usageCount = 0)
        {
            Entry = entry;
            EntryValue = entryValue;
            UsageCount = usageCount;
        }

        public string Entry { get; private set; }
        public string EntryValue { get; private set; }

        public int UsageCount { get; set; }
    }
}