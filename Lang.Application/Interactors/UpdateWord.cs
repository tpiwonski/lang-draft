using System.Linq;
using Lang.Application.Data;
using Lang.Domain.Entities;
using Lang.Interfaces;

namespace Lang.Application.Interactors
{
    public interface IUpdateWord
    {
        void Execute(WordData data);
    }

    public class UpdateWord : IUpdateWord
    {
        private readonly IWordRepository wordRepository;
        
        public UpdateWord(IWordRepository wordRepository)
        {
            this.wordRepository = wordRepository;
        }

        public void Execute(WordData data)
        {
            var word = wordRepository.GetWordById(data.Id);
            word.Update(data.Text);
            this.wordRepository.AddWord(word);
        }
    }
}