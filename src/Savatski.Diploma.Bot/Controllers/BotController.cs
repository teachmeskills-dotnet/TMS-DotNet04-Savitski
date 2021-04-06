using Microsoft.AspNetCore.Mvc;
using Savatski.Diploma.Bot.Interfaces;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Savatski.Diploma.Bot.Controllers
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
            if (update == null)
            {
                return NoContent();
            }

            var message = update.Message;

            switch (update.Type)
            {
                case UpdateType.Message:
                    {
                        foreach (var command in _commandService.Get())
                        {
                            if (command.Contains(message))
                            {
                                await command.Execute(message, _telegramBotClient);
                                break;
                            }
                        }
                        break;
                    }
            }

            return Ok();
        }
    }
}