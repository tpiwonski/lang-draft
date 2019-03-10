using Lang.Repository.Models;

namespace Lang.Repository.Data
{
    public class WordData : Lang.Domain.Data.WordData
    {
        private readonly WordEntry entry;

        public WordData(WordEntry entry)
        {
            this.entry = entry;
        }

        public override string Id 
        { 
            get { return entry.Id; } 
            set { entry.Id = value; } 
        }
        public override string Text 
        { 
            get { return entry.Text; }
            set { entry.Text = value; }
        }
        public override string Language 
        { 
            get { return entry.Language; }
            set { entry.Language = value; }
        }
    }
}