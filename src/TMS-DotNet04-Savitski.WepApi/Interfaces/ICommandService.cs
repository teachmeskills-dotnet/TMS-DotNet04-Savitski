using System.Collections.Generic;

namespace TMS_DotNet04_Savitski.WepApi.Interfaces
{
    public interface ICommandService
    {
        IEnumerable<ITelegramCommand> Get();
    }
}