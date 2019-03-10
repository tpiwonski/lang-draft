using System;
using System.Collections.Generic;
using System.Linq;
using Lang.Domain.Entities;
using Lang.Interfaces;
using Lang.Repository.Data;
using Lang.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Lang.Repository
{
    public class WordRepository : IWordRepository
    {
        private readonly Context context;

        public WordRepository(Context context)
        {
            this.context = context;
        }

        public void AddWord(Word word)
        {
            var data = word.GetData();
            if (!(data is WordData))
            {
                context.Words.Add(new WordEntry 
                { 
                    Id = data.Id, 
                    Text = data.Text,
                    Language = data.Language 
                });
            }
            context.SaveChanges();
        }

        public IEnumerable<Word> GetAllWords()
        {
            return context.Words.Select(w => new Word(new WordData(w)));
        }

        public Word GetWordById(string id)
        {
            var word = context.Words.Where(w => w.Id == id).First();
            return new Word(new WordData(word));
        }

        public void UpdateWord(Word word)
        {
            context.SaveChanges();
        }
    }
}