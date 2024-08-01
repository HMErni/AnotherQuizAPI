using AnotherQuizAPI.Data.QuizListRepo;
using AnotherQuizAPI.DTOs.QuizListDTOs;
using AnotherQuizAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnotherQuizAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizListController : ControllerBase
    {
        private readonly IQuizListRepo _quizListRepo;
        private readonly IMapper _mapper;

        public QuizListController(IQuizListRepo quizListRepo, IMapper mapper)
        {
            _quizListRepo = quizListRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizListReadDTO>>> GetAllQuizLists()
        {
            var quizLists = await _quizListRepo.GetAllQuizLists();

            return Ok(_mapper.Map<IEnumerable<QuizListReadDTO>>(quizLists));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizListReadDTO>> GetQuizListById(int id)
        {
            var quizList = await _quizListRepo.GetQuizListById(id);

            if (quizList == null)
                return NotFound();

            return Ok(_mapper.Map<QuizListReadDTO>(quizList));
        }

        [HttpPost]
        public async Task<ActionResult<QuizListReadDTO>> AddQuizList([FromBody] QuizListCreateDTO quizListCreateDTO)
        {
            var quizList = _mapper.Map<QuizList>(quizListCreateDTO);

            await _quizListRepo.AddQuizList(quizList);
            await _quizListRepo.SaveChanges();

            var quizListRead = _mapper.Map<QuizListReadDTO>(quizList);

            return CreatedAtAction(nameof(GetQuizListById), new { id = quizList.Id }, quizListRead);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QuizListReadDTO>> UpdateQuizList(int id, [FromBody] QuizListUpdateDTO quizListUpdateDTO)
        {
            var quizList = await _quizListRepo.GetQuizListById(id);

            if (quizList == null)
                return NotFound();

            _mapper.Map(quizListUpdateDTO, quizList);
            _quizListRepo.UpdateQuizList(quizList);
            await _quizListRepo.SaveChanges();

            var quizListRead = _mapper.Map<QuizListReadDTO>(quizList);

            return Ok(quizListRead);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuizList(int id)
        {
            var quizList = await _quizListRepo.GetQuizListById(id);

            if (quizList == null)
                return NotFound();

            _quizListRepo.DeleteQuizList(quizList);
            await _quizListRepo.SaveChanges();

            return Ok(quizList);
        }
    }
}