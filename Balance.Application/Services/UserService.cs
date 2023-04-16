using AutoMapper;
using Balance.Application.Dtos;
using Balance.Core.Constants;
using Balance.Core.Entities;
using Balance.Core.Exceptions;
using Balance.Core.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly ICryptoService _cryptoService;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, ICryptoService cryptoService, IMapper mapper) 
        {
            _userRepo = userRepo;
            _cryptoService = cryptoService;
            _mapper = mapper;
        }
        public async Task<User>  AuthenticateAsync(string username, string password)
        {
            bool invalidCredentials = false;

            var user = await _userRepo.GetByUsernameAsync(username);

            if (user == null)
            {
                invalidCredentials = true;
            }
            else
            {
                string passwordHash = user.Password;
                string passwordSalt = user.PasswordSalt;

                bool isValid = _cryptoService.VerifyHashedPassword(password, passwordHash, passwordSalt);

                if (!isValid)
                {
                    invalidCredentials = true;
                }
            }

            if (invalidCredentials)
            {
                throw new InvalidCredentailsException();
            }

            return user;
        }

        public async Task<User> RegisterAsync(UserDto userDto)
        {
            var usr = await _userRepo.GetByUsernameAsync(userDto.Username);

            //if user found with the requested username
            if (usr != null)
            {
                throw new UserAlreadyExistsException();
            }

            //Calculate password hash and salt
            (var passwordHash, var passwordSalt) = _cryptoService.HashPassword(userDto.Password);

            var user = _mapper.Map<User>(userDto);
            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Balance = 5;

            await _userRepo.InsertAsync(user);
            return user;
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepo.GetByIdAsync(id);
        }
    }
}
