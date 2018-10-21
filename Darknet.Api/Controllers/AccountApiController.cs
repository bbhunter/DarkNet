﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Darknet.Models;
using Darknet.Repository;
using Microsoft.Extensions.Options;

namespace Darknet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        IAccountRepository _userRepository;
        public AccountApiController(IAccountRepository userRepository) {
            _userRepository = userRepository;
        }

        [Route("RegisterUser")]
        [HttpPost]
        public string RegisterUser([FromBody] UserRegistrationModel userRegistrationModel) {
            string statusMsg = "";
            statusMsg = _userRepository.RegisterUser(userRegistrationModel);
            return statusMsg;
        }

        [Route("AuthenticateUser")]
        [HttpPost]
        public string AuthenticateUser([FromBody] UserCredentialsModel userCredentialsModel)
        {
            string statusMsg = "";
            statusMsg = _userRepository.AuthenticateUser(userCredentialsModel);
            return statusMsg;
        }
    }
}