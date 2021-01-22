using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_DotNet04_Savitski.WepApi.Interfaces
{
    public interface ICommandService
    {
        IEnumerable<ITelegramCommand> Get();
    }
}
