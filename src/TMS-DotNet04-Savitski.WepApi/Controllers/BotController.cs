using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TMS_DotNet04_Savitski.WepApi.Commands;
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
            if (update == null)
                {
                    return NoContent();
                }

            var message = update.Message;
            var mes = update.CallbackQuery;

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
                //case UpdateType.CallbackQuery:
                //    {
                //        if(mes.ToString() == "myCommand1")
                //        {
                //            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, "salam");
                //        }
                //        break;
                //    }
            }
            return Ok();
        }
    }
}