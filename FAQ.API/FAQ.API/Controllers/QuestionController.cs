﻿using FAQ.Datas.Facades.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DATAS = FAQ.Datas.Facades;
using FAQ.Datas;
using System.IO;
using FAQ.Datas.Models;
using AutoMapper;
using FAQ.API.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace FAQ.API.Controllers
{
    [ApiController]
    [Route("question")]
    public class QuestionController
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IMapper _mapper;
        private readonly Facade _facade;

        public QuestionController(ILogger<QuestionController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _facade = new Facade(Path.Combine("FAQ-Tests.db"));
        }

        [HttpGet("{id}")]
        public QuestionModelDto GetQuestion([FromRoute][Required] int id, string language)
        {
            var testQuestion = _facade.GetQuestion(language, id);

            var hello = _mapper.Map<QuestionModelDto>(testQuestion);

            return hello;
        }
    }
}
