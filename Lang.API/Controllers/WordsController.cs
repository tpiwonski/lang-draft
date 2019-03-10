using System.Collections.Generic;
using System.Linq;
using Lang.Application.Interactors;
using Lang.Application.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lang.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IAddWord addWord;
        private readonly IGetWords getWords;
        private readonly IUpdateWord updateWord;

        public WordsController(IAddWord addWord, IGetWords getWords, IUpdateWord updateWord)
        {
            this.addWord = addWord;
            this.getWords = getWords;
            this.updateWord = updateWord;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WordData>> Get()
        {
            return getWords.Execute().ToArray();
        }

        [HttpPost]
        public void Post([FromBody] WordData data)
        {
            addWord.Execute(data);
        }

        [HttpPut]
        public void Put([FromBody] WordData data)
        {
            updateWord.Execute(data);
        }
    }
}