using AnotherQuizAPI.Data.UserRepo;
using AnotherQuizAPI.DTOs.LoginDTOs;
using AnotherQuizAPI.DTOs.UserDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnotherQuizAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public LoginController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = await _userRepo.GetUserByUsernameAndPassword(userLoginDTO.Username, userLoginDTO.Password);

            if (user == null)
                return Unauthorized(new { message = "Username or Password is incorrect" });

            return Ok(_mapper.Map<UserReadDTO>(user));
        }


    }
}