using Lang.Domain.Data;

namespace Lang.Domain.Entities
{
    public class Word
    {
        private WordData data;
        
        public Word(WordData data)
        {
            this.data = data;
        }

        public WordData GetData()
        {
            return data;
        }

        public void Update(string text)
        {
            data.Text = text;
        }
    }
}