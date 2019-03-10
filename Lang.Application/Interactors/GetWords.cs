using System.Collections.Generic;
using System.Linq;
using Lang.Application.Data;
using Lang.Domain.Entities;
using Lang.Interfaces;

namespace Lang.Application.Interactors
{
    public interface IGetWords
    {
        IEnumerable<WordData> Execute();
    }

    public class GetWords : IGetWords
    {
        private readonly IWordRepository wordRepository;

        public GetWords(IWordRepository wordRepository)
        {
            this.wordRepository = wordRepository;
        }
        
        public IEnumerable<WordData> Execute()
        {
            return wordRepository
                .GetAllWords()
                .Select(w => w.GetData())
                .Select(d => new WordData 
                { 
                    Id = d.Id, 
                    Text = d.Text,
                    Language = d.Language 
                }
            );
        }
    }
}