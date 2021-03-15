using System.Collections.Generic;
using TMS_DotNet04_Savitski.WepApi.Commands;
using TMS_DotNet04_Savitski.WepApi.Interfaces;

namespace TMS_DotNet04_Savitski.WepApi.Services
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