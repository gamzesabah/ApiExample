using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Hashing.Core.Utilities.Security.Hashing;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security;
using Entities.Dtos;
using Business.Constants;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserCustomService _userCutomService;
        private ITokenHelper _tokenHelper;
        private IUserService _userService;
        private readonly LoggedInUsers _loggedInUsers;
        public AuthManager(IUserCustomService userCutomService, ITokenHelper tokenHelper, IUserService userService, LoggedInUsers loggedInUsers)
        {
            _userCutomService = userCutomService;
            _tokenHelper = tokenHelper;
            _userService = userService;
            _loggedInUsers = loggedInUsers;
        }

        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                Name = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var result = await _userCutomService.AddAsync(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {

            var userToCheck = await _userCutomService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            _loggedInUsers.UserInfo = _loggedInUsers.UserInfo.Where(x => x.UserId != userToCheck.Id).ToList();
            _loggedInUsers.UserInfo.Add(new Core.Utilities.Security.Options.UserInfo
            {
                FullName = userToCheck.Name + " " + userToCheck.LastName,
                UserId = userToCheck.Id,
                Roles = _userCutomService.GetClaims(userToCheck)

            });
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public async Task<IResult> UserExists(string email)
        {
            var user = await _userCutomService.GetByMail(email);
            if (user != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userCutomService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }

}
