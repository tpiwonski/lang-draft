using System;
using System.Collections.Generic;
using Lang.Domain.Entities;

namespace Lang.Interfaces
{
    public interface IWordRepository
    {
        void AddWord(Word word);
        Word GetWordById(string id);
        IEnumerable<Word> GetAllWords();
    }
}
