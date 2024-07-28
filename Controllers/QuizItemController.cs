using AnotherQuizAPI.Data;
using AnotherQuizAPI.Data.QuizIemRepo;
using AnotherQuizAPI.Data.QuizListRepo;
using AnotherQuizAPI.DTOs.QuizItemDTOs;
using AnotherQuizAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AnotherQuizAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizItemController : ControllerBase
    {
        private readonly IQuizItemRepo _quizItemRepo;
        private readonly IQuizListRepo _quizListRepo;
        private readonly IMapper _mapper;

        public QuizItemController(IQuizItemRepo quizItemRepo, IQuizListRepo quizListRepo, IMapper mapper)
        {
            _quizItemRepo = quizItemRepo;
            _quizListRepo = quizListRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizItemReadDTO>>> GetAllQuizItems()
        {

            var quizItems = await _quizItemRepo.GetAllQuizItems();

            return Ok(_mapper.Map<IEnumerable<QuizItemReadDTO>>(quizItems));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizItemReadDTO>> GetQuizItemById(int id)
        {
            var quizItem = await _quizItemRepo.GetQuizItemById(id);

            if (quizItem == null)
                return NotFound();

            return Ok(_mapper.Map<QuizItemReadDTO>(quizItem));
        }

        [HttpGet("quizList/{quizListId}")]
        public async Task<ActionResult<IEnumerable<QuizItemReadDTO>>> GetAllQuizItemsByQuizList(int quizListId)
        {
            var quizItems = await _quizItemRepo.GetAllQuizItemsByQuizList(quizListId);

            if (quizItems.IsNullOrEmpty())
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<QuizItemReadDTO>>(quizItems));
        }

        [HttpPost]
        public async Task<ActionResult<QuizItemReadDTO>> AddQuizItem([FromBody] QuizItemCreateDTO quizItemCreateDTO)
        {
            var quizItem = _mapper.Map<QuizItem>(quizItemCreateDTO);
            var quizList = await _quizListRepo.GetQuizListById(quizItemCreateDTO.QuizListId);

            if (quizList == null)
                return NotFound();

            quizItem.QuizList = quizList;

            await _quizItemRepo.AddQuizItem(quizItem);
            await _quizItemRepo.SaveChanges();

            var quizItemRead = _mapper.Map<QuizItemReadDTO>(quizItem);

            return CreatedAtAction(nameof(GetQuizItemById), new { id = quizItem.Id }, quizItemRead);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QuizItemReadDTO>> UpdateQuizItem(int id, [FromBody] QuizItemUpdateDTO quizItemUpdateDTO)
        {
            var quizItem = await _quizItemRepo.GetQuizItemById(id);

            if (quizItem == null)
                return NotFound();

            _mapper.Map(quizItemUpdateDTO, quizItem);
            _quizItemRepo.UpdateQuizItem(quizItem);
            await _quizItemRepo.SaveChanges();

            var quizItemRead = _mapper.Map<QuizItemReadDTO>(quizItem);

            return Ok(quizItemRead);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteQuizItem(int id)
        {
            var quizItem = await _quizItemRepo.GetQuizItemById(id);

            if (quizItem == null)
                return NotFound();

            _quizItemRepo.DeleteQuizItem(quizItem);
            await _quizItemRepo.SaveChanges();

            return Ok(quizItem);
        }



    }
}