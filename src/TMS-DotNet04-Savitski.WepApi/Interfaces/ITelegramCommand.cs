using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TMS_DotNet04_Savitski.WepApi.Interfaces
{
    public interface ITelegramCommand
    {
        string Name { get; }

        Task Execute(Message message ,ITelegramCommand client);

        bool Contains(Message message);
    }
}
