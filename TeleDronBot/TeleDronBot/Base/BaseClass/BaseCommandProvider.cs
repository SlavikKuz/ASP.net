﻿using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace TeleDronBot.Base.BaseClass
{
    class BaseCommandProvider
    {
        protected TelegramBotClient client;
        protected MainProvider provider;

        public BaseCommandProvider(TelegramBotClient client, MainProvider provider) { }
    }
}
