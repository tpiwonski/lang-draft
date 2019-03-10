using System;
using Lang.Application.Data;
using Lang.Domain.Entities;
using Lang.Interfaces;

namespace Lang.Application.Interactors
{
    public interface IAddWord
    {
        void Execute(WordData data);
    }

    public class AddWord : IAddWord
    {
        private IWordRepository wordRepository;

        public AddWord(IWordRepository wordRepository)
        {
            this.wordRepository = wordRepository;
        }

        public async void Execute(WordData data)
        {
            var word = new Word(
                new Domain.Data.WordData 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = data.Text,
                    Language = data.Language
                }
            );
            wordRepository.AddWord(word);
        }
    }
}
