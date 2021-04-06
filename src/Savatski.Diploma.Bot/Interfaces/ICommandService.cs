using System.Collections.Generic;

namespace Savatski.Diploma.Bot.Interfaces
{
    public interface ICommandService
    {
        IEnumerable<ITelegramCommand> Get();
    }
}