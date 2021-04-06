using Savatski.Diploma.Bot.Commands;
using Savatski.Diploma.Bot.Interfaces;
using System.Collections.Generic;

namespace Savatski.Diploma.Bot.Services
{
    public class CommandService : ICommandService
    {
        private readonly IEnumerable<ITelegramCommand> _commands;

        public CommandService(IEnumerable<ITelegramCommand> commands)
        {
            _commands = new List<ITelegramCommand>
            {
                new StartCommand(),
                new AboutCommand(),
                new NbRateCommand(),
                new Myfin_MinskCommand(),
                new Myfin_SvetlogorskCommand()
            };
        }

        public IEnumerable<ITelegramCommand> Get() => _commands;
    }
}