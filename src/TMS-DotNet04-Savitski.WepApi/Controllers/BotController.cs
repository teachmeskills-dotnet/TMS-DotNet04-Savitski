using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TMS_DotNet04_Savitski.WepApi.Interfaces;

namespace TMS_DotNet04_Savitski.WepApi.Controllers
{
    [ApiController]
    [Route("api/message/update")]
    public class BotController : ControllerBase
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly ICommandService _commandService;

        public BotController(ITelegramBotClient telegramBotClient, ICommandService commandService)
        {
            _telegramBotClient = telegramBotClient;
            _commandService = commandService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Update update)
        {
            if(update == null)
            {
                return NoContent();
            }

            var message = update.Message;

            foreach (var command in _commandService.Get())
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, (ITelegramBotClient)_telegramBotClient);
                    break;
                }
            }

            return Ok();
        }
    }
}
