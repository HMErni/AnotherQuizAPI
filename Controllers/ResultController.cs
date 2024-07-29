using AnotherQuizAPI.Data.QuizListRepo;
using AnotherQuizAPI.Data.ResultRepo;
using AnotherQuizAPI.Data.UserRepo;
using AnotherQuizAPI.DTOs.ResultDTOs;
using AnotherQuizAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnotherQuizAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepo _resultRepo;
        private readonly IUserRepo _userRepo;
        private readonly IQuizListRepo _quizListRepo;
        private readonly IMapper _mapper;

        public ResultController(IResultRepo resultRepo, IUserRepo userRepo, IQuizListRepo quizListRepo, IMapper mapper)
        {
            _resultRepo = resultRepo;
            _userRepo = userRepo;
            _quizListRepo = quizListRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ResultReadDTO>> GetAllResult()
        {
            var result = await _resultRepo.GetAllResult();
            return _mapper.Map<IEnumerable<ResultReadDTO>>(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultReadDTO>> GetResultById(int id)
        {
            var result = await _resultRepo.GetResultById(id);

            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<ResultReadDTO>(result));

        }

        [HttpGet("{id}/{userId}")]
        public async Task<ActionResult<ResultReadDTO>> GetResultByIdAndUserId(int id, int userId)
        {
            var result = await _resultRepo.GetResultByIdAndUserId(id, userId);

            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<ResultReadDTO>(result));
        }

        [HttpPost]
        public async Task<ActionResult<ResultReadDTO>> CreateResult([FromBody] ResultCreateDTO resultCreateDTO)
        {
            var result = _mapper.Map<Result>(resultCreateDTO);

            var user = await _userRepo.GetUserById(result.UserId);

            var quizList = await _quizListRepo.GetQuizListById(result.QuizListId);

            if (user == null || quizList == null)
                return NotFound();

            result.User = user;
            result.QuizLists = quizList;

            await _resultRepo.AddResult(result);
            await _resultRepo.SaveChanges();

            var createdResult = _mapper.Map<ResultReadDTO>(result);

            return CreatedAtAction(nameof(GetResultById), new { id = result.Id }, createdResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResultReadDTO>> UpdateResult(int id, [FromBody] ResultUpdateDTO resultUpdateDTO)
        {
            var result = await _resultRepo.GetResultById(id);

            if (result == null)
                return NotFound();

            _mapper.Map(resultUpdateDTO, result);
            _resultRepo.UpdateResult(result);

            await _resultRepo.SaveChanges();
            var updatedResult = _mapper.Map<ResultReadDTO>(result);
            return Ok(updatedResult);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteResult(int id)
        {
            var result = await _resultRepo.GetResultById(id);

            if (result == null)
                return NotFound();

            _resultRepo.DeleteResult(result);

            await _resultRepo.SaveChanges();

            return NoContent();
        }
    }
}