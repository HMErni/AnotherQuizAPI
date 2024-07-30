using AnotherQuizAPI.Data.UserRepo;
using AnotherQuizAPI.DTOs.UserDTOs;
using AnotherQuizAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnotherQuizAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetAllUsers()
        {
            var users = await _userRepo.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDTO>>(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUserById(int id)
        {
            var user = await _userRepo.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserReadDTO>(user));
        }

        [HttpGet("user")]
        public async Task<ActionResult<UserReadDTO>> GetUserByUsername(string username, string password)
        {
            var user = await _userRepo.GetUserByUsernameAndPassword(username, password);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserReadDTO>(user));
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> CreateUser([FromBody] UserCreateDTO userCreateDTO)
        {
            var user = _mapper.Map<User>(userCreateDTO);

            await _userRepo.AddUser(user);
            await _userRepo.SaveChanges();

            var createdUser = _mapper.Map<UserReadDTO>(user);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserReadDTO>> UpdateUser(int id, [FromBody] UserUpdateDTO userUpdateDTO)
        {
            var user = await _userRepo.GetUserById(id);

            if (user == null)
                return NotFound();

            _mapper.Map(userUpdateDTO, user);

            _userRepo.UpdateUser(user);
            await _userRepo.SaveChanges();

            var updatedUser = _mapper.Map<UserReadDTO>(user);

            return Ok(updatedUser);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userRepo.GetUserById(id);

            if (user == null)
                return NotFound();

            _userRepo.DeleteUser(user);
            await _userRepo.SaveChanges();

            return Ok(user);
        }

    }
}